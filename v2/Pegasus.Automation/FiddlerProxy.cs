using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiddler;
using OpenQA.Selenium;

// This class defines basic operation on fiddler core. Fiddler Proxy is used to intercept web sessions.
// To test complex file download status or server response which do not include GUI, this class can be scaled and used.

//http://www.telerik.com/fiddler/fiddlercore - link to download required dlls for the fiddler API

//The webdrivers have to be "synchronized" or hooked up with Proxy. Please visit Webdriverfactory for setup information.


namespace Pegasus.Automation
{
    public class FiddlerProxy
    {
        static int proxyPort = 0;

        //Starting fiddler, Called by Webdriver during initialization, accepts any valid ports and returns 
        //the port fiddler runs on.
        //The same port has to be passed for webdriver to use, so that fiddler can start sniffing the traffic.

        public static int StartFiddlerProxy(int desiredPort)
        {
            
            //Setting up flags for fiddler
            
            FiddlerCoreStartupFlags flags = FiddlerCoreStartupFlags.Default &
                                            ~FiddlerCoreStartupFlags.RegisterAsSystemProxy;

            //If the desiredPort is 0, fiddler will randomly choose any of the port and register it.

            FiddlerApplication.Startup(desiredPort, flags);

            //pick the proxyport used by fiddler
            proxyPort = FiddlerApplication.oProxy.ListenPort;

            // a simple debugger to see if the Fiddlerapplication is actually started
            bool fid = FiddlerApplication.IsStarted();

            
            return proxyPort;
        }

        //Stopping fiddler
        public static int StopFiddlerProxy()
        {
            if (FiddlerApplication.IsStarted())
            {
                FiddlerApplication.Shutdown();
            }
            return StopFiddlerProxy();
        }



    // A simple method created to test the status code returns
    //  Accepts the webdriver instance and the target url that needs to be accessed, response code after access is returned.
        public static int NavigateTo(IWebDriver driver, string targetUrl)
        {
            int responseCode = 0;
            SessionStateHandler responseHandler = delegate(Session targetSession)
            {
                if (targetSession.fullUrl == targetUrl)
                {
                    responseCode = targetSession.responseCode;
                }
            };

            FiddlerApplication.AfterSessionComplete += responseHandler;

            //Hardcoding to 10 seconds wait, assuming the worst response time for any request

            DateTime endTime = DateTime.Now.Add(TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl(targetUrl);
            while (responseCode == 0 && DateTime.Now < endTime)
            {
                System.Threading.Thread.Sleep(300);
            }

            FiddlerApplication.AfterSessionComplete -= responseHandler;
            return responseCode;
        }

//A method that clicks a webelement and records the response code 

        public static int ClickNavigate(IWebElement element)
        {
            int responseCode = 0;
            string targetUrl = string.Empty;
            SessionStateHandler responseHandler = delegate(Session targetSession)
            {
                // For the first session of the click, the URL should be the initial 
                // URL requested by the element click.
                if (string.IsNullOrEmpty(targetUrl))
                {
                    targetUrl = targetSession.fullUrl;
                }

                // This algorithm could be much more sophisticated based on need.
                // In this case, we'll only look for responses where the
                // content type contains application/msword, and that the URL of the session matches
                // our current target URL. Note that we also only set the response
                // code if it's not already been set.
                if (targetSession.oResponse["Content-Type"].Contains("application/msword") &&
                    targetSession.fullUrl == targetUrl &&
                    responseCode == 0)
                {
                    // If the response code is a redirect, get the URL of the
                    // redirect, so that we can look for the next response from
                    // the session for that URL.
                    if (targetSession.responseCode >= 300 &&
                        targetSession.responseCode < 400)
                    {
                        // Use GetRedirectTargetURL rather than examining the
                        // "Location" header, as some sites (illegally) might
                        // use a relative URL for the header
                        targetUrl = targetSession.GetRedirectTargetURL();
                    }
                    else
                    {
                        responseCode = targetSession.responseCode;
                    }
                }
            };

            // Note that we're using the ResponseHeadersAvailable event so
            // as to avoid a race condition with the browser 
            FiddlerApplication.ResponseHeadersAvailable += responseHandler;

            // the same 10 second wait for response
            DateTime endTime = DateTime.Now.Add(TimeSpan.FromSeconds(10));
            element.Click();
            while (responseCode == 0 && DateTime.Now < endTime)
            {
                System.Threading.Thread.Sleep(1000);
            }

            FiddlerApplication.ResponseHeadersAvailable += responseHandler;
            
            return responseCode;
        }

    }
}
