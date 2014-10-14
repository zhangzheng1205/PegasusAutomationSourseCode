using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.MyPegasus;
using System.Threading;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus MyPegasus UX Page Actions
    /// </summary>
    public class MyPegasusUXPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static readonly Logger logger = Logger.GetInstance(typeof(MyPegasusUXPage));

        /// <summary>
        /// Select Announcement
        /// </summary>
        /// <param name="announcementTypeEnum">This is announcement by type</param>
        public void SelectAnnouncement(Announcement.
                      AnnouncementTypeEnum announcementTypeEnum)
        {
            //Selecting  Announcement
            logger.LogMethodEntry("MyPegasusUXPage", "SelectAnnouncement"
                , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the window
                this.SelectGlobalHomePage();
                //Get announcement from memory
                Announcement announcement = Announcement.Get(announcementTypeEnum);
                base.WaitForElement(By.PartialLinkText(announcement.Name));
                //Focus on Element
                base.FocusOnElementByPartialLinkText(announcement.Name);
                //Click on Announcement link                
                IWebElement getAnnouncement = base.GetWebElementPropertiesByPartialLinkText
                    (announcement.Name);
                base.ClickByJavaScriptExecutor(getAnnouncement);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("MyPegasusUXPage", "SelectAnnouncement",
                            base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click Announcement ManageAll Button
        /// </summary>
        public void ClickAnnouncementManageAllButton()
        {
            //Click on  ManageAll Button
            logger.LogMethodEntry("MyPegasusUXPage", "ClickAnnouncementManageAllButton"
               , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Selecting default window
                base.SwitchToDefaultPageContent();
                //Wait for Manage all button
                base.WaitForElement(By.ClassName(MyPegasusUXPageResource.
                       MyPegasusUX_Page_ManageAll_Button_Class_Locator));
                base.WaitForElement(By.XPath(MyPegasusUXPageResource.
                    MyPegasusUX_Page_Announcement_Rows_Xpath_Locator));
                //Intalization of announcementCnt to get announcement's count
                int announcementCnt = base.GetElementCountByXPath(MyPegasusUXPageResource.
                    MyPegasusUX_Page_Announcement_Rows_Xpath_Locator);
                // Foucusing on the last displayed annoucement row
                base.FocusOnElementByXPath(MyPegasusUXPageResource.
                    MyPegasusUX_Page_AnnouncementMaxRows_Xpath_Locator);
                Thread.Sleep(Convert.ToInt32(
                MyPegasusUXPageResource.MyPegasusUX_Page_ThreadSleep_Value));
                //Focus on element
                base.FocusOnElementByClassName(MyPegasusUXPageResource.
                   MyPegasusUX_Page_ManageAll_Button_Class_Locator);
                // Click ManageAll Button
                base.ClickButtonByClassName(MyPegasusUXPageResource.
                    MyPegasusUX_Page_ManageAll_Button_Class_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("MyPegasusUXPage", "ClickAnnouncementManageAllButton",
                            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the Course Link To Open 
        /// </summary>
        /// <param name="courseName">This is Course Name</param>
        /// <param name="userTypeEnum">This is user by type </param>
        public void EnterInCourseFromGobalHomePage(string courseName, User.UserTypeEnum userTypeEnum)
        {
            // Open Course by clicking on course Link
            logger.LogMethodEntry("MyPegasusUXPage", "EnterInCourseFromGobalHomePage"
                , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectGlobalHomePage();
                //Enter In Course 
               
                EnterInsideCourse(courseName, userTypeEnum);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("MyPegasusUXPage", "EnterInCourseFromGobalHomePage"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter the Course
        /// </summary>
        /// <param name="courseName">This is Course Name</param>
        /// <param name="userTypeEnum">This is User by Type</param>
        private void EnterInsideCourse(string courseName, User.UserTypeEnum userTypeEnum)
        {
            // Search and Click Course Link
            logger.LogMethodEntry("MyPegasusUXPage", "EnterInSideCourse"
                , base.IsTakeScreenShotDuringEntryExit);
            // Switch Statement to enter course according to user role
            switch (userTypeEnum)
            {
                case User.UserTypeEnum.WsStudent:
                    //Open Course Through Course cmenu option Open
                    EnterInCourseThroughClickCmenuOption(courseName);
                    break;
                case User.UserTypeEnum.WsTeacher:
                    //Click course link to enter in course
                    base.WaitForElement(By.PartialLinkText(courseName),
                    Convert.ToInt32(MyPegasusUXPageResource.MyPegasusUX_Page_TimeToWait_Value));
                    //Get Course Link Property
                    IWebElement getCourseLinkProperty = base.
                    GetWebElementPropertiesByPartialLinkText(courseName);
                    base.ClickByJavaScriptExecutor(getCourseLinkProperty);
                    break;

                case User.UserTypeEnum.NovaNETCsStudent:
                    //Click Course Link to enter in course
                    EnterInToTheCourse(courseName);                   
                    break;
                case User.UserTypeEnum.NovaNETCsTeacher:
                    //Click Course Link to enter in course
                    EnterInToTheCourse(courseName);
                    break;
            }
            logger.LogMethodExit("MyPegasusUXPage", "EnterInSideCourse",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter in course from cmenu option 
        /// </summary>
        /// <param name="courseName">This is course name</param>
        private void EnterInCourseThroughClickCmenuOption(string courseName)
        {
            //Open Course Through Course cmenu option Open
            logger.LogMethodEntry("MyPegasusUXPage", "EnterInCourseThroughClickCmenuOption"
                , base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.PartialLinkText(courseName));
            //Intialization of IWebElement for courseName Link
            IWebElement getcourseNameLink = base.
                GetWebElementPropertiesByPartialLinkText(courseName);
            //Wait for Element
            base.WaitForElement(By.XPath(MyPegasusUXPageResource.
                    MyPegasusUX_Page_CourseCount_Xpath_Locator));
            int getCourseCount = base.GetElementCountByXPath(MyPegasusUXPageResource.
                    MyPegasusUX_Page_CourseCount_Xpath_Locator);
            //For loop to Click on particular Course cmenu
            for (int initialCount = 1; initialCount <= getCourseCount; initialCount++)
            {
                //Wait for Element
                base.WaitForElement(By.XPath(string.Format(MyPegasusUXPageResource.
                     MyPegasusUX_Page_CourseName_Text_Xpath_Locator, initialCount)));
                string getCourseName = base.GetElementTextByXPath(string.Format(MyPegasusUXPageResource.
                     MyPegasusUX_Page_CourseName_Text_Xpath_Locator, initialCount));
                //Condition for course present
                if (getCourseName == courseName)
                {   //Intialization of IWebElement for Course Cmenu
                    base.FocusOnElementByPartialLinkText(courseName);
                    //Click course cmenu option
                    ClickCourseCMenuOption(getcourseNameLink);
                    break;
                }
            }
            logger.LogMethodExit("MyPegasusUXPage", "EnterInCourseThroughClickCmenuOption",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Course CMenu Option.
        /// </summary>
        /// <param name="getcourseNameLink">This is Course Link Name.</param>
        private void ClickCourseCMenuOption(IWebElement getcourseNameLink)
        {
            logger.LogMethodEntry("MyPegasusUXPage", "ClickCourseCMenuOption",
              base.IsTakeScreenShotDuringEntryExit);
            //Mouse Hover at Course Cmenu 
            base.PerformMouseHoverAction(getcourseNameLink);
            //Wait For Element
            base.WaitForElement(By.ClassName
                (MyPegasusUXPageResource.MyPegasusUX_Page_CourseCMenu_ClassName_Locator));
            //Intialization of IWebElement for course Cmenu
            IWebElement getCourseCmenu = base.GetWebElementPropertiesByClassName
                (MyPegasusUXPageResource.MyPegasusUX_Page_CourseCMenu_ClassName_Locator);
            //Click on Course Cmenu Icon
            base.ClickByJavaScriptExecutor(getCourseCmenu);
            //Wait For Element
            base.WaitForElement(By.XPath(MyPegasusUXPageResource.
                MyPegasusUX_Page_Course_OpenCmenu_Xpath_Locator));
            //Click on Button
            base.ClickButtonByXPath(MyPegasusUXPageResource.
                MyPegasusUX_Page_Course_OpenCmenu_Xpath_Locator);
            logger.LogMethodExit("MyPegasusUXPage", "ClickCourseCMenuOption",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on My Profile Link.
        /// </summary>
        public void ClickMyProfileLinkByWSUser()
        {
            // Selecting MyProfile Link
            logger.LogMethodEntry("MyPegasusUXPage", "ClickMyProfileLinkByWSUser",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Default Window
                this.SelectGlobalHomePage();
                // Focus on My Profile Link
                base.FocusOnElementById(MyPegasusUXPageResource.
                    MyPegasusUX_Page_MyProfileLink_Id_Locator);
                // Click My Profile Link
                IWebElement myProfileLink = base.GetWebElementPropertiesById(
                    MyPegasusUXPageResource.
                    MyPegasusUX_Page_MyProfileLink_Id_Locator);
                base.ClickByJavaScriptExecutor(myProfileLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("MyPegasusUXPage", "ClickMyProfileLinkByWSUser",
               base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Enter Inside the Course.
        /// </summary>
        /// <param name="course">This is Course Name.</param>
        public void EnterInToTheCourse(string course)
        {
            //Enter Inside the Course
            logger.LogMethodEntry("MyPegasusUXPage", "EnterInToTheCourse",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the window
                this.SelectGlobalHomePage();
                //Get Count of Master Library row
                int getCourseCount = base.GetElementCountByXPath(MyPegasusUXPageResource.
                    MyPegasusUX_Page_MasterLibrary_Table_Xpath_Locator);
                for (int initialCount = Convert.ToInt32(MyPegasusUXPageResource.
                    MyPegasusUX_Page_CourseCount_InitialValue); initialCount <= getCourseCount;
                    initialCount++)
                {
                    //Get Master Library Name
                    bool isCourseNameText = base.IsElementPresent(By.XPath(string.Format(MyPegasusUXPageResource.
                        MyPegasusUX_Page_MasterLibrary_GetName_Xpath_Locator, initialCount)),10);
                    if (isCourseNameText)
                    {
                    string getCourseName = base.GetElementTextByXPath(
                        string.Format(MyPegasusUXPageResource.
                        MyPegasusUX_Page_MasterLibrary_GetName_Xpath_Locator, initialCount));

                    if (getCourseName.Contains(course))
                    {
                        base.WaitForElement(By.XPath(string.Format(
                            MyPegasusUXPageResource.
                            MyPegasusUX_Page_MasterLibrary_Name_Xpath_Locator, initialCount)));
                        //Get Course Property
                        IWebElement getCourseProperty = base.GetWebElementPropertiesByXPath(
                            string.Format(MyPegasusUXPageResource.
                            MyPegasusUX_Page_MasterLibrary_Name_Xpath_Locator, initialCount));
                        //Click on Course
                        base.ClickByJavaScriptExecutor(getCourseProperty);
                        break;
                    }
                }
               }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("MyPegasusUXPage", "EnterInToTheCourse",
               base.IsTakeScreenShotDuringEntryExit);
        }
       
        /// <summary>
        /// Select the Global Home Page.
        /// </summary>
        private void SelectGlobalHomePage()
        {
            //Select the Global Home Page
            logger.LogMethodEntry("MyPegasusUXPage", "SelectGlobalHomePage",
               base.IsTakeScreenShotDuringEntryExit);
            //Wait for GLobal Home Page Window
            base.WaitUntilWindowLoads(MyPegasusUXPageResource.MyPegasusUX_Page_Window_Title);
            base.SelectWindow(MyPegasusUXPageResource.MyPegasusUX_Page_Window_Title);
            logger.LogMethodExit("MyPegasusUXPage", "SelectGlobalHomePage",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter In To The NovanetCourse
        /// </summary>
        /// <param name="courseName">This is Course Name</param>
        private void EnterInToTheNovanetCourse(string courseName)
        {
            //Enter In To The NovanetCourse
            logger.LogMethodEntry("MyPegasusUXPage", "EnterInToTheNovanetCourse",
               base.IsTakeScreenShotDuringEntryExit);
            //Wait for GLobal Home Page Window
            this.SelectGlobalHomePage();
            //Get Count of Master Library row
            int getCourseCount = base.GetElementCountByXPath(MyPegasusUXPageResource.
                MyPegasusUX_Page_MasterLibrary_Table_Xpath_Locator);
            for (int initialCount = Convert.ToInt32(MyPegasusUXPageResource.
                MyPegasusUX_Page_CourseCount_InitialValue); initialCount <= getCourseCount;
                initialCount++)
            {
                //Get Master Library Name
                string getCourseName = base.GetElementTextByXPath(string.Format(MyPegasusUXPageResource.
                    MyPegasusUX_Page_MasterLibrary_GetName_Xpath_Locator, initialCount));
                if (getCourseName.Contains(courseName))
                {
                    //Get Course Property
                    IWebElement getCourseProperty = base.GetWebElementPropertiesByXPath(string.Format(
                        MyPegasusUXPageResource.MyPegasusUX_Page_NovanetMasterLibrary_Name_Xpath_Locator, initialCount));
                    //Click on Course
                    base.ClickByJavaScriptExecutor(getCourseProperty);
                    break;
                }
            }
            logger.LogMethodExit("MyPegasusUXPage", "EnterInToTheNovanetCourse",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter in to Template Class
        /// </summary>
        /// <param name="className">This is Class Name</param>
        public void EnterInToTemplateClass(string className)
        {
            //Enter in to Template Class
            logger.LogMethodEntry("MyPegasusUXPage", "EnterInToTemplateClass",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select window
                this.SelectGlobalHomePage();
                //Wait for element
                base.WaitForElement(By.XPath(MyPegasusUXPageResource.
                    MyPegasusUX_Page_MasterLibrary_Table_Xpath_Locator));
                //Get Class Name and Click on Class Name
                this.GetClassNameAndClickClassName(className);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("MyPegasusUXPage", "EnterInToTemplateClass",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Class Name and Click on Class Name
        /// </summary>
        /// <param name="className">This is Class name</param>
        private void GetClassNameAndClickClassName(string className)
        {
            //Get Class Name and Click on Class Name
            logger.LogMethodEntry("MyPegasusUXPage", "GetClassNameAndClickClassName",
              base.IsTakeScreenShotDuringEntryExit);
            //Get class count
            int getClassCount = base.GetElementCountByXPath(MyPegasusUXPageResource.
                MyPegasusUX_Page_MasterLibrary_Table_Xpath_Locator);
            //Initializing variable
            string getClassName = string.Empty;
            for (int getRowCount = Convert.ToInt32(MyPegasusUXPageResource.
                MyPegasusUX_Page_CourseCount_InitialValue); getRowCount <= getClassCount;
                getRowCount++)
            {
                if (base.IsElementPresent(By.XPath(string.Format(MyPegasusUXPageResource
                    .MyPegasusUX_Page_Class_Xpath_Locator, getRowCount)),
                    Convert.ToInt32(MyPegasusUXPageResource.MyPegasusUX_Page_TimeToWait_Value)))
                {
                    //Get class name
                    getClassName = base.GetElementTextByXPath(string.Format
                        (MyPegasusUXPageResource.MyPegasusUX_Page_Class_Xpath_Locator,
                        getRowCount));
                    if (getClassName == className)
                    {
                        //Click on class name
                        this.ClickOnClassName(getRowCount);
                        break;
                    }
                }
            }
            logger.LogMethodExit("MyPegasusUXPage", "GetClassNameAndClickClassName",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on class name
        /// </summary>
        /// <param name="classCount">This is Class Count</param>
        private void ClickOnClassName(int classCount)
        {
            //Click on class name
            logger.LogMethodEntry("MyPegasusUXPage", "ClickOnClassName",
               base.IsTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.XPath(string.Format(MyPegasusUXPageResource.
                MyPegasusUX_Page_Class_Xpath_Locator, classCount)));
            //Get element property
            IWebElement getClassNameLink = base.GetWebElementPropertiesByXPath
                (string.Format(MyPegasusUXPageResource.
                MyPegasusUX_Page_Class_Xpath_Locator, classCount));
            //Click on class name
            base.ClickByJavaScriptExecutor(getClassNameLink);
            logger.LogMethodExit("MyPegasusUXPage", "ClickOnClassName",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Create Class Button In Global Home.
        /// </summary>
        public void ClickOnCretaeClassButtonInGlobalHome()
        {
            //Click On Create Class Button In Global Home.
            logger.LogMethodEntry("MyPegasusUXPage", "ClickOnCretaeClassButtonInGlobalHome",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the window
                this.SelectGlobalHomePage();
                //Wait foer the element
                base.WaitForElement(By.Id(MyPegasusUXPageResource.
                    MyPegasusUX_Page_CreateClass_button_Id_Locator));
                IWebElement getCreateClassButton = base.GetWebElementPropertiesById
                    (MyPegasusUXPageResource.
                    MyPegasusUX_Page_CreateClass_button_Id_Locator);
                //Click on 'Create Class' button
                base.ClickByJavaScriptExecutor(getCreateClassButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("MyPegasusUXPage", "ClickOnCretaeClassButtonInGlobalHome",
               base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
