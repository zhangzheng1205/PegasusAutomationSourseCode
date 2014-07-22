using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MMND.
    Tests.ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class Handles MMND integration Page actions.
    /// </summary>
    [Binding]
    public class MMNDIntegration : PegasusBaseTestFixture
    {
        //Getting Cordinate Course Id From Configuration File.
        string getMMNDCoOrdinateId = ConfigurationManager.AppSettings[
            MMNDIntegrationResource.MMNDIntegration_MMNDCoOrdinate_Name];
        //Getting Non Cordinate Course Id From Configuration File.
        string getMMNDNonCoOrdinateId = ConfigurationManager.AppSettings[
            MMNDIntegrationResource.MMNDIntegration_MMNDMMNDNonCoOrdinate_Name];
        //Getting COCO Course Id From Configuration File.
        string getInstructorParameterIdCOCO = ConfigurationManager.AppSettings[
            MMNDIntegrationResource.MMNDIntegration_InstructorParameterIdCOCO_Name];
        //Getting Non COCO Course Id From Configuration File.
        string getInstructorParameterIdNONCOCO = ConfigurationManager.AppSettings[
            MMNDIntegrationResource.MMNDIntegration_InstructorParameterIdNONCOCO_Name];

        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(MMNDIntegration));

        /// <summary>
        /// Select Course Compass Next Generation from Drop Down.
        /// </summary>
        [When(@"I select CCNG from the drop down list")]
        public void SelectCCNGFromTheDropDownList()
        {
            //Select Course Compass Next Generation from Drop Down
            Logger.LogMethodEntry("MMNDIntegration", "SelectCCNGFromTheDropDownList",
              base.isTakeScreenShotDuringEntryExit);
            //Select Course Compass Next Generation from Drop Down            
            new EPContentPage().SelectCourseCompassNextGeneration(
                MMNDIntegrationResource.MMNDIntegration_CourseCompassNextGeneration_Name);
            Logger.LogMethodExit("MMNDIntegration", "SelectCCNGFromTheDropDownList",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Course Tool Settings Option.
        /// </summary>
        [When(@"I select course settings")]
        public void SelectCourseSettings()
        {
            //Select Course Settings Option
            Logger.LogMethodEntry("MMNDIntegration", "SelectCourseSettings",
            base.isTakeScreenShotDuringEntryExit);
            //Click On Course Tool Settings
            new CampusAdminNavPage().ClickOnCourseToolSettings();
            Logger.LogMethodExit("MMNDIntegration", "SelectCourseSettings",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Updated the Integration Point Id.
        /// </summary>
        [When(@"I Update the integration point id for ""(.*)"" course")]
        public void UpdateTheIntegrationPointIdForCourse(
            Course.CourseTypeEnum mmndCourseType)
        {
            //Update the Integration Point Id
            Logger.LogMethodEntry("MMNDIntegration", "UpdateTheIntegrationPointIdForCourse",
             base.isTakeScreenShotDuringEntryExit);
            switch (mmndCourseType)
            {
                case Course.CourseTypeEnum.MMNDCoOrdinate:
                    new CourseToolSettingsViewPage().EnterECollegeCourseId(getMMNDCoOrdinateId);
                    //Click On Tool Associated
                    new CourseToolAssociationViewPage().ClickOnCourseToolAssociated();
                    //Click On Next Button
                    new CourseToolVersionAssociationViewPage().ClickOnNextButton();
                    //Click On Edit Button
                    new CourseToolSettingsUpdateViewPage().ClickOnEditButton();
                    //Insert the Integration Point Id
                    new ManageCourseToolSettingsViewPage().InsertIntegrationPointId(getInstructorParameterIdCOCO);
                    break;
                case Course.CourseTypeEnum.MMNDNonCoOrdinate:
                    new CourseToolSettingsViewPage().EnterECollegeCourseId(getMMNDNonCoOrdinateId);
                    //Click On Tool Associated
                    new CourseToolAssociationViewPage().ClickOnCourseToolAssociated();
                    //Click On Next Button
                    new CourseToolVersionAssociationViewPage().ClickOnNextButton();
                    //Click On Edit Button
                    new CourseToolSettingsUpdateViewPage().ClickOnEditButton();
                    //Insert the Integration Point Id
                    new ManageCourseToolSettingsViewPage().InsertIntegrationPointId(getInstructorParameterIdNONCOCO);
                    break;
            }
            Logger.LogMethodExit("MMNDIntegration", "UpdateTheIntegrationPointIdForCourse",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Successfull Message.
        /// </summary>
        /// <param name="successMessage">This is Successfull Message.</param>
        [Then(@"I should see the successfull message ""(.*)""")]
        public void VerifySuccessfullMessage(string successMessage)
        {
            //Verify Successfull Message
            Logger.LogMethodEntry("MMNDIntegration", "VerifySuccessfullMessage",
              base.isTakeScreenShotDuringEntryExit);
            // Assert Success Message
            Logger.LogAssertion("VerifySuccessMessage", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(successMessage,
                    new CourseToolSettingsUpdateViewPage().GetSuccessfullMessage()));
            Logger.LogMethodExit("MMNDIntegration", "VerifySuccessfullMessage",
               base.isTakeScreenShotDuringEntryExit);
        }
    }
}
