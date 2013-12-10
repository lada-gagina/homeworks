@echo off
if "%Start%"=="" goto :EOF

set repoName=Geometry
set solutionName=CircleAndSegment

set gitURL=https://github.com/ladagagina/Geometry.git

:: Folders
set buildFolder=%repoName%\%solutionName%\WindowsFormsApplication1\bin\Debug
set solution=%repoName%\%solutionName%\%solutionName%.sln

:: Files
set fileList=builder\fileList.txt

:: Logs
set cloningErrors=CloningErrors.log
set MSBuildLog=MSBuildLog.log
set sendingErrors=sendingErrors.log

:: Errors
set cloningError=false
set buildingError=false
set checkingError=false
set sendingError=false

:: Nonexistent File
set FileNotFound=

:: Blat
set emailBody=Successful build the solution.
set emailFile=%MSBuildLog%
set emailSubject=Auto-building solution: %solutionName%
set emailList=builder\emailList.txt
