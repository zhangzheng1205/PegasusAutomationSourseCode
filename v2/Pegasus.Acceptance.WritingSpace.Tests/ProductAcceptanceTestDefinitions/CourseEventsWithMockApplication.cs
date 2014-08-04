using System;
using System.Configuration;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.WritingSpace.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class is responisble for handling Course Events for Mock Application.
    /// </summary>
    [Binding]
    public class CourseEventsWithMockApplication:PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the Course.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(CourseEventsWithMockApplication));

        /// <summary>
        ///Get External CourseID URL.
        /// </summary>
        String getExternalCourseIDUrl = ConfigurationManager.
            AppSettings["GetExternalCourseIDURLRoot"];

        /// <summary>
        ///Get Writing space Item Mock URL.
        /// </summary>
        String getWritingspaceItemUrl = ConfigurationManager.
            AppSettings["GetWritingSpaceItemMockURLRoot"];

        /// <summary>
        ///Get External CourseID URL.
        /// </summary>
        String getWritingSpaceMockApplicationUrl = ConfigurationManager.
            AppSettings["GetWritingSpaceAssessmentMockURLRoot"];

        /// <summary>
        /// Browse The Mock Application External CourseID URL.
        /// </summary>
        [Given(@"I browse the ExternalCourseID URL WritingSpaceMock Application")]
        public void BrowseTheMockApplicationToGetExternalCourseIDURL()
        {
            //Browse The Mock Application External CourseID URL.
            Logger.LogMethodEntry("CourseEventsWithMockApplication",
                "BrowseTheMockApplicationExternalCourseIDURL",
             base.IsTakeScreenShotDuringEntryExit);
            //  Browse The Mock Application External CourseID URL
            new PostRestServicePage().BrowseTheWritingSpceMockApplicationURL
                (getExternalCourseIDUrl);
            Logger.LogMethodExit("CourseEventsWithMockApplication",
                "BrowseTheMockApplicationExternalCourseIDURL",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Browse The WritingSpace Assessment Mock ApplicationURL.
        /// </summary>
        [Given(@"I browse the WritingSpace Assessment Mock Application URL")]
        public void BrowseTheWritingSpaceAssessmentMockApplicationURL()
        {           
            //Browse The WritingSpace Assessment Mock ApplicationURL
            Logger.LogMethodEntry("CourseEventsWithMockApplication",
                "BrowseTheWritingSpaceAssessmentMockApplicationURL",
             base.IsTakeScreenShotDuringEntryExit);
            //Browse The WritingSpace Assessment Mock ApplicationURL
            new PostRestServicePage().BrowseTheWritingSpceMockApplicationURL
                (getWritingSpaceMockApplicationUrl);
            Logger.LogMethodExit("CourseEventsWithMockApplication",
                "BrowseTheWritingSpaceAssessmentMockApplicationURL",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter The Course Details To Mock Application.
        /// </summary>
        /// <param name="pegasusCourse">This is Course Type Enum.</param>
        [When(@"I enter the ""(.*)"" details to mock application")]
        public void EnterTheCourseDetailsToMockApplication(
            Course.CourseTypeEnum pegasusCourse)
        {
            //Enter The Course Details To Mock Application
            Logger.LogMethodEntry("CourseEventsWithMockApplication",
                "EnterTheCourseDetailsToMockApplication",
             base.IsTakeScreenShotDuringEntryExit);
            //Fetch the courseId
            Course course = Course.Get(pegasusCourse);
            // Enter The Course Details To Mock Application
            new PostRestServicePage().
                EnterTheCourseDetailsInMockApplication(course.PegasusCourseId);
            Logger.LogMethodExit("CourseEventsWithMockApplication",
                "EnterTheCourseDetailsToMockApplication",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The External CourseID.
        /// </summary>
        [Then(@"I should see the External CourseID")]
        public void VerifyTheExternalCourseID()
        {
            //Verify The External CourseID
            Logger.LogMethodEntry("CourseEventsWithMockApplication",
                "VerifyTheExternalCourseID",
             base.IsTakeScreenShotDuringEntryExit);
            //Asserts the External CourseId
            Logger.LogAssertion("VerifyTheExternalCourseID", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreNotEqual(null,
                    new PostRestServicePage().GetExternalCourseID()));
            Logger.LogMethodExit("CourseEventsWithMockApplication",
                "VerifyTheExternalCourseID",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Item URL In Mock Application.
        /// </summary>
        /// <param name="postEventType">This is PostType Enum.</param>
        [When(@"I enter the ""(.*)"" URL in Mock Application")]
        public void EnterItemURLInMockApplication(String postEventType)
        {
            //Enter Item URL In Mock Application
            Logger.LogMethodEntry("CourseEventsWithMockApplication",
                "EnterItemURLInMockApplication",
                base.IsTakeScreenShotDuringEntryExit);
            //Get External Course Id
            Course course = Course.Get(Course.CourseTypeEnum.ExternalCourse);
            //Enter Item URL In Mock Application
            new PostRestServicePage().EnterUrlInMockApplication(
                (PostRestServicePage.PostingTheDataInMockEnum)Enum.Parse
                (typeof(PostRestServicePage.PostingTheDataInMockEnum), postEventType),
                getWritingspaceItemUrl, course.ExternalCourseId,
                CourseEventsWithMockApplicationResource.
                CourseEventsWithMockApplication_Resource_Append_Value);
            Logger.LogMethodExit("CourseEventsWithMockApplication",
                "EnterItemURLInMockApplication",
               base.IsTakeScreenShotDuringEntryExit);            
        }

        /// <summary>
        /// Send The Request To Create The Activity In GBR.
        /// </summary>
        /// <param name="postEventType">This is PostType Enum.</param>
        [When(@"I send the ""(.*)"" request to Mock GBR Application")]
        public void SendTheRequestToCreateTheActivityInGBR(String postEventType)
        {
            //Send The Request To Create The Activity In GBR
            Logger.LogMethodEntry("CourseEventsWithMockApplication",
                "SendTheRequestToCreateTheActivityInGBR",
             base.IsTakeScreenShotDuringEntryExit);
            //Send The Request Details GBR
            new PostRestServicePage().SendTheRequestDetailsToAddActivityInGBR
                ((PostRestServicePage.PostingTheDataInMockEnum)Enum.Parse
                (typeof(PostRestServicePage.PostingTheDataInMockEnum), postEventType));
            Logger.LogMethodExit("CourseEventsWithMockApplication",
                "SendTheRequestToCreateTheActivityInGBR",
           base.IsTakeScreenShotDuringEntryExit);
        }

         /// <summary>
        /// Select Request Type Dropdown Option.
        /// </summary>
        /// <param name="requestType">This is Request Type.</param>
        [When(@"I select the ""(.*)"" request type option")]
        public void SelectRequestTypeDropdownOption(string requestType)
        {
            //Select Request Type Dropdown Option
            Logger.LogMethodEntry("CourseEventsWithMockApplication",
                "SelectRequestTypeDropdownOption",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Request Type Option
            new PostRestServicePage().SelectRequestTypeOption(requestType);
            Logger.LogMethodExit("CourseEventsWithMockApplication",
                "SelectRequestTypeDropdownOption",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Response In MockApplication.
        /// </summary>
        [Then(@"I should see the response in mock assessment application")]
        public void VerifyTheResponseInMockApplication()
        {
            //Verify The Response In MockApplication
            Logger.LogMethodEntry("CourseEventsWithMockApplication",
                "VerifyTheResponseInMockApplication",
             base.IsTakeScreenShotDuringEntryExit);
            //Asserts the response
            Logger.LogAssertion("VerifyTheResponse", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(true,
                    new PostRestServicePage().GetTheResponseFromMockAppication().
                    Contains(CourseEventsWithMockApplicationResource.
                    CourseEventsWithMockApplication_Mock_Response_Text)));
            Logger.LogMethodExit("CourseEventsWithMockApplication",
                "VerifyTheResponseInMockApplication",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Grade Post Response In MockApplication.
        /// </summary>
        [Then(@"I should see the grade post response in mock application")]
        public void VerifyGradePostResponseInMockApplication()
        {
            //Verify Grade Post Response In MockApplication
            Logger.LogMethodEntry("CourseEventsWithMockApplication",
                "VerifyGradePostResponseInMockApplication",
             base.IsTakeScreenShotDuringEntryExit);
            //Asserts the grdae post response
            Logger.LogAssertion("VerifyTheGrdaePostResponse", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(true,
                    new PostRestServicePage().GetTheGradePostResponseFromMockApplication().
                    Contains(CourseEventsWithMockApplicationResource.
                    CourseEventsWithMockApplication_MockGrade_Response_Value)));
            Logger.LogMethodExit("CourseEventsWithMockApplication",
                "VerifyGradePostResponseInMockApplication",
           base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
