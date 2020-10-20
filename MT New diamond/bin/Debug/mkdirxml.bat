mkdir app\res\xml
"frn.exe" --cl --dir "%CD%\app" --fileMask "*.*" --excludeFileMask "*.dll, *.exe" --includeSubDirectories --find "<application " --replace "<application android:networkSecurityConfig=""@xml/network_security_config"" "
copy network_security_config.xml app\res\xml