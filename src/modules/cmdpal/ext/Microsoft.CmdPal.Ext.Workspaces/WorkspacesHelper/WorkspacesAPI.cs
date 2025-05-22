// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ManagedCommon;
using Microsoft.Win32;

namespace Microsoft.CmdPal.Ext.Workspaces.WorkspacesHelper
{
    public class WorkspacesAPI
    {
        private static WorkspacesAPI _instance;
        private readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        
        public List<Workspace> Workspaces { get; private set; } = new List<Workspace>();
        
        public static WorkspacesAPI Instance => _instance ??= new WorkspacesAPI();

        private WorkspacesAPI()
        {
            LoadWorkspaces();
        }

        public void LoadWorkspaces()
        {
            try
            {
                var workspacesFile = GetWorkspacesFilePath();
                if (!File.Exists(workspacesFile))
                {
                    Logger.LogError($"Workspaces file not found: {workspacesFile}");
                    return;
                }
                
                var json = File.ReadAllText(workspacesFile);

                // Try to deserialize as an array of workspaces first
                try
                {
                    var workspacesList = JsonSerializer.Deserialize<List<Workspace>>(json, _serializerOptions);
                    if (workspacesList != null)
                    {
                        Workspaces = workspacesList.Where(w => w != null).ToList();
                        return;
                    }
                }
                catch (JsonException)
                {
                    // Try alternative format
                }

                // Try to deserialize as a wrapper object with a workspaces property
                try
                {
                    var workspacesWrapper = JsonSerializer.Deserialize<WorkspacesWrapper>(json, _serializerOptions);
                    if (workspacesWrapper?.Workspaces != null)
                    {
                        Workspaces = workspacesWrapper.Workspaces.Where(w => w != null).ToList();
                        return;
                    }
                }
                catch (JsonException ex)
                {
                    Logger.LogError($"Error deserializing workspaces: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error loading workspaces: {ex.Message}");
                Workspaces = new List<Workspace>();
            }
        }

        private string GetWorkspacesFilePath()
        {
            try
            {
                // Try to find the PowerToys installation folder from registry
                using (var key = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\PowerToys"))
                {
                    if (key != null)
                    {
                        var installDir = key.GetValue("InstalledFolder") as string;
                        if (!string.IsNullOrEmpty(installDir))
                        {
                            // Settings should be in %LocalAppData%\Microsoft\PowerToys
                            string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                            string powerToysSettingsPath = Path.Combine(localAppData, "Microsoft", "PowerToys");
                            
                            // Workspaces settings path
                            return Path.Combine(powerToysSettingsPath, "Workspaces", "workspaces.json");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error determining PowerToys installation folder: {ex.Message}");
            }

            // Fallback to default location
            string defaultAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string defaultSettingsPath = Path.Combine(defaultAppData, "Microsoft", "PowerToys", "Workspaces", "workspaces.json");
            return defaultSettingsPath;
        }
    }
}