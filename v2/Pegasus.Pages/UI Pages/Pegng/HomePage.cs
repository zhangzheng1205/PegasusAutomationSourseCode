using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegng;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.TodaysView;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Home Page Actions,
    /// like to handling annoncement and mails, handling classes
    /// to do etc. tab actions.
    /// </summary>
    public class HomePage : BasePage
    {
        /// <summary>
        /// This is the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(HomePage));

        /// <summary>
        /// Click on the 'Messeges' image and Select ViewAll 
        /// </summary>
        public void SelectAnnouncementViewAllLink(User.UserTypeEnum userType)
        {
            //Click on the 'Messeges' link
            logger.LogMethodEntry("HomePage", "SelectAnnouncementViewAllLink",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the default window
                base.SelectDefaultWindow();
                //Wait for the element
                base.WaitForElement(By.Id(HomePageResource.
                    HomePage_Messeges_Link_Id_Locator));
                //Click on the 'Messeges' link
                base.ClickLinkById(HomePageResource.HomePage_Messeges_Link_Id_Locator);
                //Selecting the 'View All' link
                this.ClickAnnouncementViewAllLink(userType);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("HomePage", "SelectAnnouncementViewAllLink",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the Announcement 'View All' link
        /// </summary>
        /// <param name="userTypeEnum">This is user by type.</param>
        private void ClickAnnouncementViewAllLink(User.UserTypeEnum userTypeEnum)
        {
            //Select the 'View All' link
            logger.LogMethodEntry("HomePage", "ClickAnnouncementViewAllLink",
                 base.IsTakeScreenShotDuringEntryExit);
            switch (userTypeEnum)
            {
                // Click view all link by csteacher
                case User.UserTypeEnum.DPCsTeacher:
                    //Wait for the element
                    base.WaitForElement(By.XPath(HomePageResource.
                        HomePage_Announcement_ViewAll_Link_Xpath_Locator));
                    //Click on the 'View All' link
                    base.ClickLinkByXPath(HomePageResource.HomePage_Announcement_ViewAll_Link_Xpath_Locator);
                    break;
                // Click view all link by csteacher
                case User.UserTypeEnum.DPCsStudent:
                    //Wait for the element
                    base.WaitForElement(By.PartialLinkText(HomePageResource
                    .HomePage_ViewAll_Link_PartialLink));
                    //Click on the 'View All' link
                    base.ClickLinkByPartialLinkText(HomePageResource
                    .HomePage_ViewAll_Link_PartialLink);
                    break;
            }
            logger.LogMethodExit("HomePage", "ClickAnnouncementViewAllLink",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check for Global Home Page Tabs
        /// </summary>
        /// <returns>Returns Default Global Home tabs present results</returns>
        public Boolean IsGlobalHomeTabsPresent()
        {
            //Check for Global Home Page Tabs
            logger.LogMethodEntry("HomePage", "IsGlobalHomeTabsPresent",
                   base.IsTakeScreenShotDuringEntryExit);
            //Intialization of bool 'isHomeTabsPresent'
            bool isHomeTabsPresent = false;
            try
            {
                //Select Home Window
                base.SelectWindow(HomePageResource.Home_Page_Home_Window_Title);
                base.WaitForElement(By.PartialLinkText(HomePageResource.Home_Page_Home_Link_Locator));
                //bool 'isHomeTabsPresent'is use to verify display of Global Home Tabs
                // Home,Classes,Curriculum and Planner 
                isHomeTabsPresent = base.IsElementDisplayedByPartialLinkText
                                         (HomePageResource.Home_Page_Home_Link_Locator) &
                                         base.IsElementDisplayedByPartialLinkText
                                          (HomePageResource.Home_Page_Classes_Link_Locator) &
                                         base.IsElementDisplayedByPartialLinkText
                                         (HomePageResource.Home_Page_Curriculum_Link_Locator) &
                                         base.IsElementDisplayedByPartialLinkText
                                         (HomePageResource.Home_Page_Planner_Link_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("HomePage", "IsGlobalHomeTabsPresent",
                 base.IsTakeScreenShotDuringEntryExit);
            return isHomeTabsPresent;
        }

        /// <summary>
        /// Get Class Name
        /// </summary>
        /// <returns>Class name</returns>
        public String GetClassName()
        {
            //Get Class name
            logger.LogMethodEntry("HomePage", "GetClassName",
                   base.IsTakeScreenShotDuringEntryExit);
            //Initialized Class Name Variable
            string getClassName = string.Empty;
            try
            {
                //Select Classes Window
                base.WaitUntilPageGetSwitchedSuccessfully(HomePageResource.
                    Home_Page_Classes_Window_Title);
                base.SelectWindow(HomePageResource.Home_Page_Classes_Window_Title);
                base.WaitForElement(By.XPath(HomePageResource.
                    Home_Page_Classname_Xpath_Locator));
                //Get Class name
                getClassName = base.GetElementTextByXPath(HomePageResource.
                    Home_Page_Classname_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("HomePage", "GetClassName",
                 base.IsTakeScreenShotDuringEntryExit);
            return getClassName;
        }

        /// <summary>
        /// Click on My Profile link
        /// </summary>
        public void ClickMyProfileLink(User.UserTypeEnum userType)
        {
            //Click on My Profile link
            logger.LogMethodEntry("HomePage", "ClickMyProfileLink",
                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (userType)
                {
                    // Click my profile  by Cs Teacher
                    case User.UserTypeEnum.DPCsTeacher:
                        //Select the default window
                        base.SelectWindow(HomePageResource.Home_Page_Home_Window_Title);
                        //Click on User Profile imagelink
                        base.WaitForElement(By.Id(HomePageResource.
                            HomePage_UserProfile_Image_Id_Locator));
                        //Get Button Property
                        IWebElement getUserProfileButtonProperty = base.GetWebElementPropertiesById(HomePageResource.
                            HomePage_UserProfile_Image_Id_Locator);
                        base.ClickByJavaScriptExecutor(getUserProfileButtonProperty);
                        //Click on My Profile link
                        base.WaitForElement(By.Id(HomePageResource.
                            HomePage_MyProfile_Link_Id_Locator));
                        //Click on Link
                        base.ClickLinkById(HomePageResource.
                            HomePage_MyProfile_Link_Id_Locator);
                        break;
                    // Click my profile  by Cs Student
                    case User.UserTypeEnum.DPCsStudent:
                        //Select the default window
                        base.SelectWindow(HomePageResource
                             .Home_Page_Overview_Window_Title);
                        //Click on User Profile imagelink
                        base.WaitForElement(By.Id(HomePageResource.
                             HomePage_DownArrowLink_Id_locator));
                        base.ClickLinkById(HomePageResource.
                            HomePage_DownArrowLink_Id_locator);
                        //Click on My Profile link
                        base.WaitForElement(By.PartialLinkText(
                            HomePageResource.Home_Page_MyProfile_link));
                        //Click on Link
                        base.ClickLinkByPartialLinkText
                            (HomePageResource.Home_Page_MyProfile_link);
                        break;
                    case User.UserTypeEnum.CsSmsInstructor:
                        //Click on 'My Profile' link
                        new HEDGlobalHomePage().ClickOnMyProfileLink();
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("HomePage", "ClickMyProfileLink",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Messages Link
        /// </summary>
        public void ClickOnMessagesLink(User.UserTypeEnum userTypeEnum)
        {
            //Click on Messages Link
            logger.LogMethodEntry("HomePage", "ClickOnMessagesLink",
                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for Message Link
                base.WaitForElement(By.Id(HomePageResource.
                    HomePage_Messeges_Link_Id_Locator));
                //Click on Messages Link
                base.ClickLinkById(HomePageResource.
                    HomePage_Messeges_Link_Id_Locator);
                switch (userTypeEnum)
                {
                    case User.UserTypeEnum.DPCsTeacher:
                        base.WaitForElement(By.XPath(HomePageResource.
                        HomePage_GoToMail_Xpath_Locator));
                        //Click on Go To Mail or View All Link
                        base.ClickLinkByXPath(HomePageResource.
                        HomePage_GoToMail_Xpath_Locator);
                        break;
                    case User.UserTypeEnum.DPCsStudent:
                        base.WaitForElement(By.XPath(HomePageResource.
                            HomePage_Student_GoToMail_Xpath_Locator));
                        //Click on Go To Mail or View All Link
                        base.ClickLinkByXPath(HomePageResource.
                            HomePage_Student_GoToMail_Xpath_Locator);
                        break;
                }
            }
            catch (Exception e)
            {

                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("HomePage", "ClickOnMessagesLink",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Mail Popup Present or Not
        /// </summary>
        /// <returns>Mail Popup Present Status</returns>
        public Boolean IsMailPopupPresent()
        {
            //Verify Mail Popup Present or Not
            logger.LogMethodEntry("MessageGridPage", "IsMailPopupPresent",
               base.IsTakeScreenShotDuringEntryExit);
            Boolean isMailPopupPresent = false;
            try
            {
                //Check Mail Popup Present
                isMailPopupPresent = base.IsElementPresent(By.Id(HomePageResource.
                    HomePage_MailLightBox_Id_Locator),
                    Convert.ToInt32(HomePageResource.HomePage_TimeToWait_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("MessageGridPage", "IsMailPopupPresent",
               base.IsTakeScreenShotDuringEntryExit);
            return isMailPopupPresent;
        }

        /// <summary>
        /// Enter into the Class
        /// </summary>
        /// <param name="className">This is Class name</param>
        public void EnterInClass(string className)
        {
            // Enter into the Class
            logger.LogMethodEntry("HomePage", "EnterInClass",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                
                //Select Window               
                base.SelectWindow(HomePageResource.Home_Page_Home_Window_Title);
                //Get Class Count
                int getClassCount = base.GetElementCountByCssSelector(HomePageResource.HomePage_ClassesDivCount_CssSelector_Locator);
                // Click on particular class
                for (int initialCount = Convert.ToInt32(HomePageResource.
                   HomePage_ClassesDivInitialCount_Value); initialCount <= getClassCount; initialCount++)
                {
                    //Wait For Element
                    base.WaitForElement(By.XPath(string.Format(HomePageResource.
                       HomePage_ClassName_Link_Xpath_Locator, initialCount)));
                    Thread.Sleep(Convert.ToInt32(HomePageResource.HomePage_TheardSleep_Value));
                    //Get class name text                 
                    string classNameText = base.GetElementTextByXPath(string.Format(
                        HomePageResource.HomePage_ClassName_Link_Xpath_Locator, initialCount)).Trim();
                    if (classNameText == className)
                    {  
                        // Click on Class Link
                        IWebElement classNameProperties = base.GetWebElementPropertiesByXPath(
                            string.Format(HomePageResource.
                            HomePage_ClassName_Link_Xpath_Locator, initialCount));
                        base.ClickByJavaScriptExecutor(classNameProperties);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("HomePage", "EnterInClass",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Digital Path CS User LogOut.
        /// </summary>
        public void DigitalPathCsUserLogout()
        {
            // Logout by DigitalPath Cs User
            logger.LogMethodEntry("HomePage", "DigitalPathCsUserLogout",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Click on UserProfile image
                base.WaitForElement(By.Id(HomePageResource.
                    HomePage_UserProfile_Image_Id_Locator));
                base.ClickLinkById(HomePageResource.
                    HomePage_UserProfile_Image_Id_Locator);
                // Click on SignOut link
                base.WaitForElement(By.Id(HomePageResource.
                    HomePage_SignOut_Link_Id_Locator));
                base.ClickLinkById(HomePageResource.
                    HomePage_SignOut_Link_Id_Locator);
                //Wait for Signout window
                base.WaitUntilWindowLoads(HomePageResource.
                    HomePage_SignOut_Window_Title);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("HomePage", "DigitalPathCsUserLogout",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click the "Add" button
        /// </summary>
        public void ClickTheAddButton()
        {
            //Click the "Add" button
            logger.LogMethodEntry("HomePage", "ClickTheAddButton",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the window name
                base.WaitUntilWindowLoads(HomePageResource.Home_Page_Home_Window_Title);
                base.SelectWindow(HomePageResource.Home_Page_Home_Window_Title);
                base.FocusOnElementById(HomePageResource.
                    Home_Page_Product_AddButton_Id_Locator);
                //Click on the "Add" button
                base.ClickButtonById(HomePageResource.
                    Home_Page_Product_AddButton_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("HomePage", "ClickTheAddButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the product
        /// </summary>
        /// <param name="productName">This is product name</param>
        /// <returns>Product Name </returns>
        public string GetTheProduct(string productName)
        {
            //Get the product
            logger.LogMethodEntry("HomePage", "GetTheProduct",
                base.IsTakeScreenShotDuringEntryExit);
            //Variable Declaration of product          
            string getProductName = string.Empty;
            try
            {
                //Selecting the frame
                this.SelectLightBoxFrame();
                base.WaitForElement(By.ClassName(HomePageResource.
                    Home_Page_AddProduct_Title_ClassName_Locator));
                //Getting the count of product
                int getProductCount = base.GetElementCountByXPath(HomePageResource.
                    Home_Page_NumberofProduct_Title_Xpath_Locator);
                for (int rowCount = 1; rowCount <= getProductCount; rowCount++)
                {
                    //Get the productname text 
                    getProductName = base.GetElementTextByXPath
                        (string.Format(HomePageResource.
                     Home_Page_ProductName_Title_Xpath_Locator, rowCount));
                    if (getProductName == productName)
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            { ExceptionHandler.HandleException(e); }
            logger.LogMethodExit("HomePage", "GetTheProduct",
               base.IsTakeScreenShotDuringEntryExit);
            return getProductName;
        }

        /// <summary>
        /// Select the lightbox frame
        /// </summary>
        private void SelectLightBoxFrame()
        {
            //Select the lightbox frame
            logger.LogMethodEntry("HomePage", "SelectLightBoxFrame",
               base.IsTakeScreenShotDuringEntryExit);
            //Select the window name
            base.WaitUntilWindowLoads(HomePageResource.Home_Page_Home_Window_Title);
            base.SelectWindow(HomePageResource.Home_Page_Home_Window_Title);
            //Select Iframe
            base.SwitchToIFrame(HomePageResource.
                HomePage_MailLightBox_Id_Locator);
            try
            {
                base.SwitchToIFrame(HomePageResource.
                    Home_Page_AccessClass_SetUpWizardFrame_Id_Locator);
            }
            catch (Exception e) { ExceptionHandler.HandleException(e); }
            logger.LogMethodExit("HomePage", "SelectLightBoxFrame",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click the "Cancel" button
        /// </summary>
        public void ClickTheCancelButton()
        {
            //Click the "Cancel" button
            logger.LogMethodEntry("HomePage", "ClickTheCancelButton",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.FocusOnElementById(HomePageResource.
                       Home_Page_Cancel_Button_Id_Locator);
                //Click the "Cancel" button
                base.ClickButtonById(HomePageResource.
                    Home_Page_Cancel_Button_Id_Locator);
                base.FocusOnElementById(HomePageResource.
                    Home_Page_YesCancel_Button_Id_Locator);
                //Click on the"Yes,Cancel" button
                base.ClickButtonById(HomePageResource.
                    Home_Page_YesCancel_Button_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("HomePage", "ClickTheCancelButton",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Displayof the class name
        /// </summary>
        /// <param name="className">This is class name</param>
        /// <returns>class</returns>
        public string GetDisplayClassName(string className)
        {
            // Get Displayof the class name
            logger.LogMethodEntry("HomePage", "GetDisplayClassName",
                base.IsTakeScreenShotDuringEntryExit);
            //Variable Declaration of get class name
            string getClassNameText = string.Empty;
            try
            {
                //Select the window name
                base.WaitUntilWindowLoads(HomePageResource.
                        Home_Page_Home_Window_Title);
                base.SelectWindow(HomePageResource.
                        Home_Page_Home_Window_Title);
                //Get the number of class count
                int getClassCount = base.GetElementCountByCssSelector(HomePageResource.
                    HomePage_ClassesDivCount_CssSelector_Locator);
                for (int rowCount = 2; rowCount <= getClassCount; rowCount++)
                {
                    //Get Class Name
                    getClassNameText = base.GetElementTextByXPath(string.Format(
                        HomePageResource.HomePage_ClassName_Link_Xpath_Locator, rowCount)).Trim();
                    if (getClassNameText == className)
                    {
                        break;
                    }
                }
                base.SwitchToDefaultPageContent();
                base.SwitchToDefaultWindow();
            }
                
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("HomePage", "GetDisplayClassName",
               base.IsTakeScreenShotDuringEntryExit);
            return getClassNameText;
        }

        /// <summary>
        /// Signout from application by DP CS Teacher.
        /// </summary>
        public void SignoutByDigitalPathCSTeacher(String linkSignOut)
        {
            //Signout from application by DP CS Teacher
            logger.LogMethodEntry("HomePage", "SignoutByDigitalPathCSTeacher",
                     base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Default Window
                base.SelectDefaultWindow();
                //Click on Button
                base.WaitForElement(By.Id(HomePageResource.
                    HomePage_UserProfile_Image_Id_Locator));
                base.ClickButtonById(HomePageResource.
                    HomePage_UserProfile_Image_Id_Locator);
                //Click on Sign Out Link
                base.WaitForElement(By.Id(HomePageResource.
                    HomePage_SignOut_Link_Id_Locator));
                base.ClickLinkById(HomePageResource.
                    HomePage_SignOut_Link_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodEntry("HomePage", "SignoutByDigitalPathCSTeacher",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Signout from application by DP CS Teacher.
        /// </summary>
        public void SignoutByDigitalPathCSAide()
        {
            //Signout from application by DP CS Teacher
            logger.LogMethodEntry("HomePage", "SignoutByDigitalPathCSAide",
                     base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Default Window
                base.WaitUntilWindowLoads(HomePageResource.
                    Home_Page_GlobalHome_Window_Title);
                base.SelectDefaultWindow();
                base.WaitForElement(By.Id(HomePageResource.
                    HomePage_LogoutLink_Aide_Id_Locator));
                //Click on Sign Out Link
                IWebElement signOutLink = base.GetWebElementPropertiesById(HomePageResource.
                    HomePage_LogoutLink_Aide_Id_Locator);
                base.ClickByJavaScriptExecutor(signOutLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodEntry("HomePage", "SignoutByDigitalPathCSAide",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Signout from application by DP CS Student.
        /// </summary>
        /// <param name="linkSignOut">This is Sign Out Link text</param>
        public void SignOutByDigitalPathCSStudent(string linkSignOut)
        {
            //Signout from application by DP CS Student
            logger.LogMethodEntry("HomePage", "SignOutByDigitalPathCSStudent",
                     base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Default Window
                base.SelectDefaultWindow();
                //Click on Button
                base.WaitForElement(By.Id(HomePageResource.
                    HomePage_DownArrowLink_Id_locator));
                base.ClickButtonById(HomePageResource.
                    HomePage_DownArrowLink_Id_locator);
                //Click on Sign Out Link
                base.WaitForElement(By.PartialLinkText(linkSignOut));
                base.ClickButtonByPartialLinkText(linkSignOut);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("HomePage", "SignOutByDigitalPathCSStudent",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the Mail Message 'View All' link.
        /// </summary>
        public void ClickMessagesViewAllLink(User.UserTypeEnum userTypeEnum)
        {
            //Click Message View All Link
            logger.LogMethodEntry("HomePage", "ClickMessagesViewAllLink",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Click on Link
                this.ClickOnMessagesLink(userTypeEnum);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("HomePage", "ClickMessagesViewAllLink",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Manage All Button In GlobalHome.
        /// </summary>
        public void ClickTheManageAllButtonInGlobalHome()
        {
            //Click The Manage All Button In GlobalHome
            logger.LogMethodEntry("HomePage", "ClickTheManageAllButtonInGlobalHome",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the window
                base.WaitUntilWindowLoads(HomePageResource.
                    Home_Page_GlobalHome_Window_Title);
                base.SelectWindow(HomePageResource.
                    Home_Page_GlobalHome_Window_Title);
                //Wait for the 'Manage All' button
                base.WaitForElement(By.Id(HomePageResource.
                    HomePage_ManageAll_Button_Id_Locator));
                IWebElement getManageAllButton = base.GetWebElementPropertiesById
                    (HomePageResource.
                    HomePage_ManageAll_Button_Id_Locator);
                //Click the 'Manage All' button
                base.ClickByJavaScriptExecutor(getManageAllButton);
            }
            catch (Exception e)
            {
              ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("HomePage", "ClickTheManageAllButtonInGlobalHome",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Gets the displayed welcome message on Home Page.
        /// </summary>
        /// <returns></returns>
        public string GetWelcomeMessage()
        {
            logger.LogMethodEntry("HomePage", "GetWelcomeMessage",
               base.IsTakeScreenShotDuringEntryExit);
            string welcomeMessage;

            SelectLightBoxFrame();
            base.WaitForElement(By.Id(HomePageResource.HomePage_WelcomeMessage_Div_Id_Locator));
            welcomeMessage = base.GetElementTextById(
                HomePageResource.HomePage_WelcomeMessage_Div_Id_Locator);

            logger.LogMethodExit("HomePage", "GetWelcomeMessage",
              base.IsTakeScreenShotDuringEntryExit);
            return welcomeMessage;
        }

        /// <summary>
        /// Gets the Welcome banner Src attribute value
        /// </summary>
        /// <returns></returns>
        public string GetWelcomeBannerSrcAttribute()
        {
            logger.LogMethodEntry("HomePage", "GetWelcomeBannerSrcAttribute",
               base.IsTakeScreenShotDuringEntryExit);
            string welcomeBannerSrc = String.Empty;

            SelectLightBoxFrame();
            base.WaitForElement(By.Id(HomePageResource.HomePage_WelcomeBanner_Img_Id_Locator));
            if (base.IsElementDisplayedById(HomePageResource.HomePage_WelcomeBanner_Img_Id_Locator))
            {
                IWebElement bannerImage = base.GetWebElementPropertiesById(
                    HomePageResource.HomePage_WelcomeBanner_Img_Id_Locator);
                welcomeBannerSrc = bannerImage.GetAttribute("src");//the method supposed to return Src attribute value only
                //so, need to get dynamically attribute key.
            }

            logger.LogMethodExit("HomePage", "GetWelcomeBannerSrcAttribute",
             base.IsTakeScreenShotDuringEntryExit);
            return welcomeBannerSrc;
        }

        /// <summary>
        /// Gets the text in button on Welcome message box
        /// </summary>
        /// <returns></returns>
        public string GetWelcomeMessageButtonText()
        {
            logger.LogMethodEntry("HomePage", "GetWelcomeMessageButtonText",
              base.IsTakeScreenShotDuringEntryExit);
            string welcomeMessageButtonText;

            SelectLightBoxFrame();
            base.WaitForElement(By.Id(HomePageResource.HomePage_WelcomeMessage_Button_Id_Locator));
            welcomeMessageButtonText = base.GetElementTextById(HomePageResource.HomePage_WelcomeMessage_Button_Id_Locator);

            logger.LogMethodExit("HomePage", "GetWelcomeMessageButtonText",
              base.IsTakeScreenShotDuringEntryExit);
            return welcomeMessageButtonText;
        }

        /// <summary>
        /// Gets Product Id's of Product branding images displayed over Home page.
        /// </summary>
        /// <returns> List of Product Ids.</returns>
        public IList<String> GetProductIdOfProductBrandingImagesDispayed()
        {
            base.SwitchToDefaultWindow();
            ICollection<IWebElement> productBrandingImageList = base.GetWebElementsCollectionByClassName(
                HomePageResource.Home_Page_Product_BrandingImage_Class_Locator);
            if (productBrandingImageList == null) {
                return null;
            }
            return (from brandingImage in productBrandingImageList
                    select brandingImage.GetAttribute(HomePageResource
                    .Home_Page_Product_BrandingImage_ProductAttribute_Value))
                    .ToList();            
        }

        /// <summary>
        /// Clicks navigation button on Welcome message light box
        /// </summary>
        public void ClickWelcomeMessageBoxNavigationButton()
        {
            logger.LogMethodEntry("HomePage", "ClickWelcomeMessageBoxNavigationButton",
             base.IsTakeScreenShotDuringEntryExit);

            SelectLightBoxFrame();
            base.WaitForElement(By.Id(
                HomePageResource.HomePage_WelcomeMessage_Button_Id_Locator));
            base.ClickButtonById(HomePageResource
                .HomePage_WelcomeMessage_Button_Id_Locator);

            logger.LogMethodExit("HomePage", "ClickWelcomeMessageBoxNavigationButton",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select required cmenu option of class.
        /// </summary>
        /// <param name="className">Name of the class for which cmenu option has to be selected.</param>
        /// <param name="cmenuOption">Cmenu option required to be selected.</param>
        public void ClickOnCmenuIconOfClassAndSelectOption(string className, string cmenuOption)
        {
            // Enter into the Class
            logger.LogMethodEntry("HomePage", "ClickOnCmenuIconOfClassAndSelectOption",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window               
                base.SelectWindow(HomePageResource.Home_Page_Home_Window_Title);
                //Get Class Count
                int getClassCount = base.GetElementCountByCssSelector(HomePageResource.
                   HomePage_ClassesDivCount_CssSelector_Locator);
                // Click on particular class
                for (int initialCount = Convert.ToInt32(HomePageResource.
            HomePage_ClassesDivInitialCount_Value); initialCount <= getClassCount; initialCount++)
                {
                    //Wait For Element
                    base.WaitForElement(By.XPath(string.Format(HomePageResource.
                       HomePage_ClassName_Link_Xpath_Locator, initialCount)));
                    Thread.Sleep(Convert.ToInt32(HomePageResource.HomePage_TheardSleep_Value));
                    //Get class name text                 
                    string classNameText = base.GetElementTextByXPath(string.Format(
                        HomePageResource.HomePage_ClassName_Link_Xpath_Locator, initialCount)).Trim();
                    if (classNameText == className)
                    {
                        // Click on Class Cmenu icon
                        IWebElement getCmenuIconProperty = base.GetWebElementPropertiesByXPath
                            (string.Format(HomePageResource.
                            HomePage_ClassCmenu_Link_Xpath_Locator, initialCount));
                        base.ClickByJavaScriptExecutor(getCmenuIconProperty);
                        int getCmenuOptionsCount = base.GetElementCountByXPath(
                            string.Format(HomePageResource.
                            HomePage_ClassCmenu_Options_Xpath_Locator, initialCount));
                        for (int j = 1; j <= getCmenuOptionsCount; j++)
                        {
                            //Get cmenu option
                            string getCmenuName = base.GetElementTextByXPath(string.Format(
                                HomePageResource.HomePage_ClassCmenu_OptionsText_Xpath_Locator, initialCount, j));
                            if (cmenuOption.Equals(getCmenuName))
                            {
                                //Click on cmenu option
                                IWebElement getCmenuProperty = base.GetWebElementPropertiesByXPath
                                    (string.Format(
                                HomePageResource.HomePage_ClassCmenu_OptionsText_Xpath_Locator, initialCount, j));
                                base.ClickByJavaScriptExecutor(getCmenuProperty);
                                break;
                            }

                        }
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("HomePage", "ClickOnCmenuIconOfClassAndSelectOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on create button.
        /// </summary>
        public void ClickOnCreateButton()
        {
            //Click on create button in classes channel
            logger.LogMethodEntry("HomePage", "ClickOnCreateButton",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for create button
                base.WaitForElement(By.Id(HomePageResource.
                    HomePage_CreateClassButton_Id_Locator));
                //Click on create button
                base.ClickButtonById(HomePageResource.
                    HomePage_CreateClassButton_Id_Locator);
            }

            catch(Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("HomePage", "ClickOnCreateButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Success Message from Home page
        /// </summary>
        /// <returns>This is Success Message</returns>
        public string GetSuccessMessageHomePage()
        {
            //Get Success Message
            logger.LogMethodEntry("HomePage", "GetSuccessMessageHomePage",
                  base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getSuccessMessage = string.Empty;
            try
            {
                base.WaitUntilWindowLoads("Home");
                //Get Success Message From Application
                getSuccessMessage = base.GetElementTextById(HomePageResource.
                    HomePage_SuccessMessage_HomePage_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("HomePage", "GetSuccessMessageHomePage",
                  base.IsTakeScreenShotDuringEntryExit);
            return getSuccessMessage;
        }
    }
}
