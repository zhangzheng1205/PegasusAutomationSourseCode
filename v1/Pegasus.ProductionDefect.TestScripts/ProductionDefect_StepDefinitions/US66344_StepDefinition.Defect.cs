using System;
using Framework.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Library;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Calendar;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.ProgramAdmin.CourseTemplates;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.TodaysView;
using TechTalk.SpecFlow;


namespace Pegasus.ProductionDefect.TestScripts.ProductionDefect_StepDefinitions
{
    [Binding]
    public class US66344_StepDefinition : BaseTestScript
    {
        // Purpose: Calling Methods From Page Class
        readonly DrtDefaultUxPage _editStudy = new DrtDefaultUxPage();
        readonly ManageTemplatePage _manageTemplateHed = new ManageTemplatePage();
        readonly TodaysViewPage todaysView = new TodaysViewPage();

        /// <summary>
        /// This method is for assignming the study plan from assignment properties.
        /// </summary>
        [Then("I assign the study plan from assignment properties")]
        public void ThenIAssignTheStudyPlanFromAssignmentProperties()
        {
            try
            {
                _editStudy.OpenAssignementPropertiesOfStudyPlan();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        /// <summary>
        /// This method is for the verification of assignment properties by CSstudent
        /// </summary>
        [When("I verify the assignment properties")]
        public void WhenIverifytheassignmentproperties()
        {
            try
            {
                todaysView.VerifyAssignmentPropertiesByStudent();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

    }
}
