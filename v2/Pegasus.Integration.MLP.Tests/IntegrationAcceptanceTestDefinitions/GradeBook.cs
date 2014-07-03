﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Integration.MLP.Tests.
    IntegrationAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains the details of GradeBook page 
    /// and handles Pegasus GradeBook Page Actions.
    /// </summary>
    [Binding]
    public class GradeBook : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(GradeBook));

        /// <summary>
        /// View grades in Gradebook.
        /// </summary>
        [Then(@"I should see the grades for submitted activity")]
        public void DisplayGradesForSubmittedActivity()
        {
            //View Grades by Instructor
            Logger.LogMethodEntry("GradeBook",
                "DisplayGradesForSubmittedActivity",
                base.isTakeScreenShotDuringEntryExit);
            //Assert Display Grade's For Submitted Activity
            Logger.LogAssertion("ViewGrades", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                (GradeBookResource.GradeBook_ActivityGrade_Score_Value,
                new GBFoldersPage().GetActivityGrade()));
            Logger.LogMethodExit("GradeBook",
                "DisplayGradesForSubmittedActivity",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Manually Grade the Activity.
        /// </summary>        
        [When(@"I manually grade the activity")]
        public void ManuallyGradeTheActivity()
        {
            //Manually Grade the Activity
            Logger.LogMethodEntry("GradeBook",
                "ManuallyGradeTheActivity",
                base.isTakeScreenShotDuringEntryExit);
            //Naviagte Inside the Folder
            new GBFoldersPage().NavigateInsideParentActivityFolder();
            //Open the Activity For Grading
            new GBInstructorUXPage().OpenActivityForGradingInHED(
                GradeBookResource.GradeBook_ManuallyGrade_Activity_Name);
            //Grade the Activity
            new GBGradeBatchUpdationPage().GradetheActivityInHED();
            Logger.LogMethodExit("GradeBook", "ManuallyGradeTheActivity",
               base.isTakeScreenShotDuringEntryExit);
        }

       /// <summary>
        /// Click On The Content Cmenu Icon.
        /// </summary>
        [When(@"I click on the content cmenu icon")]
        public void ClickOnTheContentCmenuIcon()
        {
            //Click On The Content Cmenu Icon
            Logger.LogMethodEntry("GradeBook",
                "ClickOnTheContentCmenuIcon",
                 base.isTakeScreenShotDuringEntryExit);
            //Click On The Content Cmenu Icon
            new GBInstructorUXPage().ClickOnTheFirstColumnCmenuIcon();
            Logger.LogMethodExit("GradeBook",
                "ClickOnTheContentCmenuIcon",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Display Of Context Menu Option.
        /// </summary>
        /// <param name="contextMenuOption">This is the Context 
        /// Menu Option.</param>
        [Then(@"I should see the ""(.*)"" in the cmenu options")]
        public void DisplayOfContextMenuOption(String contextMenuOption)
        {
            //Verify the Display Of Context Menu Option
            Logger.LogMethodEntry("GradeBook", "DisplayOfContextMenuOption",
                 base.isTakeScreenShotDuringEntryExit);
            //Assert Display Of Context Menu Option
            Logger.LogAssertion("VerifyDisplayOfContextMenuOption",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(contextMenuOption, new GBInstructorUXPage().
                    GetContextMenuOptionDisplayed(contextMenuOption)));
            Logger.LogMethodExit("GradeBook", "DisplayOfContextMenuOption",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable Synchronize with LMS of submitted activity.
        /// </summary>
        [When(@"I click on Synchronize with LMS of submitted activity")]
        public void EnableSynchronizeWithLMSPreference()
        {
            //Enable Synchronize with LMS of submitted activity.
            Logger.LogMethodEntry("GradeBook", "EnableSynchronizeWithLMSPreference",
                  base.isTakeScreenShotDuringEntryExit);
            //Insatance of GBFolder Page
            new GBInstructorUXPage().EnableLMSSynchronizeOption();
            Logger.LogMethodExit("GradeBook", "EnableSynchronizeWithLMSPreference",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This method is called before execution of test.
        /// </summary>
        [BeforeTestRun]
        public static void Setup()
        {

        }

        /// <summary>
        /// This function is called after the execution of test.
        /// </summary>
        [AfterTestRun]
        public static void TearDown()
        {

        }

    }
}
