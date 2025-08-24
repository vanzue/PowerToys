# PowerToys TODO Report

Generated on: 2025-06-11 03:38:12 (Cleaned of self-referential TODO items - scripts and report references removed)
Repository root: /home/runner/work/PowerToys/PowerToys
Total TODO items found: 281

## Summary by Component
- **Module: cmdpal**: 118 TODOs
- **Core: settings-ui**: 38 TODOs
- **Module: launcher**: 15 TODOs
- **Module: MouseWithoutBorders**: 13 TODOs
- **Core: Monaco**: 12 TODOs
- **Module: imageresizer**: 12 TODOs
- **Module: peek**: 11 TODOs
- **Documentation**: 9 TODOs
- **Core: common**: 9 TODOs
- **Module: FileLocksmith**: 8 TODOs
- **Module: powerrename**: 5 TODOs
- **Module: MouseUtils**: 4 TODOs
- **Module: alwaysontop**: 4 TODOs
- **Module: PowerOCR**: 4 TODOs
- **Module: fancyzones**: 3 TODOs
- **Module: colorPicker**: 3 TODOs
- **Module: AdvancedPaste**: 3 TODOs
- **Module: ZoomIt**: 3 TODOs
- **Module: Workspaces**: 3 TODOs
- **Module: registrypreview**: 3 TODOs
- **Module: previewpane**: 3 TODOs
- **Module: keyboardmanager**: 2 TODOs
- **Core: runner**: 2 TODOs
- **Module: CropAndLock**: 2 TODOs

- **Module: ShortcutGuide**: 1 TODOs
- **Core: Update**: 1 TODOs
- **Module: MeasureTool**: 1 TODOs
- **Module: poweraccent**: 1 TODOs

## Summary by Category
- **General**: 165 TODOs
- **UI/UX**: 52 TODOs
- **Feature**: 38 TODOs
- **Logging/Debug**: 24 TODOs
- **Bug Fix**: 16 TODOs
- **Refactoring**: 7 TODOs
- **Performance**: 3 TODOs
- **Testing**: 3 TODOs
- **Security**: 1 TODOs

## Summary by Priority
- **High**: 0 TODOs
- **Medium**: 278 TODOs
- **Low**: 3 TODOs

## Detailed TODO List

### High Priority TODOs
*No high priority TODOs found.*

### TODOs by Component

#### Core: common (9 TODOs)

**Bug Fix** (1 items):

- `src/common/Common.UI/SettingsDeepLink.cs:114` [Medium] - // TODO(stefan): Log exception once unified logging is implemented

**Feature** (4 items):

- `src/common/UITestAutomation/Element/Window.cs:25` [Medium] - // TODO: Implement maximizing the window using an alternative method
- `src/common/UITestAutomation/Element/Window.cs:44` [Medium] - // TODO: Implement restoring the window using an alternative method
- `src/common/UITestAutomation/Element/Window.cs:63` [Medium] - // TODO: Implement minimizing the window using an alternative method
- `src/common/UITestAutomation/Element/Window.cs:81` [Medium] - // TODO: Implement closing the window using an alternative method

**General** (4 items):

- `src/common/Display/monitors.h:9` [Medium] - // TODO: merge with FZ::Rect
- `src/common/logger/logger.cpp:86` [Medium] - // todo: that message should be shown from init caller and strings should be localized
- `src/common/updating/updateState.h:14` [Medium] - readyToDownload = 2,
- `src/common/utils/registry.h:430` [Medium] - // TODO: verify that we actually need all of those


#### Core: Monaco (12 TODOs)

*Monaco TODOs excluded from detailed listing for brevity. Most are related to third-party library code.*


#### Core: runner (2 TODOs)

**General** (2 items):

- `src/runner/general_settings.cpp:16` [Medium] - // TODO: would be nice to get rid of these globals, since they're basically cached json settings
- `src/runner/UpdateUtils.cpp:194` [Medium] - state.state = UpdateState::readyToDownload;


#### Core: settings-ui (38 TODOs)

**Bug Fix** (1 items):

- `src/settings-ui/Settings.UI/ViewModels/MouseWithoutBordersViewModel.cs:553` [Medium] - /* TODO: Error handling */

**Feature** (2 items):

- `src/settings-ui/Settings.UI/SettingsXAML/OOBE/Views/OobeNewPlus.xaml:11` [Medium] - <!--  TODO: Create New+ overview .gif and update ref here  -->
- `src/settings-ui/Settings.UI/ViewModels/FileLocksmithViewModel.cs:99` [Medium] - // TODO: Implement when this module has properties.

**General** (33 items):

