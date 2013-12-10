@echo off
if "%Start%"=="" goto :EOF

echo Sending the results of build solutions...

if %cloningError%==true (
  set emailBody=An error occurred while cloning repository.
  set emailSubject=%emailSubject% [Error in cloning repo]
  set emailFile=%cloningErrors%
 )
 
if %buildingError%==true (
  set emailBody=An error occurred while building solution.
  set emailSubject=%emailSubject% [Error in build solution]
 ) 
 
if %checkingError%==true (
  set emailBody=File %FileNotFound% not found in the results of building.
  set emailSubject=%emailSubject% [File not found]
 )  

blat -subject "%emailSubject%" -body "%emailBody%" -tf %emailList% -attach %emailFile% >nul 2>%sendingErrors%

if errorlevel 1 goto :error

echo Sending completed.
goto :EOF

:error

set sendingError=true
echo Error while sending.