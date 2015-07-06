using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.SMSIntegration.ProgramManagement;
using Pegasus.Pages.Exceptions;
namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles the action of create program page.
    /// </summary>
    public class ProgramCreatePage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(ProgramCreatePage));

        /// <summary>
        /// Create New Program.
        /// </summary>
        /// <param name="programTypeEnum">This is The Program Type Enum.</param>
        public void CreateNewProgram(Program.ProgramTypeEnum programTypeEnum)
        {
            //Create New Program
            logger.LogMethodEntry("ProgramCreatePage", "CreateNewProgram",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Create New Program Window
                SelectCreateNewProgramWindow();
                //Enter New Program Name
                Guid programGuid = EnterNewProgramName();
                //Select Empty Class
                this.SelectEmptyClassNameBasedOnProgramType(programTypeEnum);
                //Select Program Association Options
                this.SelectOptionsForProgramAssociation();
                //Click To Save The Program
                this.ClickToSaveTheProgram();
                // Save Program Name in Memory
                this.StoreProgramDetailsInMemory(programGuid, programTypeEnum);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ProgramCreatePage", "CreateNewProgram",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter New Program Name.
        /// </summary>
        /// <returns>Program Name Guid.</returns>
        private Guid EnterNewProgramName()
        {
            //Enter New Program Name
            logger.LogMethodEntry("ProgramCreatePage", "EnterNewProgramName",
              base.IsTakeScreenShotDuringEntryExit);
            //Program Name Guid
            Guid programNameGuid = Guid.NewGuid();
            // Enter Program Name
            base.WaitForElement(By.ClassName(ProgramCreatePageResource.
                                                 ProgramCreation_Page_TextField_ClassName_Locator));
            //Fill Text Box
            base.FillTextBoxByClassName(ProgramCreatePageResource.
                                            ProgramCreation_Page_TextField_ClassName_Locator,
                                        programNameGuid.ToString());
            //Wait For Element
            base.WaitForElement(By.Id(ProgramCreatePageResource.
                                          ProgramCreation_Page_EmptyClass_DropDown_Id_Locator));
            logger.LogMethodExit("ProgramCreatePage", "EnterNewProgramName",
                base.IsTakeScreenShotDuringEntryExit);
            return programNameGuid;
        }

        /// <summary>
        /// Select Create New Program Window.
        /// </summary>
        private void SelectCreateNewProgramWindow()
        {
            //Select Create Program Window
            logger.LogMethodEntry("ProgramCreatePage", "SelectCreateNewProgramWindow",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait For Window Loads
            base.WaitUntilWindowLoads(ProgramCreatePageResource.
                                          ProgramCreation_Page_Window_Title_Locator);
            //Select Window
            base.SelectWindow(ProgramCreatePageResource.
                                  ProgramCreation_Page_Window_Title_Locator);
            logger.LogMethodExit("ProgramCreatePage", "SelectCreateNewProgramWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }        

        /// <summary>
        /// Select Empty Class Based on Program Type.
        /// </summary>
        /// <param name="programTypeEnum">This Is Program Type Enum.</param>
        private void SelectEmptyClassNameBasedOnProgramType
            (Program.ProgramTypeEnum programTypeEnum)
        {
            //Selects Empty Class
            logger.LogMethodEntry("ProgramCreatePage", "SelectEmptyClassNameBasedOnProgramType",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Empty Class on Program Type Basis
            switch (programTypeEnum)
            {
                case Program.ProgramTypeEnum.HedCore:
                case Program.ProgramTypeEnum.HedMil:
                    {
                        //Get the Empty Class from Memory
                        Course getEmptyHedClass = Course.Get(Course.CourseTypeEnum.HedEmptyClass);
                        //Select Empty Class
                        base.SelectDropDownValueThroughTextById(ProgramCreatePageResource.
                            ProgramCreation_Page_EmptyClass_DropDown_Id_Locator,
                            getEmptyHedClass.Name);
                        break;
                    }                
                case Program.ProgramTypeEnum.PromotedAdminDigitalPathProgram:
                case Program.ProgramTypeEnum.DigitalPath:
                    {
                        //Select Empty Class
                        base.SelectDropDownValueThroughTextById(ProgramCreatePageResource.
                            ProgramCreation_Page_EmptyClass_DropDown_Id_Locator,
                            ProgramCreatePageResource.ProgramCreation_Page_DPEmptyClass_Value);
                        break;
                    }
                case Program.ProgramTypeEnum.NovaNET:
                   {
                        //Get the Empty Class from Memory
                        Course getEmptyClass = Course.Get(Course.CourseTypeEnum.EmptyClass);
                        //Select Empty Class
                        base.SelectDropDownValueThroughTextById(ProgramCreatePageResource.
                            ProgramCreation_Page_EmptyClass_DropDown_Id_Locator,
                            getEmptyClass.Name);
                        break;
                    }
            }
            logger.LogMethodExit("ProgramCreatePage", "SelectEmptyClassNameBasedOnProgramType",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click CheckBoxes For Program Assocoiation To Users.
        /// </summary>
        private void SelectOptionsForProgramAssociation()
        {
            // Four Check Box to be Check After Empty Class Selection
            logger.LogMethodEntry("ProgramCreatePage", "SelectOptionsForProgramAssociation",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(ProgramCreatePageResource.
                ProgramCreation_Page_EnablePrgAssociationToAdmin_CheckBox_Id_Locator));
            //Get Checkbox Property
            IWebElement getEnablePrgAssociationToAdminCheckBoxProperty = base.GetWebElementPropertiesById
                (ProgramCreatePageResource.ProgramCreation_Page_EnablePrgAssociationToAdmin_CheckBox_Id_Locator);
            //Click Checkbox For Associating Program To Admin
            base.ClickByJavaScriptExecutor(getEnablePrgAssociationToAdminCheckBoxProperty);
            //Get Checkbox Property
            IWebElement getEnablePrgAssociationToTechCheckBoxProperty = base.GetWebElementPropertiesById
                (ProgramCreatePageResource.ProgramCreation_Page_EnablePrgAssociationToTech_CheckBox_Id_Locator);
            //Click Checkbox For Associating Program To Teacher
            base.ClickByJavaScriptExecutor(getEnablePrgAssociationToTechCheckBoxProperty);
            //Wait For Element
            base.WaitForElement(By.Id(ProgramCreatePageResource.
                ProgramCreation_Page_EnableTeachBadgeView_CheckBox_Id_Locator));
            //Get Checkbox Property
            IWebElement getEnableTeachBadgeViewCheckBoxProperty = base.GetWebElementPropertiesById
                (ProgramCreatePageResource.ProgramCreation_Page_EnableTeachBadgeView_CheckBox_Id_Locator);
            //Click Checkbox To Enable Teacher Badge View
            base.ClickByJavaScriptExecutor(getEnableTeachBadgeViewCheckBoxProperty);
            if (!base.IsElementSelectedById(ProgramCreatePageResource.
                ProgramCreation_Page_EnableTeachBadgeView_CheckBox_Id_Locator))
            {
                //Click Checkbox To Enable Teacher Badge View
                base.ClickByJavaScriptExecutor(getEnableTeachBadgeViewCheckBoxProperty);
            }
            //Get Checkbox Property
            IWebElement getEnableStdManagementCheckBoxProperty = base.GetWebElementPropertiesById
                (ProgramCreatePageResource.ProgramCreation_Page_EnableStdManagement_CheckBox_Id_Locator);
            //Click Checkbox To Enable Student Management
            base.ClickByJavaScriptExecutor(getEnableStdManagementCheckBoxProperty);
            logger.LogMethodExit("ProgramCreatePage", "SelectOptionsForProgramAssociation",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On 'Save' Button of the Program.
        /// </summary>
        private void ClickToSaveTheProgram()
        {
            // Save The Program
            logger.LogMethodEntry("ProgramCreatePage", "ClickToSaveTheProgram",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait For The Save Button
            base.WaitForElement(By.Id(ProgramCreatePageResource.
                ProgramCreation_Page_Save_Button_Id_Locator));
            //Get Save Button Property
            IWebElement getButtonProperty = base.GetWebElementPropertiesById
                (ProgramCreatePageResource.ProgramCreation_Page_Save_Button_Id_Locator);
            //Click Save Button
            base.ClickByJavaScriptExecutor(getButtonProperty);
            logger.LogMethodExit("ProgramCreatePage", "ClickToSaveTheProgram",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save Program in memory.
        /// </summary>
        /// <param name="programNameGuid">This is Program Name Guid.</param>
        /// /// <param name="programTypeEnum">This Is Program Type Enum.</param>
        private void StoreProgramDetailsInMemory
            (Guid programNameGuid, Program.ProgramTypeEnum programTypeEnum)
        {
            //Stores Program in Memory
            logger.LogMethodEntry("ProgramCreatePage", "StoreProgramDetailsInMemory",
                                  base.IsTakeScreenShotDuringEntryExit);
            Program program = new Program
                {
                    //Program Details
                    Name = programNameGuid.ToString(),
                    ProgramType = programTypeEnum,
                    IsCreated = true,
                };
            program.StoreProgramInMemory();
            logger.LogMethodExit("ProgramCreatePage", "StoreProgramDetailsInMemory",
                        base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
