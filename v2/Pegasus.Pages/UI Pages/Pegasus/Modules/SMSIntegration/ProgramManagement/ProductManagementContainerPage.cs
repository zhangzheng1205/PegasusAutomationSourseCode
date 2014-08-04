using System;
using OpenQA.Selenium;
using System.Globalization;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.SMSIntegration.ProgramManagement;
using OpenQA.Selenium.Interactions;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class handles the actions of Product Management Container Page.
    /// </summary>
    public class ProductManagementContainerPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(ProductManagementContainerPage));

        /// <summary>
        /// This method click on the Search Courses link.
        /// </summary>
        public void ClickSearchCoursesLink()
        {
            //Method To click on the Search Courses Link
            Logger.LogMethodEntry("ProductManagementContainerPage", "ClickSearchCoursesLink",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Parent Window
                base.SelectDefaultWindow();
                //Wait For Element
                base.WaitForElement(By.Id(ProductManagementContainerPageResource.
                    ProductManagementContainer_Page_SearchCourses_Frame_Locator));
                //Switch To Frame
                base.SwitchToIFrame(ProductManagementContainerPageResource.
                    ProductManagementContainer_Page_SearchCourses_Frame_Locator);
                //Wait For Element
                base.WaitForElement(By.Id(ProductManagementContainerPageResource.
                    ProductManagementContainer_Page_SearchCourses_Link_Locator));
                //Get HTML Element Properties
                IWebElement leftSearchPanel = base.GetWebElementPropertiesById(
                    ProductManagementContainerPageResource.
                    ProductManagementContainer_Page_SearchCourses_Link_Locator);
                //Clicking Course Search Link
                base.ClickByJavaScriptExecutor(leftSearchPanel);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ProductManagementContainerPage", "ClickSearchCoursesLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This method click on the Search Product link.
        /// </summary>
        public void ClickSearchProductLink()
        {
            //Method To click on the Search Product Link
            Logger.LogMethodEntry("ProductManagementContainerPage", "ClickSearchProductLink",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Product Window
                this.SelectProductWindow();
                //Select Product WorkSpace IFrame
                this.SelectWorkSpaceIFrame();
                //Wait For Element
                base.WaitForElement(By.Id(ProductManagementContainerPageResource.
                    ProductManagementContainer_Page_SearchProduct_Link_Locator));
                //Get Link Property
                IWebElement getLinkProperty = base.GetWebElementPropertiesById
                    (ProductManagementContainerPageResource.
                    ProductManagementContainer_Page_SearchProduct_Link_Locator);
                //Click on Button
                base.ClickByJavaScriptExecutor(getLinkProperty);
                //Switch To Default Window
                base.SwitchToDefaultPageContent();
                //Select Product Window
                this.SelectProductWindow();
                //Select Product WorkSpace IFrame
                this.SelectWorkSpaceIFrame();
                //Select IFrame Right
                this.SelectIFrameRight();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ProductManagementContainerPage", "ClickSearchProductLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Window. 
        /// </summary>
        public void SelectProductWindow()
        {
            //Select Window
            Logger.LogMethodEntry("ProductManagementContainerPage", "SelectProductWindow",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                base.WaitUntilWindowLoads(ProductManagementContainerPageResource.
                       ProductManagementContainer_Page_Window_Title);
                base.SelectWindow(ProductManagementContainerPageResource.
                       ProductManagementContainer_Page_Window_Title);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ProductManagementContainerPage", "SelectProductWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Product IFrame Right.
        /// </summary>
        public void SelectIFrameRight()
        {
            //Select IFrame Right
            Logger.LogMethodEntry("ProductManagementContainerPage", "SelectIFrameRight",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Element
                base.WaitForElement(By.Id(ProductManagementContainerPageResource.
                                        ProductManagementContainer_Page_IFrameRight_Id_Locator));
                //Switch To Frame
                base.SwitchToIFrame(ProductManagementContainerPageResource.
                                        ProductManagementContainer_Page_IFrameRight_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ProductManagementContainerPage", "SelectIFrameRight",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Product WorkSpace IFrame.
        /// </summary>
        public void SelectWorkSpaceIFrame()
        {
            //Select WorkSpace IFrame
            Logger.LogMethodEntry("ProductManagementContainerPage", "SelectWorkSpaceIFrame",
           base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Element
                base.WaitForElement(By.Id(ProductManagementContainerPageResource.
                   ProductManagementContainer_Page_SearchCourses_Frame_Locator));
                //Switch To Frame
                base.SwitchToIFrame(ProductManagementContainerPageResource.
                   ProductManagementContainer_Page_SearchCourses_Frame_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ProductManagementContainerPage", "SelectWorkSpaceIFrame",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Product Course Preference Option.
        /// </summary>
        public void ClickonProductCoursePreferenceOption()
        {
            //Click on Product Course Preference Option
            Logger.LogMethodEntry("ProductManagementContainerPage",
                "ClickonProductCoursePreferenceOption", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Product Window
                this.SelectProductWindow();
                //Select Product WorkSpace IFrame
                this.SelectWorkSpaceIFrame();
                //Select IFrame Right
                this.SelectIFrameRight();
                //Wait for the element
                base.WaitForElement(By.XPath(ProductManagementContainerPageResource.
                    ProductManagementContainer_Page_Course_CmenuImage_Xpath_Locator));
                IWebElement getCourseCmenuOption = base.GetWebElementPropertiesByXPath
                  (ProductManagementContainerPageResource.
                    ProductManagementContainer_Page_Course_CmenuImage_Xpath_Locator);
                //Click the cmenu image option
                base.ClickByJavaScriptExecutor(getCourseCmenuOption);
                //Wait for the element
                base.WaitForElement(By.XPath(ProductManagementContainerPageResource.
                    ProductManagementContainer_Page_Course_CmenuPreference_Xpath_Locator));
                IWebElement getCourseCmenuPreferenceOption = base.GetWebElementPropertiesByXPath
                  (ProductManagementContainerPageResource.
                    ProductManagementContainer_Page_Course_CmenuPreference_Xpath_Locator);
                //Click the cmenu preference option
                base.ClickByJavaScriptExecutor(getCourseCmenuPreferenceOption);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ProductManagementContainerPage",
                "ClickonProductCoursePreferenceOption", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Integration PointID.
        /// </summary>
        public void GetIntegrationPointID()
        {
            //Get Integration PointID
            Logger.LogMethodEntry("ProductManagementContainerPage",
                "GetIntegrationPointID", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Edit Enrollment Window
                this.SelectEditEnrollmentWindow();
                //Wait for the element
                base.WaitForElement(By.Id(ProductManagementContainerPageResource.
                    ProductManagementContainer_Page_CCNGIntegrationPointID_Text));
                //Get the Integration PointID
                String getCCNGPointIDText = GetElementTextById(
                    ProductManagementContainerPageResource.
                    ProductManagementContainer_Page_CCNGIntegrationPointID_Text);
                String[] getCCNGPointID = getCCNGPointIDText.Split(
                    Convert.ToChar(ProductManagementContainerPageResource.
                    ProductManagementContainer_Page_Integration_SplitValue));
                String IntegrationPointID = getCCNGPointID[
                    Convert.ToInt32(ProductManagementContainerPageResource.
                    ProductManagementContainer_Page_Integration_IndextValue)];
                //Store Integration PointID in Memory
                this.StoreIntegrationPointIDInMemory(IntegrationPointID);
                base.CloseBrowserWindow();
            }
            catch (Exception e)
            {
              ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ProductManagementContainerPage",
               "GetIntegrationPointID", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Edit Enrollment Window.
        /// </summary>
        private void SelectEditEnrollmentWindow()
        {
            //Select Edit Enrollment Window
            Logger.LogMethodEntry("ProductManagementContainerPage",
                "SelectEditEnrollmentWindow", base.IsTakeScreenShotDuringEntryExit);
            //Wait for the window
            base.WaitUntilWindowLoads(ProductManagementContainerPageResource.
                ProductManagementContainer_Page_EditEnrollmentWindow_Title);
            //Select Window
            base.SelectWindow(ProductManagementContainerPageResource.
                ProductManagementContainer_Page_EditEnrollmentWindow_Title);
            Logger.LogMethodExit("ProductManagementContainerPage",
               "SelectEditEnrollmentWindow", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store Integration PointID In Memory.
        /// </summary>
        /// <param name="IntegrationPointID">This is Integration Point ID.</param>
        private void StoreIntegrationPointIDInMemory(string CCNGIntegrationPointID)
        {
            //Store Integration PointID In Memory
            Logger.LogMethodEntry("ProductManagementContainerPage",
                "StoreIntegrationPointIDInMemory", base.IsTakeScreenShotDuringEntryExit);
            Course course = new Course
            {
                IntegrationPointId = CCNGIntegrationPointID,
                CourseType = Course.CourseTypeEnum.IntegrationPointID,
                IsCreated = true,
            };
            course.StoreCourseInMemory();
            Logger.LogMethodExit("ProductManagementContainerPage",
                "StoreIntegrationPointIDInMemory", base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
