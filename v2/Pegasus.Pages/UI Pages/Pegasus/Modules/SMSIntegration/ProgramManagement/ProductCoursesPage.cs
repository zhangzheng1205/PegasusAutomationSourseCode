using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.SMSIntegration.ProgramManagement;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles the product course related actions.
    /// </summary>
    public class ProductCoursesPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(ProductCoursesPage));

        /// <summary>
        /// Select Product Course Contextual Menu Option.
        /// </summary>
        /// <param name="courseName">This is Course Name.</param>
        /// <param name="contextualMenuOptionName">This is Cmenu Option.</param>
        public void SelectProductCourseContextualMenuOption
            (String courseName, String contextualMenuOptionName)
        {
            //Select Product Course Contextual Menu Option
            Logger.LogMethodEntry("ProductCoursesPage",
                                  "SelectCoursePreferenceOption",
                                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectManageProductsWindow();
                //Select Product WorkSpace IFrame
                this.SelectWorkSpaceIFrame();
                //Select IFrame Right
                this.SelectIFrameRight();
                //Select Course Contextual Menu Option
                this.ClickProductCourseContextualMenuOption
                    (courseName, contextualMenuOptionName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ProductCoursesPage",
                                 "SelectCoursePreferenceOption",
                                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Product WorkSpace IFrame.
        /// </summary>
        private void SelectWorkSpaceIFrame()
        {
            //Select WorkSpace IFrame
            Logger.LogMethodEntry("ClickSearchProductLink", "SelectWorkSpaceIFrame",
           base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(ProductManagementContainerPageResource.
                                          ProductManagementContainer_Page_SearchCourses_Frame_Locator));
            //Switch To Frame
            base.SwitchToIFrame(ProductManagementContainerPageResource.
                                    ProductManagementContainer_Page_SearchCourses_Frame_Locator);
            Logger.LogMethodExit("ClickSearchProductLink", "SelectWorkSpaceIFrame",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Product IFrame Right.
        /// </summary>
        private void SelectIFrameRight()
        {
            //Select IFrame Right
            Logger.LogMethodEntry("ClickSearchProductLink", "SelectIFrameRight",
               base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(ProductManagementContainerPageResource.
                                    ProductManagementContainer_Page_IFrameRight_Id_Locator));
            //Switch To Frame
            base.SwitchToIFrame(ProductManagementContainerPageResource.
                                    ProductManagementContainer_Page_IFrameRight_Id_Locator);
            Logger.LogMethodExit("ClickSearchProductLink", "SelectIFrameRight",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Manage Products Window.
        /// </summary>
        private void SelectManageProductsWindow()
        {
            //Select Manage Products Window
            Logger.LogMethodEntry("ProductCoursesPage", "SelectManageProductsWindow",
                                  base.IsTakeScreenShotDuringEntryExit);
            //Select Window
            base.SelectWindow(ProductCoursesPageResource.
                                  ProductCourse_Page_ManageProducts_Window_Title);
            Logger.LogMethodExit("ProductCoursesPage", "SelectManageProductsWindow",
                                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Product Course Contextual Menu Option. 
        /// </summary>
        /// <param name="productCourseName">This is product course name.</param>
        /// <param name="courseContextualMenuOptionName">This is contextual menu option name.</param>
        private void ClickProductCourseContextualMenuOption
            (String productCourseName, String courseContextualMenuOptionName)
        {
            //Click Product Course Contextual Menu
            Logger.LogMethodEntry("ProductCoursesPage", "ClickProductCourseContextualMenuOption",
                                   base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            WaitForElement(By.XPath(ProductCoursesPageResource.
                ProductCourse_Page_ProgramCourse_Grid_XPath_Locator));
            //Get Course Count
            int getTotalCourseRowCount =
                base.GetElementCountByXPath(ProductCoursesPageResource.
                ProductCourse_Page_ProgramCourse_Grid_XPath_Locator);
            //Iterate For Respective Course In Grid
            for (int setCourseRowCount = Convert.ToInt32(ProductCoursesPageResource.
                ProductCourse_Page_Loop_Initial_Value); setCourseRowCount <= getTotalCourseRowCount;
                setCourseRowCount++)
            {
                //Get Product Course Name
                String getProductCourseName =
                    base.GetTitleAttributeValueByXPath(
                        String.Format(ProductCoursesPageResource.
                        ProductCourse_Page_ProgramCourse_Grid_Row_XPath_Locator,
                        setCourseRowCount));
                if (productCourseName.Equals(getProductCourseName))
                {
                    //Click on Contextual Icon
                    this.ClickOnProductCourseContextualIcon(setCourseRowCount);
                    //Click on Contextual Menu Option Name
                    this.ClickOnProductCourseContextualMenuOptionName(courseContextualMenuOptionName);
                }
            }
            //Select To Default Window 
            base.SwitchToDefaultPageContent();
            Logger.LogMethodExit("ProductCoursesPage", "ClickProductCourseContextualMenuOption",
                                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Product Course Contextual Menu Option Name.
        /// </summary>
        /// <param name="courseContextualMenuOptionName">
        /// This is name of the course contextual option.</param>
        private void ClickOnProductCourseContextualMenuOptionName
            (String courseContextualMenuOptionName)
        {
            //Click on Course Contextual Menu Option Name
            Logger.LogMethodEntry("ProductCoursesPage",
                "ClickOnProductCourseContextualMenuOptionName",
                                  base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.PartialLinkText(courseContextualMenuOptionName));
            //Get Element Property
            IWebElement getCourseControlMenuOptionProperty =
                base.GetWebElementPropertiesByPartialLinkText(courseContextualMenuOptionName);
            //Click on Contextual Option Name
            base.ClickByJavaScriptExecutor(getCourseControlMenuOptionProperty);
            Logger.LogMethodEntry("ProductCoursesPage",
                "ClickOnProductCourseContextualMenuOptionName",
                                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Product Course Contextual Menu Icon.
        /// </summary>
        /// <param name="courseRowNumber">This is a product course row number in a grid.</param>
        private void ClickOnProductCourseContextualIcon(int courseRowNumber)
        {
            //Click on Contextaul Icon
            Logger.LogMethodEntry("ProductCoursesPage", "ClickOnProductCourseContextualIcon",
                                  base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.XPath(String.Format(ProductCoursesPageResource.
                ProductCourse_Page_ProgramCourse_ContextualMenu_Icon_XPath_Locator,
                        courseRowNumber)));
            //Get Element Property
            IWebElement getContextualImageProperty =
                base.GetWebElementPropertiesByXPath(String.Format(ProductCoursesPageResource.
                ProductCourse_Page_ProgramCourse_ContextualMenu_Icon_XPath_Locator,
                courseRowNumber));
            //Set Focus on the Element
            getContextualImageProperty.SendKeys(string.Empty);
            //Click on the Course Contextual Menu Icon
            base.ClickByJavaScriptExecutor(getContextualImageProperty);
            Logger.LogMethodEntry("ProductCoursesPage", "ClickOnProductCourseContextualIcon",
                                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Course Contextual Menu Option In Product. 
        /// </summary>
        /// <param name="productCourseName">This is product course name.</param>
        /// <param name="courseContextualMenuOptionName">This is contextual menu option name.</param>
        private void ClickCourseContextualMenuOptionInProduct
            (String productCourseName, String courseContextualMenuOptionName)
        {
            //Click Product Course Contextual Menu
            Logger.LogMethodEntry("ProductCoursesPage","ClickCourseContextualMenuOptionInProduct",
                                   base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.XPath(ProductCoursesPageResource.
                ProductCourse_Page_ProgramCourse_Grid_XPath_Locator));
            //Get Course Count
            int getTotalCourseRowCount =
                base.GetElementCountByXPath(ProductCoursesPageResource.
                ProductCourse_Page_ProgramCourse_Grid_XPath_Locator);
            //Iterate For Respective Course In Grid
            for (int setCourseRowCount = Convert.ToInt32(ProductCoursesPageResource.
                ProductCourse_Page_Loop_Initial_Value);
                setCourseRowCount <= getTotalCourseRowCount;
                setCourseRowCount++)
            {
                //Get Product Course Name
                String getProductCourseName =
                    base.GetTitleAttributeValueByXPath(
                        String.Format(ProductCoursesPageResource.
                        ProductCourse_Page_ProgramCourse_Grid_Row_XPath_Locator,
                        setCourseRowCount));
                if (getProductCourseName.Contains(productCourseName))
                {
                    //Click on Contextual Icon
                    this.ClickOnProductCourseContextualIcon(setCourseRowCount);
                    //Click on Contextual Menu Option Name
                    this.ClickOnProductCourseContextualMenuOptionName(courseContextualMenuOptionName);
                }
            }
            //Select To Default Window 
            base.SwitchToDefaultPageContent();
            Logger.LogMethodExit("ProductCoursesPage","ClickCourseContextualMenuOptionInProduct",
                                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Course Contextual Menu Option In Product.
        /// </summary>
        /// <param name="courseName">This is Course Name.</param>
        /// <param name="contextualMenuOptionName">This is Cmenu Option.</param>
        public void SelectCourseContextualMenuOptionInProduct
            (String courseName, String contextualMenuOptionName)
        {
            //Select Product Course Contextual Menu Option
            Logger.LogMethodEntry("ProductCoursesPage",
                                  "SelectCourseContextualMenuOptionInProduct",
                                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectManageProductsWindow();
                //Select Product WorkSpace IFrame
                this.SelectWorkSpaceIFrame();
                //Select IFrame Right
                this.SelectIFrameRight();
                //Select Course Contextual Menu Option
                this.ClickCourseContextualMenuOptionInProduct
                    (courseName, contextualMenuOptionName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ProductCoursesPage",
                                 "SelectCourseContextualMenuOptionInProduct",
                                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Course State.
        /// </summary>
        /// <param name="courseName">This is Product Course Name.</param>
        /// <returns>This is Course Status.</returns>
        public string GetCourseState(string productCourseName)
        {
            //Get Course State
            Logger.LogMethodEntry("ProductCoursesPage","GetCourseState",
                                  base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getCourseState = string.Empty;
            try
            {
                //Select Window And Get Course Count
                int getTotalCourseRowCount = this.SelectWindowAndGetCourseCount();
                //Iterate For Respective Course In Grid
                for (int setCourseRowCount = Convert.ToInt32(ProductCoursesPageResource.
                    ProductCourse_Page_Loop_Initial_Value);
                    setCourseRowCount <= getTotalCourseRowCount;
                    setCourseRowCount++)
                {
                    //Get Product Course Name
                    base.WaitForElement(By.XPath(String.Format(ProductCoursesPageResource.
                            ProductCourse_Page_ProgramCourse_Grid_Row_XPath_Locator,
                            setCourseRowCount)));
                    String getProductCourseName =
                        base.GetTitleAttributeValueByXPath(
                            String.Format(ProductCoursesPageResource.
                            ProductCourse_Page_ProgramCourse_Grid_Row_XPath_Locator,
                            setCourseRowCount));
                    if (getProductCourseName.Contains(productCourseName))
                    {
                        base.WaitForElement(By.XPath(string.Format(ProductCoursesPageResource.
                            ProductCourse_Page_ProductCourse_Status_Xpath_Locator,
                            setCourseRowCount)));
                        //Get Course State
                        getCourseState = base.GetElementTextByXPath(string.Format(ProductCoursesPageResource.
                            ProductCourse_Page_ProductCourse_Status_Xpath_Locator,
                            setCourseRowCount));
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }            
            Logger.LogMethodExit("ProductCoursesPage","GetCourseState",
                                 base.IsTakeScreenShotDuringEntryExit);
            return getCourseState;
        }

        /// <summary>
        /// Select Window And Get Course Count.
        /// </summary>
        /// <returns>Course Count.</returns>
        private int SelectWindowAndGetCourseCount()
        {
            //Select Window And Get Course Count
            Logger.LogMethodEntry("ProductCoursesPage", "SelectWindowAndGetCourseCount",
                                  base.IsTakeScreenShotDuringEntryExit);
            //Select Window
            this.SelectManageProductsWindow();
            //Select Product WorkSpace IFrame
            this.SelectWorkSpaceIFrame();
            //Select IFrame Right
            this.SelectIFrameRight();
            //Wait For Element
            base.WaitForElement(By.XPath(ProductCoursesPageResource.
                ProductCourse_Page_ProgramCourse_Grid_XPath_Locator));
            //Get Course Count
            int getTotalCourseRowCount =
                base.GetElementCountByXPath(ProductCoursesPageResource.
                ProductCourse_Page_ProgramCourse_Grid_XPath_Locator);            
            Logger.LogMethodExit("ProductCoursesPage", "SelectWindowAndGetCourseCount",
                                 base.IsTakeScreenShotDuringEntryExit);
            return getTotalCourseRowCount;
        }

        /// <summary>
        /// Click The Product Cmenu Option.
        /// </summary>
        public void ClickTheProductCmenuOption()
        {
            //Select Window And Get Course Count
            Logger.LogMethodEntry("ProductCoursesPage", "ClickTheProductCmenuOption",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectManageProductsWindow();
                //Select Product WorkSpace IFrame
                this.SelectWorkSpaceIFrame();
                //Select IFrame Right
                this.SelectIFrameRight();
                //Wait for the element
                base.WaitForElement(By.XPath(ProductCoursesPageResource.
                    ProductCourse_Page_ProductCmenu_Image_XPath_Locator));
                base.FocusOnElementByXPath(ProductCoursesPageResource.
                    ProductCourse_Page_ProductCmenu_Image_XPath_Locator);
                IWebElement getProductCmenuImage = base.GetWebElementPropertiesByXPath
                    (ProductCoursesPageResource.
                    ProductCourse_Page_ProductCmenu_Image_XPath_Locator);
                base.ClickByJavaScriptExecutor(getProductCmenuImage);
                Thread.Sleep(Convert.ToInt32(ProductCoursesPageResource.
                    ProductCourse_Page_Element_WaitTime));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ProductCoursesPage", "ClickTheProductCmenuOption",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Display Of Product Cmenu Options.
        /// </summary>
        /// <param name="actualCmenuOption">this is Actual cmneu.</param>
        /// <returns>Cmenu options.</returns>
        public string GetDisplayOfProductCmenuOptions(string actualCmenuOption)
        {
            //Get Display Of Product Cmenu Options
            Logger.LogMethodEntry("ProductCoursesPage",
                "GetDisplayOfProductCmenuOptions",
                 base.IsTakeScreenShotDuringEntryExit);
            //Initialize Activity Cmenuoptions Variable
            string getDisplayOfProductCmenuOptions = string.Empty;
            try
            {
                //Wait for the element
                base.WaitForElement(By.XPath(ProductCoursesPageResource.
                    ProductCourse_Page_Product_CmenuOptions_XPath_Locator));
                //Get the cmenu options
                getDisplayOfProductCmenuOptions = base.GetElementTextByXPath
                    (ProductCoursesPageResource.
                    ProductCourse_Page_Product_CmenuOptions_XPath_Locator);
                if (getDisplayOfProductCmenuOptions.Contains(actualCmenuOption))
                {
                    //Compare the cmenu options
                    getDisplayOfProductCmenuOptions = actualCmenuOption;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ProductCoursesPage",
                "GetDisplayOfProductCmenuOptions",
                          base.IsTakeScreenShotDuringEntryExit);
            return getDisplayOfProductCmenuOptions;
        }
    }
}
