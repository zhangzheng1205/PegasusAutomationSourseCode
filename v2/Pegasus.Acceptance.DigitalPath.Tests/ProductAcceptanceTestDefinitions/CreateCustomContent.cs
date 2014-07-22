#region

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

#endregion

namespace Pegasus.Acceptance.DigitalPath.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles Creation of Assets in Global Custom Content.
    /// </summary>
    [Binding]
    public class CreateCustomContent:PegasusBaseTestFixture 
    {
        /// <summary>
        /// This is the logger
        /// </summary>
        private static readonly Logger Logger = 
            Logger.GetInstance(typeof(CreateCustomContent));

        /// <summary>
        ///Click Custom Content Link.
        /// </summary>
        [When(@"I click The ""(.*)"" link in Home Page")]
        public void ClickCurriculumLink(String customContent)
        {
            //Click Custom Content Link 
            Logger.LogMethodEntry("CreateCustomContent",
                "ClickCurriculumLink",
               base.isTakeScreenShotDuringEntryExit);
            // Click The Curriculum Link In Home Page
            new CustomContentPage().ClickTheCurriculumLinkInHomePage(customContent);
            Logger.LogMethodExit("CreateCustomContent",
                "ClickCurriculumLink",
              base.isTakeScreenShotDuringEntryExit); 
        }

        /// <summary>
        /// Verify The Master Library course.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type by enum.</param>
        [Then(@"I should see the ""(.*)"" course in the custom content view")]
        public void VerifyTheMasterLibraryCourse(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Verify The Master library course 
            Logger.LogMethodEntry("CreateCustomContent",
                "VerifyTheMasterLibraryCourse",
               base.isTakeScreenShotDuringEntryExit);
            //Get Master Library course from memory
             Course course = Course.Get(courseTypeEnum);                                
            //Assert for Master Library Course          
            Logger.LogAssertion("VerifyMaterLibrary",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(course.Name, new CustomContentPage()
                    .GetTheMasterLibraryCourse(course.Name)));
            Logger.LogMethodExit("CreateCustomContent",
                "VerifyTheMasterLibraryCourse",
              base.isTakeScreenShotDuringEntryExit); 
        }
      
        /// <summary>
       /// Mouseover On The Licensed Content.
       /// </summary>
       [When(@"I mouseover on the Licensed content")]
       public void MouseoverOnTheLicensedContent()
       {
           //Mouseover On The Licensed Content
           Logger.LogMethodEntry("CreateCustomContent",
               "MouseoverOnTheLicensedContent",
              base.isTakeScreenShotDuringEntryExit);
           //Mouse over on the Row of Master Library course
           new CustomContentPage().MouseOverOnRowMLCourse();
           Logger.LogMethodExit("CreateCustomContent",
              "MouseoverOnTheLicensedContent",
           base.isTakeScreenShotDuringEntryExit); 
       }

        /// <summary>
        /// Create The Global Content Activity.
       /// </summary>
       /// <param name="assetType">This is Asset Type.</param>
       /// <param name="activityType">This is Activity by type enum.</param>
       [When(@"I create the global ""(.*)"" content ""(.*)"" activity and 'TrueFalse' question in global")]
       public void CreateTheGlobalContentActivity
           (String assetType, Activity.ActivityTypeEnum activityType)
       {
           //Create The Global Content Activity
           Logger.LogMethodEntry("CreateCustomContent",
               "CreateTheGlobalContentActivity",
              base.isTakeScreenShotDuringEntryExit);           
           //Create the Global custom content activity               
           new AddAssessmentPage().CreateGlobalCustomContentActivity
               ((AddAssessmentPage.AssetTypeEnum)Enum.Parse
               (typeof(AddAssessmentPage.AssetTypeEnum),assetType),activityType);
           //Create the Fill in the blank question           
           new TrueFalsePage().CreateFillInTheBlankQuestion();
           Logger.LogMethodExit("CreateCustomContent",
               "CreateTheGlobalContentActivity",
            base.isTakeScreenShotDuringEntryExit); 
       }
        
        /// <summary>
        /// Create The Folder Activity in Global.
        /// </summary>  
        /// <param name="activityTypeEnum">This is Activity Type Enum</param>
        [When(@"I Create the custom content ""(.*)"" activity global")]
        public void CreateTheFolderActivityGlobal(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Create The Folder Activity in Global
            Logger.LogMethodEntry("CreateCustomContent",
                "CreateTheFolderActivityGlobal",
               base.isTakeScreenShotDuringEntryExit);
            //Click The Create Button In Global
            new CustomContentPage().ClickTheCreateButtonInGlobal();
            //Select Assets Type Folder
            new CustomContentPage().SelectAssetsTypeFolder();
            //Cretae the folder
            new AddFolderPage().CreateTheFolder(activityTypeEnum);
            Logger.LogMethodExit("CreateCustomContent",
                "CreateTheFolderActivityGlobal",
           base.isTakeScreenShotDuringEntryExit); 
        }
        
        /// <summary>
        /// Mouse Over On NonLicensed Assets.
        /// </summary>
        [When(@"I mouseOver on the NonLicensed Assets")]
        public void WhenIMouseOverOnNonLicensedAssets()
        {
            //Mouse Over On NonLicensed Assets
            Logger.LogMethodEntry("CreateCustomContent",
                "WhenIMouseOverOnNonLicensedAssets",
              base.isTakeScreenShotDuringEntryExit);
            //Mouse Over On NonLecensed Folder
            new CustomContentPage().MouseOverOnNonLecensedFolder();
            //Select The ContentMenu
            new CustomContentPage().SelectTheContentMenu();
            Logger.LogMethodExit("CreateCustomContent",
                "WhenIMouseOverOnNonLicensedAssets",
           base.isTakeScreenShotDuringEntryExit); 
        }
        
        /// <summary>
        /// Create The NonGradable Activity.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        [When(@"I create the nonGgadable ""(.*)"" activity")]
        public void CreateTheNonGradableActivity(
                         Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Create The NonGradable Activity
            Logger.LogMethodEntry("CreateCustomContent",
                  "CreateTheNonGradableActivity",
                        base.isTakeScreenShotDuringEntryExit);
            //Mouse Over On NonLecensed Folder
            new CustomContentPage().MouseOverOnNonLecensedFolder();
            //Select Link Asset
            new CustomContentPage().SelectLinkAsset();
            //Create Link Asset
            new AddUrlPage().CreateLinkAsset(activityTypeEnum);
            Logger.LogMethodExit("CreateCustomContent",
                "CreateTheNonGradableActivity",
                      base.isTakeScreenShotDuringEntryExit);
        }
    }
}
