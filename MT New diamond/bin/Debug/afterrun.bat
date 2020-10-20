move app\dist\app-aligned-debugSigned.apk out
set name=%1
set newname=%random%%random%
rename out\app-aligned-debugSigned.apk %name% %newname%_app.apk