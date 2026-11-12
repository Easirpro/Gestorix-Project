; Instalador de Gestorix (Inno Setup 6). Se compila con GenerarInstalador.ps1, que antes
; publica el programa en .\publicado y genera la firma de la base de referencia de .\base.

#define Version "0.0.1.4"
#define VersionBase "0.0.1.2"

[Setup]
AppId={{8F3C2A51-6B7D-4E2A-9C1F-3D5E7A9B1C20}
AppName=Gestorix
AppVersion={#Version}
AppPublisher=Gestorix
DefaultDirName={autopf}\Gestorix
DefaultGroupName=Gestorix
DisableProgramGroupPage=yes
OutputDir=salida
OutputBaseFilename=Gestorix
SetupIconFile=..\Imagenes\Logoicon.ico
UninstallDisplayIcon={app}\CapaVista.exe
Compression=lzma2
SolidCompression=yes
WizardStyle=modern
PrivilegesRequired=admin
ArchitecturesAllowed=x64compatible
ArchitecturesInstallIn64BitMode=x64compatible

[Languages]
Name: "es"; MessagesFile: "compiler:Languages\Spanish.isl"

[Tasks]
Name: "escritorio"; Description: "Crear un acceso directo en el escritorio"; GroupDescription: "Accesos directos:"

[Dirs]
; Los datos de Gestorix van fuera de Program Files y no se borran al desinstalar (son los backups).
; La ruta es fija en C:\Gestorix porque el programa la busca ahí (ClsBackupLogica).
Name: "C:\Gestorix\Backups"; Flags: uninsneveruninstall
Name: "C:\Gestorix\BaseInicial"; Flags: uninsneveruninstall

[Files]
Source: "publicado\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; Base de referencia: el programa la restaura sola la primera vez que se abre (si no existe la base).
Source: "base\Gestorix_referencia_{#VersionBase}.bak"; DestDir: "C:\Gestorix\BaseInicial"; DestName: "Gestorix_inicial.bak"; Flags: ignoreversion uninsneveruninstall
Source: "base\Gestorix_referencia_{#VersionBase}.bak.hash"; DestDir: "C:\Gestorix\BaseInicial"; DestName: "Gestorix_inicial.bak.hash"; Flags: ignoreversion uninsneveruninstall

[Icons]
Name: "{group}\Gestorix"; Filename: "{app}\CapaVista.exe"
Name: "{group}\Desinstalar Gestorix"; Filename: "{uninstallexe}"
Name: "{autodesktop}\Gestorix"; Filename: "{app}\CapaVista.exe"; Tasks: escritorio

[Run]
; El servicio de SQL Server lee la base inicial y escribe los backups en C:\Gestorix.
Filename: "{sys}\icacls.exe"; Parameters: """C:\Gestorix"" /grant ""NT SERVICE\MSSQL$SQLEXPRESS:(OI)(CI)M"" /T /Q"; Flags: runhidden waituntilterminated; StatusMsg: "Dando permisos a SQL Server sobre la carpeta de Gestorix..."
Filename: "{app}\CapaVista.exe"; Description: "Abrir Gestorix"; Flags: nowait postinstall skipifsilent

[Code]
// SQL Server es requisito previo: tiene que estar la instancia SQLEXPRESS de SQL Server 2025
// (versión 17) o más nuevo, porque la base de referencia es de esa versión.
function VersionSqlExpress(): Integer;
var
  Instancia, Numero: String;
  Punto: Integer;
begin
  Result := 0;
  if RegQueryStringValue(HKLM64, 'SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL', 'SQLEXPRESS', Instancia) then
  begin
    // El valor tiene la forma MSSQL17.SQLEXPRESS
    Numero := Copy(Instancia, 6, Length(Instancia));
    Punto := Pos('.', Numero);
    if Punto > 0 then
      Numero := Copy(Numero, 1, Punto - 1);
    Result := StrToIntDef(Numero, 0);
  end;
end;

function InitializeSetup(): Boolean;
var
  Version: Integer;
begin
  Version := VersionSqlExpress();
  Result := Version >= 17;

  if Version = 0 then
    MsgBox('Gestorix necesita SQL Server 2025 Express con la instancia SQLEXPRESS y no se encontró en esta PC.' + #13#10#13#10 +
      'Instálelo y vuelva a ejecutar este instalador:' + #13#10 +
      'https://www.microsoft.com/es-es/sql-server/sql-server-downloads', mbError, MB_OK)
  else if not Result then
    MsgBox('La instancia SQLEXPRESS de esta PC es de una versión anterior a SQL Server 2025.' + #13#10#13#10 +
      'Gestorix necesita SQL Server 2025 Express o más nuevo. Actualícelo y vuelva a ejecutar este instalador.', mbError, MB_OK);
end;
