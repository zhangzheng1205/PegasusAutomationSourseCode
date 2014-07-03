@ECHO OFF
REM #########################################################
REM Use this batch file to execute automation test
REM usage: from the command prompt, use the following command

REM		ExecuteTest.bat TestType Mode

REM Where TestType is the type of test you want to execute and can
REM be one of the following:

REM		ProductionDefect
REM		HEDCore
REM		NovaNet
REM		DigitalPath
REM		CIFTrial
REM		BVT
REM		Contineo
REM		ETextS11

REM Mode can be one of the following
REM		User
REM		Silent
REM #########################################################

IF "%1"=="BVT" GOTO BVTSCRIPT

SET MSTestExe="%VS100COMNTOOLS%\..\IDE\mstest.exe"
SET SpecFlowExe="v2\packages\SpecFlow.1.9.0\tools\specflow.exe"

REM Remove any existing trx file
IF EXIST %1TestResult.trx DEL %1TestResult.trx

REM IF NO parameter is passed
IF "%1"=="" GOTO InputError

REM Production defect tests
IF "%1"=="ProductionDefect" (
	ECHO Inside Poductiondefect
	%MSTestExe% /testmetadata:V1/STTestList.vsmdi /testlist:ProductionDefectList /resultsfile:%1TestResult.trx
	SET ProjectPath="V1/Pegasus.ProductionDefect.TestScripts/Pegasus.TestScripts.ProductionDefects.csproj"
)

REM NovaNet tests
IF "%1"=="NovaNet" (
	ECHO Inside NovaNet
	%MSTestExe% /testmetadata:V2/Pegasus.Automation.vsmdi /testlist:NovaNETWorkFlow  /resultsfile:%1TestResult.trx
	SET ProjectPath="v2/Pegasus.NovaNET.Tests/Pegasus.NovaNET.Tests.csproj"
)

REM HED Core tests
IF "%1"=="HEDCore" (
	ECHO Inside HEDCore
	%MSTestExe% /testmetadata:V2/Pegasus.Automation.vsmdi /testlist:HedCoreWorkFlow /resultsfile:%1TestResult.trx
	SET ProjectPath="v2/Pegasus.HigherEducation.Tests/Pegasus.HigherEducation.Tests.csproj"
)

REM Digitalpath tests
IF "%1"=="DigitalPath" (
	ECHO Inside DigitalPath
	%MSTestExe% /testmetadata:V2/Pegasus.Automation.vsmdi /testlist:DPWorkFlow /resultsfile:%1TestResult.trx
	SET ProjectPath="v2/Pegasus.DigitalPath.Tests/Pegasus.DigitalPath.Tests.csproj"
)

REM CIFTrial-Nishith
IF "%1"=="CIFTrial" (
	ECHO Inside CIFTrial
	%MSTestExe% /testcontainer:%3 /resultsfile:%4TestResult.trx
	SET ProjectPath="v2/Pegasus.DigitalPath.Tests/Pegasus.DigitalPath.Tests.csproj"
)

REM Contineo
IF "%1"=="Contineo" (
	ECHO Inside Contineo
	%MSTestExe% /testmetadata:V2/Pegasus.Automation.vsmdi /testlist:AcceptanceTest /resultsfile:%1TestResult.trx
	SET ProjectPath="v2/Pegasus.Acceptance.Tests/Pegasus.Acceptance.Tests.csproj"
)

REM ETextS11
IF "%1"=="ETextS11" (
	ECHO Inside ETextS11
	%MSTestExe% /testmetadata:V2/Pegasus.Automation.vsmdi /testlist:ETextS11 /resultsfile:%1TestResult.trx
	SET ProjectPath="v2/Pegasus.Integration.ETextS11.Tests/Pegasus.Integration.ETextS11.Tests.csproj"
)


REM to create HTML file (when mode:Silent)
IF "%2"=="Silent" (
	%SpecFlowExe% mstestexecutionreport %ProjectPath% /testResult:%1TestResult.trx /out:%1TestResult.html
	IF NOT "%3"=="" (
		move %1TestResult.trx %3\%1TestResult.trx
		move %1TestResult.html %3\%1TestResult.html
	)
)
EXIT /b

