using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Common.SetupWizard;
using System.Threading;
using Pegasus.Automation.DataTransferObjects;

namespace Pegasus.Pages.UI_Pages
{

    public class frmSetupWizardPage : BasePage
    {

        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(ShowMessagePage));

        private static string pageTitleFromSetupWizard = null;
        /// <summary>
        ///  Get setup wizard light box title.
        /// </summary>
        /// <returns>Page title</returns>
        public string GetSetupWizardPopUpTitle()
        {
            //Get setup wizard light box title.
            logger.LogMethodEntry("frmSetupWizardPage", "GetSetupWizardPopUpTitle",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize variable
            string popUpTitle = null;
            try
            {
                //Switch to setup wizard parent iframe
                base.SwitchToIFrameById(frmSetupWizardPageResource.
                    frmSetupWizardPageResource_SetupWizardParent_Iframe_Id_Locator);
                //Get light box title
                popUpTitle = base.GetElementTextByXPath(frmSetupWizardPageResource.
                frmSetupWizardPageResource_SetupWizard_PopupHeader_Title_Xpath_Locator);
                //Switch to setup wizard inner iframe
                base.SwitchToIFrameById(frmSetupWizardPageResource.
                  frmSetupWizardPageResource_SetupWizard_Iframe_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("frmSetupWizardPage", "GetSetupWizardPopUpTitle",
               base.IsTakeScreenShotDuringEntryExit);
            //Return the light boz title
            return popUpTitle;
        }

        /// <summary>
        /// Enter class name.
        /// </summary>
        /// <param name="classTypeEnum">Enum type.</param>
        public void EnterClassName(Class.ClassTypeEnum classTypeEnum)
        {
            //Enter class name
            logger.LogMethodEntry("frmSetupWizardPage", "EnterClassName",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                Guid className = Guid.NewGuid();
                base.WaitForElement(By.Id(frmSetupWizardPageResource.
                frmSetupWizardPageResource_ClassName_TextBox_Id_Locator));
                //Enter the text in class name
                base.FillTextBoxById(frmSetupWizardPageResource.
                    frmSetupWizardPageResource_ClassName_TextBox_Id_Locator, className.ToString());
                //Store the class in memory
                Class Class = Class.Get(classTypeEnum);
                Class.UpdateClassName(className.ToString());

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("frmSetupWizardPage", "EnterClassName",
               base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Click on select product button in setup wizard while class creation.
        /// </summary>
        public void ClickSelectProductButton()
        {
            //Click on select product button
            logger.LogMethodEntry("frmSetupWizardPage", "ClickSelectProductButton",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for select product button
                base.WaitForElement(By.Id(frmSetupWizardPageResource.
                    frmSetupWizardPageResource_SelectProductButton_Id_Locator));
                //Click on select product button
                base.ClickButtonById(frmSetupWizardPageResource.
                    frmSetupWizardPageResource_SelectProductButton_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("frmSetupWizardPage", "ClickSelectProductButton",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select master library
        /// </summary>
        public void SelectMasterLibrary()
        {
            //Select master library
            logger.LogMethodEntry("frmSetupWizardPage", "SelectMasterLibrary",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Check whether application suggested to use default product
                bool isUseThisProductButtonDisplayed = base.IsElementPresent(By.Id(
                    frmSetupWizardPageResource.frmSetupWizardPageResource_UserThisProduct_Button_Span_Id_Locator), 3);
                if (isUseThisProductButtonDisplayed)
                {
                    base.ClickButtonById(frmSetupWizardPageResource.
                        frmSetupWizardPageResource_UserThisProduct_Button_Span_Id_Locator);
                }
                else
                {
                    base.WaitForElement(By.XPath(frmSetupWizardPageResource.
                    frmSetupWizardPageResource_CourseListTable_Xpath_Locator));
                    //Select master library
                    base.ClickButtonByXPath(frmSetupWizardPageResource.
                        frmSetupWizardPageResource_CourseListTable_Xpath_Locator);
                    this.ClickManageEnrollmentsButton();
                }
                base.SwitchToDefaultPageContent();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("frmSetupWizardPage", "SelectMasterLibrary",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on manage enrollments button
        /// </summary>
        public void ClickManageEnrollmentsButton()
        {
            //Click on manage enrollments button
            logger.LogMethodEntry("frmSetupWizardPage", "ClickManageEnrollmentsButton",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the button
                base.WaitForElement(By.Id(frmSetupWizardPageResource.
                    frmSetupWizardPageResource_ManageEnrollmentsButton_Id_Locator));
                //Click on manage enrollments button
                base.ClickButtonById(frmSetupWizardPageResource.
                    frmSetupWizardPageResource_ManageEnrollmentsButton_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);

            }
            logger.LogMethodExit("frmSetupWizardPage", "ClickManageEnrollmentsButton",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on save class button.
        /// </summary>
        public void ClickOnSaveClass()
        {
            //Save class
            logger.LogMethodEntry("frmSetupWizardPage", "ClickOnSaveClass",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for save class button
                base.WaitForElement(By.Id(
                frmSetupWizardPageResource.frmSetupWizardPageResource_SaveClass_Btn_Id_Locator));
                //Click on save class button
                IWebElement getSaveButtonProperties = base.GetWebElementPropertiesById(frmSetupWizardPageResource.
                    frmSetupWizardPageResource_SaveClass_Btn_Id_Locator);
                base.ClickByJavaScriptExecutor(getSaveButtonProperties);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("frmSetupWizardPage", "ClickOnSaveClass",
               base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Get  page title from setup wizard.
        /// </summary>
        /// <returns>Page title</returns>
        public string GetPageTitleFromSetupWizard(string PageTitle)
        {
            //Get page title
            logger.LogMethodEntry("frmSetupWizardPage", "GetPageTitleFromSetupWizard",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Fetch title based on the page
                switch (PageTitle)
                {
                    case "Select Product":
                        //Wait for page title
                        base.WaitForElement(By.Id(frmSetupWizardPageResource.
                            frmSetupWizardPageResource_SelectProductPageTitle_Id_Locator));
                        //Get page title
                        pageTitleFromSetupWizard = base.GetElementTextById(frmSetupWizardPageResource.
                            frmSetupWizardPageResource_SelectProductPageTitle_Id_Locator);
                        break;

                    case "Manage Enrollments":
                        //Wait for page title
                        base.SwitchToIFrameById(frmSetupWizardPageResource.
                         frmSetupWizardPageResource_SetupWizardParent_Iframe_Id_Locator);
                 
                //Switch to setup wizard inner iframe
                base.SwitchToIFrameById(frmSetupWizardPageResource.
                  frmSetupWizardPageResource_SetupWizard_Iframe_Id_Locator);
                        base.WaitForElement(By.ClassName(frmSetupWizardPageResource.
                            frmSetupWizardPageResource_ManageEnrollmentsPageTitle_ClassName_Locator));
                        //Get page title
                        pageTitleFromSetupWizard = base.GetElementTextByClassName(frmSetupWizardPageResource.
                     frmSetupWizardPageResource_ManageEnrollmentsPageTitle_ClassName_Locator);
                        break;
                }

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("frmSetupWizardPage", "GetPageTitleFromSetupWizard",
               base.IsTakeScreenShotDuringEntryExit);
            return pageTitleFromSetupWizard;
        }


        /// <summary>
        /// Get success message in class creation wizard.
        /// </summary>
        /// <returns>Success message.</returns>
        public string GetClassCreationSuccessMessageInSetupWizard()
        {
            //Get success message
            logger.LogMethodEntry("frmSetupWizardPage", "GetClassCreationSuccessMessageInSetupWizard",
               base.IsTakeScreenShotDuringEntryExit);
            string getSuccessMsg = null;
            try
            {
                //Wait for the message
                base.WaitForElement(By.Id(frmSetupWizardPageResource.
                    frmSetupWizardPageResource_SuccessMessageDiv_Id_Locator));
                //Get success message
                getSuccessMsg = base.GetElementTextById(frmSetupWizardPageResource.
                    frmSetupWizardPageResource_SuccessMessageDiv_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            return getSuccessMsg;
        }

        /// <summary>
        /// Click on save and exit button.
        /// </summary>
        public void ClickOnSaveAndExitButton()
        {
            //Click on save and exit button
            logger.LogMethodEntry("frmSetupWizardPage", "ClickOnSaveAndExitButton",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for save and exit button
                base.WaitForElement(By.Id(frmSetupWizardPageResource.
                    frmSetupWizardPageResource_SaveAndExitButton_Button_Id_Locator));
                //Click on save and exit button
                base.ClickButtonById(frmSetupWizardPageResource.
                    frmSetupWizardPageResource_SaveAndExitButton_Button_Id_Locator);
                base.SwitchToDefaultPageContent();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
        }
        /// <summary>
        /// Click on Add button in curricullum channel
        /// </summary>
        public void ClickOnAddProduct()
        {
            //Click on Add button
            logger.LogMethodEntry("frmSetupWizardPage",
              "ClickOnAddPorudct",
               base.IsTakeScreenShotDuringEntryExit);
            //Get the webelement property of Add button
            IWebElement Addbutton = base.GetWebElementPropertiesById("btnAddProduct");
            //Click on Add button
            base.ClickByJavaScriptExecutor(Addbutton);
            logger.LogMethodEntry("frmSetupWizardPage",
             "ClickOnAddPorudct",
              base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Select the Product to add in channel
        /// </summary>
        /// <param name="prodName"></param>
        public void SelectProduct(string prodName)
        {
            //Method to Select the Product in Setupwizard Ligthbox
            logger.LogMethodEntry("frmSetupWizardPage",
             "SelectProduct",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //wait for window
                base.WaitUntilWindowLoads("Home");
                //Switch to Default Page content of Home Page
                base.SwitchToDefaultPageContent();
                //Wait for Ifrmae ID
                base.WaitForElement(By.Id("lightboxid"));
                //Swithc to Setup Wizard Iframe
                base.SwitchToIFrameById("lightboxid");
                //Wait for Iframe 
                base.WaitForElement(By.Id("iframeSetUpWizard"));
                //Switch to iframe
                base.SwitchToIFrameById("iframeSetUpWizard");
                // Get the total number of Products
                int getproductcount = base.GetElementCountByXPath
                    (frmSetupWizardPageResource.frmSetupWizardPageResource_AddProduct_TableXPath_Locator);
                //Identify valid product
                for (int initialcount = Convert.ToInt32(frmSetupWizardPageResource.
                    frmSetupWizardPageResource_AddProduct_InitalCount);
                    initialcount <= getproductcount; initialcount++)
                {
                    //Identify valid product
                    base.WaitForElement(By.XPath(string.Format(frmSetupWizardPageResource.
                        frmSetupWizardPageResource_AddProduct_ProductName_Locator, initialcount)));
                    String ProductNameText = base.GetElementTextByXPath(string.Format(frmSetupWizardPageResource.
                        frmSetupWizardPageResource_AddProduct_ProductName_Locator, initialcount));
                    if (ProductNameText.Equals(prodName))
                    {
                        //Click on Checkbox
                        IWebElement getProductCheckbox = base.GetWebElementPropertiesByXPath(String.
                            Format(frmSetupWizardPageResource.
                            frmSetupWizardPageResource_AddProduct_Checkbox_Locator, initialcount));
                        base.ClickByJavaScriptExecutor(getProductCheckbox);
                        break;
                    }

                }

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodEntry("frmSetupWizardPage", "SelectProduct",
          base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click on Save button
        /// </summary>
        public void ClickOnSave()
        {
            //Method to click on save button
            logger.LogMethodEntry("frmSetupWizardPage", "ClickOnSave",
            base.IsTakeScreenShotDuringEntryExit);
            //wait for element
            base.WaitForElement(By.Id(frmSetupWizardPageResource.frmSetupWizardPageResource_AddProduct_Window_Save));
            //Click on save button
            base.ClickButtonById(frmSetupWizardPageResource.frmSetupWizardPageResource_AddProduct_Window_Save);
            logger.LogMethodEntry("frmSetupWizardPage", "ClickOnSave",
         base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click on 'No, Save and Exit' button
        /// </summary>
        public void ClickonSaveandExit()
        {
            //Method to click on 'No, Save and Exit' button
            logger.LogMethodEntry("frmSetupWizardPage", "ClickonSaveandExit",
            base.IsTakeScreenShotDuringEntryExit);
            //Wait for element
            base.WaitForElement(By.Id(frmSetupWizardPageResource.
                frmSetupWizardPageResource_Add_Product_SaveAndExit_button));
            //Click on 'No, Save and Exit' button
            base.ClickButtonById(frmSetupWizardPageResource.
                frmSetupWizardPageResource_Add_Product_SaveAndExit_button);
            logger.LogMethodEntry("frmSetupWizardPage", "ClickonSaveandExit",
         base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Validate Successful message
        /// </summary>
        /// <returns></returns>
        public string GetAddProductSuccessMessageInSetupWizard()
        {
            //Declare successful message as Null initially.
            string getSuccessMsg = null;
            try
            {
                //Wait for the message
                Thread.Sleep(5000);
                base.WaitForElement(By.Id(frmSetupWizardPageResource.
                    frmSetupWizardPageResource_SuccessMessageDiv_Id_Locator));
                //Get success message
                getSuccessMsg = base.GetElementTextById(frmSetupWizardPageResource.
                    frmSetupWizardPageResource_SuccessMessageDiv_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            return getSuccessMsg;
        }
        /// <summary>
        /// Verify the added Product in Curricullum Channel
        /// </summary>
        /// <param name="prodName"></param>
        /// <returns></returns>
        public string VerifyProductName(string prodName)
        {
            //Get success message
            logger.LogMethodEntry("frmSetupWizardPage", "VerifyProductName",
            base.IsTakeScreenShotDuringEntryExit);
            //Delecare object to hold retrun value
            string ProductName = null;
            //Delecare object to compare with return value
            string ProductNameText = null;
            try
            {
                //Switch to Main widow, Home Page
                base.SwitchToDefaultWindow();
                //Focus on Main window
                base.SelectDefaultWindow();
                //Get the total number of products in curriculum channel
                int getproductcount = base.GetElementCountByXPath(frmSetupWizardPageResource.
                    frmSetupWizardPageResource_Verify_Product_InitialCount_Locator);
                //Locate the desired Product in curriculumn channel
                for (int initialcount = Convert.ToInt32(2);
                    initialcount <= getproductcount; initialcount++)
                {
                    //Get the Product Name from object repository 
                    ProductNameText = base.GetElementTextByXPath(string.Format(frmSetupWizardPageResource.
                        frmSetupWizardPageResource_Verify_Product_Span_Id_Locator, initialcount));
                    //Compare Product name
                    if (ProductNameText.Equals(prodName))
                    {
                        ProductName = ProductNameText;
                        break;
                    }
                }
                base.SwitchToDefaultWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            return ProductName;
        }

        /// <summary>
        /// Remove product from curriculum
        /// </summary>
        /// <param name="prodName">This is the Product name.</param>
        public void RemoveProductFromCurriculum(string cmenuOption, string productName)
        {
            //Remove product from curriculum
            logger.LogMethodEntry("frmSetupWizardPage", "RemoveProductFromCurriculum",
            base.IsTakeScreenShotDuringEntryExit);
            //Delecare object to compare with return value
            string ProductNameText = null;
            try
            {
                //Switch to Main widow, Home Page
                base.SwitchToDefaultWindow();
                //Focus on Main window
                base.SelectDefaultWindow();
                //Get the total number of products in curriculum channel
                int getproductcount = base.GetElementCountByXPath(frmSetupWizardPageResource.
                    frmSetupWizardPageResource_Verify_Product_InitialCount_Locator);
                //Locate the desired Product in curriculumn channel
                for (int initialcount = Convert.ToInt32(2);
                    initialcount <= getproductcount; initialcount++)
                {
                    //Get the Product Name from object repository 
                    ProductNameText = base.GetElementTextByXPath(string.Format(frmSetupWizardPageResource.
                        frmSetupWizardPageResource_Verify_Product_Span_Id_Locator, initialcount));
                    //Compare Product name
                    if (ProductNameText.Equals(productName))
                    {
                        IWebElement getCmenuIcon = base.GetWebElementPropertiesByXPath(string.Format(frmSetupWizardPageResource.
                            frmSetupWizardPageResource_Cmenu_Product_Xpath_Locator, initialcount));
                        base.PerformClickAndHoldAction(getCmenuIcon);
                        base.ClickByJavaScriptExecutor(getCmenuIcon);
                        IWebElement getCmenuOption = base.GetWebElementPropertiesByXPath(string.Format(frmSetupWizardPageResource.
                            frmSetupWizardPageResource_GetCmenuOptions_Xpath_Locator, initialcount));
                        base.ClickByJavaScriptExecutor(getCmenuOption);

                        // Select popup window
                        base.SwitchToActivePageElement();
                        base.WaitUntilPopUpLoads(frmSetupWizardPageResource.
                            frmSetupWizardPageResource_RemoveProduct_ConfirmationPopup_Title);
                        base.ClickButtonByPartialLinkText(frmSetupWizardPageResource.
                            frmSetupWizardPageResource_RemoveProduct_ConfirmationPopup_OkButton_Id);
                        break;
                    }
                }
                base.SwitchToDefaultWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
        }
    }
}



