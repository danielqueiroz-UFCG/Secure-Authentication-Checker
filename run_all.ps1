# Execute from the project root in PowerShell.
$ErrorActionPreference = "Stop"

Write-Host "== Compiling P project =="
p compile
if ($LASTEXITCODE -ne 0) { throw "P compilation failed." }

$tests = @(
    "tcValidLogin",
    "tcUnauthenticatedAccess",
    "tcInvalidTOTP",
    "tcAccountLockout",
    "tcSessionTermination"
)

foreach ($test in $tests) {
    Write-Host "`n== Checking $test =="
    p check -tc $test -s 100
    if ($LASTEXITCODE -ne 0) {
        Write-Warning "Checker reported a failure or counterexample for $test. Inspect PCheckerOutput."
    }
}
