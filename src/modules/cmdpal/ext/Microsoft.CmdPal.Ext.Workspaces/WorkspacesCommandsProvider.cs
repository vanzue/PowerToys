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
    public partial class WorkspacesCommandsProvider : CommandProvider
    {
        private readonly WorkspacesAPI _workspacesApi;
        private readonly FallbackWorkspacesItem _fallbackWorkspacesItem;
        private readonly CommandItem _command;

        public WorkspacesCommandsProvider()
        {
            _workspacesApi = WorkspacesAPI.Instance;
            DisplayName = Resources.plugin_workspaces_name;
            Id = "Workspaces";
            
            // Create icon with glyph, you can also use "new IconInfo(new Uri("ms-appx:///Assets/Workspaces.png"))" if you add an image
            Icon = new IconInfo("\uE71D"); // Using a default grid icon; replace with a specific workspace icon if available

            _fallbackWorkspacesItem = new FallbackWorkspacesItem(_workspacesApi);
            
            // Create main command
            _command = new CommandItem(new WorkspacesCommandAction(_workspacesApi))
            {
                Icon = Icon,
                Title = Resources.plugin_workspaces_name,
                Subtitle = Resources.plugin_workspaces_description,
            };
        }

        public override ICommandItem[] TopLevelCommands() => [_command];

        public override IFallbackCommandItem[] FallbackCommands() => [_fallbackWorkspacesItem];
    }

    internal sealed class WorkspacesCommandAction : InvokableCommand
    {
        private readonly WorkspacesAPI _workspacesApi;

        public WorkspacesCommandAction(WorkspacesAPI workspacesApi)
        {
            _workspacesApi = workspacesApi;
            Name = Resources.plugin_workspaces_name;
            Icon = new IconInfo("\uE71D"); // Using a default grid icon
        }

        public override ICommandResult Invoke()
        {
            // This is called when the user selects the main command
            // We'll return a result with a list of workspaces
            var items = GetWorkspacesItems();
            return CommandResult.ShowListPage(items, Resources.plugin_workspaces_name);
        }

        private ICommandItem[] GetWorkspacesItems()
        {
            // Refresh workspaces list
            _workspacesApi.LoadWorkspaces();
            
            var results = new List<CommandItem>();

            if (_workspacesApi.Workspaces.Count == 0)
            {
                // No workspaces found
                results.Add(new CommandItem(new NoOpCommand())
                {
                    Title = Resources.plugin_workspaces_error_no_workspaces,
                    Subtitle = string.Empty,
                });
                return results.ToArray();
            }

            // Add a command for each workspace
            foreach (var workspace in _workspacesApi.Workspaces)
            {
                var command = new CommandItem(new LaunchWorkspaceCommand(workspace))
                {
                    Title = workspace.Name,
                    Subtitle = Resources.plugin_workspaces_workspace,
                    Icon = new IconInfo("\uE71D"), // Using a default grid icon
                };
                results.Add(command);
            }

            return results.ToArray();
        }
    }

    internal sealed class LaunchWorkspaceCommand : InvokableCommand
    {
        private readonly Workspace _workspace;

        public LaunchWorkspaceCommand(Workspace workspace)
        {
            _workspace = workspace;
            Name = workspace.Name;
            Icon = new IconInfo("\uE71D"); // Using a default grid icon
        }

        public override ICommandResult Invoke()
        {
            bool success = WorkspacesLauncher.LaunchWorkspace(_workspace);
            if (!success)
            {
                return CommandResult.Error(Resources.plugin_workspaces_error_launching, $"{_workspace.Name}");
            }

            return CommandResult.Close();
        }
    }
}