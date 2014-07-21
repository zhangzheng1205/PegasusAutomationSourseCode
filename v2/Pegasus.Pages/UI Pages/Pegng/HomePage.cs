using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegng;

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
                 base.isTakeScreenShotDuringEntryExit);
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
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the Announcement 'View All' link
        /// </summary>
        /// <param name="userTypeEnum">This is user by type.</param>
        private void ClickAnnouncementViewAllLink(User.UserTypeEnum userTypeEnum)
        {
            //Select the 'View All' link
            logger.LogMethodEntry("HomePage", "ClickAnnouncementViewAllLink",
                 base.isTakeScreenShotDuringEntryExit);
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
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check for Global Home Page Tabs
        /// </summary>
        /// <returns>Returns Default Global Home tabs present results</returns>
        public Boolean IsGlobalHomeTabsPresent()
        {
            //Check for Global Home Page Tabs
            logger.LogMethodEntry("HomePage", "IsGlobalHomeTabsPresent",
                   base.isTakeScreenShotDuringEntryExit);
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
                 base.isTakeScreenShotDuringEntryExit);
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
                   base.isTakeScreenShotDuringEntryExit);
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
                 base.isTakeScreenShotDuringEntryExit);
            return getClassName;
        }

        /// <summary>
        /// Click on My Profile link
        /// </summary>
        public void ClickMyProfileLink(User.UserTypeEnum userType)
        {
            //Click on My Profile link
            logger.LogMethodEntry("HomePage", "ClickMyProfileLink",
                   base.isTakeScreenShotDuringEntryExit);
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
                        base.FocusOnElementByID(HomePageResource.
                            HomePage_UserProfile_Image_Id_Locator);
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
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Messages Link
        /// </summary>
        public void ClickOnMessagesLink(User.UserTypeEnum userTypeEnum)
        {
            //Click on Messages Link
            logger.LogMethodEntry("HomePage", "ClickOnMessagesLink",
                   base.isTakeScreenShotDuringEntryExit);
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
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Mail Popup Present or Not
        /// </summary>
        /// <returns>Mail Popup Present Status</returns>
        public Boolean IsMailPopupPresent()
        {
            //Verify Mail Popup Present or Not
            logger.LogMethodEntry("MessageGridPage", "IsMailPopupPresent",
               base.isTakeScreenShotDuringEntryExit);
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
               base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window               
                base.SelectWindow(HomePageResource.Home_Page_Home_Window_Title);
                //Get Class Count
                int getClassCount = base.GetElementCountByXPath(HomePageResource.
                   HomePage_ClassesDivCount_Xpath_Locator);
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
                    {  // Click on Class Link
                        base.ClickLinkByXPath(string.Format(HomePageResource.
                            HomePage_ClassName_Link_Xpath_Locator, initialCount)); break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("HomePage", "EnterInClass",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Digital Path CS User LogOut.
        /// </summary>
        public void DigitalPathCsUserLogout()
        {
            // Logout by DigitalPath Cs User
            logger.LogMethodEntry("HomePage", "DigitalPathCsUserLogout",
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click the "Add" button
        /// </summary>
        public void ClickTheAddButton()
        {
            //Click the "Add" button
            logger.LogMethodEntry("HomePage", "ClickTheAddButton",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the window name
                base.WaitUntilWindowLoads(HomePageResource.Home_Page_Home_Window_Title);
                base.SelectWindow(HomePageResource.Home_Page_Home_Window_Title);
                base.FocusOnElementByID(HomePageResource.
                    Home_Page_Product_AddButton_Id_Locator);
                //Click on the "Add" button
                base.ClickButtonByID(HomePageResource.
                    Home_Page_Product_AddButton_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("HomePage", "ClickTheAddButton",
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
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
               base.isTakeScreenShotDuringEntryExit);
            return getProductName;
        }

        /// <summary>
        /// Select the lightbox frame
        /// </summary>
        private void SelectLightBoxFrame()
        {
            //Select the lightbox frame
            logger.LogMethodEntry("HomePage", "SelectLightBoxFrame",
               base.isTakeScreenShotDuringEntryExit);
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
            catch (Exception ex) { logger.LogMessage("HomePage", "SelectLightBoxFrame", "Error in switching setup wizard frame"); }
            logger.LogMethodExit("HomePage", "SelectLightBoxFrame",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click the "Cancel" button
        /// </summary>
        public void ClickTheCancelButton()
        {
            //Click the "Cancel" button
            logger.LogMethodEntry("HomePage", "ClickTheCancelButton",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.FocusOnElementByID(HomePageResource.
                       Home_Page_Cancel_Button_Id_Locator);
                //Click the "Cancel" button
                base.ClickButtonByID(HomePageResource.
                    Home_Page_Cancel_Button_Id_Locator);
                base.FocusOnElementByID(HomePageResource.
                    Home_Page_YesCancel_Button_Id_Locator);
                //Click on the"Yes,Cancel" button
                base.ClickButtonByID(HomePageResource.
                    Home_Page_YesCancel_Button_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("HomePage", "ClickTheCancelButton",
               base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
            //Variable Declaration of get class name
            string getClassNameText = string.Empty;
            try
            {
                //Select the window name
                base.SelectWindow(HomePageResource.
                        Home_Page_Home_Window_Title);
                //Get the number of class count
                int getClassCount = base.GetElementCountByXPath(HomePageResource.
                    HomePage_ClassesDivCount_Xpath_Locator);
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
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("HomePage", "GetDisplayClassName",
               base.isTakeScreenShotDuringEntryExit);
            return getClassNameText;
        }

        /// <summary>
        /// Signout from application by DP CS Teacher.
        /// </summary>
        public void SignoutByDigitalPathCSTeacher(String linkSignOut)
        {
            //Signout from application by DP CS Teacher
            logger.LogMethodEntry("HomePage", "SignoutByDigitalPathCSTeacher",
                     base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Default Window
                base.SelectDefaultWindow();
                //Click on Button
                base.WaitForElement(By.Id(HomePageResource.
                    HomePage_UserProfile_Image_Id_Locator));
                base.ClickButtonByID(HomePageResource.
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
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Signout from application by DP CS Student.
        /// </summary>
        /// <param name="linkSignOut">This is Sign Out Link text</param>
        public void SignOutByDigitalPathCSStudent(string linkSignOut)
        {
            //Signout from application by DP CS Student
            logger.LogMethodEntry("HomePage", "SignOutByDigitalPathCSStudent",
                     base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Default Window
                base.SelectDefaultWindow();
                //Click on Button
                base.WaitForElement(By.Id(HomePageResource.
                    HomePage_DownArrowLink_Id_locator));
                base.ClickButtonByID(HomePageResource.
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
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the Mail Message 'View All' link.
        /// </summary>
        public void ClickMessagesViewAllLink(User.UserTypeEnum userTypeEnum)
        {
            //Click Message View All Link
            logger.LogMethodEntry("HomePage", "ClickMessagesViewAllLink",
                base.isTakeScreenShotDuringEntryExit);
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
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Manage All Button In GlobalHome.
        /// </summary>
        public void ClickTheManageAllButtonInGlobalHome()
        {
            //Click The Manage All Button In GlobalHome
            logger.LogMethodEntry("HomePage", "ClickTheManageAllButtonInGlobalHome",
                base.isTakeScreenShotDuringEntryExit);
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
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Gets the displayed welcome message on Home Page.
        /// </summary>
        /// <returns></returns>
        public string GetWelcomeMessage()
        {
            logger.LogMethodEntry("HomePage", "GetWelcomeMessage",
               base.isTakeScreenShotDuringEntryExit);
            string welcomeMessage;

            SelectLightBoxFrame();
            base.WaitForElement(By.Id(HomePageResource.HomePage_WelcomeMessage_Div_Id_Locator));
            welcomeMessage = base.GetElementTextByID(
                HomePageResource.HomePage_WelcomeMessage_Div_Id_Locator);

            logger.LogMethodExit("HomePage", "GetWelcomeMessage",
              base.isTakeScreenShotDuringEntryExit);
            return welcomeMessage;
        }

        /// <summary>
        /// Gets the Welcome banner Src attribute value
        /// </summary>
        /// <returns></returns>
        public string GetWelcomeBannerSrcAttribute()
        {
            logger.LogMethodEntry("HomePage", "GetWelcomeBannerSrcAttribute",
               base.isTakeScreenShotDuringEntryExit);
            string welcomeBannerSrc = String.Empty;

            SelectLightBoxFrame();
            base.WaitForElement(By.Id(HomePageResource.HomePage_WelcomeBanner_Img_Id_Locator));
            if (base.IsElementDisplayedByID(HomePageResource.HomePage_WelcomeBanner_Img_Id_Locator))
            {
                IWebElement bannerImage = base.GetWebElementPropertiesById(
                    HomePageResource.HomePage_WelcomeBanner_Img_Id_Locator);
                welcomeBannerSrc = bannerImage.GetAttribute("src");//the method supposed to return Src attribute value only
                //so, need to get dynamically attribute key.
            }

            logger.LogMethodExit("HomePage", "GetWelcomeBannerSrcAttribute",
             base.isTakeScreenShotDuringEntryExit);
            return welcomeBannerSrc;
        }

        /// <summary>
        /// Gets the text in button on Welcome message box
        /// </summary>
        /// <returns></returns>
        public string GetWelcomeMessageButtonText()
        {
            logger.LogMethodEntry("HomePage", "GetWelcomeMessageButtonText",
              base.isTakeScreenShotDuringEntryExit);
            string welcomeMessageButtonText;

            SelectLightBoxFrame();
            base.WaitForElement(By.Id(HomePageResource.HomePage_WelcomeMessage_Button_Id_Locator));
            welcomeMessageButtonText = base.GetElementTextByID(HomePageResource.HomePage_WelcomeMessage_Button_Id_Locator);

            logger.LogMethodExit("HomePage", "GetWelcomeMessageButtonText",
              base.isTakeScreenShotDuringEntryExit);
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
             base.isTakeScreenShotDuringEntryExit);

            SelectLightBoxFrame();
            base.WaitForElement(By.Id(
                HomePageResource.HomePage_WelcomeMessage_Button_Id_Locator));
            base.ClickButtonByID(HomePageResource
                .HomePage_WelcomeMessage_Button_Id_Locator);

            logger.LogMethodExit("HomePage", "ClickWelcomeMessageBoxNavigationButton",
              base.isTakeScreenShotDuringEntryExit);
        }
    }
}
