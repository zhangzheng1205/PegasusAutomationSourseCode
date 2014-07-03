using System;
using System.Globalization;
using TechTalk.SpecFlow;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pegasus.Pages.UI_Pages;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using System.Configuration;
using System.Threading;

namespace Pegasus.Acceptance.DigitalPath.Tests.Definitions
{
    /// <summary>
    /// This class responsible to call the scedular services.
    /// </summary>
    [Binding]
    public class SchedularService : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(SchedularService));

        /// <summary>
        /// This is the thread time to be needed for pegasus to reflect changes
        /// </summary>
        private readonly int ThreadTime = Convert.ToInt32(ConfigurationManager.
            AppSettings[CreateClassEventResource.CreateClassEvent_ResponseTime]);

        /// <summary>
        /// This function is used for posting the rest service to 
        /// initiate Schedular Service.
        /// </summary>
        /// <param name="httpStatus">This is the http status.</param>
        /// <param name="eventType">This is event type.</param>
        [Then(@"I should be able to receive the status ""(.*)"" on posting the ""(.*)"" event and acknowledge CMS call messages through its REST endpoints")]
        public void ProcessUserDetails(String httpStatus, String eventType)
        {
            //Check rest post call status
            logger.LogMethodEntry("SchedularService", "ProcessUserDetails",
                base.isTakeScreenShotDuringEntryExit);
            //This is Organization Rumba ID
            Organization organizationID = Organization.Get(Organization.
                OrganizationLevelEnum.PowerSchool, Organization.OrganizationTypeEnum.DigitalPath);
            String getOrganizationID = organizationID.RumbaOrgID;
            // This is Rumba User ID
            User userID = User.Get(User.UserTypeEnum.RumbaNonPSNTeacher);
            String getTeacherID = userID.RumbaOwnerID;
            //This is Rumba Student ID
            User userStudentID = User.Get(User.UserTypeEnum.RumbaStudent);
            String getStudentID = userStudentID.RumbaOwnerID;
            // This is Rumba Product ID
            License productID = License.Get(License.LicenseTypeEnum.Rumba);
            int getProductID = productID.ProductID;
            // Update class guid
            Guid updatedClass = Guid.NewGuid();
            // This is the class ID and class name
            Class rumbaUpdatedClass = Class.Get(
                Class.ClassTypeEnum.DigitalPathContineoMasterLibrary);
            rumbaUpdatedClass.Name = updatedClass.ToString();
            //Get Class Id
            String getClassID = rumbaUpdatedClass.RumbaSectionID;
            // Process User details
            logger.LogAssertion("VerifySchedularServiceStatus",
             ScenarioContext.Current.ScenarioInfo.Title,
             () => Assert.AreEqual(httpStatus
                , new PostRestServicePage().ProcessRequest
                ((PostRestServicePage.EventEnum)Enum.Parse
                (typeof(PostRestServicePage.EventEnum), eventType)
                , getClassID, rumbaUpdatedClass.Name, getOrganizationID, getTeacherID,
                getStudentID, getProductID.ToString(CultureInfo.InvariantCulture))));
            // Wait for 10 minutes to get the data on pegasus UI
            Thread.Sleep(TimeSpan.FromMinutes(10));
            logger.LogMethodExit("SchedularService", "ProcessUserDetails",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To have the required parameters that 
        /// will be posted on rest client.
        /// </summary>
        [Given("I am on PSN plus")]
        public void VerifyRequiredParameters()
        {
            //TODO: implement act (action) logic

            // ScenarioContext.Current.Pending();
        }

        /// <summary>
        /// Initialize Pegasus test before test execution starts.
        /// </summary>
        [BeforeTestRun]
        public static void Setup()
        {

        }

        /// <summary>
        /// Deinitialize Pegasus test after the execution of test.
        /// </summary>
        [AfterTestRun]
        public static void TearDown()
        {

        }
    }
}

