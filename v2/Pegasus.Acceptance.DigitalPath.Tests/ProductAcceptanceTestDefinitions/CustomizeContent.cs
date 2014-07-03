#region

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

#endregion

namespace Pegasus.Acceptance.DigitalPath.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class Handles Customize Content Actions
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
        public void CustomizeContentInCurriculumTab(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Customize the Content in Curriculum Tab
            Logger.LogMethodEntry("CustomizeContent", "CustomizeContentInCurriculumTab",
                base.isTakeScreenShotDuringEntryExit);           
            //Get Activity Name From Memory
             Activity activity = Activity.Get(activityTypeEnum);
            //Search Activity
            new ContentLibraryPage().SearchActivity(activity.Name);
            //Click On Activity Customize Content Cmenu
            new ContentLibraryPage().ClickOnActivityCustomizeContentCmenu(activity.Name);
            //Customize the Content
            new MathXLAssessmentPage().CustomizeTheContentInCurriculumTab(activityTypeEnum);
            //Close Customized Item Saved Window
            new CustomizeNotificationPage().CloseCustomizedItemSavedWindow();                           
            Logger.LogMethodEntry("CustomizeContent", "CustomizeContentInCurriculumTab", 
                base.isTakeScreenShotDuringEntryExit);            
        }

        /// <summary>
        /// Verify Successfull Message In Curriculum Tab.
        /// </summary>
        /// <param name="successMessage">This is Success Message.</param>
        [Then(@"I should see the successfull message ""(.*)"" in Curriculum tab")]
        public void VerifySuccessfullMessageInCurriculumTab(
            String successMessage)
        {
            //Verify Successfull Message In Curriculum Tab
            Logger.LogMethodEntry("CustomizeContent", "VerifySuccessfullMessageInCurriculumTab",
                base.isTakeScreenShotDuringEntryExit);
            //Assert Display of Success Message
            Logger.LogAssertion("VerifySuccessfullMessage",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(successMessage, new ContentLibraryPage().GetSuccessMessage()));
            Logger.LogMethodExit("CustomizeContent", "VerifySuccessfullMessageInCurriculumTab",
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
                () => Assert.AreEqual(course.Name, new CustomContentPage().GetMasterLibraryName()));                                                           
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
        /// <param name="activityTypeEnum">This is activity type enum.</param>
        [Then(@"I should see the customized ""(.*)"" content of the ML in the custom content view")]
        public void VerifyCustomizedContentsOfMLInCustomContentView(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Verify Customized Contents Of ML In Custom Content View
            Logger.LogMethodEntry("CustomizeContent", "VerifyCustomizedContentsOfMLInCustomContentView",
                  base.isTakeScreenShotDuringEntryExit);            
            //Assert Customized Content Name In Custom Content View
            Logger.LogAssertion("VerifyCustomizedContentNameInCustomContentView",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(new CustomContentPage().FetchUpdatedActivityNameFromMemory(),
                    new CustomContentPage().GetCustomizedContentName(activityTypeEnum)));                     
            Logger.LogMethodExit("CustomizeContent", "VerifyCustomizedContentsOfMLInCustomContentView",
                  base.isTakeScreenShotDuringEntryExit);
        }
    }
}
