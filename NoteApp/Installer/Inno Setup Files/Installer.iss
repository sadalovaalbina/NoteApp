#define MyAppName = "NoteApp"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "Elizaveta Kolbas"
#define MyAppURL "https://github.com/lhoney614/NoteApp"
#define MyAppExeName "NoteAppUI.exe"
#define UninstallName "unins000.exe"
#define StartMenuFolderName "NoteApp"
#define AppIconName "128x128_app.ico"

[Setup]
AppId  = {{0CFE0878-DA14-4AA5-B75D-0EAC308D3C8A}}
AppName = {#MyAppName}
AppVersion = {#MyAppVersion}
;AppVerName = {#MyAppName}{#MyAppVersion}
AppPublisher = {#MyAppPublisher}
AppPublisherURL = {#MyAppURL}
AppSupportURL = {#MyAppURL}
AppUpdatesURL = {#MyAppURL}
DefaultDirName = {autopf}\{#MyAppName}
DefaultGroupName = {#MyAppName}
ChangesAssociations = yes
DisableProgramGroupPage = yes
OutputDir = Installers
OutputBaseFilename = NoteAppSetup
SetupIconFile = "..\NoteAppUI\{#AppIconName}"
Compression = lzma
SolidCompression = yes
WizardStyle = modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"

[Dirs]
Name: "{commonstartmenu}\{#StartMenuFolderName}"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "Release\*.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "Release\*.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\NoteAppUI\{#AppIconName}"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{commonstartmenu}\{#StartMenuFolderName}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename:"{app}\{#AppIconName}"
Name: "{commonstartmenu}\{#StartMenuFolderName}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{app}\{#UninstallName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFileName: "{app}\{#AppIconName}";  Tasks:desktopicon 

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

