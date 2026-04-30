<#
.SYNOPSIS
Generates the "Algorithms Problem Set" section in README.md.

.DESCRIPTION
Scans Coding.Challenges/Easy, Coding.Challenges/Medium, and Coding.Challenges/Hard for .cs files and
replaces the content between markers in README.md:

<!-- ALGORITHMS_PROBLEM_SET:START -->
...
<!-- ALGORITHMS_PROBLEM_SET:END -->
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
  # Split PascalCase safely: insert space before capitals (except at start)
  $spaced = ($name -creplace '(?<!^)([A-Z])', ' $1')

  # Normalize common acronyms
  $spaced = ($spaced -replace '\bBst\b', 'BST')
  $spaced = ($spaced -replace '\bId\b', 'ID')

  return $spaced.Trim()
}

function Get-ProblemLinks([string]$difficulty) {
  $dir = Join-Path $ChallengesRoot $difficulty
  if (-not (Test-Path $dir)) {
    return @()
  }

  $files = Get-ChildItem -Path $dir -Filter "*.cs" -File | Sort-Object Name
  $files = $files | Where-Object { $_.Name -notmatch '^(Test|Tests).*\.cs$' }

  $links = foreach ($f in $files) {
    $base = [System.IO.Path]::GetFileNameWithoutExtension($f.Name)
    $title = To-TitleCaseFromPascalCase $base
    $relativePath = "Coding.Challenges/$difficulty/$($f.Name)"
    "- [$title]($relativePath)"
  }

  # Force string[] even when there's 0 or 1 item
  return ,$links
}

function Build-AlgorithmsSection() {
  $easy   = @((Get-ProblemLinks "Easy"))
  $medium = @((Get-ProblemLinks "Medium"))
  $hard   = @((Get-ProblemLinks "Hard"))

  $lines = @()

  $lines += "<!-- This list is auto-generated from `Coding.Challenges/`. Run scripts/generate-algorithms-index.ps1 to refresh. -->"
  $lines += ""

  $lines += "<a id=""easy""></a>"
  $lines += "### Easy"
  if ($easy.Length -gt 0) { $lines += $easy } else { $lines += "- (none yet)" }
  $lines += ""

  $lines += "<a id=""medium""></a>"
  $lines += "### Medium"
  if ($medium.Length -gt 0) { $lines += $medium } else { $lines += "- (none yet)" }
  $lines += ""

  $lines += "<a id=""hard""></a>"
  $lines += "### Hard"
  if ($hard.Length -gt 0) { $lines += $hard } else { $lines += "- (coming soon)" }
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