- `src/settings-ui/Settings.UI.Library/GeneralSettings.cs:71` [Medium] - public bool AutoDownloadUpdates { get; set; }
- `src/settings-ui/Settings.UI.Library/GeneralSettings.cs:87` [Medium] - AutoDownloadUpdates = false;
- `src/settings-ui/Settings.UI.Library/UpdatingSettings.cs:20` [Medium] - ReadyToDownload,
- `src/settings-ui/Settings.UI.UnitTests/Cmd/SetSettingCommandTests.cs:58` [Medium] - [DataRow(typeof(GeneralSettings), nameof(GeneralSettings.AutoDownloadUpdates), "true")]
- `src/settings-ui/Settings.UI.UnitTests/ViewModelTests/General.cs:64` [Medium] - Assert.AreEqual(originalGeneralSettings.AutoDownloadUpdates, viewModel.AutoDownloadUpdates);
- `src/settings-ui/Settings.UI/SettingsXAML/Controls/AlphaColorPickerButton.xaml:12` [Medium] - <!--TODO(stefan): ToDisplayName is no longer available in ColorHelper
- `src/settings-ui/Settings.UI/SettingsXAML/Controls/ColorPickerButton.xaml:12` [Medium] - <!--TODO(stefan): ToDisplayName is no longer available in ColorHelper
- `src/settings-ui/Settings.UI/SettingsXAML/OOBE/Views/OobeAdvancedPaste.xaml.cs:42` [Medium] - // TODO(stefan): Check how to remove additional space if item is set to Collapsed.
- `src/settings-ui/Settings.UI/SettingsXAML/Views/AwakePage.xaml.cs:71` [Medium] - /// TODO: The logic here needs to be optimized since doing string comparison on values is not ideal.
- `src/settings-ui/Settings.UI/SettingsXAML/Views/GeneralPage.xaml:75` [Medium] - IsEnabled="{x:Bind Mode=OneWay, Path=ViewModel.IsAutoDownloadUpdatesCardEnabled}"
- `src/settings-ui/Settings.UI/SettingsXAML/Views/GeneralPage.xaml:77` [Medium] - <controls:CheckBoxWithDescriptionControl x:Uid="GeneralPage_AutoDownloadAndInstallUpdates" IsChecked="{Binding Mode=TwoWay, Path=AutoDownloadUpdates}" />
- `src/settings-ui/Settings.UI/SettingsXAML/Views/GeneralPage.xaml:108` [Medium] - IsOpen="{x:Bind ViewModel.PowerToysUpdatingState, Mode=OneWay, Converter={StaticResource UpdateStateToBoolConverter}, ConverterParameter=ReadyToDownload}"
- `src/settings-ui/Settings.UI/SettingsXAML/Views/GeneralPage.xaml:109` [Medium] - IsTabStop="{x:Bind ViewModel.PowerToysUpdatingState, Mode=OneWay, Converter={StaticResource UpdateStateToBoolConverter}, ConverterParameter=ReadyToDownload}"
- `src/settings-ui/Settings.UI/SettingsXAML/Views/GeneralPage.xaml:172` [Medium] - x:Uid="General_FailedToDownloadTheNewVersion"
- `src/settings-ui/Settings.UI/SettingsXAML/Views/GeneralPage.xaml:181` [Medium] - x:Uid="General_TryAgainToDownloadAndInstall"
- `src/settings-ui/Settings.UI/SettingsXAML/Views/GeneralPage.xaml.cs:144` [Medium] - // TODO: go back PickSingleFolderAsync when it's fixed
- `src/settings-ui/Settings.UI/SettingsXAML/Views/MouseWithoutBordersPage.xaml:120` [Medium] - <!--  TODO: colors?  -->
- `src/settings-ui/Settings.UI/SettingsXAML/Views/PowerLauncherPage.xaml:624` [Medium] - <!-- todo(Stefan): InfoBadge not available
- `src/settings-ui/Settings.UI/SettingsXAML/Views/ZoomItPage.xaml.cs:77` [Medium] - // TODO: chooseFont.lpTemplateName = FORMATDLGORD31; and CHOOSE_FONT_FLAGS.CF_ENABLETEMPLATE
- `src/settings-ui/Settings.UI/ViewModels/DashboardViewModel.cs:67` [Medium] - UpdateAvailable = updatingSettingsConfig != null && (updatingSettingsConfig.State == UpdatingSettings.UpdatingState.ReadyToInstall || updatingSettingsConfig.State == UpdatingSettings.UpdatingState.ReadyToDownload);
- `src/settings-ui/Settings.UI/ViewModels/Flyout/LauncherViewModel.cs:60` [Medium] - if (updatingSettingsConfig.State == UpdatingSettings.UpdatingState.ReadyToInstall || updatingSettingsConfig.State == UpdatingSettings.UpdatingState.ReadyToDownload)
- `src/settings-ui/Settings.UI/ViewModels/GeneralViewModel.cs:151` [Medium] - _autoDownloadUpdates = GeneralSettingsConfig.AutoDownloadUpdates;
- `src/settings-ui/Settings.UI/ViewModels/GeneralViewModel.cs:170` [Medium] - _autoDownloadUpdatesIsGpoDisabled = GPOWrapper.GetDisableAutomaticUpdateDownloadValue() == GpoRuleConfigured.Enabled;
- `src/settings-ui/Settings.UI/ViewModels/GeneralViewModel.cs:243` [Medium] - private bool _autoDownloadUpdates;
- `src/settings-ui/Settings.UI/ViewModels/GeneralViewModel.cs:244` [Medium] - private bool _autoDownloadUpdatesIsGpoDisabled;
- `src/settings-ui/Settings.UI/ViewModels/GeneralViewModel.cs:487` [Medium] - (_isAdmin && _autoDownloadUpdatesIsGpoDisabled) ||
- `src/settings-ui/Settings.UI/ViewModels/GeneralViewModel.cs:515` [Medium] - public bool AutoDownloadUpdates
- `src/settings-ui/Settings.UI/ViewModels/GeneralViewModel.cs:519` [Medium] - return _autoDownloadUpdates && !_autoDownloadUpdatesIsGpoDisabled;
- `src/settings-ui/Settings.UI/ViewModels/GeneralViewModel.cs:524` [Medium] - if (_autoDownloadUpdates != value)
- `src/settings-ui/Settings.UI/ViewModels/GeneralViewModel.cs:526` [Medium] - _autoDownloadUpdates = value;
- `src/settings-ui/Settings.UI/ViewModels/GeneralViewModel.cs:527` [Medium] - GeneralSettingsConfig.AutoDownloadUpdates = value;
- `src/settings-ui/Settings.UI/ViewModels/GeneralViewModel.cs:533` [Medium] - public bool IsAutoDownloadUpdatesCardEnabled
- `src/settings-ui/Settings.UI/ViewModels/GeneralViewModel.cs:535` [Medium] - get => !_isDevBuild && !_autoDownloadUpdatesIsGpoDisabled;

**UI/UX** (2 items):

- `src/settings-ui/Settings.UI/SettingsXAML/Views/KeyboardManagerPage.xaml.cs:46` [Medium] - // Todo: Handle duplicate events either by somehow suppress them or re-read the configuration every time since we will be updating the UI only if something is changed.
- `src/settings-ui/Settings.UI/SettingsXAML/Views/MouseWithoutBordersPage.xaml.cs:55` [Medium] - // Todo: Handle duplicate events either by somehow suppress them or re-read the configuration every time since we will be updating the UI only if something is changed.


#### Core: Update (1 TODOs)

**General** (1 items):

- `src/Update/PowerToys.Update.cpp:68` [Medium] - if (state.state == UpdateState::readyToDownload || state.state == UpdateState::errorDownloading)


#### Documentation (9 TODOs)

**General** (9 items):

- `doc/devdocs/embedded-msix.md:5` [Medium] - - uncomment everything near "TODO: Use to activate embedded MSIX" comments
- `doc/devdocs/modules/powerrename.md:2` [Medium] - TODO
- `doc/devdocs/modules/powerrename.md:5` [Medium] - TODO
- `doc/devdocs/modules/powerrename.md:8` [Medium] - TODO
- `doc/devdocs/modules/powerrename.md:11` [Medium] - TODO
- `doc/devdocs/modules/powerrename.md:14` [Medium] - TODO
- `doc/devdocs/modules/powerrename.md:17` [Medium] - TODO
- `doc/devdocs/modules/powerrename.md:20` [Medium] - TODO
- `doc/devdocs/modules/powerrename.md:23` [Medium] - TODO

**Performance** (1 items):



#### Module: AdvancedPaste (3 TODOs)

**General** (3 items):

- `src/modules/AdvancedPaste/AdvancedPaste/AdvancedPasteXAML/Converters/CountToDoubleConverter.cs:12` [Medium] - public sealed partial class CountToDoubleConverter : IValueConverter
- `src/modules/AdvancedPaste/AdvancedPaste/AdvancedPasteXAML/Pages/MainPage.xaml:20` [Medium] - <converters:CountToDoubleConverter
- `src/modules/AdvancedPaste/AdvancedPaste/Helpers/ClipboardHelper.cs:61` [Medium] - // TODO(stefan): For some reason Flush() fails from time to time when directly activated via hotkey.


#### Module: alwaysontop (4 TODOs)

**General** (4 items):

