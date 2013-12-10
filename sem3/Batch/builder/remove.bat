@echo off
if "%Start%"=="" goto :EOF

echo Removing the old repo...

if exist %repoName% goto :remove

echo Old repo not found.
goto :EOF

:remove
rd /s /q %repoName%
echo Remove completed.