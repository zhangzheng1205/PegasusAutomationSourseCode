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
       
        private string sslTestUrl = "https://www.ssllabs.com/ssltest/";
        private By SSLPage = By.CssSelector("#main>h1");
        private By inputURL = By.CssSelector("td>input[type='text']");
        private By submitURL = By.CssSelector("td>input[type='submit']");
        private By pageLoaderIndicator = By.CssSelector("#warningBox>img");
        private By scannedDns = By.CssSelector(".url");
        private By certRate = By.CssSelector(".rating_g");
        private By scanAnother = By.CssSelector("#main>div>a");
        private By scanAnotherDns= By.LinkText("Scan Another »");
        

        
        private string certRating = null;
        private IWebElement variableElement = null;
        //private IWebElement scanNext = null;
        private bool siteReadyToScan = false;


       /// <summary>
        /// Prepares www.ssllabs.com for scanning
       /// </summary>
       /// <returns>True if successfull</returns>
        public bool fireUPSSLServerTest()
        {

            try
            {
                base.NavigateToBrowseUrl(sslTestUrl);

                siteReadyToScan = base.IsElementPresent(SSLPage);
            }

            catch (Exception e)
            {
                throw e;
            }

            return siteReadyToScan;
        }
      
                 
       /// <summary>
       /// Scans input DNS and returns the Certificate Rating
       /// </summary>
       /// <param name="dnsToScan">Input DNS</param>
       /// <returns>DNS Certificate Rating</returns>
        public string scanDns(string dnsToScan)
        {

            try
            {
                base.WaitForElementDisplayedInUi(inputURL);
                variableElement = base.GetWebElementProperties(inputURL);
                variableElement.Clear();
                variableElement.SendKeys(dnsToScan);

                base.WaitForElementDisplayedInUi(submitURL);
                variableElement = base.GetWebElementProperties(submitURL);
                variableElement.Click();



                base.WaitForElementDisplayedInUi(scannedDns);

                base.WaitTillElementFound(certRate);
                variableElement = base.GetWebElementProperties(certRate);
                certRating = variableElement.Text;

                base.WaitForElementDisplayedInUi(scanAnother, 5);
                variableElement = base.GetWebElementProperties(scanAnotherDns);
                variableElement.Click();
            }

            catch (Exception e)
            {
                throw e;
            }
           
            
            return certRating;
        }



    }
}