- `src/modules/alwaysontop/AlwaysOnTop/AlwaysOnTop.cpp:60` [Medium] - // TODO: show localized message
- `src/modules/alwaysontop/AlwaysOnTop/Settings.cpp:27` [Medium] - // TODO: move to common utils
- `src/modules/alwaysontop/AlwaysOnTop/Settings.cpp:216` [Medium] - // TODO: show localized message
- `src/modules/alwaysontop/AlwaysOnTopModuleInterface/dllmain.cpp:174` [Medium] - app_name = L"AlwaysOnTop"; //TODO: localize


#### Module: cmdpal (118 TODOs)

**Bug Fix** (4 items):

- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.WinGet/Pages/WinGetExtensionPage.cs:245` [Medium] - // TODO more error handling like this:
- `src/modules/cmdpal/Microsoft.CmdPal.UI/Controls/IconBox.cs:66` [Medium] - // TODO: File platform bug?
- `src/modules/cmdpal/Microsoft.CmdPal.UI/Pages/ShellPage.xaml.cs:241` [Medium] - // TODO: It would be better to do this as a page exception, rather
- `src/modules/cmdpal/Microsoft.CmdPal.UI/Pages/ShellPage.xaml.cs:279` [Medium] - // TODO: It would be better to do this as a page exception, rather

**Feature** (19 items):

- `src/modules/cmdpal/doc/command-pal-anatomy/command-palette-anatomy.md:250` [Medium] - new ListItem(new NoOpCommand()) { Title = "TODO: Implement your extension here" }
- `src/modules/cmdpal/doc/command-pal-anatomy/command-palette-anatomy.md:269` [Medium] - new ListItem(new NoOpCommand()) { Title = "TODO: Implement your extension here" }
- `src/modules/cmdpal/doc/command-pal-anatomy/command-palette-anatomy.md:304` [Medium] - Now when you [invoke the default command](#default-command-this-is-probably-not-the-right-spot-for-this) to be executed for the `Search SSH Keys` command in the root view, you should see a new page displayed in the Command Palette with the message "TODO: Implement your extension here":
- `src/modules/cmdpal/doc/command-pal-anatomy/command-palette-anatomy.md:306` [Medium] - ![alt text](image-8.png "New ListPage with a single ListItem that says 'TODO: Implement your extension here'")
- `src/modules/cmdpal/doc/command-pal-anatomy/command-palette-anatomy.md:309` [Medium] - - TODO: Implement the logic that will parse the SSH config file to actually display the available SSH hosts on the machine in the Command Palette.
- `src/modules/cmdpal/doc/command-pal-anatomy/command-palette-anatomy.md:329` [Medium] - new ListItem(new NoOpCommand()) { Title = "TODO: Implement your extension here" },
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.Registry/Helpers/ResultHelper.cs:62` [Medium] - // TODO GH #126 Investigate tool tips, result.ToolTipData = new ToolTipData(Resources.RegistryKey, $"{Resources.KeyName} {result.Title}");
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.Registry/Helpers/ResultHelper.cs:109` [Medium] - // TODO --> Investigate ToolTipData = new ToolTipData(valueException.Message, valueException.ToString()),
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.Registry/Helpers/ResultHelper.cs:138` [Medium] - // TODO Investigate -->ToolTipData = new ToolTipData(Resources.RegistryValue, GetToolTipTextForRegistryValue(key, valueEntry)),
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.WindowsTerminal/TerminalPackage.cs:45` [Medium] - // Not using wox anymore, TODO: find the right new way to handle this
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.WindowWalker/Components/Window.cs:142` [Medium] - // TODO: Add verification as to whether the window handle is valid
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.WindowWalker/Components/WindowProcess.cs:148` [Medium] - // TODO: Add verification as to whether the process id and thread id is valid
- `src/modules/cmdpal/ExtensionTemplate/TemplateCmdPalExtension/TemplateCmdPalExtension/Pages/TemplateCmdPalExtensionPage.cs:22` [Medium] - new ListItem(new NoOpCommand()) { Title = "TODO: Implement your extension here" }
- `src/modules/cmdpal/Microsoft.CmdPal.UI.ViewModels/ShellViewModel.cs:99` [Medium] - // TODO GH #239 switch back when using the new MD text block
- `src/modules/cmdpal/Microsoft.CmdPal.UI.ViewModels/ShellViewModel.cs:108` [Medium] - // TODO GH #239 switch back when using the new MD text block
- `src/modules/cmdpal/Microsoft.CmdPal.UI/Controls/IconBox.cs:92` [Medium] - // TODO GH #239 switch back when using the new MD text block
- `src/modules/cmdpal/Microsoft.CmdPal.UI/Controls/SearchBar.xaml.cs:76` [Medium] - // TODO GH #239 switch back when using the new MD text block
- `src/modules/cmdpal/Microsoft.CmdPal.UI/Controls/SearchBar.xaml.cs:91` [Medium] - // TODO GH #239 switch back when using the new MD text block
- `src/modules/cmdpal/Microsoft.CmdPal.UI/Helpers/IconCacheService.cs:19` [Medium] - // todo: actually implement a cache of some sort

**General** (73 items):

- `src/modules/cmdpal/doc/command-pal-anatomy/command-palette-anatomy.md:63` [Medium] - String[] Bodies(); // TODO! should this be an IBody, so we can make it observable?
- `src/modules/cmdpal/doc/command-pal-anatomy/command-palette-anatomy.md:152` [Medium] - 2. Run the following PowerShell script, replacing "MastodonExtension" with the `Name` of your extension and "Mastodon extension for cmdpal" with the `DisplayName` of the [command that will show up in the root view](#root-view) of the Command Palette:
- `src/modules/cmdpal/doc/command-pal-anatomy/command-palette-anatomy.md:155` [Medium] - .\ext\NewExtension.ps1 -name MastodonExtension -DisplayName "Mastodon extension for cmdpal"
- `src/modules/cmdpal/doc/initial-sdk-spec/initial-sdk-spec.md:201` [Medium] - `HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\DevPal\Extensions` [TODO!api-review]: not this path. I think that's owned by the OS
- `src/modules/cmdpal/doc/initial-sdk-spec/initial-sdk-spec.md:1447` [Medium] - [TODO!api-review]: can we do some trickery in the `idl` to have this PropertyChanged be _literally the same as the XAML one_? So that if there's both in a dll, they get merge into one?
- `src/modules/cmdpal/doc/initial-sdk-spec/initial-sdk-spec.md:1903` [Medium] - [TODO!]: I'm marking these methods async right now, to force extension authors
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.Apps/Programs/UWPApplication.cs:583` [Medium] - // todo use windows theme as background
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.Bookmark/BookmarkPlaceholderForm.cs:27` [Medium] - // TODO pass in an array of placeholders
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.ClipboardHistory/Commands/PasteCommand.cs:29` [Medium] - // TODO GH #524: This isn't great - this requires us to have Secret Sauce in
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.ClipboardHistory/Helpers/ClipboardHelper.cs:79` [Medium] - // TODO(stefan): For some reason Flush() fails from time to time when directly activated via hotkey.
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.Registry/Commands/OpenKeyInEditorCommand.cs:43` [Medium] - // TODO GH #118 We need a convenient way to show errors to a user
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.Shell/Commands/ExecuteItem.cs:93` [Medium] - // GH TODO #138 -- show this message once that's wired up
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.Shell/Commands/ExecuteItem.cs:102` [Medium] - // GH TODO #138 -- show this message once that's wired up
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.Shell/Helpers/SettingsManager.cs:33` [Medium] - false); // TODO -- double check default value
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.System/Helpers/SettingsManager.cs:20` [Medium] - false); // TODO -- double check default value
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.System/Helpers/SettingsManager.cs:26` [Medium] - false); // TODO -- double check default value
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.TimeDate/Helpers/SettingsManager.cs:88` [Medium] - false); // TODO -- double check default value
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.TimeDate/Helpers/SettingsManager.cs:94` [Medium] - false); // TODO -- double check default value
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.WebSearch/Commands/OpenURLCommand.cs:31` [Medium] - // TODO GH# 138 --> actually display feedback from the extension somewhere.
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.WebSearch/Commands/SearchWebCommand.cs:33` [Medium] - // TODO GH# 138 --> actually display feedback from the extension somewhere.
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.WindowsServices/Helpers/ServiceHelper.cs:96` [Medium] - // TODO GH #78 we need to improve the icon story
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.WindowsServices/Helpers/ServiceHelper.cs:97` [Medium] - // TODO GH #126 investigate tooltip story
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.WindowsServices/Helpers/ServiceHelper.cs:106` [Medium] - // TODO GH #118 IPublicAPI contextAPI isn't used anymore, but we need equivalent ways to show notifications and status
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.WindowsServices/Helpers/ServiceHelper.cs:143` [Medium] - // TODO GH #118 feedback to users
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.WindowsSettings/Helpers/ResultHelper.cs:40` [Medium] - // TODO GH #126 investigate tooltips
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.WindowsSettings/Helpers/ResultHelper.cs:57` [Medium] - // TODO GH #127 --> Investigate scoring
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.WindowWalker/Commands/KillProcessCommand.cs:41` [Medium] - // TODO GH #86 -- need to figure out how to show status message once implemented on host
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.WindowWalker/Commands/KillProcessCommand.cs:48` [Medium] - // TODO GH #138, #153 -- need to figure out how to confirm kill process? should this just be the same status thing... maybe not? Need message box? Could be nested context menu.
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.WinGet/Pages/InstallPackageCommand.cs:88` [Medium] - // TODO: LOCK in here, so this can only be invoked once until the
- `src/modules/cmdpal/extensionsdk/Microsoft.CommandPalette.Extensions.Toolkit/BaseObservable.cs:9` [Medium] - // TODO! We probably want to have OnPropertyChanged raise the event
- `src/modules/cmdpal/extensionsdk/Microsoft.CommandPalette.Extensions.Toolkit/BaseObservable.cs:21` [Medium] - // TODO #181 - This is dangerous! If the original host goes away,
- `src/modules/cmdpal/extensionsdk/Microsoft.CommandPalette.Extensions.Toolkit/CommandProvider.cs:43` [Medium] - // TODO #181 - This is the same thing that BaseObservable has to deal with.
- `src/modules/cmdpal/extensionsdk/Microsoft.CommandPalette.Extensions.Toolkit/ContentPage.cs:31` [Medium] - // TODO #181 - This is the same thing that BaseObservable has to deal with.
- `src/modules/cmdpal/extensionsdk/Microsoft.CommandPalette.Extensions.Toolkit/ExtensionServer.cs:59` [Medium] - // TODO : We need to handle lifetime management of the server.
- `src/modules/cmdpal/extensionsdk/Microsoft.CommandPalette.Extensions.Toolkit/ListPage.cs:101` [Medium] - // TODO #181 - This is the same thing that BaseObservable has to deal with.
- `src/modules/cmdpal/extensionsdk/Microsoft.CommandPalette.Extensions.Toolkit/TreeContent.cs:31` [Medium] - // TODO #181 - This is the same thing that BaseObservable has to deal with.
- `src/modules/cmdpal/Microsoft.CmdPal.Common/Helpers/RuntimeHelper.cs:18` [Medium] - // TODO: for whatever reason, when I ported this into the PT
- `src/modules/cmdpal/Microsoft.CmdPal.UI.ViewModels/AppStateModel.cs:95` [Medium] - // TODO: Instead of just raising the event here, we should
- `src/modules/cmdpal/Microsoft.CmdPal.UI.ViewModels/CommandItemViewModel.cs:141` [Medium] - // TODO: Do these need to go into FastInit?
- `src/modules/cmdpal/Microsoft.CmdPal.UI.ViewModels/CommandItemViewModel.cs:201` [Medium] - // TODO this probably should just be a CommandContextItemViewModel(CommandItemViewModel) ctor, or a copy ctor or whatever
- `src/modules/cmdpal/Microsoft.CmdPal.UI.ViewModels/Commands/MainListPage.cs:18` [Medium] - /// TODO: Need to think about how we structure/interop for the page -> section -> item between the main setup, the extensions, and our viewmodels.
- `src/modules/cmdpal/Microsoft.CmdPal.UI.ViewModels/ContentPageViewModel.cs:55` [Medium] - // TODO: Does this need to hop to a _different_ thread, so that we don't block the extension while we're fetching?
- `src/modules/cmdpal/Microsoft.CmdPal.UI.ViewModels/ContentTreeViewModel.cs:51` [Medium] - // TODO: Does this need to hop to a _different_ thread, so that we don't block the extension while we're fetching?
- `src/modules/cmdpal/Microsoft.CmdPal.UI.ViewModels/ListItemViewModel.cs:98` [Medium] - // TODO: Do we want filters to match descriptions and other properties? Tags, etc... Yes?
- `src/modules/cmdpal/Microsoft.CmdPal.UI.ViewModels/ListItemViewModel.cs:99` [Medium] - // TODO: Do we want to save off the score here so we can sort by it in our ListViewModel?
- `src/modules/cmdpal/Microsoft.CmdPal.UI.ViewModels/ListViewModel.cs:21` [Medium] - // TODO: Do we want a base "ItemsPageViewModel" for anything that's going to have items?
- `src/modules/cmdpal/Microsoft.CmdPal.UI.ViewModels/ListViewModel.cs:82` [Medium] - // TODO: Does this need to hop to a _different_ thread, so that we don't block the extension while we're fetching?
- `src/modules/cmdpal/Microsoft.CmdPal.UI.ViewModels/ListViewModel.cs:173` [Medium] - // TODO: Iterate over everything in Items, and prune items from the
- `src/modules/cmdpal/Microsoft.CmdPal.UI.ViewModels/ListViewModel.cs:178` [Medium] - // TODO: Move this within the for loop, so we can catch issues with individual items
- `src/modules/cmdpal/Microsoft.CmdPal.UI.ViewModels/ListViewModel.cs:244` [Medium] - // TODO: GH #502
- `src/modules/cmdpal/Microsoft.CmdPal.UI.ViewModels/PageViewModel.cs:104` [Medium] - // TODO: We may want a SemaphoreSlim lock here.
- `src/modules/cmdpal/Microsoft.CmdPal.UI.ViewModels/PageViewModel.cs:124` [Medium] - // TODO: Do we want an event/signal here that the Page Views can listen to? (i.e. ListPage setting the selected index to 0, however, in async world the user may have already started navigating around page...)
- `src/modules/cmdpal/Microsoft.CmdPal.UI.ViewModels/SettingsModel.cs:139` [Medium] - // TODO: Instead of just raising the event here, we should
- `src/modules/cmdpal/Microsoft.CmdPal.UI.ViewModels/ShellViewModel.cs:58` [Medium] - // TODO: Handle failure case
- `src/modules/cmdpal/Microsoft.CmdPal.UI.ViewModels/ShellViewModel.cs:93` [Medium] - // TODO: Handle failure case
- `src/modules/cmdpal/Microsoft.CmdPal.UI.ViewModels/TopLevelCommandManager.cs:202` [Low] - // TODO In the future, we'll probably abstract some of this away, to have
- `src/modules/cmdpal/Microsoft.CmdPal.UI/App.xaml.cs:91` [Medium] - // TODO: It's in the Labs feed, but we can use Sergio's AOT-friendly source generator for this: https://github.com/CommunityToolkit/Labs-Windows/discussions/463
- `src/modules/cmdpal/Microsoft.CmdPal.UI/Controls/ContentFormControl.xaml.cs:52` [Low] - // TODO in the future, we should handle ActualThemeChanged and replace
- `src/modules/cmdpal/Microsoft.CmdPal.UI/Controls/SearchBar.xaml.cs:46` [Medium] - //// TODO: If the Debounce timer hasn't fired, we may want to store the current Filter in the OldValue/prior VM, but we don't want that to go actually do work...
- `src/modules/cmdpal/Microsoft.CmdPal.UI/Controls/SearchBar.xaml.cs:58` [Medium] - // TODO: In some cases we probably want commands to clear a filter
- `src/modules/cmdpal/Microsoft.CmdPal.UI/Controls/SearchBar.xaml.cs:148` [Medium] - // hack TODO GH #245
- `src/modules/cmdpal/Microsoft.CmdPal.UI/Controls/SearchBar.xaml.cs:159` [Medium] - // hack TODO GH #245
- `src/modules/cmdpal/Microsoft.CmdPal.UI/Controls/SearchBar.xaml.cs:228` [Medium] - // TERRIBLE HACK TODO GH #245
- `src/modules/cmdpal/Microsoft.CmdPal.UI/Controls/SearchBar.xaml.cs:243` [Medium] - // TODO: We could encapsulate this in a Behavior if we wanted to bind to the Filter property.
- `src/modules/cmdpal/Microsoft.CmdPal.UI/ExtViews/ListPage.xaml:18` [Medium] - <!--  TODO: Figure out what we want to do here for filtering/grouping and where  -->
- `src/modules/cmdpal/Microsoft.CmdPal.UI/Pages/LoadingPage.xaml.cs:39` [Medium] - // TODO: Handle failure case
- `src/modules/cmdpal/Microsoft.CmdPal.UI/Pages/ShellPage.xaml.cs:126` [Medium] - // TODO: Actually loading up the page, or invoking the command -
- `src/modules/cmdpal/Microsoft.CmdPal.UI/Pages/ShellPage.xaml.cs:182` [Medium] - // TODO GH #526 This needs more better locking too
- `src/modules/cmdpal/Microsoft.CmdPal.UI/Pages/ShellPage.xaml.cs:224` [Medium] - // todo BODGY
- `src/modules/cmdpal/Microsoft.CmdPal.UI/Pages/ShellPage.xaml.cs:249` [Medium] - // TODO GH #525 This needs more better locking.
- `src/modules/cmdpal/Microsoft.CmdPal.UI/Pages/ShellPage.xaml.cs:313` [Medium] - // TODO: Maybe we need to style the primary button to be red?
- `src/modules/cmdpal/Microsoft.CmdPal.UI/Pages/ShellPage.xaml.cs:437` [Medium] - // TERRIBLE HACK TODO GH #245
- `src/modules/cmdpal/Microsoft.CmdPal.UI/Pages/ShellPage.xaml.cs:576` [Low] - // TODO: In the future we probably want a short cache (3-5?) of recent VMs in case the user re-navigates

