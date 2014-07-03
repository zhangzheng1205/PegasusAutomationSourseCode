using Framework.CommonBaseTestScript.BaseTestScript;
using TechTalk.SpecFlow;
namespace Pegasus.ProductionDefect.TestScripts
{
    [Binding]
    public class BaseTestScript : CommonBaseTestScript
    {
        [BeforeScenario]
        // Purpose: To Initialize TestScript
        public new static void TestInitialize()
        {
            CommonBaseTestScript.TestInitialize();
        }

        [AfterScenario]
       // Purpose: To Dispose TestScript
        public new static void TearDown()
        {
            CommonBaseTestScript.TearDown();
        }
    }
}