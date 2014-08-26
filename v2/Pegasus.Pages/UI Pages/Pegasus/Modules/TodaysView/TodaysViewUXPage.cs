using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.TodaysView;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.HomePage;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.TemplateClassManagement.Classes;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class contains the details of Today's View Page.
    /// </summary>
    public class TodaysViewUXPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(TodaysViewUXPage));

        /// <summary>
        /// This is the Tab on the Todays View Page.
        /// </summary>
        public enum TodaysViewTabType
        {
            /// <summary>
            /// Overview Tab
            /// </summary>
            Overview = 1,
            /// <summary>
            /// Practice Tab
            /// </summary>
            Practice = 2,
            /// <summary>
            /// To Do Tab
            /// </summary>
            ToDo = 3
        }

        /// <summary>
        /// This the enum available for global homepage links
        /// </summary>
        public enum GlobalHomePageLinkTypeEnum
        {
            /// <summary>
            /// enum available for global homepage links 'Home'
            /// </summary>
            Home = 1,
            /// <summary>
            /// enum available for global homepage links 'Help'
            /// </summary>
            Help = 2,
            /// <summary>
            /// enum available for global homepage links 'Help' in TA
            /// </summary>
            HelpInTA = 3
        }

        /// <summary>
        /// This the enum available for Resource Tools.
        /// </summary>
        public enum ResourceToolsTypeEnum
        {
            /// <summary>
            /// enum available for resource tool type 'Glossary'
            /// </summary>
            Glossary = 1,
            /// <summary>
            /// enum available for resource tool type 'Tutorials'
            /// </summary>
            VerbChart = 2           
        }

        /// <summary>
        /// Display of New Grades Alert.
        /// </summary>
        /// <returns>New Grades Alert.</returns>
        public String GetNewGradesAlert()
        {
            //Display of New Grades Option
            logger.LogMethodEntry("TodaysViewUXPage", "GetNewGradesAlert",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the window
                base.WaitUntilWindowLoads(TodaysViewUXPageResource
                               .TodaysViewUXPageResource_WindowsTitle);
                base.SelectWindow(TodaysViewUXPageResource
                            .TodaysViewUXPageResource_WindowsTitle);
                //Displpay of New Grades link
                if (!base.IsElementPresent(By.PartialLinkText(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_NewGrades_Link_Text),
                    Convert.ToInt32(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_Custom_WaitTime)))
                {
                    //Enables the New Grades Link in Todays View Page
                    EnableSettingToViewNewGradesAlert();
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "GetNewGradesAlert",
                base.IsTakeScreenShotDuringEntryExit);
            //Returns The alert displayed
            return GetDisplayedAlertValue();
        }

        /// <summary>
        /// Setting to Enable New Grades Link.
        /// </summary>
        private void EnableSettingToViewNewGradesAlert()
        {
            //Enables New Grades Option
            logger.LogMethodEntry("TodaysViewUXPage", "EnableSettingToViewNewGradesAlert",
                                  base.IsTakeScreenShotDuringEntryExit);
            //Click on the Cutomize button
            base.IsElementPresent(By.PartialLinkText(TodaysViewUXPageResource.
                     TodaysViewUXPageResource_Button_CUSTOMIZE_Text));
            //Click on the customize button
            base.ClickButtonByPartialLinkText(TodaysViewUXPageResource.
                     TodaysViewUXPageResource_Button_CUSTOMIZE_Text);
            //Enable the Checkbox for the New Grades in Settings page
            new SettingsPage().EnableNewGradesOption();
            logger.LogMethodExit("TodaysViewUXPage", "EnableSettingToViewNewGradesAlert",
                                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Checks if the Alert is displayed or not
        /// </summary>
        /// <returns>Alert/Notification Displayed</returns>
        public String GetDisplayedAlertValue()
        {
            //Displayes the Alert
            logger.LogMethodEntry("TodaysViewUXPage", "GetDisplayedAlertValue",
                                  base.IsTakeScreenShotDuringEntryExit);
            //Initialize Alert Variable
            string alertValue = string.Empty;
            //Initialize Alert Value Variable
            string newGradesAlert = string.Empty;
            try
            {
                //To Get the Activity Name based on Browser
                switch (base.Browser)
                {
                    case PegasusBaseTestFixture.InternetExplorer:
                        //To get the submitted Activity Name for Internet Explorer
                        newGradesAlert = this.GetActivityNameForInternetExplorer();
                        break;
                    case PegasusBaseTestFixture.FireFox:
                        //To get the submitted Activity Name for Firefox browser
                        newGradesAlert = this.GetActivityNameForFireFox();
                        break;
                }
                //Splitting the text Obtained from New Grades inner text
                string[] newGradeSplit = newGradesAlert.Split(Convert.ToChar(
                    TodaysViewUXPageResource.
                        TodaysViewUXPageResource_SubmittedActivity_Name_SplittingCharacter));
                alertValue = newGradeSplit[0].Substring(Convert.ToInt32(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_NewGrades_Alert_StartIndex));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "GetDisplayedAlertValue",
                                 base.IsTakeScreenShotDuringEntryExit);
            return alertValue;
        }

        /// <summary>
        /// Get Alert Count in Todays View Notfication
        /// Channel
        /// </summary>
        /// <returns>Alert Count</returns>
        public int GetAlertCount(String channelName)
        {
            //Get Alert count from Notification Channel
            logger.LogMethodEntry("TodaysViewUXPage", "GetAlertCount",
                                  base.IsTakeScreenShotDuringEntryExit);
            //Initialize Alert Variable
            int alertValue = 0;
            //Wait for the Alert channel to load
            base.WaitForElement(By.PartialLinkText(channelName));
            //Store the Alert channel text
            string newGradesAlert = base.GetElementTextByPartialLinkText(channelName);
            try
            {
                //Extract only alert count from the string
                alertValue = Convert.ToInt32(Regex.Replace(newGradesAlert, @"\D", ""));

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "GetAlertCount",
                                 base.IsTakeScreenShotDuringEntryExit);
            return alertValue;
        }

        /// <summary>
        /// Gets Activity Name for the New Grades link for Internet Explorer
        /// </summary>        
        /// <returns>Submitted Activity Name</returns>
        private String GetActivityNameForInternetExplorer()
        {
            //Get the Submitted Activity Name  
            logger.LogMethodEntry("TodaysViewUXPage", "GetActivityNameForInternetExplorer",
                                  base.IsTakeScreenShotDuringEntryExit);
            logger.LogMethodExit("TodaysViewUXPage", "GetActivityNameForInternetExplorer",
                                 base.IsTakeScreenShotDuringEntryExit);
            //Submitted Activity Name
            return base.GetWebElementPropertiesByPartialLinkText(TodaysViewUXPageResource.
                TodaysViewUXPageResource_NewGrades_Link_Text).
                GetAttribute(TodaysViewUXPageResource.
                TodaysViewUXPageResource_NewGrades_Attribute_InnerText);
        }

        /// <summary>
        /// Gets Activity Name for the New Grades link for FireFox browser.
        /// </summary>        
        /// <returns>Submitted Activity Name</returns>
        private String GetActivityNameForFireFox()
        {
            //Get the Submitted Activity Name  
            logger.LogMethodEntry("TodaysViewUXPage", "GetActivityNameForFireFox",
                                  base.IsTakeScreenShotDuringEntryExit);
            logger.LogMethodExit("TodaysViewUXPage", "GetActivityNameForFireFox",
                                 base.IsTakeScreenShotDuringEntryExit);
            //Submitted Activity Name
            return base.GetElementTextByPartialLinkText(TodaysViewUXPageResource.
                TodaysViewUXPageResource_NewGrades_Link_Text);
        }

        /// <summary>
        /// Click on the New Grades option.
        /// </summary>
        public void ClickNewGradesOption()
        {
            //Clicks on the New Grades link
            logger.LogMethodEntry("TodaysViewUXPage", "ClickNewGradesOption",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {                
                //Wait For the Home Link
                base.WaitForElement(By.PartialLinkText(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_NewGrades_Link_Text));
                //Get web element
                IWebElement getNewGrade = base.GetWebElementPropertiesByPartialLinkText
                    (TodaysViewUXPageResource.
                    TodaysViewUXPageResource_NewGrades_Link_Text);
                //Click on the New Grades Link option
                base.ClickByJavaScriptExecutor(getNewGrade);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "ClickNewGradesOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Checks the Submitted Activity Name
        /// </summary>
        /// <returns>Submitted Activity Name</returns>
        public String GetSubmittedActivityName()
        {
            //Verifies the Submitted Activity
            logger.LogMethodEntry("TodaysViewUXPage", "GetSubmittedActivityName",
                                  base.IsTakeScreenShotDuringEntryExit);
            //Intilize Activity Name Variable
            string getActivityName = string.Empty;
            try
            {
                //Display of New Grades Table                
                if (base.IsElementPresent(By.Id(TodaysViewUXPageResource.
                   TodaysViewUXPageResource_NewGrades_SubmittedActivity_Table_Id_Locator),
                       Convert.ToInt32(TodaysViewUXPageResource.
                          TodaysViewUXPageResource_Custom_WaitTime)))
                {
                    //Get Activity Name
                    getActivityName = base.GetElementTextById(TodaysViewUXPageResource.
                         TodaysViewUXPageResource_NewGrades_SubmittedActivity_Table_Id_Locator);
                    //Get Only Activity Name
                    getActivityName = getActivityName.Substring(Convert.ToInt32
                         (TodaysViewUXPageResource.
                          TodaysViewUXPageResource_SubmittedActivity_Name_StartIndex),
                             Convert.ToInt32(TodaysViewUXPageResource.
                              TodaysViewUXPageResource_SubmittedActivity_Name_Length));
                    //Select Default Window
                    base.SelectWindow(TodaysViewUXPageResource
                                          .TodaysViewUXPageResource_WindowsTitle);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "GetSubmittedActivityName",
                                 base.IsTakeScreenShotDuringEntryExit);
            return getActivityName;
        }

        /// <summary>
        /// Click On The Home Link
        /// </summary>
        public void ClickOnHomeLink()
        {
            //To Click On The Home Link
            logger.LogMethodEntry("TodaysViewUXPage", "ClickOnHomeLink",
                                  base.IsTakeScreenShotDuringEntryExit);
            try
            {

                //Wait For the Home Link
                base.WaitForElement(By.PartialLinkText(TodaysViewUXPageResource.
                                                           TodaysViewUXPageResource_Home_Link_PartialText_Locator));
                //Click On The Home Link
                base.ClickLinkByPartialLinkText(TodaysViewUXPageResource.
                                                    TodaysViewUXPageResource_Home_Link_PartialText_Locator);
                //Wait For Global Home Page
                base.WaitUntilWindowLoads(HEDGlobalHomePageResource.
                                         HEDGlobalHome_Page_Window_Title_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "ClickOnHomeLink",
                                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verifying the Display of Defaults Tabs
        /// </summary>
        /// <param name="userTypeEnum">This is User by type</param>
        public Boolean IsDefaultTabsPresent(User.UserTypeEnum userTypeEnum)
        {
            // Verification of Defaults Tabs Display
            logger.LogMethodEntry("TodaysViewUXPage", "IsDefaultTabsPresent",
                                  base.IsTakeScreenShotDuringEntryExit);
            //Intialization of bool 'isAllTabsPresent' to verify display of Defaults Tabs
            Boolean isAllTabsPresent = false;
            try
            {
                //Wait For Overview Window Loads
                base.WaitUntilWindowLoads(TodaysViewUXPageResource.
                                              TodaysViewUXPageResource_Overview_TabName_Text);
                //Select Overview Window
                base.SelectWindow(TodaysViewUXPageResource.
                                      TodaysViewUXPageResource_Overview_TabName_Text);
                //View Page tabs by User type
                switch (userTypeEnum)
                {
                    case User.UserTypeEnum.WsStudent:
                        //Check Display of Defaults Tabs for WsStudent
                        isAllTabsPresent = this.IsDefaultsTabsPresentForWsStudent();
                        break;
                    case User.UserTypeEnum.WsTeacher:
                        //Check Display of Defaults Tabs for WsTeacher
                        isAllTabsPresent = this.IsDefaultsTabsPresentForWsTeacher();
                        break;
                    case User.UserTypeEnum.DPCsStudent:
                        //Check Display of Defaults Tabs for Cs Student
                        isAllTabsPresent = IsDefaultTabsPresentForDigitalPathCsStudent();
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "IsDefaultTabsPresent",
                                 base.IsTakeScreenShotDuringEntryExit);
            return isAllTabsPresent;
        }

        /// <summary>
        /// Verifying the Display of Defaults Tabs for WsStudent
        /// </summary>
        /// <returns>Returns Default tabs present results</returns>
        private Boolean IsDefaultsTabsPresentForWsStudent()
        {
            // Checks Defaults Tabs Display for WsStudent
            logger.LogMethodEntry("TodaysViewUXPage", "IsDefaultsTabsPresentForWsStudent",
                                  base.IsTakeScreenShotDuringEntryExit);
            //Intialization 'isAllTabsPresent' to verify display of Defaults Tabs
            // Overview, Content, Grades, Assignments and Communicate tabs          
            bool isAllTabsPresent = base.IsElementDisplayedByPartialLinkText(TodaysViewUXPageResource.
                                                                                 TodaysViewUXPageResource_Overview_TabName_Text)
                                    && base.IsElementDisplayedByPartialLinkText(TodaysViewUXPageResource.
                                                                                    TodaysViewUXPageResource_Content_TabName_Text)
                                    && base.IsElementDisplayedByPartialLinkText(TodaysViewUXPageResource.
                                                                                    TodaysViewUXPageResource_Assignments_TabName_Text)
                                    && base.IsElementDisplayedByPartialLinkText(TodaysViewUXPageResource.
                                                                                    TodaysViewUXPageResource_Grades_TabName_Text)
                                    && base.IsElementDisplayedByPartialLinkText(TodaysViewUXPageResource.
                                                                                    TodaysViewUXPageResource_Communicate_TabName_Text);
            logger.LogMethodExit("TodaysViewUXPage", "IsDefaultsTabsPresentForWsStudent",
                                 base.IsTakeScreenShotDuringEntryExit);
            return isAllTabsPresent;
        }

        /// <summary>
        /// Verifying the Display of Defaults Tabs WsTeacher
        /// </summary>
        /// <returns>Returns Default tabs present results</returns>
        private Boolean IsDefaultsTabsPresentForWsTeacher()
        {
            // Checks Defaults Tabs Display for WsTeacher
            logger.LogMethodEntry("TodaysViewUXPage", "IsDefaultsTabsPresentForWsTeacher",
                                  base.IsTakeScreenShotDuringEntryExit);
            // Click on the More Link
            this.ClickMoreLink();
            //Intialization of bool 'isAllTabsPresent' to verify display of Defaults Tabs
            // Overview, Content, Gradebook, MyTest, Enrollments, Communicate 
            // and Preferences tabs 
            bool isAllTabsPresent = base.IsElementDisplayedByPartialLinkText(
                TodaysViewUXPageResource.TodaysViewUXPageResource_Overview_TabName_Text) &
                                    base.IsElementDisplayedByPartialLinkText(TodaysViewUXPageResource.
                                                                                 TodaysViewUXPageResource_Content_TabName_Text)
                                    && base.IsElementDisplayedByPartialLinkText(TodaysViewUXPageResource.
                                                                                    TodaysViewUXPageResource_MyTest_TabName_Text)
                                    && base.IsElementDisplayedByPartialLinkText(TodaysViewUXPageResource.
                                                                                    TodaysViewUXPageResource_Gradebook_TabName_Text)
                                    && base.IsElementDisplayedByPartialLinkText(TodaysViewUXPageResource.
                                                                                    TodaysViewUXPageResource_Enrollments_TabName_Text)
                                    && base.IsElementDisplayedByPartialLinkText(TodaysViewUXPageResource.
                                                                                    TodaysViewUXPageResource_Communicate_TabName_Text)
                                    && base.IsElementDisplayedByPartialLinkText(TodaysViewUXPageResource.
                                                                                    TodaysViewUXPageResource_Preferences_TabName_Text);
            logger.LogMethodExit("TodaysViewUXPage", "IsDefaultsTabsPresentForWsTeacher",
                                 base.IsTakeScreenShotDuringEntryExit);
            return isAllTabsPresent;
        }

        /// <summary>
        /// Click on the More Link
        /// </summary>
        private void ClickMoreLink()
        {
            logger.LogMethodEntry("TodaysViewUXPage", "ClickMoreLink",
                                  base.IsTakeScreenShotDuringEntryExit);
            //Wait for content tab
            base.WaitForElement(By.PartialLinkText(TodaysViewUXPageResource.
                                                       TodaysViewUXPageResource_Content_TabName_Text));
            Thread.Sleep(Convert.ToInt32(TodaysViewUXPageResource.
                                             TodaysViewUXPageResource_Custom_WaitTime));
            //Click on Morelink if present           
            if (base.IsElementDisplayedById(TodaysViewUXPageResource.
                                                TodaysViewUXPageResource_MoreLink_Id_Locator))
            {
                // Click on More Link
                base.ClickButtonById(TodaysViewUXPageResource.
                                         TodaysViewUXPageResource_MoreLink_Id_Locator);
            }

            logger.LogMethodExit("TodaysViewUXPage", "ClickMoreLink",
                                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On More Link if More Link Is Present
        /// And The Required Tab Is Not Present
        /// </summary>
        /// <param name="tabName">This Is The Tab Name</param>
        public void ClickMoreLinkIfPresent(string tabName)
        {
            //View More Link If Present
            logger.LogMethodEntry("TodaysViewUXPage", "ClickMoreLinkIfPresent",
                                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                if (base.IsElementPresent(By.Id(TodaysViewUXPageResource.
                                                    TodaysViewUXPageResource_MoreLink_Id_Locator),
                                          Convert.ToInt32(TodaysViewUXPageResource.
                                                              TodaysViewUXPageResource_Custom_WaitTime))
                    && !base.IsElementPresent(By.PartialLinkText(tabName),
                                              Convert.ToInt32(TodaysViewUXPageResource.
                                                                  TodaysViewUXPageResource_Custom_WaitTime)))
                {
                    //Click On More Link if More Link Is Present
                    base.ClickButtonById(TodaysViewUXPageResource.
                                             TodaysViewUXPageResource_MoreLink_Id_Locator);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "ClickMoreLinkIfPresent",
                                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On More Link if More Link Is Present
        /// And The Required Tab Is Not Present.
        /// </summary>
        /// <param name="tabName">This Is The Tab Name.</param>
        public void ClickTheMoreLinkIfPresent(string tabName)
        {
            //Click More Link If Present
            logger.LogMethodEntry("TodaysViewUXPage", "ClickTheMoreLinkIfPresent",
                                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                if (base.IsElementPresent(By.XPath(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_MoreLink_Xpath_Locator),
                                          Convert.ToInt32(TodaysViewUXPageResource.
                                                              TodaysViewUXPageResource_Custom_WaitTime))
                    && !base.IsElementPresent(By.PartialLinkText(tabName),
                                              Convert.ToInt32(TodaysViewUXPageResource.
                                                                  TodaysViewUXPageResource_Custom_WaitTime)))
                {
                    //Click On More Link if More Link Is Present
                    base.ClickButtonByXPath(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_MoreLink_Xpath_Locator);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "ClickTheMoreLinkIfPresent",
                                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Global Home Page
        /// </summary>
        public void NavigateToGlobalHomePage()
        {
            //Navigate To Global Home Page
            logger.LogMethodEntry("TodaysViewUXPage", "NavigateToGlobalHomePage",
                                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Switch To default Window
                base.SelectDefaultWindow();
                //Wait For The Home Link
                base.WaitForElement(By.ClassName(TodaysViewUXPageResource.
                                                     TodaysViewUXPageResource_HomeLink_Class_Locator));
                //Focus On The Element
                base.FocusOnElementByClassName(TodaysViewUXPageResource.
                                                   TodaysViewUXPageResource_HomeLink_Class_Locator);
                //Click On Home Link
                base.ClickButtonByClassName(TodaysViewUXPageResource.
                                                TodaysViewUXPageResource_HomeLink_Class_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "NavigateToGlobalHomePage",
                                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Announcement ManageAll Button
        /// </summary>
        public void ClickAnnouncementManageAllButton()
        {
            //Click on  ManageAll Button
            logger.LogMethodEntry("TodaysViewUXPage", "ClickAnnouncementManageAllButton"
                                  , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Selecting default window
                base.SwitchToDefaultPageContent();
                //Select Course Container frame
                SelectCourseContainerFrame();
                base.WaitForElement(By.ClassName(TodaysViewUXPageResource.
                                                     TodaysViewUXPageResource_ManageAll_Button_Class_Locator));
                base.WaitForElement(By.XPath(TodaysViewUXPageResource.
                                                 TodaysViewUXPageResource_Announcement_Rows_Xpath_Locator));
                //Wait for Element
                base.WaitForElement(By.PartialLinkText(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_ManageAll_Button_PartialLinkText));
                //Focus on Element
                base.FocusOnElementByPartialLinkText(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_ManageAll_Button_PartialLinkText);
                //Get Element Property
                IWebElement getManageAllButton = base.GetWebElementPropertiesByPartialLinkText
                    (TodaysViewUXPageResource.
                    TodaysViewUXPageResource_ManageAll_Button_PartialLinkText);
                //Click Manage All Button
                base.ClickByJavaScriptExecutor(getManageAllButton);

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "ClickAnnouncementManageAllButton",
                                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Course Container frame
        /// </summary>
        private void SelectCourseContainerFrame()
        {
            //Select Course Container frame
            logger.LogMethodEntry("TodaysViewUXPage", "SelectCourseContainerFrame"
                                  , base.IsTakeScreenShotDuringEntryExit);
            //Select Window
            base.SelectWindow(TodaysViewUXPageResource.
                                  TodaysViewUXPageResource_Classes_Window_Title);
            //Wait For Element
            base.WaitForElement(By.Id(TodaysViewUXPageResource.
                                          TodaysViewUXPageResource_CourseContainer_Frame_Id_Locator));
            //Switch To Frame
            base.SwitchToIFrame(TodaysViewUXPageResource.
                                    TodaysViewUXPageResource_CourseContainer_Frame_Id_Locator);
            logger.LogMethodExit("TodaysViewUXPage", "SelectCourseContainerFrame",
                                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Check for the Display of Teacher View tabs
        /// </summary>
        /// <returns>Returns Teacher View tabs present results</returns>
        public Boolean IsTeacherViewTabsPresent()
        {
            //Verify Teacher View Tabs
            logger.LogMethodEntry("TodaysViewUXPage", "IsTeacherViewTabsPresent",
                                  base.IsTakeScreenShotDuringEntryExit);
            //Initializing isTeacherViewTabsPresent Variable
            bool isTeacherViewTabsPresent = false;
            try
            {
                //Wait for Overview Window
                base.WaitUntilWindowLoads(TodaysViewUXPageResource.
                                              TodaysViewUXPageResource_Overview_TabName_Text);
                //Select the Overview Window
                base.SelectWindow(TodaysViewUXPageResource.
                                      TodaysViewUXPageResource_Overview_TabName_Text);
                base.WaitForElement(By.PartialLinkText(TodaysViewUXPageResource.
                                                           TodaysViewUXPageResource_Overview_Link_Locator));
                base.FocusOnElementByPartialLinkText(TodaysViewUXPageResource.
                                                         TodaysViewUXPageResource_Overview_Link_Locator);
                //verify display of Teacher View Tabs Overview,Content,Gradebook and Preferences 
                isTeacherViewTabsPresent = base.IsElementDisplayedByPartialLinkText(TodaysViewUXPageResource.
                                                                                        TodaysViewUXPageResource_Overview_Link_Locator)
                                           && base.IsElementDisplayedByPartialLinkText(TodaysViewUXPageResource.
                                                                                           TodaysViewUXPageResource_Content_Link_Locator)
                                           && base.IsElementDisplayedByPartialLinkText(TodaysViewUXPageResource.
                                                                                           TodaysViewUXPageResource_Gradebook_Link_Locator)
                                           && base.IsElementDisplayedByPartialLinkText(TodaysViewUXPageResource.
                                                                                           TodaysViewUXPageResource_Preferences_Link_Locator)
                                           && base.IsElementDisplayedByPartialLinkText(TodaysViewUXPageResource.
                                                                                           TodaysViewUXPageResource_Enrollments_Link_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "IsTeacherViewTabsPresent",
                                 base.IsTakeScreenShotDuringEntryExit);
            return isTeacherViewTabsPresent;
        }


        /// <summary>
        /// Enter as Demo Student
        /// </summary>
        public void EnterAsDemoStudent()
        {
            //Enter as Demo student
            logger.LogMethodEntry("TodaysViewUXPage", "EnterAsDemoStudent",
                                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for Overview Window
                base.WaitUntilWindowLoads(TodaysViewUXPageResource.
                                              TodaysViewUXPageResource_Overview_TabName_Text);
                //Select the Overview Window
                base.SelectWindow(TodaysViewUXPageResource.
                                      TodaysViewUXPageResource_Overview_TabName_Text);
                base.WaitForElement(By.ClassName(TodaysViewUXPageResource.
                                                     TodaysViewUXPageResource_StudentView_ClassName_Locator));
                base.FocusOnElementByClassName(TodaysViewUXPageResource.
                                                   TodaysViewUXPageResource_StudentView_ClassName_Locator);
                //Click on Student View Button
                base.ClickButtonByClassName(TodaysViewUXPageResource.
                                                TodaysViewUXPageResource_StudentView_ClassName_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "EnterAsDemoStudent",
                                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Class Name
        /// </summary>
        /// <returns>Class Name</returns>
        public String GetClassName()
        {
            //Get Class Name
            logger.LogMethodEntry("TodaysViewUXPage", "GetClassName",
                                  base.IsTakeScreenShotDuringEntryExit);
            //Initialization getClassName Variable
            string getClassName = string.Empty;
            try
            {
                //Wait for Overview Window
                base.WaitUntilWindowLoads(TodaysViewUXPageResource.
                                              TodaysViewUXPageResource_Overview_TabName_Text);
                //Select the Overview Window
                base.SelectWindow(TodaysViewUXPageResource.
                                      TodaysViewUXPageResource_Overview_TabName_Text);
                //Wait For Element
                base.WaitForElement(By.Id(TodaysViewUXPageResource.
                                              TodaysViewUX_Page_CourseTitle_Id_Locator));
                //Get Class Name
                getClassName = base.GetTitleAttributeValueById(TodaysViewUXPageResource.
                                                                   TodaysViewUX_Page_CourseTitle_Id_Locator).Trim();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "GetClassName",
                                 base.IsTakeScreenShotDuringEntryExit);
            return getClassName;
        }


        /// <summary>
        /// Select Home Button
        /// </summary>
        public void SelectHomeButton()
        {
            //Select Home BUtton
            logger.LogMethodEntry("TodaysViewUXPage", "SelectHomeButton",
                                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitUntilWindowLoads(TodaysViewUXPageResource.
                                         TodaysViewUXPageResource_Content_TabName_Text);
                //Select Content Window
                base.SelectWindow(TodaysViewUXPageResource.
                                      TodaysViewUXPageResource_Content_TabName_Text);
                base.WaitForElement(By.PartialLinkText(TodaysViewUXPageResource.
                                                           TodaysViewUXPageResource_Back_Link_Locator));
                //Click on Back Link
                base.FocusOnElementByPartialLinkText(TodaysViewUXPageResource.
                                                         TodaysViewUXPageResource_Back_Link_Locator);
                base.ClickButtonByPartialLinkText(TodaysViewUXPageResource.
                                                      TodaysViewUXPageResource_Back_Link_Locator);
                base.WaitUntilWindowLoads(ManageClassManagementPageResource.
                                         ManageClassManagement_Page_ManageOrganization_Window_Title);
                //Select Manage Organization Window
                base.SelectWindow(ManageClassManagementPageResource.
                                      ManageClassManagement_Page_ManageOrganization_Window_Title);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "SelectHomeButton",
                                 base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Navigate to Teacher View
        /// </summary>
        /// <returns>Back button</returns>
        public Boolean IsTeacherNavigatedBack()
        {
            //Navigate to Teacher View
            logger.LogMethodEntry("TodaysViewUXPage", "IsTeacherNavigatedBack",
                                  base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable isBackButtonPresent
            bool isBackButtonPresent = false;
            try
            {
                //Wait for Overview Window
                base.WaitUntilWindowLoads(TodaysViewUXPageResource.
                                              TodaysViewUXPageResource_Overview_TabName_Text);
                //Select the Overview Window
                base.SelectWindow(TodaysViewUXPageResource.
                                      TodaysViewUXPageResource_Overview_TabName_Text);
                //Wait for Element
                base.WaitForElement(By.ClassName(TodaysViewUXPageResource.
                                                     TodaysViewUX_Page_InstructorView_ClassName_Locator));
                base.FocusOnElementByClassName(TodaysViewUXPageResource.
                                                   TodaysViewUX_Page_InstructorView_ClassName_Locator);
                //Click on Teacher View Button
                base.ClickButtonByClassName(TodaysViewUXPageResource.
                                                TodaysViewUX_Page_InstructorView_ClassName_Locator);
                Thread.Sleep(Convert.ToInt32(TodaysViewUXPageResource.
                                                 TodaysViewUXPageResource_Sleep_Value));
                //Select Overview Window
                base.SelectWindow(TodaysViewUXPageResource.
                                      TodaysViewUXPageResource_Overview_TabName_Text);
                base.WaitForElement(By.PartialLinkText(TodaysViewUXPageResource.
                                                           TodaysViewUXPageResource_Back_Link_Locator));
                //Verify Back Button
                isBackButtonPresent = base.IsElementDisplayedByPartialLinkText(
                    TodaysViewUXPageResource.TodaysViewUXPageResource_Back_Link_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "IsTeacherNavigatedBack",
                                 base.IsTakeScreenShotDuringEntryExit);
            return isBackButtonPresent;
        }

        /// <summary>
        /// Navigate Outside from Class
        /// </summary>
        public void NavigateOutsideFromClass(string windowName)
        {
            //Navigate Outside from Class
            logger.LogMethodEntry("TodaysViewUXPage", "NavigateOutsideFromClass",
                                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for Overview Window
                base.WaitUntilWindowLoads(windowName);
                //Select the Overview Window
                base.SelectWindow(windowName);
                base.WaitForElement(By.PartialLinkText(TodaysViewUXPageResource.
                                                           TodaysViewUXPageResource_Back_Link_Locator));
                //Click on Back Link
                base.ClickButtonByPartialLinkText(TodaysViewUXPageResource.
                                                      TodaysViewUXPageResource_Back_Link_Locator);
                base.WaitUntilWindowLoads(ManageClassManagementPageResource.
                                         ManageClassManagement_Page_ManageOrganization_Window_Title);
                //Select Manage Organization Window
                base.SelectWindow(ManageClassManagementPageResource.
                                      ManageClassManagement_Page_ManageOrganization_Window_Title);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "NavigateOutsideFromClass",
                                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the New Grades Option
        /// </summary>
        public void ClickNewGradesOptionInOverViewTab()
        {
            //Clicks on the New Grades Option
            logger.LogMethodEntry("TodaysViewUXPage", "ClickNewGradesOptionInOverViewTab",
                                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                base.WaitUntilWindowLoads(TodaysViewUXPageResource.
                                         TodaysViewUXPageResource_Overview_Window_Title);
                base.SelectWindow(TodaysViewUXPageResource.
                                      TodaysViewUXPageResource_Overview_Window_Title);
                //Wait for Element
                base.WaitForElement(By.XPath(TodaysViewUXPageResource.
                                                 TodaysViewUXPageResource_NewGradesLink_Xpath_Locator));
                //Focus on Element
                base.FocusOnElementByXPath(TodaysViewUXPageResource.
                                               TodaysViewUXPageResource_NewGradesLink_Xpath_Locator);
                //Get Element Property
                IWebElement getNewGradesLink = base.GetWebElementPropertiesByXPath
                    (TodaysViewUXPageResource.TodaysViewUXPageResource_NewGradesLink_Xpath_Locator);
                //Click on New Grades Option
                base.ClickByJavaScriptExecutor(getNewGradesLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "ClickNewGradesOptionInOverViewTab",
                                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Checks the Submitted Activity Name
        /// </summary>
        /// <param name="activityName">This is submitted activity name.</param>
        /// <returns>Submitted Activity Name.</returns>
        public String GetSubmittedActivityName(string activityName)
        {
            //Verifies the Submitted Activity
            logger.LogMethodEntry("TodaysViewUXPage", "GetSubmittedActivityName",
                                  base.IsTakeScreenShotDuringEntryExit);
            //Initialized Variable
            string getSubmittedActivityName = string.Empty;
            try
            {
                //Display of New Grades Table                
                if (base.IsElementPresent(By.Id(TodaysViewUXPageResource.
                                                    TodaysViewUXPageResource_NewGrades_Synapse_SubmittedActivity_Table_Id_Locator),
                                          Convert.ToInt32(TodaysViewUXPageResource.
                                                              TodaysViewUXPageResource_Custom_WaitTime)))
                {
                    //Get Activity Name
                    string getActivityNameText = base.GetElementTextById(TodaysViewUXPageResource.
                                                                             TodaysViewUXPageResource_NewGrades_Synapse_SubmittedActivity_Table_Id_Locator);
                    //Get Activity Name
                    int getExpectedActivityIndexValue = getActivityNameText.
                        IndexOf(activityName, System.StringComparison.Ordinal);
                    getSubmittedActivityName = getActivityNameText.Substring
                        (getExpectedActivityIndexValue, activityName.Length);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "GetSubmittedActivityName",
                                 base.IsTakeScreenShotDuringEntryExit);
            return getSubmittedActivityName;
        }

        /// <summary>
        /// Verifying the Display of Defaults Tabs Digital Path Cs Student.
        /// </summary>
        /// <returns>Returns Default tabs present results.</returns>
        private Boolean IsDefaultTabsPresentForDigitalPathCsStudent()
        {
            // Checks Defaults Tabs Display for Student
            logger.LogMethodEntry("TodaysViewUXPage", "IsDefaultTabsPresentForDigitalPathCsStudent",
                                  base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.PartialLinkText(TodaysViewUXPageResource.
                                                       TodaysViewUXPageResource_Overview_Window_Title));
            base.FocusOnElementByPartialLinkText(TodaysViewUXPageResource.
                                                     TodaysViewUXPageResource_Overview_Link_Locator);
            //Display of Student View Tabs Overview, Practice and To Do 
            bool isStudentDefaultTabsPresent = base.IsElementDisplayedByPartialLinkText(TodaysViewUXPageResource.
                                                                                            TodaysViewUXPageResource_Overview_Link_Locator)
                                               && base.IsElementDisplayedByPartialLinkText(TodaysViewUXPageResource.
                                                                                               TodaysViewUXPageResource_Practice_Link_Locator)
                                               && base.IsElementDisplayedByPartialLinkText(TodaysViewUXPageResource.
                                                                                               TodaysViewUXPageResource_ToDo_Link_Locator);
            logger.LogMethodExit("TodaysViewUXPage", "IsDefaultTabsPresentForDigitalPathCsStudent",
                                 base.IsTakeScreenShotDuringEntryExit);
            return isStudentDefaultTabsPresent;
        }

        /// <summary>
        /// Get Overview Page window Title.
        /// If Window is accessible then window title should be as expected.
        /// </summary>
        /// <param name="tabName">This is name of the tab.</param>
        /// <returns>True if window title found as expected otherwirse false.</returns>
        private String GetOverviewTabWindowTitle(string tabName)
        {
            //Get Window Title
            logger.LogMethodEntry("TodaysViewUXPage", "GetOverviewTabWindowTitle",
               base.IsTakeScreenShotDuringEntryExit);
            //Wait For Page To Get Switched
            base.WaitUntilPageGetSwitchedSuccessfully(tabName);
            //Get Page Title
            string getWindowTitle = base.GetPageTitle;
            logger.LogMethodEntry("TodaysViewUXPage", "GetOverviewTabWindowTitle",
               base.IsTakeScreenShotDuringEntryExit);
            return getWindowTitle;
        }

        /// <summary>
        /// Get The Tab Window Title.
        /// </summary>
        /// <param name="todaysViewTab">This is tab by type.</param>
        /// <returns>Tab Window Title.</returns>
        public String GetTodaysViewTabTitle(TodaysViewTabType todaysViewTab)
        {
            //Get Tab Window Title
            logger.LogMethodEntry("TodaysViewUXPage", "GetTodaysViewTabTitle",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialized Variable
            string getTabWindowTitle = null;
            switch (todaysViewTab)
            {
                //Get Accessiblity for Overview Tab
                case TodaysViewUXPage.TodaysViewTabType.Overview:
                    getTabWindowTitle = this.GetOverviewTabWindowTitle
                        (todaysViewTab.ToString());
                    break;
                //Get Accessiblity for Practice Tab
                case TodaysViewUXPage.TodaysViewTabType.Practice:
                    getTabWindowTitle = new StudentExplorePage().
                        GetPracticeTabWindowTitle(todaysViewTab.ToString());
                    break;
                //Get Accessiblity for To Do Tab
                case TodaysViewUXPage.TodaysViewTabType.ToDo:
                    getTabWindowTitle = new CoursePreviewUXPage().
                        GetToDoTabWindowTitle(todaysViewTab.ToString());
                    break;
            }
            logger.LogMethodExit("TodaysViewUXPage", "GetTodaysViewTabTitle",
              base.IsTakeScreenShotDuringEntryExit);
            return getTabWindowTitle;
        }


        /// <summary>
        /// Click On Manage All Button in HED
        /// </summary>
        public void ClickOnManageAllButtonHED()
        {
            //Click On Manage All Button in HED
            logger.LogMethodEntry("TodaysViewUXPage", "ClickOnManageAllButtonHED",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.SelectDefaultWindow();
                //Wait for Manage All Partial Link Text
                base.WaitForElement(By.PartialLinkText(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_ManageAll_Button_PartialLinkText));
                //Get Button Property
                IWebElement getButtonProperty = base.GetWebElementPropertiesByPartialLinkText(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_ManageAll_Button_PartialLinkText);
                //Click On Button
                base.ClickByJavaScriptExecutor(getButtonProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "ClickOnManageAllButtonHED",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Welcome Student Text Message
        /// </summary>
        /// <returns>Welcome student text</returns>
        public String GetWelcomeStudentTextMessage(string welcomeStudentText)
        {
            //Get Welcome Student Text Message
            logger.LogMethodEntry("TodaysViewUXPage", "GetWelcomeStudentTextMessage",
              base.IsTakeScreenShotDuringEntryExit);
            //Initialized welsome student text
            string getWelcomeStudentText = string.Empty;
            try
            {
                //Wait untill the window laods
                base.WaitUntilWindowLoads(TodaysViewUXPageResource.
                       TodaysViewUXPageResource_WindowsTitle);
                //Wait for the element
                base.WaitForElement(By.Id(TodaysViewUXPageResource.
                    TodaysViewUX_Page_welcomeStudentMessage_Id_Locator));
                //Get the welcome student text
                string getWelcomeStudentMessagae = base.GetElementTextById
                    (TodaysViewUXPageResource.
                    TodaysViewUX_Page_welcomeStudentMessage_Id_Locator);
                getWelcomeStudentText = getWelcomeStudentMessagae.Substring
                    (Convert.ToInt32(TodaysViewUXPageResource.
                    TodaysViewUXPage_WelcomeMessage_TextValue));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "GetWelcomeStudentTextMessage",
              base.IsTakeScreenShotDuringEntryExit);
            return getWelcomeStudentText;
        }

        /// <summary>
        /// To validate the page using text 
        /// </summary>
        /// <param name="containerID">Is used to fin the text with in given container</param>
        /// <returns>Text of given container as string</returns>
        public string ValidateThePageWithText(string container)
        {
            // Check the text in given page
            logger.LogMethodEntry("TodaysViewUXPage", "ValidateThePageWithText",
                IsTakeScreenShotDuringEntryExit);
            string text = string.Empty;
            try
            {
                // Wait for given page load
                base.WaitUntilWindowLoads(TodaysViewUXPageResource
                    .TodaysViewUXPageResource_WindowsTitle);
                // Wait for given element load
                base.WaitForElement(By.ClassName(container));
                // Get text of given element
                text = base.GetElementTextByClassName(container);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            // Check the text in given page
            logger.LogMethodExit("TodaysViewUXPage", "ValidateThePageWithText",
                IsTakeScreenShotDuringEntryExit);
            // Rerun text of given container as string
            return text;
        }

        /// <summary>
        /// To check the student name in "Unread comments" list
        /// </summary>
        /// <param name="studentName">Name of the student</param>
        /// <returns>Name of the student</returns>
        public string ValidateTheStudentName(string studentName)
        {
            // To check the student name in "Unread comments" list
            logger.LogMethodEntry("TodaysViewUXPage", "ValidateTheStudentName",
                IsTakeScreenShotDuringEntryExit);
            string name = string.Empty;
            try
            {
                // Wait for given page load
                base.WaitUntilWindowLoads(TodaysViewUXPageResource
                    .TodaysViewUXPageResource_WindowsTitle);
                // Wait for given element load
                base.WaitForElement(By.Id("divTreeContainer"));
                // Get text of given element
                name = base.GetElementTextById(TodaysViewUXPageResource
                    .TodaysViewUXPageResource_Tree_View_DivID).Contains(studentName) ? studentName : name;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            // To check the student name in "Unread comments" list
            logger.LogMethodExit("TodaysViewUXPage", "ValidateTheStudentName",
                IsTakeScreenShotDuringEntryExit);
            return name;
        }

        /// <summary>
        /// Enter Into The Activity Folder HED
        /// </summary>
        public void LaunchTheActivityHED()
        {
            // Enter Into the Activity Folder
            logger.LogMethodEntry("TodaysViewUXPage", "LaunchTheActivityHED",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Open the Activity 
                this.EnterIntoTheAsset(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_Page_ManualGrade_Activity);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            // Enter Into the Activity Folder
            logger.LogMethodExit("TodaysViewUXPage", "LaunchTheActivityHED",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Into The Asset.
        /// </summary>
        /// <param name="assetName">This is asset name.</param>
        private void EnterIntoTheAsset(String assetName)
        {
            // Enter Into The Asset
            logger.LogMethodEntry("TodaysViewUXPage", "EnterIntoTheAsset",
                    base.IsTakeScreenShotDuringEntryExit);
            // Select the 'Course Materials' Window
            base.SelectWindow(TodaysViewUXPageResource.
                TodaysViewUXPageResource_Page_Window_Title_Name_HED);
            // Select the Frame
            this.SelectActivityFrame();
            // Click on the Asset Name
            base.WaitForElement(By.PartialLinkText(assetName));
            // Click on the Asset Name
            base.ClickLinkByPartialLinkText(assetName);
            logger.LogMethodExit("TodaysViewUXPage", "EnterIntoTheAsset",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Activity Frame
        /// </summary>
        private void SelectActivityFrame()
        {
            // Select Activity Frame
            logger.LogMethodEntry("TodaysViewUXPage", "SelectActivityFrame",
              base.IsTakeScreenShotDuringEntryExit);
            // Wait gor Activity Frame
            base.WaitForElement(By.Id(TodaysViewUXPageResource.
                TodaysViewUXPageResource_Page_Frame_Id_Locator));
            // Switch to inner frame
            base.SwitchToIFrame(TodaysViewUXPageResource.
                TodaysViewUXPageResource_Page_Frame_Id_Locator);
            // Select Activity Frame
            logger.LogMethodExit("TodaysViewUXPage", "SelectActivityFrame",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Attempt Essay Activity.
        /// </summary>
        /// <param name="answerText">This is Answer Text.</param>
        public void AttemptEssayActivity(string answerText)
        {
            // Attempt Essay Activity
            logger.LogMethodEntry("TodaysViewUXPage", "AttemptEssayActivity",
                    base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait to open presentation window
                Thread.Sleep(Convert.ToInt32(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_Page_CustomWait_Time));
                // Select the window
                base.SwitchToLastOpenedWindow();
                // Wait for activity element
                base.WaitForElement(By.XPath(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_Page_Answer_TextArea_Xpath_Locator));
                //Enter the Answer text
                base.GetWebElementPropertiesByXPath(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_Page_Answer_TextArea_Xpath_Locator).
                    SendKeys(answerText);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "AttemptEssayActivity",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit The Activity
        /// </summary>
        public void SubmitTheActivityHED()
        {
            // Submit The Activity
            logger.LogMethodEntry("TodaysViewUXPage", "SubmitTheActivityHED",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait For Element
                base.WaitForElement(By.Id(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_Page_MasterFinish_Button_Id_Locator));
                // Get Button Property
                IWebElement getMasterFinishButtonProperty = WebDriver.FindElement(By.Id
                    (TodaysViewUXPageResource.
                    TodaysViewUXPageResource_Page_MasterFinish_Button_Id_Locator));
                // Click On Button
                base.ClickByJavaScriptExecutor(getMasterFinishButtonProperty);
                // Wait For Element
                base.WaitForElement(By.Id(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_Page_ActivityFinish_Button_Id_Locator));
                // Get Finish Button Property
                IWebElement getFinishButtonProperty = WebDriver.FindElement(By.Id
                    (TodaysViewUXPageResource
                    .TodaysViewUXPageResource_Page_ActivityFinish_Button_Id_Locator));
                // Click on Button
                base.ClickByJavaScriptExecutor(getFinishButtonProperty);
                // Wait For Element
                base.WaitForElement(By.PartialLinkText(TodaysViewUXPageResource.
                        TodaysViewUXPageResource_Page_ReturnToCourse_Button_Id_Locator));
                // Get Link Property
                IWebElement getReturnToCourseLinkProperties = base.
                    GetWebElementPropertiesByPartialLinkText(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_Page_ReturnToCourse_Button_Id_Locator);
                // Click on Button
                base.ClickByJavaScriptExecutor(getReturnToCourseLinkProperties);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "SubmitTheActivityHED",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Manually Grade the Activity
        /// </summary>
        /// <param name="activityName">This is Activity Name</param>
        public void OpenActivityForGradingInHED(string activityName)
        {
            // Manually Grade the Activity
            logger.LogMethodEntry("TodaysViewUXPage", "OpenActivityForGradingInHED",
                                   base.IsTakeScreenShotDuringEntryExit);
            // Get the Activity Title
            string getAssignmentTitle = string.Empty;
            try
            {
                // Select the Frame
                this.SelectFrame();
                // Wait till column element load
                base.WaitForElement(By.XPath(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_Page_AssignmentCount_Xpath_Locator));
                // Total Number Of Activities
                int getActivityCount = base.GetElementCountByXPath(
                    (TodaysViewUXPageResource.
                    TodaysViewUXPageResource_Page_AssignmentCount_Xpath_Locator));
                // Setting Column Number
                int activityColumnNo;
                for (activityColumnNo = Convert.ToInt32(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_Page_Initial_Value); activityColumnNo <= getActivityCount; activityColumnNo++)
                {
                    // Check For The Assignment In GradeBook
                    getAssignmentTitle = GetAssignmetTitle(getAssignmentTitle, activityColumnNo);
                    if (getAssignmentTitle.Contains(activityName))
                    {
                        break;
                    }
                }
                // Click on Activity Cmenu
                this.ClickOnActivityCmenu(activityColumnNo);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "OpenActivityForGradingInHED",
                          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Activity Cmenu Option
        /// </summary>
        /// <param name="activityColumnNo">This is Activity Column Number</param>
        private void ClickOnActivityCmenu(int activityColumnNo)
        {
            //Click On Activity Cmenu Option
            logger.LogMethodEntry("TodaysViewUXPage", "ClickOnActivityCmenu",
                                   base.IsTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.XPath(string.Format(TodaysViewUXPageResource.
                TodaysViewUXPageResource_Page_CmenuOption_Xpath_Locator, activityColumnNo)));
            IWebElement getCmenuProperty = base.GetWebElementPropertiesByXPath
                (string.Format(TodaysViewUXPageResource.
                  TodaysViewUXPageResource_Page_CmenuOption_Xpath_Locator, activityColumnNo));
            //Click on Activity Cmenu Button
            base.ClickByJavaScriptExecutor(getCmenuProperty);
            base.WaitForElement(By.Id(TodaysViewUXPageResource.
                TodaysViewUXPageResource_Page_ViewSubmission_Cmenu_ID));
            IWebElement getEditGradeProperty = base.GetWebElementPropertiesById(TodaysViewUXPageResource.
                TodaysViewUXPageResource_Page_ViewSubmission_Cmenu_ID);
            //Click On Edit Grades Option
            base.ClickByJavaScriptExecutor(getEditGradeProperty);
            Thread.Sleep(Convert.ToInt32(TodaysViewUXPageResource.
                   TodaysViewUXPageResource_Page_WaitWindowTime_Value));
            logger.LogMethodExit("TodaysViewUXPage", "ClickOnActivityCmenu",
                        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the Frame
        /// </summary>
        private void SelectFrame()
        {
            // Select the Frame
            logger.LogMethodEntry("TodaysViewUXPage", "SelectFrame",
                                   base.IsTakeScreenShotDuringEntryExit);
            // Select Window
            base.SelectWindow(TodaysViewUXPageResource.
                TodaysViewUXPageResource_Page_Window_Title);
            // Wait for Element         
            base.WaitForElement(By.Id(TodaysViewUXPageResource.
                TodaysViewUXPageResource_Page_Synapse_GradesFrame_Iframe_Name_Locator));
            // Switch to Frame
            base.SwitchToIFrame(TodaysViewUXPageResource.
                TodaysViewUXPageResource_Page_Synapse_GradesFrame_Iframe_Name_Locator);
            // Select the Frame
            logger.LogMethodExit("TodaysViewUXPage", "SelectFrame",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Assignment Title
        /// </summary>
        /// <param name="assignmentTitle">This Is The Assignment Title</param>
        /// <param name="columnNo">This Is The Column Number Of Required Activity</param>
        /// <returns>Assignment title</returns>
        private String GetAssignmetTitle(
            string assignmentTitle, int columnNo)
        {
            // Get Assignment Title
            logger.LogMethodEntry("TodaysViewUXPage", "GetAssignmetTitle",
                                 base.IsTakeScreenShotDuringEntryExit);
            switch (base.Browser)
            {
                case PegasusBaseTestFixture.InternetExplorer:
                    {
                        //Get assignment title from Internet explorer
                        assignmentTitle = this.GetAssignmentTitleInInternetExplorer(assignmentTitle, columnNo);
                        break;
                    }
                case PegasusBaseTestFixture.FireFox:
                    {
                        //Get assignment title from Firefox
                        assignmentTitle = this.GetAssignmentTitleInFireFox(assignmentTitle, columnNo);
                        break;
                    }
            }
            logger.LogMethodExit("TodaysViewUXPage", "GetAssignmetTitle",
                                 base.IsTakeScreenShotDuringEntryExit);
            return assignmentTitle;
        }

        /// <summary>
        /// Get assignment title from Firefox
        /// </summary>
        /// <param name="assignmentTitle">This Is The Assignment Title</param>
        /// <param name="columnNo">This Is The Column Number Of Required Activity</param>
        /// <returns>Assignment Title For Internet Explorer Browser</returns>
        private string GetAssignmentTitleInInternetExplorer(
            string assignmentTitle, int columnNo)
        {
            //Get assignment title from Firefox
            logger.LogMethodEntry("TodaysViewUXPage", "GetAssignmentTitleInInternetExplorer",
                                  base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.XPath(string.Format(TodaysViewUXPageResource.
                TodaysViewUXPageResource_Page_AssignmentTitleIE_Xpath_Locator, columnNo)));
            assignmentTitle = base.GetTitleAttributeValueByXPath(string.Format(TodaysViewUXPageResource.
                TodaysViewUXPageResource_Page_AssignmentTitleIE_Xpath_Locator, columnNo));
            logger.LogMethodExit("TodaysViewUXPage", "GetAssignmentTitleInInternetExplorer",
                                 base.IsTakeScreenShotDuringEntryExit);
            return assignmentTitle;
        }

        /// <summary>
        /// Get Assignment Title From Internet Explorer
        /// </summary>
        /// <param name="assignmentTitle">This Is The Assignment Title</param>
        /// <param name="columnNo">This Is The Column Number Of Required Activity</param>
        /// <returns>Assignment Title For FireFox</returns>
        private string GetAssignmentTitleInFireFox(
            string assignmentTitle, int columnNo)
        {
            //Get assignment title from Internet explorer
            logger.LogMethodEntry("TodaysViewUXPage", "AssignmentTitleFF",
                                  base.IsTakeScreenShotDuringEntryExit);

            assignmentTitle = base.GetTitleAttributeValueByXPath(string.Format(TodaysViewUXPageResource.
                TodaysViewUXPageResource_Page_AssignmentTitleFF_Xpath_Locator, columnNo));

            logger.LogMethodExit("TodaysViewUXPage", "AssignmentTitleFF",
                                  base.IsTakeScreenShotDuringEntryExit);
            return assignmentTitle;
        }

        /// <summary>
        /// Enter instructor comments for submission
        /// </summary>
        public void EnterInstructorComments()
        {
            // Enter instructor comments for submission
            logger.LogMethodEntry("TodaysViewUXPage", "EnterInstructorComments",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait till window laod
                Thread.Sleep(Convert.ToInt32(TodaysViewUXPageResource.
                                             TodaysViewUXPageResource_Custom_WaitTime));
                // Select view submission window
                base.SelectWindow(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_Page_ViewSubmission_Title);
                // Wait for Student name load
                base.WaitForElement(By.XPath(TodaysViewUXPageResource.
                TodaysViewUXPageResource_Page_StudentName_Xpath));
                // Click on student name
                IWebElement studentName = base.GetWebElementPropertiesByXPath(TodaysViewUXPageResource.
                TodaysViewUXPageResource_Page_StudentName_Xpath);
                // Click on student name
                base.ClickByJavaScriptExecutor(studentName);
                // Enter inastructor comments
                this.EnterComments();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            // Enter instructor comments for submission
            logger.LogMethodExit("TodaysViewUXPage", "EnterInstructorComments",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter instructor comments
        /// </summary>
        private void EnterComments()
        {
            // Enter instructor comments
            logger.LogMethodEntry("TodaysViewUXPage", "EnterComments",
                IsTakeScreenShotDuringEntryExit);
            // Search for HTML editor iframe
            base.WaitForElement(By.XPath(TodaysViewUXPageResource.
                TodaysViewUXPageResource_Page_HTML_editorIframe));
            // Insert instructor comments to HTML editor iframe
            base.GetWebElementPropertiesByXPath(TodaysViewUXPageResource.
                TodaysViewUXPageResource_Page_HTML_editorIframe).SendKeys(TodaysViewUXPageResource.
                TodaysViewUXPageResource_Page_Instructor_comment);
            // Click on View Submission Save and Close button
            this.ClickSaveAndClose();
            // Enter instructor comments
            logger.LogMethodExit("TodaysViewUXPage", "EnterComments",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on View submission Save and Close button
        /// </summary>
        private void ClickSaveAndClose()
        {
            // Click on View submission Save and Close button
            logger.LogMethodEntry("TodaysViewUXPage", "ClickSaveAndClose",
                IsTakeScreenShotDuringEntryExit);
            // Click on View Submission Save and Close button
            base.ClickButtonByPartialLinkText(TodaysViewUXPageResource.
                TodaysViewUXPageResource_Page_SaveAndClose_Button);
            // Click on View submission Save and Close button
            logger.LogMethodExit("TodaysViewUXPage", "ClickSaveAndClose",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on student tree view Expand icon
        /// </summary>
        public void ClickOnExpandIcon()
        {
            // Click on student tree view Expand icon
            logger.LogMethodEntry("TodaysViewUXPage", "ClickOnExpandIcon",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Click on Expand icon
                base.ClickLinkById(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_Page_TreeViewExpandIconID);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            // Click on student tree view Expand icon
            logger.LogMethodExit("TodaysViewUXPage", "ClickOnExpandIcon",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To check submitted activity name
        /// </summary>
        /// <param name="activityName">Name of the activity</param>
        /// <returns>String: Activity name</returns>
        public string CheckSubmittedActitvityName(string activityName)
        {
            // To check submitted activity name
            logger.LogMethodEntry("TodaysViewUXPage", "CheckSubmittedActitvityName",
                base.IsTakeScreenShotDuringEntryExit);
            string _activityName = string.Empty;
            try
            {
                base.WaitForElement(By.Id(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_Page_TreeViewControlID));
                _activityName = (base.GetElementTextById(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_Page_TreeViewControlID).Contains(activityName) ? activityName : _activityName);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            // To check submitted activity name
            logger.LogMethodExit("TodaysViewUXPage", "CheckSubmittedActitvityName",
                base.IsTakeScreenShotDuringEntryExit);
            // Return activity name if exits
            return _activityName;
        }

        /// <summary>
        /// Open Customize Notification Window
        /// </summary>
        public void OpenCustomizeNotificationPopUp()
        {
            //Open the Customize Notification Window On Click of Customize button
            logger.LogMethodEntry("TodaysViewUXPage", "OpenCustomizeNotificationPopUp",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the window
                base.SelectWindow(TodaysViewUXPageResource
                    .TodaysViewUXPageResource_WindowsTitle);
                //Click customize button    
                IWebElement getCustomizeButtonProperties = base.GetWebElementPropertiesById(
                    TodaysViewUXPageResource.TodaysViewUX_Page_Customize_Button_ID_Locator);
                base.ClickByJavaScriptExecutor(getCustomizeButtonProperties);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "OpenCustomizeNotificationPopUp",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Pop up window opened is Correct
        /// </summary>
        /// <returns>Customize Notification Popup Window Title</returns>
        public string GetCustomizeNotificationPopUpWindowTitle()
        {
            //Check the Customize Notification pop up Window Title
            logger.LogMethodEntry("TodaysViewUXPage", "GetCustomizeNotificationPopUpWindowTitle",
                base.IsTakeScreenShotDuringEntryExit);
            string getPopUpWindowTitle = string.Empty;
            try
            {
                //Wait for Popup window loads                
                base.WaitForElement(By.Id(TodaysViewUXPageResource
                    .TodaysViewUX_Page_IFrame_LightBox_PopUp_ID_Locator));
                base.SwitchToIFrame(TodaysViewUXPageResource
                    .TodaysViewUX_Page_IFrame_LightBox_PopUp_ID_Locator);
                //get the Pop Up window Title
                base.WaitForElement(By.Id(TodaysViewUXPageResource.
                    TodaysViewUX_Page_Customize_Notification_Title_ID_Locator));
                getPopUpWindowTitle = base.GetElementTextById(TodaysViewUXPageResource.
                    TodaysViewUX_Page_Customize_Notification_Title_ID_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "GetCustomizeNotificationPopUpWindowTitle",
                base.IsTakeScreenShotDuringEntryExit);
            return getPopUpWindowTitle;
        }

        /// <summary>
        /// Select the Default Channel Name
        /// </summary>
        /// <param name="channelName">This is Channel Name</param>
        public void SelectTheDefaultChannel(string channelName)
        {
            //Select the Default Channel Name
            logger.LogMethodEntry("TodaysViewUXPage", "SelectTheDefaultChannel",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(TodaysViewUXPageResource.
                    TodaysViewUX_Page_Default_View_DropDownList_By_ID_Locator));
                //Select the Dropdown option Text
                base.SelectDropDownValueThroughTextById(TodaysViewUXPageResource.
                    TodaysViewUX_Page_Default_View_DropDownList_By_ID_Locator, channelName);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            logger.LogMethodExit("TodaysViewUXPage", "SelectTheDefaultChannel",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Uncheck the Checkbox Option 
        /// </summary>       
        public void UnCheckNotifyMeCheckboxOption()
        {
            //Uncheck the Checkbox Option
            logger.LogMethodEntry("TodaysViewUXPage", "UnCheckNotifyMeCheckboxOption",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //wait for element
                base.WaitForElement(By.Id(TodaysViewUXPageResource.
                    TodaysViewUX_Page_NotifyMe_CheckBox_ID_Locator));
                //focussing the Check box element
                base.FocusOnElementById(TodaysViewUXPageResource.
                    TodaysViewUX_Page_NotifyMe_CheckBox_ID_Locator);
                if (base.IsElementSelectedById(TodaysViewUXPageResource.
                    TodaysViewUX_Page_NotifyMe_CheckBox_ID_Locator))
                {
                    //UnCheck the check box                
                    base.SelectCheckBoxById(TodaysViewUXPageResource.
                        TodaysViewUX_Page_NotifyMe_CheckBox_ID_Locator);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            logger.LogMethodExit("TodaysViewUXPage", "UnCheckNotifyMeCheckboxOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This will close the light box on click of Save and Close button
        /// </summary>
        public void ClickTheSaveAndCloseButton()
        {
            //Click on Save and Close button and Close the pop up 
            logger.LogMethodEntry("TodaysViewUXPage", "ClickTheSaveAndCloseButton",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //wait for element
                base.WaitForElement(By.Id(TodaysViewUXPageResource.
                    TodaysViewUX_Page_Save_Close_Button_By_ID_Locator));
                //get Element Property
                IWebElement getSaveCloseButtonProperties = base.GetWebElementPropertiesById(
                    TodaysViewUXPageResource.TodaysViewUX_Page_Save_Close_Button_By_ID_Locator);
                base.ClickByJavaScriptExecutor(getSaveCloseButtonProperties);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "ClickTheSaveAndCloseButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This will return Channel Name
        /// </summary>
        /// <param name="channelName">This is Channel Name</param>
        /// <returns>Unread Comments Text if Displayed</returns>
        public string GetUnreadCommentsInTodaysViewPage(string channelName)
        {
            //Uncheck the Checkbox Option
            logger.LogMethodEntry("TodaysViewUXPage", "GetUnreadCommentsInTodaysViewPage",
                base.IsTakeScreenShotDuringEntryExit);
            string getChannelName = string.Empty;
            try
            {
                //Wait for Today's view page load
                Thread.Sleep(Convert.ToInt32(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_ChannelDisplay_Sleep_Time_Value));
                //Wait for the Element
                base.WaitForElement(By.ClassName(TodaysViewUXPageResource.
                    TodaysViewUX_Page_CoursePerformance_Update_By_Class_Name));
                string getNotificationText =
                    GetElementTextByClassName(TodaysViewUXPageResource.
                    TodaysViewUX_Page_CoursePerformance_Update_By_Class_Name);
                //If the Element is Present
                if (getNotificationText.Contains(channelName))
                {
                    getChannelName = channelName;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "GetUnreadCommentsInTodaysViewPage",
                base.IsTakeScreenShotDuringEntryExit);
            return getChannelName;
        }

        /// <summary>
        /// This will check the Checkbox Option
        /// </summary>
        public void CheckNotifyMeCheckboxOption()
        {
            //check the Checkbox Option
            logger.LogMethodEntry("TodaysViewUXPage", "CheckNotifyMeCheckboxOption",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //wait for element
                base.WaitForElement(By.Id(TodaysViewUXPageResource.
                    TodaysViewUX_Page_NotifyMe_CheckBox_ID_Locator));
                //focussing the Check box element
                base.FocusOnElementById(TodaysViewUXPageResource.
                    TodaysViewUX_Page_NotifyMe_CheckBox_ID_Locator);
                if (!base.IsElementSelectedById(TodaysViewUXPageResource.
                    TodaysViewUX_Page_NotifyMe_CheckBox_ID_Locator))
                {
                    //Check the check box                
                    base.SelectCheckBoxById(TodaysViewUXPageResource.
                        TodaysViewUX_Page_NotifyMe_CheckBox_ID_Locator);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "CheckNotifyMeCheckboxOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Course name
        /// </summary>
        /// <returns>Course Name</returns>
        public String GetCourseName()
        {
            //Get Course name
            logger.LogMethodEntry("TodaysViewUXPage", "GetCourseName",
                 base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getCourseName = string.Empty;
            try
            {
                //Select Default Window
                base.SelectDefaultWindow();
                //Wait for Element
                base.WaitForElement(By.XPath(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_CourseName_XPath_Locator));
                //Get Course Name
                getCourseName = base.GetElementTextByXPath(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_CourseName_XPath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "GetCourseName",
              base.IsTakeScreenShotDuringEntryExit);
            return getCourseName;
        }

        /// <summary>
        /// Select Window.
        /// </summary>
        private void SelectWindow()
        {
            //Select Window
            logger.LogMethodEntry("TodaysViewUXPage", "SelectWindow",
                 base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(TodaysViewUXPageResource.
                TodaysViewUXPageResource_WindowsTitle);
            //Select Window
            base.SelectWindow(TodaysViewUXPageResource.
                TodaysViewUXPageResource_WindowsTitle);
            logger.LogMethodExit("TodaysViewUXPage", "SelectWindow",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Section ID
        /// </summary>
        /// <returns>This is Section ID</returns>
        public String GetSectionIDAfterEnterInsideSection()
        {
            //Get Section ID
            logger.LogMethodEntry("TodaysViewUXPage", "GetSectionIDAfterEnterInsideSection",
                 base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getSectionID = string.Empty;
            try
            {
                //Select Window
                this.SelectWindow();
                //Wait for Element
                base.WaitForElement(By.Id(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_SectionID_Id_Locator));
                //Get Section ID
                getSectionID = base.GetElementTextById(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_SectionID_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "GetSectionIDAfterEnterInsideSection",
              base.IsTakeScreenShotDuringEntryExit);
            //Returns Section ID
            return getSectionID;
        }

        /// <summary>
        /// Click The Home Link In Global Homepage.
        /// </summary>
        private void ClickTheHomeLinkInGlobalHomepage()
        {
            //Click The Home Link In Global Homepage
            logger.LogMethodEntry("TodaysViewUXPage", "ClickTheHomeLinkInGlobalHomepage",
              base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.PartialLinkText(TodaysViewUXPageResource.
                TodayViewUXPageResource_Home_Link_PartialLink_Locator));
            IWebElement getHomeLinkProperty = base.GetWebElementPropertiesByPartialLinkText
                (TodaysViewUXPageResource.
                TodayViewUXPageResource_Home_Link_PartialLink_Locator);
            //Click the Home link
            base.ClickByJavaScriptExecutor(getHomeLinkProperty);
            logger.LogMethodExit("TodaysViewUXPage", "ClickTheHomeLinkInGlobalHomepage",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Is Verify The HelpLink Page TextPresent.
        /// </summary>
        /// <returns>HelpLink Page Text</returns>
        public Boolean IsVerifyTheHelpLinkPageTextPresent()
        {
            //Is Verify The HelpLink Page TextPresent
            logger.LogMethodEntry("TodaysViewUXPage", "IsVerifyTheHelpLinkPageTextPresent",
              base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool IsHelpPageTextPresent = false;
            try
            {
                //Select window
                base.SelectWindow(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_Help_Link_Window_Name);
                //Select navigate frame
                IWebElement getFrameProperty = base.GetWebElementPropertiesByName(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_Help_Link_Frame_Name);
                base.SwitchToIFrameByWebElement(getFrameProperty);
                //Select Iframe
                IWebElement getHelpWindowFrameName = base.GetWebElementPropertiesById
                    (TodaysViewUXPageResource.TodaysViewUXPageResource_Help_Link_IFrame_Id_Locator);
                base.SwitchToIFrameByWebElement(getHelpWindowFrameName);
                IsHelpPageTextPresent = base.IsElementPresent(By.PartialLinkText
                    (TodaysViewUXPageResource.TodaysViewUXPageResource_Help_TextPresent));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "IsVerifyTheHelpLinkPageTextPresent",
            base.IsTakeScreenShotDuringEntryExit);
            return IsHelpPageTextPresent;
        }

        /// <summary>
        /// Click The Link In GlobalHome page.
        /// </summary>
        /// <param name="globalHomePageLinkTypeEnum">This is global home page link</param>
        public void ClickTheLinkInGlobalHomePage(
            GlobalHomePageLinkTypeEnum globalHomePageLinkTypeEnum)
        {
            //Click The Link In GlobalHome page.
            logger.LogMethodEntry("TodaysViewUXPage", "ClickTheLinkInGlobalHomePage",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (globalHomePageLinkTypeEnum)
                {
                    // Click The Home Link In Global Homepage        
                    case GlobalHomePageLinkTypeEnum.Home:
                        this.ClickTheHomeLinkInGlobalHomepage();
                        break;
                    // Click The Help Link In Global Homepage
                    case GlobalHomePageLinkTypeEnum.Help:
                        new HEDGlobalHomePage().ClickTheHelpLinkInGlobalHomePage();
                        break;
                    //Click The Help Link In Global Homepage in TA
                    case GlobalHomePageLinkTypeEnum.HelpInTA:
                        new HEDGlobalHomePage().ClickTheHelpLinkInGlobalHomePageInTa();
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "ClickTheLinkInGlobalHomePage",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Submitted Activity Name By Student.
        /// </summary>
        /// <returns>Submitted activity.</returns>
        public String GetSubmittedActivityNameByStudent()
        {
            //Get Submitted Activity Name By Student
            logger.LogMethodEntry("TodaysViewUXPage", "GetSubmittedActivityNameByStudent",
                    base.IsTakeScreenShotDuringEntryExit);
            //Intilize Activity Name Variable
            string getActivityName = string.Empty;
            //Select the Today's View window
            this.SelectTodaysViewWindow();
            try
            {
                //Display of New Grades Table                
                if (base.IsElementPresent(By.Id(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_Student_Newgrade_Id_Locator),
                       Convert.ToInt32(TodaysViewUXPageResource.
                          TodaysViewUXPageResource_Custom_WaitTime)))
                {
                    //Get Activity Name
                    getActivityName = base.GetElementTextById(TodaysViewUXPageResource.
                        TodaysViewUXPageResource_Student_Newgrade_Id_Locator);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "GetSubmittedActivityNameByStudent",
                  base.IsTakeScreenShotDuringEntryExit);
            return getActivityName;
        }

        /// <summary>
        /// Click The View Submission Cmenu Option.
        /// </summary>
        public void ClickTheViewSubmissionCmenuOption()
        {
            //Click The View Submission Cmenu Option
            logger.LogMethodEntry("TodaysViewUXPage", "ClickTheViewSubmissionCmenuOption",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.WaitForElement(By.XPath(TodaysViewUXPageResource.
                     TodaysViewUXPageResource_Page_NewGrade_ActivitytName_Xpath));
                IWebElement getActivityName = base.GetWebElementPropertiesByXPath
                    (TodaysViewUXPageResource.
                     TodaysViewUXPageResource_Page_NewGrade_ActivitytName_Xpath);
                //Mouse over action
                base.PerformMouseHoverByJavaScriptExecutor(getActivityName);
                //Wait for the element
                base.WaitForElement(By.ClassName(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_Page_NewGrade_Activityt_Cmenu_ClassName));
                IWebElement getActivityCmenu = base.GetWebElementPropertiesByClassName
                    (TodaysViewUXPageResource.
                        TodaysViewUXPageResource_Page_NewGrade_Activityt_Cmenu_ClassName);
                //Click on cmenu option image
                base.ClickByJavaScriptExecutor(getActivityCmenu);
                //Get web element
                IWebElement getViewSubmission = base.GetWebElementPropertiesByXPath
                  (TodaysViewUXPageResource.
                    TodaysViewUXPageResource_Page_NewGrade_Activityt_Cmenu_Viewgrade_Xpath);
                //Click the 'View Submission' cmenu
                base.ClickByJavaScriptExecutor(getViewSubmission);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "ClickTheViewSubmissionCmenuOption",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Move Down Option Of Channel.
        /// </summary>
        /// <param name="option">This is Course Channel Option</param>
        public void ClickOnChannelMoveDownOption(string option)
        {
            //Click On Move Down Option Of Channel
            logger.LogMethodEntry("TodaysViewUXPage", "ClickOnChannelMoveDownOption",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectTodaysViewWindow();
                base.WaitForElement(By.XPath(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_MoveDown_Option_Xpath_Locator));
                // Get Element Property
                IWebElement getMoveDownOption = base.GetWebElementPropertiesByXPath
                    (TodaysViewUXPageResource.
                    TodaysViewUXPageResource_MoveDown_Option_Xpath_Locator);
                //Perform Mouse Hover
                base.PerformMouseHoverByJavaScriptExecutor(getMoveDownOption);
                // Click Button
                base.ClickButtonByLinkText(option);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "ClickOnChannelMoveDownOption",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Window.
        /// </summary>
        private void SelectTodaysViewWindow()
        {
            //Select Window
            logger.LogMethodEntry("TodaysViewUXPage", "SelectTodaysViewWindow",
              base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(TodaysViewUXPageResource.
                TodaysViewUXPageResource_WindowsTitle);
            // Select Window
            base.SelectWindow(TodaysViewUXPageResource.
                TodaysViewUXPageResource_WindowsTitle);
            logger.LogMethodExit("TodaysViewUXPage", "SelectTodaysViewWindow",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Course Channel Name.
        /// </summary>
        /// <returns>Channel Name</returns>
        public String getCourseChannelName()
        {
            //Get Course Channel Name
            logger.LogMethodEntry("TodaysViewUXPage", "getCourseChannelName",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getChannelName = string.Empty;
            try
            {
                //Select Window
                this.SelectTodaysViewWindow();
                base.WaitForElement(By.XPath(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_Channel_Name_Xpath_Locator));
                // Get Channel Name
                getChannelName = base.GetElementTextByXPath(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_Channel_Name_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "getCourseChannelName",
              base.IsTakeScreenShotDuringEntryExit);
            return getChannelName;
        }

        /// <summary>
        /// Click On Course Channel Move Up Option.
        /// </summary>
        /// <param name="option">This is Course Channel Option</param>
        public void ClickOnCourseChannelMOveUpOption(string option)
        {
            //Click On Course Channel Move Up Option
            logger.LogMethodEntry("TodaysViewUXPage", "ClickOnCourseChannelMOveUpOption",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectTodaysViewWindow();
                base.WaitForElement(By.XPath(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_Channel_MoveUp_Option_Xpath_Locator));
                // Get Element Property
                IWebElement getOption = base.GetWebElementPropertiesByXPath(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_Channel_MoveUp_Option_Xpath_Locator);
                base.PerformMouseHoverByJavaScriptExecutor(getOption);
                // Click on Button
                base.ClickButtonByLinkText(option);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "ClickOnCourseChannelMOveUpOption",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Remove Calendar Channel.
        /// </summary>
        public void RemoveCalendarChannel()
        {
            //Remove Calendar Channel
            logger.LogMethodEntry("TodaysViewUXPage", "RemoveCalendarChannel",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectTodaysViewWindow();
                base.WaitForElement(By.XPath(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_Channel_Close_Button_Xpath_Locator));
                // Close Channel
                base.ClickButtonByXPath(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_Channel_Close_Button_Xpath_Locator);
                Thread.Sleep(Convert.ToInt32(TodaysViewUXPageResource.
                                                 TodaysViewUXPageResource_Sleep_Value));
                base.AcceptAlert();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "RemoveCalendarChannel",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Channels In Today's View Page
        /// </summary>
        /// <returns>Channels</returns>
        public String GetChannelsInTodaysView()
        {
            //Get Channels In Today's View Page
            logger.LogMethodEntry("TodaysViewUXPage", "GetChannelsInTodaysView",
              base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getChannels = string.Empty;
            try
            {
                //Get Calendar Text
                this.GetCalendarText();
                //Get Announcement Text
                this.GetAnnouncementText();
                //Get Notification Text
                this.GetNotificationsText();
                //Get Channels Text
                getChannels = this.GetCalendarText() + this.GetNotificationsText() + this.GetAnnouncementText();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "GetChannelsInTodaysView",
              base.IsTakeScreenShotDuringEntryExit);
            return getChannels;
        }

        /// <summary>
        /// Get Notification channel text In Today's View Page
        /// </summary>
        /// <returns>Notification channel Title</returns>
        public String GetNotificationsChannelTitle()
        {
            //Validate notification channel existance in Today's View Page
            logger.LogMethodEntry("TodaysViewUXPage", "GetChannelsInTodaysView",
              base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getChannels = string.Empty;
            try
            {
                //Get Channels Text
                getChannels = this.GetNotificationsText();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "GetChannelsInTodaysView",
              base.IsTakeScreenShotDuringEntryExit);
            return getChannels;
        }


        /// <summary>
        /// Get Notification Text
        /// </summary>
        /// <returns>Notification Text</returns>
        private String GetNotificationsText()
        {
            //Get Notification Text
            logger.LogMethodEntry("TodaysViewUXPage", "GetNotificationsText",
             base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getNotificationsText = string.Empty;
            //Get Notification Text
            bool isNotificationChannelPreset = base.IsElementPresent(By.Id(TodaysViewUXPageResource.
                TodaysViewUXPageResource_GetNotificationText_Id_Locator), 5);
            if (isNotificationChannelPreset)
            {
                getNotificationsText = base.GetElementTextById(TodaysViewUXPageResource.
                TodaysViewUXPageResource_GetNotificationText_Id_Locator);
            }
            else
            {
                getNotificationsText = base.GetElementTextById(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_MILGetNotificationText_Id_Locator);
            }
            logger.LogMethodExit("TodaysViewUXPage", "GetNotificationsText",
            base.IsTakeScreenShotDuringEntryExit);
            return getNotificationsText;
        }

        /// <summary>
        /// Get the activity count from Past due not
        /// submitted alert channel
        /// </summary>
        /// <returns>Activity count</returns>
        public int GetActivityCountFromPastDueNotSubmittedChannel()
        {

            //Get Alert count from Notification Channel
            logger.LogMethodEntry("TodaysViewUXPage", "GetActivityCountFromPastDueNotSubmittedChannel",
                                  base.IsTakeScreenShotDuringEntryExit);
            //Initialize Alert Variable
            int alertValue = 0;
            int totalCount = 0;
            try
            {
                //Get the number of student rows displayed in the past due not submitted channel
                alertValue = base.GetElementCountByXPath(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_PastDueNotSubmitted_ActivityCount_Xpath_Locator);
                //Initialize the counter
                for (int i = 2; i <= alertValue; i++)
                {
                    //Get the content count
                    int ContentCount = base.GetElementCountByXPath(
                        string.Format(TodaysViewUXPageResource.
                        TodaysViewUXPageResource_PastDueNotSubmitted_ActivityTotalCount_Xpath_Locator, i));
                    totalCount = totalCount + ContentCount;
                }
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "GetActivityCountFromPastDueNotSubmittedChannel",
                                base.IsTakeScreenShotDuringEntryExit);
            return totalCount;
        }


        /// <summary>
        /// Get Calendar Text
        /// </summary>
        /// <returns>Calendar Text</returns>
        private String GetCalendarText()
        {
            //Get Calendar Text
            logger.LogMethodEntry("TodaysViewUXPage", "GetCalendarText",
             base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getCalendarText = string.Empty;
            base.WaitForElement(By.Id(TodaysViewUXPageResource.
                TodaysViewPageResource_GetCalendarText_Id_Locator));
            //Get Calendar Text
            getCalendarText = base.GetElementTextById(TodaysViewUXPageResource.
                TodaysViewPageResource_GetCalendarText_Id_Locator);
            logger.LogMethodExit("TodaysViewUXPage", "GetCalendarText",
            base.IsTakeScreenShotDuringEntryExit);
            return getCalendarText;
        }

        /// <summary>
        /// Get Announcment Text
        /// </summary>
        /// <returns>Announcment Text</returns>
        private String GetAnnouncementText()
        {
            //Get Announcement Text
            logger.LogMethodEntry("TodaysViewUXPage", "GetAnnouncementText",
            base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getAnnouncementText = string.Empty;
            base.WaitForElement(By.Id(TodaysViewUXPageResource.
                TodaysViewPageReosurce_GetAnnouncementText_Id_Locator));
            //Get Announcement Text
            getAnnouncementText = base.GetElementTextById(TodaysViewUXPageResource.
                TodaysViewPageReosurce_GetAnnouncementText_Id_Locator);
            logger.LogMethodExit("TodaysViewUXPage", "GetAnnouncementText",
            base.IsTakeScreenShotDuringEntryExit);
            return getAnnouncementText;
        }

        /// <summary>
        /// Click On FeedBack Link
        /// </summary>
        public void ClickOnFeedBackLink()
        {
            //Click On FeedBack Link
            logger.LogMethodEntry("TodaysViewUXPage", "ClickOnFeedBackLink",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Today's View Window
                this.SelectWindow();
                base.WaitForElement(By.Id(TodaysViewUXPageResource.
                    TodayViewUXPageResource_Feedback_Id_Locator));
                //Get Feedback Property
                IWebElement getFeedBackProperty = base.
                    GetWebElementPropertiesById(TodaysViewUXPageResource.
                    TodayViewUXPageResource_Feedback_Id_Locator);
                //Click On Feedback
                base.ClickByJavaScriptExecutor(getFeedBackProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "ClickOnFeedBackLink",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Resource Tool From Tools Dropdown.
        /// </summary>
        /// <param name="resourceToolsTypeEnum">This is Resource Tool Type Enum.</param>
        public void SelectResourceToolFromToolsDropdown(
            ResourceToolsTypeEnum resourceToolsTypeEnum)
        {
            //Select Resource Tool From Tools Dropdown
            logger.LogMethodEntry("TodaysViewUXPage", "SelectResourceToolFromToolsDropdown",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectTodaysViewWindow();
                switch (resourceToolsTypeEnum)
                {
                    case ResourceToolsTypeEnum.Glossary:
                        //Select 'Glossary' Option In Tools Dropdown
                        this.SelectGlossaryOptionInToolsDropdown();
                        break;
                    case ResourceToolsTypeEnum.VerbChart:
                        //Select 'VerbChart' Option In Tools Dropdown
                        this.SelectVerbChartOptionInToolsDropdown();
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "SelectResourceToolFromToolsDropdown",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Tutorials Option In Tools Dropdown.
        /// </summary>
        private void SelectVerbChartOptionInToolsDropdown()
        {
            //Select Verb Chart Option In Tools Dropdown
            logger.LogMethodEntry("TodaysViewUXPage",
                "SelectVerbChartOptionInToolsDropdown",
            base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(TodaysViewUXPageResource.
                TodayViewUXPageResource_Tools_Dropdown_Id_Locator));
            //Click On Tools Dropdown
            base.ClickButtonById(TodaysViewUXPageResource.
                TodayViewUXPageResource_Tools_Dropdown_Id_Locator);
            base.WaitForElement(By.Id(TodaysViewUXPageResource.
                TodayViewUXPageResource_VerbChart_Image_Id_Locator));
            //Click On Verb Chart Option
            base.ClickLinkById(TodaysViewUXPageResource.
                TodayViewUXPageResource_VerbChart_Image_Id_Locator);
            logger.LogMethodExit("TodaysViewUXPage",
                "SelectVerbChartOptionInToolsDropdown",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Glossary Option In Tools Dropdown.
        /// </summary>
        private void SelectGlossaryOptionInToolsDropdown()
        {
            //Select Glossary Option In Tools Dropdown
            logger.LogMethodEntry("TodaysViewUXPage",
                "SelectGlossaryOptionInToolsDropdown",
            base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(TodaysViewUXPageResource.
                TodayViewUXPageResource_Tools_Dropdown_Id_Locator));
            //Click On Tools Dropdown
            base.ClickButtonById(TodaysViewUXPageResource.
                TodayViewUXPageResource_Tools_Dropdown_Id_Locator);
            base.WaitForElement(By.Id(TodaysViewUXPageResource.
                TodayViewUXPageResource_Glossary_Image_Id_Locator));
            //Click On Glossary Option
            base.ClickLinkById(TodaysViewUXPageResource.
                TodayViewUXPageResource_Glossary_Image_Id_Locator);
            logger.LogMethodExit("TodaysViewUXPage",
                "SelectGlossaryOptionInToolsDropdown",
            base.IsTakeScreenShotDuringEntryExit);
        }
       
        /// <summary>
        /// Select My Progress Button
        /// </summary>
        public void SelectMyProgressOption()
        {
            //Select My Progress Button
            logger.LogMethodEntry("TodaysViewUXPage",
                "SelectMyProgressOption", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.LinkText(TodaysViewUXPageResource.
                       TodayViewUXPageResource_Myprogress_Link_Locator));
                //Get MyProgress Button Property
                IWebElement getMyProgressButtonProperty = base.GetWebElementPropertiesByLinkText(
                    TodaysViewUXPageResource.TodayViewUXPageResource_Myprogress_Link_Locator);
                base.ClickByJavaScriptExecutor(getMyProgressButtonProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage",
                "SelectMyProgressOption", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Cmenu Option of Activity
        /// </summary>
        /// <param name="assetName">This is Asset Name</param>
        public void ClickOnCmenuOptionOfAsset(String assetName)
        {
            //Click On Cmenu Option of Activity
            logger.LogMethodEntry("TodaysViewUXPage", "ClickOnCmenuOptionOfAsset", 
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getActivityName = string.Empty;
            try
            {
                base.WaitForElement(By.XPath(TodaysViewUXPageResource.
                        TodayViewUXPageResource_AssetCount_Xpath_Locator));
                //Get Asset Count
                int assetCount = base.GetElementCountByXPath(TodaysViewUXPageResource.
                    TodayViewUXPageResource_AssetCount_Xpath_Locator);
                for (int initialCount = Convert.ToInt32(TodaysViewUXPageResource.
                    TodayViewUXPageResource_Asset_InitialValue); initialCount <= assetCount; initialCount++)
                {
                    base.WaitForElement(By.XPath(string.Format(TodaysViewUXPageResource.
                        TodayViewUXPageResource_GetActivityName_Xpath_Locator, initialCount)));
                    //Get Activity Name
                    getActivityName = base.GetElementTextByXPath(string.Format(TodaysViewUXPageResource.
                        TodayViewUXPageResource_GetActivityName_Xpath_Locator, initialCount));
                    if (getActivityName == assetName)
                    {
                        IWebElement getActivityProperty = base.GetWebElementPropertiesByXPath
                            (string.Format(TodaysViewUXPageResource.
                            TodayViewUXPageResource_GetActivityName_Xpath_Locator, initialCount));
                        //Perform Mouse Hover
                        base.PerformMouseHoverByJavaScriptExecutor(getActivityProperty);
                        //Get Cmenu Property
                        IWebElement getCmenubuttonProperty = base.GetWebElementPropertiesByClassName(
                            TodaysViewUXPageResource.TodayViewUXPageResource_AssetCmenu_ClassName_Locator);
                        //Click On Cmenu
                        base.ClickByJavaScriptExecutor(getCmenubuttonProperty);
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "ClickOnCmenuOptionOfAsset", 
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Cmenu Option of Asset
        /// </summary>
        /// <param name="cmenuOption">This is Cmenu Option</param>
        public void SelectCmenuOption(string cmenuOption)
        {
            //Select Cmenu  Option of Asset
            logger.LogMethodEntry("TodaysViewUXPage", "SelectCmenuOption",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait fot Cmenu Option
                base.WaitForElement(By.PartialLinkText(cmenuOption));
                //Get Link Text Property
                IWebElement getLinkTextProperty = base.GetWebElementPropertiesByPartialLinkText(cmenuOption);
                //Click On Link Text
                base.ClickByJavaScriptExecutor(getLinkTextProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "SelectCmenuOption",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Support Link.
        /// </summary>
        public void ClickonSupportLink()
        {
            //Click on Support Link
            logger.LogMethodEntry("TodaysViewUXPage", "ClickonSupportLink",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Today's View Window
                this.SelectWindow();
                //Click on Support Link
                base.WaitForElement(By.Id(TodaysViewUXPageResource.
                    TodayViewUXPageResource_SupportLink_Id_Locator));
                IWebElement getSupportLink =
                    base.GetWebElementPropertiesById(TodaysViewUXPageResource.
                    TodayViewUXPageResource_SupportLink_Id_Locator);
                base.ClickByJavaScriptExecutor(getSupportLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "ClickonSupportLink", 
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Writingspace Assessment In NewGrades.
        /// </summary>
        /// <param name="writingSpaceAssessmentName">This is Writingspace Assessment Name.</param>
        /// <returns>Writingspace Assessment.</returns>
        public String GetWritingspaceAssessmentInNewGrades(string writingSpaceAssessmentName)
        {
            //Get Writingspace Assessment In NewGrades
            logger.LogMethodEntry("TodaysViewUXPage", "GetWritingspaceAssessmentInNewGrades",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getWritingspaceAssessment = string.Empty;            
            try
            {
                Thread.Sleep(Convert.ToInt32(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_Sleep_Value));          
                //Get Writingspace Asset Name
                getWritingspaceAssessment = new ContentLibraryUXPage().
                    GetTheDisplayOfActivityName(writingSpaceAssessmentName,
                    TodaysViewUXPageResource.
                    TodayViewUXPageResource_Instructor_NewGrades_Assets_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "GetWritingspaceAssessmentInNewGrades",
                base.IsTakeScreenShotDuringEntryExit);
            return getWritingspaceAssessment;
        }

        /// <summary>
        /// Get Assessment In Course Performance Channel.
        /// </summary>
        /// <param name="assessmentName">This is Asset Name.</param>
        /// <returns>Writingspace Assessment in Course Performance Channel.</returns>
        public String GetAssessmentInCoursePerformance(string assessmentName)
        {
            //Get Assessment In Course Performance Channel
            logger.LogMethodEntry("TodaysViewUXPage",
                "GetAssessmentInCoursePerformance",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getAssessmentinCoursePerformance = string.Empty;            
            try
            {              
                //Get Writingspace Asset Name
                getAssessmentinCoursePerformance = new ContentLibraryUXPage().
                    GetTheDisplayOfActivityName(assessmentName,
                    TodaysViewUXPageResource.
                    TodayViewUXPageResource_Instructor_CoursePerformance_Assets_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage",
                "GetAssessmentInCoursePerformance",
                base.IsTakeScreenShotDuringEntryExit);
            return getAssessmentinCoursePerformance;
        }

        /// <summary>
        /// Click on Notification Channel Option.
        /// </summary>
        /// <param name="channelOption">This is Channel option.</param>
        public void ClickonNotificationChannelOption(string channelOption)
        {
            //Click on Performance Channel Option
            logger.LogMethodEntry("TodaysViewUXPage", "ClickonPerformanceChannelOption",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.WaitForElement(By.PartialLinkText(channelOption));
                //Click on Performance Channel Option
                IWebElement getPerformanceChannelOption =
                    base.GetWebElementPropertiesByPartialLinkText(channelOption);
                base.ClickByJavaScriptExecutor(getPerformanceChannelOption);
                Thread.Sleep(Convert.ToInt32(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_Sleep_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "ClickonPerformanceChannelOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fetch overall grade displayed in
        /// Student performance channel.
        /// </summary>
        /// <returns>Overall Grade.</returns>
        public string GetGradeFromStudentPerformanceChannel(string channelName)
        {
            //Get Alert count from Notification Channel
            logger.LogMethodEntry("TodaysViewUXPage", "GetGradeFromStudentPerformanceChannel",
                                  base.IsTakeScreenShotDuringEntryExit);
            //Initialize variable
            string gradeValue = string.Empty;
            try
            {
                //Get the overall grade from Weather Map channels.
                switch (channelName)
                {
                    case "Student Performance":
                        //Get overall grade from Student performance channel
                        gradeValue = base.GetElementTextByXPath(TodaysViewUXPageResource.
                     TodaysViewUXPageResource_StudentPerformanceChannel_OverallGrade_Xpath_Locator);
                        break;

                    case "My Progress":
                        //Get overall grade from My progress channel
                        gradeValue = base.GetElementTextByXPath(TodaysViewUXPageResource.
                     TodaysViewUXPageResource_MyProgressChannel_OverallGrade_Xpath_Locator);
                        break;
                }

            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("TodaysViewUXPage", "GetGradeFromStudentPerformanceChannel",
                             base.IsTakeScreenShotDuringEntryExit);
            return gradeValue;
        }

        /// <summary>
        /// Click on cmenu icon of the Discussion topic.
        /// </summary>
        /// <param name="assetName">Name of the discussion topic for which system has to click on cmenu icon.</param>
        public void ClickOnCmenuIconOfDiscussionTopic(string assetName)
        {
            //Click On Cmenu Option of Activity
            logger.LogMethodEntry("TodaysViewUXPage", "ClickOnCmenuIconOfDiscussionTopic",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getDiscussionTopicName = string.Empty;
            try
            {
                base.WaitForElement(By.XPath(TodaysViewUXPageResource.
                        TodaysViewUXPageResource_GetDiscussionTopicCount_Xpath_Locator));
                //Get Asset Count
                int assetCount = base.GetElementCountByXPath(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_GetDiscussionTopicCount_Xpath_Locator);
                //Initialize the counter to find the discussion topic and click on the cmenu of it
                for (int initialCount = 1; initialCount <= assetCount; initialCount++)
                {
                    //Wait for the discussion topic name
                    base.WaitForElement(By.XPath(string.Format(TodaysViewUXPageResource.
                        TodaysViewUXPageResource_GetDiscussionTopicName_Xpath_Locator, initialCount)));

                    //Get Activity Name
                    getDiscussionTopicName = base.GetElementTextByXPath(string.Format(TodaysViewUXPageResource.
                         TodaysViewUXPageResource_GetDiscussionTopicName_Xpath_Locator, initialCount));
                    string[] discussionTopicNameSplitValue = getDiscussionTopicName.Split(new string[] { "..." }, StringSplitOptions.None);
                    string discussionTopicName = discussionTopicNameSplitValue[0].Trim();
                    if (assetName.Contains(discussionTopicName))
                    {
                        IWebElement getActivityProperty = base.GetWebElementPropertiesByXPath
                            (string.Format(TodaysViewUXPageResource.
                            TodaysViewUXPageResource_GetDiscussionTopicName_Xpath_Locator, initialCount));
                        //Perform Mouse Hover
                        base.PerformMouseHoverByJavaScriptExecutor(getActivityProperty);
                        //Get Cmenu Property
                        IWebElement getCmenubuttonProperty = base.GetWebElementPropertiesByClassName(
                            TodaysViewUXPageResource.TodayViewUXPageResource_AssetCmenu_ClassName_Locator);
                        //Click On Cmenu
                        base.ClickByJavaScriptExecutor(getCmenubuttonProperty);
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "ClickOnCmenuIconOfDiscussionTopic",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Get student first, last name
        /// from Past due submitted channel.
        /// </summary>
        /// <returns>Student first, last name.</returns>
        public string GetStudentNameFromPastDueSubmittedChannel()
        {
            string studentName = string.Empty;
            //Get Student First name, Last name displayed in unread messages channel
            logger.LogMethodEntry("TodaysViewUXPage", "GetStudentNameFromPastDueSubmittedChannel",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get the Student First name, Last name and store it in the variable
                studentName = base.GetElementInnerTextById
                    (TodaysViewUXPageResource.TodayViewUXPageResource_PastDueSubmitted_StudentName_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("TodaysViewUXPage", "GetStudentNameFromPastDueSubmittedChannel",
               base.IsTakeScreenShotDuringEntryExit);
            return studentName;
        }

        /// <summary>
        /// Click on student expand icon
        /// in Past due submitted channel.
        /// </summary>
        public void ClickonExpandIconInPastDueSubmittedChannel()
        {
            //Click on the student name in unread messages channel
            logger.LogMethodEntry("TodaysViewUXPage", "ClickonExpandIconInPastDueSubmittedChannel",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Click on Expand icon displayed for student
                base.ClickLinkByXPath(TodaysViewUXPageResource.
                TodaysViewUXPageResource_ExpandIcon_PastDueSubmitted_Xpath_Locator);
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("TodaysViewUXPage", "ClickonExpandIconInPastDueSubmittedChannel",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Past due submitted activity name.
        /// </summary>
        /// <returns>Activity name.</returns>
        public string GetActivityNameInPastDueSubmittedChannel()
        {

            //Click on the student name in unread messages channel
            logger.LogMethodEntry("TodaysViewUXPage", "GetActivityNameInPastDueSubmittedChannel",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize string variable which holds the activity name
            string activityName = string.Empty;
            string pastDueActivityName = string.Empty;
            try
            {
                //Get the activity name by Xpath
                activityName = base.GetElementInnerTextByXPath(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_ActivityName_PastDueSubmitted_Xpath_Locator);
                //Split the obtained string to get only required activity name
                string[] activityName_splitValue = activityName.Split(new string[] { "Due" }, StringSplitOptions.None);
                pastDueActivityName = activityName_splitValue[0].Trim();
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("TodaysViewUXPage", "GetActivityNameInPastDueSubmittedChannel",
              base.IsTakeScreenShotDuringEntryExit);
            return pastDueActivityName;
        }



        /// <summary>
        /// Get content count from alert channel.
        /// </summary>
        /// <param name="channelName">Alert channel name.</param>
        /// <returns>Content count</returns>
        public int GetCountFromAlertChannels(string channelName)
        {
            //Get content count from alert channel
            logger.LogMethodEntry("TodaysViewUXPage", "GetCountFromAlertChannels",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize variable
            int ContentCount = 0;
            try
            {
                //Switch to alert channel based on the input paramater passed
                switch (channelName)
                {
                    case "Not Passed":
                        ContentCount = GetContentCountFromAlertChannel(TodaysViewUXPageResource.
                            TodaysViewUXPageResource_NotPassedChannel_ActivityRow_Id_Locator);
                        break;
                    case "Unread Messages":
                        ContentCount = GetContentCountFromAlertChannel(TodaysViewUXPageResource.
                            TodaysViewPageResource_GetMessagesCount_Xpath_Locator);
                        break;
                    case "Idle Students":
                        ContentCount = GetContentCountFromAlertChannel(TodaysViewUXPageResource.
                            TodaysViewUXPageResource_GetIdleStudentCount_Xpath_Locator);
                        break;
                    case "Unread Discussion":
                        ContentCount = GetContentCountFromAlertChannel(TodaysViewUXPageResource.
                            TodaysViewUXPageResource_GetDiscussionTopicCount_Xpath_Locator);
                        break;
                }

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "GetCountFromAlertChannels",
                base.IsTakeScreenShotDuringEntryExit);

            return ContentCount;
        }

        /// <summary>
        /// Get student first, last name
        /// from Idle student alert channel.
        /// </summary>
        /// <returns>Student irst, last name.</returns>
        public string GetStudentNameFromIdleStudents()
        {
            string StudentName = string.Empty;
            //Get Student First name, Last name displayed in unread messages channel
            logger.LogMethodEntry("TodaysViewUXPage", "GetStudentNameFromUnreadMessages",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Call the method to get the student first, last name and store it
                StudentName = GetStudentNameFromAlertChannel(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_StudentName_IdleStudents_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("TodaysViewUXPage", "GetStudentNameFromUnreadMessages",
               base.IsTakeScreenShotDuringEntryExit);
            return StudentName;
        }

        /// <summary>
        /// Get student first, last name
        /// from alert channels.
        /// </summary>
        /// <param name="studentNamePath">Student name xpath.</param>
        /// <returns>Student first, last name.</returns>
        private string GetStudentNameFromAlertChannel(string studentNamePath)
        {
            string StudentName = string.Empty;
            //Get Student First name, Last name displayed in unread messages channel
            logger.LogMethodEntry("TodaysViewUXPage", "GetStudentNameFromAlertChannel",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get the Student First name, Last name and store it in the variable
                StudentName = base.GetElementInnerTextByXPath(studentNamePath).Trim();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("TodaysViewUXPage", "GetStudentNameFromAlertChannel",
               base.IsTakeScreenShotDuringEntryExit);
            return StudentName;
        }

        /// <summary>
        /// Get Content count 
        /// from Alert Channel.
        /// </summary>
        /// <returns>Content count.</returns>
        private int GetContentCountFromAlertChannel(string LocatorPath)
        {
            int ContentCount = 0;
            //Get activity count displayed from Not Passed Channel
            logger.LogMethodEntry("TodaysViewUXPage", "GetContentCountInNotPassedAlertChannel",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get Activity Count
                ContentCount = base.GetElementCountByXPath(LocatorPath);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("TodaysViewUXPage", "GetContentCountInNotPassedAlertChannel",
                base.IsTakeScreenShotDuringEntryExit);
            return ContentCount;
        }

        /// <summary>
        /// Get Assessment In Student Performance Channel.
        /// </summary>
        /// <param name="assessmentName">This is Asset Name.</param>
        /// <param name="mmndStudentName">This is MMND Student First Name.</param>
        /// <returns>Writingspace Assessment in Student Performance Channel.</returns>
        public String GetAssessmentInStudentPerformance(
            string assessmentName, string mmndStudentFirstName)
        {
            //Get Assessment In Student Performance Channel
            logger.LogMethodEntry("TodaysViewUXPage", "GetAssessmentInStudentPerformance",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getAssessmentinStudentPerformance = string.Empty;            
            try
            {
                //Wait for the element
                base.WaitForElement(By.PartialLinkText(mmndStudentFirstName));
                //Click on Student Name
                IWebElement getMMNDStudentName =
                    base.GetWebElementPropertiesByPartialLinkText(mmndStudentFirstName);
                base.ClickByJavaScriptExecutor(getMMNDStudentName);
                Thread.Sleep(Convert.ToInt32(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_Sleep_Value));
                //Get Writingspace Asset Name
                getAssessmentinStudentPerformance = new ContentLibraryUXPage().
                    GetTheDisplayOfActivityName(assessmentName,
                    TodaysViewUXPageResource.
                    TodayViewUXPageResource_Instructor_StudentPerformance_Assets_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "GetAssessmentInStudentPerformance",
                base.IsTakeScreenShotDuringEntryExit);
            return getAssessmentinStudentPerformance;
        }

        /// <summary>
        /// Get Writingspace Assessment In NewGrades For Student.
        /// </summary>
        /// <param name="writingSpaceAssessmentName">
        /// This is Writingspace Assessment Name.</param>
        /// <returns>Writingspace Assessment.</returns>
        public String GetWritingspaceAssessmentInNewGradesForStudent(
            string writingSpaceAssessmentName)
        {
            //Get Writingspace Assessment In NewGrades For Student
            logger.LogMethodEntry("TodaysViewUXPage",
                "GetWritingspaceAssessmentInNewGradesForStudent",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize String Variables
            string getWritingspaceAssessment = string.Empty;            
            try
            {                
                //Get Writingspace Asset Name
                getWritingspaceAssessment = new ContentLibraryUXPage().
                    GetTheDisplayOfActivityName(writingSpaceAssessmentName,
                    TodaysViewUXPageResource.
                    TodayViewUXPageResource_AssetsName_Newgrades_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage",
                "GetWritingspaceAssessmentInNewGradesForStudent",
                base.IsTakeScreenShotDuringEntryExit);
            return getWritingspaceAssessment;
        }

        /// <summary>
        /// Get Writingspace Assessment In MyProgress For Student.
        /// </summary>
        /// <param name="assetName">This is Asset Name.</param>
        /// <returns>Writingspace Assessment in My Progress Channel.</returns>
        public String GetWritingspaceAssessmentInMyProgress(string assetName)
        {
            //Get Writingspace Assessment In MyProgress For Student
            logger.LogMethodEntry("TodaysViewUXPage",
                "GetWritingspaceAssessmentInMyProgress",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getAssessmentinMyProgress = string.Empty;            
            try
            {                
                //Get Writingspace Asset Name
                getAssessmentinMyProgress = new ContentLibraryUXPage().
                    GetTheDisplayOfActivityName(assetName,
                    TodaysViewUXPageResource.
                    TodayViewUXPageResource_AssetsName_MyProgress_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage",
                "GetWritingspaceAssessmentInMyProgress",
                base.IsTakeScreenShotDuringEntryExit);
            return getAssessmentinMyProgress;
        }

        /// <summary>
        /// Select Window and Frame.
        /// </summary>
        public void selectwindowandFrame()
        {
            logger.LogMethodEntry("TodaysViewUXPage",
                "selectwindowandFrame",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitUntilWindowLoads(TodaysViewUXPageResource.
                       TodayViewUXPageResource_Classes_Window_Name);
                //Select Window
                base.SelectWindow(TodaysViewUXPageResource.
                    TodayViewUXPageResource_Classes_Window_Name);
                base.WaitForElement(By.Id(TodaysViewUXPageResource.
                    TodayViewUXPageResource_Outer_Frame_Id_Locator));
                //Switch to Frame
                base.SwitchToIFrame(TodaysViewUXPageResource.
                    TodayViewUXPageResource_Outer_Frame_Id_Locator);
                base.WaitForElement(By.Id(TodaysViewUXPageResource.
                    TodayViewUXPageResource_Gradebook_Frame_Id_Locator));
                //Switch to Gradebook Frame
                base.SwitchToIFrame(TodaysViewUXPageResource.
                    TodayViewUXPageResource_Gradebook_Frame_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage",
                "selectwindowandFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Link In More Dropdown.
        /// </summary>
        /// <param name="linkName">This is Link Name.</param>
        public void ClickLinkInMoreDropdown(string linkName)
        {
            //Click Link In More Dropdown
            logger.LogMethodEntry("GBInstructorUXPage", "ClickLinkInMoreDropdown",
                         base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string tabName = string.Empty;
            try
            {
                //Click on More Link
                this.ClickonMoreLink();
                //Wait for More link
                base.WaitForElement(By.XPath(TodaysViewUXPageResource.
                    TodayViewUXPageResource_LinkCount_Xpath_Locator));
                //Get the link counts in More drop down
                int getLinkCount = base.GetElementCountByXPath(TodaysViewUXPageResource.
                    TodayViewUXPageResource_LinkCount_Xpath_Locator);
                for (int i = Convert.ToInt32(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_Page_Initial_Value); i <= getLinkCount; i++)
                {                    
                    //Get tab name
                    tabName = base.GetElementTextByXPath(string.Format
                        (TodaysViewUXPageResource.
                        TodayViewUXPageResource_LinkName_Xpath_Locator, i));
                    //Check if the tab name found is matching with expected tab name
                    if (tabName.Contains(linkName))
                    {
                        //Click on the tab name
                        IWebElement TabClick = base.GetWebElementPropertiesByXPath(
                            string.Format(TodaysViewUXPageResource.
                        TodayViewUXPageResource_LinkName_Xpath_Locator, i));
                        base.ClickByJavaScriptExecutor(TabClick);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorUXPage", "ClickLinkInMoreDropdown",
                          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on More Link.
        /// </summary>
        private void ClickonMoreLink()
        {
            //Click on More Link
            logger.LogMethodEntry("GBInstructorUXPage", "ClickonMoreLink",
                         base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(TodaysViewUXPageResource.
                TodayViewUXPageResource_Classes_Window_Name);
            //Select Classes Window
            base.SelectWindow(TodaysViewUXPageResource.
                TodayViewUXPageResource_Classes_Window_Name);
            base.WaitForElement(By.Id(TodaysViewUXPageResource.
                TodayViewUXPageResource_MoreLink_Id_Locator));
            //Click on More Link
            IWebElement moreLink = base.GetWebElementPropertiesById(TodaysViewUXPageResource.
                TodayViewUXPageResource_MoreLink_Id_Locator);
            base.ClickByJavaScriptExecutor(moreLink);
            logger.LogMethodExit("GBInstructorUXPage", "ClickonMoreLink",
                          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Launch PCT From ToolBar.
        /// </summary>
        public void OpenPCTToolsDropDown()
        {
            //Launch PCT From Resource ToolBar.
            logger.LogMethodEntry("TodaysViewUXPage", "OpenPCTToolsDropDown",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // wait for xpath element for PCT DropDown
                WaitForElement(By.XPath(TodaysViewUXPageResource.
                    TodayViewUXPageResource_PCTInstructorResourceDropDown));
                // Gets PCT Tools drop down element object
                IWebElement ToolsDropDown = base.GetWebElementPropertiesByXPath(TodaysViewUXPageResource.
                    TodayViewUXPageResource_PCTInstructorResourceDropDown);
                base.ClickByJavaScriptExecutor(ToolsDropDown);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "OpenPCTToolsDropDown"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Launch PCT From ToolBar.
        /// </summary>
        public void LaunchPCTFromDropDown(string PCTToolName)
        {
            //Launch PCT From Resource ToolBar
            logger.LogMethodEntry("TodaysViewUXPage", "LaunchPCTFromDropDown",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // wait for xpath element for PCT Link
                WaitForElement(By.XPath(TodaysViewUXPageResource.
                    TodayViewUXPageResource_PCTInstructorResourceToolLink + "=" + "'" + PCTToolName + "'" + "]"));
                // Gets PCT Link element object from drop down
                IWebElement ResourceToolLaunch1 = base.GetWebElementPropertiesByXPath(TodaysViewUXPageResource.
                    TodayViewUXPageResource_PCTInstructorResourceToolLink + "=" +"'"+ PCTToolName +"'"+ "]");
                // Perform mouse hover action over the PCT Tool Link
                base.PerformMouseHoverAction(ResourceToolLaunch1);
                // Click on the PCT Tool Link
                base.ClickByJavaScriptExecutor(ResourceToolLaunch1);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "LaunchPCTFromDropDown"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get PCT Window Width.
        /// </summary>
        public int GetPCTWindowWidth()
        {
            // Get current PCT window width
            logger.LogMethodEntry("TodaysViewUXPage", "GetPCTWindowWidth"
                , base.IsTakeScreenShotDuringEntryExit);

            int windowWidth = 0;
            try
            {
                windowWidth = base.GetCurrentOpenWindowSize().Width;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "GetPCTWindowWidth"
                , base.IsTakeScreenShotDuringEntryExit);
            return windowWidth;
        }

        /// <summary>
        /// Get PCT Window Height.
        /// </summary>
        public int GetPCTWindowHeight()
        {
            // Get current PCT window height
            logger.LogMethodEntry("TodaysViewUXPage", "GetPCTWindowHeight"
                , base.IsTakeScreenShotDuringEntryExit);

            int windowHeight = 0;
            try
            {
                windowHeight = base.GetCurrentOpenWindowSize().Height;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "GetPCTWindowHeight"
                , base.IsTakeScreenShotDuringEntryExit);
            return windowHeight;
        }

        /// <summary>
        /// Select Tab.
        /// </summary>
        /// <param name="parentTabName">This is Parent Tab Name.</param>
        /// <param name="childTabName">This is Child Tab Name.</param>
        public void SelectTab(string parentTabName,
            string childTabName = "Default Value")
        {
            //Navigate to Tab
            logger.LogMethodEntry("TodaysViewUXPage", "SelectTab",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the CourseSpace User MainTab
                this.SelectCourseSpaceUserMainTab(parentTabName);
                if (childTabName != "Default Value")
                {
                    //Get Subtab Counts
                    base.WaitForElement(By.XPath(TodaysViewUXPageResource.
                        TodayViewUXPageResource_Subtab_Count_Xpath_Locator));
                    //Get Tab Count
                    int getSubTabCount = base.GetElementCountByXPath(TodaysViewUXPageResource.
                        TodayViewUXPageResource_Subtab_Count_Xpath_Locator);
                    for (int csTabCountNo = Convert.ToInt32(
                        TodaysViewUXPageResource.TodaysViewUXPageResource_Page_Initial_Value);
                        csTabCountNo <= getSubTabCount; csTabCountNo++)
                    {
                        IWebElement getSelectedTabElement = base.GetWebElementPropertiesByXPath
                            (String.Format(TodaysViewUXPageResource.
                                    TodayViewUXPageResource_Subtab_Classname_Xpath_Locator, csTabCountNo));
                        if (getSelectedTabElement.Text == childTabName)
                        {
                            string getClassName = getSelectedTabElement.
                                          GetAttribute(TodaysViewUXPageResource.
                               TodayViewUXPageResource_GetClass_Value);
                            if (getClassName == TodaysViewUXPageResource.
                                             TodayViewUXPageResource__SubTab_SelectedTab_Value)
                            {
                                break;
                            }
                            else
                            {
                                //Select The Tab
                                this.ClickonTab(childTabName);
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "SelectTab",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select MainTab.
        /// </summary>
        /// <param name="mainTabName">This is Main Tab Name.</param>
        private void SelectCourseSpaceUserMainTab(string mainTabName)
        {
            //Select MainTab
            logger.LogMethodEntry("TodaysViewUXPage", "SelectCourseSpaceUserMainTab",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the MainTab
            base.WaitForElement(By.PartialLinkText(mainTabName));
            //Get Tab Property
            string getTabClassAttribute =
                base.GetClassAttributeValueByPartialLinkText(mainTabName);
            if (getTabClassAttribute ==
                TodaysViewUXPageResource.TodayViewUXPageResource_MainTab_SelectedTab_Value)
            {
                //Select Window
                base.SelectWindow(base.GetPageTitle);
            }
            else
            {
                //Select The Tab
                this.ClickonTab(mainTabName);
            }
            logger.LogMethodExit("TodaysViewUXPage", "SelectCourseSpaceUserMainTab",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Tab.
        /// </summary>
        /// <param name="tabName">This is Tab Name.</param>
        private void ClickonTab(string tabName)
        {
            //Click on Tab
            logger.LogMethodEntry("TodaysViewUXPage", "ClickonTab",
                base.IsTakeScreenShotDuringEntryExit);
            //Click On More Link if More Link Is Present
            //And The Required Tab Is Not Present
            new TodaysViewUXPage().ClickTheMoreLinkIfPresent(tabName);
            //Wait For Element
            base.WaitForElement(By.PartialLinkText(tabName));
            //Get Tab Element Property
            IWebElement getTabNameProperty = base.
                GetWebElementPropertiesByPartialLinkText(tabName);
            //Click on Tab 
            base.ClickByJavaScriptExecutor(getTabNameProperty);
            logger.LogMethodExit("TodaysViewUXPage", "ClickonTab",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To The Publishing Tab.
        /// </summary>
        /// <param name="subtabName">This is Subtab Name.</param>
        /// <param name="mainTabName">This is Maintab Name.</param>
        public void NavigateToThePublishingTab(string subtabName, string mainTabName)
        {
            //Navigate To The Publishing Tab
            logger.LogMethodEntry("TodaysViewUXPage", "NavigateToThePublishingTab",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                string pageTitle = base.GetPageTitle;
                if (pageTitle != TodaysViewUXPageResource.TodayViewUXPageResource_ManagePrograms_Tab_Name
                    && pageTitle != TodaysViewUXPageResource.TodayViewUXPageResource_ManageProducts_Tab_Name)
                {
                    base.SelectWindow(pageTitle);
                    IWebElement mainTabNameElement =
                        base.GetWebElementPropertiesByPartialLinkText(mainTabName);
                    //Click on the 'publishing' tab
                    base.ClickByJavaScriptExecutor(mainTabNameElement);
                    Thread.Sleep(Convert.ToInt32(TodaysViewUXPageResource.
                        TodayViewUXPageResource_ElementWaitTimeOut_Value));
                }
                string getPublishingPageTitle = base.GetPageTitle;
                base.SelectWindow(getPublishingPageTitle);
                //Get Seleted Tab Name
                string getSelectorTab = this.GetSubtabValue(subtabName);
                IWebElement selectedTabElement = base.GetWebElementPropertiesById(getSelectorTab);
                //Get Seleted Tab Class value
                string getClassName = selectedTabElement.GetAttribute(TodaysViewUXPageResource.
                    TodayViewUXPageResource_GetClass_Value);
                if (getClassName == TodaysViewUXPageResource.TodayViewUXPageResource__SubTab_SelectedTab_Value)
                {
                    base.SelectWindow(subtabName);
                }
                else
                {
                    //Wait for the element
                    base.WaitForElement(By.PartialLinkText(subtabName));
                    IWebElement subtabNameElement =
                        base.GetWebElementPropertiesByPartialLinkText(subtabName);
                    //Click the subtab
                    base.ClickByJavaScriptExecutor(subtabNameElement);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage", "NavigateToThePublishingTab",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Subtab Value.
        /// </summary>
        /// <param name="SubtabName">Get the SubTab.</param>
        /// <returns>Return selector tab Id.</returns>
        private String GetSubtabValue(string SubtabName)
        {
            //Navigate Administrator Tool Page
            logger.LogMethodEntry("TodaysViewUXPage", "GetSubtabValue",
                base.IsTakeScreenShotDuringEntryExit);
            //Intialize the variable
            String getSubTabId = String.Empty;
            switch (SubtabName)
            {
                case "Manage Programs":
                    getSubTabId = TodaysViewUXPageResource.
                        TodayViewUXPageResource_ManageProgramsTab_Value;
                    break;
                case "Manage Products":
                    getSubTabId = TodaysViewUXPageResource.
                        TodayViewUXPageResource_ManageProductsTab_Value;
                    break;
            }
            logger.LogMethodExit("TodaysViewUXPage", "GetSubtabValue",
               base.IsTakeScreenShotDuringEntryExit);
            return getSubTabId;
        }

        /// <summary>
        /// Get Instructor Comments channel text In Today's View Page.
        /// </summary>
        /// <returns>Notification channel Title.</returns>
        public String GetInstructorCommentsChannelTitle(string channelName)
        {
            //Validate Instructor Comments channel existance in Today's View Page
            logger.LogMethodEntry("TodaysViewUXPage", 
                "GetInstructorCommentsChannelTitle",
              base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getInstructorCommentsText = string.Empty;
            try
            {                
                //Wait for the Alert channel to load
                base.WaitForElement(By.PartialLinkText(channelName));
                //Get Instructor Comments Text
                getInstructorCommentsText =
                       base.GetElementTextByPartialLinkText(channelName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("TodaysViewUXPage",
                "GetInstructorCommentsChannelTitle",
              base.IsTakeScreenShotDuringEntryExit);
            return getInstructorCommentsText;
        }

        /// <summary>
        /// Get Instructor Comments Activity Name Text.
        /// </summary>
        /// <returns>Activity Name.</returns>
        public string GetActivityNameOfInstructorCommentsChannel(string activityName)
        {
            //Get Instructor Comments Text
            logger.LogMethodEntry("TodaysViewUXPage",
                "GetActivityNameOfInstructorCommentsChannel",
             base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getActivityName = string.Empty;
            //get Activities Row Count
            int GetActivitiesRowCount = base.GetElementCountByXPath(TodaysViewUXPageResource.
                TodaysViewUXPageResource_InstructorComments_Activity_Count_By_Xpath
                );
            //Iterate for Respective Activity In Table
            for (
                int setActivityRowCount =
                    Convert.ToInt32(TodaysViewUXPageResource.TodaysViewUXPageResource_Page_Initial_Value);
                    setActivityRowCount <= GetActivitiesRowCount; setActivityRowCount++)
            {
                //Get The Activity Name From List   
                getActivityName =
                    base.GetElementInnerTextByXPath(String.Format(TodaysViewUXPageResource.
                    TodaysViewUXPageResource_InstructorComments_Activity_Name_By_Xpath,
                    setActivityRowCount));
                if(getActivityName.Contains(activityName))
                {
                    break;
                }
            }  
            logger.LogMethodExit("TodaysViewUXPage",
                "GetActivityNameOfInstructorCommentsChannel",
            base.IsTakeScreenShotDuringEntryExit);
            return getActivityName;
        }
    }
}
