using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Coursesettings;
using System.Threading;
using System.IO;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles Questions Preferences Page Actions.
    /// </summary>
    public class QuestionsPreferencesPage : BasePage    
    {
        /// <summary>
        /// The Static Instance of the Logger for the Class.
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(QuestionsPreferencesPage));

        /// <summary>
        /// Enable SIM5 Questions Preference.
        /// </summary>
        public void EnableSIM5QuestionsPreference()
        {
            //Enable SIM5 Questions Preference
            logger.LogMethodEntry("QuestionsPreferencesPage",
            "EnableSIM5QuestionsPreference", base.isTakeScreenShotDuringEntryExit);
            try
            {
                GeneralPreferencesPage generalPreferencesPage = new GeneralPreferencesPage();
                //Select Window And Frame
                generalPreferencesPage.SelectThePreferenceWindowWithFrame();
                //Wait For Sim5 Questions Radiobutton
                base.WaitForElement(By.Id(QuestionsPreferencesPageResource.
                    QuestionsPreferences_Page_Sim5Questions_Preference_Radio_Id_Locator));
                if (!base.IsElementSelectedById(QuestionsPreferencesPageResource.
                    QuestionsPreferences_Page_Sim5Questions_Preference_Radio_Id_Locator))
                {
                    //Get Lock Icon Status
                    string getEnableSIM5questionsLockIconStatus =
                        base.GetClassAttributeValueById(QuestionsPreferencesPageResource.
                        QuestionsPreferences_Page_Sim5Questions_LockIcon_Id_Locator);
                    if (getEnableSIM5questionsLockIconStatus ==
                        QuestionsPreferencesPageResource.
                        QuestionsPreferences_Page_LockIcon_Status_Value)
                    {
                        //Click On Lock Icon to Unlock Preference
                        base.ClickButtonByID(QuestionsPreferencesPageResource.
                        QuestionsPreferences_Page_Sim5Questions_LockIcon_Id_Locator);
                    }
                    //Select 'Enable SIM5 Questions' Preference Radiobutton
                    base.SelectRadioButtonById(QuestionsPreferencesPageResource.
                    QuestionsPreferences_Page_Sim5Questions_Preference_Radio_Id_Locator);
                }
                //Save Preferences
                generalPreferencesPage.SavePreferences();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("QuestionsPreferencesPage",
            "EnableSIM5QuestionsPreference", base.isTakeScreenShotDuringEntryExit);
        }

       /// <summary>
       /// Enable original Sim Questions Radiobutton.
       /// </summary>
       public void EnableOriginalSIMQuestionPreference()
        {
            //Logger Entry
            logger.LogMethodEntry("QuestionsPreferencesPage",
            "EnableOriginalSIMQuestionPreference", 
            base.isTakeScreenShotDuringEntryExit);
            try
            {
                GeneralPreferencesPage generalPreferencesPage = new 
                    GeneralPreferencesPage();
                //Select Window And Frame
                generalPreferencesPage.SelectThePreferenceWindowWithFrame();
                //Wait For original Sim Questions Radiobutton
                base.WaitForElement(By.Id(QuestionsPreferencesPageResource.
                    QuestionsPreferences_Page_OriginalSimQuestions_Radio_Id_Locator));
                if (!base.IsElementSelectedById(QuestionsPreferencesPageResource.
                    QuestionsPreferences_Page_OriginalSimQuestions_Radio_Id_Locator))
                {
                    //Get Lock Icon Status
                    string getEnableSIM5questionsLockIconStatus =
                        base.GetClassAttributeValueById(QuestionsPreferencesPageResource.
                        QuestionsPreferences_Page_Sim5Questions_LockIcon_Id_Locator);
                    if (getEnableSIM5questionsLockIconStatus ==
                        QuestionsPreferencesPageResource.
                        QuestionsPreferences_Page_LockIcon_Status_Value)
                    {
                        //Wait for the element
                        base.WaitForElement(By.Id(QuestionsPreferencesPageResource.
                        QuestionsPreferences_Page_Sim5Questions_LockIcon_Id_Locator));
                        IWebElement getSimRadioButton = base.GetWebElementPropertiesById
                            (QuestionsPreferencesPageResource.
                        QuestionsPreferences_Page_Sim5Questions_LockIcon_Id_Locator);
                        //Click On Lock Icon to Unlock Preference
                        base.ClickByJavaScriptExecutor(getSimRadioButton);                      
                    }
                    //Select 'Enable original Sim Questions' Preference Radiobutton
                    base.SelectRadioButtonById(QuestionsPreferencesPageResource.
                    QuestionsPreferences_Page_OriginalSimQuestions_Radio_Id_Locator);
                }
                //Save Preferences
                generalPreferencesPage.SavePreferences();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Logger Exit
            logger.LogMethodExit("QuestionsPreferencesPage",
            "EnableOriginalSIMQuestionPreference", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable 'Grader Project' Question Type Preference.
        /// </summary>
        public void EnableGraderProjectQuestionTypePreference()
        {
            //Enable 'Grader Project' Question Type Preference
            logger.LogMethodEntry("QuestionsPreferencesPage",
            "EnableGraderProjectQuestionTypePreference", base.isTakeScreenShotDuringEntryExit);
            try
            {
                GeneralPreferencesPage generalPreferencesPage = new GeneralPreferencesPage();
                //Select Window And Frame
                generalPreferencesPage.SelectThePreferenceWindowWithFrame();
                //Wait For 'Grader Project' Question Type Preference Checkbox
                base.WaitForElement(By.Id(QuestionsPreferencesPageResource.
                    QuestionsPreferences_Page_GraderProject_Preference_Id_Locator));
                if (!base.IsElementSelectedById(QuestionsPreferencesPageResource.
                    QuestionsPreferences_Page_GraderProject_Preference_Id_Locator))
                {
                    //Get Lock Icon Status
                    string getGraderProjectQuestionTypeLockIconStatus =
                        base.GetClassAttributeValueById(QuestionsPreferencesPageResource.
                        QuestionsPreferences_Page_GraderProject_LockIcon_Id_Locator);
                    if (getGraderProjectQuestionTypeLockIconStatus ==
                        QuestionsPreferencesPageResource.
                        QuestionsPreferences_Page_LockIcon_Status_Value)
                    {
                        //Click On Lock Icon to Unlock Preference
                        base.ClickButtonByID(QuestionsPreferencesPageResource.
                        QuestionsPreferences_Page_GraderProject_LockIcon_Id_Locator);
                    }
                    //Select 'Grader Project' Question Type Preference Checkbox
                    base.ClickCheckBoxById(QuestionsPreferencesPageResource.
                    QuestionsPreferences_Page_GraderProject_Preference_Id_Locator);
                }
                //Save Preferences
                generalPreferencesPage.SavePreferences();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("QuestionsPreferencesPage",
            "EnableGraderProjectQuestionTypePreference", base.isTakeScreenShotDuringEntryExit);
        }
    }
}
