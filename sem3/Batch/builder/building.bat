@echo off
if "%Start%"=="" goto :EOF

echo Building solution...

chcp 1251 > nul
MSBuild %solution%>%MSBuildLog%
chcp 866 > nul

if errorlevel 1 goto :error

echo Build completed.
goto :EOF

:error
set buildingError=true
echo Error while building.