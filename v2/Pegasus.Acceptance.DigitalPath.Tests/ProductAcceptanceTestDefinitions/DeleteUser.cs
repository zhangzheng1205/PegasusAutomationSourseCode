#region

using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

#endregion

namespace Pegasus.Acceptance.DigitalPath.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class Handles Delete User Actions
    /// </summary>
    [Binding]
    public class DeleteUser : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger = 
            Logger.GetInstance(typeof(DeleteUser));
        
        /// <summary>
        /// Select 'OK' Option.
        /// </summary>
        [When(@"I select 'OK' option")]
        public void ClickOnOkOption()
        {
            //Select Ok Option
            Logger.LogMethodEntry("DeleteUser", "ClickOnOkOption",
              base.isTakeScreenShotDuringEntryExit);
            //Click on Ok Button
            new ShowMessagePage().ClickOnPegasusOkButton();
            Logger.LogMethodExit("DeleteUser", "ClickOnOkOption",
            base.isTakeScreenShotDuringEntryExit);
        }
    }
}
