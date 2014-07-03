using System;
using System.Configuration;
using System.Diagnostics;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.SMSIntegration.ProgramManagement;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles List Courses Page Actions.
    /// </summary>
    public class ListCoursesPage : BasePage
    {
        /// <summary>
        /// This is the logger
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(ListCoursesPage));

        /// <summary>
        /// This is the Broswer variable called from AppSettings.
        /// </summary>
        private int getWaitTimeOut = Convert.ToInt32(
            ConfigurationManager.AppSettings[ListCoursesPageResource.
            ListCourse_Page_ConfigurationManager_AppSettings_Key_Value]);

        /// <summary>
        /// Click on the Cmenu option to initiate approval of course.
        /// </summary>
        /// <param name="cMenuOptionName">This is cmenu option name.</param>
        public void ClickCourseCMenuOption(String cMenuOptionName)
        {
            //Click CMenu option of Course
            Logger.LogMethodEntry("ListCoursesPage", "ClickCourseCMenuOption",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Browser
                switch (base.Browser)
                {
                    // This is for Chrome Browser
                    case PegasusBaseTestFixture.Chrome:
                        //Click Course Cmenu In Chrome
                        this.ClickCourseCmenuInChrome();
                        break;
                    // This is for Internet Explorer Browser
                    case PegasusBaseTestFixture.InternetExplorer:
                        //Click Course Cmenu In Internet Explorer
                        this.ClickCourseCmenuInInternetExplorer();
                        break;
                    // This is for Firefox Browser
                    case PegasusBaseTestFixture.FireFox:
                        //Click Course Cmenu In FireFox
                        this.ClickCourseCmenuInFireFox();
                        break;
                }
                //Display Course CMenu Option
                base.WaitForElement(By.PartialLinkText(cMenuOptionName));
                IWebElement getCmenuOption = base.GetWebElementPropertiesByPartialLinkText
                    (cMenuOptionName);
                //Click on CMenu Option Name
                base.ClickByJavaScriptExecutor(getCmenuOption);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ListCoursesPage", "ClickCourseCMenuOption",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Course Cmenu In FireFox.
        /// </summary>
        private void ClickCourseCmenuInFireFox()
        {
            //Click CMenu Option Name in FireFox Browser
            Logger.LogMethodEntry("ListCoursesPage", "ClickCourseCmenuInFireFox",
                base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(ListCoursesPageResource.
                ListCourse_Page_Course_Grid_Id_Locator));
            base.WaitForElement(By.XPath(ListCoursesPageResource.
                ListCourse_Page_CMenu_Image_XPath_Locator));
            //Enter Empty String in Text Box
            base.FillEmptyText(By.XPath(ListCoursesPageResource.
                ListCourse_Page_CMenu_Image_XPath_Locator));
            //Click on Cmenu
            IWebElement getCourseCmenu = 
                base.GetWebElementPropertiesByXPath(ListCoursesPageResource.
                ListCourse_Page_CMenu_Image_XPath_Locator);
            base.ClickByJavaScriptExecutor(getCourseCmenu);            
            Logger.LogMethodExit("ListCoursesPage", "ClickCourseCmenuInFireFox",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Course Cmenu In Internet Explorer.
        /// </summary>
        private void ClickCourseCmenuInInternetExplorer()
        {
            //Click CMenu Option Name in FireFox Browser
            Logger.LogMethodEntry("ListCoursesPage", "ClickCourseCmenuInInternetExplorer",
                base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(ListCoursesPageResource.
                ListCourse_Page_Course_Grid_Id_Locator));
            base.WaitForElement(By.XPath(ListCoursesPageResource.
                ListCourse_Page_CMenu_Image_XPath_Locator));
            //Send Empty String in Text Box
            base.FillEmptyText(By.XPath(ListCoursesPageResource.
                ListCourse_Page_CMenu_Image_XPath_Locator));
            IWebElement getCmenuImage = base.GetWebElementPropertiesByXPath
                (ListCoursesPageResource.
                ListCourse_Page_CMenu_Image_XPath_Locator);
            //Click on CMenu Option
            base.ClickByJavaScriptExecutor(getCmenuImage);
            Logger.LogMethodExit("ListCoursesPage", "ClickCourseCmenuInInternetExplorer",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Course Cmenu In Chrome.
        /// </summary>
        private void ClickCourseCmenuInChrome()
        {
            //Click CMenu Option Name in Chrome Browser
            Logger.LogMethodEntry("ListCoursesPage", "ClickCourseCmenuInChrome",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.Id(ListCoursesPageResource.
                ListCourse_Page_Course_Grid_Id_Locator));
            //Click on CMenu Option
            base.ClickImageByXPath(ListCoursesPageResource.
                ListCourse_Page_CMenu_Image_XPath_Locator);
            Logger.LogMethodExit("ListCoursesPage", "ClickCourseCmenuInChrome",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Approved Course.
        /// </summary>
        public void SelectApprovedCourse()
        {
            //Select the Approved Course
            Logger.LogMethodEntry("ListCoursesPage", "SelectApprovedCourse",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the Approved Course element
                base.WaitForElement(By.Id(ListCoursesPageResource.
                    ListCourse_Page_CourseGrid_CheckBox_Id_Locator));
                //Get Element Property
                IWebElement getCheckBoxProperty = base.GetWebElementPropertiesById(
                    ListCoursesPageResource.ListCourse_Page_CourseGrid_CheckBox_Id_Locator);
                //Initialized Variable
                bool isCheckBoxSelected;
                //Initiate the Stop Watch
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                //The do statement executes a statement or a block of statements repeatedly 
                //until checkbox get selected and expression evaluates to false.
                do
                {
                    base.ClickByJavaScriptExecutor(getCheckBoxProperty);
                    isCheckBoxSelected = base.IsElementSelectedById(ListCoursesPageResource.
                       ListCourse_Page_CourseGrid_CheckBox_Id_Locator);
                    //If Time expires then get out of the loop, this avoids the loop get in infinite.
                    if (stopWatch.Elapsed.TotalSeconds > getWaitTimeOut) break;
                } while (!isCheckBoxSelected);
                //Stop The Clock
                stopWatch.Stop();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ListCoursesPage", "SelectApprovedCourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Searched Course in COurse Space.
        /// </summary>
        /// <param name="coursTypeEnum">This is Course Type Enum.</param>
        /// <returns>Course Name.</returns>
        public String GetSearchedCourseNameInCourseSpace(
            Course.CourseTypeEnum coursTypeEnum)
        {
            //Get Searched Course in Course Space
            Logger.LogMethodEntry("ListCoursesPage", "GetSearchedCourseNameInCourseSpace",
                base.isTakeScreenShotDuringEntryExit);
            //Initialized Course Name Variable 
            String getcourseName = string.Empty;
            try
            {
                //Wait For Search Results
                base.WaitForElement(By.XPath(ListCoursesPageResource.
                    ListCourse_Page_SearchedCourse_Xpath_Locator));
                switch (coursTypeEnum)
                {
                    case Course.CourseTypeEnum.NovaNETMasterLibrary:
                    case Course.CourseTypeEnum.MasterLibrary:
                        //Get The Course Name
                        getcourseName = base.GetTitleAttributeValueByXPath(
                            ListCoursesPageResource.
                            ListCourse_Page_SearchedCourse_Xpath_Locator);
                        string[] getSplitCourseName = getcourseName.Split(
                            Convert.ToChar(ListCoursesPageResource.
                            ListCourse_Page_ActivityName_SplittingCharacter));
                        getcourseName = getSplitCourseName[
                            Convert.ToInt32(ListCoursesPageResource.
                            ListCourse_Page_Index_Value)].TrimStart();
                        break;
                    case Course.CourseTypeEnum.MySpanishLabMaster:
                    case Course.CourseTypeEnum.MySpanishLabMasterVm:
                    case Course.CourseTypeEnum.MyItLabSIM5MasterCourse: 
                    case Course.CourseTypeEnum.HEDGeneral:
                    case Course.CourseTypeEnum.GraderITSIM5Course:
                        //Get The Course Name
                        getcourseName = base.GetTitleAttributeValueByXPath(
                            ListCoursesPageResource.
                        ListCourse_Page_SearchedCourse_Xpath_Locator);
                        break;
                    case Course.CourseTypeEnum.EmptyClass:
                    case Course.CourseTypeEnum.HedEmptyClass:
                        //Get The Course Name
                        getcourseName = base.GetTitleAttributeValueByXPath(
                            ListCoursesPageResource.
                        ListCourse_Page_SearchedCourse_Xpath_Locator);
                        break;
                    case Course.CourseTypeEnum.Container:
                        //Get The Course Name
                        getcourseName = base.GetTitleAttributeValueByXPath(
                            ListCoursesPageResource.
                        ListCourse_Page_SearchedCourse_Xpath_Locator);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ListCoursesPage", "GetSearchedCourseNameInCourseSpace",
                base.isTakeScreenShotDuringEntryExit);
            return getcourseName;
        }
    }
}
