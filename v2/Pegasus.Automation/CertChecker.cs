using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pegasus.Automation
{
   public class CertChecker : BasePage
    {
       private IWebDriver driver;
      
       private static Logger CertLogger = Logger.GetInstance(typeof(CertChecker));

       private By SSLPage = By.CssSelector("#main>h1");
       private By inputURL = By.CssSelector("td>input[type='text']");
       private By submitURL = By.CssSelector("td>input[type='submit']");
       private By pageLoaderIndicator = By.Id("");
              
       
       
       
       private CertChecker(IWebDriver driver)
       {
           this.driver = driver;
       }




    }
}
