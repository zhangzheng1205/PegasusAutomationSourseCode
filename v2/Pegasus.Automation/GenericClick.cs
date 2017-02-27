
using System.Linq;
using OpenQA.Selenium.Interactions;
using Keys = OpenQA.Selenium.Keys;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;


namespace Pearson.Pegasus.TestAutomation.Frameworks
{
    public enum ClickAction
    {
        Click,
        Submit,
        DoubleClick,
        LeftMBClick,
        RightMBClick,
        JSClick,
        CursorClick,
        SendKeyEnter,
        SendKeyReturn,
        SendKeySpacebar
    }

    public static class Extensions
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, uint cButtons, uint dwExtraInfo);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern long SetCursorPos(int X, int Y);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;

        static string PageHashCode(IWebDriver driver)
        {
            MD5 md5 = MD5.Create();
            byte[] bytesArray = Encoding.ASCII.GetBytes(driver.PageSource);
            byte[] hashCode = md5.ComputeHash(bytesArray);
            var sb = new StringBuilder();
            foreach (byte t in hashCode)
                sb.Append(t.ToString("X2"));
            return sb.ToString();
        }

        public delegate bool CustomFunction(params object[] obj);

        public static void SmartClick(this IWebElement element, IWebDriver driver = null, CustomFunction precondition = null,
        CustomFunction postcondition = null, int iterations = 1, int delay = 1, params ClickAction[] clicks)
        {
            int i = iterations;

            //if you do not specify what actions to use for clicking the following default actions will be used
            ClickAction[] clickActions = clicks != null ? clicks : new ClickAction[] { ClickAction.Click, ClickAction.LeftMBClick, ClickAction.JSClick };

            string elementName = element.Text;

            if (precondition == null)
                precondition = x => true; //if you did not specify the method let's assume it has passed (return true)

            if (postcondition == null)
            {
                if (driver == null)
                {
                    //"SmartClick: IWebDriver is null, no postcondition verification provided" message to log file
                    postcondition = x => true; //assume if you do not pass IWebDriver to the mathod you do not need any post-click conditions verification. Therefore, this method always returns true
                }
                else
                {
                    //"SmartClick: No click verification conditions are specified. Default verification wil be used." message to log file
                    var numOfWindows = driver.WindowHandles.Count;
                    var pageHashCode = PageHashCode(driver);
                    var pageTitle = driver.Title;
                    var pageUrl = driver.Url;
                    //the method returns true if any of the following conditions are met, otherwise it returns false
                    postcondition = delegate
                    {
                        //page title is changed
                        if (pageTitle != driver.Title)
                        {
                            //log message "SmartClick: Click validation - Title of the page has changed"
                            //screenshot
                            return true;
                        }
                        //page url address is changed
                        if (pageUrl != driver.Url)
                        {
                            //log message "SmartClick: Click validation - Url address of the page has changed"
                            //screenshot
                            return true;
                        }
                        //alert pop-up is displayed
                        try
                        {
                            driver.SwitchTo().Alert();
                            //log message "SmartClick: "Element_ClickWhile: Click validation - Alert pop-up is displayed"
                            //screenshot
                            return true;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        //number of opened windows or tabs is changed
                        if (numOfWindows != driver.WindowHandles.Count)
                        {
                            //log message "SmartClick: "Element_ClickWhile: Click validation - Number of opened windows (tabs) has changed"
                            //screenshot
                            return true;
                        }
                        //page hash code is changed. It indicates that some changes has occurred on the page
                        if (pageHashCode != PageHashCode(driver))
                        {
                            //log message "SmartClick: "Element_ClickWhile: Click validation - Hash code of the page has changed"
                            //screenshot
                            return true;
                        }
                        return false;
                    };
                }
            }

            while (i > 0)
            {
                i--;
                if (!precondition.Invoke())
                {
                    //add string.Format("Preconditions for clicking '{0}' web element are not met", elementName) error message into your log file
                    //screenshot
                    continue; //there is no sense to do clicking action if precondition method has failed. Return back to the beginning of the loop and start again from the very beginning
                }
                if (element == null)
                {
                    //add 'Element is null' error message into your log file or throw NoSuchElement or NullReference exception   
                }
                if (!element.Displayed)
                {
                    //add 'Element is not displayed and cannot be clicked' error message into your log file   
                    //you may add a screenshot here  
                }
                if (!element.Enabled)
                {
                    //add 'Element is not displayed and cannot be clicked' error message into your log file  
                    //plus a screenshot  
                }
                foreach (var action in clickActions)
                {
                    //here you may add string.Format("Clicking '{0}' web element with {1} click action", elementName, action) message into your log file
                    switch (action)
                    {
                        case ClickAction.Click:
                            try
                            {
                                element.Click();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case ClickAction.Submit:
                            try
                            {
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case ClickAction.DoubleClick:
                            try
                            {
                                var builder = new Actions(driver);
                                builder.DoubleClick().Build().Perform();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;

                        case ClickAction.RightMBClick:
                            if (driver == null)
                            {
                                //"SmartClick clicking error: IWebDriver instance must be passed as a parameter and connot be null if you use clicking with right mouse button action" error message
                                break;
                            }
                            try
                            {
                                var builder = new Actions(driver);
                                builder.MoveToElement(element).ContextClick(element).Build().Perform();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case ClickAction.JSClick:
                            if (driver == null)
                            {
                                //"SmartClick clicking error: IWebDriver instance must be passed as a parameter and connot be null if you use clicking with JavaScript action" error message
                                break;
                            }
                            try
                            {
                                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case ClickAction.CursorClick:
                            try
                            {
                                var X = element.Location.X;
                                var Y = element.Location.Y;
                                SetCursorPos(X, Y);
                                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case ClickAction.SendKeyEnter:
                            try
                            {
                                element.SendKeys(Keys.Enter);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case ClickAction.SendKeyReturn:
                            try
                            {
                                element.SendKeys(Keys.Return);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case ClickAction.SendKeySpacebar:
                            try
                            {
                                element.SendKeys(Keys.Space);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                    }
                    Thread.Sleep(delay * 1000);
                    if (postcondition())
                        return;
                    //add string.Format("Post-conditions for clicking '{0}' web element are not met", elementName) error message into your log file
                    //screenshot
                }
            }
        }


    }
}