**Logging/Debug** (16 items):

- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.ClipboardHistory/Pages/ClipboardHistoryListPage.cs:114` [Medium] - // TODO GH #108 We need to figure out some logging
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.WindowsServices/Helpers/ServiceHelper.cs:148` [Medium] - // TODO GH #108 We need to figure out some logging
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.WindowsServices/Helpers/ServiceHelper.cs:156` [Medium] - // TODO GH #108 We need to figure out some logging
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.WindowsServices/Helpers/ServiceHelper.cs:178` [Medium] - // TODO GH #108 We need to figure out some logging
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.WindowsSettings/Commands/OpenSettingsCommand.cs:73` [Medium] - // TODO GH #108 Logging is something we have to take care of
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.WindowsSettings/Helpers/JsonSettingsListHelper.cs:62` [Medium] - // TODO GH #108 Logging is something we have to take care of
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.WindowsSettings/Helpers/UnsupportedSettingsHelper.cs:42` [Medium] - // TODO GH #108 Logging is something we have to take care of
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.WindowsSettings/Helpers/WindowsSettingsPathHelper.cs:36` [Medium] - // TODO GH #108 Logging is something we have to take care of
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.WindowsSettings/Helpers/WindowsSettingsPathHelper.cs:51` [Medium] - // TODO GH #108 Logging is something we have to take care of
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.WindowsTerminal/Commands/LaunchProfileAsAdminCommand.cs:54` [Medium] - // TODO GH #108 We need to figure out some logging
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.WindowsTerminal/Commands/LaunchProfileAsAdminCommand.cs:93` [Medium] - // TODO GH #108 We need to figure out some logging
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.WindowsTerminal/Commands/LaunchProfileAsAdminCommand.cs:118` [Medium] - // TODO GH #108 We need to figure out some logging
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.WindowsTerminal/Commands/LaunchProfileCommand.cs:62` [Medium] - // TODO GH #108 We need to figure out some logging
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.WindowsTerminal/Commands/LaunchProfileCommand.cs:87` [Medium] - // TODO GH #108 We need to figure out some logging
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.WindowsTerminal/Helpers/TerminalQuery.cs:42` [Medium] - // TODO: what kind of logging should we do?
- `src/modules/cmdpal/ext/Microsoft.CmdPal.Ext.WindowsTerminal/Helpers/TerminalQuery.cs:51` [Medium] - // TODO: what kind of logging should we do?

**Performance** (1 items):

- `src/modules/cmdpal/Microsoft.CmdPal.UI.ViewModels/ListViewModel.cs:140` [Medium] - // TODO we can probably further optimize this by also keeping a

**Testing** (1 items):

- `src/modules/cmdpal/Microsoft.CmdPal.UI.ViewModels/ListViewModel.cs:87` [Medium] - //// TODO: Just temp testing, need to think about where we want to filter, as ACVS in View could be done, but then grouping need CVS, maybe we do grouping in view

**UI/UX** (4 items):

- `src/modules/cmdpal/doc/initial-sdk-spec/initial-sdk-spec.md:1874` [Medium] - // TODO! Icon maybe? Work with design on this
- `src/modules/cmdpal/Microsoft.CmdPal.UI.ViewModels/PageViewModel.cs:106` [Medium] - // TODO: We may want to investigate using some sort of AsyncEnumerable or populating these as they come into the UI layer
- `src/modules/cmdpal/Microsoft.Terminal.UI/Converters.cpp:69` [Medium] - // double Converters::FontWeightToDouble(const winrt::Windows::UI::Text::FontWeight fontWeight)
- `src/modules/cmdpal/Microsoft.Terminal.UI/Converters.h:30` [Medium] - // static double FontWeightToDouble(winrt::Windows::UI::Text::FontWeight fontWeight);


#### Module: colorPicker (3 TODOs)

**General** (3 items):

- `src/modules/colorPicker/ColorPickerUI/Helpers/ColorHelper.cs:19` [Medium] - internal static (double Red, double Green, double Blue) ConvertToDouble(Color color)
- `src/modules/colorPicker/ColorPickerUI/Helpers/ColorRepresentationHelper.cs:109` [Medium] - var (red, green, blue) = ColorHelper.ConvertToDouble(color);
- `src/modules/colorPicker/ColorPickerUI/Settings/UserSettings.cs:91` [Medium] - // TODO this IO call should by Async, update GetFileWatcher helper to support async


#### Module: CropAndLock (2 TODOs)

**Bug Fix** (1 items):

- `src/modules/CropAndLock/CropAndLock/main.cpp:136` [Medium] - // TODO: Fix WindowInfo.h to not contain the null char at the end.

**General** (1 items):

- `src/modules/CropAndLock/CropAndLockModuleInterface/dllmain.cpp:321` [Medium] - // TODO: actual default hotkey setting in line with other PowerToys.


#### Module: fancyzones (3 TODOs)

**General** (3 items):

- `src/modules/fancyzones/editor/FancyZonesEditor/Models/GridLayoutModel.cs:77` [Medium] - //  TODO: ideally no setter here - this means moving logic like "split" over to model
- `src/modules/fancyzones/editor/FancyZonesEditor/Models/LayoutModel.cs:111` [Medium] - // TODO: once we switch to a picker per monitor, we need to move this state to the view
- `src/modules/fancyzones/FancyZonesEditorCommon/Data/LayoutDefaultSettings.cs:9` [Medium] - // TODO: share the constants b/w C# Editor and FancyZoneLib


#### Module: FileLocksmith (8 TODOs)

**Bug Fix** (1 items):

- `src/modules/FileLocksmith/FileLocksmithUI/ViewModels/MainViewModel.cs:180` [Medium] - // TODO report error?

**General** (5 items):

- `src/modules/FileLocksmith/FileLocksmithLib/FileLocksmithLib.cpp:7` [Medium] - // TODO: This is an example of a library function
- `src/modules/FileLocksmith/FileLocksmithLibInterop/FileLocksmith.cpp:22` [Medium] - // TODO use a trie!
- `src/modules/FileLocksmith/FileLocksmithLibInterop/NativeMethods.cpp:188` [Medium] - // TODO: Make elevation.h lighter so that this function can be used without bringing dependencies like spdlog in.
- `src/modules/FileLocksmith/FileLocksmithLibInterop/NtdllExtensions.cpp:212` [Medium] - // TODO uncomment and investigate
- `src/modules/FileLocksmith/FileLocksmithUI/ViewModels/MainViewModel.cs:175` [Medium] - // TODO gentler exit

**UI/UX** (2 items):

- `src/modules/FileLocksmith/FileLocksmithContextMenu/dllmain.cpp:144` [Medium] - // TODO Aggregate items and send to UI
- `src/modules/FileLocksmith/FileLocksmithExt/ExplorerCommand.cpp:217` [Medium] - // TODO Aggregate items and send to UI


#### Module: imageresizer (12 TODOs)

**Bug Fix** (1 items):

- `src/modules/imageresizer/ui/App.xaml.cs:57` [Medium] - // TODO: Add command-line parameters that can be used in lieu of the input page (issue #14)

**Feature** (2 items):

- `src/modules/imageresizer/ui/App.xaml.cs:48` [Medium] - /* TODO: Add logs to ImageResizer.
- `src/modules/imageresizer/ui/Views/SizeTypeToHelpTextConverter.cs:20` [Medium] - private readonly AutoDoubleConverter _autoDoubleConverter = new();

**General** (9 items):

- `src/modules/imageresizer/dll/ContextMenuHandler.cpp:100` [Medium] - // TODO: Instead, detect whether there's a WIC codec installed that can handle this file
- `src/modules/imageresizer/dll/ContextMenuHandler.cpp:420` [Medium] - // TODO: Instead, detect whether there's a WIC codec installed that can handle this file
- `src/modules/imageresizer/ImageResizerContextMenu/dllmain.cpp:123` [Medium] - // TODO: Instead, detect whether there's a WIC codec installed that can handle this file
- `src/modules/imageresizer/ui/App.xaml:19` [Medium] - <v:AutoDoubleConverter x:Key="AutoDoubleConverter" />
- `src/modules/imageresizer/ui/Models/ResizeBatch.cs:93` [Medium] - // TODO: If we ever switch to Windows.Graphics.Imaging, we can get a lot more throughput by using the async
- `src/modules/imageresizer/ui/Views/AutoDoubleConverter.cs:21` [Medium] - internal class AutoDoubleConverter : IValueConverter
- `src/modules/imageresizer/ui/Views/InputPage.xaml:49` [Medium] - Text="{Binding Width, Converter={StaticResource AutoDoubleConverter}, ConverterParameter=Auto}" />
- `src/modules/imageresizer/ui/Views/InputPage.xaml:58` [Medium] - Text="{Binding Height, Converter={StaticResource AutoDoubleConverter}, ConverterParameter=Auto}"
- `src/modules/imageresizer/ui/Views/SizeTypeToHelpTextConverter.cs:33` [Medium] - _autoDoubleConverter.Convert(value, typeof(string), null, culture) as string;


#### Module: keyboardmanager (2 TODOs)

**General** (1 items):

- `src/modules/keyboardmanager/KeyboardManagerEditorLibrary/ShortcutControl.cpp:29` [Medium] - // TODO: Check if there is a VariableSizedWrapGrid equivalent.

**UI/UX** (1 items):

- `src/modules/keyboardmanager/KeyboardManagerEditorLibrary/SingleKeyRemapControl.cpp:132` [Medium] - void SingleKeyRemapControl::TextToMapChangedHandler(winrt::Windows::Foundation::IInspectable const& sender, winrt::Windows::UI::Xaml::Controls::TextChangedEventArgs const& e) // TODO: remove


#### Module: launcher (15 TODOs)

**Feature** (3 items):

- `src/modules/launcher/Plugins/Microsoft.Plugin.WindowWalker/Components/Window.cs:207` [Medium] - // TODO: Add verification as to whether the window handle is valid
- `src/modules/launcher/Plugins/Microsoft.Plugin.WindowWalker/Components/WindowProcess.cs:152` [Medium] - // TODO: Add verification as to whether the process id and thread id is valid
- `src/modules/launcher/PowerLauncher/ViewModel/MainViewModel.cs:935` [Medium] - /* TODO: Custom Hotkeys for Plugins. Commented since this is an incomplete feature.

**General** (10 items):

- `src/modules/launcher/Plugins/Microsoft.Plugin.Folder/Main.cs:103` [Medium] - // todo why was this hack here?
- `src/modules/launcher/Plugins/Microsoft.Plugin.Indexer/Main.cs:208` [Medium] - // Todo : Update with theme based IconPath
- `src/modules/launcher/Plugins/Microsoft.Plugin.Program/Programs/UWPApplication.cs:708` [Medium] - // todo use windows theme as background
- `src/modules/launcher/Plugins/Microsoft.Plugin.Shell/Main.cs:414` [Medium] - // Todo : Update with theme based IconPath
- `src/modules/launcher/Plugins/Microsoft.Plugin.Uri.UnitTests/UriHelper/ExtendedUriParserTests.cs:57` [Medium] - // ToDo: Block [::] address results in parser. This Address is unspecified per RFC 4291 and the results make no sense.
- `src/modules/launcher/Plugins/Microsoft.Plugin.WindowWalker/Main.cs:70` [Medium] - // Todo : Update with theme based IconPath
- `src/modules/launcher/PowerLauncher/Plugin/PluginConfig.cs:43` [Medium] - // todo use linq when disable plugin is implemented since parallel.foreach + list is not thread saft
- `src/modules/launcher/PowerLauncher/ViewModel/MainViewModel.cs:149` [Medium] - // TODO: Custom plugin hotkeys.
- `src/modules/launcher/Wox.Infrastructure/Image/ImageLoader.cs:110` [Medium] - // Todo : Update it with icons specific to each theme.
- `src/modules/launcher/Wox.Infrastructure/Storage/JsonStorage`1.cs:125` [Medium] - // todo give user notification for the backup process

