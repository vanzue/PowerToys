#!/usr/bin/env pwsh

# PowerToys TODO Collection Script
# This script scans the PowerToys codebase and generates a comprehensive report of all TODO items
# for prioritization and tracking purposes.

param(
    [string]$OutputPath = ".\todo-report.md",
    [switch]$ShowHelp
)

if ($ShowHelp) {
    Write-Host "PowerToys TODO Collection Script"
    Write-Host ""
    Write-Host "Usage: .\collect-todos.ps1 [-OutputPath <path>] [-ShowHelp]"
    Write-Host ""
    Write-Host "Parameters:"
    Write-Host "  -OutputPath   Path where the TODO report will be saved (default: ./todo-report.md)"
    Write-Host "  -ShowHelp     Show this help message"
    Write-Host ""
    Write-Host "Example:"
    Write-Host "  .\collect-todos.ps1 -OutputPath .\docs\todo-analysis.md"
    exit 0
}

# Set the working directory to the repository root
$ScriptDir = Split-Path -Parent $MyInvocation.MyCommand.Definition
$RepoRoot = Resolve-Path (Join-Path $ScriptDir "..\..") 
Set-Location $RepoRoot

Write-Host "Scanning PowerToys repository for TODO items..."
Write-Host "Repository root: $RepoRoot"

# Use grep to find all TODOs
Write-Host "Collecting TODO items using grep..."
$GrepOutput = & grep -r -i -n "todo" --include="*.cpp" --include="*.cs" --include="*.h" --include="*.hpp" --include="*.c" --include="*.cc" --include="*.cxx" --include="*.js" --include="*.ts" --include="*.py" --include="*.md" --include="*.txt" --include="*.xaml" --include="*.xml" --exclude-dir=".git" --exclude-dir="node_modules" --exclude-dir="bin" --exclude-dir="obj" --exclude-dir="packages" --exclude-dir=".vs" --exclude-dir="Debug" --exclude-dir="Release" --exclude-dir="x64" --exclude-dir="x86" --exclude-dir="target" . 2>$null

if (-not $GrepOutput) {
    Write-Warning "No TODO items found or grep command failed"
    exit 1
}

Write-Host "Processing $($GrepOutput.Count) TODO items..."

# Process grep output
$TodoItems = @()
foreach ($Line in $GrepOutput) {
    if ($Line -match "^([^:]+):(\d+):(.*)$") {
        $FilePath = $Matches[1].TrimStart('.', '/')
        $LineNumber = [int]$Matches[2]
        $TodoText = $Matches[3].Trim()
        
        # Extract the component/module from the path
        $PathParts = $FilePath -split '[/\\]'
        $Component = if ($PathParts.Length -gt 1 -and $PathParts[0] -eq "src") {
            if ($PathParts.Length -gt 2 -and $PathParts[1] -eq "modules") {
                "Module: $($PathParts[2])"
            } elseif ($PathParts.Length -gt 1) {
                "Core: $($PathParts[1])"
            } else {
                "Core"
            }
        } elseif ($PathParts.Length -gt 0 -and $PathParts[0] -eq "doc") {
            "Documentation"
        } elseif ($PathParts.Length -gt 0 -and $PathParts[0] -eq "tools") {
            "Tools"
        } else {
            "Other"
        }
        
        # Categorize TODO by keywords
        $Category = "General"
        if ($TodoText -match "(?i)\b(performance|perf|speed|slow|optimize|optimization)\b") {
            $Category = "Performance"
        } elseif ($TodoText -match "(?i)\b(test|testing|unit test|integration)\b") {
            $Category = "Testing"
        } elseif ($TodoText -match "(?i)\b(bug|fix|error|issue|crash|exception)\b") {
            $Category = "Bug Fix"
        } elseif ($TodoText -match "(?i)\b(feature|implement|add|new|enhancement)\b") {
            $Category = "Feature"
        } elseif ($TodoText -match "(?i)\b(refactor|cleanup|clean|organize|restructure)\b") {
            $Category = "Refactoring"
        } elseif ($TodoText -match "(?i)\b(ui|ux|interface|design|layout)\b") {
            $Category = "UI/UX"
        } elseif ($TodoText -match "(?i)\b(security|auth|permission|privilege)\b") {
            $Category = "Security"
        } elseif ($TodoText -match "(?i)\b(log|logging|diagnostic|debug)\b") {
            $Category = "Logging/Debug"
        }
        
        # Determine priority based on keywords
        $Priority = "Medium"
        if ($TodoText -match "(?i)\b(critical|urgent|important|asap|high priority)\b") {
            $Priority = "High"
        } elseif ($TodoText -match "(?i)\b(low priority|nice to have|future|someday|optional)\b") {
            $Priority = "Low"
        }
        
        $TodoItems += [PSCustomObject]@{
            File = $FilePath
            LineNumber = $LineNumber
            Component = $Component
            Category = $Category
            Priority = $Priority
            Text = $TodoText
        }
    }
}

