using Framework.CommonBaseTestScript.BaseTestScript;
using TechTalk.SpecFlow;
namespace PegasusTestScripts
{
    [Binding]
    public class BaseTestScript : CommonBaseTestScript
    {
        [BeforeTestRun]
        // Purpose: To Initialize TestScript
        public new static void TestInitialize()
        {
            CommonBaseTestScript.TestInitialize();
        }

        [AfterTestRun]
       // Purpose: To Dispose TestScript
        public new static void TearDown()
        {
            CommonBaseTestScript.TearDown();
        }
    }
}