@echo off
if "%Start%"=="" goto :EOF

if %sendingError%==false (
  if exist %cloningErrors% del %cloningErrors%
  if exist %MSBuildLog% del %MSBuildLog%
  if exist %sendingErrors% del %sendingErrors%  
)