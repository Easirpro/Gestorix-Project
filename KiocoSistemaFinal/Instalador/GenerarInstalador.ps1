# Genera el instalador de Gestorix en .\salida:
#   1. Publica el programa en .\publicado (Release, autocontenido: la PC no necesita .NET instalado).
#   2. Genera la firma de la base de referencia que está en .\base.
#   3. Compila Gestorix.iss con Inno Setup 6.
# Uso (PowerShell, desde esta carpeta): .\GenerarInstalador.ps1

$ErrorActionPreference = 'Stop'

$aqui = $PSScriptRoot
$publicado = Join-Path $aqui 'publicado'
$bak = Join-Path $aqui 'base\Gestorix_referencia_0.0.1.2.bak'

$iscc = @(
    "${env:ProgramFiles(x86)}\Inno Setup 6\ISCC.exe",
    "$env:ProgramFiles\Inno Setup 6\ISCC.exe",
    "$env:LOCALAPPDATA\Programs\Inno Setup 6\ISCC.exe"
) | Where-Object { Test-Path $_ } | Select-Object -First 1

if (-not $iscc) {
    throw 'No se encontró Inno Setup 6 (ISCC.exe). Instalarlo desde https://jrsoftware.org/isdl.php'
}

if (-not (Test-Path $bak)) {
    throw "No se encontró la base de referencia: $bak"
}

if (Test-Path $publicado) { Remove-Item $publicado -Recurse -Force }

Write-Host 'Publicando el programa...'
dotnet publish (Join-Path $aqui '..\SistemaFinalKiosco\CapaVista\CapaVista.csproj') -c Release -r win-x64 --self-contained true -o $publicado
if ($LASTEXITCODE -ne 0) { throw 'Falló la publicación del programa.' }

Write-Host 'Generando la firma de la base de referencia...'
# Sin salto de línea: el programa compara el texto exacto
[System.IO.File]::WriteAllText("$bak.hash", (Get-FileHash $bak -Algorithm SHA256).Hash)

Write-Host 'Compilando el instalador...'
& $iscc (Join-Path $aqui 'Gestorix.iss')
if ($LASTEXITCODE -ne 0) { throw 'Falló Inno Setup.' }

Write-Host ('Instalador generado en ' + (Join-Path $aqui 'salida'))
