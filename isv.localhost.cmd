@echo off
:: IIS		 
set APPCMD=%WinDir%\System32\inetsrv\appcmd.exe
set SITENAME=isv.localhost
set CRD=%~dp0
set CRD=%CRD:Installation_Scripts\=%

%APPCMD% list site /name:%SITENAME%
IF "%ERRORLEVEL%" EQU "0" (
    echo.
    echo Removing %SITENAME%* sites...
    %APPCMD% delete site /site.name:%SITENAME%
)																
%APPCMD% list apppool /apppool.name:"isv-backend"
IF "%ERRORLEVEL%" EQU "0" (
    echo.
    %APPCMD% delete apppool "isv-backend"
)									   
echo.
echo Creating application pools...
%APPCMD% add apppool /apppool.name:"isv-backend"		/managedRuntimeVersion:"v4.0" /managedPipelineMode:"Integrated"

echo.
echo Setting application pools identity
%APPCMD% set config /section:applicationPools /[name='isv-backend'].processModel.identityType:ApplicationPoolIdentity

echo.
echo Preparing site folders...
if not exist %SystemDrive%\inetpub\%SITENAME%		mkdir %SystemDrive%\inetpub\%SITENAME%			
									 
echo.
echo Importing site/applications...
%APPCMD% add site /in < %CRD%\isv.localhost.xml
						 
echo.
echo Updating physical paths...
%APPCMD% set vdir -vdir.name:"%SITENAME%/"			    -physicalPath:"%SystemDrive%\inetpub\%SITENAME%"
%APPCMD% set vdir -vdir.name:"%SITENAME%/backend/"		-physicalPath:"%CRD%src\ISV.Services.Host"

echo.
echo Enabling required authentication modes...

%APPCMD% set config "%SITENAME%/backend"	 /enabled:"True" /commit:apphost -section:system.webServer/security/authentication/windowsAuthentication
%APPCMD% set config "%SITENAME%/backend"	 /enabled:"True" /commit:apphost -section:system.webServer/security/authentication/basicAuthentication

echo.
echo Done!
echo Add the following entries to  %WinDir%\system32\drivers\etc\hosts file:
echo 	127.0.0.1		isv.localhost
echo.	 
pause
