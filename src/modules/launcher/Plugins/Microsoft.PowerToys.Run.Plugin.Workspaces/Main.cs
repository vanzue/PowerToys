// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Microsoft.PowerToys.Run.Plugin.Workspaces.Properties;
using Microsoft.PowerToys.Run.Plugin.Workspaces.WorkspacesHelper;
using Wox.Plugin;
using Wox.Plugin.Logger;

namespace Microsoft.PowerToys.Run.Plugin.Workspaces
{
    public class Main : IPlugin, IPluginI18n, IDisposable
    {
        private PluginInitContext _context;
        private string _iconPath;
        private bool _disposed;
        private readonly WorkspacesAPI _workspacesApi;

        public Main()
        {
            _workspacesApi = WorkspacesAPI.Instance;
        }

        public string Name => Resources.wox_plugin_workspaces_plugin_name;

        public string Description => Resources.wox_plugin_workspaces_plugin_description;

        public static string PluginID => "24FFBA81A11C43719403ACFC5C086CDF";

        public List<Result> Query(Query query)
        {
            var results = new List<Result>();

            if (query?.Search == null)
            {
                return results;
            }

            // Refresh workspaces list
            _workspacesApi.LoadWorkspaces();

            // Search through workspaces
            foreach (var workspace in _workspacesApi.Workspaces)
            {
                if (string.IsNullOrEmpty(query.Search) || 
                    workspace.Name.Contains(query.Search, StringComparison.OrdinalIgnoreCase))
                {
                    var result = new Result
                    {
                        Title = workspace.Name,
                        SubTitle = $"{Resources.wox_plugin_workspaces_workspace}",
                        Icon = _iconPath,
                        Score = 100,
                        Action = c =>
                        {
                            bool success = WorkspacesLauncher.LaunchWorkspace(workspace);
                            return success;
                        },
                    };

                    results.Add(result);
                }
            }

            // Apply scoring for results based on match
            results.ForEach(x =>
            {
                if (x.Score == 0)
                {
                    x.Score = 100;
                }

                // Rank results based on matching
                if (!string.IsNullOrEmpty(query.Search))
                {
                    // Calculate score based on how closely the title matches the search query
                    var intersection = x.Title.ToLowerInvariant().Intersect(query.Search.ToLowerInvariant()).Count() * query.Search.Length;
                    var differenceWithQuery = (x.Title.Length - intersection) * query.Search.Length * 0.7;
                    x.Score = Math.Max(0, x.Score - (int)differenceWithQuery + intersection);
                }
            });

            // Sort by score, or by name if scores are equal or search is empty
            results = results.OrderByDescending(x => x.Score).ToList();
            if (string.IsNullOrWhiteSpace(query.Search))
            {
                results = results.OrderBy(x => x.Title).ToList();
            }

            return results;
        }

        public void Init(PluginInitContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _context.API.ThemeChanged += OnThemeChanged;
            UpdateIconPath(_context.API.GetCurrentTheme());
        }

        private void UpdateIconPath(Theme theme)
        {
            if (theme == Theme.Light || theme == Theme.HighContrastWhite)
            {
                _iconPath = "Images/workspaces.light.png";
            }
            else
            {
                _iconPath = "Images/workspaces.dark.png";
            }
        }

        private void OnThemeChanged(Theme currentTheme, Theme newTheme)
        {
            UpdateIconPath(newTheme);
        }

        public string GetTranslatedPluginTitle()
        {
            return Resources.wox_plugin_workspaces_plugin_name;
        }

        public string GetTranslatedPluginDescription()
        {
            return Resources.wox_plugin_workspaces_plugin_description;
        }

        public Control CreateSettingPanel()
        {
            return null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                if (_context != null && _context.API != null)
                {
                    _context.API.ThemeChanged -= OnThemeChanged;
                }

                _disposed = true;
            }
        }
    }
}