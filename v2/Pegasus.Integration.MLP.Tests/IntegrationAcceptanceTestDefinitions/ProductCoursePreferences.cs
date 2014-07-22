using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;
using Pegasus.Integration.Hed.MLP.Tests.IntegrationAcceptanceTestDefinitions;

namespace Pegasus.Integration.MLP.Tests.
    IntegrationAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles product course preferences actions.
    /// </summary>
    [Binding]
    public class ProductCoursePreferences : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(ProductCoursePreferences));

        /// <summary>
        /// Select The Course Option From The CMenu.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        /// <param name="contextualMenuOptionName">This is course cmenu option name.</param>
        [When(@"I select the """"(.*)"" course ""(.*)"" option from the cMenu")]
        public void SelectTheCourseOptionFromTheCMenu(
            Course.CourseTypeEnum courseTypeEnum,
            String contextualMenuOptionName)
        {
            Logger.LogMethodEntry("ProductCoursePreferences",
               "SelectTheCourseOptionFromTheCMenu",
           base.isTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Select Course Contextual Option
            new ProductCoursesPage().SelectProductCourseContextualMenuOption
                (course.Name, contextualMenuOptionName);
            Logger.LogMethodExit("ProductCoursePreferences",
              "SelectTheCourseOptionFromTheCMenu",
          base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate ECollege Tpi Integration Point Id.
        /// </summary>
        [Then(@"I should see the eCollege TPI integration point Id")]
        public void ValidateECollegeTpiIntegrationPointId()
        {
            //Verify ECollege Integration Point Id
            Logger.LogMethodEntry("ProductCoursePreferences",
                "ValidateECollegeTpiIntegrationPointId",
            base.isTakeScreenShotDuringEntryExit);
            //Created Page Object
            CourseEnrollmentModePage courseEnrollmentModePage = 
                new CourseEnrollmentModePage();
            //Assert on ECollege Integration Point Id
            Logger.LogAssertion("VerifyECollegeIntegrationPointId", ScenarioContext.
                 Current.ScenarioInfo.Title, () => Assert.IsTrue(courseEnrollmentModePage.
                     GetECollegeTpiIntegrationPointId().Contains(ProductCoursePreferencesResource.
                     ProductCoursePreferences_Page_IntegrationPointID_Value)));
            //Click Cancel Button To Close Window
            courseEnrollmentModePage.ClickCancelButton();
            Logger.LogMethodExit("ProductCoursePreferences",
              "ValidateECollegeTpiIntegrationPointId",
          base.isTakeScreenShotDuringEntryExit);
        }
    }
}