**Logging/Debug** (1 items):

- `src/modules/launcher/Wox.Infrastructure/Exception/ExceptionFormatter.cs:25` [Medium] - // todo log /display line by line

**UI/UX** (1 items):

- `src/modules/launcher/Wox.Infrastructure/Storage/ISavable.cs:9` [Medium] - /// todo should be merged into a abstract class instead of separate interface


#### Module: MeasureTool (1 TODOs)

**Refactoring** (1 items):

- `src/modules/MeasureTool/MeasureToolCore/ToolState.h:64` [Medium] - // TODO: refactor so we don't need unordered_map


#### Module: MouseUtils (4 TODOs)

**General** (1 items):

- `src/modules/MouseUtils/MouseHighlighter/MouseHighlighter.cpp:164` [Medium] - // TODO: We're leaking shapes for long drawing sessions.

**Logging/Debug** (1 items):

- `src/modules/MouseUtils/MouseJumpUI/Program.cs:39` [Medium] - // TODO : Log message

**Refactoring** (2 items):

- `src/modules/MouseUtils/MouseHighlighter/dllmain.cpp:178` [Medium] - // TODO: refactor to use common/utils/json.h instead
- `src/modules/MouseUtils/MousePointerCrosshairs/dllmain.cpp:188` [Medium] - // TODO: refactor to use common/utils/json.h instead


