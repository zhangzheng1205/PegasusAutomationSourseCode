using System;
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
    /// This class responsible to handle unenroll event
    /// </summary>
    [Binding]
    public class UnenrollEvent : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(UnenrollEvent));

        /// <summary>
        /// This is the thread time to be needed for pegasus to reflect changes
        /// </summary>
        private readonly int getThreadTime = Convert.ToInt32(ConfigurationManager.
            AppSettings[CreateClassEventResource.CreateClassEvent_ResponseTime]);

        /// <summary>
        /// This function is used for unenrolling the user through Unenroll event
        /// </summary>
        /// <param name="httpStatus">This is the http status.</param>
        /// <param name="eventType">This is event type.</param>
        [Then(@"I should be able to receive the status ""(.*)"" on posting the ""(.*)"" event")]
        public void UnenrollUser(string httpStatus, string eventType)
        {
            //Check rest post call status
            logger.LogMethodEntry("UnenrollEvent", "UnenrollUser",
                base.isTakeScreenShotDuringEntryExit);
            //This is Organization Rumba ID
            Organization organizationID = Organization.Get(Organization.
                OrganizationLevelEnum.PowerSchool, Organization.OrganizationTypeEnum.DigitalPath);
            String getOrganizationID = organizationID.RumbaOrgID;
            // This is Rumba User ID
            User userID = User.Get(User.UserTypeEnum.RumbaTeacher);
            String getTeacherID = userID.RumbaOwnerID;
            //This is Rumba Student ID
            User userStudentID = User.Get(User.UserTypeEnum.RumbaStudent);
            String getStudentID = userStudentID.RumbaOwnerID;
            // This is Rumba Product ID
            License productID = License.Get(License.LicenseTypeEnum.Rumba);
            int getProductID = productID.ProductID;
            // This is the class ID and class name
            Class domainClass = Class.Get(Class.ClassTypeEnum.DigitalPathContineoMasterLibrary);
            // Fetch class name
            String getClassName = domainClass.Name;
            //Get Class Id
            String getClassID = domainClass.RumbaSectionID;
            // Process User details
            logger.LogAssertion("VerifyUnenrollEvent",
             ScenarioContext.Current.ScenarioInfo.Title,
             () => Assert.AreEqual(httpStatus
                , new PostRestServicePage().ProcessRequest
                ((PostRestServicePage.EventEnum)Enum.Parse
                (typeof(PostRestServicePage.EventEnum), eventType)
                , getClassID, getClassName, getOrganizationID, getTeacherID,
                getStudentID, getProductID.ToString())));
            // Wait for 10 minutes to get the data on pegasus UI
            Thread.Sleep(TimeSpan.FromMinutes(getThreadTime));
            logger.LogMethodExit("UnenrollEvent", "UnenrollUser",
                base.isTakeScreenShotDuringEntryExit);
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

