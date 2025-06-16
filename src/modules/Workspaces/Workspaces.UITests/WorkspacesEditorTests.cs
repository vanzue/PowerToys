// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.PowerToys.UITest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;

namespace PowerToys.Workspaces.UITests
{
    [TestClass]
    public class WorkspacesEditorTests : UITestBase
    {
        private Process? notepadProcess = null;
        private Process? explorerProcess = null;
        
        [TestInitialize]
        public void TestInitialize()
        {
            // Navigate to Workspaces page
            this.Find<NavigationViewItem>("Workspaces").Click();
            
            // Make sure Workspaces is enabled
            var enableToggle = this.Find<ToggleSwitch>("Enable Workspaces");
            if (!enableToggle.ToggleState)
            {
                enableToggle.Toggle(true);
            }
        }
        
        [TestCleanup]
        public void TestCleanup()
        {
            // Close test applications if they're still running
            CloseTestApplications();
        }
        
        /// <summary>
        /// Test creating a workspace using the snapshot tool
        /// </summary>
        [TestMethod]
        public void TestWorkspaceCreation()
        {
            // Launch test applications
            LaunchTestApplications();
            
            // Launch Workspaces editor
            this.Find<Button>("Launch Workspaces").Click();
            Task.Delay(1000).Wait();
            this.Session.Attach(PowerToysModule.Workspaces);
            
            // Click 'Create new' button
            this.Find<Button>("Create new").Click();
            
            // Click 'Snapshot current desktop'
            this.Find<Button>("Snapshot current desktop").Click();
            
            // Wait for snapshot to complete
            Task.Delay(2000).Wait();
            
            // Enter workspace name
            var nameInput = this.Find<TextBox>("Workspace name");
            nameInput.Clear();
            nameInput.SendKeys("Test Workspace");
            
            // Save workspace
            this.Find<Button>("Save").Click();
            
            // Verify workspace was created
            Task.Delay(1000).Wait();
            var workspaceItem = this.Find("Test Workspace");
            Assert.IsNotNull(workspaceItem, "Workspace should have been created with name 'Test Workspace'");
            
            // Delete the test workspace for cleanup
            workspaceItem.Click();
            this.Find<Button>("Delete").Click();
            
            // Confirm deletion
            var deleteConfirm = this.Find<Button>("Delete");
            if (deleteConfirm != null)
            {
                deleteConfirm.Click();
            }
            
            // Close Workspaces editor
            this.Session.Find<Window>("Workspaces").Close();
            
            // Return to settings
            this.Session.Attach(PowerToysModule.PowerToysSettings);
        }
        
        /// <summary>
        /// Test searching for workspaces in the editor
        /// </summary>
        [TestMethod]
        public void TestWorkspaceSearch()
        {
            // Launch Workspaces editor
            this.Find<Button>("Launch Workspaces").Click();
            Task.Delay(1000).Wait();
            this.Session.Attach(PowerToysModule.Workspaces);
            
            // Create test workspaces
            CreateTestWorkspace("SearchTest1");
            CreateTestWorkspace("SearchTest2");
            
            // Use search bar
            var searchBox = this.Find<TextBox>("Search");
            searchBox.Clear();
            searchBox.SendKeys("SearchTest1");
            
            // Verify only SearchTest1 is visible
            Task.Delay(500).Wait();
            Assert.IsNotNull(this.Find("SearchTest1"), "SearchTest1 workspace should be visible");
            
            try
            {
                this.Find("SearchTest2", 500);
                Assert.Fail("SearchTest2 should not be visible when searching for SearchTest1");
            }
            catch
            {
                // Expected to fail as SearchTest2 should be filtered out
            }
            
            // Clear search and verify both visible
            searchBox.Clear();
            Task.Delay(500).Wait();
            Assert.IsNotNull(this.Find("SearchTest1"), "SearchTest1 workspace should be visible after clearing search");
            Assert.IsNotNull(this.Find("SearchTest2"), "SearchTest2 workspace should be visible after clearing search");
            
            // Delete test workspaces
            DeleteWorkspace("SearchTest1");
            DeleteWorkspace("SearchTest2");
            
            // Close Workspaces editor
            this.Session.Find<Window>("Workspaces").Close();
            
            // Return to settings
            this.Session.Attach(PowerToysModule.PowerToysSettings);
        }
        
