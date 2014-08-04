#region

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool.Presentation;
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
                base.IsTakeScreenShotDuringEntryExit);           
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
                base.IsTakeScreenShotDuringEntryExit);            
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
                base.IsTakeScreenShotDuringEntryExit);
            //Assert Display of Success Message
            Logger.LogAssertion("VerifySuccessfullMessage",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(successMessage, new ContentLibraryPage().GetSuccessMessage()));
            Logger.LogMethodExit("CustomizeContent", "VerifySuccessfullMessageInCurriculumTab",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On The CustomContent Link.
        /// </summary>
        [When(@"I click on the custom content link")]
        public void ClickOnTheCustomContentLink()
        {
            //Click On The CustomContent Link
            Logger.LogMethodEntry("CustomizeContent", "ClickOnTheCustomContentLink",
               base.IsTakeScreenShotDuringEntryExit);
            //Click on Custom Content Link
            new ContentLibraryPage().ClickOnCustomContentLink();
            Logger.LogMethodExit("CustomizeContent", "ClickOnTheCustomContentLink",
               base.IsTakeScreenShotDuringEntryExit);           
        }

        /// <summary>
        /// Verify ML In CustomContent View.
        /// </summary>
        [Then(@"I should see the ML in the custom content view")]
        public void VerifyMLInCustomContentView()
        {
            //Verify ML In CustomContent View
            Logger.LogMethodEntry("CustomizeContent", "VerifyMLInCustomContentView",
                base.IsTakeScreenShotDuringEntryExit);
            //Get MasterLibrary From Memory
            Course course = Course.Get(Course.CourseTypeEnum.MasterLibrary);
            //Assert ML Name In Custom Content View
            Logger.LogAssertion("VerifyMLNameInCustomContentView",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(course.Name, new CustomContentPage().GetMasterLibraryName()));                                                           
            Logger.LogMethodExit("CustomizeContent", "VerifyMLInCustomContentView",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Click On Expand Button of ML In CustomContent View
            new CustomContentPage().ClickOnExpandButtonofMLInCustomContentView();
            Logger.LogMethodExit("CustomizeContent",
                "ClickOnExpandButtonOfMLInTheCustomContentView",
                base.IsTakeScreenShotDuringEntryExit);
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
                  base.IsTakeScreenShotDuringEntryExit);            
            //Assert Customized Content Name In Custom Content View
            Logger.LogAssertion("VerifyCustomizedContentNameInCustomContentView",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(new CustomContentPage().FetchUpdatedActivityNameFromMemory(),
                    new CustomContentPage().GetCustomizedContentName(activityTypeEnum)));                     
            Logger.LogMethodExit("CustomizeContent", "VerifyCustomizedContentsOfMLInCustomContentView",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Cmenu Of Asset In Table Of Contents.
        /// </summary>
        /// <param name="assetCmenu">This is Asset Cmenu.</param>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [When(@"I select ""(.*)"" cmenu option of ""(.*)"" in table of contents")]
        public void SelectCmenuOfAssetInTableOfContents(string assetCmenu,
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Select Cmenu Of Asset In Table Of Contents
            Logger.LogMethodEntry("CustomizeContent", "SelectCmenuOfAssetInTableOfContents",
                  base.IsTakeScreenShotDuringEntryExit);
            //Get Activity Name From Memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Search Activity
            new ContentLibraryPage().SearchActivity(activity.Name);
            //Select Asset Cmenu In Table of Content
            new ContentLibraryPage().SelectAssetCmenuInTableofContent(activity.Name, assetCmenu);
            Logger.LogMethodExit("CustomizeContent", "SelectCmenuOfAssetInTableOfContents",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set The Due Date For The Activity In Curriculum.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [When(@"I set the due date for the ""(.*)"" activity in curriculum")]
        public void SetTheDueDateForTheActivityInCurriculum(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Select Cmenu Of Asset In Table Of Contents
            Logger.LogMethodEntry("CustomizeContent",
                "SetTheDueDateForTheActivityInCurriculum",
                  base.IsTakeScreenShotDuringEntryExit);
            //Get Activity Name From Memory
            Activity activity = Activity.Get(activityTypeEnum);
            // fetch class name 
            Class orgClass = Class.Get(Class.ClassTypeEnum.DigitalPathMasterLibrary);
            //Set Due Date For Activity In Curriculum
            new ContentLibraryPage().SetDueDateForActivityInCurriculum(orgClass.Name);
            Logger.LogMethodExit("CustomizeContent",
                "SetTheDueDateForTheActivityInCurriculum",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Download Option In Print Window.
        /// </summary>
        /// <param name="downloadOption">This is Download Option.</param>
       [Then(@"I should see the ""(.*)"" option in print window")]
        public void VerifyTheDownloadOptionInPrintWindow(string downloadOption)
        {
            //Verify The Download Option In Print Window
            Logger.LogMethodEntry("CustomizeContent",
                "VerifyTheDownloadOptionInPrintWindow",
                  base.IsTakeScreenShotDuringEntryExit);
            //Assert Download Option In Print Window
            Logger.LogAssertion("VerifyTheDownloadOptionInPrintWindow",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new PrintToolPage().IsDownloadOptionPresent())); 
            Logger.LogMethodExit("CustomizeContent",
                "VerifyTheDownloadOptionInPrintWindow",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
       /// Verify The Button In Test Page.
        /// </summary>
        /// <param name="buttonName">This is Button Name.</param>
       [Then(@"I should see the ""(.*)"" button in 'Test' page")]
       public void VerifyTheButtonInTestPage(string buttonName)
       {
           //Verify The Download Option In Print Window
           Logger.LogMethodEntry("CustomizeContent",
               "VerifyTheDownloadOptionInPrintWindow",
                 base.IsTakeScreenShotDuringEntryExit);
           //Assert Download Option In Print Window
           Logger.LogAssertion("VerifyTheDownloadOptionInPrintWindow",
               ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreEqual(buttonName, new InstructionsPage().GetButtonText()));
           Logger.LogMethodExit("CustomizeContent",
               "VerifyTheDownloadOptionInPrintWindow",
                 base.IsTakeScreenShotDuringEntryExit);
       }

        
    }
}
