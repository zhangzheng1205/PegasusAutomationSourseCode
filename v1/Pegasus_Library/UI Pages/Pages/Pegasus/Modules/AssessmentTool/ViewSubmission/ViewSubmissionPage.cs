using System;
using System.Globalization;
using System.Windows.Forms;
using Framework.Common;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Activity;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.AssessmentTool.ViewSubmission
{
    public class ViewSubmissionPage : BasePage
    {
        //grade integer to be used in below functions
        private int _grade = 60;
        private string gradestoBeEntered;
        //Purpose: To Open The View Submission Page
        public void OpenActivityViewSubmissionPage()
        {
            try
            {

                GenericHelper.WaitUtilWindow("View Submission");
                GenericHelper.SelectWindow("View Submission");
                if (GenericHelper.IsElementPresent(By.Id("_ctl0_PopupPageContent_ucSubmissionList_LnkHideUnsubmitted")))
                {
                    WebDriver.FindElement(By.Id("_ctl0_PopupPageContent_ucSubmissionList_LnkHideUnsubmitted")).Click();
                }
                Thread.Sleep(10000);
                if (GenericHelper.IsElementPresent(By.XPath("//img[contains(@src,'ViewSubmission/expand.png')]")))
                {
                    WebDriver.FindElement(By.XPath("//img[contains(@src,'ViewSubmission/expand.png')]")).Click();
                }
                GenericHelper.WaitUntilElement(By.XPath("//div[@id='_ctl0_PopupPageContent_ucSubmissionList_gtStudents_items']/span/div"));
                WebDriver.FindElement(By.XPath("//div[@id='_ctl0_PopupPageContent_ucSubmissionList_gtStudents_items']/span/div")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: To Place The Cursor on Comments in First Editor
        public void EnterCommentsAndPlaceCursorInFirstEditor()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.Id("_ctl0_PopupPageContent_submissionDetailMaster__ctl1__VSEditor_0"));
                WebDriver.SwitchTo().Frame("_ctl0_PopupPageContent_submissionDetailMaster__ctl1__VSEditor_0");
                GenericHelper.WaitUntilElement(By.XPath("//html/body"));
                IWebElement studentComment = WebDriver.FindElement(By.XPath("//html/body"));
                var builder = new Actions(WebDriver);
                WebDriver.FindElement(By.XPath("//html/body")).SendKeys("Instructor Comment1");
                //    WebDriver.SwitchTo().DefaultContent();
                builder.MoveToElement(studentComment).ClickAndHold().Perform();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //purpose :To give submission through teacher
        public void GiveSubmissionByTeacher(string userType)
        {
            try
            {
                //Purpose : To give manaul grading by TA

                GenericHelper.WaitUntilElement(By.Id("_ctl0_PopupPageContent_SubmissionHeaderMaster_InstructorHeader_chkGrade"));
                if (WebDriver.FindElement(By.Id("_ctl0_PopupPageContent_SubmissionHeaderMaster_InstructorHeader_chkGrade")).Selected)
                {
                    GenericHelper.Logs("Grades are already submitted by the TA", "Passed");
                    WebDriver.FindElement(By.Id("_ctl0_PopupPageContent_SubmissionHeaderMaster_InstructorHeader_chkGrade")).Click();
                    if (GenericHelper.IsWindowPresent("Pegasus"))
                    {
                        GenericHelper.SelectWindow("Pegasus");
                        GenericHelper.WaitUntilElement(By.Id("chkWarning"));
                        WebDriver.FindElement(By.Id("chkWarning")).Click();
                        WebDriver.FindElement(By.CssSelector("span > span")).Click();
                    }
                    GenericHelper.SelectWindow("View Submission");
                }
                GenericHelper.WaitUntilElement(By.ClassName("VSGradetxt_box_1"));
                WebDriver.FindElement(By.ClassName("VSGradetxt_box_1")).Click();
                WebDriver.FindElement(By.ClassName("VSGradetxt_box_1")).Clear();
                WebDriver.FindElement(By.ClassName("VSGradetxt_box_1")).SendKeys("2");
                GenericHelper.WaitUntilElement(By.Id("_ctl0_PopupPageContent_btnSave"));
                WebDriver.FindElement(By.Id("_ctl0_PopupPageContent_btnSave")).Click();
                Thread.Sleep(2000);
                SendKeys.SendWait("{ENTER}");
                ////To dismiss alert
                //Thread.Sleep(3000);
                //WebDriver.SwitchTo().Alert().Accept();
                //Thread.Sleep(2000);
                //WebDriver.SwitchTo().DefaultContent();

                GenericHelper.SelectWindow("View Submission");
                GenericHelper.WaitUntilElement(By.Id("_ctl0_PopupPageContent_SubmissionHeaderMaster_InstructorHeader_chkGrade"));
                WebDriver.FindElement(By.Id("_ctl0_PopupPageContent_SubmissionHeaderMaster_InstructorHeader_chkGrade")).Click();
                GenericHelper.WaitUntilElement(
                    By.Id("_ctl0_PopupPageContent_SubmissionHeaderMaster_InstructorHeader_txtGrade"));
                WebDriver.FindElement(By.Id("_ctl0_PopupPageContent_SubmissionHeaderMaster_InstructorHeader_txtGrade")).Click();
                WebDriver.FindElement(By.Id("_ctl0_PopupPageContent_SubmissionHeaderMaster_InstructorHeader_txtGrade")).Clear();
                gradestoBeEntered = (_grade + 1).ToString(CultureInfo.InvariantCulture);
                WebDriver.FindElement(By.Id("_ctl0_PopupPageContent_SubmissionHeaderMaster_InstructorHeader_txtGrade")).SendKeys(gradestoBeEntered);
                GenericHelper.WaitUntilElement(By.Id("_ctl0_PopupPageContent_btnSaveAndClose"));
                WebDriver.FindElement(By.Id("_ctl0_PopupPageContent_btnSaveAndClose")).Click();
                bool isViewSubmissionClosed = GenericHelper.IsPopUpClosed(2);
                if (isViewSubmissionClosed)
                {
                    GenericHelper.Logs("View Submission window is closed after manual editing of grades","Passed");
                }
                else
                {
                    GenericHelper.Logs("View Submission window is still open","Failed");
                }
                GenericHelper.WaitUtilWindow("Course Materials");
                GenericHelper.SelectWindow("Course Materials");
                ToOpenViewSubmissionByTAAfterManualGrading();
            }


            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }


        // To open view submission by TA after manual grading
        public void ToOpenViewSubmissionByTAAfterManualGrading()
        {
            WebDriver.Navigate().Refresh();
            new CourseContentUXPage().ToSelectSubmittedActivityFromTa();
        }

        //purpose :To verify grades by TA
        public void VerifyGradesGivenByTa()
        {
            GenericHelper.SelectWindow("View Submission");
            string gradeTextBoxValue = WebDriver.FindElement(By.ClassName("Expandable_GridNode_Grade")).Text;
            if (gradeTextBoxValue.Contains(gradestoBeEntered))
            {
                GenericHelper.Logs("Score gets updated and overall score for submission is reflecting and same is being displayed in View submission window", "passed");
            }
            WebDriver.Close();
            GenericHelper.SelectWindow("Course Materials");
        }


        //Purpose: To Verify Comments and Color of Instructor Comments in First Editor
        public void VerifyStudentAndInstructorCommentTextColorInFirstEditor()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.XPath("//html/body/font"));
                string fontText = WebDriver.FindElement(By.XPath("//html/body/font")).GetAttribute("innerText");
                string fontColorCode = WebDriver.FindElement(By.XPath("//html/body/font")).GetAttribute("color");

                if (fontColorCode == "#0000ff" && fontText.Contains("Instructor"))
                {
                    GenericHelper.Logs("Instructor inserted text displayed in Blue Color for first submission of essay question.", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("Instructor inserted text not displayed in Blue Color for first submission of essay question.", "FAILED");
                    Assert.Fail("Instructor inserted text not displayed in Blue Color for first submission of essay question.");
                }
                string isStudentCommentedColorChanged = WebDriver.FindElement(By.XPath("//html/body")).GetAttribute("text");
                if (isStudentCommentedColorChanged == "#000000")
                {
                    GenericHelper.Logs("Upon placing cursor the color of student answer not changed or first submission of essay question.", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("Upon placing cursor the color of student answer has changed.", "FAILED");
                    Assert.Fail("Upon placing cursor the color of student answer has changed or first submission of essay question.");
                }
                WebDriver.SwitchTo().DefaultContent();
                Thread.Sleep(4000);
                WebDriver.Close();

            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: To Verify Comments and Color of Instructor Comments in Second Editor
        public void EnterCommentsAndPlaceCursorInSecondEditor()
        {
            try
            {
                GenericHelper.SelectWindow("View Submission");
                GenericHelper.WaitUntilElement(By.Id("_ctl0_PopupPageContent_submissionDetailMaster__ctl1__VSEditor_1"));
                WebDriver.SwitchTo().Frame("_ctl0_PopupPageContent_submissionDetailMaster__ctl1__VSEditor_1");
                IWebElement studentComment = WebDriver.FindElement(By.XPath("//html/body"));
                var builder = new Actions(WebDriver);
                builder.MoveToElement(studentComment).ClickAndHold().Perform();
                WebDriver.FindElement(By.XPath("//html/body")).SendKeys("Instructor Comment 2");
                builder.MoveToElement(studentComment).ClickAndHold().Perform();

            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: To Verify Comments and Color of Instructor Comments in First Editor
        public void VerifyStudentAndInstructorCommentTextColorInSecondEditor()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.XPath("//html/body/font"));
                string fontText = WebDriver.FindElement(By.XPath("//html/body/font")).GetAttribute("innerText");
                string fontColorCode = WebDriver.FindElement(By.XPath("//html/body/font")).GetAttribute("color");
                if (fontColorCode == "#0000ff" && fontText.Contains("Instructor"))
                {
                    GenericHelper.Logs("Instructor inserted text displayed in Blue Color for second submission of essay question.", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("Instructor inserted text not displayed in Blue Color for second submission of essay question.", "FAILED");
                    Assert.Fail("Instructor inserted text not displayed in Blue Color for second submission of essay question.");
                }
                string isStudentCommentedColorChanged = WebDriver.FindElement(By.XPath("//html/body")).GetAttribute("text");
                if (isStudentCommentedColorChanged == "#000000")
                {
                    GenericHelper.Logs("Upon placing cursor the color of student answer not changed for second submission of essay question.", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("Upon placing cursor the color of student answer has changed for second submission of essay question.", "FAILED");
                    Assert.Fail("Upon placing cursor the color of student answer has changed for second submission of essay question.");
                }
                WebDriver.SwitchTo().DefaultContent();
                Thread.Sleep(4000);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }
    }
}
