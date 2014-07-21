#region

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Integration.MGM.Tests.CommonIntegrationAcceptanceTestDefinitions;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;
using Pegasus.Integration.DigitalPath.Rumba.Tests.CommonIntegrationAcceptanceTestDefinitions;

#endregion

namespace Pegasus.Integration.MGM.Tests.
    IntegrationAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class Handles Customize Content Actions.
    /// </summary>
    [Binding]
    public class CustomizeContent : PegasusBaseTestFixture
    {
        /// <summary>
        /// Static instance of the logger.
        /// </summary>
        private static readonly Logger Logger = 
            Logger.GetInstance(typeof(CustomizeContent));

        /// <summary>
        /// Customize the Content in Curriculum Tab.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [When(@"I customize the content ""(.*)"" in curriculum tab")]
        public void CustomizeContentInCurriculumTab(Activity.
            ActivityTypeEnum activityTypeEnum)
        {
            //Customize the Content in Curriculum Tab
            Logger.LogMethodEntry("CustomizeContent", "CustomizeContentInCurriculumTab",
                base.isTakeScreenShotDuringEntryExit);
            //Get Activity Name From Memory By Activity ID
            Activity activity = Activity.Get(CommonStepsResource.
                CommonSteps_DigitalPath_Activity_Test_UC1);
            //Search Activity
            new ContentLibraryPage().SearchActivity(activity.Name);
            //Click On Activity Customize Content Cmenu
            new ContentLibraryPage().ClickOnActivityCustomizeContentCmenu(activity.Name);
            //Customize the Content
            new MathXLAssessmentPage().CustomizeTheContentInCurriculumTab(activityTypeEnum);
            //Close Customized Item Saved Window
            new CustomizeNotificationPage().CloseCustomizedItemSavedWindow();
            Logger.LogMethodExit("CustomizeContent", "CustomizeContentInCurriculumTab",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Customize the SKill StudyPlan in Curriculum Tab.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [When(@"I customize the StudyPlan ""(.*)"" in curriculum tab")]
        public void CustomizeSkillStudyPlanInCurriculumTab(Activity.
            ActivityTypeEnum activityTypeEnum)
        {
            //Customize the Content in Curriculum Tab
            Logger.LogMethodEntry("CustomizeContent", "CustomizeContentInCurriculumTab",
                base.isTakeScreenShotDuringEntryExit);
            //Get Activity Name From Memory by Activity ID
            Activity activity = Activity.Get(CommonStepsResource.
                CommonSteps_DigitalPath_Activity_SkillStudyPlan_UC1);
            //Search Activity
            new ContentLibraryPage().SearchActivity(activity.Name);
            //Click On Activity Customize Content Cmenu
            new ContentLibraryPage().ClickOnActivityCustomizeContentCmenu(
                activity.Name);
            //Customize the Content
            new MathXLAssessmentPage().CustomizeTheSkillStudyPlanInCurriculumTab(
                activityTypeEnum);
            //Close Customized Item Saved Window
            new CustomizeNotificationPage().CloseCustomizedItemSavedWindow();
            Logger.LogMethodExit("CustomizeContent", "CustomizeContentInCurriculumTab",
                base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Verify Successfull Message In Curriculum Tab.
        /// </summary>
        /// <param name="successMessage">This is Success Message.</param>
        [Then(@"I should see the successfull message ""(.*)"" in Curriculum tab")]
        public void VerifySuccessfullMessageInCurriculumTab(String successMessage)
        {
            //Verify Successfull Message In Curriculum Tab
            Logger.LogMethodEntry("CustomizeContent",
                "VerifySuccessfullMessageInCurriculumTab",
                base.isTakeScreenShotDuringEntryExit);
            //Assert Display of Success Message
            Logger.LogAssertion("VerifySuccessfullMessage",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(successMessage, 
                    new ContentLibraryPage().GetSuccessMessage()));
            Logger.LogMethodExit("CustomizeContent", 
                "VerifySuccessfullMessageInCurriculumTab",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On The CustomContent Link.
        /// </summary>
        [When(@"I click on the custom content link")]
        public void ClickOnTheCustomContentLink()
        {
            //Click On The CustomContent Link
            Logger.LogMethodEntry("CustomizeContent", "ClickOnTheCustomContentLink",
               base.isTakeScreenShotDuringEntryExit);
            //Click on Custom Content Link
            new ContentLibraryPage().ClickOnCustomContentLink();
            Logger.LogMethodExit("CustomizeContent", "ClickOnTheCustomContentLink",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify ML In CustomContent View.
        /// </summary>
        [Then(@"I should see the ML in the custom content view")]
        public void VerifyMLInCustomContentView()
        {
            //Verify ML In CustomContent View
            Logger.LogMethodEntry("CustomizeContent", "VerifyMLInCustomContentView",
                base.isTakeScreenShotDuringEntryExit);
            //Get MasterLibrary From Memory
            Course course = Course.Get(Course.CourseTypeEnum.MasterLibrary);
            //Assert ML Name In Custom Content View
            Logger.LogAssertion("VerifyMLNameInCustomContentView",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(course.Name, new 
                    CustomContentPage().GetMasterLibraryName()));
            Logger.LogMethodExit("CustomizeContent", "VerifyMLInCustomContentView",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Expand Button Of ML In The CustomContent View.
        /// </summary>
        [When(@"I click on the expand button of MasterLibrary in the custom content view")]
        public void ClickOnExpandButtonOfMLInTheCustomContentView()
        {
            //Click On Expand Button Of ML In The CustomContent View
            Logger.LogMethodEntry("CustomizeContent",
                "ClickOnExpandButtonOfMLInTheCustomContentView",
                base.isTakeScreenShotDuringEntryExit);
            //Click On Expand Button of ML In CustomContent View
            new CustomContentPage().ClickOnExpandButtonofMLInCustomContentView();
            Logger.LogMethodExit("CustomizeContent",
                "ClickOnExpandButtonOfMLInTheCustomContentView",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Customized Contents Of ML In Custom Content View.
        /// </summary>
        [Then(@"I should see the customized ""(.*)"" content of the ML in the custom content view")]
        public void VerifyCustomizedContentsOfMLInCustomContentView(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Verify Customized Contents Of ML In Custom Content View
            Logger.LogMethodEntry("CustomizeContent", 
                "VerifyCustomizedContentsOfMLInCustomContentView",
                  base.isTakeScreenShotDuringEntryExit);
            switch (activityTypeEnum)
            {
                case Activity.ActivityTypeEnum.Test:
                    //Get Activity Name From Memory
                    Activity activity = Activity.Get(CommonStepsResource.
                        CommonSteps_DigitalPath_Activity_Test_UC1);
                    //Assert Customized Content Name In Custom Content View
                    Logger.LogAssertion("VerifyCustomizedContentNameInCustomContentView",
                        ScenarioContext.Current.ScenarioInfo.Title,
                        () => Assert.AreEqual(activity.Name, new CustomContentPage().
                            GetCustomizedContentName(activityTypeEnum)));
                    break;
                case Activity.ActivityTypeEnum.SkillStudyPlan:
                    //Get Activity Name From Memory
                    activity = Activity.Get(CommonStepsResource.
                        CommonSteps_DigitalPath_Activity_SkillStudyPlan_UC1);
                    //Assert Customized Content Name In Custom Content View
                    Logger.LogAssertion("VerifyCustomizedContentNameInCustomContentView",
                        ScenarioContext.Current.ScenarioInfo.Title,
                        () => Assert.AreEqual(activity.Name, new CustomContentPage().
                            GetCustomizedContentName(activityTypeEnum)));
                    break;
            }
            Logger.LogMethodExit("CustomizeContent", "VerifyCustomizedContentsOfMLInCustomContentView",
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
