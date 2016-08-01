﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pegasus.Pages.Exceptions;
using Pegasus.Automation;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;


namespace Pegasus.Pages.UI_Pages.Integration.MMND
{
    [Binding]
   public class MMNDLoginPage : BasePage
   
    {
       //private static Logger MMNDLoginlogger = Logger.GetInstance(typeof(MMNDLoginPage));

       //Locators

      private By userName = By.Id("username");
      private By passWord = By.Id("password");
      private By signIn = By.Name("Sign In");

     

/// <summary>
/// Accepts usertype, scans username and password stored in respective environment xml
/// and uses to sign In
/// </summary>
/// <param name="user">the user enum</param>

     public void MMNDLogin(User.UserTypeEnum user)
     {
        IWebElement keyIn = null;
        User mmndUser = User.Get(user);


        try
        {
            base.IsElementPresent(userName, 10);
            keyIn = base.GetWebElementProperties(userName);
            keyIn.SendKeys(mmndUser.FirstName);

            base.IsElementPresent(passWord, 10);
            keyIn = base.GetWebElementProperties(passWord);
            keyIn.SendKeys(mmndUser.Password);

            base.IsElementPresent(signIn, 10);
            keyIn = base.GetWebElementProperties(signIn);
            base.ClickByJavaScriptExecutor(keyIn);

        }
        
         
        catch (Exception e)
        {
            throw e;
        }
         

     }


    }
}
