using System.Configuration;
using System.Threading;
using OpenQA.Selenium;
using Pegasus_DataAccess;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
using Framework.Common;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.SMSIntegration.ProgramManagement
{
    public class ProductSearchPage : BasePage
    {
        IWebElement _iElement;
        //Pupose: Run code on the basis of Browser Selected
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];

        //Purpose : To Search and Open the Product
        public void SearchProductAndOpen(string productInstance)
        {
            GenericHelper.SelectWindow("Manage Products");
            GenericHelper.WaitUntilElement(By.Id("ifrmWorkspace"));
            WebDriver.SwitchTo().Frame("ifrmWorkspace");
            GenericHelper.WaitUntilElement(By.Id("ancRightSearch"));
            WebDriver.FindElement(By.Id("ancRightSearch")).Click();
            Thread.Sleep(3000);
            WebDriver.SwitchTo().ActiveElement();
            GenericHelper.WaitUntilElement(By.Id("ifrmRight"));
            WebDriver.SwitchTo().Frame("ifrmRight");
            //Purpose: Get Course From DB Based on Instance
            string productName = string.Empty;
            switch (productInstance)
            {
                case "NovaNET":
                     productName = DatabaseTools.GetProduct(Enumerations.ProductInstance.NovaNET);
                    break;
                case "DigitalPath":
                     productName = DatabaseTools.GetProduct(Enumerations.ProductInstance.DigitalPath);
                    break;
                case "HedCoreGeneral":
                    productName = DatabaseTools.GetProduct(Enumerations.ProductInstance.HedCoreGeneral);
                    break;
                case "HedCoreProgram":
                    productName = DatabaseTools.GetProduct(Enumerations.ProductInstance.HedCoreProgram);
                    break;
                case "HedMilGeneral":
                     productName = DatabaseTools.GetProduct(Enumerations.ProductInstance.HedMilGeneral);
                    break;
                case "HedMilProgram":
                     productName = DatabaseTools.GetProduct(Enumerations.ProductInstance.HedMilProgram);
                    break;
            }
            GenericHelper.WaitUntilElement(By.Id(("txtProgramName")));
            WebDriver.FindElement(By.Id("txtProgramName")).SendKeys(productName);
           // GenericHelper.WaitUntilElement(By.Id("cmbState"));
           // _iElement = WebDriver.FindElement(By.Id("cmbState"));
            GenericHelper.WaitUntilElement(By.Id("imgBtnSearch"));
            IWebElement imgBtnSearch = WebDriver.FindElement(By.Id("imgBtnSearch"));
            imgBtnSearch.Click();
            bool isManageProgramsGridOpened = GenericHelper.IsElementPresent(By.Id("grdManagePrograms"));
            if (!isManageProgramsGridOpened)
            {
                imgBtnSearch.Click();
            }
            #region Browser Selection
            if (Browser.Equals("FF"))
            {
                if (WebDriver.FindElement(By.Id("grdManagePrograms")).Text.Contains(productName))
                {
                    GenericHelper.Logs("searched product found in 'Manage Product' page", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("searched product not found in 'Manage Product' page", "FAILED");
                }
            }
            if (Browser.Equals("IE"))
            {
                if (WebDriver.FindElement(By.Id("grdManagePrograms")).GetAttribute("innerText").Contains(productName))
                {
                    GenericHelper.Logs("searched product found in 'Manage Product' page", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("searched product not found in 'Manage Product' page", "FAILED");
                }
            }
            #endregion Browser Selection
            GenericHelper.WaitUntilElement(By.PartialLinkText(productName));
            WebDriver.FindElement(By.PartialLinkText(productName)).Click();
            WebDriver.SwitchTo().DefaultContent();
        }
    }
}
