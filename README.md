# WindowsFontEditor
Change windows 10 default interface font
Requires registry tweak: 

    Windows Registry Editor Version 5.00
    
    [HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts]
    "Segoe UI (TrueType)"=""
    "Segoe UI Bold (TrueType)"=""
    "Segoe UI Bold Italic (TrueType)"=""
    "Segoe UI Italic (TrueType)"=""
    "Segoe UI Light (TrueType)"=""
    "Segoe UI Semibold (TrueType)"=""
    "Segoe UI Symbol (TrueType)"=""

    [HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\FontSubstitutes]
    "Segoe UI"="ENTER-NEW-FONT-NAME"
