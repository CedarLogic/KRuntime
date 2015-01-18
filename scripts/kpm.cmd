@Echo OFF
SETLOCAL
SET ERRORLEVEL=

"%~dp0dotnet" --appbase "%CD%" %DOTNET_OPTIONS% --lib "%~dp0lib\Microsoft.Framework.PackageManager" Microsoft.Framework.PackageManager %*

exit /b %ERRORLEVEL%
ENDLOCAL
