// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using ManagedCommon;
using Microsoft.Win32;

namespace Microsoft.CmdPal.Ext.Workspaces.WorkspacesHelper
{
    public static class WorkspacesLauncher
    {
        public static bool LaunchWorkspace(Workspace workspace)
        {
            try
            {
                string launcherPath = GetWorkspacesLauncherPath();
                if (string.IsNullOrEmpty(launcherPath))
                {
                    Logger.LogError("Could not find PowerToys Workspaces launcher");
                    return false;
                }

                if (!File.Exists(launcherPath))
                {
                    Logger.LogError($"Workspaces launcher not found: {launcherPath}");
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
                Logger.LogError($"Failed to launch workspace: {workspace.Name} - {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error launching workspace: {workspace.Name} - {ex.Message}");
                return false;
            }
        }

        private static string GetWorkspacesLauncherPath()
        {
            // Try to find the PowerToys installation folder from registry first
            try
            {
                using (var key = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\PowerToys"))
                {
                    if (key != null)
                    {
                        var installDir = key.GetValue("InstalledFolder") as string;
                        if (!string.IsNullOrEmpty(installDir))
                        {
                            var path = Path.Combine(installDir, "modules", "Workspaces", "PowerToys.Workspaces.Launcher.exe");
                            if (File.Exists(path))
                            {
                                return path;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error accessing registry for PowerToys path: {ex.Message}");
            }

            // Try common installation locations if registry fails
            string[] possiblePaths = new[]
            {
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "PowerToys", "modules", "Workspaces", "PowerToys.Workspaces.Launcher.exe"),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "PowerToys", "modules", "Workspaces", "PowerToys.Workspaces.Launcher.exe"),
            };

            foreach (var path in possiblePaths)
            {
                if (File.Exists(path))
                {
                    return path;
                }
            }

            // If everything else fails, return the default path and let the calling method handle the case where the file doesn't exist
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "PowerToys", "modules", "Workspaces", "PowerToys.Workspaces.Launcher.exe");
        }
    }
}