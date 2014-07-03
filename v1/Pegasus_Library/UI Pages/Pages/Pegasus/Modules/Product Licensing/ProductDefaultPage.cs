using System;
using System.Data;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using Pegasus_DataAccess;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
using Framework.Common;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Course_Preference
{
    public class ProductDefaultPage : BasePage
    {
        //Purpose: Method to Select Product For License Creation
        public void SelectProduct(Enumerations.ProductInstance productInstance)
        {
            try
            {
                bool isProductSelectionWindowAppeared = GenericHelper.WaitUtilWindow("Product Selection");
                if (isProductSelectionWindowAppeared)
                {
                    GenericHelper.SelectWindow("Product Selection");
                    GenericHelper.WaitUntilElement(By.Id("ifrmAvailableProd"));
                    WebDriver.SwitchTo().Frame("ifrmAvailableProd");
                    GenericHelper.WaitUntilElement(By.XPath("//label[@class='cssLicenseSearchLbl']"));
                    WebDriver.FindElement(By.XPath("//label[@class='cssLicenseSearchLbl']")).Click();
                    bool isProductTextBoxDisplayed = WebDriver.FindElement(By.Id("txtProduct")).Displayed;
                    if (!isProductTextBoxDisplayed)
                    {
                        GenericHelper.WaitUntilElement(By.XPath("//label[@class='cssLicenseSearchLbl']"));
                        WebDriver.FindElement(By.XPath("//label[@class='cssLicenseSearchLbl']")).Click();
                    }
                    string productName = DatabaseTools.GetProduct(productInstance);
                    if (productName == null) throw new ArgumentNullException(string.Format("Product Name is {0}, dataconfiguration issue.", "productName"));
                    GenericHelper.WaitUntilElement(By.Id("txtProduct"));
                    WebDriver.FindElement(By.Id("txtProduct")).SendKeys(productName);
                    GenericHelper.WaitUntilElement(By.Id("Search1"));
                    WebDriver.FindElement(By.Id("Search1")).Click();
                    bool isProductDisplayed = GenericHelper.IsElementPresent(By.PartialLinkText("Select"));
                    if (isProductDisplayed)
                    {
                        GenericHelper.WaitUntilElement(By.PartialLinkText("Select"));
                        GenericHelper.Logs("Product has been found successfully while creating the license.", "PASSED");
                    }
                    else
                    {
                        GenericHelper.Logs("Product has been not found while creating the license.", "FAILED");
                        throw new NoSuchElementException("Product has been not found while creating the license.");
                    }
                    WebDriver.FindElement(By.PartialLinkText("Select")).Click();
                    WebDriver.SwitchTo().DefaultContent();
                    WebDriver.WindowHandles.Any(item => WebDriver.SwitchTo().Window(item).Title == "Product Selection");
                    GenericHelper.WaitUntilElement(By.Id("ImgContinue"));
                    WebDriver.FindElement(By.Id("ImgContinue")).Click();
                    Thread.Sleep(15000);
                    WebDriver.WindowHandles.Any(item => WebDriver.SwitchTo().Window(item).Title == "Create License");

                    new CreateLicensePage().EnterLicenseDetail();

                    WebDriver.Close();
                    GenericHelper.SelectWindow("Organization Management");
                }
                else
                {
                    GenericHelper.Logs("Product selection pop-up not opened for selecting product for licensing.", "FAILED");
                    throw new NoSuchWindowException("Product Selection pop-up not opened for selecting product for licensing.");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                bool isWindowPresentProductSelection = GenericHelper.IsPopUpWindowPresent("Product Selection");
                if (isWindowPresentProductSelection)
                {
                    GenericHelper.SelectWindow("Product Selection");
                    WebDriver.Close();
                }
                throw new Exception(e.ToString());
            }
        }
    }
}
