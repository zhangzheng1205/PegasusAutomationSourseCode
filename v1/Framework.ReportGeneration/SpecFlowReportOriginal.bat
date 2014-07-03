set SAVESTAMP=%DATE:/=-%@%TIME::=-%
set SAVESTAMP=BDD_SMOKERESULT_%SAVESTAMP: =%.html

for /f "delims=" %%x in ('dir /od /a-d /b D:\B2\TestResults\*.*') do set recent=%%x

echo %recent%

REM Remove space from the file name here

set OldFileName=%recent%

set NewFileName=%OldFileName: =%

rem ren "E:\B2\TestResults\%OldFileName%" %NewFileName%

ren "D:\B2\TestResults\%OldFileName%" %NewFileName%

"C:\Program Files (x86)\TechTalk\SpecFlow\SpecFlow.exe" mstestexecutionreport D:\B2\Sources\PegasusBDD\PegasusTestScripts\PegasusTestScripts.csproj /testResult:D:\B2\TestResults\%NewFileName% /out:%SAVESTAMP%

echo %SAVESTAMP%

copy %SAVESTAMP% Z:\
