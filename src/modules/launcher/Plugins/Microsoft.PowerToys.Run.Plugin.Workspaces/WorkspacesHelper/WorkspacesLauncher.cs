// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using Wox.Plugin.Logger;

namespace Microsoft.PowerToys.Run.Plugin.Workspaces.WorkspacesHelper
{
    public static class WorkspacesLauncher
    {
        public static bool LaunchWorkspace(Workspace workspace)
        {
            try
            {
                string launcherPath = GetWorkspacesLauncherPath();
                if (string.IsNullOrEmpty(launcherPath) || !File.Exists(launcherPath))
                {
                    Log.Error($"Workspaces launcher not found: {launcherPath}", typeof(WorkspacesLauncher));
                    return false;
                }

                // Command-line arguments: <workspaceId> <invokePoint>
                // The invokePoint is 2 (Taskbar) in this case to match desktop shortcut behavior
                var process = new ProcessStartInfo
                {
                    FileName = launcherPath,
                    Arguments = $"{workspace.Id} 2",
                    UseShellExecute = true,
                };

                Process.Start(process);
                return true;
            }
            catch (Win32Exception ex)
            {
                Log.Exception($"Failed to launch workspace: {workspace.Name}", ex, typeof(WorkspacesLauncher));
                return false;
            }
            catch (Exception ex)
            {
                Log.Exception($"Error launching workspace: {workspace.Name}", ex, typeof(WorkspacesLauncher));
                return false;
            }
        }

        private static string GetWorkspacesLauncherPath()
        {
            // Get the PowerToys installation folder
            string programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            string powerToysPath = Path.Combine(programFiles, "PowerToys");
            
            // The launcher executable path
            return Path.Combine(powerToysPath, "modules", "Workspaces", "PowerToys.Workspaces.Launcher.exe");
        }
    }
}