$TodoCount = $TodoItems.Count
Write-Host "Found $TodoCount TODO items." -ForegroundColor Green

# Generate the report
Write-Host "Generating TODO report at: $OutputPath"

$ReportContent = @"
# PowerToys TODO Report

Generated on: $(Get-Date -Format "yyyy-MM-dd HH:mm:ss")
Repository root: $($RepoRoot.Path)
Total TODO items found: $TodoCount

## Summary by Component

"@

# Component summary
$ComponentSummary = $TodoItems | Group-Object Component | Sort-Object Count -Descending
foreach ($Group in $ComponentSummary) {
    $ReportContent += "- **$($Group.Name)**: $($Group.Count) TODOs`n"
}

$ReportContent += @"

## Summary by Category

"@

# Category summary
$CategorySummary = $TodoItems | Group-Object Category | Sort-Object Count -Descending
foreach ($Group in $CategorySummary) {
    $ReportContent += "- **$($Group.Name)**: $($Group.Count) TODOs`n"
}

$ReportContent += @"

## Summary by Priority

"@

# Priority summary
$PrioritySummary = $TodoItems | Group-Object Priority | Sort-Object @{Expression={if($_.Name -eq "High") {3} elseif($_.Name -eq "Medium") {2} else {1}}} -Descending
foreach ($Group in $PrioritySummary) {
    $ReportContent += "- **$($Group.Name)**: $($Group.Count) TODOs`n"
}

$ReportContent += @"

## Detailed TODO List

### High Priority TODOs

"@

# High priority TODOs
$HighPriorityTodos = $TodoItems | Where-Object { $_.Priority -eq "High" } | Sort-Object Component, File
foreach ($Todo in $HighPriorityTodos) {
    $ReportContent += "- **[$($Todo.Component)]** ``$($Todo.File):$($Todo.LineNumber)`` - $($Todo.Text)`n"
}

if ($HighPriorityTodos.Count -eq 0) {
    $ReportContent += "*No high priority TODOs found.*`n"
}

$ReportContent += @"

### TODOs by Component

"@

# Group by component for detailed view
$TodosByComponent = $TodoItems | Sort-Object Component, Category, File | Group-Object Component

foreach ($ComponentGroup in $TodosByComponent) {
    $ReportContent += "`n#### $($ComponentGroup.Name) ($($ComponentGroup.Count) TODOs)`n`n"
    
    $TodosByCategory = $ComponentGroup.Group | Group-Object Category
    foreach ($CategoryGroup in $TodosByCategory) {
        $ReportContent += "**$($CategoryGroup.Name)** ($($CategoryGroup.Count) items):`n`n"
        
        foreach ($Todo in $CategoryGroup.Group | Sort-Object File, LineNumber) {
            $ReportContent += "- ``$($Todo.File):$($Todo.LineNumber)`` [$($Todo.Priority)] - $($Todo.Text)`n"
        }
        $ReportContent += "`n"
    }
}

$ReportContent += @"

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
*Last updated: $(Get-Date -Format "yyyy-MM-dd HH:mm:ss")*

"@

# Write the report to file
try {
    $ReportContent | Out-File -FilePath $OutputPath -Encoding UTF8
    Write-Host "TODO report successfully saved to: $OutputPath" -ForegroundColor Green
    Write-Host ""
    Write-Host "Report Summary:" -ForegroundColor Cyan
    Write-Host "- Total TODOs: $TodoCount" -ForegroundColor White
    Write-Host "- High Priority: $(($TodoItems | Where-Object { $_.Priority -eq 'High' }).Count)" -ForegroundColor Red
    Write-Host "- Medium Priority: $(($TodoItems | Where-Object { $_.Priority -eq 'Medium' }).Count)" -ForegroundColor Yellow
    Write-Host "- Low Priority: $(($TodoItems | Where-Object { $_.Priority -eq 'Low' }).Count)" -ForegroundColor Green
    Write-Host ""
    Write-Host "Top components with TODOs:" -ForegroundColor Cyan
    $ComponentSummary | Select-Object -First 5 | ForEach-Object {
        Write-Host "  $($_.Name): $($_.Count)" -ForegroundColor White
    }
}
catch {
    Write-Error "Failed to write report to $OutputPath`: $($_.Exception.Message)"
    exit 1
}