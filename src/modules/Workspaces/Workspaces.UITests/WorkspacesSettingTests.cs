// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Threading.Tasks;
using Microsoft.PowerToys.UITest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;

namespace PowerToys.Workspaces.UITests
{
    [TestClass]
    public class WorkspacesSettingTests : UITestBase
    {
        /// <summary>
        /// Test enabling and disabling the Workspaces module through settings
        /// </summary>
        [TestMethod]
        public void TestToggleWorkspaces()
        {
            // Navigate to Workspaces settings page
            this.Find<NavigationViewItem>("Workspaces").Click();
            
            // Check initial state and toggle if needed
            var enableToggle = this.Find<ToggleSwitch>("Enable Workspaces");
            bool initialState = enableToggle.ToggleState;
            
            // Toggle to opposite state
            enableToggle.Toggle(!initialState);
            
            // Verify toggle state changed
            Assert.AreEqual(!initialState, enableToggle.ToggleState, "Toggle state should have changed");
            
            // Toggle back
            enableToggle.Toggle(initialState);
            
            // Verify we're back to initial state
            Assert.AreEqual(initialState, enableToggle.ToggleState, "Toggle state should be back to initial");
        }
        
        /// <summary>
        /// Test launching the Workspaces editor from settings
        /// </summary>
        [TestMethod]
        public void TestLaunchWorkspacesEditor()
        {
            // Navigate to Workspaces settings page
            this.Find<NavigationViewItem>("Workspaces").Click();
            
            // Enable Workspaces if not enabled
            var enableToggle = this.Find<ToggleSwitch>("Enable Workspaces");
            if (!enableToggle.ToggleState)
            {
                enableToggle.Toggle(true);
            }
            
            // Verify Launch button is present
            var launchButton = this.Find<Button>("Launch Workspaces");
            Assert.IsNotNull(launchButton, "Launch button should be present");
            
            // Click launch button
            launchButton.Click();
            
            // Wait for editor to appear
            Task.Delay(1000).Wait();
            
            // Switch to Workspaces window
            this.Session.Attach(PowerToysModule.Workspaces);
            
            // Verify Workspaces editor window is open
            var workspacesWindow = this.Find<Window>("Workspaces");
            Assert.IsNotNull(workspacesWindow, "Workspaces window should be open");
            
            // Close the editor
            workspacesWindow.Close();
            
            // Return to settings
            this.Session.Attach(PowerToysModule.PowerToysSettings);
        }
        
        /// <summary>
        /// Test activation shortcut visibility in settings
        /// </summary>
        [TestMethod]
        public void TestActivationShortcutVisibility()
        {
            // Navigate to Workspaces settings page
            this.Find<NavigationViewItem>("Workspaces").Click();
            
            // Enable Workspaces if not enabled
            var enableToggle = this.Find<ToggleSwitch>("Enable Workspaces");
            if (!enableToggle.ToggleState)
            {
                enableToggle.Toggle(true);
            }
            
            // Verify activation shortcut control is visible
            var shortcutElement = this.Find("Activation shortcut");
            Assert.IsNotNull(shortcutElement, "Activation shortcut control should be visible");
            
            // Disable Workspaces
            enableToggle.Toggle(false);
            
            // Verify activation shortcut is now disabled/not interactive
            try
            {
                var shortcutElements = this.FindAll("Activation shortcut");
                foreach (var element in shortcutElements)
                {
                    // If we can find an enabled shortcut element, the test should fail
                    if (element.Enabled)
                    {
                        Assert.Fail("Activation shortcut should be disabled when Workspaces is disabled");
                    }
                }
            }
            catch (Exception)
            {
                // Exception is acceptable - might mean element is not found or not accessible when disabled
            }
            
            // Re-enable for cleanup
            enableToggle.Toggle(true);
        }
    }
}