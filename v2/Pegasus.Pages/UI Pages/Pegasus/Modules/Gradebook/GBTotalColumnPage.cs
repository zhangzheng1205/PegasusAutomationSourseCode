using System;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Gradebook;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    ///  This class handles Pegasus GBTotalColumn Page Actions.
    /// </summary>
    public class GBTotalColumnPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger.
        /// </summary>
        private static readonly Logger logger = Logger.GetInstance(typeof(GBTotalColumnPage));

        /// <summary>
        /// Get Value In Total Weight Field.
        /// </summary>
        /// <returns>Total Weight Value</returns>
        public String GetValueInTotalWeightField()
        {
            //Get Value In Total Weight Field
            logger.LogMethodEntry("GBTotalColumnPage", "GetValueInTotalWeightField",
                base.isTakeScreenShotDuringEntryExit);
            //Initialized variable
            string totalWeight = string.Empty;
            try
            {
                //Select Create Total Column Window
                this.SelectCreateTotalColumnWindow();
                //Wait for Element
                base.WaitForElement(By.XPath(GBTotalColumnPageResource.
                    GBTotalColumn_Page_TotalWeightField_Xpath_Locator));
                //Get the value from total weight text box
                totalWeight = base.GetValueAttributeByXPath(GBTotalColumnPageResource.
                    GBTotalColumn_Page_TotalWeightField_Xpath_Locator);
                totalWeight = totalWeight.Substring(Convert.ToInt32(GBTotalColumnPageResource.
                    GBTotalColumn_Page_Substring_InitialIndex_Value),
                    Convert.ToInt32(GBTotalColumnPageResource.
                    GBTotalColumn_Page_Substring_EndIndex_Value));                  
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBTotalColumnPage", "GetValueInTotalWeightField",
                 base.isTakeScreenShotDuringEntryExit);
            return totalWeight;
        }

        /// <summary>
        /// Select Create Total Column Window.
        /// </summary>
        private void SelectCreateTotalColumnWindow()
        {
            //Select Create Total Column Window
            logger.LogMethodEntry("GBTotalColumnPage", "SelectCreateTotalColumnWindow",
                base.isTakeScreenShotDuringEntryExit);
            //Select Window
            base.SelectWindow(GBTotalColumnPageResource.GBTotalColumn_Page_WindowName);
            logger.LogMethodExit("GBTotalColumnPage", "SelectCreateTotalColumnWindow",
                 base.isTakeScreenShotDuringEntryExit);
        }
    }
}
