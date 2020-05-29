@ECHO OFF

set TIMESTAMP=%DATE%

ECHO %TIMESTAMP%

REM Export all databases into file C:\path\backup\databases.[year][month][day].sql
"C:\Program Files\MySQL\MySQL Server 8.0\bin\mysqldump.exe" --databases nostrumex --result-file="D:\Nostrum backup\nostrum.%TIMESTAMP%.sql" --user=root --password=1234

REM Change working directory to the location of the DB dump file.
CD "D:\Nostrum backup\"

REM Compress DB dump file into CAB file (use "EXPAND file.cab" to decompress).
MAKECAB "nostrum.%TIMESTAMP%.sql" "nostrum.%TIMESTAMP%.sql.cab"

REM Delete uncompressed DB dump file.
DEL /q /f "nostrum.%TIMESTAMP%.sql"