<# 
.SYNOPSIS
Generates the Algorithms Problem Set list in README.md.

.DESCRIPTION
Scans Coding.Challenges/Easy, Coding.Challenges/Medium, and Coding.Challenges/Hard for .cs files and
replaces the content between markers in README.md:

<!-- ALGORITHMS_PROBLEM_SET:START -->
...
<!-- ALGORITHMS_PROBLEM_SET:END -->

Only the content between the markers is replaced.
#>

[CmdletBinding()]
param(
  [Parameter(Mandatory = $false)]
  [string]$ReadmePath = "./README.md",

  [Parameter(Mandatory = $false)]
  [string]$ChallengesRoot = "./Coding.Challenges"
)

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

$startMarker = "<!-- ALGORITHMS_PROBLEM_SET:START -->"
$endMarker   = "<!-- ALGORITHMS_PROBLEM_SET:END -->"

function To-TitleCaseFromPascalCase([string]$name) {
  # Insert spaces between lower/digit -> upper transitions safely (no $1/$2, no args indexing)
  $spaced = $name -replace '([a-z0-9])([A-Z])', { "$($Matches[1]) $($Matches[2])" }

  # Normalize common acronyms
  $spaced = ($spaced -replace '\bBst\b', 'BST')
  $spaced = ($spaced -replace '\bId\b', 'ID')

  return $spaced.Trim()
}

function Get-ProblemLinks([string]$difficulty) {
  $dir = Join-Path $ChallengesRoot $difficulty
  if (-not (Test-Path $dir)) { return @() }

  $files = Get-ChildItem -Path $dir -Filter "*.cs" -File | Sort-Object Name

  # Heuristic: exclude files that look like tests living in Coding.Challenges
  $files = $files | Where-Object { $_.Name -notmatch '^(Test|Tests).*\.cs$' }

  $links = @()
  foreach ($f in $files) {
    $base = [System.IO.Path]::GetFileNameWithoutExtension($f.Name)
    $title = To-TitleCaseFromPascalCase $base
    $relativePath = "Coding.Challenges/$difficulty/$($f.Name)"
    $links += "- [$title]($relativePath)"
  }

  return $links
}

function Build-AlgorithmsSection() {
  $easy   = @(Get-ProblemLinks "Easy")
  $medium = @(Get-ProblemLinks "Medium")
  $hard   = @(Get-ProblemLinks "Hard")

  $lines = @()

  # Optional: keep as comment (NOT visible)
  # If you already have a comment above the markers in README, you can delete this line.
  $lines += "<!-- This list is auto-generated from `Coding.Challenges/`. Run scripts/generate-algorithms-index.ps1 to refresh. -->"
  $lines += ""

  $lines += "<a id=""easy""></a>"
  $lines += "### Easy"
  if ($easy.Count -gt 0) { $lines += $easy } else { $lines += "- (none yet)" }
  $lines += ""

  $lines += "<a id=""medium""></a>"
  $lines += "### Medium"
  if ($medium.Count -gt 0) { $lines += $medium } else { $lines += "- (none yet)" }
  $lines += ""

  $lines += "<a id=""hard""></a>"
  $lines += "### Hard"
  if ($hard.Count -gt 0) { $lines += $hard } else { $lines += "- (coming soon)" }
  $lines += ""

  return ($lines -join "`n")
}

if (-not (Test-Path $ReadmePath)) {
  throw "README not found at path: $ReadmePath"
}

$readme = Get-Content -Path $ReadmePath -Raw

if ($readme -notmatch [regex]::Escape($startMarker) -or $readme -notmatch [regex]::Escape($endMarker)) {
  throw "README.md must contain markers: $startMarker and $endMarker"
}

$generated = Build-AlgorithmsSection

$pattern = "(?s)" + [regex]::Escape($startMarker) + ".*?" + [regex]::Escape($endMarker)
$replacement = $startMarker + "`n" + $generated + "`n" + $endMarker

$newReadme = [regex]::Replace($readme, $pattern, $replacement)

if ($newReadme -ne $readme) {
  Set-Content -Path $ReadmePath -Value $newReadme -NoNewline
  Write-Host "Updated $ReadmePath"
} else {
  Write-Host "No changes needed."
}
