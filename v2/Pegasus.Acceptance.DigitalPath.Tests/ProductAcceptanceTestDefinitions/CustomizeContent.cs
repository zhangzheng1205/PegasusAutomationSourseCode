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
        /// 
        /// </summary>
        /// <param name="p0"></param>
        [When(@"I click on the expand button of ""(.*)"" in the custom content view")]
        public void ClickExpandButtonInCustomContentView(Course.CourseTypeEnum courseName)
        {
            Logger.LogMethodEntry("GlobalHome", "ClickExpandButtonInCustomContentView", base.IsTakeScreenShotDuringEntryExit);
            Course course = Course.Get(courseName);
            String courseTitle = course.Name.ToString();
            new CustomContentPage().ClickExpandIcon(courseTitle);
            Logger.LogMethodExit("GlobalHome", "ClickExpandButtonInCustomContentView", base.IsTakeScreenShotDuringEntryExit);

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
            new ContentLibraryPage().SelectAssetCmenuInTableOfContent(activity.Name, assetCmenu);
            Logger.LogMethodExit("CustomizeContent", "SelectCmenuOfAssetInTableOfContents",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Cmenu Of Asset In Table Of Contents of Curriculum.
        /// </summary>
        /// <param name="assetCmenu">This is the Asset cmenu option.</param>
        /// <param name="activityName">This is the Activity Name.</param>
        [When(@"I select ""(.*)"" cmenu of ""(.*)"" in table of content")]
        public void SelectCmenuOfInTableOfContent(string assetCmenu, string activityName)
        {
            //Select Cmenu Of Asset In Table Of Contents
            Logger.LogMethodEntry("CustomizeContent", "SelectCmenuOfAssetInTableOfContents",
                  base.IsTakeScreenShotDuringEntryExit);
            //Search Activity
            new ContentLibraryPage().SearchActivity(activityName);
            //Select Asset Cmenu In Table of Content
            new ContentLibraryPage().SelectAssetCmenuInTableOfContent(activityName, assetCmenu);
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
        /// Set The Due Date For The Activity In Curriculum
        /// </summary>
        /// <param name="activityTypeEnum">This is the activity type Enum</param>
        [When(@"I set due date for the ""(.*)"" activity in curriculum for Media Server Class")]
        public void SetDueDateForTheMSActivityInCurriculum(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Select Cmenu Of Asset In Table Of Contents
            Logger.LogMethodEntry("CustomizeContent",
                "SetTheDueDateForTheActivityInCurriculum",
                  base.IsTakeScreenShotDuringEntryExit);
            //Get Activity Name From Memory
            Activity activity = Activity.Get(activityTypeEnum);
            // fetch class name 
            Class orgClass = Class.Get(Class.ClassTypeEnum.MediaServerClass);
            //Set Due Date For Activity In Curriculum
            new ContentLibraryPage().SetDueDateCurrentForActivityInCurriculum(orgClass.Name);
            Logger.LogMethodExit("CustomizeContent",
                "SetTheDueDateForTheActivityInCurriculum",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set The Due Date For The Activity In Curriculum
        /// </summary>
        /// <param name="activityTypeEnum">This is the activity type Enum</param>
        [When(@"I set due date for the ""(.*)"" activity in curriculum for Writing Coach Class")]
        public void SetDueDateForTheWCActivityInCurriculum(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Select Cmenu Of Asset In Table Of Contents
            Logger.LogMethodEntry("CustomizeContent",
                "SetTheDueDateForTheActivityInCurriculum",
                  base.IsTakeScreenShotDuringEntryExit);
            //Get Activity Name From Memory
            Activity activity = Activity.Get(activityTypeEnum);
            // fetch class name 
            Class orgClass = Class.Get(Class.ClassTypeEnum.DigitalPathWCMasterLibrary);
            //Set Due Date For Activity In Curriculum
            new ContentLibraryPage().SetDueDateCurrentForActivityInCurriculum(orgClass.Name.ToString());
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

       /// <summary>
       /// Expand the folder in curriculum tab.
       /// </summary>
       [When(@"I expand the folder ""(.*)"" in Curriculum tab")]
       public void ExpandTheFolder(string folderName)
       {
           //Expand the folder
           Logger.LogMethodEntry("CustomizeContent",
               "ExpandTheFolder",
                 base.IsTakeScreenShotDuringEntryExit);
           //Expand the folder in Curriculum tab
          new ContentLibraryPage().ExpandTheFolderInCurriculumTab(folderName);
           Logger.LogMethodExit("CustomizeContent",
               "ExpandTheFolder",
                 base.IsTakeScreenShotDuringEntryExit);
       }

       /// <summary>
       /// Click on cmenu option of Lesson in Curriculum tab.
       /// </summary>
       /// <param name="cmenuOption">Cmenu option.</param>
       /// <param name="activityName">Activity name.</param>
       [When(@"I select cmenu option ""(.*)"" of ""(.*)"" activity in Curriculum tab")]
       public void SelectCmenuOptionOfLesson(string cmenuOption, string activityName)
       {
           //Select cmenu option of lesson
           Logger.LogMethodEntry("CustomizeContent",
               "SelectCmenuOptionOfLesson",
                 base.IsTakeScreenShotDuringEntryExit);
           new ContentLibraryPage().FindActivityAndClickOnCmenuOption(cmenuOption, activityName);
           Logger.LogMethodExit("CustomizeContent",
              "SelectCmenuOptionOfLesson",
                base.IsTakeScreenShotDuringEntryExit);
       }

     
       /// <summary>
       /// Select class in assign window.
       /// </summary>
       /// <param name="className">Class name.</param>
       [When(@"I select the class ""(.*)""")]
       public void SelectClassInAssignWindow(Class.ClassTypeEnum classTypeEnum)
       {
           //Select cmenu option of lesson
           Logger.LogMethodEntry("CustomizeContent",
               "SelectClassInAssignWindow",
                 base.IsTakeScreenShotDuringEntryExit);
           //Get class name from memory
           Class Class = Class.Get(classTypeEnum);
           string className = Class.Name.ToString();
           new AssignContentPage().SelectClassOnAssignWindow(className);
           Logger.LogMethodExit("CustomizeContent",
              "SelectClassInAssignWindow",
                base.IsTakeScreenShotDuringEntryExit);
       }

        /// <summary>
        /// Enter the system current date and time
        /// </summary>
       [When(@"I select the current date and due date")]
       public void EnterCurrentDateAndTime()
       {
           //Enter current date and time
           Logger.LogMethodEntry("CustomizeContent",
              "EnterCurrentDateAndTime",
                base.IsTakeScreenShotDuringEntryExit);
           new AssignContentPage().EnterCurrentDateAndTime();
           Logger.LogMethodExit("CustomizeContent",
              "EnterCurrentDateAndTime",
                base.IsTakeScreenShotDuringEntryExit);
       }

        /// <summary>
        /// Expand the sub folder in curriculum tab.
        /// </summary>
        /// <param name="subFolderName">Sub folder name.</param>
       [When(@"I expand the sub folder ""(.*)"" in Curriculum tab")]
       public void ExpandSubFolderInCurriculumTab(string subFolderName)
       {
           //Expand the sub folder
           Logger.LogMethodEntry("CustomizeContent",
               "ExpandSubFolderInCurriculumTab",
                 base.IsTakeScreenShotDuringEntryExit);
           //Expand sub folder in curriculum tab
           new ContentLibraryPage().ExpandSubFolder(subFolderName);
           Logger.LogMethodExit("CustomizeContent",
              "ExpandSubFolderInCurriculumTab",
                base.IsTakeScreenShotDuringEntryExit);
       }

        /// <summary>
        /// Click on Save and assign button in assign pop up.
        /// </summary>
       [When(@"I click on Save and Assign button")]
       public void ClikcOnSaveAndAssignButtonInSaveAssignWindow()
       {
           //Click on Save and assign button
           Logger.LogMethodEntry("CustomizeContent",
               "ClikcOnSaveAndAssignButtonInSaveAssignWindow",
                 base.IsTakeScreenShotDuringEntryExit);
           new AssignContentPage().ClickOnSaveAndAssignButton();
           Logger.LogMethodExit("CustomizeContent",
             "ClikcOnSaveAndAssignButtonInSaveAssignWindow",
               base.IsTakeScreenShotDuringEntryExit);
       }

       /// <summary>
       /// Validate the closure of assign pop up.
       /// </summary>
       [Then(@"I should see Assign pop up closed")]
       public void ValidateClosureOfAssignPopUp()
       {
           //Validate the closure of assign pop up
           Logger.LogMethodEntry("CustomizeContent",
               "ValidateClosureOfAssignPopUp",
                 base.IsTakeScreenShotDuringEntryExit);
           Logger.LogAssertion("CustomizeContent", ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.IsTrue(new AssignContentPage().IsAssignWindowClosed()));
           Logger.LogMethodExit("CustomizeContent",
             "ValidateClosureOfAssignPopUp",
               base.IsTakeScreenShotDuringEntryExit);
       }

       /// <summary>
       /// Click on Ok button in Assign pop up.
       /// </summary>
       [When(@"I click on Ok button in Assign pop up")]
       public void ClickOnOkButton()
       {
           //Click on ok button
           Logger.LogMethodEntry("CustomizeContent",
               "ClickOnOkButton",
                 base.IsTakeScreenShotDuringEntryExit);
           new AssignContentPage().ClickOkButtonInAssignWindow();
           Logger.LogMethodExit("CustomizeContent",
             "ClickOnOkButton",
               base.IsTakeScreenShotDuringEntryExit);
       }

        /// <summary>
        /// Validate assigned content in calendar frame.
        /// </summary>
        /// <param name="assignedActivityTitle"></param>
       [Then(@"I should see the assigned content ""(.*)"" in Calendar frame")]
       public void ValidateAssignedContentInCalendarFrame(string assignedActivityTitle)
       {
           //Validate assigned content in calendar frame
           Logger.LogMethodEntry("CustomizeContent",
               "ClickOnOkButton",
                 base.IsTakeScreenShotDuringEntryExit);
           new CalendarDefaultGlobalUXPage().GetAssignedContentTitle(assignedActivityTitle);
           Logger.LogMethodExit("CustomizeContent",
            "ValidateAssignedContentInCalendarFrame",
              base.IsTakeScreenShotDuringEntryExit);
       }

       /// <summary>
       /// Select the period at Assign window .
       /// </summary>
       /// <param name="productTypeEnum">This is product type enum.</param>
       [When(@"I select the ""(.*)"" period")]
       public void SelectThePeriod(Product.ProductTypeEnum productTypeEnum)
       {
           Logger.LogMethodEntry("CustomizeContent",
             "ClickOnOkButton",
               base.IsTakeScreenShotDuringEntryExit);
           //Get the expected period name
           Product product = Product.Get(productTypeEnum);
           string periodName = product.PeriodName.ToString();
           // Select the period at Assign window
           new AssignContentPage().SelectPeriod(periodName);
           Logger.LogMethodExit("CustomizeContent",
       "ValidateAssignedContentInCalendarFrame",
         base.IsTakeScreenShotDuringEntryExit);

       }

        
    }
}
