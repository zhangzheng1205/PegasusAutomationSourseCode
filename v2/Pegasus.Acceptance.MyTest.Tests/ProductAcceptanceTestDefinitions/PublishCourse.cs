using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MyTest.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class contains the details  for Publish Course.
    /// in workspace.
    /// </summary>
    [Binding]
    public class PublishCourse : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(PublishCourse));

        /// <summary>
        /// Publish Master Course In WorkSpace. 
        /// </summary>
        /// <param name="courseTypeEnum">This course type enum.</param>
        /// <param name="cmenuOptionName">This is course cmenu option name.</param>
        [When(@"I publish the Authored ""(.*)"" in workspace as ""(.*)""")]
        public void PublishAuthoredMasterCourseInWorkSpace
            (Course.CourseTypeEnum courseTypeEnum,
            String cmenuOptionName)
        {
            //Method To Publish Course
            Logger.LogMethodEntry("PublishCourse", "PublishAuthoredMasterCourseInWorkSpace",
                base.isTakeScreenShotDuringEntryExit);
            //Click On Course Cmenu Option
            new ManageCoursesPage().ClickCourseCMenuOption
                    (PublishCourseResource.
                    PublishCourse_PublishAsMasterCourse_Keyword + cmenuOptionName);
            //Course Published Successfully
            new PublishingNotesPage().PublishCourseInWorkSpace(courseTypeEnum);
            Logger.LogMethodExit("PublishCourse", "PublishAuthoredMasterCourseInWorkSpace",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
