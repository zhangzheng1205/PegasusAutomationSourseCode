using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Gradebook;
using Pegasus.Pages.UI_Pages;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles GBGroupsDefaultUXPage Page Actions
    /// </summary>
     public class GBGroupsDefaultUXPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
         private static readonly Logger logger = Logger.GetInstance(typeof(GBGroupsDefaultUXPage));
         
         /// <summary>
         /// Create Group.
         /// </summary>        
         public void CreateGroup()
         {
             //Create Group
             logger.LogMethodEntry("GBGroupsDefaultUXPage",
                 "CreateGroup",
                 base.isTakeScreenShotDuringEntryExit);             
             try
             {
                 //Select Window And Frame
                 this.SelectWindowAndFrame();
                 base.WaitForElement(By.PartialLinkText(GBGroupsDefaultUXPageResource.
                     GBGroupsDefaultUX_Page_CreateGroup_Button_Id_Locator));
                 //Click On Create Group Button
                 base.ClickButtonByPartialLinkText(GBGroupsDefaultUXPageResource.
                     GBGroupsDefaultUX_Page_CreateGroup_Button_Id_Locator);
                 base.WaitUntilWindowLoads(GBGroupsDefaultUXPageResource.
                     GBGroupsDefaultUX_Page_CreateGroup_Window_Title);
                 base.SelectWindow(GBGroupsDefaultUXPageResource.
                     GBGroupsDefaultUX_Page_CreateGroup_Window_Title);
                 //Enter Group Name
                 base.WaitForElement(By.Id(GBGroupsDefaultUXPageResource.
                     GBGroupsDefaultUX_Page_GroupName_Textbox_Id_Locator));
                 base.FillTextBoxByID(GBGroupsDefaultUXPageResource.
                     GBGroupsDefaultUX_Page_GroupName_Textbox_Id_Locator,
                     GBGroupsDefaultUXPageResource.GBGroupsDefaultUX_Page_GroupName_Value);
                 base.WaitForElement(By.Id(GBGroupsDefaultUXPageResource.
                     GBGroupsDefaultUX_Page_SaveButton_Id__Locator));
                 //Click On Save Button
                 base.ClickButtonByID(GBGroupsDefaultUXPageResource.
                     GBGroupsDefaultUX_Page_SaveButton_Id__Locator);
             }
             catch (Exception e)
             {
                 ExceptionHandler.HandleException(e);
             }
             logger.LogMethodExit("GBGroupsDefaultUXPage",
                 "CreateGroup",
                 base.isTakeScreenShotDuringEntryExit);
         }

         /// <summary>
         /// Select Window And Frame.
         /// </summary>
         private void SelectWindowAndFrame()
         {
             //Select Window And Frame
             logger.LogMethodEntry("GBGroupsDefaultUXPage",
                 "SelectWindowAndFrame",
                 base.isTakeScreenShotDuringEntryExit);
             //Select Window
             base.WaitUntilWindowLoads(GBGroupsDefaultUXPageResource.
                 GBGroupsDefaultUX_Page_ManageGroups_Window_Title);
             base.SelectWindow(GBGroupsDefaultUXPageResource.
                 GBGroupsDefaultUX_Page_ManageGroups_Window_Title);
             //Select Frame
             base.WaitForElement(By.ClassName(GBGroupsDefaultUXPageResource.
                 GBGroupsDefaultUX_Page_Frame_Id_Locator));
             base.SwitchToIFrame(GBGroupsDefaultUXPageResource.
                 GBGroupsDefaultUX_Page_Frame_Id_Locator);
             logger.LogMethodExit("GBGroupsDefaultUXPage",
                 "SelectWindowAndFrame",
                 base.isTakeScreenShotDuringEntryExit);
         }

         /// <summary>
         /// Enroll Student To Group.
         /// </summary>
         public void EnrollStudentToGroup()
         {
             //Enroll Student To Group
             logger.LogMethodEntry("GBGroupsDefaultUXPage",
                 "EnrollStudentToGroup",
                 base.isTakeScreenShotDuringEntryExit);
             try
             {
                 //Select Window Frame And Click On Group.
                 this.SelectWindowFrameAndClickOnGroup();
                 //Get User Count
                 int getUserCount = base.GetElementCountByXPath(GBGroupsDefaultUXPageResource.
                     GBGroupsDefaultUX_Page_UserCount_Xpath_Locator);
                 for (int rowCount = Convert.ToInt32(GBGroupsDefaultUXPageResource.
                     GBGroupsDefaultUX_Page_Loop_Initializer_Value);
                     rowCount <= getUserCount; rowCount++)
                 {

                     base.WaitForElement(By.XPath(string.Format(GBGroupsDefaultUXPageResource.
                         GBGroupsDefaultUX_Page_UserText_Xpath_Locator, rowCount)));
                     //Get User Text
                     string getUserText = base.GetElementTextByXPath(
                         string.Format(GBGroupsDefaultUXPageResource.
                         GBGroupsDefaultUX_Page_UserText_Xpath_Locator, rowCount));
                     if (getUserText == GBGroupsDefaultUXPageResource.
                         GBGroupsDefaultUX_Page_User_Name_Value)
                     {
                         base.WaitForElement(By.XPath(string.Format(GBGroupsDefaultUXPageResource.
                             GBGroupsDefaultUX_Page_UserCheckbox_Xpath_Locator, rowCount)));
                         //Select User Checkbox
                         base.SelectCheckBoxByXPath(string.Format(GBGroupsDefaultUXPageResource.
                             GBGroupsDefaultUX_Page_UserCheckbox_Xpath_Locator, rowCount));
                         base.SelectWindow(GBGroupsDefaultUXPageResource.
                             GBGroupsDefaultUX_Page_ManageGroups_Window_Title);
                         base.WaitForElement(By.Id(GBGroupsDefaultUXPageResource.
                             GBGroupsDefaultUX_Page_Add_Button_Id_Locator));
                         //Click On Add Button
                         base.ClickButtonByID(GBGroupsDefaultUXPageResource.
                             GBGroupsDefaultUX_Page_Add_Button_Id_Locator);
                         break;
                     }
                 }
             }
             catch (Exception e)
             {
                 ExceptionHandler.HandleException(e);
             }
             logger.LogMethodExit("GBGroupsDefaultUXPage",
                 "EnrollStudentToGroup",
                 base.isTakeScreenShotDuringEntryExit);
         }

         /// <summary>
         /// Select Window Frame And Click On Group.
         /// </summary>
         private void SelectWindowFrameAndClickOnGroup()
         {
             //Select Window Frame And Click On Group
             logger.LogMethodEntry("GBGroupsDefaultUXPage",
                 "SelectWindowFrameAndClickOnGroup",
                 base.isTakeScreenShotDuringEntryExit);
             //Select Window And Frame
             this.SelectWindowAndFrame();
             base.WaitForElement(By.XPath(GBGroupsDefaultUXPageResource.
                 GBGroupsDefaultUX_Page_GroupName_Xpath_Locator));
             //Click On Group Name
             base.ClickLinkByXPath(GBGroupsDefaultUXPageResource.
                 GBGroupsDefaultUX_Page_GroupName_Xpath_Locator);
             base.WaitUntilWindowLoads(GBGroupsDefaultUXPageResource.
                 GBGroupsDefaultUX_Page_ManageGroups_Window_Title);
             //Select Enrollments Window
             base.SelectWindow(GBGroupsDefaultUXPageResource.
                 GBGroupsDefaultUX_Page_ManageGroups_Window_Title);
             base.WaitForElement(By.ClassName(GBGroupsDefaultUXPageResource.
                 GBGroupsDefaultUX_Page_Roster_Frame_Id_Locator));
             base.SwitchToIFrame(GBGroupsDefaultUXPageResource.
                 GBGroupsDefaultUX_Page_Roster_Frame_Id_Locator);
             logger.LogMethodExit("GBGroupsDefaultUXPage",
                "SelectWindowFrameAndClickOnGroup",
                base.isTakeScreenShotDuringEntryExit);
         }

         /// <summary>
         /// Click On ViewFilters Link In Gradebook.
         /// </summary>
         public void ClickOnViewFiltersLinkInGradebook()
         {
             //Click On ViewFilters Link In Gradebook
             logger.LogMethodEntry("GBGroupsDefaultUXPage",
                 "ClickOnViewFiltersLinkInGradebook",
                 base.isTakeScreenShotDuringEntryExit);
             try
             {
                 //Select Gradebook Window
                 this.SelectGradebookWindow();                
                 //Wait for the element
                 base.WaitForElement(By.Id(GBGroupsDefaultUXPageResource.
                     GBGroupsDefaultUX_Page_Select_Student_Link_Id_Locator));
                 IWebElement getStudentLink=base.GetWebElementPropertiesById
                     (GBGroupsDefaultUXPageResource.
                     GBGroupsDefaultUX_Page_Select_Student_Link_Id_Locator);
                 base.ClickByJavaScriptExecutor(getStudentLink);
                 //Wait for the element
                 base.WaitForElement(By.Id(GBGroupsDefaultUXPageResource.
                     GBGroupsDefaultUX_Page_SelectStudent_RedioBtn_Id_Locator));
                 IWebElement getSelectStudentRedioButton = base.GetWebElementPropertiesById
                     (GBGroupsDefaultUXPageResource.
                     GBGroupsDefaultUX_Page_SelectStudent_RedioBtn_Id_Locator);
                 base.ClickByJavaScriptExecutor(getSelectStudentRedioButton);                 
             }
             catch (Exception e)
             {
                 ExceptionHandler.HandleException(e);
             }
             logger.LogMethodExit("GBGroupsDefaultUXPage",
                "ClickOnViewFiltersLinkInGradebook",
                base.isTakeScreenShotDuringEntryExit);
         }

         /// <summary>
         /// Click Vieew Filters Link.
         /// </summary>
         private void ClickVieewFiltersLink()
         {
             //Click Vieew Filters Link
             logger.LogMethodEntry("GBGroupsDefaultUXPage",
                 "ClickVieewFiltersLink",
                 base.isTakeScreenShotDuringEntryExit);            
             //Wait for the element
             base.WaitForElement(By.Id(GBGroupsDefaultUXPageResource.
                 GBGroupsDefaultUX_Page_ViewFilter_Link_Id_Locator));
             IWebElement getViewFiltersLink = base.GetWebElementPropertiesById
                 (GBGroupsDefaultUXPageResource.
                 GBGroupsDefaultUX_Page_ViewFilter_Link_Id_Locator);
             //Click the 'View Filters' link
             base.ClickByJavaScriptExecutor(getViewFiltersLink);
             logger.LogMethodExit("GBGroupsDefaultUXPage",
                "ClickVieewFiltersLink",
                base.isTakeScreenShotDuringEntryExit);
         }

         /// <summary>
         /// Select Gradebook Window.
         /// </summary>
         private void SelectGradebookWindow()
         {
             //Select Gradebook Window
             logger.LogMethodEntry("GBGroupsDefaultUXPage",
                 "SelectGradebookWindow",
                 base.isTakeScreenShotDuringEntryExit);
             //Select the window
             base.WaitUntilWindowLoads(GBGroupsDefaultUXPageResource.
                 GBGroupsDefaultUX_Page_Gradebook_WindowName);
             base.SelectWindow(GBGroupsDefaultUXPageResource.
                 GBGroupsDefaultUX_Page_Gradebook_WindowName);
             logger.LogMethodExit("GBGroupsDefaultUXPage",
                "SelectGradebookWindow",
                base.isTakeScreenShotDuringEntryExit);
         }

         /// <summary>
         ///Search Student In Gradebook.
         /// </summary>
         /// <param name="userName">This is User Name.</param>
         public void SearchStudentInGradebook(string userName)
         {
             //Search Student In Gradebook
             logger.LogMethodEntry("GBGroupsDefaultUXPage",
                 "SearchStudentInGradebook",
                 base.isTakeScreenShotDuringEntryExit);
             try
             {
                 //Select Gradebook Window
                 this.SelectGradebookWindow();
                 base.SwitchToIFrameById(GBGroupsDefaultUXPageResource.
                     GBGroupsDefaultUX_Page_SearchStudent_Frame);
                 //Wait for the element
                 base.WaitForElement(By.Id(GBGroupsDefaultUXPageResource.
                     GBGroupsDefaultUX_Page_SearchStudent_RedioButton_Id_Locator));
                 IWebElement getSearchStudent = base.GetWebElementPropertiesById
                     (GBGroupsDefaultUXPageResource.
                     GBGroupsDefaultUX_Page_SearchStudent_RedioButton_Id_Locator);
                 base.ClickByJavaScriptExecutor(getSearchStudent);
                 //Fill The Student Name In Search TextBox
                 this.FillTheStudentNameInSearchTextBox(userName);
                 //Click On Search Button
                 this.ClickOnSearchButton();
             }
             catch (Exception e)
             {
                 ExceptionHandler.HandleException(e);
             }
             logger.LogMethodExit("GBGroupsDefaultUXPage",
                "SearchStudentInGradebook",
                base.isTakeScreenShotDuringEntryExit);
         }

         /// <summary>
         /// Click On Search Button.
         /// </summary>
         private void ClickOnSearchButton()
         {
             //Click On Search Button
             //Fill The Student Name In Search TextBox
             logger.LogMethodEntry("GBGroupsDefaultUXPage",
                 "ClickOnSearchButton",
                 base.isTakeScreenShotDuringEntryExit);
             //Wait for the element
             base.WaitForElement(By.Id(GBGroupsDefaultUXPageResource.
                 GBGroupsDefaultUX_Page_Search_Button_Id_Locator));
             IWebElement getSaveButton = base.GetWebElementPropertiesById
                 (GBGroupsDefaultUXPageResource.
                 GBGroupsDefaultUX_Page_Search_Button_Id_Locator);
             //Click on 'Search' button
             base.ClickByJavaScriptExecutor(getSaveButton);
             logger.LogMethodExit("GBGroupsDefaultUXPage",
               "ClickOnSearchButton",
               base.isTakeScreenShotDuringEntryExit);
         }

         /// <summary>
         /// Fill The Student Name In Search TextBox.
         /// </summary>
         /// <param name="userName">This is User Name.</param>
         private void FillTheStudentNameInSearchTextBox(string userName)
         {
             //Fill The Student Name In Search TextBox
             logger.LogMethodEntry("GBGroupsDefaultUXPage",
                 "FillTheStudentNameInSearchTextBox",
                 base.isTakeScreenShotDuringEntryExit);
             //Wait for the element
             base.WaitForElement(By.Id(GBGroupsDefaultUXPageResource.
                 GBGroupsDefaultUX_Page_SearchStudent_TextBox_Id_Locator));
             base.FocusOnElementByID(GBGroupsDefaultUXPageResource.
                 GBGroupsDefaultUX_Page_SearchStudent_TextBox_Id_Locator);
             //Clear the text box
             base.GetWebElementPropertiesById(GBGroupsDefaultUXPageResource.
                 GBGroupsDefaultUX_Page_SearchStudent_TextBox_Id_Locator).Clear();
             //Fill the textbox with user name
             base.FillTextBoxByID(GBGroupsDefaultUXPageResource.
                 GBGroupsDefaultUX_Page_SearchStudent_TextBox_Id_Locator, userName);
             logger.LogMethodExit("GBGroupsDefaultUXPage",
                "FillTheStudentNameInSearchTextBox",
                base.isTakeScreenShotDuringEntryExit);
         }

         /// <summary>
         /// Click On Show Status for All Item Filter Option.
         /// </summary>
         public void ClickOnShowStatusforAllItemFilterOption()
         {
             //Click On Show Status for All Item Filter Option
             logger.LogMethodEntry("GBGroupsDefaultUXPage",
                 "ClickOnShowStatusforAllItemFilterOption",
                 base.isTakeScreenShotDuringEntryExit);
             try
             {
                 //Select the window
                 this.SelectGradebookWindow();
                 //Wait for the element
                 base.WaitForElement(By.Id(GBGroupsDefaultUXPageResource.
                     GBGroupsDefaultUX_Page_ShowAllItem_Id_Locator));
                 IWebElement getShowAllItems = base.GetWebElementPropertiesById
                     (GBGroupsDefaultUXPageResource.
                     GBGroupsDefaultUX_Page_ShowAllItem_Id_Locator);
                 base.ClickByJavaScriptExecutor(getShowAllItems);
             }
             catch (Exception e)
             {
                 ExceptionHandler.HandleException(e);
             }
             logger.LogMethodExit("GBGroupsDefaultUXPage",
                "ClickOnShowStatusforAllItemFilterOption",
                base.isTakeScreenShotDuringEntryExit);
         }

         /// <summary>
         /// Click On Assignment Types Link In Gradebook.
         /// </summary>
         public void ClickOnAssignmentTypesLinkInGradebook()
         {
             //Click On Assignment Types Link In Gradebook.
             logger.LogMethodEntry("GBGroupsDefaultUXPage",
                 "ClickOnAssignmentTypesLinkInGradebook",
                 base.isTakeScreenShotDuringEntryExit);
             try
             {
                 //Select the window
                 this.SelectGradebookWindow();
                 //Wait for the element
                 base.WaitForElement(By.Id(GBGroupsDefaultUXPageResource.
                     GBGroupsDefaultUX_Page_AssignmentType_Link_Id_Locator));
                 IWebElement getAssignmentTypes = base.GetWebElementPropertiesById
                     (GBGroupsDefaultUXPageResource.
                     GBGroupsDefaultUX_Page_AssignmentType_Link_Id_Locator);
                 //Click th 'Assignment Types' link
                 base.ClickByJavaScriptExecutor(getAssignmentTypes);
             }
             catch (Exception e)
             {
                 ExceptionHandler.HandleException(e);
             }
             logger.LogMethodExit("GBGroupsDefaultUXPage",
                "ClickOnAssignmentTypesLinkInGradebook",
                base.isTakeScreenShotDuringEntryExit);
         }

         /// <summary>
         /// Select Assignment Type In Gradebook.
         /// </summary>
         /// <param name="assignmentType">This is Assignment Type.</param>
         public void SelectAssignmentTypeInGradebook(string assignmentType)
         {
             //Select Assignment Type In Gradebook.
             logger.LogMethodEntry("GBGroupsDefaultUXPage",
                "SelectAssignmentTypeInGradebook",
                  base.isTakeScreenShotDuringEntryExit);
             //Initialize VariableVariable
             string getAssignmentTypeName = string.Empty;
             try
             {
                 //Initialize VariableVariable
                 int assignmentTypeColumnNumber = Convert.ToInt32(GBInstructorUXPageResource.
                     GBInstructorUX_Page_Initial_Count_Value);
                 //Getting the counts of Activity                    
                 int getAssignmentTypeCount = base.GetElementCountByXPath(
                     GBGroupsDefaultUXPageResource.
                     GBGroupsDefaultUX_Page_AssignmentType_TotalCount_Xpath_Locator);
                 for (int columnCount = Convert.ToInt32(GBInstructorUXPageResource.
                     GBInstructorUX_Page_Initial_Value); columnCount <= getAssignmentTypeCount;
                     columnCount++)
                 {
                    //Wait for Element
                    base.WaitForElement(By.XPath(string.Format(GBGroupsDefaultUXPageResource.
                       GBGroupsDefaultUX_Page_AssignmentType_Name_Xpath_Locator, columnCount)));
                    //Getting the Assignment Type Name
                    getAssignmentTypeName = base.GetElementTextByXPath
                     (string.Format(GBGroupsDefaultUXPageResource.
                      GBGroupsDefaultUX_Page_AssignmentType_Name_Xpath_Locator, columnCount));
                    if (getAssignmentTypeName == assignmentType)
                    {
                         //Select Assignment Type Checkbox
                         this.SelectAssignmentTypeCheckbox(columnCount);
                         break;
                    }
                 }
             }
             catch (Exception e)
             {
                 ExceptionHandler.HandleException(e);
             }
             logger.LogMethodExit("GBGroupsDefaultUXPage",
               "SelectAssignmentTypeInGradebook",
                 base.isTakeScreenShotDuringEntryExit);
         }

         /// <summary>
         /// Select Assignment Type Checkbox.
         /// </summary>
         /// <param name="columnCount">This is Column Count.</param>
         private void SelectAssignmentTypeCheckbox(int columnCount)
         {
             //Select Assignment Type Checkbox
             logger.LogMethodEntry("GBGroupsDefaultUXPage",
                "SelectAssignmentTypeCheckbox",
                   base.isTakeScreenShotDuringEntryExit);
             //Wait for the element
             base.WaitForElement(By.XPath(string.Format(GBGroupsDefaultUXPageResource.
             GBGroupsDefaultUX_Page_AssignmentType_Checkbox_Xpath_Locator,
             columnCount)));
             IWebElement getAssignmentTypeCheckbox = base.GetWebElementPropertiesByXPath
                 (string.Format(GBGroupsDefaultUXPageResource.
             GBGroupsDefaultUX_Page_AssignmentType_Checkbox_Xpath_Locator, columnCount));
             //Click the 'Assignment Type' checkbox
             base.ClickByJavaScriptExecutor(getAssignmentTypeCheckbox);
             logger.LogMethodExit("GBGroupsDefaultUXPage",
               "SelectAssignmentTypeCheckbox",
                  base.isTakeScreenShotDuringEntryExit);
         }
    }
}
