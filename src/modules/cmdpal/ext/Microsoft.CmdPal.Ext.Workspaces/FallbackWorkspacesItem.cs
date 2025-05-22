// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.CmdPal.Ext.Workspaces.Properties;
using Microsoft.CmdPal.Ext.Workspaces.WorkspacesHelper;
using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace Microsoft.CmdPal.Ext.Workspaces
{
    internal sealed partial class FallbackWorkspacesItem : FallbackCommandItem
    {
        private readonly HashSet<string> _validOptions;
        private readonly WorkspacesAPI _workspacesApi;
        private Workspace _matchedWorkspace;

        public FallbackWorkspacesItem(WorkspacesAPI workspacesApi)
             : base(new NoOpCommand(), Resources.plugin_workspaces_fallback_display_title)
        {
            Title = string.Empty;
            Subtitle = string.Empty;
            _workspacesApi = workspacesApi;
            
            // Define valid search options
            var searchTags = Resources.plugin_workspaces_search_tag.Split(';', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            _validOptions = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            
            foreach (var tag in searchTags)
            {
                _validOptions.Add(tag);
            }
        }

        public override void UpdateQuery(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                Title = string.Empty;
                Subtitle = string.Empty;
                Command = new NoOpCommand();
                return;
            }

            // Check if the query is a search tag (like "workspace" or "ws")
            bool isSearchTag = IsValidSearchTag(query);

            // Refresh workspaces list
            _workspacesApi.LoadWorkspaces();

            // Find best matching workspace
            if (_workspacesApi.Workspaces.Count > 0)
            {
                // If query is just a search tag, show the first workspace
                if (isSearchTag && !query.Contains(' '))
                {
                    _matchedWorkspace = _workspacesApi.Workspaces.FirstOrDefault();
                    if (_matchedWorkspace != null)
                    {
                        UpdateWithWorkspace(_matchedWorkspace);
                        return;
                    }
                }
                // Otherwise, search for workspace by name
                else
                {
                    string searchTerm = query;
                    // If query starts with a search tag, remove it
                    foreach (var tag in _validOptions)
                    {
                        if (query.StartsWith(tag + " ", StringComparison.OrdinalIgnoreCase))
                        {
                            searchTerm = query.Substring(tag.Length + 1);
                            break;
                        }
                    }

                    // Search for workspace by name
                    var bestMatch = FindBestMatch(searchTerm);
                    if (bestMatch != null)
                    {
                        _matchedWorkspace = bestMatch;
                        UpdateWithWorkspace(bestMatch);
                        return;
                    }
                }
            }

            // No match found
            Title = string.Empty;
            Subtitle = string.Empty;
            Command = new NoOpCommand();
        }

        private Workspace FindBestMatch(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return null;
            }

            Workspace bestMatch = null;
            int bestScore = int.MinValue;

            foreach (var workspace in _workspacesApi.Workspaces)
            {
                if (workspace.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                {
                    int score = CalculateMatchScore(workspace.Name, searchTerm);
                    if (score > bestScore)
                    {
                        bestScore = score;
                        bestMatch = workspace;
                    }
                }
            }

            return bestMatch;
        }

        private int CalculateMatchScore(string name, string searchTerm)
        {
            // Simple scoring - exact match gets highest score
            if (string.Equals(name, searchTerm, StringComparison.OrdinalIgnoreCase))
            {
                return 100;
            }

            // Starts with gets second highest score
            if (name.StartsWith(searchTerm, StringComparison.OrdinalIgnoreCase))
            {
                return 75;
            }

            // Contains gets third highest score
            if (name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            {
                return 50;
            }

            // Default score for any other match
            return 25;
        }

        private void UpdateWithWorkspace(Workspace workspace)
        {
            Title = workspace.Name;
            Subtitle = Resources.plugin_workspaces_workspace;
            Icon = new IconInfo("\uE71D"); // Using a default grid icon
            Command = new LaunchWorkspaceCommand(workspace);
        }

        private bool IsValidSearchTag(string query)
        {
            // Check if the query starts with a search tag
            foreach (var option in _validOptions)
            {
                if (string.Equals(option, query, StringComparison.OrdinalIgnoreCase) ||
                    query.StartsWith(option + " ", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
    }
}