using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.HomePage;
using TechTalk.SpecFlow;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.OrganizationManagement;
using Pegasus.Pages.UI_Pages;
using Pegasus.Acceptance.DigitalPath.Tests.StepDefinitions;

namespace Pegasus.DigitalPath.Tests.Definitions
{
    /// <summary>
    /// This class handles GradeBook Page actions
    /// </summary>
    [Binding]
    public class GradeBook : PegasusBaseTestFixture
    {

        /// <summary>
        /// The static instance of the logger for the class
        /// </summary>
        private static readonly Logger logger = Logger.GetInstance(typeof(GradeBook));


        /// <summary>
        /// click on create column drop down 
        /// </summary>
        [When(@"I click on the 'Create Column' drop down")]
        public void ClickOnTheCreateColumnDropDown()
        {
            // Open Create Total column pop up window
            logger.LogMethodEntry("GradeBook", "ClickOnTheCreateColumnDropDown",
                base.isTakeScreenShotDuringEntryExit);
            new GBInstructorUXPage().ClickCreateColumnDropDown();
            logger.LogMethodExit("GradeBook", "ClickOnTheCreateColumnDropDown",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select activities from Left Iframe  
        /// </summary>
        /// <param name="activityName1">This is the first activity name</param>
        /// <param name="activityName2">This is the second activity name</param>
        [When(@"I select checkbox of activities ""(.*)"" and ""(.*)""")]
        public void SelectCheckboxOfActivities(string activityName1, string activityName2)
        {
            // Select activities for adding
            logger.LogMethodEntry("GradeBook", "SelectCheckboxOfActivities",
                base.isTakeScreenShotDuringEntryExit);
            //Sending first activity to for loop
            new GBInstructorUXPage().SelectActivityFromLeftFrame(activityName1);
            //Sending second activity to for loop
            new GBInstructorUXPage().SelectActivityFromLeftFrame(activityName2);
            logger.LogMethodExit("GradeBook", "SelectCheckboxOfActivities",
               base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click on Add button to Add selected Activities to right Iframe
        /// </summary>
        [When(@"I should be click the on Add button")]
        public void ClickAddButtonToAddActivities()
        {
            //Click on add button to add activities
            logger.LogMethodEntry("GradeBook", "ClickAddButtonToAddActivities",
                base.isTakeScreenShotDuringEntryExit);
            // Add activities to right frame
            new GBInstructorUXPage().AddActivitiesinRightFrame();
            logger.LogMethodExit("GradeBook", "ClickAddButtonToAddActivities",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Calculate the Total weight by passing numeric values to the text box.
        /// </summary>
        /// <param name="textOption1">This indicates the which text box</param>
        /// <param name="textOption2">This is the numeric value to enter in text box</param>
        [When(@"I have entered ""(.*)"" and ""(.*)"" into weight box")]
        public void EnterValueInWeightBox(string textOption1, string textOption2)
        {
            //Enter integer values in weight box 
            logger.LogMethodEntry("GradeBook", "EnterValueInWeightBox",
                base.isTakeScreenShotDuringEntryExit);
            //Enter value in First text box
            new GBInstructorUXPage().CalculateTotalWeight((GBInstructorUXPage.TextTypeEnum)Enum.
                Parse(typeof(GBInstructorUXPage.TextTypeEnum),                  
                GradeBookResource.GradeBook_Page_First_TextBox_Option), textOption1);
            //Enter value in Second text box
            new GBInstructorUXPage().CalculateTotalWeight((GBInstructorUXPage.TextTypeEnum)Enum.
               Parse(typeof(GBInstructorUXPage.TextTypeEnum),
               GradeBookResource.GradeBook_Page_Second_TextBox_Option), textOption2);
            logger.LogMethodExit("GradeBook", "EnterValueInWeightBox",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Result will be displayed in the Total weight text box 
        /// </summary>
        [Then(@"I should able to see the result in Total Weight Textbox")]
        public void CheckTheResultInTotalWeightTextbox()
        {
            //Check result in TotalWeight Textbox
            logger.LogMethodEntry("GradeBook", "CheckTheResultInTotalWeightTextbox",
                base.isTakeScreenShotDuringEntryExit);
            //Verifying the return value is correct.
            logger.LogAssertion("VerifyResultInTotalWeightTextbox",
                ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreEqual(GradeBookResource.
                   GradeBook_Page_TotalWeight_TextBox_Result_Value,
                   new GBInstructorUXPage().GetRestulInTotalWeightTextBox()));
            logger.LogMethodExit("GradeBook", "CheckTheResultInTotalWeightTextbox",
               base.isTakeScreenShotDuringEntryExit);
        }
    }
}
