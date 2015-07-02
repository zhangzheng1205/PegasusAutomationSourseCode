using System;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.SMSIntegration.ProgramManagement;
using Pegasus.Pages.Exceptions;
using System.Threading;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Manage Products Page Actions.
    /// </summary>
    public class ManageProductsPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(ManageProductsPage));

        /// <summary>
        /// Click on Create New Product Link.
        /// </summary>
        public void ClickOnCreateNewProductLink()
        {
            //Click on Create New Product Link
            Logger.LogMethodEntry("ManageProductsPage", "ClickOnCreateNewProductLink",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                base.SelectWindow(ManageProductsPageResource.
                        ManageProducts_Page_Window_Title_Name);
                //Select IFrame
                this.SelectManageProductsIFrame();
                //Select Right Frame
                this.SelectRightIFrame();
                //Click on Button
                Thread.Sleep(20000);
                base.WaitForElement(By.PartialLinkText(ManageProductsPageResource.
                    ManageProducts_Page_CreateNewProduct_PartialLinkText_Locator));
                base.ClickByJavaScriptExecutor(
                    base.GetWebElementPropertiesByPartialLinkText(ManageProductsPageResource.
                    ManageProducts_Page_CreateNewProduct_PartialLinkText_Locator));
                //Switch To Default Window
                base.SwitchToDefaultWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageProductsPage", "ClickOnCreateNewProductLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selects Right Frame.
        /// </summary>
        private void SelectRightIFrame()
        {
            //Select Right IFrame
            Logger.LogMethodEntry("ManageProductsPage", "SelectRightIFrame",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(ManageProductsPageResource.
                                          ManageProducts_Page_IFrameRight_Id_Locator));
            //Switch To IFrame
            base.SwitchToIFrame(ManageProductsPageResource.
                                    ManageProducts_Page_IFrameRight_Id_Locator);
            Logger.LogMethodExit("ManageProductsPage", "SelectRightIFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Manage Products IFrame.
        /// </summary>
        private void SelectManageProductsIFrame()
        {
            //Select Frame
            Logger.LogMethodEntry("ManageProductsPage", "SelectManageProductsIFrame",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(ManageProductsPageResource.
                                          ManageProducts_Page_IFrame_Id_Locator));
            //Switch To IFrame
            base.SwitchToIFrame(ManageProductsPageResource.
                                    ManageProducts_Page_IFrame_Id_Locator);
            Logger.LogMethodExit("ManageProductsPage", "SelectManageProductsIFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Searched Product in Product Frame.
        /// </summary>
        /// <param name="productName">This is Product Name.</param>
        public void SelectProductInProductFrame
            (String productName)
        {
            //Find Search Product in Product Frame
            Logger.LogMethodEntry("ManageProductsPage", "SelectProductInProductFrame",
                base.IsTakeScreenShotDuringEntryExit);
            //Variable Declaration
            string getSubstring = string.Empty;
            try
            {
                //Get the End Index of Substring
                int getSubstringEndIndex = Convert.ToInt32(productName.Length) / 
                    Convert.ToInt32(ManageProductsPageResource.
                    ManageProducts_Page_ProductLength_Divident_Value);
                //Get Substring of Product
                getSubstring = productName.Substring(Convert.ToInt32
                    (ManageProductsPageResource.ManageProducts_Page_Product_Substring_Start_Index),
                    getSubstringEndIndex);
                //Search Product
                base.WaitForElement(By.PartialLinkText(getSubstring));
                IWebElement getProductLink = base.GetWebElementPropertiesByPartialLinkText
                    (getSubstring);
                //Click Button 
                base.ClickByJavaScriptExecutor(getProductLink);
                //Switch Default Window
                base.SwitchToDefaultPageContent();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageProductsPage", "SelectProductInProductFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Product Cmenu Option.
        /// </summary>
        /// <param name="cmenuOption">This is Cmenu Option.</param>
        public void SelectProductCmenuOption(string cmenuOption)
        {
            //Select Product Cmenu Option
            Logger.LogMethodEntry("ManageProductsPage", "SelectProductCmenuOption",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                ProductManagementContainerPage productManagementContainerPage
                    = new ProductManagementContainerPage();
                //Select Product Window
                productManagementContainerPage.SelectProductWindow();
                //Select Main Frame
                productManagementContainerPage.SelectWorkSpaceIFrame();
                //Select Right Frame
                productManagementContainerPage.SelectIFrameRight();
                base.WaitForElement(By.XPath(ManageProductsPageResource.
                    ManageProducts_Page_Cmenu_Icon_Xpath_Locator));
                base.FillEmptyTextByXPath(ManageProductsPageResource.
                    ManageProducts_Page_Cmenu_Icon_Xpath_Locator);
                //Click on Product Cmenu Icon
                IWebElement getCmenuIcon =
                    base.GetWebElementPropertiesByXPath(ManageProductsPageResource.
                    ManageProducts_Page_Cmenu_Icon_Xpath_Locator);
                base.ClickByJavaScriptExecutor(getCmenuIcon);
                base.WaitForElement(By.PartialLinkText(cmenuOption));
                //Select Product Cmenu Option
                IWebElement getProductCmenu =
                    base.GetWebElementPropertiesByPartialLinkText(cmenuOption);
                base.ClickByJavaScriptExecutor(getProductCmenu);
                //Click On Message Ok Button
                this.ClickOnMessageOkButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageProductsPage", "SelectProductCmenuOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Message Ok Button.
        /// </summary>
        public void ClickOnMessageOkButton()
        {
            //Click On Message Ok Button
            Logger.LogMethodEntry("ManageProductsPage", "ClickOnMessageOkButton",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Pegasus Window
                this.SelectPegasusWindow();
                base.WaitForElement(By.Id(ManageProductsPageResource.
                ManageProducts_Page_Message_Ok_Button_Id_Locator));
                //Click on Ok Button
                IWebElement getOkButtonProperty =
                    base.GetWebElementPropertiesById(ManageProductsPageResource.
                    ManageProducts_Page_Message_Ok_Button_Id_Locator);
                base.ClickByJavaScriptExecutor(getOkButtonProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageProductsPage", "ClickOnMessageOkButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Pegasus Window.
        /// </summary>
        private void SelectPegasusWindow()
        {
            //Select Pegasus Window
            Logger.LogMethodEntry("ManageProductsPage", "SelectPegasusWindow",
               base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(ManageProductsPageResource.
                    ManageProducts_Page_Window_Name);
            //Select Window
            base.SelectWindow(ManageProductsPageResource.
                ManageProducts_Page_Window_Name);            
            Logger.LogMethodExit("ManageProductsPage", "SelectPegasusWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