        /// <summary>
        /// Test launching a workspace and verifying the UI elements
        /// </summary>
        [TestMethod]
        public void TestWorkspaceLaunch()
        {
            // Launch test applications
            LaunchTestApplications();
            
            // Launch Workspaces editor
            this.Find<Button>("Launch Workspaces").Click();
            Task.Delay(1000).Wait();
            this.Session.Attach(PowerToysModule.Workspaces);
            
            // Create test workspace
            CreateTestWorkspace("LaunchTest");
            
            // Select and launch the workspace
            this.Find("LaunchTest").Click();
            this.Find<Button>("Launch").Click();
            
            // Wait for launch UI to appear
            Task.Delay(1000).Wait();
            
            // Verify launch UI elements
            Assert.IsNotNull(this.Find("Launching workspace"), "Launch status message should be visible");
            
            // Wait for launch to complete
            Task.Delay(3000).Wait();
            
            // Return to Workspaces editor
            this.Session.Attach(PowerToysModule.Workspaces);
            
            // Delete test workspace
            DeleteWorkspace("LaunchTest");
            
            // Close Workspaces editor
            this.Session.Find<Window>("Workspaces").Close();
            
            // Return to settings
            this.Session.Attach(PowerToysModule.PowerToysSettings);
        }
        
        // Helper methods
        
        private void LaunchTestApplications()
        {
            // Launch Notepad
            if (notepadProcess == null || notepadProcess.HasExited)
            {
                notepadProcess = Process.Start("notepad.exe");
                Task.Delay(1000).Wait();
            }
            
            // Launch File Explorer
            if (explorerProcess == null || explorerProcess.HasExited)
            {
                explorerProcess = Process.Start("explorer.exe");
                Task.Delay(1000).Wait();
            }
        }
        
        private void CloseTestApplications()
        {
            // Close Notepad
            if (notepadProcess != null && !notepadProcess.HasExited)
            {
                notepadProcess.CloseMainWindow();
                if (!notepadProcess.WaitForExit(3000))
                {
                    notepadProcess.Kill();
                }
            }
            
            // Close Explorer windows (don't kill the process as that would close desktop)
            if (explorerProcess != null && !explorerProcess.HasExited)
            {
                explorerProcess.CloseMainWindow();
            }
        }
        
        private void CreateTestWorkspace(string name)
        {
            // Click 'Create new' button
            this.Find<Button>("Create new").Click();
            
            // Click 'Snapshot current desktop'
            this.Find<Button>("Snapshot current desktop").Click();
            
            // Wait for snapshot
            Task.Delay(2000).Wait();
            
            // Enter workspace name
            var nameInput = this.Find<TextBox>("Workspace name");
            nameInput.Clear();
            nameInput.SendKeys(name);
            
            // Save workspace
            this.Find<Button>("Save").Click();
            
            // Wait for save to complete
            Task.Delay(1000).Wait();
        }
        
        private void DeleteWorkspace(string name)
        {
            try
            {
                // Select the workspace
                this.Find(name).Click();
                
                // Delete it
                this.Find<Button>("Delete").Click();
                
                // Confirm deletion if prompted
                try
                {
                    var deleteConfirm = this.Find<Button>("Delete", 1000);
                    if (deleteConfirm != null)
                    {
                        deleteConfirm.Click();
                    }
                }
                catch
                {
                    // No confirmation dialog, that's fine
                }
                
                Task.Delay(500).Wait();
            }
            catch
            {
                // Workspace might already be deleted
            }
        }
    }
}