using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;

namespace Pegasus.Pages.Exceptions
{
    /// <summary>
    /// This class handles the different types of exception actions. 
    /// </summary>
    public static class ExceptionHandler
    {
        /// <summary>
        /// Static logger instance of the class.
        /// </summary>
        private static Logger exceptionLogger = Logger.GetInstance(typeof(ExceptionHandler));

        /// <summary>
        /// This method handels and throws exceptions.
        /// </summary>
        /// <param name="ex">This is the exception.</param>
        public static void HandleException(Exception ex)
        {
            // wrap the exception and not execute the below code in second run
            if (ex is GenericPageException
                || ex is OpenQA.Selenium.WebDriverTimeoutException
                || ex is InvalidOperationException
                || ex is OpenQA.Selenium.WebDriverException)
            {
                exceptionLogger.LogMessage("Exception Handler", "Rethrow handled exception out", "The nested child exception has already been handled", true);
                // close webdriver and browser instances
                WebDriverSingleton.GetInstance().Dispose();
                throw ex;
            }
            GenericPageException genericPageException = new GenericPageException(ex.ToString(), ex);
            exceptionLogger.LogException("ExceptionHandler", "handleException", ex, true);
            // close webdriver and browser instances
            WebDriverSingleton.GetInstance().Dispose();
            throw genericPageException;
        }
    }
}
