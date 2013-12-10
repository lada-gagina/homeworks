@echo off

if "%Start%"=="" goto :EOF

echo Cloning to %repoName%...

git clone %gitURL% >nul 2>%cloningErrors%

if errorlevel 1 goto :error

echo Cloning is completed.

goto :EOF

:error
set cloningError=true
echo Error while cloning.
