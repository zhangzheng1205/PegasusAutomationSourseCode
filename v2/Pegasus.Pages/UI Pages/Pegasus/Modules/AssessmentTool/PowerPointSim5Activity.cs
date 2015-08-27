using Microsoft.VisualStudio.TestTools.UITesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool.Presentation;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using Keys = OpenQA.Selenium.Keys;
using Pegasus.Automation;
using System.IO;
using System.Globalization;
using Pegasus.Pages.CommonPageObjects;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Discussion;





namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus Student Presentation Page Actions.
    /// </summary>
    public class PowerPointSim5Activity : BasePage
    {


        /// <summary>
        /// The Static Instance Of The Logger For The Class.
        /// </summary>
        private static Logger logger =
            Logger.GetInstance(typeof(StudentPresentationPage));

        private int waitTimeOut = Convert.ToInt32(
          ConfigurationManager.AppSettings["ElementFindTimeOutInSeconds"]);

        private string locatorType = string.Empty;
        private string locator = string.Empty;



        /// <summary>
        /// Attempt Sim5 Power Point Questions.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        public void AttemptSim5PowerPointQuestions(string activityName, string score)
        {
            //Attempt Sim5 Power Point Questions
            logger.LogMethodEntry("PowerPointSim5Activity", "AttemptSim5PowerPointQuestions",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (score)
                {
                    case "100%":
                        break;


                    case "70%": const int screenWidth = 1267;
                        const int screenHeight = 850;
                        // setting the screen size and position
                        //Thread.Sleep(1200000);

                        PPTAttemptForSeventyPercent(activityName);
                        break;
                }
                //Click On SIM5 Activity Submit Button
                this.ClickOnSim5ActivitySubmitButton();
                base.SwitchToDefaultWindow();

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PowerPointSim5Activity", "AttemptSim5PowerPointQuestions",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Attempt PPT SIM5 activity to score 70%.
        /// </summary>
        /// <param name="activityName">This is the activity name</param>
        public void PPTAttemptForSeventyPercent(string activityName)
        {
            // Attempt PPT SIM5 activity to score 70%
            logger.LogMethodEntry("PowerPointSim5Activity", "PPTAttemptForSeventyPercent",
              base.IsTakeScreenShotDuringEntryExit);
            //Attempt the question no. 1
            this.AttemptPPTQuestion01(activityName);
            //JumpToQuestion("18");
            //this.AttemptPPTQuestion18();
            JumpToQuestion("16");
            this.AttemptPPTQuestion16();
            JumpToQuestion("22");
            this.AttemptPPTQuestion22();
            //Open question no. 3
            JumpToQuestion("3");
            //Attempt the question no. 3

            this.AttemptPPTQuestion03(activityName);
            //Attempt the question no. 4

            this.AttemptPPTQuestion04(activityName);
            //Attempt the question no.5

            //this.AttemptPPTQuestion05(activityName);
            //Attempt the question no. 6
            JumpToQuestion("6");
            this.AttemptPPTQuestion06(activityName);
            JumpToQuestion("8");
            this.AttemptPPTQuestion08(activityName);

            this.AttemptPPTQuestion09();

            this.AttemptPPTQuestion10();

            this.AttemptPPTQuestion11();

            this.AttemptPPTQuestion12();

            this.AttemptPPTQuestion13();

            this.AttemptPPTQuestion14();

            this.AttemptPPTQuestion15();



            this.AttemptPPTQuestion17();
            //this.AttemptPPTQuestion18();

            JumpToQuestion("20");
            this.AttemptPPTQuestion20();

            this.AttemptPPTQuestion21();



            JumpToQuestion("25");
            this.AttemptPPTQuestion25();

            this.AttemptPPTQuestion26();

            this.AttemptPPTQuestion27();

            this.AttemptPPTQuestion28();
            JumpToQuestion("31");
            this.AttemptPPTQuestion31();
            JumpToQuestion("32");
            this.AttemptPPTQuestion32();
            JumpToQuestion("33");
            this.AttemptPPTQuestion33();

            logger.LogMethodExit("PowerPointSim5Activity", "PPTAttemptForSeventyPercent",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To verify the element display in UI.
        /// </summary>
        /// <param name="by">Locator type.</param>
        /// <param name="timeOut">time out.</param>
        /// <returns>returns bool value.</returns>
        public bool IsElementDisplayedInUI(By by, int timeOut = -1)
        {
            //If element not present then webdriver throw the exception, 
            //catch this exception so that outer code does not worry 
            //about this exception and existing logic which relies on TRUE/FALSE can work as it is except TimeoutException.
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            if (timeOut == -1)
            {
                timeOut = this.waitTimeOut;
            }
            bool isThinkingIndicatorProcessing = true;
            try
            {
                while (stopWatch.Elapsed.TotalSeconds < timeOut)
                {
                    if (WebDriver.FindElement(by).Displayed)
                    {
                        break;
                    }
                }
            }
            //Exception Handling
            catch (Exception)
            {
                stopWatch.Stop();
                return false;
            }
            stopWatch.Stop();
            return isThinkingIndicatorProcessing;
        }

        /// <summary>
        /// Select Presentation Player Window.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        public void SelectPresentationPlayerWindow(string activityName)
        {
            //Select Presentation Player Window
            logger.LogMethodEntry("PowerPointSim5Activity", "SelectPresentationPlayerWindow",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Student Details From Memory
            User user = User.Get(User.UserTypeEnum.CsSmsStudent);
            // Wait for window
            base.WaitUntilWindowLoads(activityName +
                StudentPresentationPageResource.StudentPrsentation_Page_Space_Hypen_Value + user.FirstName +
                StudentPresentationPageResource.StudentPrsentation_Page_Space_Value + user.LastName);
            //Select Window
            base.SelectWindow(activityName +
                StudentPresentationPageResource.StudentPrsentation_Page_Space_Hypen_Value + user.FirstName +
                StudentPresentationPageResource.StudentPrsentation_Page_Space_Value + user.LastName);
            logger.LogMethodExit("PowerPointSim5Activity", "SelectPresentationPlayerWindow",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To wait for the SIM5 question to load.
        /// </summary>
        /// <param name="timeOut">time out.</param>
        /// <returns>Returns bool value.</returns>
        private bool IsProcessingCurtainLoading(int timeOut = -1)
        {

            //If element not present then webdriver throw the exception, 
            //catch this exception so that outer code does not worry 
            //about this exception and existing logic which relies on TRUE/FALSE can work as it is except TimeoutException.
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            if (timeOut == -1)
            {
                timeOut = this.waitTimeOut;
            }
            bool isThinkingIndicatorProcessing = true;
            try
            {
                while (isThinkingIndicatorProcessing && stopWatch.Elapsed.TotalSeconds < timeOut)
                {
                    isThinkingIndicatorProcessing = WebDriver.FindElement(By.Id
                        (StudentPresentationPageResource.
                        StudentPrsentation_Page_SIM5_LoadingCurtain_Id_Locator)).Displayed;
                }
            }
            //Exception Handling
            catch (Exception)
            {
                stopWatch.Stop();
                return false;
            }
            stopWatch.Stop();
            return isThinkingIndicatorProcessing;
        }

        /// <summary>
        /// Click On SIM5 Activity Submit Button.
        /// </summary>
        public void ClickOnSim5ActivitySubmitButton()
        {
            logger.LogMethodEntry("PowerPointSim5Activity", "ClickOnSim5ActivitySubmitButton",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.IsPageLoading();
                base.WaitForElement(By.Id(StudentPresentationPageResource.
                StudentPresentation_Page_Submit_Button_Id_Locator));
                //Click on Ok button
                IWebElement getSubmitButton = base.GetWebElementPropertiesById
                (StudentPresentationPageResource.
                StudentPresentation_Page_Submit_Button_Id_Locator);
                base.ClickByJavaScriptExecutor(getSubmitButton);

                //Get the Submit Assignment 'OK' button as WebElement
                IWebElement getSubmitAssignment = base.GetWebElementPropertiesByXPath
                (StudentPresentationPageResource.
                StudentPresentation_Page_SubmitAssignment_OK_Button_Id_Locator);
                //Click on the Submit Assignment 'OK' button
                base.ClickByJavaScriptExecutor(getSubmitAssignment);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                                        StudentPresentation_Page_LaunchWindow_TimeValue));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PowerPointSim5Activity", "ClickOnSim5ActivitySubmitButton",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This method validates for page loading curtain display in SIM5 presentation page.
        /// </summary>
        /// <param name="timeOut">time out.</param>
        /// <returns>Returns bool value.</returns>
        public bool IsPageLoading(int timeOut = -1)
        {

            //If element not present then webdriver throw the exception, 
            //catch this exception so that outer code does not worry 
            //about this exception and existing logic which relies on TRUE/FALSE can work as it is except TimeoutException.
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            if (timeOut == -1)
            {
                timeOut = this.waitTimeOut;
            }
            bool isThinkingIndicatorProcessing = true;
            try
            {
                while (stopWatch.Elapsed.TotalSeconds < timeOut && isThinkingIndicatorProcessing)
                {
                    isThinkingIndicatorProcessing = WebDriver.FindElement(By.Id(StudentPresentationPageResource.
                        StudentPrsentation_Page_SIM5_LoadingCurtain_Id_Locator)).Displayed;
                    if (isThinkingIndicatorProcessing == false)
                    {
                        break;
                    }
                }
            }
            //Exception Handling
            catch (Exception)
            {
                stopWatch.Stop();
                return false;
            }
            stopWatch.Stop();
            return isThinkingIndicatorProcessing;
        }

        /// <summary>
        /// Post condition method to verify if next expected element is present.
        /// </summary>
        /// <param name="by">This is the type of locator.</param>
        /// <param name="locator">This is the locator value.</param>
        /// <returns></returns>
        public bool IsElementPresent(string by, string locator)
        {
            // Post condition method to verify if next expected element is present
            logger.LogMethodEntry("PowerPointSim5Activity", "IsElementPresent",
             base.IsTakeScreenShotDuringEntryExit);
            bool present = false;
            switch (by)
            {
                case "id": base.WaitForElement(By.Id(locator), 200);
                    present = base.IsElementPresent(By.Id(locator), 5);
                    break;
                case "css": base.WaitForElement(By.CssSelector(locator), 200);
                    present = base.IsElementPresent(By.CssSelector(locator), 5);
                    break;
            }
            logger.LogMethodExit("PowerPointSim5Activity", "IsElementPresent",
           base.IsTakeScreenShotDuringEntryExit);
            return present;

        }

        /// <summary>
        /// Open a question from view all.
        /// </summary>
        /// <param name="questNo"></param>
        public void getQuestionNumber(int questNo)
        {
            logger.LogMethodEntry("PowerPointSim5Activity", "getQuestionNumber",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Open a question from view all
                base.SetImplicitWaitTime(15);
                this.IsPageLoading();
                //Click the view all button
                IWebElement getClickButtonProperty = base.GetWebElementPropertiesById(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_ViewAll_ID_Locator);
                Thread.Sleep(2000);
                locatorType = "css";
                locator = StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_ViewAll_Page_Xpath_Locator;
                getClickButtonProperty.SmartClick(driver: WebDriver, postcondition: x => IsElementPresent
                (locatorType, locator), iterations: 3,
                clicks: ClickAction.JSClick);
                //Get the question number
                IWebElement questLink = base.GetWebElementPropertiesByXPath(string.Format(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_ViewAll_Question_Xpath_Locator, questNo));
                base.ScrollElementByJavaScriptExecutor(questLink);
                base.PerformFocusOnElementActionByXPath(string.Format(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_ViewAll_Question_Xpath_Locator, questNo));
                //Click on the question
                getClickButtonProperty.SmartClick(driver: WebDriver, postcondition: x => IsViewAllQuestionsPopUpClosed()
                , iterations: 3,
                clicks: ClickAction.DoubleClick);
                this.IsPageLoading();
                base.SetImplicitWaitTime(15);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PowerPointSim5Activity", "getQuestionNumber",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Element By cssSelector.
        /// </summary>
        /// <param name="elementAttribute">This is an Attribute.</param>
        public void ClickOnElementByCssSelector(string elementAttribute)
        {
            //Click On Element By Xpath
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnElementByCssSelector",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on Element
            base.WaitForElement(By.CssSelector(elementAttribute));
            IWebElement getElementProperty = base.GetWebElementPropertiesByCssSelector(elementAttribute);
            Thread.Sleep(4000);
            base.ClickByJavaScriptExecutor(getElementProperty);
            Thread.Sleep(2000);
            logger.LogMethodExit("StudentPresentationPage", "ClickOnElementByCssSelector",
                base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Click On Element By Xpath.
        /// </summary>
        /// <param name="elementAttribute">This is an Attribute.</param>
        public void ClickOnElementByXpath(string elementAttribute)
        {
            //Click On Element By Xpath
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnElementByXpath",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on Element

            base.WaitForElement(By.XPath(elementAttribute));
            IWebElement getElementProperty = base.GetWebElementPropertiesByXPath(elementAttribute);
            Thread.Sleep(4000);
            base.ClickByJavaScriptExecutor(getElementProperty);
            Thread.Sleep(2000);
            logger.LogMethodExit("StudentPresentationPage", "ClickOnElementByXpath",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Element By Id.
        /// </summary>
        /// <param name="elementAttribute">This is an Attribute.</param>
        public void ClickOnElementById(string elementAttribute)
        {
            //Click On Element By Xpath
            logger.LogMethodEntry("StudentPresentationPage", "ClickOnElementByXpath",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on Element

            base.WaitForElement(By.Id(elementAttribute));
            IWebElement getElementProperty = base.GetWebElementPropertiesById(elementAttribute);
            Thread.Sleep(4000);
            base.ClickByJavaScriptExecutor(getElementProperty);
            Thread.Sleep(2000);
            logger.LogMethodExit("StudentPresentationPage", "ClickOnElementByXpath",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To verify View All Qusetion window closure.
        /// </summary>
        /// <param name="timeOut">time out.</param>
        /// <returns>Returns bool value.</returns>
        public bool IsViewAllQuestionsPopUpClosed(int timeOut = -1)
        {

            //If element not present then webdriver throw the exception, 
            //catch this exception so that outer code does not worry 
            //about this exception and existing logic which relies on TRUE/FALSE can work as it is except TimeoutException.
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            if (timeOut == -1)
            {
                timeOut = this.waitTimeOut;
            }
            bool isThinkingIndicatorProcessing = true;
            try
            {
                while (stopWatch.Elapsed.TotalSeconds < timeOut)
                {
                    if (!WebDriver.FindElement(By.Id("ViewAllFrame")).Displayed)
                    {
                        break;
                    }
                }
            }
            //Exception Handling
            catch (Exception)
            {
                stopWatch.Stop();
                return false;
            }
            stopWatch.Stop();
            return isThinkingIndicatorProcessing;
        }

        /// <summary>
        /// To verify if SIM5 Question is loaded.
        /// </summary>
        /// <param name="questionNumber">This the expected question.</param>
        /// <param name="timeOut">time out.</param>
        /// <returns>This return bool value.</returns>
        public bool IsQuestionLoaded(string questionNumber, int timeOut = -1)
        {

            //If element not present then webdriver throw the exception, 
            //catch this exception so that outer code does not worry 
            //about this exception and existing logic which relies on TRUE/FALSE can work as it is except TimeoutException.
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            if (timeOut == -1)
            {
                timeOut = this.waitTimeOut;
            }
            bool isThinkingIndicatorProcessing = true;
            try
            {
                while (stopWatch.Elapsed.TotalSeconds < timeOut)
                {
                    string getQuestionID = base.GetElementTextByCssSelector("div#quetionattempt > span");
                    if (getQuestionID.Equals(questionNumber))
                    {
                        break;
                    }
                }
            }
            //Exception Handling
            catch (Exception)
            {
                stopWatch.Stop();
                return false;
            }
            stopWatch.Stop();
            return isThinkingIndicatorProcessing;
        }

        /// <summary>
        /// To Navigate to expected question.
        /// </summary>
        /// <param name="questionNumber">Question Number.</param>
        public void JumpToQuestion(string questionNumber)
        {
            //Select question from View all questions pop up
            logger.LogMethodEntry("PowerPointSim5Activity", "JumpToWordQuestion",
            base.IsTakeScreenShotDuringEntryExit);
            this.SelectLastOpenedWindow();
            Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
           StudentPrsentation_Page_SIM5_Sleep_Time));
            this.IsPageLoading();
            this.IsElementDisplayedInUI(By.Id(StudentPresentationPageResource.
            StudentPrsentation_Page_PPT_ViewAll_ID_Locator));
            //Click on View all button 
            IWebElement getClickButtonProperty = base.GetWebElementPropertiesById(StudentPresentationPageResource.
             StudentPrsentation_Page_PPT_ViewAll_ID_Locator);
            base.ClickByJavaScriptExecutor(getClickButtonProperty);
            this.IsElementDisplayedInUI(By.CssSelector(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument__ViewAllQuestions_QuestionsList_Xpath_Locator));
            base.IsElementPresent(By.CssSelector(StudentPresentationPageResource.
                StudentPrsentation_Page_Worddocument__ViewAllQuestions_QuestionsList_Xpath_Locator), 5);
            //Get total number of questions present in view all questions pop up    
            int getTotalQuestions = base.GetElementCountByCssSelector(StudentPresentationPageResource.
                        StudentPrsentation_Page_Worddocument__ViewAllQuestions_QuestionsList_Xpath_Locator);
            //Click on the required question
            for (int i = 1; i <= getTotalQuestions; i++)
            {
                string getQuestionNumber = base.GetElementTextByCssSelector(string.
                    Format(StudentPresentationPageResource.
                    StudentPrsentation_Page_Worddocument__ViewAllQuestionsPopUp_QuestionPath_Xpath_Locator, i));
                if (getQuestionNumber.Equals(questionNumber))
                {
                    Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
               StudentPrsentation_Page_SIM5_Sleep_Time));
                    IWebElement getQuestionRowProperty = base.GetWebElementPropertiesByCssSelector(string.
                    Format(StudentPresentationPageResource.
                    StudentPrsentation_Page_Worddocument__ViewAllQuestionsPopUp_QuestionPath_Xpath_Locator, i));
                    Thread.Sleep(5000);
                    base.PerformMouseHoverByJavaScriptExecutor(getQuestionRowProperty);
                    base.DoubleClickByJavaScriptExecuter(getQuestionRowProperty);
                    //base.ClickImageByClassName("custom-box-button LaunchExam enabled");      
                    break;
                }

            }
            this.IsViewAllQuestionsPopUpClosed();
            logger.LogMethodExit("PowerPointSim5Activity", "JumpToWordQuestion",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Last Opened Window.
        /// </summary>
        private void SelectLastOpenedWindow()
        {
            //Select Last Opened Window
            logger.LogMethodEntry("PowerPointSim5Activity", "SelectLastOpenedWindow",
                base.IsTakeScreenShotDuringEntryExit);

            base.SwitchToLastOpenedWindow();
            //Get Window Title
            string windowTitle = base.GetPageTitle;
            base.WaitUntilWindowLoads(windowTitle);
            //Select Presentation Window
            base.SelectWindow(windowTitle);
            logger.LogMethodExit("PowerPointSim5Activity", "SelectLastOpenedWindow",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// PPT question no.01 attempt.
        /// </summary>
        /// <param name="activityName">This is activity name</param>
        public void AttemptPPTQuestion01(string activityName)
        {
            // PPT question no.01 attempt

            logger.LogMethodEntry("PowerPointSim5Activity", "SelectPresentationPlayerWindow",
                base.IsTakeScreenShotDuringEntryExit);
            //Select the activity window
            SelectPresentationPlayerWindow(activityName);
            //In the Windows 8 Start screen, scroll to, and then right-click PowerPoint 2013
            base.WaitForElement(By.Id(StudentPresentationPageResource.
            StudentPrsentation_Page_PowerPoint_Option_Id_Locator));
            base.PerformFocusOnElementActionById(StudentPresentationPageResource.
            StudentPrsentation_Page_PowerPoint_Option_Id_Locator);
            IWebElement getPowerPointOptionProperty =
                base.GetWebElementPropertiesById(StudentPresentationPageResource.
                StudentPrsentation_Page_PowerPoint_Option_Id_Locator);
            Thread.Sleep(2000);
            locatorType = "css";
            locator = StudentPresentationPageResource.
                     StudentPrsentation_Page_Facet_Template_Xpath_Locator;
            getPowerPointOptionProperty.SmartClick(driver: WebDriver, postcondition: x => IsElementPresent
            (locatorType, locator), iterations: 3,
               clicks: ClickAction.JSClick);
            IWebElement getPPTFacetIcon =
                base.GetWebElementPropertiesByCssSelector(StudentPresentationPageResource.
                     StudentPrsentation_Page_Facet_Template_Xpath_Locator);
            Thread.Sleep(2000);
            locatorType = "id";
            locator = StudentPresentationPageResource.
                     StudentPrsentation_Page_Create_Option_Id_Locator;
            getPPTFacetIcon.SmartClick(driver: WebDriver, postcondition: x => IsElementPresent
            (locatorType, locator), iterations: 3,
               clicks: ClickAction.JSClick);
            IWebElement getCreateOptionProperty =
                    base.GetWebElementPropertiesById(StudentPresentationPageResource.
                    StudentPrsentation_Page_Create_Option_Id_Locator);
            Thread.Sleep(2000);
            getCreateOptionProperty.SmartClick(driver: WebDriver, iterations: 3,
              clicks: ClickAction.JSClick);
            this.IsProcessingCurtainLoading();

        }

        /// <summary>
        /// PPT question no.03 attempt.
        /// </summary>
        /// <param name="activityName">This is activity name</param>
        public void AttemptPPTQuestion03(string activityName)
        {
            //Attempt Third Question
            logger.LogMethodEntry("PowerPointSim5Activity", "AttemptThirdQuestion",
                base.IsTakeScreenShotDuringEntryExit);

            try
            {
                SelectPresentationPlayerWindow(activityName);
                IWebElement getPageDesignTabProperty = base.GetWebElementPropertiesByCssSelector(StudentPresentationPageResource.
                 StudentPrsentation_Page_Design_Tab_Xpath_Locator);
                Thread.Sleep(2000);
                locatorType = "css";
                locator = StudentPresentationPageResource.
                    StudentPrsentation_Page_Design_Theme_Xpath_Locator;
                getPageDesignTabProperty.SmartClick(driver: WebDriver, postcondition: x => IsElementPresent
               (locatorType, locator), iterations: 3,
                clicks: ClickAction.JSClick);
                //Click on Design Theme More Button
                IWebElement getMoreButton = base.GetWebElementPropertiesByCssSelector(StudentPresentationPageResource.
                 StudentPrsentation_Page_Design_Theme_Xpath_Locator);
                Thread.Sleep(2000);
                locatorType = "css";
                locator = StudentPresentationPageResource.
                    StudentPrsentation_Page_Organic_Theme_Xpath_Locator;
                getMoreButton.SmartClick(driver: WebDriver, postcondition: x => IsElementPresent
                (locatorType, locator), iterations: 3,
                 clicks: ClickAction.JSClick);
                //Select Organic Theme
                IWebElement getOrganicThemeIcon = base.GetWebElementPropertiesByCssSelector(StudentPresentationPageResource.
                  StudentPrsentation_Page_Organic_Theme_Xpath_Locator);
                Thread.Sleep(2000);
                getOrganicThemeIcon.SmartClick(driver: WebDriver, iterations: 3,
                 clicks: ClickAction.JSClick);
                this.IsProcessingCurtainLoading();

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("PowerPointSim5Activity", "AttemptThirdQuestion",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// PPT question no.04 attempt.
        /// </summary>
        /// <param name="activityName">This is activity name</param>
        public void AttemptPPTQuestion04(string activityName)
        {
            //Attempt Fourth Question
            logger.LogMethodEntry("PowerPointSim5Activity", "AttemptPPTQuestion04",
               base.IsTakeScreenShotDuringEntryExit);

            try
            {
                Actions builder = new Actions(WebDriver);
                this.IsQuestionLoaded("4");
                base.SetImplicitWaitTime(Convert.ToInt32
                  (StudentPresentationPageResource.StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                this.IsPageLoading();
                //Select Panoromic Slide and Enter Title
                this.SelectPanoromicSlideandEnterTitle();
                Thread.Sleep(4000);
                //Create New Slide
                IWebElement getNewSlide = base.GetWebElementPropertiesByCssSelector(StudentPresentationPageResource.
                StudentPrsentation_Page_NewSlide_Xpath_Locator);
                Thread.Sleep(2000);
                locatorType = "css";
                locator = StudentPresentationPageResource.
                   StudentPrsentation_Page_Title_Content_Slide;
                getNewSlide.SmartClick(driver: WebDriver, postcondition: x => IsElementPresent
                 (locatorType, locator), iterations: 3,
                  clicks: ClickAction.JSClick);
                //Create Title and Content Slide
                IWebElement getContentSlide = base.GetWebElementPropertiesByCssSelector(StudentPresentationPageResource.
                StudentPrsentation_Page_Title_Content_Slide);
                Thread.Sleep(2000);
                locatorType = "css";
                locator = StudentPresentationPageResource.
                    StudentPrsentation_Page_Title_Xpath_Locator;
                getContentSlide.SmartClick(driver: WebDriver, postcondition: x => IsElementPresent
                 (locatorType, locator), iterations: 3,
                  clicks: ClickAction.JSClick);
                //Click on Title Content
                IWebElement getTitleBoxProperty = base.GetWebElementPropertiesByCssSelector(StudentPresentationPageResource.
                    StudentPrsentation_Page_Title_Xpath_Locator);
                Thread.Sleep(2000);
                locatorType = "css";
                locator = StudentPresentationPageResource.
                   StudentPrsentation_Page_Title_Xpath_Locator;
                getTitleBoxProperty.SmartClick(driver: WebDriver, postcondition: x => IsElementPresent
                 (locatorType, locator), iterations: 3,
                  clicks: ClickAction.JSClick);
                //Type Title
                IWebElement getTitleProperty = base.GetWebElementPropertiesByCssSelector(StudentPresentationPageResource.
                    StudentPrsentation_Page_Title_Xpath_Locator);
                Thread.Sleep(2000);

                base.FillTextToInnerHtmlByCssFillTexttoInnerHtmlThroughJavaScriptExecutor(StudentPresentationPageResource.
                    StudentPrsentation_Page_Title_Xpath_Locator,
                    StudentPresentationPageResource.StudentPrsentation_Page_Title_Content_Slide_Title_Value);
                //Perform click

                IWebElement Perfclick = base.GetWebElementPropertiesByCssSelector(StudentPresentationPageResource.
                 StudentPrsentation_Page_Title_Xpath_Locator);
                Thread.Sleep(2000);
                locator = StudentPresentationPageResource.
                 StudentPrsentation_Page_Content_Text;
                builder.SendKeys(Keys.End + Keys.Tab).Perform();
                //Click on Content
                IWebElement getContent = base.GetWebElementPropertiesByCssSelector(StudentPresentationPageResource.
               StudentPrsentation_Page_Content_Text);
                Thread.Sleep(2000);
                locator = StudentPresentationPageResource.
                 StudentPrsentation_Page_Content_Text;
                getContent.SmartClick(driver: WebDriver, postcondition: x => IsElementPresent
                 (locatorType, locator), iterations: 3,
                  clicks: ClickAction.JSClick);
                //Fill Text             
                base.FillTextToInnerHtmlByCssFillTexttoInnerHtmlThroughJavaScriptExecutor(StudentPresentationPageResource.
                    StudentPrsentation_Page_Content_Text, StudentPresentationPageResource.
                    StudentPrsentation_Page_Content_FirstBullet_Text);
                //Click on tab key
                builder.SendKeys(Keys.Tab).Perform();
                base.SetImplicitWaitTime(Convert.ToInt32
                   (StudentPresentationPageResource.StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                this.IsProcessingCurtainLoading();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("PowerPointSim5Activity", "AttemptPPTQuestion04",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// PPT question no.05 attempt.
        /// </summary>
        /// <param name="activityName">This is activity name</param>
        public void AttemptPPTQuestion05(string activityName)
        {
            //Attempt Fifth Question
            logger.LogMethodEntry("PowerPointSim5Activity", "AttemptPPTQuestion05",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.IsQuestionLoaded("5");
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                this.IsPageLoading();
                SelectPresentationPlayerWindow(activityName);
                //Enter Text In First Bulleted Point
                this.EnterTextInFirstBulletedPoint();
                //Enter Text In Second Bulleted Point
                this.EnterTextInSecondBulletedPoint();
                //Enter Text In Third Bulleted Point
                this.EnterTextInThirdBulletedPoint();
                this.IsProcessingCurtainLoading();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PowerPointSim5Activity", "AttemptPPTQuestion05",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Text In First Bulleted Point in question 05.
        /// </summary>
        private void EnterTextInFirstBulletedPoint()
        {
            //Enter Text In First Bulleted Point
            logger.LogMethodEntry("PowerPointSim5Activity", "EnterTextInFirstBulletedPoint",
                base.IsTakeScreenShotDuringEntryExit);
            Actions builder = new Actions(WebDriver);
            //Click and Place Cursor Location
            base.WaitForElement(By.CssSelector(StudentPresentationPageResource.
                StudentPrsentation_Page_First_Bulleted_Point_Xpath_Locator));
            IWebElement getCursorLocation = base.GetWebElementPropertiesByCssSelector(
                StudentPresentationPageResource.StudentPrsentation_Page_First_Bulleted_Point_Xpath_Locator);
            Thread.Sleep(4000);
            base.SetImplicitWaitTime(5);
            getCursorLocation.SmartClick(driver: WebDriver, iterations: 3,
              clicks: ClickAction.JSClick);
            base.PlaceCursorPosition(getCursorLocation, 50, 50);
            Thread.Sleep(2000);
            builder.SendKeys(Keys.End).Perform();
            Thread.Sleep(4000);
            builder.SendKeys(Keys.Enter + Keys.Tab).Perform();

            //Enter Text in bulleted Point
            Thread.Sleep(4000);
            this.IsElementDisplayedInUI(By.CssSelector(StudentPresentationPageResource.
                StudentPrsentation_Page_First_Bulleted_Point_Text_Xpath_Locator));
            base.FillTextToInnerHtmlByCssFillTexttoInnerHtmlThroughJavaScriptExecutor(
                StudentPresentationPageResource.StudentPrsentation_Page_First_Bulleted_Point_Text_Xpath_Locator,
                StudentPresentationPageResource.StudentPrsentation_Page_First_Bulleted_Point_Text_Value);
            Thread.Sleep(4000);
            builder.SendKeys(Keys.End).Perform();
            logger.LogMethodExit("PowerPointSim5Activity", "EnterTextInFirstBulletedPoint",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Text In Second Bulleted Point in question 05.
        /// </summary>
        private void EnterTextInSecondBulletedPoint()
        {
            //Enter Text In Second Bulleted Point
            logger.LogMethodEntry("PowerPointSim5Activity", "EnterTextInSecondBulletedPoint",
                base.IsTakeScreenShotDuringEntryExit);
            base.SetImplicitWaitTime(5);
            Actions builder = new Actions(WebDriver);
            //Click and Place Cursor Location
            //builder.SendKeys(Keys.End + Keys.Enter).Perform();
            builder.SendKeys(Keys.Enter).Perform();
            //Click on 'Decrease List Level' Option
            base.WaitForElement(By.CssSelector(StudentPresentationPageResource.
                StudentPrsentation_Page_DecreaseList_Level_Xpath_Locator));
            IWebElement decreaseBulletOrder = base.GetWebElementPropertiesByCssSelector
                (StudentPresentationPageResource.
               StudentPrsentation_Page_DecreaseList_Level_Xpath_Locator);
            Thread.Sleep(4000);
            locator = "div#ContentDiv_TP_4 > ul > li:nth-of-type(3) > span";
            locatorType = "css";
            decreaseBulletOrder.SmartClick(driver: WebDriver, postcondition: x => IsElementPresent
            (locatorType, locator), iterations: 3,
             clicks: ClickAction.JSClick);
            Thread.Sleep(4000);
            //Enter Text in bulleted Point               
            this.IsElementDisplayedInUI(By.CssSelector("div#ContentDiv_TP_4 > ul > li:nth-of-type(3)"));
            base.FillTextToInnerHtmlByCssFillTexttoInnerHtmlThroughJavaScriptExecutor
                ("div#ContentDiv_TP_4 > ul > li:nth-of-type(3)",
               StudentPresentationPageResource.StudentPrsentation_Page_Second_Bulleted_Point_Text_Value);
            Thread.Sleep(4000);
            builder.SendKeys(Keys.End).Perform();
            logger.LogMethodExit("PowerPointSim5Activity", "EnterTextInSecondBulletedPoint",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Text In Third Bulleted Point in question 05.
        /// </summary>
        private void EnterTextInThirdBulletedPoint()
        {
            //Enter Text In Third Bulleted Point
            logger.LogMethodEntry("PowerPointSim5Activity", "EnterTextInThirdBulletedPoint",
                base.IsTakeScreenShotDuringEntryExit);
            Actions builder = new Actions(WebDriver);
            //Click and Place Cursor Location
            IWebElement getCursorLocation = base.GetWebElementPropertiesByCssSelector(StudentPresentationPageResource.
                StudentPrsentation_Page_Second_Bulleted_Point_Text_Xpath_Locator);
            Thread.Sleep(4000);
            builder.SendKeys(Keys.Enter + Keys.Tab).Perform();
            Thread.Sleep(4000);
            //Enter Text in bulleted Point
            this.IsElementDisplayedInUI(By.CssSelector("div#ContentDiv_TP_4 > ul > li:nth-of-type(4)"));
            base.FillTextToInnerHtmlByCssFillTexttoInnerHtmlThroughJavaScriptExecutor("div#ContentDiv_TP_4 > ul > li:nth-of-type(4)",
                StudentPresentationPageResource.StudentPrsentation_Page_Third_Bulleted_Point_Text_Value);
            Thread.Sleep(4000);
            builder.SendKeys(Keys.End).Perform();
            logger.LogMethodExit("PowerPointSim5Activity", "EnterTextInThirdBulletedPoint",
            base.IsTakeScreenShotDuringEntryExit);
        }



        /// <summary>
        /// Select Panoromic Slide and Enter Title.
        /// </summary>
        public void SelectPanoromicSlideandEnterTitle()
        {
            //Select Panoromic Slide and Enter Title
            logger.LogMethodEntry("PowerPointSim5Activity", "SelectPanoromicSlideandEnterTitle",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Home Tab
                IWebElement getHomeTabProperties = base.GetWebElementPropertiesByCssSelector
                    (StudentPresentationPageResource.
                 StudentPrsentation_Page_Home_Tab_Xpath_Locator);
                Thread.Sleep(2000);
                locatorType = "css";
                string preLocatorValue = StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_SlideToWait_Xpath_Locator;
                locator = StudentPresentationPageResource.
                    StudentPrsentation_Page_NewSlide_Xpath_Locator;
                getHomeTabProperties.SmartClick(driver: WebDriver, postcondition: x => IsElementPresent
                 (locatorType, locator), iterations: 3,
                  clicks: ClickAction.JSClick);
                //next step
                IWebElement getNewSlideProperties = base.GetWebElementPropertiesByCssSelector
                    (StudentPresentationPageResource.
                 StudentPrsentation_Page_NewSlide_Xpath_Locator);
                Thread.Sleep(2000);
                base.PerformMouseHoverAction(getNewSlideProperties);
                locatorType = "css";
                locator = StudentPresentationPageResource.
                    StudentPrsentation_Page_Panoramic_Slide_Xpath_Locator;
                getNewSlideProperties.SmartClick(driver: WebDriver, postcondition: x => IsElementPresent
                 (locatorType, locator), iterations: 3,
                  clicks: ClickAction.JSClick);
                //Select Panoromic Slide
                IWebElement getPanoromicSlide = base.GetWebElementPropertiesByCssSelector
                   (StudentPresentationPageResource.
                StudentPrsentation_Page_Panoramic_Slide_Xpath_Locator);
                Thread.Sleep(2000);
                locatorType = "css";
                locator = StudentPresentationPageResource.
                    StudentPrsentation_Page_Title_Xpath_Locator;

                getPanoromicSlide.SmartClick(driver: WebDriver, postcondition: x => IsElementPresent
                 (locatorType, locator), iterations: 3,
                  clicks: ClickAction.JSClick);
                //Enter Title
                bool pres = base.IsElementPresent(By.CssSelector(StudentPresentationPageResource.
                         StudentPrsentation_Page_Title_Xpath_Locator), 10);
                IWebElement getTitleField = base.GetWebElementPropertiesByCssSelector
                           (StudentPresentationPageResource.
                        StudentPrsentation_Page_Title_Xpath_Locator);
                Thread.Sleep(2000);
                locatorType = "css";
                locator = StudentPresentationPageResource.
                    StudentPrsentation_Page_Title_Xpath_Locator;
                getTitleField.SmartClick(driver: WebDriver, postcondition: x => IsElementPresent
                 (locatorType, locator), iterations: 3,
                  clicks: ClickAction.JSClick);
                //Enter Title                
                base.FillTextToInnerHtmlByCssFillTexttoInnerHtmlThroughJavaScriptExecutor(StudentPresentationPageResource.
             StudentPrsentation_Page_Title_Xpath_Locator, StudentPresentationPageResource.
             StudentPrsentation_Page_Fourth_Question_Title_Value);
                Actions builder = new Actions(WebDriver);
                builder.SendKeys(Keys.Tab).Perform();

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("PowerPointSim5Activity", "SelectPanoromicSlideandEnterTitle",
               base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// PPT question no.06 attempt.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        public void AttemptPPTQuestion06(string activityName)
        {
            //Attempt Sixth Question
            logger.LogMethodEntry("PowerPointSim5Activity", "AttemptPPTQuestion06",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.IsQuestionLoaded("6");
                Actions builder = new Actions(WebDriver);
                base.SetImplicitWaitTime(Convert.ToInt32
                    (StudentPresentationPageResource.StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                //Click on Notes
                bool notesPresent = base.IsElementPresent(By.CssSelector
                    (StudentPresentationPageResource.
                    StudentPrsentation_Page_PPT_6_NotesIcon_Xpath_Locator), 5);
                while (!notesPresent)
                {

                    builder.SendKeys(Keys.F6).Perform();
                    notesPresent = base.IsElementPresent(By.CssSelector
                        (StudentPresentationPageResource.
                        StudentPrsentation_Page_PPT_6_NotesIcon_Xpath_Locator), 5);
                }

                base.FillTextToInnerHtmlByCssFillTexttoInnerHtmlThroughJavaScriptExecutor(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_6_NotesIcon_Xpath_Locator,
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_6_Notes_Value);
                //Click and place cursor Location

                builder.SendKeys(Keys.End).Perform();
                builder.SendKeys(Keys.Delete).Perform();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PowerPointSim5Activity", "AttemptPPTQuestion06",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// PPT question no.08 attempt.
        /// </summary>
        /// <param name="activityName">This is activity name</param>
        public void AttemptPPTQuestion08(string activityName)
        {
            logger.LogMethodEntry("PowerPointSim5Activity", "AttemptPPTQuestion08",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.IsQuestionLoaded("8");
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
                StudentPresentation_Page_PPT_Slide2_Value));
                //click on slide 2
                IWebElement newSlide = base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                StudentPresentation_Page_PPT_Slide2_Value);
                Thread.Sleep(4000);
                ClickOnElementByCssSelector(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_TitleOfSLide_CssLocator);
                base.SwitchToLastOpenedWindow();
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                base.WaitForElement(By.Id(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_8_ImageIcon1_ID_Locator));
                //  click on image "1A_Glacier.jpg"
                base.ClickImageById(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_8_ImageIcon1_ID_Locator);
                //click on Insert button
                ClickOnElementByCssSelector(StudentPresentationPageResource.StudentPrsentation_Page_PPT_8_InsertButton_CSSLocator);
                this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
                StudentPresentation_Page_PPT_Slide4_Value));
                ClickOnElementByXpath(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_EightQuestion_Slide4_Xpath_Locator);
                ClickOnElementByCssSelector(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_8_ContentTitleButton_CSSLocator);
                //  click on image 
                this.IsElementDisplayedInUI(By.Id(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_8_ImageIcon2_ID_Locator));
                base.ClickImageById(StudentPresentationPageResource.StudentPrsentation_Page_PPT_8_ImageIcon2_ID_Locator);
                //click on Insert button
                ClickOnElementByCssSelector(
                 StudentPresentationPageResource.StudentPrsentation_Page_PPT_8_InsertButton_CSSLocator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("PowerPointSim5Activity", "AttemptPPTQuestion08",
          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// PPT question no.09 attempt.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        public void AttemptPPTQuestion09()
        {
            logger.LogMethodEntry("PowerPointSim5Activity", "AttemptPPTQuestion09",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.IsQuestionLoaded("9");
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                //click on slide 4
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPresentation_Page_PPT_Slide4_Value);
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                //click on pitcure
                this.ClickOnElementByCssSelector(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_TitleOfSLide_CssLocator);
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                //click on format tab
                this.ClickOnElementByCssSelector(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_FormatTab_CSSLocator);
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                    StudentPrsentation_Page_PPT_9_DownArrow_Xpath_Locator);
                // select simple black pitcure style                
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_9_PitctureStyle_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("PowerPointSim5Activity", "AttemptPPTQuestion09",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// PPT question no.10 attempt.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        public void AttemptPPTQuestion10()
        {
            logger.LogMethodEntry("PowerPointSim5Activity", "AttemptPPTQuestion10",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.IsQuestionLoaded("10");
                this.IsPageLoading();
                //click on slide 4 
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPresentation_Page_PPT_Slide4_Value);
                // click on the picture 
                this.ClickOnElementByCssSelector(
                 StudentPresentationPageResource.StudentPrsentation_Page_PPT_TitleOfSLide_CssLocator);
                //click on format tab
                this.ClickOnElementByCssSelector(
                 StudentPresentationPageResource.StudentPrsentation_Page_PPT_FormatTab_CSSLocator);
                // click on Artistic Effect and select glow diffused
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                 StudentPrsentation_Page_PPT_10_ArtisticEffectsButton_Xpath_Locator);
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                    StudentPrsentation_Page_PPT_10_GlowDiffusedButton_Xpath_Locator);
                //Remove the artistic effect from the SLide 4 by selecting None on Artistic effect
                this.ClickOnElementByCssSelector(
                 StudentPresentationPageResource.StudentPrsentation_Page_PPT_TitleOfSLide_CssLocator);
                this.ClickOnElementByCssSelector(
                 StudentPresentationPageResource.StudentPrsentation_Page_PPT_FormatTab_CSSLocator);
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                 StudentPrsentation_Page_PPT_10_ArtisticEffectsButton_Xpath_Locator);
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                 StudentPrsentation_Page_PPT_10_NoneButton_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("PowerPointSim5Activity", "AttemptPPTQuestion10",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// PPT question no.11 attempt.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        public void AttemptPPTQuestion11()
        {
            logger.LogMethodEntry("PowerPointSim5Activity", "AttemptPPTQuestion11",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.IsQuestionLoaded("11");
                Actions builder = new Actions(WebDriver);
                //click on slide show tool bar and click on Start from begining
                base.WaitForElement(By.XPath(StudentPresentationPageResource.StudentPrsentation_Page_PPT_SlideShowTab_Xpath_Locator));
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_SlideShowTab_Xpath_Locator));
                this.ClickOnElementByXpath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_11_FromBeginingButton_Xpath_Locator);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                        StudentPrsentation_Page_SIM5_Sleep_Time));
                // press space bar to proceed to slide 2-6
                for (int i = 0; i < 5; i++)
                {
                    builder.SendKeys(Keys.Enter).Perform();
                    Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                          StudentPrsentation_Page_SIM5_Sleep_Time));
                }
                // Press Esc to return Normal view
                builder.SendKeys(Keys.Escape).Perform();

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("PowerPointSim5Activity", "AttemptPPTQuestion11",
            base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// PPT question no.12 attempt.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        public void AttemptPPTQuestion12()
        {
            logger.LogMethodEntry("PowerPointSim5Activity", "AttemptPPTQuestion12",
          base.IsTakeScreenShotDuringEntryExit);

            try
            {
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Sleep_Time));
                //click on slide show tool bar and under Monitors group check "Use Presenter View"
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_SlideShowTab_Xpath_Locator));
                IWebElement slideShowTab = base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_PPT_SlideShowTab_Xpath_Locator);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Sleep_Time));
                base.ClickByJavaScriptExecutor(slideShowTab);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
               StudentPrsentation_Page_SIM5_Sleep_Time));
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_12_PresenterCheckBox_XPath_Locator));
                IWebElement presenterCheckBox = base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_12_PresenterCheckBox_XPath_Locator);
                base.ClickByJavaScriptExecutor(presenterCheckBox);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                   StudentPrsentation_Page_SIM5_Sleep_Time));
                // Press Alt+F5
                base.PerformKeyDownThenPressKeyToElement(Keys.Alt, Keys.F5, 1);

                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                 StudentPrsentation_Page_SIM5_Sleep_Time));
                // click Advance to next slide twice 
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
               StudentPrsentation_Page_PPT_12_NextSlideButton_XPath_Locator));
                for (int i = 0; i < 2; i++)
                {
                    base.ClickButtonByXPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_PPT_12_NextSlideButton_XPath_Locator);
                    Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_Sleep_Time));
                }
                // click on the Make the Text larger Icon   
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_12_Font_XPath_Locator));
                base.ClickButtonByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_12_Font_XPath_Locator);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Sleep_Time));
                //click on "See all slides"     
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_12_AllSlides_XPath_Locator));
                base.ClickButtonByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_12_AllSlides_XPath_Locator);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Sleep_Time));
                //click Slide 1   
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_12_Slides1_XPath_Locator));
                base.ClickButtonByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_12_Slides1_XPath_Locator);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                 StudentPrsentation_Page_SIM5_Sleep_Time));
                // click on End slide show  
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_12_EndSlideShow_XPath_Locator));
                base.ClickButtonByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_12_EndSlideShow_XPath_Locator);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Sleep_Time));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("PowerPointSim5Activity", "AttemptPPTQuestion12",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// PPT question no.13 attempt.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        public void AttemptPPTQuestion13()
        {
            logger.LogMethodEntry("PowerPointSim5Activity", "AttemptPPTQuestion13",
          base.IsTakeScreenShotDuringEntryExit);

            try
            {
                this.IsQuestionLoaded("13");
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                //click on Insert Tab
                this.ClickOnElementByXpath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_InsertTab_Xpath_Locator);
                // click on Header and footer under Text group
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_13_HeaderButton_Xpath_Locator));
                // navigate to Notes and handouts
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_13_NotesTab_Xpath_Locator);
                // check Date and Time Option
                base.SelectCheckBoxById(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_13_DateTimeCheckBox_Xpath_Locator);
                // check footer check box
                base.SelectCheckBoxById(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_13_FooterCheckBox_Xpath_Locator);
                // Type "1A_KWT_Overview"
                base.FocusOnElementByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_13_FooterTextBox_Xpath_Locator);
                base.FillTextBoxByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_13_FooterTextBox_Xpath_Locator,
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_13_FooterTextBox_Value);
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                // click Apply to All
                IWebElement Applybutton = base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_13_AppyToAll_Xpath_Locator);
                base.PerformMouseClickAction(Applybutton);
                this.SwitchToLastOpenedWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("PowerPointSim5Activity", "AttemptPPTQuestion13",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// PPT question no.14 attempt.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        public void AttemptPPTQuestion14()
        {
            logger.LogMethodEntry("PowerPointSim5Activity", "AttemptPPTQuestion14",
          base.IsTakeScreenShotDuringEntryExit);

            try
            {
                this.IsQuestionLoaded("14");
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_PPT_InsertTab_Xpath_Locator));
                //click on Insert Tab
                IWebElement getInsertTabProperty = base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_PPT_InsertTab_Xpath_Locator);
                base.PerformMouseHoverAction(getInsertTabProperty);
                base.PerformClickAction(getInsertTabProperty);
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                // click on Header and footer under Text group      
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_13_HeaderButton_Xpath_Locator));
                // In slide tab click on slide Number checkbox          
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_14_SlideTab_Xpath_Locator);
                base.SelectCheckBoxById(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_14_SLideNoCheckBox_ID_Locator);
                //click on "dont show on title slide" check box          
                base.SelectCheckBoxById(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_14_TitleCheckBox_ID_Locator);
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                // click Apply to All
                IWebElement Applybutton = base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_13_AppyToAll_Xpath_Locator);
                base.PerformMouseClickAction(Applybutton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("PowerPointSim5Activity", "AttemptPPTQuestion14",
                       base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// PPT question no.15 attempt.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        public void AttemptPPTQuestion15()
        {
            logger.LogMethodEntry("PowerPointSim5Activity", "AttemptPPTQuestion15",
          base.IsTakeScreenShotDuringEntryExit);

            try
            {
                this.IsQuestionLoaded("15");
                this.IsPageLoading();
                NavigateToFileTabAndSelectParticularScreen();
                //click on 6 slides horizontal button
                ClickOnElementByXpath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_15__Slidehorizontal_Xpath_Locator);
                // click on print button
                IWebElement PrintButton = base.GetWebElementPropertiesById(
                 StudentPresentationPageResource.StudentPrsentation_Page_PPT_15_PrintButton_ID_Locator);
                base.ClickByJavaScriptExecutor(PrintButton);

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PowerPointSim5Activity", "AttemptPPTQuestion15",
                     base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To perform navigation.
        /// </summary>
        private void NavigateToFileTabAndSelectParticularScreen()
        {
            logger.LogMethodEntry("PowerPointSim5Activity", "NavigateToFileTabAndSelectParticularScreen",
            base.IsTakeScreenShotDuringEntryExit);
            //click on File Tab

            this.ClickOnElementByXpath(StudentPresentationPageResource.
            StudentPrsentation_Page_PPT_FileTab_Xpath_Locator);
            base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
            // click on print

            this.ClickOnElementByXpath(StudentPresentationPageResource.
            StudentPrsentation_Page_PPT_15_PrintOption_Xpath_Locator);
            base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
            // click ok 6 sides horizontal screen or click Full Page slides
            this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_SlideStyle_Xpath_Locator));
            IWebElement element = base.GetWebElementPropertiesByXPath(
            StudentPresentationPageResource.StudentPrsentation_Page_PPT_SlideStyle_Xpath_Locator);
            base.PerformMouseClickAction(element);
            logger.LogMethodExit("PowerPointSim5Activity", "NavigateToFileTabAndSelectParticularScreen",
                     base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// PPT question no.16 attempt.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        public void AttemptPPTQuestion16()
        {
            logger.LogMethodEntry("PowerPointSim5Activity", "AttemptPPTQuestion16",
            base.IsTakeScreenShotDuringEntryExit);

            try
            {
                this.IsQuestionLoaded("16");
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                NavigateToFileTabAndSelectParticularScreen();
                // click on Notes pages
                IWebElement Xelement = base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_16_NotesButton_Xpath_Locator);
                base.PerformMouseClickAction(Xelement);
                // click on slides text box and type 3
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Sleep_Time));
                base.FillTextBoxByXPath("//div[@class='editPagesToPrintWrap general-textbox accessible filemenu-manipulator']/input",
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_16_NotesInputButton_value);
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Sleep_Time));
                //click on Notes pages button
                this.IsElementDisplayedInUI(By.XPath("//div[@class='print-page-container relative-pos']/span/div/div/div/div/div/span/img"));
                IWebElement element = base.GetWebElementPropertiesByXPath("//div[@class='print-page-container relative-pos']/span/div/div/div/div/div/span/img");
                base.PerformMouseClickAction(element);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Sleep_Time));
                // in lower section select Frame slides
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_16_FrameSLidesButton_Xpath_Locator));
                IWebElement FrameEle = base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_16_FrameSLidesButton_Xpath_Locator);
                base.ClickByJavaScriptExecutor(FrameEle);
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                StudentPrsentation_Page_SIM5_Sleep_Time));
                bool checkElement = base.IsElementPresent(By.XPath("//div[@id='4']/div[2]/div[3]/div[6]/div[3]/div/div"));
                this.IsElementDisplayedInUI(By.XPath("//div[@id='4']/div[2]/div[3]/div[6]/div[3]/div/div"));
                //click on print
                IWebElement PrintButton = base.GetWebElementPropertiesById(StudentPresentationPageResource.
                    StudentPrsentation_Page_PPT_15_PrintButton_ID_Locator);
                base.ClickByJavaScriptExecutor(PrintButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("PowerPointSim5Activity", "AttemptPPTQuestion16",
                       base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// PPT question no.17 attempt.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        public void AttemptPPTQuestion17()
        {
            logger.LogMethodEntry("PowerPointSim5Activity", "AttemptPPTQuestion17",
          base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.IsQuestionLoaded("17");
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                this.IsPageLoading();
                //click on design Tab and click on slide size in Cusomize group
                this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.StudentPrsentation_Page_PPT_DesignTab_Xpath_Locator));
                IWebElement getDesignTabProperty = base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_PPT_DesignTab_Xpath_Locator);
                base.PerformFocusOnElementActionByXPath(StudentPresentationPageResource.StudentPrsentation_Page_PPT_DesignTab_Xpath_Locator);
                base.ClickByJavaScriptExecutor(getDesignTabProperty);
                this.IsElementDisplayedInUI(By.CssSelector(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_SlideToWait_Xpath_Locator));
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                    StudentPrsentation_Page_PPT_17_SlideSizeButton_Xpath_Locator);
                // select widescreen
                this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_PPT_17_SlidetypeButton_Xpath_Locator));
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                    StudentPrsentation_Page_PPT_17_SlidetypeButton_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("PowerPointSim5Activity", "AttemptPPTQuestion17",
                       base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// PPT question no.20 attempt.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        public void AttemptPPTQuestion20()
        {
            logger.LogMethodEntry("PowerPointSim5Activity", "AttemptPPTQuestion20",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.IsQuestionLoaded("20");
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                 StudentPrsentation_Page_SIM5_Sleep_Time));
                // click on slide 9 and press delete
                this.ClickOnElementByXpath(StudentPresentationPageResource.StudentPresentation_Page_PPT_Slide9_Value);
                //click on cut icon in clipboard
                this.ClickOnElementByXpath(".//*[@id='ribbon-tab-Home']/li[1]/span/span[1]/span/span[2]/span[1]/span");
                // move the Slide 4 to the slide 8 position
                this.ClickOnElementByXpath("//div[@id='2_PPTSlideThumbnails_SVM_013']/div[1]/div[2]/div/img");
                this.ClickOnElementByXpath(".//*[@id='ribbon-tab-Home']/li[1]/span/span[1]/span/span[2]/span[1]/span");
                this.ClickOnElementByXpath(".//*[@id='2_PPTSlideThumbnails_SVM_016']/div[1]/div[2]/div/img");
                this.ClickOnElementByXpath(".//*[@id='ribbon-tab-Home']/li[1]/span/span[1]/span/span[1]/div[1]/div[1]/div/div[1]");
                this.ClickOnElementByXpath(" .//*[@id='thumbnailPasteMenu']/div[1]/div/div[2]");
                this.ClickOnElementByXpath(".//*[@id='thumbnailPasteMenu']/div[2]/div[3]/div[1]");
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                 StudentPrsentation_Page_SIM5_Sleep_Time));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PowerPointSim5Activity", "AttemptPPTQuestion20",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// PPT question no.21 attempt.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        public void AttemptPPTQuestion21()
        {
            logger.LogMethodEntry("PowerPointSim5Activity", "AttemptPPTQuestion21",
                    base.IsTakeScreenShotDuringEntryExit);

            try
            {
                this.IsQuestionLoaded("21");
                this.IsPageLoading();
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                //click on Home Tab  and click on Replace button
                IWebElement pptHomeTab = base.GetWebElementPropertiesByCssSelector(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_HomeTab_CSSLocator);
                Thread.Sleep(4000);
                base.ClickByJavaScriptExecutor(pptHomeTab);
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_21_ReplaceButton_Xpath_Locator);

                // type Pike Market in Find what textbox
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_21_SearchText_Xpath_Locator);

                base.FillTextBoxByXPath(StudentPresentationPageResource.StudentPrsentation_Page_PPT_21_SearchText_Xpath_Locator,
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_21_SearchText_Value);
                //type Pike Place Market in Relplace with Text box
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_21_ReplaceText_Xpath_Locator);

                base.FillTextBoxByXPath(StudentPresentationPageResource.StudentPrsentation_Page_PPT_21_ReplaceText_Xpath_Locator,
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_21_ReplaceText_Value);
                //click on "Replace All"
                base.ClickButtonById(StudentPresentationPageResource.StudentPrsentation_Page_PPT_21_ReplaceAll_ID_Locator);
                // click on OK on message box and click on close
                base.ClickButtonById(StudentPresentationPageResource.StudentPrsentation_Page_PPT_OkButton_ID_Locator);
                base.ClickButtonById(StudentPresentationPageResource.StudentPrsentation_Page_PPT_21_CloseButton_ID_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PowerPointSim5Activity", "AttemptPPTQuestion21",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// PPT question no.22 attempt.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        public void AttemptPPTQuestion22()
        {
            logger.LogMethodEntry("PowerPointSim5Activity", "AttemptPPTQuestion22",
            base.IsTakeScreenShotDuringEntryExit);

            try
            {
                this.IsQuestionLoaded("22");
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                this.IsPageLoading();
                //click on design tab with slide 1

                this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_PPT_DesignTab_Xpath_Locator));
                IWebElement getDesignTabProperty = base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_PPT_DesignTab_Xpath_Locator);
                Thread.Sleep(3000);
                base.PerformFocusOnElementActionByXPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_PPT_DesignTab_Xpath_Locator);
                base.ClickByJavaScriptExecutor(getDesignTabProperty);
                Thread.Sleep(2000);
                // under variants group right click on third theme
                this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_22_Frame3_Xpath_Locator));
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_22_Frame3_Xpath_Locator));
                IWebElement Thirdelement = base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_22_Frame3_Xpath_Locator);
                Thread.Sleep(3000);
                base.PerformMouseRightClickAction(Thirdelement);
                Thread.Sleep(3000);
                // click on "Apply to selected slides"
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_22_ApplyToSelectedlSlidesButton_Xpath_Locator));
                IWebElement ApplyToselectedElement = base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_22_ApplyToSelectedlSlidesButton_Xpath_Locator);
                Thread.Sleep(3000);
                base.PerformMouseHoverByJavaScriptExecutor(ApplyToselectedElement);
                Actions builder = new Actions(WebDriver);
                builder.SendKeys(Keys.Enter).Perform();
                Thread.Sleep(10000);
                // under variants group right click on first theme 
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_22_Frame1_Xpath_Locator));
                IWebElement Firstelement = base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_22_Frame1_Xpath_Locator);
                Thread.Sleep(3000);
                base.PerformMouseRightClickAction(Firstelement);
                Thread.Sleep(3000);
                // click on "Apply to selected slides"
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_22_ApplyToSelectedlSlidesButton_Xpath_Locator));
                IWebElement ApplyToAllElement = base.GetWebElementPropertiesByXPath(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_22_ApplyToAllSlidesButton_Xpath_Locator);
                Thread.Sleep(3000);
                base.PerformMouseHoverByJavaScriptExecutor(ApplyToAllElement);
                builder.SendKeys(Keys.Enter).Perform();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("PowerPointSim5Activity", "AttemptPPTQuestion22",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// PPT question no.25 attempt.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        public void AttemptPPTQuestion25()
        {
            logger.LogMethodEntry("PowerPointSim5Activity", "AttemptPPTQuestion25",
            base.IsTakeScreenShotDuringEntryExit);

            try
            {
                this.IsQuestionLoaded("25");
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));

                // click on th paragraph present in left side of slide 5
                IWebElement Subtitle = base.GetWebElementPropertiesByCssSelector(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_25_Paragraph_CSSLocator);
                base.PerformMoveToElementClickAction(Subtitle);
                // on home page tab under paragrapth click on center button
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_HomeTab_Xpath_Locator);

                this.ClickOnElementByXpath(StudentPresentationPageResource.StudentPrsentation_Page_PPT_25_CenterAllign_Xpath_Locator);

                // click on slide 4
                this.ClickOnElementByXpath(StudentPresentationPageResource.StudentPresentation_Page_PPT_Slide4_Value);
                // click on slide title and press cntrl+E
                IWebElement title = base.GetWebElementPropertiesByXPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_TwentyFifthQuestion_TitleBox_Xpath_Locator);
                base.PerformMoveToElementClickAction(title);
                Actions builder = new Actions(WebDriver);
                builder.SendKeys("\u0005").Perform();
                base.SetImplicitWaitTime(Convert.ToInt32(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ImplicitWait_TimeOutValue));
                // click on sub title and press cntrl+E
                IWebElement Subtitlea = base.GetWebElementPropertiesByCssSelector(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_25_Paragraph_CSSLocator);
                base.PerformMoveToElementClickAction(Subtitlea);
                builder.SendKeys("\u0005").Perform();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("PowerPointSim5Activity", "AttemptPPTQuestion25",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// PPT question no.26 attempt.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        public void AttemptPPTQuestion26()
        {
            logger.LogMethodEntry("PowerPointSim5Activity", "AttemptPPTQuestion26",
            base.IsTakeScreenShotDuringEntryExit);

            try
            {
                this.IsQuestionLoaded("26");
                // click on paragraph on slide 5  
                this.ClickOnElementByXpath(StudentPresentationPageResource.StudentPresentation_Page_PPT_Slide5_Value);

                //select the paragrapth
                base.WaitForElement(By.ClassName(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_26_Title_ClassName_Locator));
                IWebElement Subtitlea = base.GetWebElementPropertiesByClassName(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_26_Title_ClassName_Locator);
                base.PerformMoveToElementClickAction(Subtitlea);
                //on home tab click on line spacing under paragraph group
                this.ClickOnElementByXpath(StudentPresentationPageResource.StudentPrsentation_Page_PPT_HomeTab_Xpath_Locator);
                this.ClickOnElementByXpath(StudentPresentationPageResource.StudentPrsentation_Page_PPT_26_LineSpacing_Xpath_Locator);

                //click on 2.0
                this.ClickOnElementByXpath(StudentPresentationPageResource.StudentPrsentation_Page_PPT_26_LineSpacingOption_Xpath_Locator);

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("PowerPointSim5Activity", "AttemptPPTQuestion26",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// PPT question no.27 attempt.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        public void AttemptPPTQuestion27()
        {
            logger.LogMethodEntry("PowerPointSim5Activity", "AttemptPPTQuestion27",
            base.IsTakeScreenShotDuringEntryExit);

            try
            {
                this.IsQuestionLoaded("27");
                this.IsPageLoading();
                // click on Layout under home tab with slide 1
                this.ClickOnElementByXpath(StudentPresentationPageResource.StudentPrsentation_Page_PPT_HomeTab_Xpath_Locator);
                this.ClickOnElementByXpath(StudentPresentationPageResource.StudentPrsentation_Page_PPT_27_Layout_Xpath_Locator);

                // Click on section header
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_27_SectionHeader_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("PowerPointSim5Activity", "AttemptPPTQuestion27",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// PPT question no.28 attempt.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        public void AttemptPPTQuestion28()
        {
            logger.LogMethodEntry("PowerPointSim5Activity", "AttemptPPTQuestion28",
            base.IsTakeScreenShotDuringEntryExit);

            try
            {
                this.IsQuestionLoaded("28");
                this.IsPageLoading();
                Actions builder = new Actions(WebDriver);
                // click on SLide sorter Icon in status bar
                base.ClickButtonByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_27_SlideSorter_Xpath_Locator);
                //Press delete on Slide 1 
                base.ClickButtonByXPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_27_Slide1_Xpath_Locator);
                builder.SendKeys(Keys.Delete).Perform();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("PowerPointSim5Activity", "AttemptPPTQuestion28",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// PPT question no.31 attempt.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        public void AttemptPPTQuestion31()
        {
            logger.LogMethodEntry("PowerPointSim5Activity", "AttemptPPTQuestion31",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.IsQuestionLoaded("31");
                this.IsPageLoading();
                //click on Transaction Tab and click on downward arrow under transaction this slide section
                this.ClickOnElementByXpath(StudentPresentationPageResource.StudentPrsentation_Page_PPT_TransactionTab_Xpath_Locator);


                this.ClickOnElementByXpath(StudentPresentationPageResource.
                    StudentPrsentation_Page_PPT_31_DownarrowButton_Xpath_Locator);

                // click on "fade" under subtitle

                this.ClickOnElementByXpath(StudentPresentationPageResource.
                    StudentPrsentation_Page_PPT_31_FadeButton_Xpath_Locator);


                this.ClickOnElementByXpath(StudentPresentationPageResource.
                    StudentPrsentation_Page_PPT_31_EffectOptions_Xpath_Locator);

                // click on apply to all under timing group

                this.ClickOnElementByXpath(StudentPresentationPageResource.
                    StudentPrsentation_Page_PPT_31_SmoothlyOptions_Xpath_Locator);


                this.ClickOnElementByXpath(StudentPresentationPageResource.
                    StudentPrsentation_Page_PPT_31_ApplyToAllOptions_Xpath_Locator);

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PowerPointSim5Activity", "AttemptPPTQuestion31",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// PPT question no.32 attempt.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        public void AttemptPPTQuestion32()
        {
            logger.LogMethodEntry("PowerPointSim5Activity", "AttemptPPTQuestion32",
            base.IsTakeScreenShotDuringEntryExit);

            try
            {
                this.IsQuestionLoaded("32");
                Actions builder = new Actions(WebDriver);
                // on transation tab click on duration up arrow under timing group twice till duration = 1.75
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByCssSelector(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_TransactionTab_CSSLocator));
                this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.StudentPrsentation_Page_SIM5_PPT_SlideToWait_Xpath_Locator));
                this.IsElementDisplayedInUI(By.Id(StudentPresentationPageResource.StudentPrsentation_Page_PPT_32_Upbutton_ID_Locator));
                IWebElement Applybutton = base.GetWebElementPropertiesById(
                StudentPresentationPageResource.StudentPrsentation_Page_PPT_32_Upbutton_ID_Locator);
                base.PerformMouseClickAction(Applybutton);
                base.PerformMouseClickAction(Applybutton);
                // click on apply to all under timing group
                ClickOnElementByXpath(
                 StudentPresentationPageResource.StudentPrsentation_Page_PPT_31_ApplyToAllOptions_Xpath_Locator);

                //click on slide show tool bar and click on Start from begining
                ClickOnElementByXpath(
                 StudentPresentationPageResource.StudentPrsentation_Page_PPT_SlideShowTab_Xpath_Locator);
                ClickOnElementByXpath(
                 StudentPresentationPageResource.StudentPrsentation_Page_PPT_11_FromBeginingButton_Xpath_Locator);
                Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                 StudentPrsentation_Page_SIM5_Sleep_Time));
                // press space bar to proceed to slide 2
                for (int i = 0; i < 7; i++)
                {

                    builder.SendKeys(Keys.Enter).Perform();
                    Thread.Sleep(Convert.ToInt32(StudentPresentationPageResource.
                     StudentPrsentation_Page_SIM5_Sleep_Time));
                }
                // Press Esc to return Normal view
                builder.SendKeys(Keys.Escape).Perform();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PowerPointSim5Activity", "AttemptPPTQuestion32",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// PPT question no.33 attempt.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        public void AttemptPPTQuestion33()
        {
            logger.LogMethodEntry("PowerPointSim5Activity", "AttemptPPTQuestion33",
           base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.IsQuestionLoaded("33");
                this.IsPageLoading();
                Actions builder = new Actions(WebDriver);
                // on status bar click on reading view icon
                this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_33_ReadingViewIcon_XPath_Locator));
                base.WaitForElement(By.XPath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_33_ReadingViewIcon_XPath_Locator));
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                StudentPrsentation_Page_PPT_33_ReadingViewIcon_XPath_Locator);
                this.IsElementDisplayedInUI(By.Id(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_ThirtyThirdQuestion_ReadViewSlide_Id_Locator));
                Thread.Sleep(10000);
                // press space bar to proceed to slide 2
                builder.SendKeys(Keys.Space).Perform();
                Thread.Sleep(3000);
                // press space bar to proceed to slide 3
                builder.SendKeys(Keys.Space).Perform();
                Thread.Sleep(3000);
                //Click on Normal view icon
                this.IsElementDisplayedInUI(By.XPath(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_Question33_NormalViewIcon_Xpath_Locator));
                this.ClickOnElementByXpath(StudentPresentationPageResource.
                    StudentPrsentation_Page_SIM5_PPT_Question33_NormalViewIcon_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("PowerPointSim5Activity", "AttemptPPTQuestion33",
                      base.IsTakeScreenShotDuringEntryExit);
        }
    }
}