using System.Threading;
using OpenQA.Selenium;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
using System.Linq;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.SkillStandardIntegration
{
    public class AlignContentsToSkillPage: BasePage
    {
        //Purpose: To Open Skill in right frame
        public void OpenTheSkillInRightFrame()
        {
            WebDriver.SwitchTo().Frame("ifrmRight");
            GenericHelper.WaitUntilElement(By.Id("tblNormal"));
            WebDriver.FindElement(By.XPath("//TABLE[@id='grdFrameWorkSkillStandard']/tbody/tr/td[2]/table/tbody/tr/td/span")).Click();

            GenericHelper.WaitUntilElement(By.Id("tblNormal"));
            WebDriver.FindElement(By.XPath("//TABLE[@id='grdFrameWorkSkillStandard']/tbody/tr/td[2]/table/tbody/tr/td/span/span/span")).Click();
            
            GenericHelper.WaitUntilElement(By.Id("tblNormal"));
            if (GenericHelper.IsElementPresent(By.XPath("//TABLE[@id='grdFrameWorkSkillStandard']/tbody/tr/td[2]/table/tbody/tr/td/span/span/span")))
            {
                WebDriver.FindElement(By.XPath("//TABLE[@id='grdFrameWorkSkillStandard']/tbody/tr/td[2]/table/tbody/tr/td/span/span/span")).Click();
                GenericHelper.WaitUntilElement(By.Id("tblNormal"));
            }
            if (GenericHelper.IsElementPresent(By.XPath("//TABLE[@id='grdFrameWorkSkillStandard']/tbody/tr/td[2]/table/tbody/tr/td/span/span/span")))
            {
                WebDriver.FindElement(By.XPath("//TABLE[@id='grdFrameWorkSkillStandard']/tbody/tr/td[2]/table/tbody/tr/td/span/span/span")).Click();
                GenericHelper.WaitUntilElement(By.Id("tblNormal"));
            }
            if (GenericHelper.IsElementPresent(By.XPath("//TABLE[@id='grdFrameWorkSkillStandard']/tbody/tr/td[2]/table/tbody/tr/td/span/span/span")))
            {
                WebDriver.FindElement(By.XPath("//TABLE[@id='grdFrameWorkSkillStandard']/tbody/tr/td[2]/table/tbody/tr/td/span/span/span")).Click();
                GenericHelper.WaitUntilElement(By.Id("tblNormal"));
            }
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
            
        }

        //Purpose: To Select the question in Left Frame
        public void SelectQuestionInLeftFrame(string questionName)
        {
            GenericHelper.WaitUntilElement(By.XPath("//TABLE[@id='dgContentLibrary']"));
            int rows = (WebDriver.FindElements(By.XPath("//TABLE[@id='dgContentLibrary']/tbody/tr"))).Count;
            for (int i = 2; i <= rows; i++)
            {
                string QuestionName =
                    WebDriver.FindElement(By.XPath("//TABLE[@id='dgContentLibrary']/tbody/tr[" + i.ToString() + "]")).
                        GetAttribute("AssetName");
                if (QuestionName ==questionName)
                {
                    WebDriver.FindElement(
                        By.XPath("//TABLE[@id='dgContentLibrary']/tbody/tr[" + i.ToString() + "]/td/input")).Click();
                    break;
                }
            }

        }

        //PurPose : To Select left frame 
        public void SelectLeftFrame()
        {
            WebDriver.SwitchTo().Frame("ifrmleft");
        }

        //PurPose : To Click Add button to map questions to skill
        public void ClickAddButton()
        {
            GenericHelper.WaitUntilElement(By.ClassName("btn_add"));
            WebDriver.FindElement(By.ClassName("btn_add")).Click();
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
        }
    }
}
