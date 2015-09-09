#region
using System;
using System.Threading;
using Pearson.Pegasus.TestAutomation.Frameworks;
using System.Configuration;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using System.Diagnostics;
using Pegasus.Automation;
using Pegasus.Automation.DataTransferObjects;
#endregion


namespace Pegasus.Pages.UI_Pages.SSRSReports
{
    /// <summary>
    /// This Class Contains The Details Of Folder Page.
    /// </summary>
    public class FolderPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(FolderPage));

        /// <summary>
        /// Get the windown Name
        /// </summary>
        /// <returns>Returns the window name</returns>
        public string getWindowName()
        {
            Logger.LogMethodEntry("FolderPage", "getWindowName",
                            IsTakeScreenShotDuringEntryExit);
            string getwindowName = "Fail";
            try
            {
                getwindowName = base.GetPageTitle;
            }
            catch(Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("FolderPage", "getWindowName",
                IsTakeScreenShotDuringEntryExit);
            return getwindowName;
        }

        /// <summary>
        /// Verify the Report Link is present
        /// </summary>
        /// <param name="reportName">This is name of the report</param>
        /// <returns></returns>
        public Boolean verifyReportLinkPresent(string reportName)
        {
            Logger.LogMethodEntry("FolderPage", "verifyReportLinkPresent", 
                IsTakeScreenShotDuringEntryExit);
            bool isReportLinkPresent = false;
            try
            {
                //Get count of the report links
                int reportCount = base.GetElementCountByXPath(
                FolderPageResource.FolderPage_Folders_Count);
                for (int i = 1; i <= reportCount; i++)
                {
                    //Verify if report is present
                    isReportLinkPresent = base.IsElementPresent(By.PartialLinkText(reportName), 10);
                    if (isReportLinkPresent) break;
                }
            }
            catch(Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("FolderPage", "verifyReportLinkPresent", 
                IsTakeScreenShotDuringEntryExit);
            return isReportLinkPresent;
        }

        /// <summary>
        /// Select the Report by Name
        /// </summary>
        /// <param name="reportName">This is the report name</param>
        public void SelectReport(string reportName)
        {
            Logger.LogMethodEntry("FolderPage", "SelectReport",
                IsTakeScreenShotDuringEntryExit);
            try
            {
                Thread.Sleep(2000);
                base.GetWebElementPropertiesByPartialLinkText(reportName);
                base.ClickLinkByPartialLinkText(reportName);
            }
            catch(Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("FolderPage", "SelectReport",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Generate the SSRS report
        /// </summary>
        /// <param name="reportName">this is the Report Name</param>
        public string generateReport(string reportName)
        {
            Logger.LogMethodEntry("FolderPage", "generateReport",
                IsTakeScreenShotDuringEntryExit);
            string reportGenerated = "Fail";
            try
            {
                switch (reportName)
                {
                    case "MIL3xUsersReport":
                        reportGenerated = this.generateMIL3XUserReport();
                        break;
                    case "HED5xPMCUserDetails":
                        reportGenerated = this.generateHED5xPMCUserDetails(reportName);
                        break;
                    case "WVU Report":
                        reportGenerated = this.generateWVUReport();
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("FolderPage", "generateReport",
                IsTakeScreenShotDuringEntryExit);
            return reportGenerated;
        }

        /// <summary>
        /// Generate the MIL3XUser Report
        /// </summary>
        private string generateMIL3XUserReport()
        {
            //Generate the report
            Logger.LogMethodEntry("FolderPage", "generateMIL3XUserReport",
                IsTakeScreenShotDuringEntryExit);
            string reportGenerated = "Fail";
            //Get user id from memory
            User user = User.Get(User.UserTypeEnum.MIL3xUser);
            string getuserID = user.UserId.ToString();
            //Get User ID element locator
            base.GetWebElementPropertiesById(string.Format(
                FolderPageResource.FolderPage_MIL3XUserID_Id_Locator));
            //Clear USer ID text field
            base.ClearTextById(FolderPageResource.
                FolderPage_MIL3XUserID_Id_Locator);
            //Add User ID to text field
            base.FillTextBoxById(FolderPageResource.
                FolderPage_MIL3XUserID_Id_Locator, getuserID);
            //Click the View Report button
            bool reportLoaded = this.clickViewReport();
            if (reportLoaded == false)
            {
                reportGenerated = "Success";
            }
            Logger.LogMethodExit("FolderPage", "generateMIL3XUserReport",
                IsTakeScreenShotDuringEntryExit);
            return reportGenerated;
        }

        /// <summary>
        /// Generate the HED5xPMCUserDetails Report
        /// </summary>
        private string generateHED5xPMCUserDetails(string reportName)
        {
            //Generate the report
            Logger.LogMethodEntry("FolderPage", "generateHED5xPMCUserDetails",
                IsTakeScreenShotDuringEntryExit);
            string reportGenerated = "Fail";
            string reportVerified = "Fail";
            //Get PMC id from memory
            Course course = Course.Get(Course.CourseTypeEnum.HED5xPMC);
            string getCourseID = course.PegasusCourseId.ToString();
            //Get PMC ID element Locator
            base.GetWebElementPropertiesById(string.Format(
                FolderPageResource.FolderPage_HED5xPMC_Id_Locator));
            //Clear PMC ID text field
            base.ClearTextById(FolderPageResource.
                FolderPage_HED5xPMC_Id_Locator);
            //Add PMC ID to the text field
            base.FillTextBoxById(FolderPageResource.
                FolderPage_HED5xPMC_Id_Locator, getCourseID);
            //Uncheck Start date
            IWebElement startDate = base.GetWebElementPropertiesById(FolderPageResource.
                FolderPage_HED5xPMC_StartDate_Id_Locator);
            base.ClickByJavaScriptExecutor(startDate);
            //Uncheck End date
            IWebElement endDate = base.GetWebElementPropertiesById(FolderPageResource.
                FolderPage_HED5xPMC_EndDate_Id_Locator);
            base.ClickByJavaScriptExecutor(endDate);
            string[] role;
            role = new string[2] {"Student", "Instructor"};
            //Get count of role
            int roleCount = base.GetElementCountByCssSelector(
                FolderPageResource.FolderPage_HED5xPMC_Role_DropDown_CSSSelector_Locator);
            for (int i = 0; i < roleCount; i++)
            {
                base.SelectDropDownValueThroughTextByCssSelector(FolderPageResource.
                    FolderPage_HED5xPMC_Role_DropDownValue_CSSSelector_Locator, role[i]);
                //Click the View Report button
                bool reportLoaded = this.clickViewReport();
                reportVerified = this.verifyHED5xPMCUserDetails(reportName);
                if (reportLoaded == false && reportVerified != "Fail")
                {
                    reportGenerated = "Success";
                }
                
            }
            Logger.LogMethodExit("FolderPage", "generateHED5xPMCUserDetails",
                IsTakeScreenShotDuringEntryExit);
            return reportGenerated;
        }

        /// <summary>
        /// Generate the WVU Report
        /// </summary>
        private string generateWVUReport()
        {
            //Generate the report
            Logger.LogMethodEntry("FolderPage", "generateWVUReport",
                IsTakeScreenShotDuringEntryExit);
            string reportGenerated = "Fail";
            //Get course details from memory
            Course courseWVU = Course.Get(Course.CourseTypeEnum.WVUCourse);
            string WVUcourseId = courseWVU.PegasusCourseId.ToString();
            //Get Course ID Text Box Property
            base.GetWebElementPropertiesById(FolderPageResource.
                FolderPage_WVUReport_CourseID_Id_Locator);
            //Clear the text box
            base.ClearTextById(FolderPageResource.
                FolderPage_WVUReport_CourseID_Id_Locator);
            //Add the Course ID
            base.FillTextBoxById(FolderPageResource.
                FolderPage_WVUReport_CourseID_Id_Locator, WVUcourseId);

            //Add Start Date
            DateTime dateTime = DateTime.Today;
            //Convert date and time to string
            string getstartDateTime = dateTime.AddDays(-365).ToString();
            //Split Date and Time
            string startTime = getstartDateTime.Split(' ')[1];
            string startDate = getstartDateTime.Split(' ')[0];

            //Get Start Date textbox
            base.GetWebElementPropertiesById(FolderPageResource.
                FolderPage_WVUReport_StartDate_TextBox_Id_Locator);
            //Clear text
            base.ClearTextById(FolderPageResource.
                FolderPage_WVUReport_StartDate_TextBox_Id_Locator);
            //Add Start Date 
            base.FillTextBoxById(FolderPageResource.
                FolderPage_WVUReport_StartDate_TextBox_Id_Locator, startDate);
            
            //Add End Date
            string getendDateTime = dateTime.ToString();
            string endTime = getendDateTime.Split(' ')[1];
            string endDate = getendDateTime.Split(' ')[0];

            //Get End Date textbox
            base.GetWebElementPropertiesById(FolderPageResource.
                FolderPage_WVUReport_EndDate_TextBox_Id_Locator);
            //Clear text
            base.ClearTextById(FolderPageResource.
                FolderPage_WVUReport_EndDate_TextBox_Id_Locator);
            //Add Start Date 
            base.FillTextBoxById(FolderPageResource.
                FolderPage_WVUReport_EndDate_TextBox_Id_Locator, endDate);
            //Click View Report button
            bool reportLoaded = this.clickViewReport();
            if (reportLoaded == false)
            {
                reportGenerated = "Success";
            }
            Logger.LogMethodExit("FolderPage", "generateWVUReport",
                IsTakeScreenShotDuringEntryExit);
            return reportGenerated;
        }

        /// <summary>
        /// Click View Report button to generate the report
        /// </summary>
        private Boolean clickViewReport()
        {
            Logger.LogMethodEntry("FolderPage", "clickViewReport",
                IsTakeScreenShotDuringEntryExit);
            //Wait for the View Report button
            base.WaitForElement(By.Id(string.Format(FolderPageResource.
                FolderPage_ViewReport_Button_Id_Locator)), 10);
            //Get the View Report button
            IWebElement getViewReportButton = base.GetWebElementPropertiesById(
                string.Format(FolderPageResource.FolderPage_ViewReport_Button_Id_Locator));
            //Click the View Report button
            base.ClickByJavaScriptExecutor(getViewReportButton);
            base.WaitUntilWindowLoads(base.GetPageTitle);
            bool reportloaded = true;
            Thread.Sleep(2000);
            //Verify report page is completely loaded
            while(reportloaded)
            {
                reportloaded = this.verifyReportIsLoaded();
            }
            Logger.LogMethodExit("FolderPage", "clickViewReport",
                IsTakeScreenShotDuringEntryExit);
            return reportloaded;
        }

        /// <summary>
        /// Verify the report is generated successfully
        /// </summary>
        /// <param name="reportName">This is the report name</param>
        public string verifygeneratedReport(string reportName)
        {
            Logger.LogMethodEntry("FolderPage", "verifygeneratedReport",
                IsTakeScreenShotDuringEntryExit);
            string reportVerified = "Fail";
            try
            {
                switch (reportName)
                {
                    case "MIL3xUsersReport":
                        reportVerified = this.verifyMIL3XUserReport();
                        break;
                    case "WVU Report":
                        reportVerified = this.verifyWVUReport();
                        break;
                }
            }
            catch(Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("FolderPage", "verifygeneratedReport",
                IsTakeScreenShotDuringEntryExit);
            return reportVerified;
        }

        /// <summary>
        /// Verify the MIL3XUser Report
        /// </summary>
        private string verifyMIL3XUserReport()
        {
            Logger.LogMethodEntry("FolderPage", "verifyMIL3XUserReport",
                IsTakeScreenShotDuringEntryExit);
            string isReportGenerated = "Fail";
            base.WaitUntilWindowLoads(base.GetPageTitle);
            User user = User.Get(User.UserTypeEnum.MIL3xUser);
            string firstName = user.FirstName.ToString();
            string lastName = user.LastName.ToString();
            string emailID = user.Email.ToString();
            string userName = user.Name.ToString();
            string source = base.GetPageSource();
            if (source.Contains(firstName) && source.Contains(lastName) && source.Contains(emailID) && source.Contains(userName))
            {
                isReportGenerated = "Success"; 
            }
            Logger.LogMethodExit("FolderPage", "verifyMIL3XUserReport",
                IsTakeScreenShotDuringEntryExit);
            return isReportGenerated;
        }

        /// <summary>
        /// Verify the HED5xPMCUserDetails Report
        /// </summary>
        private string verifyHED5xPMCUserDetails(string reportName)
        {
            Logger.LogMethodEntry("FolderPage", "verifyHED5xPMCUserDetails",
                IsTakeScreenShotDuringEntryExit);
            string isReportGenerated = "Fail";
            base.WaitUntilWindowLoads(base.GetPageTitle);
            //Get Course details from memory
            Course course = Course.Get(Course.CourseTypeEnum.HED5xPMC);
            string descipline = course.Desciplines.ToString();
            string PMCTitle = course.Name.ToString();
            
            //Get User details from memory
            User pmcUser = User.Get(User.UserTypeEnum.HED5xPMCUser);
            string userID = pmcUser.UserId.ToString();
            string firstName = pmcUser.FirstName.ToString();
            string lastName = pmcUser.LastName.ToString();
            string userName = pmcUser.Name.ToString();
            string emailID = pmcUser.Email.ToString();
            string smsUserID = pmcUser.SMSUserID.ToString();

            string source = base.GetPageSource();

            if (source.Contains(descipline) && source.Contains(PMCTitle) &&
                source.Contains(userID) && source.Contains(firstName) && source.Contains(lastName)
                && source.Contains(userName) && source.Contains(emailID) && source.Contains(smsUserID))
            {
                isReportGenerated = "Success";
            }
            Logger.LogMethodExit("FolderPage", "verifyHED5xPMCUserDetails",
                IsTakeScreenShotDuringEntryExit);
            return isReportGenerated;
        }

        /// <summary>
        /// Verify the WVU Report
        /// </summary>
        private string verifyWVUReport()
        {
            //Verify the generated WVU Report
            Logger.LogMethodEntry("FolderPage", "verifyWVUReport",
                IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(base.GetPageTitle);
            string isReportGenerated = "Fail";
            //Get course details from memory
            Course courseWVU = Course.Get(Course.CourseTypeEnum.WVUCourse);
            string WVUSMScourseId = courseWVU.SMSCourseId.ToString();
            string WVUCourseTitle = courseWVU.Name.ToString();

            //Get user details from memory
            User userWVU = User.Get(User.UserTypeEnum.WVUUser);
            string firstName = userWVU.FirstName.ToString();
            string lastName = userWVU.LastName.ToString();
            
            string source = base.GetPageSource();

            if (source.Contains(WVUSMScourseId) && source.Contains(WVUCourseTitle) && source.Contains(firstName) && source.Contains(lastName))
            {
                isReportGenerated = "Success";
            }

            Logger.LogMethodExit("FolderPage", "verifyWVUReport",
                IsTakeScreenShotDuringEntryExit);
            return isReportGenerated;
        }

        /// <summary>
        /// Verify if report is loaded
        /// </summary>
        /// <returns>Returns false if report is loaded</returns>
        private Boolean verifyReportIsLoaded()
        {
            //Verify if report is loaded
            Logger.LogMethodEntry("FolderPage", "verifyReportIsLoaded",
                IsTakeScreenShotDuringEntryExit);
            bool isReportLoaded = base.IsSSRSThinkingIndicatorLoading();
            Thread.Sleep(5000);
            Logger.LogMethodExit("FolderPage", "verifyReportIsLoaded",
               IsTakeScreenShotDuringEntryExit);
            return isReportLoaded;
        }
    }
}
