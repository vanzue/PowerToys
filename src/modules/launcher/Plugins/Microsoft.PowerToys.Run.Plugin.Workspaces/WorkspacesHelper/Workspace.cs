// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Text.Json.Serialization;

namespace Microsoft.PowerToys.Run.Plugin.Workspaces.WorkspacesHelper
{
    public class Workspace
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("creationTime")]
        public long CreationTime { get; set; }

        [JsonPropertyName("lastLaunchedTime")]
        public long? LastLaunchedTime { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}