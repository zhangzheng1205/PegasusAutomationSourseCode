using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using Pegasus_DataAccess;
using Framework.Common;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.SMSIntegration.ProgramManagement
{
   public class ProgramCreatePage : BasePage
    {
       IWebElement _iElement;

       //Purpose: To Create Program
       public void CreateProgram()
       {
           try
           {
               string programName = GenericHelper.GenerateUniqueVariable("BDD_Pgm");
               string emptyCourse = DatabaseTools.GetEnabledCourse(Enumerations.CourseType.EmptyCourse);
               Thread.Sleep(1000);
               GenericHelper.WaitUntillWindowAndElement("Create New Program", By.ClassName("textfield2"));
               WebDriver.FindElement(By.ClassName("textfield2")).SendKeys(programName);
               GenericHelper.WaitUntilElement(By.Id("drpEmptyClass"));
               _iElement = WebDriver.FindElement(By.Id("drpEmptyClass"));
               SelectElement selectElement1 = new SelectElement(_iElement);
               try
               {
                   selectElement1.SelectByText(emptyCourse);
               }
               catch (Exception)
               {
                   GenericHelper.Logs("Empty Class not present while creating Program.", "FAILED");
                   throw new Exception("Empty Class not present while creating Program.");
               }
               WebDriver.FindElement(By.Id("chkbxEnablePrgAssociationToAdmin")).Click();
               WebDriver.FindElement(By.Id("chkbxEnablePrgAssociationToTech")).Click();
               GenericHelper.WaitUntilElement(By.Id("chkbxEnableStdManagement"));
               WebDriver.FindElement(By.Id("chkbxEnableTeachBadgeView")).Click();
               WebDriver.FindElement(By.Id("chkbxEnableStdManagement")).Click();
               GenericHelper.WaitUntilElement(By.Id("imgbtnSave"));
               WebDriver.FindElement(By.Id("imgbtnSave")).Click();
               Thread.Sleep(1000);
               if (GenericHelper.IsPopUpClosed(2))
               {
                   DatabaseTools.UpdateProgram(programName, emptyCourse,Enumerations.ProgramInstance.NovaNET);
                   GenericHelper.Logs(programName + " program name is updated in DB", "PASSED");
               }
               else
               {
                   GenericHelper.Logs(
                       "'Create New Program' not closed on clicking the save button hence progrm name is not updated in DB",
                       "FAILED");
               }
           }
           catch (Exception e)
           {
               GenericHelper.Logs(e.ToString(), "FAILED");
               if (GenericHelper.IsPopUpWindowPresent("Create New Program"))
               {
                   GenericHelper.SelectWindow("Create New Program");
                   WebDriver.Close();
               }
               
               throw new Exception(e.ToString());
           }
       }

       public void CreateHEDProgram()
       {
           try
           {
               string programName = GenericHelper.GenerateUniqueVariable("BDD_Pgm");
              // string emptyCourse = DatabaseTools.GetEnabledCourse(Enumerations.CourseType.EmptyCourse);
               Thread.Sleep(1000);
               GenericHelper.WaitUntillWindowAndElement("Create New Program", By.ClassName("textfield2"));
               WebDriver.FindElement(By.ClassName("textfield2")).SendKeys(programName);
               GenericHelper.WaitUntilElement(By.Id("drpEmptyClass"));
               _iElement = WebDriver.FindElement(By.Id("drpEmptyClass"));
               SelectElement selectElement1 = new SelectElement(_iElement);
               try
               {
                   selectElement1.SelectByText("QA - Empty Class HED Core");
               }
               catch (Exception)
               {
                   GenericHelper.Logs("Empty Class not present while creating Program.", "FAILED");
                   throw new Exception("Empty Class not present while creating Program.");
               }
               WebDriver.FindElement(By.Id("chkbxEnablePrgAssociationToAdmin")).Click();
               WebDriver.FindElement(By.Id("chkbxEnablePrgAssociationToTech")).Click();
               GenericHelper.WaitUntilElement(By.Id("chkbxEnableStdManagement"));
               WebDriver.FindElement(By.Id("chkbxEnableTeachBadgeView")).Click();
               WebDriver.FindElement(By.Id("chkbxEnableStdManagement")).Click();
               GenericHelper.WaitUntilElement(By.Id("imgbtnSave"));
               WebDriver.FindElement(By.Id("imgbtnSave")).Click();
               Thread.Sleep(1000);
               if (GenericHelper.IsPopUpClosed(2))
               {                                     
                   DatabaseTools.UpdateHEDProgram(programName, Enumerations.ProgramInstance.HedCore);
                   GenericHelper.Logs(programName + "Hed program name is updated in DB", "PASSED");
               }
               else
               {
                   GenericHelper.Logs("'Create New Program' not closed on clicking the save button hence progrm name is not updated in DB","FAILED");
               }
           }
           catch (Exception e)
           {
               GenericHelper.Logs(e.ToString(), "FAILED");
               if (GenericHelper.IsPopUpWindowPresent("Create New Program"))
               {
                   GenericHelper.SelectWindow("Create New Program");
                   WebDriver.Close();
               }

               throw new Exception(e.ToString());
           }
       }
    }
}
