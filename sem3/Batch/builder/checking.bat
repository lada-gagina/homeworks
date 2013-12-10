@echo off
if "%Start%"=="" goto :EOF

echo Checking the building...

for /F "tokens=*" %%i in (%fileList%) do if not exist "%buildFolder%\%%i" set FileNotFound=%%i& goto :error

echo Building is correct.
goto :EOF  

:error
echo Not found: %FileNotFound%.
set checkingError=true