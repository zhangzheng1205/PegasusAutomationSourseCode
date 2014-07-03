using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Framework.Common;
using OpenQA.Selenium.Interactions;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
using OpenQA.Selenium;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.AssessmentTool;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.DRT;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.QuestionLibrary;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.TeachingPlan
{
    public class ContentLibraryUXPage : BasePage
    {
        readonly private DRTDefaultUXPage _drtDefaultUxPage = new DRTDefaultUXPage();
        readonly private AddAssessmentPage _addAssessmentPage = new AddAssessmentPage();
        readonly private RandomAssessmentPage _randomAssessmentPage = new RandomAssessmentPage();
        readonly private SelectQuestionTypePage _selectQuestionTypePage = new SelectQuestionTypePage();
        readonly private RandomTopicListPage _randomTopicListPage = new RandomTopicListPage();
        readonly private TrueFalsePage _trueFalsePage = new TrueFalsePage();

        //Purpose: To Open MyTestsFolder
        public void OpenMyTestsFolder()
        {
            try
            {
                GenericHelper.WaitUtilWindow("Course Materials");
                GetControlToLeftFrame();
                GenericHelper.WaitUntilElement(By.PartialLinkText("My Tests Folder"));
                WebDriver.FindElement(By.PartialLinkText("My Tests Folder")).SendKeys("");
                WebDriver.FindElement(By.PartialLinkText("My Tests Folder")).Click();
                Thread.Sleep(2000);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To Click Activity Cmenu
        public void ClickActivityCmenu(string actName)
        {
            try
            {
                int rowcnt = WebDriver.FindElements(By.XPath("//table[@id='grdContentLibrary']/tbody/tr")).Count();
                for (int i = 1; i <= rowcnt; i++)
                {
                    WebDriver.FindElement(By.XPath("//table[@id='grdContentLibrary']/tbody/tr[" + i.ToString() + "]")).SendKeys("");
                    string assetName = WebDriver.FindElement(By.XPath("//table[@id='grdContentLibrary']/tbody/tr[" + i.ToString() + "]")).GetAttribute("AssetName");
                    if (assetName == actName)
                    {
                        IWebElement asset = WebDriver.FindElement(By.XPath("//table[@id='grdContentLibrary']/tbody/tr[" + i.ToString() + "]//td[2]/table/tbody/tr/td/table/tbody/tr/td[2]"));
                        IWebElement cmenu = WebDriver.FindElement(By.XPath("//table[@id='grdContentLibrary']/tbody/tr[" + i.ToString() + "]//td[2]/table/tbody/tr/td/table/tbody/tr/td[3]/center/img"));

                        Actions builder = new Actions(WebDriver);
                        builder.MoveToElement(asset).Build().Perform();
                        builder.MoveToElement(cmenu).Click().Perform();
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To Select Edit Cmenu Option
        public void SelectEditCmenuOption()
        {
            try
            {
                WebDriver.FindElement(By.PartialLinkText("Edit")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To Click Activity Link
        public void ClickActivityLink(string actName)
        {
            try
            {
                GenericHelper.WaitUntilElement(By.XPath("//table[@id='grdContentLibrary']/tbody/tr[2]/td[2]/table/tbody/tr/td/table/tbody/tr/td[2]/a"));
                WebDriver.FindElement(By.XPath("//table[@id='grdContentLibrary']/tbody/tr[2]/td[2]/table/tbody/tr/td/table/tbody/tr/td[2]/a")).Click();



                GenericHelper.WaitUntilElement(By.XPath("//table[@id='grdContentLibrary']/tbody/tr[2]/td[2]/table/tbody/tr/td/table/tbody/tr/td[2]/a[@title='Test201324125450']"));

                IWebElement assetName = WebDriver.FindElement(By.XPath("//table[@id='grdContentLibrary']/tbody/tr[2]/td[2]/table/tbody/tr/td/table/tbody/tr/td[2]/a[@title='Test201324125450']"));
                assetName.Click();
                GenericHelper.WaitUtilWindow("Web Activity");
                GenericHelper.SelectWindow("Web Activity");

            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To Get Control To Left Frame
        public void GetControlToLeftFrame()
        {
            try
            {
                GenericHelper.SelectDefaultWindow();
                GenericHelper.WaitUntilElement(By.Id("ifrmLeft"));
                WebDriver.SwitchTo().Frame("ifrmLeft");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To Select Asset
        public void SelectAsset(string actName)
        {
            try
            {
                int rowcnt = WebDriver.FindElements(By.XPath("//table[@id='grdContentLibrary']/tbody/tr")).Count();
                for (int i = 1; i <= rowcnt; i++)
                {
                    WebDriver.FindElement(By.XPath("//table[@id='grdContentLibrary']/tbody/tr[" + i.ToString() + "]")).SendKeys("");
                    string assetName = WebDriver.FindElement(By.XPath("//table[@id='grdContentLibrary']/tbody/tr[" + i.ToString() + "]")).GetAttribute("AssetName");
                    if (assetName == actName)
                    {
                        WebDriver.FindElement(By.XPath("//table[@id='grdContentLibrary']/tbody/tr[" + i.ToString() + "]/td/input")).Click();
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }

        }

        //Purpose : To Click Add Course Materials
        public void ClickAddCourseMaterialsButton()
        {
            try
            {
                WebDriver.SwitchTo().Frame("ifrmleft");
                GenericHelper.WaitUntilElement(By.ClassName("btn_AddContent"));
                WebDriver.FindElement(By.ClassName("btn_AddContent")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose : To Select Web Activity option
        public void SelectWebActivity()
        {
            try
            {
                WebDriver.FindElement(By.XPath("//table[@id='tbldivMenu']/tbody/tr[3]/td[@title='Web Activity']")).Click();
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose : To Select Add StudyPlan option
        public void SelectAddStudyPlan()
        {
            try
            {
                WebDriver.FindElement(By.XPath("//table[@id='tbldivMenu']/tbody/tr[11]/td[@title='Add Study Plan']")).SendKeys("");
                WebDriver.FindElement(By.XPath("//table[@id='tbldivMenu']/tbody/tr[11]/td[@title='Add Study Plan']")).Click();
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose : To verify Add study plan option is present
        public bool IsStudyPlanOptionPresent()
        {
            try
            {
                return GenericHelper.IsElementPresent(By.XPath("//table[@id='tbldivMenu']/tbody/tr[11]/td[@title='Add Study Plan']"));
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        public void StudyPlanCreation(string studyPlanName)
        {
            SelectAddStudyPlan();
            GenericHelper.WaitUtilWindow("Create Study Plan");
            _drtDefaultUxPage.EnterSSPName(studyPlanName);

            //pretest
            _drtDefaultUxPage.ClickCreateTestForPretest();
            GenericHelper.WaitUtilWindow("Create Pre-test:");
            _addAssessmentPage.EnterActivityName("PreTest");
            _addAssessmentPage.ClickSaveAndContinue();
            _randomAssessmentPage.ClickAddQuestions();
            _randomAssessmentPage.ClickCreateNewQuestion();
            GenericHelper.WaitUtilWindow("Create New Question");
            GenericHelper.SelectWindow("Create New Question");
            _selectQuestionTypePage.SelectTrueFalse();
            _selectQuestionTypePage.CreateTrueFalseQuestion();
            _randomAssessmentPage.ClickSaveAndReturn();
            if (_drtDefaultUxPage.VerifySuccesfullMessage("Pre Test created successfully."))
            {
                GenericHelper.Logs("SuccessFull message displayed for creation of PreTest", "PASSED");
            }
            else
            {
                GenericHelper.Logs("SuccessFull message not displayed for creation of PreTest", "FAILED");
                throw new Exception("SuccessFull message not displayed for creation of PreTest");
            }

            //posttest
            _drtDefaultUxPage.ClickCreateTestForPretest();
            GenericHelper.WaitUtilWindow("Create Post-test");
            _addAssessmentPage.EnterActivityName("PostTest");
            _addAssessmentPage.ClickSaveAndContinue();
            _randomTopicListPage.ClickAddQuestions();
            _randomTopicListPage.ClickCreateNewQuestion();
            GenericHelper.WaitUtilWindow("Create New Question");
            GenericHelper.SelectWindow("Create New Question");
            _selectQuestionTypePage.SelectTrueFalseForPostTest();
            _trueFalsePage.CreateTrueFalseQuestionForPostTest();
            _randomAssessmentPage.ClickSaveAndReturn();
            if (_drtDefaultUxPage.VerifySuccesfullMessage("Post Test created successfully."))
            {
                GenericHelper.Logs("SuccessFull message displayed for creation of PostTest", "PASSED");
            }
            else
            {
                GenericHelper.Logs("SuccessFull message not displayed for creation of PostTest", "FAILED");
                throw new Exception("SuccessFull message not displayed for creation of PostTest");
            }

            GenericHelper.SelectDefaultWindow();
            _drtDefaultUxPage.SaveSSP();

            GenericHelper.WaitUtilWindow("Course Materials");
            if (GenericHelper.VerifySuccesfullMessage("Study Plan added successfully."))
            {
                GenericHelper.Logs("SuccessFull message displayed for creation of Study Plan", "PASSED");
                DatabaseTools.UpdateActivity(Enumerations.ActivityType.StudyPlan, studyPlanName);
            }
            else
            {
                GenericHelper.Logs("SuccessFull message not displayed for creation of Study Plan", "FAILED");
                throw new Exception("SuccessFull message not displayed for creation of Study Plan");
            }

        }

    }
}
