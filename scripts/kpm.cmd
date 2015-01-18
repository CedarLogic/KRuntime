@Echo OFF
SETLOCAL
SET ERRORLEVEL=

"%~dp0dotnet" %DOTNET_OPTIONS% "%~dp0lib\Microsoft.Framework.PackageManager" %*

exit /b %ERRORLEVEL%
ENDLOCAL
