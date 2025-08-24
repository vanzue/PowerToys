# TODO Collection Tool

The TODO Collection Tool is a PowerShell script that scans the PowerToys codebase and generates a comprehensive report of all TODO items for prioritization and tracking purposes.

## Location

The script is located at: `tools/build/collect-todos.ps1`

## Usage

### Basic Usage

```powershell
.\tools\build\collect-todos.ps1
```

This will generate a `todo-report.md` file in the repository root.

### Advanced Usage

```powershell
# Specify custom output path
.\tools\build\collect-todos.ps1 -OutputPath .\docs\todo-analysis.md

# Show help
.\tools\build\collect-todos.ps1 -ShowHelp
```

## Generated Report

The script generates a comprehensive markdown report that includes:

### Summary Sections
- **Component Summary**: TODOs grouped by component/module
- **Category Summary**: TODOs grouped by category (Feature, Bug Fix, Performance, etc.)
- **Priority Summary**: TODOs grouped by priority (High, Medium, Low)

### Detailed Sections
- **High Priority TODOs**: List of TODOs marked as high priority
- **TODOs by Component**: Detailed breakdown organized by component and category

## Automatic Categorization

The tool automatically categorizes TODOs based on keywords found in the TODO text:

### Categories
- **Performance**: performance, perf, speed, slow, optimize, optimization
- **Testing**: test, testing, unit test, integration
- **Bug Fix**: bug, fix, error, issue, crash, exception
- **Feature**: feature, implement, add, new, enhancement
- **Refactoring**: refactor, cleanup, clean, organize, restructure
- **UI/UX**: ui, ux, interface, design, layout
- **Security**: security, auth, permission, privilege
- **Logging/Debug**: log, logging, diagnostic, debug
- **General**: all others

### Priorities
- **High**: critical, urgent, important, asap, high priority
- **Low**: low priority, nice to have, future, someday, optional
- **Medium**: all others

## Component Detection

The tool automatically detects components based on file paths:

- **Module: [name]**: Files under `src/modules/[name]/`
- **Core: [name]**: Files under `src/[name]/`
- **Documentation**: Files under `doc/`
- **Tools**: Files under `tools/`
- **Other**: All other files

## File Types Scanned

The tool scans the following file types:
- Source code: `.cpp`, `.cs`, `.h`, `.hpp`, `.c`, `.cc`, `.cxx`
- Scripts: `.js`, `.ts`, `.py`
- Documentation: `.md`, `.txt`
- UI: `.xaml`, `.xml`

## Excluded Directories

The following directories are excluded from the scan:
- `.git`, `node_modules`, `bin`, `obj`, `packages`
- `.vs`, `Debug`, `Release`, `x64`, `x86`, `target`

## Example Output

```
Report Summary:
- Total TODOs: 301
- High Priority: 1
- Medium Priority: 297
- Low Priority: 3

Top components with TODOs:
  Module: cmdpal: 118
  Core: settings-ui: 38
  Module: launcher: 15
  Module: MouseWithoutBorders: 13
  Core: Monaco: 12
```

## Integration with Development Workflow

### Regular Reporting
Run the tool regularly (e.g., before releases) to get an updated view of TODO items:

```powershell
.\tools\build\collect-todos.ps1 -OutputPath .\release-todos-$(Get-Date -Format "yyyy-MM-dd").md
```

### CI/CD Integration
The tool can be integrated into build pipelines to track TODO debt over time.

### Prioritization Meetings
Use the generated report in team meetings to discuss and prioritize TODO items based on:
- Component importance
- Category urgency
- Current development priorities

## Maintenance

The categorization and priority keywords can be updated by modifying the script. Consider updating the keywords based on team conventions and emerging patterns in the codebase.