#### Module: MouseWithoutBorders (13 TODOs)

**Feature** (2 items):

- `src/modules/MouseWithoutBorders/App/Helper/Program.cs:37` [Medium] - // TODO: Add logging.
- `src/modules/MouseWithoutBorders/App/Service/Program.cs:34` [Medium] - // TODO: Add logging.

**General** (5 items):

- `src/modules/MouseWithoutBorders/App/Class/Common.cs:264` [Medium] - // TODO: For telemetry only, to be removed.
- `src/modules/MouseWithoutBorders/App/Class/Common.cs:1243` [Medium] - Sk = null; // TODO: This looks redundant.
- `src/modules/MouseWithoutBorders/App/Class/Common.InitAndCleanup.cs:146` [Medium] - /* TODO: Telemetry for the matrix? */
- `src/modules/MouseWithoutBorders/App/Class/IClipboardHelper.cs:140` [Medium] - /* TODO: Telemetry for screen capture. */
- `src/modules/MouseWithoutBorders/App/Class/Setting.cs:481` [Medium] - return int.MaxValue; // TODO(@yuyoyuppe): do we still need expiration mechanics now?

**Logging/Debug** (4 items):

- `src/modules/MouseWithoutBorders/App/Class/TcpServer.cs:159` [Medium] - /* TODO: There was some telemetry here. Log instead? */
- `src/modules/MouseWithoutBorders/App/Class/TcpServer.cs:162` [Medium] - /* TODO: There was some telemetry here. Log instead? */
- `src/modules/MouseWithoutBorders/App/Class/TcpServer.cs:167` [Medium] - /* TODO: There was some telemetry here. Log instead? */
- `src/modules/MouseWithoutBorders/App/Class/TcpServer.cs:172` [Medium] - /* TODO: There was some telemetry here. Log instead? */

