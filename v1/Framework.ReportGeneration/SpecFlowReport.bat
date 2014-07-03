IF EXIST TestResult.trx DEL TestResult.trx

"C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\mstest.exe" /testmetadata:D:\Pegasus_BDD\STTestList.vsmdi /testlist:STTestList /resultsfile:TestResult.trx

set SAVESTAMP=%DATE:/=-%@%TIME::=-%
set SAVESTAMP=SMOKERESULT_%SAVESTAMP: =%.html

"C:\Program Files (x86)\TechTalk\SpecFlow\SpecFlow.exe" mstestexecutionreport ../PegasusTestScripts/PegasusTestScripts.csproj /testResult:TestResult.trx /out:%SAVESTAMP%

echo %SAVESTAMP%
