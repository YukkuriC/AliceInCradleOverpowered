@echo off
echo ========================================
echo Building AliceInCradleOverpowered...
echo ========================================
echo.

call dotnet build AliceInCradleOverpowered.csproj -c Release --no-dependencies -v normal

if %ERRORLEVEL% NEQ 0 (
    echo.
    echo [ERROR] Build failed!
    exit /b %ERRORLEVEL%
)

echo.
echo ========================================
echo [SUCCESS] Build completed!
echo Output: bin\Release\AliceInCradleOverpowered.dll
echo ========================================
