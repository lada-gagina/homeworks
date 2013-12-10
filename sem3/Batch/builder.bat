@echo off

set Start=true

call builder\settings.bat

call builder\remove.bat

call builder\cloning.bat
if "%cloningError%"=="true" goto :end

call builder\building.bat
if "%buildingError%"=="true" goto :end

call builder\checking.bat

:end
call builder\email.bat

call builder\finishing.bat

echo Done.

timeout /t 5 > nul