**Testing** (1 items):

- `src/modules/MouseWithoutBorders/App/Helper/FormHelper.cs:776` [Medium] - // TODO: Test in Win8/7/XP.

**UI/UX** (1 items):

- `src/modules/MouseWithoutBorders/App/Class/MachinePool.cs:129` [Medium] - // TODO: would probably be cleaner interface as IEnumerable


#### Module: peek (11 TODOs)

**Bug Fix** (2 items):

- `src/modules/peek/Peek.FilePreviewer/FilePreview.xaml.cs:247` [Medium] - // TODO: Log task cancelled exception?
- `src/modules/peek/peek/dllmain.cpp:456` [Medium] - // TODO: fix VK_SPACE DestroyWindow in viewer app

**Feature** (1 items):

- `src/modules/peek/Peek.FilePreviewer/Previewers/WebBrowserPreviewer/Helpers/MonacoHelper.cs:53` [Medium] - // TODO: check if file is too big, add MaxFileSize to settings

**General** (6 items):

- `src/modules/peek/Peek.FilePreviewer/Controls/BrowserControl.xaml.cs:323` [Medium] - // TODO: && args.IsUserInitiated - always false for PDF files, revert the workaround when fixed in WebView2: https://github.com/microsoft/PowerToys/issues/27403
- `src/modules/peek/Peek.FilePreviewer/Previewers/MediaPreviewer/Helpers/WICHelper.cs:18` [Medium] - // TODO: Find a way to get file metadata without hydrating files. Look into Shell API/Windows Property System, e.g., IPropertyStore
- `src/modules/peek/Peek.FilePreviewer/Previewers/MediaPreviewer/Helpers/WICHelper.cs:25` [Medium] - // TODO: Respect EXIF data and find correct orientation
- `src/modules/peek/Peek.FilePreviewer/Previewers/ShellPreviewHandlerPreviewer/ShellPreviewHandlerPreviewer.cs:93` [Medium] - // TODO: Figure out how to get it to run in a low integrity level
- `src/modules/peek/Peek.FilePreviewer/Previewers/ShellPreviewHandlerPreviewer/ShellPreviewHandlerPreviewer.cs:100` [Medium] - // TODO: Maybe free them after some inactivity or when Peek quits?
- `src/modules/peek/Peek.UI/PeekXAML/MainWindow.xaml.cs:226` [Medium] - // TODO: Investigate why portrait images do not perfectly fit edge-to-edge --> WindowHeightContentPadding can be 0 (or close to that) if custom? [Jay]

