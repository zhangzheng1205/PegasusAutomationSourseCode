using System;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.HomePage;
using System.Diagnostics;
using System.Configuration;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.PegasusTest;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles MyTest Page Actions.
    /// </summary>
   public class MyTestUXPage:BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(HEDGlobalHomePage));

        /// <summary>
        /// Click on UpgradeToText Inside Course on Main Tab.
        /// </summary>
        public void ClickOnUpgradeToTextInsideCourse()
        {
            //Logger Entry
            Logger.LogMethodEntry("MyTestUXPage",
              "ClickOnUpgradeToTextInsideCourse",base.IsTakeScreenShotDuringEntryExit);
            //wait for element 
            base.WaitForElement(By.ClassName(MyTestUXPageResource.
                MyTestPage_UpgradeTo_ClassID_Locator));
            //focus on element
            base.FocusOnElementByClassName(MyTestUXPageResource.
                MyTestPage_UpgradeTo_ClassID_Locator);
            //Get HTML peroperty of element
            IWebElement getPropertyOfUpgradeToLink = base.
                GetWebElementPropertiesByClassName(MyTestUXPageResource.
                MyTestPage_UpgradeTo_ClassID_Locator);
            //Click on UpgradeTo Link
            base.ClickByJavaScriptExecutor(getPropertyOfUpgradeToLink);
            //Logger Exit
            Logger.LogMethodExit("MyTestUXPage",
              "ClickOnUpgradeToTextInsideCourse", base.IsTakeScreenShotDuringEntryExit);
        }

       /// <summary>
        /// Click The OK Button In UpgrdePage.
       /// </summary>
       public void ClickTheOkButtonInUpgradePage()
       {
         //Click The OK Button In UpgrdePage
         Logger.LogMethodEntry("MyTestUXPage",
              "ClickTheOkButtonInUpgradePage", base.IsTakeScreenShotDuringEntryExit);
         try
         {
             //Select the window
             this.SelectUpgradeWindow();
             //Wait for the element
             base.WaitForElement(By.Id(MyTestUXPageResource.
                 MyTestPage_Upgrade_OK_Button_Id_Locator));
             IWebElement getOkButtonProperty = base.GetWebElementPropertiesById
                 (MyTestUXPageResource.
                 MyTestPage_Upgrade_OK_Button_Id_Locator);
             //Click on 'OK' button
             base.ClickByJavaScriptExecutor(getOkButtonProperty);
             //Store The Upgraded MyTest Course
             this.StoreTheUpgradedMyTestCourse();
         }
         catch (Exception e)
         {
             ExceptionHandler.HandleException(e);
         }
         Logger.LogMethodExit("MyTestUXPage",
              "ClickTheOkButtonInUpgradePage", base.IsTakeScreenShotDuringEntryExit);
        }

       /// <summary>
       /// Select Upgrade Window.
       /// </summary>
       private void SelectUpgradeWindow()
       {
           //Select Upgrade Window
           Logger.LogMethodEntry("MyTestUXPage",
                "SelectUpgradeWindow", base.IsTakeScreenShotDuringEntryExit);
           //Select the window
           base.WaitUntilWindowLoads(MyTestUXPageResource.
               MyTestPage_Upgrade_Window_Name);
           base.SelectWindow(MyTestUXPageResource.
               MyTestPage_Upgrade_Window_Name);
           Logger.LogMethodExit("MyTestUXPage",
             "SelectUpgradeWindow", base.IsTakeScreenShotDuringEntryExit);
       }

       /// <summary>
       /// Store The Upgraded MyTest Course.
       /// </summary>
       private void StoreTheUpgradedMyTestCourse()
       {
           //Store The Upgraded MyTest Course
           Logger.LogMethodEntry("MyTestUXPage","StoreTheUpgradedMyTestCourse", 
               base.IsTakeScreenShotDuringEntryExit);
           //Fetch the data from memory
           Course course = Course.Get(Course.CourseTypeEnum.MyTestBankCourse);
           Course newCourse = new Course
           {
               Name = (MyTestUXPageResource.
               MyTestPage_Upgrade_MyTestCourse_Name + course.Name).ToString(),
               CourseType = Course.CourseTypeEnum.MyTestInstructorCourse,
               IsCreated = true,
           };
           newCourse.StoreCourseInMemory();
           Logger.LogMethodExit("MyTestUXPage","StoreTheUpgradedMyTestCourse", 
               base.IsTakeScreenShotDuringEntryExit);
       }
    }
}
