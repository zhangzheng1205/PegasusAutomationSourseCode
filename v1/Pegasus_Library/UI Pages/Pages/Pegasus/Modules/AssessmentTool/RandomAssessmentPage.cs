using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using System.Configuration;
using OpenQA.Selenium.Support.UI;
using Pegasus_DataAccess;
using Framework.Common;
using System.Linq;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.AssessmentTool
{
    public class RandomAssessmentPage : BasePage
    {
        //Purpose: to Create PreTest for SSP
        public void CreatePreTestSsp(string pretestName)
        {
            GenericHelper.WaitUntilElement(By.Id("cmdTabAssessmentNext"));
            WebDriver.FindElement(By.Id("txtAssname")).SendKeys(GenericHelper.GenerateUniqueVariable("BDD_pretest"));
            WebDriver.FindElement(By.Id("cmdTabAssessmentNext")).Click();

            GenericHelper.WaitUntilElement(By.Id("cmdTabTopicsNext"));
            WebDriver.FindElement(By.PartialLinkText("Add Questions")).Click();
            WebDriver.FindElement(By.XPath("//div[@id='AddQuestionsContextMenu']/table/thead/tr/td")).Click();
            Thread.Sleep(2000);
            GenericHelper.SelectWindow("Select Questions");

            WebDriver.SwitchTo().Frame("_ctl0_PopupPageContent_ifrmLeft");
            GenericHelper.WaitUntilElement(By.Id("tdShowPreview"));
            WebDriver.FindElement(
                By.XPath("//TABLE[@id='grdFrameWorkSkillStandard']/tbody/tr/td[2]/table/tbody/tr/td/span/span/span")).
                Click();
            GenericHelper.WaitUntilElement(By.Id("tdShowPreview"));
            if (
                GenericHelper.IsElementPresent(
                    By.XPath("//TABLE[@id='grdFrameWorkSkillStandard']/tbody/tr/td[2]/table/tbody/tr/td/span/span/span")))
            {
                WebDriver.FindElement(
                    By.XPath("//TABLE[@id='grdFrameWorkSkillStandard']/tbody/tr/td[2]/table/tbody/tr/td/span/span/span"))
                    .Click();
                GenericHelper.WaitUntilElement(By.Id("tdShowPreview"));
            }
            if (
                GenericHelper.IsElementPresent(
                    By.XPath("//TABLE[@id='grdFrameWorkSkillStandard']/tbody/tr/td[2]/table/tbody/tr/td/span/span/span")))
            {
                WebDriver.FindElement(
                    By.XPath("//TABLE[@id='grdFrameWorkSkillStandard']/tbody/tr/td[2]/table/tbody/tr/td/span/span/span"))
                    .Click();
                GenericHelper.WaitUntilElement(By.Id("tdShowPreview"));
            }
            if (
                GenericHelper.IsElementPresent(
                    By.XPath("//TABLE[@id='grdFrameWorkSkillStandard']/tbody/tr/td[2]/table/tbody/tr/td/span/span/span")))
            {
                WebDriver.FindElement(
                    By.XPath("//TABLE[@id='grdFrameWorkSkillStandard']/tbody/tr/td[2]/table/tbody/tr/td/span/span/span"))
                    .Click();
                GenericHelper.WaitUntilElement(By.Id("tdShowPreview"));
            }
            WebDriver.FindElement(By.Id("grdSkillStandardAlignedAssets$_ctrl0")).Click();
            GenericHelper.SelectWindow("Select Questions");
            WebDriver.FindElement(By.Id("_ctl0_PopupPageContent_imgBtnAdd_Close")).Click();
            //  GenericHelper.IsPopUpClosed("Select Questions");
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
            GenericHelper.WaitUntilElement(By.Id("cmdTabTopicsFinish"));
            WebDriver.FindElement(By.Id("cmdTabTopicsFinish")).Click();

        }

        //Purpose: to Create PostTest for SSP
        public void CreatePostTestSsp(string posttestName)
        {
            GenericHelper.WaitUntilElement(By.Id("cmdTabAssessmentNext"));
            WebDriver.FindElement(By.Id("txtAssname")).SendKeys(GenericHelper.GenerateUniqueVariable("BDD_postest"));
            WebDriver.FindElement(By.Id("cmdTabAssessmentNext")).Click();
            GenericHelper.WaitUntilElement(By.Id("cmdTabTopicsNext"));
            WebDriver.SwitchTo().Frame("frmTopic");
            WebDriver.FindElement(By.PartialLinkText("Add Questions")).Click();
            if (GenericHelper.IsElementPresent(By.PartialLinkText("Browse Skills Framework")))
            {
                WebDriver.FindElement(By.PartialLinkText("Browse Skills Framework")).Click();
            }
            else
            {
                WebDriver.FindElement(By.PartialLinkText("Browse Skill Framework")).Click();
            }
            Thread.Sleep(2000);
            GenericHelper.SelectWindow("Select Questions");
            Thread.Sleep(2000);
            WebDriver.SwitchTo().Frame("_ctl0_PopupPageContent_ifrmLeft");
            WebDriver.FindElement(By.Id("grdSkillStandardAlignedAssets$_ctrl0")).Click();
            GenericHelper.SelectWindow("Select Questions");
            WebDriver.FindElement(By.Id("_ctl0_PopupPageContent_imgBtnAdd_Close")).Click();
            //GenericHelper.IsPopUpClosed("Select Questions");
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
            GenericHelper.WaitUntilElement(By.Id("cmdTabTopicsFinish"));
            WebDriver.FindElement(By.Id("cmdTabTopicsFinish")).Click();
            Thread.Sleep(2000);
        }

        //Purpose : To navigate preferences tab
        public void NavigatePreferencesTab()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.Id("cmdTabPreference"));
                WebDriver.FindElement(By.Id("cmdTabPreference")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose : To navigate preferences tab
        public void NavigateGradesTab()
        {
            try
            {

                if (GenericHelper.IsElementPresent(By.Id("chkEnableTryAgain")))
                {
                    GenericHelper.WaitUntilElement(By.Id("chkEnableTryAgain"));
                    WebDriver.FindElement(By.Id("chkEnableTryAgain")).Click();
                }
                GenericHelper.WaitUntilElement(By.Id("cmdTabGrades"));
                WebDriver.FindElement(By.Id("cmdTabGrades")).SendKeys("");
                WebDriver.FindElement(By.Id("cmdTabGrades")).Click();

            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose : To Select ActivityLevel Radio Button under preferences 
        public void SelectActivityLevelRadioButton()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.Id("radAssessmentTiming"));
                WebDriver.FindElement(By.Id("radAssessmentTiming")).SendKeys("");
                WebDriver.FindElement(By.Id("radAssessmentTiming")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To Set Hours
        public void SetHours(string hour)
        {
            try
            {
                WebDriver.FindElement(By.Id("txtAssessmentHours")).SendKeys("");
                WebDriver.FindElement(By.Id("txtAssessmentHours")).Clear();
                WebDriver.FindElement(By.Id("txtAssessmentHours")).SendKeys(hour);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To Click Save And Return At Preferences
        public void ClickSaveAndReturnAtPreferences()
        {
            try
            {
                WebDriver.FindElement(By.Id("cmdTabPreferenceFinish")).SendKeys("");
                WebDriver.FindElement(By.Id("cmdTabPreferenceFinish")).Click();
                Thread.Sleep(2000);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To Click Save And Return At Grades
        public void ClickSaveAndReturnAtGrades()
        {
            try
            {
                WebDriver.SwitchTo().DefaultContent();
                GenericHelper.SelectWindow("Edit Random activity");
                GenericHelper.WaitUntilElement(By.Id("cmdTabGradeFinish"));
                //WebDriver.FindElement(By.Id("cmdTabGradeFinish")).SendKeys("");
                WebDriver.FindElement(By.Id("cmdTabGradeFinish")).Click();
                Thread.Sleep(2000);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }
        //Purpose: To Get Time Value 
        public string GetTimeValue()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.Id("txtAssessmentHours"));
                WebDriver.FindElement(By.Id("txtAssessmentHours")).SendKeys("");
                string time = WebDriver.FindElement(By.Id("txtAssessmentHours")).GetAttribute("value");
                return time;
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To Set Questions Count
        public void SetQuestionsCount(string Count)
        {
            try
            {
                WebDriver.FindElement(By.Id("txtNoOfQuestions")).SendKeys("");
                WebDriver.FindElement(By.Id("txtNoOfQuestions")).Clear();
                WebDriver.FindElement(By.Id("txtNoOfQuestions")).SendKeys(Count);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To Get Questions Count
        public string GetQuestionsCount()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.Id("txtNoOfQuestions"));
                WebDriver.FindElement(By.Id("txtNoOfQuestions")).SendKeys("");
                string cntValue = WebDriver.FindElement(By.Id("txtNoOfQuestions")).GetAttribute("value");
                return cntValue;
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        // Purpose: To Select Default Style Sheet
        public void SelectDefaultStyleSheet()
        {
            try
            {
                WebDriver.FindElement(By.Id("cboStyleSheet")).SendKeys("");
                new SelectElement(WebDriver.FindElement(By.Id("cboStyleSheet"))).SelectByText("Default");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To verify Default Style Sheet Selected
        public string verifyDefaultStyleSheetSelected()
        {
            try
            {
                IWebElement dropdown = WebDriver.FindElement(By.Id("cboStyleSheet"));
                SelectElement select = new SelectElement(dropdown);
                String wantedText = select.SelectedOption.Text;

                return wantedText;
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To verify  Grade Schema Selected 
        public string verifyGradeSchemaSelected()
        {
            try
            {
                IWebElement dropdown = WebDriver.FindElement(By.Id("cboGradeScheme"));
                SelectElement select = new SelectElement(dropdown);
                String wantedText = select.SelectedOption.Text;

                return wantedText;
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        // Purpose: To Select Default Grade Schema
        public void SelectDefaultGradeSchema()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.Id("cboGradeScheme"));
                WebDriver.FindElement(By.Id("cboGradeScheme")).SendKeys("");
                new SelectElement(WebDriver.FindElement(By.Id("cboGradeScheme"))).SelectByText("Default");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        // Purpose: To Set Number Of Attempts
        public void SetNumberOfAttempts(string attempts)
        {
            try
            {
                GenericHelper.WaitUntilElement(By.Id("txtAttemptsallowed"));
                WebDriver.FindElement(By.Id("txtAttemptsallowed")).SendKeys("");
                WebDriver.FindElement(By.Id("txtAttemptsallowed")).Clear();
                WebDriver.FindElement(By.Id("txtAttemptsallowed")).SendKeys(attempts);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        // Purpose: To Get Value Of 'Specify Number Of Attempts'
        public string GetValueOfSpecifyNumberOfAttempts()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.Id("txtAttemptsallowed"));
                WebDriver.FindElement(By.Id("txtAttemptsallowed")).SendKeys("");
                return WebDriver.FindElement(By.Id("txtAttemptsallowed")).GetAttribute("value");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        // Purpose: To Get Value Of 'Specify Number Of Attempts'
        public string GetValueOfThresholdScore()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.Id("txtthreshold"));
                WebDriver.FindElement(By.Id("txtthreshold")).SendKeys("");
                return WebDriver.FindElement(By.Id("txtthreshold")).GetAttribute("value");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose : To Click on Add Questions
        public void ClickAddQuestions()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.Id("A1"));
                WebDriver.FindElement(By.Id("A1")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose : To Click on Create New Question
        public void ClickCreateNewQuestion()
        {
            try
            {
                WebDriver.FindElement(By.Id("tdCreateQuestion")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose : To Click SaveAndReturn
        public void ClickSaveAndReturn()
        {
            try
            {
                // GenericHelper.WaitUtilWindow("Create Study Plan");
                GenericHelper.SelectDefaultWindow();

                GenericHelper.WaitUntilElement(By.Id("cmdTabTopicsFinish"));
                WebDriver.FindElement(By.Id("cmdTabTopicsFinish")).SendKeys("");
                WebDriver.FindElement(By.Id("cmdTabTopicsFinish")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

    }
}
