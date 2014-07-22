using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.CourseCatalog;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class contains Details of Instructor Search Catalog
    /// </summary>
    public class CourseCatalogMainPage : BasePage
    {
        /// <summary>
        /// This is the logger
        /// </summary>
        private static readonly Logger Logger = Logger.
            GetInstance(typeof(CourseCatalogMainPage));

        /// <summary>
        /// This is the Assigned to Copy Interval Time
        /// </summary>
        static readonly int MinutesToWait = Int32.Parse(ConfigurationManager.
            AppSettings["AssignedToCopyInterval"]);


        /// <summary>
        /// Add Course From Instructor Search Catalog.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course by Type.</param>        
        public void AddCourseFromSearchCatalog(Course.CourseTypeEnum courseTypeEnum)
        {
            // Add Course From Instructor Search Catalog
            Logger.LogMethodEntry("CourseCatalogMainPage",
                "AddCourseFromSearchCatalog", base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Get Course from Memory
                Course course = Course.Get(courseTypeEnum);
                //Course Guid Name
                Guid courseGuidName = Guid.NewGuid();
                //Generate New Course Name Through Global Unique Identifier
                EnterInstructorCourseSearchCatalogParameter();
                // Wait and Click on Next button
                base.WaitForElement(By.CssSelector(CourseCatalogMainPageResource
                    .CourseCatalogMain_Page_NextButton_CssSelector_Locator));
                //Get Button Property
                IWebElement getButtonProperty = base.GetWebElementPropertiesByCssSelector
                    (CourseCatalogMainPageResource
                    .CourseCatalogMain_Page_NextButton_CssSelector_Locator);
                //Click on Next Button
                base.ClickByJavaScriptExecutor(getButtonProperty);
                //Purpose: Search Course In Instructor Catalog
                SearchCourseInInstructorCatalog(course.Name);
                // Check to verify the availibility of finish button
                CatalogFinishButtonAvailability(courseGuidName);
                switch (courseTypeEnum)
                {
                    case Course.CourseTypeEnum.MyItLabSIM5MasterCourse:
                    case Course.CourseTypeEnum.GraderITSIM5Course:
                        // Store MyItLab Instructor Course Name in Memory
                        StoreCourseInMemory(courseGuidName,
                            Course.CourseTypeEnum.MyItLabInstructorCourse);
                        break;
                    case Course.CourseTypeEnum.MySpanishLabMaster:
                        // Store HED Core Instructor Course Name in Memory
                        StoreCourseInMemory(courseGuidName, Course.CourseTypeEnum.
                            InstructorCourse);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseCatalogMainPage",
                "AddCourseFromSearchCatalog", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add Product From Instructor Search Catalog.
        /// </summary>
        /// <param name="productType">This is Product by Type.</param>
        public void AddProductFromSearchCatalog
            (Product.ProductTypeEnum productType)
        {
            // add course from instructor search catalog
            Logger.LogMethodEntry("CourseCatalogMainPage",
                "AddProductFromSearchCatalog", base.isTakeScreenShotDuringEntryExit);
            try
            {
                // get product from memory
                Product product = Product.Get(productType);
                //Program course Guid Name
                Guid programCourseGuidName = Guid.NewGuid();
                // generate new course name Guid
                switch (productType)
                {
                    case Product.ProductTypeEnum.MyITLabForOffice2013Program:
                        this.SearchCourseByTextBookName(product.Name);
                        break;
                    case Product.ProductTypeEnum.MyITLabForOffice2013General:
                        this.BrowseCourseByDiscipline();
                        break;
                }

                // click next button
                this.ClickOnNextButton();
                // search product in instructor catalog
                this.SearchCourseInInstructorCatalog(product.Name);
                // Check to verify the availibility of finish button
                CatalogFinishButtonAvailability(programCourseGuidName);
                // verify is Search Catalog Pop Up Closed
                if (base.IsPopUpClosed(2))
                {
                    // save course details in memory
                    this.StoreCourseInMemory(programCourseGuidName,
                        Course.CourseTypeEnum.MyITLabOffice2013Program);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseCatalogMainPage",
                "AddProductFromSearchCatalog", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search Course By Text Book Name In Catalog.
        /// </summary>
        /// <param name="productType">This is product type enum.</param>
        private void SearchCourseByTextBookName(string productName)
        {
            //Enter Catalog Search Parameter
            Logger.LogMethodEntry("CourseCatalogMainPage",
                "SearchCourseByTextBookName",
                base.isTakeScreenShotDuringEntryExit);
            // Click on the radio button
            base.WaitForElement(By.Id(CourseCatalogMainPageResource
                .CourseCatalogMain_ProductTextBook_TextBox_Id_Locator));
            // clear text box
            base.ClearTextByID(CourseCatalogMainPageResource
                .CourseCatalogMain_ProductTextBook_TextBox_Id_Locator);
            base.FillTextBoxByID(CourseCatalogMainPageResource
                .CourseCatalogMain_ProductTextBook_TextBox_Id_Locator, productName);
            Logger.LogMethodExit("CourseCatalogMainPage", "SearchCourseByTextBookName",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This method handle the Adding TestBank from Search Catalog.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        public void AddTestBankFromSearchCatalog
            (Course.CourseTypeEnum courseTypeEnum)
        {
            // Add Course From Instructor Search Catalog
            Logger.LogMethodEntry("CourseCatalogMainPage",
                "AddTestBankFromSearchCatalog", base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Get Course from Memory
                Course course = Course.Get(courseTypeEnum);
                //Course Guid Name
                Guid testBankGuidName = Guid.NewGuid();
                //Generate New Testbank Name Through Global Unique Identifier
                this.EnterInstructorCourseSearchCatalogParameter();
                // Wait and Click on Next button
                base.WaitForElement(By.CssSelector(CourseCatalogMainPageResource
                    .CourseCatalogMain_Page_NextButton_CssSelector_Locator));
                //Get Button Property of Next button
                IWebElement getButtonProperty = base.
                    GetWebElementPropertiesByCssSelector(CourseCatalogMainPageResource
                    .CourseCatalogMain_Page_NextButton_CssSelector_Locator);
                //Click on Next Button
                base.ClickByJavaScriptExecutor(getButtonProperty);
                //Search Course In Instructor Catalog to Add Testbank
                this.SearchCourseInCatalogToAddTestBank(course.Name);
                // Check to verify the availability of finish button
                this.CatalogFinishButtonAvailability(testBankGuidName);
                // Save TestBank Course Name in Memory
                this.StoreCourseInMemory(testBankGuidName, Course.
                    CourseTypeEnum.MyTestBankCourse);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseCatalogMainPage",
                "AddTestBankFromSearchCatalog", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search course in catalog and add as TestBank.
        /// </summary>
        /// <param name="courseName">This is name of course.</param>
        private void SearchCourseInCatalogToAddTestBank
            (string courseName)
        {
            //Logger Entry
            Logger.LogMethodEntry("CourseCatalogMainPage",
                "SearchCourseInCatalogToAddTestBank", base.isTakeScreenShotDuringEntryExit);
            //Wait for element 
            base.WaitForElement(By.Id(CourseCatalogMainPageResource
               .CourseCatalogMain_Page_SearchCatalog_Span_Id_Locator));
            //Start Stop Watch
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            //Setting Course Table Row
            int setCourseTableRow = 1;
            //Check if the course name is Visible
            this.HandlePagingToFindCourseNameOnCatalogPage(courseName);
            // Purpose: To Search the Course Through Each Table Row(s)
            while (stopWatch.Elapsed.Minutes < MinutesToWait)
            {
                string getCourseName = base.GetElementTextByXPath
                 (string.Format(CourseCatalogMainPageResource.
                 CourseCatalogMain_Page_GetCourse_Name_XPath_Locator, setCourseTableRow));
                if (getCourseName.Contains(courseName))
                {
                    //Click on Select TestBank button to create Testbank
                    this.ClickOnSelectTestBank(setCourseTableRow);
                    break;
                }
                setCourseTableRow = setCourseTableRow + 1;
            }
            stopWatch.Stop();

            //Logger Exist
            Logger.LogMethodExit("CourseCatalogMainPage",
            "SearchCourseInCatalogToAddTestBank", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Select TestBank button to create Testbank.
        /// </summary>
        /// <param name="setCourseTableRow">This is number of CourseTable row.</param>
        private void ClickOnSelectTestBank(int setCourseTableRow)
        {

            //Logger Entry
            Logger.LogMethodEntry("CourseCatalogMainPage",
                "ClickOnSelectTestBank", base.isTakeScreenShotDuringEntryExit);
            //Wait for element
            base.WaitForElement(By.XPath(string.Format(CourseCatalogMainPageResource.
                CourseCatalogMain_Page_SelectTestBank_Button_XPath_Locator,
                setCourseTableRow)));
            // Set focus on the course and click on select course
            base.FocusOnElementByXPath(string.Format(CourseCatalogMainPageResource.
                CourseCatalogMain_Page_SelectTestBank_Button_XPath_Locator,
                setCourseTableRow));
            //Get Select COurse Button Property
            IWebElement getSelectCourseButtonProperty = base.
                GetWebElementPropertiesByXPath(string.Format(
                CourseCatalogMainPageResource.
                CourseCatalogMain_Page_SelectTestBank_Button_XPath_Locator,
                setCourseTableRow));
            base.ClickByJavaScriptExecutor(getSelectCourseButtonProperty);
            //Logger Exist
            Logger.LogMethodExit("CourseCatalogMainPage",
                "ClickOnSelectTestBank", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Next Button.
        /// </summary>
        public void ClickOnNextButton()
        {
            //Click On Next Button
            Logger.LogMethodEntry("CourseCatalogMainPage",
                "ClickOnNextButton", base.isTakeScreenShotDuringEntryExit);
            try
            {
                // Wait and Click on Next button
                base.WaitForElement(By.CssSelector(CourseCatalogMainPageResource
                    .CourseCatalogMain_Page_NextButton_CssSelector_Locator));
                //Get Button Property
                IWebElement getButtonProperty = base.GetWebElementPropertiesByCssSelector
                    (CourseCatalogMainPageResource
                    .CourseCatalogMain_Page_NextButton_CssSelector_Locator);
                //Click on Button
                base.ClickByJavaScriptExecutor(getButtonProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseCatalogMainPage",
                "ClickOnNextButton", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Catalog Search Parameter For Program Course
        /// </summary>
        private void BrowseCourseByDiscipline()
        {
            //Enter Catalog Search Parameter
            Logger.LogMethodEntry("CourseCatalogMainPage",
                "BrowseCourseByDiscipline",
                base.isTakeScreenShotDuringEntryExit);
            // Click on the radio button
            base.WaitForElement(By.Id(CourseCatalogMainPageResource
                .CourseCatalogMain_Page_Discipline_RadioButton_Id_Locator));
            base.ClickButtonByID(CourseCatalogMainPageResource
                .CourseCatalogMain_Page_Discipline_RadioButton_Id_Locator);
            //Select Art option in the drop down value
            base.SelectDropDownValueThroughTextById(CourseCatalogMainPageResource
                    .CourseCatalogMain_Page_Discipline_DropDown_Id_Locator,
                CourseCatalogMainPageResource
                    .CourseCatalogMain_Page_Discipline_DropDown_Text_Value);
            Logger.LogMethodExit("CourseCatalogMainPage",
                "BrowseCourseByDiscipline",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Enter Catalog Search Parameter For Instructor Course
        /// </summary>
        private void EnterInstructorCourseSearchCatalogParameter()
        {
            //Enter Catalog Search Parameter
            Logger.LogMethodEntry("CourseCatalogMainPage",
                "EnterInstructorCourseSearchCatalogParameter",
               base.isTakeScreenShotDuringEntryExit);
            //Wait for element
            base.WaitForElement(By.Id(CourseCatalogMainPageResource
                .CourseCatalogMain_Page_ProductTextBook_TextBox_Id_Locator));
            base.ClearTextByID(CourseCatalogMainPageResource
                 .CourseCatalogMain_Page_ProductTextBook_TextBox_Id_Locator);
            //Enter the text book title to search
            base.FillTextBoxByID(CourseCatalogMainPageResource
                 .CourseCatalogMain_Page_ProductTextBook_TextBox_Id_Locator,
                 CourseCatalogMainPageResource.
                 CourseCatalogMain_Page_ProductTextBook_Name_value);
            Logger.LogMethodExit("CourseCatalogMainPage",
                "EnterInstructorCourseSearchCatalogParameter",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search Course on Each Page of Instructor Catalog
        /// </summary>
        /// <param name="productCourseName">This is Product Course Name</param>
        private void SearchCourseInInstructorCatalog
            (string productCourseName)
        {
            // search course in instructor catalog
            Logger.LogMethodEntry("CourseCatalogMainPage"
                , "SearchCourseInInstructorCatalog", base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(CourseCatalogMainPageResource
                .CourseCatalogMain_Page_SearchCatalog_Span_Id_Locator));
            // start stop watch
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            // set course grid row
            int setCourseTableRow = 1;
            // check if the course name is visible
            HandlePagingToFindCourseNameOnCatalogPage(productCourseName);
            // search the course in each rows
            while (stopWatch.Elapsed.Minutes < MinutesToWait)
            {
                string getCourseName = base.GetElementTextByXPath
                    (string.Format(CourseCatalogMainPageResource.
                    CourseCatalogMain_Page_GetCourse_Name_XPath_Locator, setCourseTableRow));
                if (getCourseName.Contains(productCourseName))
                {
                    base.WaitForElement(By.XPath(string.Format(CourseCatalogMainPageResource.
                        CourseCatalogMain_Page_SelectCourse_Button_XPath_Locator, setCourseTableRow)));
                    // set focus on the course and click on select course
                    base.PerformFocusOnElementActionByXPath(string.Format(CourseCatalogMainPageResource.
                        CourseCatalogMain_Page_SelectCourse_Button_XPath_Locator, setCourseTableRow));
                    // get select course button property
                    IWebElement getSelectCourseButtonProperty = base.GetWebElementPropertiesByXPath(
                        string.Format(CourseCatalogMainPageResource.
                        CourseCatalogMain_Page_SelectCourse_Button_XPath_Locator, setCourseTableRow));
                    base.ClickByJavaScriptExecutor(getSelectCourseButtonProperty);
                    break;
                }
                setCourseTableRow = setCourseTableRow + 1;
            }
            stopWatch.Stop();
            Logger.LogMethodExit("CourseCatalogMainPage"
                , "SearchCourseInInstructorCatalog", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Find the Course in Instructor Catalog and hadle paging.
        /// </summary>
        /// <param name="productCourseName">This is Product Course Name.</param>
        private void HandlePagingToFindCourseNameOnCatalogPage
            (string productCourseName)
        {
            // search and select course in catalog
            Logger.LogMethodEntry("CourseCatalogMainPage",
                "HandlePagingToFindCourseNameOnCatalogPage",
                base.isTakeScreenShotDuringEntryExit);
            // wait for catalog loads
            Thread.Sleep(Convert.ToInt32(CourseCatalogMainPageResource.
                    CourseCatalogMain_Page_Thread_SleepTime_Value_Paging_NextLink));
            base.WaitForElement(By.Id(CourseCatalogMainPageResource.
                CourseCatalogMain_Page_SearchCatalog_Span_Id_Locator));
            // validate page number present or not 
            if (base.IsElementDisplayedByID(CourseCatalogMainPageResource.
                CourseCatalogMain_Page_Total_Pages_Id_Locator))
            {
                // get page count
                int getTotalPageCount = Convert.ToInt16(base.
                    GetElementTextByID(CourseCatalogMainPageResource.
                    CourseCatalogMain_Page_Total_Pages_Id_Locator));
                // check if the course name is visible on the page
                for (int pageCount = Convert.ToInt16(CourseCatalogMainPageResource.
                    CourseCatalogMain_Page_Frame_First_Index);
                    pageCount <= getTotalPageCount; pageCount++)
                {
                    // check if the course name s present
                    if (base.IsElementContainsTextById(CourseCatalogMainPageResource.
                        CourseCatalogMain_Page_SearchCatalog_Span_Id_Locator, productCourseName))
                    {
                        break;
                    }
                    // click on the "Next>>" link
                    this.ClickOnNextLink();
                    // wait for course grid on next page
                    base.WaitForElement(By.Id(CourseCatalogMainPageResource.
                        CourseCatalogMain_Page_SearchCatalog_Span_Id_Locator));
                }
            }
            Logger.LogMethodExit("CourseCatalogMainPage",
                "HandlePagingToFindCourseNameOnCatalogPage",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the "Next>>" Link.
        /// </summary>
        private void ClickOnNextLink()
        {
            //Click on the "Next>>" Link.
            Logger.LogMethodEntry("CourseCatalogMainPage", "ClickOnNextLink",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(CourseCatalogMainPageResource.
                CourseCatalogMain_Page_Paging_NextLink_Id_Locator));
            //Get Button Property.
            IWebElement getLinkProperty = base.GetWebElementPropertiesById
                (CourseCatalogMainPageResource.
                CourseCatalogMain_Page_Paging_NextLink_Id_Locator);
            base.ClickByJavaScriptExecutor(getLinkProperty);
            //Halt Execution for 15 Seconds.
            Thread.Sleep(Convert.ToInt32(CourseCatalogMainPageResource.
                CourseCatalogMain_Page_Thread_SleepTime_Value_Paging_NextLink));
            Logger.LogMethodExit("CourseCatalogMainPage", "ClickOnNextLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Purpose: To Verify the Mail Error on the Catalog Light Box.
        /// </summary>
        private void InstructorCatalogCourseMailErrorDisappeared()
        {
            // Search Catalog Course Mail Error
            Logger.LogMethodEntry("CourseCatalogMainPage",
                "InstructorCatalogCourseMailErrorDisappeared"
                , base.isTakeScreenShotDuringEntryExit);
            // Check the mail server error on the catalog page 
            if (base.IsElementPresent(By.ClassName(CourseCatalogMainPageResource.
                CourseCatalogMain_Page_MessageBoard_Text_ClassName_Locator),
                Convert.ToInt32(CourseCatalogMainPageResource
                .CourseCatalogMain_Page_WaitTime_MailServerError_Value)))
            {
                IWebElement courseMailErrorText = base.GetWebElementPropertiesByClassName
                    (CourseCatalogMainPageResource.
                        CourseCatalogMain_Page_MessageBoard_Text_ClassName_Locator);
                //Check the Error Message After Click on the Finish Button
                if (courseMailErrorText.Text.Contains(CourseCatalogMainPageResource.
                    CourseCatalogMain_Page_MessageBoard_Text_Value))
                {
                    //Click on the cancel button on lightbox to eleiminate it
                    base.WaitForElement(By.CssSelector(CourseCatalogMainPageResource
                        .CourseCatalogMain_Page_Cancel_Button_CssSelector_Locator));
                    //Click on Button
                    base.ClickButtonByCssSelector(CourseCatalogMainPageResource
                        .CourseCatalogMain_Page_Cancel_Button_CssSelector_Locator);
                    Thread.Sleep(Convert.ToInt32(CourseCatalogMainPageResource.
                        CourseCatalogMain_Page_Thread_SleepTime_AfterCancelButton));
                    base.SwitchToDefaultPageContent();
                    //Select Window
                    base.SelectWindow(CourseCatalogMainPageResource
                        .CourseCatalogMain_Page_Window_Title_Page);
                    //Refresh The Page
                    new HEDGlobalHomePage().RefreshTheGlobalHomePage();
                }
                else
                {
                    // in case light box does not contain mail server error
                    base.SwitchToDefaultPageContent();
                    base.SelectWindow(CourseCatalogMainPageResource
                        .CourseCatalogMain_Page_Window_Title_Page);
                }
                Logger.LogMethodExit("CourseCatalogMainPage",
                    "InstructorCatalogCourseMailErrorDisappeared"
                    , base.isTakeScreenShotDuringEntryExit);
            }
        }

        /// <summary>
        /// Switching to Search Catalog frame
        /// </summary>
        public void SwitchToCatalogIFrame()
        {
            //Switching to the Search Catalog Iframe
            Logger.LogMethodEntry("CourseCatalogMainPage", "SwitchToCatalogIFrame",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                // Waiting for the Search Catalog Frame
                base.WaitForElement(By.XPath(CourseCatalogMainPageResource
                    .CourseCatalogMain_Page_CatalogFrame_XPath_Locator));
                //Switch to Search Catalog Iframe
                base.SwitchToIFrameByWebElement(
                    base.GetWebElementPropertiesByXPath(CourseCatalogMainPageResource.
                    CourseCatalogMain_Page_CatalogFrame_XPath_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseCatalogMainPage", "SwitchToCatalogIFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This method is to check the finish button availability on catalog frame
        /// </summary>
        /// <param name="newHedCourseName">This is the Guid name of HED course</param>
        private void CatalogFinishButtonAvailability(Guid newHedCourseName)
        {
            // Catalog Finish Button Still Present After Clicks on Finish Button
            Logger.LogMethodEntry("CourseCatalogMainPage", "CatalogFinishButtonAvailability"
                , base.isTakeScreenShotDuringEntryExit);
            // Enter instructor course/program course name and description
            base.WaitForElement(By.Id(CourseCatalogMainPageResource.
                CourseCatalogMain_Page_ProductName_TextBox_Id_Locator));
            base.ClearTextByID(CourseCatalogMainPageResource.
                CourseCatalogMain_Page_ProductName_TextBox_Id_Locator);
            //Insert Course Name in Text Box
            base.FillTextBoxByID(CourseCatalogMainPageResource.
                CourseCatalogMain_Page_ProductName_TextBox_Id_Locator,
                                 newHedCourseName.ToString());
            //Enter Description of INS course / Program course
            base.WaitForElement(By.Id(CourseCatalogMainPageResource.
                CourseCatalogMain_Page_ProductDescription_TextBox_Id_Locator));
            //Clear Text Box
            base.ClearTextByID(CourseCatalogMainPageResource.
                CourseCatalogMain_Page_ProductDescription_TextBox_Id_Locator);
            base.FillTextBoxByID(
                CourseCatalogMainPageResource.
                CourseCatalogMain_Page_ProductDescription_TextBox_Id_Locator,
                CourseCatalogMainPageResource.
                CourseCatalogMain_Page_ProductDescription_TextBox_Value);
            //Wait For Element
            base.WaitForElement(By.Id(CourseCatalogMainPageResource.
                CourseCatalogMain_Page_Finish_Button_Id_Locator));
            //Get Button Property
            IWebElement getButtonProperty = base.GetWebElementPropertiesById
                (CourseCatalogMainPageResource.
                CourseCatalogMain_Page_Finish_Button_Id_Locator);
            //Click on Button
            base.ClickByJavaScriptExecutor(getButtonProperty);
            //Verify Course Mail Error Exists
            InstructorCatalogCourseMailErrorDisappeared();
            Logger.LogMethodExit("CourseCatalogMainPage", "CatalogFinishButtonAvailability",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To Save Product Course in memory against Hed Product Course Type
        /// </summary>
        /// <param name="courseGuid">This is Course Name Guid by Guid</param>
        /// <param name="courseTypeEnum">This is Hed Course by Type</param>
        private void StoreCourseInMemory(Guid courseGuid,
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Save Product  Course in Memory
            Logger.LogMethodEntry("CourseCatalogMainPage", "StoreCourseInMemory"
                , base.isTakeScreenShotDuringEntryExit);
            Course hedProductCourse;
            hedProductCourse = new Course
            {
                //Store Course Details
                Name = courseGuid.ToString(),
                CourseType = courseTypeEnum,
                IsCreated = true,
            };
            hedProductCourse.StoreCourseInMemory();
            Logger.LogMethodExit("CourseCatalogMainPage", "StoreCourseInMemory"
                , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Search Parameter In Catalog.
        /// </summary>
        /// <param name="searchParameter">This is Search Parameter.</param>
        public void EnterSearchParameterInCatalog(String searchParameter)
        {
            //Enter Search Parameter In Catalog
            Logger.LogMethodEntry("CourseCatalogMainPage", "EnterSearchParameterInCatalog"
                , base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for element
                base.WaitForElement(By.Id(CourseCatalogMainPageResource.
                    CourseCatalogMain_Page_ProductTextBook_TextBox_Id_Locator));
                base.ClearTextByID(CourseCatalogMainPageResource.
                    CourseCatalogMain_Page_ProductTextBook_TextBox_Id_Locator);
                //Fill Search Parameter
                base.FillTextBoxByID(CourseCatalogMainPageResource
                    .CourseCatalogMain_Page_ProductTextBook_TextBox_Id_Locator,
                    searchParameter);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseCatalogMainPage", "EnterSearchParameterInCatalog"
                , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Message In Search Catalog.
        /// </summary>
        /// <returns>Message.</returns>
        public String GetMessageInSearchCatalog()
        {
            //Get Message In Search Catalog
            Logger.LogMethodEntry("CourseCatalogMainPage", "GetMessageInSearchCatalog"
                 , base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getMessage = string.Empty;
            try
            {
                base.WaitForElement(By.Id(CourseCatalogMainPageResource.
                        CourseCatalogMain_Page_NorecordMessage_Value));
                //Get message
                getMessage = base.GetElementTextByID(CourseCatalogMainPageResource.
                    CourseCatalogMain_Page_NorecordMessage_Value);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseCatalogMainPage", "GetMessageInSearchCatalog"
                , base.isTakeScreenShotDuringEntryExit);
            return getMessage;
        }
    }
}