REM When no parameter is passed
:InputError
ECHO[
ECHO You have not specified any command. Please see the Help for more information.

CECHO ExecuteTest.bat TestType Mode
ECHO TestType:
ECHO		ProductionDefect
ECHO		HEDCore
ECHO		NovaNet
ECHO		DigitalPath
ECHO Mode (optional):
ECHO		User
ECHO		Silent
ECHO[
pause;
@ECHO ON
EXIT /b

REM Script used exclusively for Jenkins BVT Execution
:BVTSCRIPT
ECHO Executing BVT Script
SET MSTestExe="%VS100COMNTOOLS%\..\IDE\mstest.exe"
SET SpecFlowExe="v2\packages\SpecFlow.1.9.0\tools\specflow.exe"
IF NOT EXIST "%WORKSPACE%\RawReports\" (
	ECHO Creating RawReports Directory
	mkdir "%WORKSPACE%\RawReports\"
)
REM mkdir %WORKSPACE%\Reports-%BUILD_TAG%\;

ECHO Executing Main BVT Logic

REM NovaNet tests
IF "%BVT_TYPE%"=="NN" (
	ECHO Inside NovaNet BVT
	SET BVT_ORDERED_SUITE=v2/Pegasus.NovaNET.Tests/OrderedTest/OrderedTest.NovaNETBVT.orderedtest
	SET ProjectPath=v2/Pegasus.NovaNET.Tests/Pegasus.NovaNET.Tests.csproj
)

REM HED Core tests
IF "%BVT_TYPE%"=="HED" (
	ECHO Inside HEDCore BVT
	SET BVT_ORDERED_SUITE=v2/Pegasus.HigherEducation.Tests/OrderedTest/OrderedTest.HEDMyLanguageLabBVT.orderedtest
	SET ProjectPath=v2/Pegasus.HigherEducation.Tests/Pegasus.HigherEducation.Tests.csproj
)

REM Digitalpath tests
IF "%BVT_TYPE%"=="DP" (
	ECHO Inside DigitalPath BVT
	SET BVT_ORDERED_SUITE=v2/Pegasus.DigitalPath.Tests/OrderedTest/OrderedTest.K12DigitsBVT.orderedtest
	SET ProjectPath=v2/Pegasus.DigitalPath.Tests/Pegasus.DigitalPath.Tests.csproj
)

REM Trial One Test
IF "%BVT_TYPE%"=="CIFTRIAL" (
	ECHO Inside CIF Trial One Test
	SET BVT_ORDERED_SUITE=v2\Pegasus.HigherEducation.Tests\OrderedTest\TestOneScenario.orderedtest
	SET ProjectPath=v2\Pegasus.HigherEducation.Tests\Pegasus.HigherEducation.Tests.csproj
)

REM Production defect tests
IF "%BVT_TYPE%"=="PD" (
	ECHO Inside Production Defects Execution
	ECHO Production Defects Execution not supported
	EXIT 2
	REM %MSTestExe% /testmetadata:V1/STTestList.vsmdi /testlist:ProductionDefectList /resultsfile:%1TestResult.trx
	REM SET ProjectPath=v1/Pegasus.ProductionDefect.TestScripts/Pegasus.TestScripts.ProductionDefects.csproj
)

ECHO MSTestExe:: %MSTestExe%
ECHO SpecFlowExe:: %SpecFlowExe%
ECHO BVT_TRIAL:: %BVT_TYPE%
ECHO BVT_ORDERED_SUITE:: %BVT_ORDERED_SUITE%
ECHO ProjectPath:: %ProjectPath%

ECHO %MSTestExe% /testcontainer:%WORKSPACE%\src\%BVT_ORDERED_SUITE% /resultsfile:%WORKSPACE%\RawReports\TestResult-%BUILD_TAG%.trx
SET ProjectPath="%WORKSPACE%\src\%ProjectPath%"
ECHO %ProjectPath%
ECHO %WORKSPACE%\src\%SpecFlowExe% mstestexecutionreport %ProjectPath% /testResult:%WORKSPACE%\RawReports\TestResult-%BUILD_TAG%.trx /out:%WORKSPACE%\RawReports\TestResult-%BUILD_TAG%.html
REM copy /Y %WORKSPACE%\RawReports-%BUILD_NUMBER%\*.html Reports\;
REM copy /Y %WORKSPACE%\RawReports-%BUILD_NUMBER%\*.trx Reports\;