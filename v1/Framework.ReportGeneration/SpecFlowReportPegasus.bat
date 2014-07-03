set SAVESTAMP=%DATE:/=-%@%TIME::=-%
set SAVESTAMP=BDD_SMOKERESULT_%SAVESTAMP: =%.html

for /f "delims=" %%x in ('dir /od /a-d /b D:\B2\TestResults\*.*') do set recent=%%x

echo %recent%

REM Remove space from the file name here

set OldFileName=%recent%

set NewFileName=%OldFileName: =%

rem ren "E:\B2\TestResults\%OldFileName%" %NewFileName%

ren "D:\B2\TestResults\%OldFileName%" %NewFileName%

"C:\Program Files (x86)\TechTalk\SpecFlow\SpecFlow.exe" mstestexecutionreport D:\B1\PegasusBDD\PegasusTestScripts\PegasusTestScripts.csproj /testResult:D:\B2\TestResults\%NewFileName% /out:%SAVESTAMP%

echo Copy trx file to %1
copy D:\B2\TestResults\%NewFileName% %1\NovaNetTestResult.trx

echo %SAVESTAMP%

copy %SAVESTAMP% Z:\
copy %SAVESTAMP% %1\NovaNetTestResult.html