**Refactoring** (2 items):

- `src/modules/peek/Peek.UI/Extensions/HWNDExtensions.cs:29` [Medium] - // TODO: Refactor into same C++ class consumed by both.
- `src/modules/peek/peek/dllmain.cpp:161` [Medium] - // TODO: Refactor into same C++ class consumed by both.


#### Module: poweraccent (1 TODOs)

**General** (1 items):

- `src/modules/poweraccent/PowerAccent.Core/Services/SettingsService.cs:35` [Medium] - // TODO this IO call should by Async, update GetFileWatcher helper to support async


#### Module: PowerOCR (4 TODOs)

**General** (4 items):

- `src/modules/PowerOCR/PowerOCR/Helpers/WindowUtilities.cs:68` [Medium] - // TODO: Decide when to close the process
- `src/modules/PowerOCR/PowerOCR/OCROverlay.xaml.cs:360` [Medium] - // TODO: Set the preferred language based upon what was chosen here
- `src/modules/PowerOCR/PowerOCR/Settings/UserSettings.cs:48` [Medium] - // TODO this IO call should by Async, update GetFileWatcher helper to support async
- `src/modules/PowerOCR/PowerOCR/Settings/UserSettings.cs:113` [Medium] - // TODO: Send Telemetry when settings change


#### Module: powerrename (5 TODOs)

**Bug Fix** (1 items):

- `src/modules/powerrename/lib/PowerRenameManager.cpp:956` [Medium] - // TODO: an exception can happen while typing the expression and the syntax is not correct yet,

**General** (4 items):

- `src/modules/powerrename/lib/MRUListHandler.cpp:30` [Medium] - // TODO: Already existing item should be put on top of MRU list.
- `src/modules/powerrename/lib/PowerRenameManager.cpp:860` [Medium] - // TODO: If we do, post a message back to ourselves
- `src/modules/powerrename/lib/PowerRenameRegEx.cpp:388` [Medium] - // TODO: creating the regex could be costly.  May want to cache this.
- `src/modules/powerrename/unittests/PowerRenameManagerTests.cpp:73` [Medium] - // TODO: Setup match and replace parameters


#### Module: previewpane (3 TODOs)

**Feature** (3 items):

- `src/modules/previewpane/GcodeThumbnailProvider/GcodeThumbnailProvider.cs:60` [Medium] - // TODO: add logger
- `src/modules/previewpane/PdfThumbnailProvider/PdfThumbnailProvider.cs:75` [Medium] - // TODO: add logger
- `src/modules/previewpane/QoiThumbnailProvider/QoiThumbnailProvider.cs:57` [Medium] - // TODO: add logger


#### Module: registrypreview (3 TODOs)

**General** (3 items):

- `src/modules/registrypreview/RegistryPreview/RegistryPreviewXAML/App.xaml.cs:113` [Medium] - #pragma warning disable CA2211 // Non-constant fields should not be visible. TODO: consider making it a property
- `src/modules/registrypreview/RegistryPreview/RegistryPreviewXAML/MainWindow.xaml.cs:47` [Medium] - // TODO(stefan)
- `src/modules/registrypreview/RegistryPreviewUILib/RegistryPreviewMainPage.xaml.cs:37` [Medium] - // TODO (stefan): check ctor


#### Module: ShortcutGuide (1 TODOs)

**Refactoring** (1 items):

- `src/modules/ShortcutGuide/ShortcutGuide/shortcut_guide.cpp:22` [Medium] - // TODO: refactor singleton


#### Module: Workspaces (3 TODOs)

**Bug Fix** (3 items):

- `src/modules/Workspaces/WorkspacesEditor/Utils/WorkspacesEditorIO.cs:158` [Medium] - // TODO: show error
- `src/modules/Workspaces/WorkspacesSnapshotTool/SnapshotUtils.cpp:103` [Medium] - // fix for the packaged apps that are not caught when minimized, e.g. Settings, Microsoft ToDo, ...
- `src/modules/Workspaces/WorkspacesWindowArranger/WindowArranger.cpp:185` [Medium] - // fix for the packaged apps that are not caught when minimized, e.g. Settings, Microsoft ToDo, ...


#### Module: ZoomIt (3 TODOs)

**Feature** (1 items):

- `src/modules/ZoomIt/ZoomIt/Zoomit.cpp:7574` [Medium] - // TODO: Update the Windows 11 21H2 revision check when the final number is known. Also add a

**General** (2 items):

- `src/modules/ZoomIt/ZoomItModuleInterface/dllmain.cpp:69` [Medium] - // TODO: Read settings from Registry.
- `src/modules/ZoomIt/ZoomItModuleInterface/dllmain.cpp:84` [Medium] - // TODO: Save settings to registry.


---

## Notes

- **Priority** is automatically determined based on keywords:
  - **High**: critical, urgent, important, asap, high priority
  - **Low**: low priority, nice to have, future, someday, optional
  - **Medium**: all others
  
- **Category** is automatically determined based on content:
  - **Performance**: performance, perf, speed, slow, optimize
  - **Testing**: test, testing, unit test, integration
  - **Bug Fix**: bug, fix, error, issue, crash, exception
  - **Feature**: feature, implement, add, new, enhancement
  - **Refactoring**: refactor, cleanup, clean, organize, restructure
  - **UI/UX**: ui, ux, interface, design, layout
  - **Security**: security, auth, permission, privilege
  - **Logging/Debug**: log, logging, diagnostic, debug
  - **General**: all others

*This report was generated automatically by the PowerToys TODO collection script.*
*Last updated: 2025-06-11 03:38:13*

