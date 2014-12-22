using System;
using System.IO;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.PegasusTest;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles MyTest Page Actions.
    /// </summary>
    public class MyTestUxPage : BasePage
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
              "ClickOnUpgradeToTextInsideCourse", base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodEntry("MyTestUXPage", "StoreTheUpgradedMyTestCourse",
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
            Logger.LogMethodExit("MyTestUXPage", "StoreTheUpgradedMyTestCourse",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on download button.
        /// </summary>
        public void ClickToDownloadButton()
        {
            // click download button
            Logger.LogMethodEntry("MyTestUXPage",
                 "ClickToDownloadButton", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                IWebElement downloadButtonObject = base.GetWebElementPropertiesByCssSelector
                    (MyTestUXPageResource.MyTestPage_Download_Button_CssSelector_Locator);
                // click on button
                base.ClickByJavaScriptExecutor(downloadButtonObject);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("MyTestUXPage",
                 "ClickToDownloadButton", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on download all zip button.
        /// </summary>
        public void ClickToDownloadAllZipButton()
        {
            // click download all button
            Logger.LogMethodEntry("MyTestUXPage",
                 "ClickToDownloadAllZipButton", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // select current window
                this.SelectMyTestWindow();
                base.SwitchToIFrameById(MyTestUXPageResource
                    .MyTestPage_DownloadFile_Lightbox_Id_Locator);
                bool isDownloadAllButtonPresent = base.IsElementPresent
                    (By.Id(MyTestUXPageResource.MyTestPage_DownloadAll_Button_Id_Locator), 20);
                // switch iframe
                if (!isDownloadAllButtonPresent)
                {
                    this.SelectMyTestWindow();
                    base.SwitchToIFrameById(MyTestUXPageResource.MyTestPage_DownloadFile_Lightbox_Id_Locator);
                }
                IWebElement allDownloadButtonObject = base.GetWebElementPropertiesById
                    (MyTestUXPageResource.MyTestPage_DownloadAll_Button_Id_Locator);
                // click on button
                base.ClickByJavaScriptExecutor(allDownloadButtonObject);
                base.SwitchToDefaultPageContent();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("MyTestUXPage",
                 "ClickToDownloadAllZipButton", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select MyTest Window.
        /// </summary>
        private void SelectMyTestWindow()
        {
            Logger.LogMethodEntry("MyTestUXPage", "SelectMyTestWindow",
                base.IsTakeScreenShotDuringEntryExit);
            // select window
            base.WaitUntilWindowLoads(MyTestUXPageResource.MyTestPage_Window_Title_Name);
            base.SelectWindow(MyTestUXPageResource.MyTestPage_Window_Title_Name);
            Logger.LogMethodExit("MyTestUXPage", "SelectMyTestWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Downloaded File Extentions.
        /// </summary>
        /// <returns>Downloaded File Extensions List.</returns>
        public string[] GetFileExtentionsFromDownloadedFolder()
        {
            Logger.LogMethodEntry("MyTestUXPage",
                 "GetFileExtentionsFromDownloadedFolder", base.IsTakeScreenShotDuringEntryExit);
            var downloadedFileExtensions = new[] { string.Empty };
            try
            {
                Thread.Sleep(5000);
                // get files extension
                downloadedFileExtensions = Directory.GetFiles(
                    AutomationConfigurationManager.DownloadFilePath.Replace("file:\\", ""))
                    .Select(p => Path.GetExtension(p)).Distinct().OrderBy(p => p).ToArray();
                // delete files from folder
                Array.ForEach(Directory.GetFiles(AutomationConfigurationManager.DownloadFilePath.Replace("file:\\", "")), File.Delete);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("MyTestUXPage",
                 "GetFileExtentionsFromDownloadedFolder", base.IsTakeScreenShotDuringEntryExit);
            return downloadedFileExtensions;
        }

        /// <summary>
        /// Select Question Order For Download Test.
        /// </summary>
        public void SelectQuestionOrderForDownloadTest(string questionOrderName)
        {
            // select dropdown question order value
            Logger.LogMethodEntry("MyTestUXPage",
                 "SelectQuestionOrderForDownloadTest", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                Thread.Sleep(2000);
                base.SelectDropDownValueThroughTextById(MyTestUXPageResource
                    .MyTestPage_QuestionOrder_DropDown_Id_Locator, questionOrderName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("MyTestUXPage",
                 "SelectQuestionOrderForDownloadTest", base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
