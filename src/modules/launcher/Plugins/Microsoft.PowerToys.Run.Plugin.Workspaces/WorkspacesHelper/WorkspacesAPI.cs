// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Wox.Plugin.Logger;

namespace Microsoft.PowerToys.Run.Plugin.Workspaces.WorkspacesHelper
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
                    Log.Error($"Workspaces file not found: {workspacesFile}", typeof(WorkspacesAPI));
                    return;
                }
                
                var json = File.ReadAllText(workspacesFile);
                var workspacesWrapper = JsonSerializer.Deserialize<WorkspacesWrapper>(json, _serializerOptions);
                
                if (workspacesWrapper?.Workspaces != null)
                {
                    Workspaces = workspacesWrapper.Workspaces.Where(w => w != null).ToList();
                }
            }
            catch (Exception ex)
            {
                Log.Exception("Error loading workspaces", ex, typeof(WorkspacesAPI));
                Workspaces = new List<Workspace>();
            }
        }

        private string GetWorkspacesFilePath()
        {
            // Get the PowerToys settings folder path
            string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string powerToysSettingsPath = Path.Combine(localAppData, "Microsoft", "PowerToys");
            
            // Workspaces are stored in the Workspaces subfolder
            return Path.Combine(powerToysSettingsPath, "Workspaces", "workspaces.json");
        }
    }
}