set "currentPath=%~dp0"
powershell -nologo -noprofile -command "$userEnvPath = [Environment]::GetEnvironmentVariable('Path', 'User'); [Environment]::SetEnvironmentVariable('Path', $userEnvPath + ';%currentPath%MinGW\bin', 'User')"
pause
