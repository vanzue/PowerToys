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
    public class WorkspacesModuleTests : UITestBase
    {
        /// <summary>
        /// Test basic navigation to the Workspaces module in settings
        /// </summary>
        [TestMethod]
        public void TestNavigateToWorkspacesModule()
        {
            // Navigate to Workspaces page
            this.Find<NavigationViewItem>("Workspaces").Click();
            
            // Verify we're on the Workspaces page
            var pageTitle = this.Find("Workspaces");
            Assert.IsNotNull(pageTitle, "Workspaces settings page should be displayed");
            
            // Verify core UI elements
            var enableToggle = this.Find<ToggleSwitch>("Enable Workspaces");
            Assert.IsNotNull(enableToggle, "Enable toggle should be present");
        }
    }
}