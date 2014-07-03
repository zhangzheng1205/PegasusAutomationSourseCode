using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
using Framework.Common;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.SMSIntegration.ProgramManagement
{
    public class NewProductPage : BasePage
    {
        //Pupose: Run code on the basis of Browser Selected
        private static readonly string Browser = ConfigurationManager.AppSettings["browser"];

        //Pupose: To Create Product NovaNet
        public void CreateProduct()
        {
            try
            {
                string productName = GenericHelper.GenerateUniqueVariable("BDD_Prod");
                string programName = DatabaseTools.GetProgram(Enumerations.ProgramInstance.NovaNET);
                GenericHelper.SelectWindow("Create New Product");
                GenericHelper.WaitUntilElement(By.Id("txtProductName"));
                WebDriver.FindElement(By.Id("txtProductName")).SendKeys(productName);
                WebDriver.FindElement(By.Id("ancRightSearch")).Click();
                GenericHelper.WaitUntilElement(By.Id("ifrmSearchProgram"));
                WebDriver.SwitchTo().Frame("ifrmSearchProgram");
                GenericHelper.WaitUntilElement(By.Id("txtProgramName"));
                WebDriver.FindElement(By.Id("txtProgramName")).SendKeys(programName);
                WebDriver.FindElement(By.Id("btnSearch")).Click();
                GenericHelper.WaitUntilElement(By.Id("grdPegasusDataGrid"));

                #region Browser Selection

                if (Browser.Equals("FF"))
                {
                    if (WebDriver.FindElement(By.Id("grdPegasusDataGrid")).Text.Contains(programName))
                    {
                        GenericHelper.Logs("Searched Program Found in 'Create New Product' page.", "PASSED");
                    }
                    else
                    {
                        GenericHelper.Logs("Searched Program not Found in 'Create New Product' page.", "FAILED");
                        throw new Exception("Searched Program not Found in 'Create New Product' page.");
                    }
                }
                if (Browser.Equals("IE"))
                {
                    if (
                        (WebDriver.FindElement(By.Id("grdPegasusDataGrid")).GetAttribute("innerText")).Contains(
                            programName))
                    {
                        GenericHelper.Logs("Searched Program Found in 'Create New Product' page.", "PASSED");
                    }
                    else
                    {
                        GenericHelper.Logs("Searched Program not Found in 'Create New Product' page.", "FAILED");
                        throw new Exception("Searched Program not Found in 'Create New Product' page.");
                    }
                }

                #endregion Browser Selection

                WebDriver.FindElement(By.Id("grdPegasusDataGrid$_ctrl1")).Click();
                GenericHelper.SelectWindow("Create New Product");
                GenericHelper.WaitUntilElement(By.Id("drpProductType"));
                Actions builder = new Actions(WebDriver);
                IWebElement novenetDropDown = WebDriver.FindElement(By.Id("drpProductType"));
                builder.MoveToElement(novenetDropDown).Build().Perform();
                if (Browser.Equals("IE"))
                {
                    WebDriver.FindElement(By.Id("drpProductType")).SendKeys("NovaNet");
                }
                if (Browser.Equals("FF") || Browser.Equals("GC"))
                {
                    WebDriver.FindElement(By.Id("drpProductType")).FindElement(By.CssSelector("option[value='1']")).
                        Click();
                }
                IWebElement saveButton = WebDriver.FindElement(By.Id("imgbtnSave"));
                builder.MoveToElement(saveButton).Build().Perform();
                GenericHelper.WaitUntilElement(By.Id("imgbtnSave"));
                WebDriver.FindElement(By.Id("imgbtnSave")).Click();
                bool isCreateNewProductPopUpClosed = GenericHelper.IsPopUpClosed(2);
                if (isCreateNewProductPopUpClosed)
                {
                    GenericHelper.Logs("'Create New Product' pop up window closed successfully after creation of product.", "PASSED");
                    DatabaseTools.UpdateProduct(productName, programName, Enumerations.ProductInstance.NovaNET);
                }
                else
                {
                    GenericHelper.Logs("'Create New Product' pop up window not closed successfully after creation of product.", "FAILED");
                    throw new Exception("'Create New Product' pop up window not closed successfully after creation of product.");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                if (GenericHelper.IsPopUpWindowPresent("Create New Product"))
                {
                    GenericHelper.SelectWindow("Create New Product");
                    WebDriver.Close();
                }
                throw new Exception(e.ToString());
            }
        }

        public void CreateHedProduct(Enumerations.ProductInstance productType)
        {
            try
            {
                string productName = GenericHelper.GenerateUniqueVariable("BDD_Prod");
                string programName = DatabaseTools.GetProgram(Enumerations.ProgramInstance.HedCore);
                GenericHelper.SelectWindow("Create New Product");
                GenericHelper.WaitUntilElement(By.Id("txtProgramName"));
                WebDriver.FindElement(By.Id("txtProgramName")).SendKeys(productName);
                WebDriver.FindElement(By.Id("ancRightSearch")).Click();
                GenericHelper.WaitUntilElement(By.Id("ifrmSearchProgram"));
                WebDriver.SwitchTo().Frame("ifrmSearchProgram");
                GenericHelper.WaitUntilElement(By.Id("txtProgramName"));
                WebDriver.FindElement(By.Id("txtProgramName")).SendKeys(programName);
                WebDriver.FindElement(By.Id("btnSearch")).Click();
                GenericHelper.WaitUntilElement(By.Id("grdPegasusDataGrid"));
                #region Browser Selection

                if (Browser.Equals("FF"))
                {
                    if (WebDriver.FindElement(By.Id("grdPegasusDataGrid")).Text.Contains(programName))
                    {
                        GenericHelper.Logs("Searched Program Found in 'Create New Product' page.", "PASSED");
                    }
                    else
                    {
                        GenericHelper.Logs("Searched Program not Found in 'Create New Product' page.", "FAILED");
                        Assert.Fail("Searched Program not Found in 'Create New Product' page.");
                    }
                }
                if (Browser.Equals("IE"))
                {
                    if (
                        (WebDriver.FindElement(By.Id("grdPegasusDataGrid")).GetAttribute("innerText")).Contains(
                            programName))
                    {
                        GenericHelper.Logs("Searched Program Found in 'Create New Product' page.", "PASSED");
                    }
                    else
                    {
                        GenericHelper.Logs("Searched Program not Found in 'Create New Product' page.", "FAILED");
                        Assert.Fail("Searched Program not Found in 'Create New Product' page.");
                    }
                }

                #endregion Browser Selection
                GenericHelper.WaitUntilElement(By.Id("grdPegasusDataGrid$_ctrl1"));
                if (!WebDriver.FindElement(By.Id("grdPegasusDataGrid$_ctrl1")).Selected)
                {
                    WebDriver.FindElement(By.Id("grdPegasusDataGrid$_ctrl1")).Click();
                }
                WebDriver.SwitchTo().DefaultContent();
                GenericHelper.WaitUntilElement(By.Id("txtSMSID"));
                WebDriver.FindElement(By.Id("txtSMSID")).SendKeys("2731");
                if (productType.Equals(Enumerations.ProductInstance.HedCoreProgram))
                {
                    GenericHelper.WaitUntilElement(By.Id("chkIsProgram"));
                    WebDriver.FindElement(By.Id("chkIsProgram")).Click();
                    GenericHelper.WaitUntilElement(By.Id("drpDiscipline"));
                    WebDriver.FindElement(By.Id("drpDiscipline")).SendKeys("");
                    new SelectElement(WebDriver.FindElement(By.Id("drpDiscipline"))).SelectByText("Art");
                    GenericHelper.WaitUntilElement(By.Id("imgbtnSave"));
                    WebDriver.FindElement(By.Id("imgbtnSave")).Click();
                    bool isCreateNewProductPopUpClosed = GenericHelper.IsPopUpClosed(2);
                    if (isCreateNewProductPopUpClosed)
                    {
                        GenericHelper.Logs("'Create New Product' pop up window closed successfully after creation of product.", "PASSED");
                        DatabaseTools.UpdateProduct(productName, programName, Enumerations.ProductInstance.HedCoreProgram);
                    }
                    else
                    {
                        GenericHelper.Logs("'Create New Product' pop up window not closed successfully after creation of product.", "FAILED");
                        Assert.Fail("'Create New Product' pop up window not closed successfully after creation of product.");
                    }
                }
                else
                {
                    GenericHelper.WaitUntilElement(By.Id("imgbtnSave"));
                    WebDriver.FindElement(By.Id("imgbtnSave")).Click();
                    bool isCreateNewProductPopUpClosed = GenericHelper.IsPopUpClosed(2);
                    if (isCreateNewProductPopUpClosed)
                    {
                        GenericHelper.Logs("'Create New Product' pop up window closed successfully after creation of product.", "PASSED");
                        DatabaseTools.UpdateProduct(productName, programName, Enumerations.ProductInstance.HedCoreGeneral);
                    }
                    else
                    {
                        GenericHelper.Logs("'Create New Product' pop up window not closed successfully after creation of product.", "FAILED");
                        Assert.Fail("'Create New Product' pop up window not closed successfully after creation of product.");
                    }
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                if (GenericHelper.IsPopUpWindowPresent("Create New Product"))
                {
                    GenericHelper.SelectWindow("Create New Product");
                    WebDriver.Close();
                }
                Assert.Fail(string.Format("Exception of type {0} caught: {1}", e.GetType(), e.Message));
            }
        }
    }
}
