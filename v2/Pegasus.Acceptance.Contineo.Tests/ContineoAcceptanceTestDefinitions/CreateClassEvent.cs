using System;
using System.Configuration;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Acceptance.Contineo.Tests.CommonContineoAcceptanceTestDefinitions;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.Contineo.Tests.
    ContineoAcceptanceTestDefinitions
{
    /// <summary>
    /// This class is responisble for handling create class event
    /// </summary>
    [Binding]
    public class CreateClassEvent : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger = 
            Logger.GetInstance(typeof(CreateClassEvent));

        /// <summary>
        /// This is the thread time to be needed for pegasus to reflect changes
        /// </summary>
        private readonly int getThreadTime = Convert.ToInt32(ConfigurationManager.
            AppSettings[CreateClassEventResource.CreateClassEvent_ResponseTime]);


        /// <summary>
        /// This function is used for posting the rest service to initiate create class event.
        /// </summary>
        /// <param name="responseStatus">This is the http status.</param>
        /// <param name="eventType">This is request event type,</param>
        [Then(@"I should be able to receive the status ""(.*)"" on posting the ""(.*)"" class event and acknowledge CMS call messages through its REST endpoints")]
        public void CreateClass(String responseStatus, String eventType)
        {
            //Check rest post call status
            Logger.LogMethodEntry("CreateClassEvent", "CreateClass",
                base.isTakeScreenShotDuringEntryExit);
            //This is Organization Rumba ID
            Organization organizationID = Organization.Get(Organization.
                OrganizationLevelEnum.PowerSchool, Organization.OrganizationTypeEnum.DigitalPath);
            string getOrganizationID = organizationID.RumbaOrgID;
            // This is Rumba User ID
            User userID = User.Get(User.UserTypeEnum.RumbaTeacher);
            string getTeacherID = userID.RumbaOwnerID;
            // This is Rumba Student ID
            User userStudentID = User.Get(User.UserTypeEnum.RumbaStudent);
            string getStudentID = userStudentID.RumbaOwnerID;
            // This is Rumba Product ID
            License productID = License.Get(License.LicenseTypeEnum.Rumba);
            int getProductID = productID.ProductID;
            // This is the class ID and class name
            Class rumbaClass = Class.Get(Class.ClassTypeEnum.DigitalPathContineoMasterLibrary);
            string getClassID = rumbaClass.RumbaSectionID;
            string getClassName = rumbaClass.Name;
            // Check create class status
            Logger.LogAssertion("CheckCreateClassStatus",
             ScenarioContext.Current.ScenarioInfo.Title,
             () => Assert.AreEqual(responseStatus
                , new PostRestServicePage().ProcessRequest
                ((PostRestServicePage.EventEnum)Enum.Parse
                (typeof(PostRestServicePage.EventEnum), eventType)
                , getClassID, getClassName, getOrganizationID, getTeacherID,
                getStudentID, getProductID.ToString())));
            // Wait for 10 minutes to get the data on pegasus UI
            Thread.Sleep(TimeSpan.FromMinutes(getThreadTime));
            Logger.LogMethodExit("CreateClassEvent", "CreateClass",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To have the required parameters that will be posted on rest client
        /// </summary>
        [Given(@"I send the raw CMS message data from the CAT reaches to PSN")]
        public void SendRawCMSMessageToPSN()
        {
            // Verify the required parameters
            Logger.LogMethodEntry("CreateClassEvent", "SendRawCMSMessageToPSN",
             base.isTakeScreenShotDuringEntryExit);
            // Store section id with its class name
            new PostRestServicePage().StoreSectionIDWithClassName();
            Logger.LogMethodExit("CreateClassEvent", "SendRawCMSMessageToPSN",
           base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Save the required parameters
        /// </summary>
        [Then("I should be able to save the required parameters")]
        public void SaveRequiredParametersInMemory()
        {

        }

        /// <summary>
        /// Initialize Pegasus test before test execution starts
        /// </summary>
        [BeforeScenario()]
        public static void Setup()
        {
            new CommonSteps().ResetWebdriver();
        }

        /// <summary>
        /// Deinitialize Pegasus test after the execution of test
        /// and clean the WebDriver Instance.
        /// </summary>
        [AfterScenario()]
        public static void TearDown()
        {
            new CommonSteps().WebDriverCleanUp();
        }
    }
}
