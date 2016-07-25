using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Pearson.Pegasus.TestAutomation.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Chrome;

namespace Pegasus.Automation
{
   public class CertChecker : BasePage
     {
       //private DesiredCapabilities configDriver = new DesiredCapabilities();

       //private IWebDriver driver;

      
       
        //private static Logger CertLogger = Logger.GetInstance(typeof(CertChecker));

        private string sslTestUrl = "https://www.ssllabs.com/ssltest/";
        private By SSLPage = By.CssSelector("#main>h1");
        private By inputURL = By.CssSelector("td>input[type='text']");
        private By submitURL = By.CssSelector("td>input[type='submit']");
        private By pageLoaderIndicator = By.CssSelector("#warningBox>img");
        private By scannedDns = By.CssSelector(".url");
        private By certRate = By.CssSelector(".rating_g");
        private By scanAnother = By.CssSelector("#main>div>a");

        
        private string certRating = null;
        private IWebElement variableElement = null;
        private IWebElement scanNext = null;


        public bool fireUPSSLServerTest()
        {

            base.NavigateToBrowseUrl(sslTestUrl);
           
            bool siteReadyToScan = base.IsElementPresent(SSLPage);

            return siteReadyToScan;
        }
      
                 
       
        public string scanDns(string dnsToScan)
        {

            base.WaitForElementDisplayedInUi(inputURL);

            variableElement = base.GetWebElementProperties(inputURL);
            variableElement.Clear();
            variableElement.SendKeys(dnsToScan);

            base.WaitForElementDisplayedInUi(submitURL);
            variableElement = base.GetWebElementProperties(submitURL);
            variableElement.Click();


            //if (base.IsElementDisplayedInPage(pageLoaderIndicator, false))
                //base.WaitForAjaxToComplete();

            base.WaitForElementDisplayedInUi(scannedDns);
            Console.WriteLine(scannedDns);

            base.WaitForElementDisplayedInUi(certRate);

            variableElement = base.GetWebElementProperties(certRate);

            certRating = variableElement.Text;

            base.WaitForElementDisplayedInUi(scanAnother);

            base.ClickLinkByLinkText("Scan Another");

            
            return certRating;
        }

      /*public CertChecker()
      {
          Console.WriteLine("Starting CERT Tests");
      }*/
       



    }
}
