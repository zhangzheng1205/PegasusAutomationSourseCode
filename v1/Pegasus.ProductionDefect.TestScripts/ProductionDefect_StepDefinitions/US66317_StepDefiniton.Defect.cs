using System;
using System.Threading;
using Framework.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Library;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Calendar;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.ProgramAdmin.CourseTemplates;
using TechTalk.SpecFlow;

namespace Pegasus.ProductionDefect.TestScripts.ProductionDefect_StepDefinitions
{
    [Binding]
    public class US66317StepDefinitonDefect : BaseTestScript
    {
        // Purpose: Calling Methods From Page Class
        readonly DrtDefaultUxPage _editStudy = new DrtDefaultUxPage();
        readonly ManageTemplatePage _manageTemplateHed = new ManageTemplatePage();

        //Purpose: Step Definition for Create The Authored Course Copy
        [Given(@"Authored course copy already created if not then create the authored course copy")]
        public void GivenAuthoredCourseCopyAlreadyCreatedIfNotThenCreateTheAuthoredCourseCopy()
        {
            try
            {
                string isCourseAlreadyCopied = DatabaseTools.GetCourse(Enumerations.CourseType.MySpanishLabMasterCourse);
                if (isCourseAlreadyCopied == null)
                {
                    //Purpose: Steps To Create Test Data
                    GenericTestStep.StepToBrowsedUrlForPegasusUser("HED WS Admin");
                    GenericTestStep.StepToLoggedIntoTheWorkspaceAsHedWsAdmin();
                    GenericTestStep.StepToItShouldBeOnPage("Course Enrollment");
                    GenericTestStep.StepToIAmOnTheUserCreationPage();
                    GenericTestStep.StepToSelectTheCourse("MySpanishLab AuthoredCourse");
                    GenericTestStep.StepToClickOnTheCmenuOfCourse();
                    GenericTestStep.StepToClickOnTheCourseCMenuOptionLink("Copy as Master Course");
                    GenericTestStep.StepToIShouldSeeTheNewPopup("Copy as Master Course");
                    GenericTestStep.StepToCopyTheCourseInSameWorkspace("Master");
                    GenericTestStep.StepToItShouldDisplaySuccessfulMessage("Copied as master course.");
                    GenericTestStep.StepToWaitForTheCourseOutFromAssignToCopyState();
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: Step Definition for Publish The Authored Copied Course
        [Given(@"Authored course copy is already published if not then publish the authored course copy")]
        public void GivenAuthoredCourseCopyIsAlreadyPublishedIfNotThenPublishTheAuthoredCourseCopy()
        {
            try
            {
                //Purpose: Steps To Create Test Data
                string isCourseAlreadyPublished = DatabaseTools.GetCoursePublishStatus(Enumerations.CourseType.MySpanishLabMasterCourse);
                if (isCourseAlreadyPublished == null || isCourseAlreadyPublished.Equals("False") || isCourseAlreadyPublished.Equals(""))
                {
                    string getCopiedCourse = DatabaseTools.GetCourse(Enumerations.CourseType.MySpanishLabMasterCourse);
                    if (getCopiedCourse == null) throw new ArgumentNullException("getCo" + "piedCourse is null");
                    GenericTestStep.StepToBrowsedUrlForPegasusUser("HED WS Admin");
                    GenericTestStep.StepToLoggedIntoTheWorkspaceAsHedWsAdmin();
                    GenericTestStep.StepToItShouldBeOnPage("Course Enrollment");
                    GenericTestStep.StepToSelectTheCourse("MySpanishLab Authored Master Course");
                    GenericTestStep.StepToClickOnTheCmenuOfCourse();
                    GenericTestStep.StepToClickOnTheCourseCMenuOptionLink("Publish Master Course");
                    GenericTestStep.StepToIShouldSeeTheNewPopup("Publishing Notes");
                    GenericTestStep.StepToEnterThePublishingNotes();
                    GenericTestStep.StepToClickOnThePublishButton();
                    GenericTestStep.StepToItShouldDisplaySuccessfulMessage("Course published successfully.");
                    DatabaseTools.UpdateCoursePublishStatusTrue(getCopiedCourse);
                    GenericTestStep.StepToClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: Step Definition for Approving The Authored Copied Course in Course Space
        [Given(@"Autohored course is already approved in the course space if not then approve the authored course in course space")]
        public void GivenAutohoredCourseIsAlreayApprovedInTheCourseSpaceIfNotThenApproveTheAuthoredCourseInCourseSpace()
        {
            try
            {
                //Purpose: Steps To Create Test Data
                string isCourseAlreadyApproved = DatabaseTools.GetCourseApproveStatus(Enumerations.CourseType.MySpanishLabMasterCourse);
                if (isCourseAlreadyApproved == null || isCourseAlreadyApproved.Equals("False") || isCourseAlreadyApproved.Equals(""))
                {
                    string getCopiedCourse = DatabaseTools.GetCourse(Enumerations.CourseType.MySpanishLabMasterCourse);
                    GenericTestStep.StepToBrowsedUrlForPegasusUser("HED CS Admin");
                    GenericTestStep.StepToLoggedIntoTheCourseSpaceAsHedCSAdmin();
                    GenericTestStep.StepToItShouldBeOnPage("Course Enrollment");
                    GenericTestStep.StepToNavigateToTheTab("Publishing");
                    GenericTestStep.StepToSwitchToTheTab("Manage Products");
                    GenericTestStep.StepToItShouldShowTheManageProductsPage();
                    GenericTestStep.StepToSelectTheCourseToApprove("MySpanishLab Master Course");
                    GenericTestStep.StepToClickedOnTheApproveCourseLink("Approve");
                    GenericTestStep.StepToItShouldDisplaySuccessfulMessage("Published course marked as Approved.");
                    DatabaseTools.UpdateCourseApproveStatusTrue(getCopiedCourse);
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: Step Definition for Creation of HED Program
        [Given(@"HED program is already created if not then create the HED program")]
        public void GivenHEDProgramIsAlreadyCreatedIfNotThenCreateTheHEDProgram()
        {
            try
            {
                string isProgramAlreadyCreated = DatabaseTools.GetProgram(Enumerations.ProgramInstance.HedCore);
                if (isProgramAlreadyCreated == null || isProgramAlreadyCreated.Equals("False") || isProgramAlreadyCreated.Equals(""))
                {
                    GenericTestStep.StepToBrowsedUrlForPegasusUser("HED CS Admin");
                    GenericTestStep.StepToLoggedIntoTheCourseSpaceAsHedCSAdmin();
                    GenericTestStep.StepToItShouldShowTheManageProgramsPage();
                    GenericTestStep.StepToClickTheCreateNewProgramLink();
                    GenericTestStep.StepToCreateHedProgram();
                    GenericTestStep.StepToItShouldDisplaySuccessfulMessage("Program created successfully.");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: Step Definition for Creation General Type Product
        [Given(@"HED general type product is already created if not then create a new general type product")]
        public void GivenHEDGeneralTypeProductIsAlreadyCreatedIfNotThenCreateANewGeneralTypeProduct()
        {
            try
            {
                string isProductAlreadyCreated = DatabaseTools.GetProduct(Enumerations.ProductInstance.HedCoreGeneral);
                if (isProductAlreadyCreated == null || isProductAlreadyCreated.Equals("False") || isProductAlreadyCreated.Equals(""))
                {
                    GenericTestStep.StepToBrowsedUrlForPegasusUser("HED CS Admin");
                    GenericTestStep.StepToLoggedIntoTheCourseSpaceAsHedCSAdmin();
                    GenericTestStep.StepToItShouldShowTheManageProductsPage();
                    GenericTestStep.StepToClickTheCreateNewProductLink();
                    GenericTestStep.StepToCreateHedGeneralTypeProduct("HedCoreGeneral");
                    GenericTestStep.StepToItShouldDisplaySuccessfulMessage("New product created successfully.");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: Step Definition for Creation Program Type Product
        [Given(@"Program type product is already created if not then create a new program type product")]
        public void GivenProgramTypeProductIsAlreadyCreatedIfNotThenCreateANewProgramTypeProduct()
        {
            try
            {
                string isProductAlreadyCreated = DatabaseTools.GetProduct(Enumerations.ProductInstance.HedCoreProgram);
                if (isProductAlreadyCreated == null || isProductAlreadyCreated.Equals("False") || isProductAlreadyCreated.Equals(""))
                {
                    GenericTestStep.StepToBrowsedUrlForPegasusUser("HED CS Admin");
                    GenericTestStep.StepToLoggedIntoTheCourseSpaceAsCSAdmin();
                    GenericTestStep.StepToItShouldShowTheManageProductsPage();
                    GenericTestStep.StepToClickTheCreateNewProductLink();
                    GenericTestStep.StepToCreateHedGeneralTypeProduct("HedCoreProgram");
                    GenericTestStep.StepToItShouldDisplaySuccessfulMessage("New product created successfully.");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }

        }

        //Purpose: Step Definition for Course Association to General Type Product
        [Given(@"Course association to general type product is already created if not then create association")]
        public void GivenCourseAssociationToGeneralTypeProductIsAlreadyCreatedIfNotThenCreateAssociation()
        {
            try
            {
                string productName = DatabaseTools.GetProduct(Enumerations.ProductInstance.HedCoreGeneral);
                string isMasterCourseAlreadyAssociatedToProduct = DatabaseTools.GetProductMaterCourseAssociatedStatus(productName);
                if (isMasterCourseAlreadyAssociatedToProduct == null || isMasterCourseAlreadyAssociatedToProduct.Equals("False") || isMasterCourseAlreadyAssociatedToProduct.Equals(""))
                {
                    GenericTestStep.StepToBrowsedUrlForPegasusUser("HED CS Admin");
                    GenericTestStep.StepToLoggedIntoTheCourseSpaceAsHedCSAdmin();
                    GenericTestStep.StepToItShouldShowTheManageProductsPage();
                    GenericTestStep.StepToSelectCourseInManageProductsPage("MySpanishLab Master Course");
                    GenericTestStep.StepToSelectTheProductInTheRightFrame("HedCoreGeneral");
                    GenericTestStep.StepToAssociateTheCourseToProduct();
                    GenericTestStep.StepToItShouldDisplaySuccessfulMessage("Approved courses programmed successfully.");
                    DatabaseTools.UpdateProductMaterCourseAssociatedStatus(productName);
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: Step Definition for Course association to Program Type Product
        [Given(@"Course association to program type product is already created if not then create association")]
        public void GivenCourseAssociationToProgramTypeProductIsAlreadyCreatedIfNotThenCreateAssociation()
        {
            try
            {
                string productName = DatabaseTools.GetProduct(Enumerations.ProductInstance.HedCoreProgram);
                string isMasterCourseAlreadyAssociatedToProduct = DatabaseTools.GetProductMaterCourseAssociatedStatus(productName);
                if (isMasterCourseAlreadyAssociatedToProduct == null || isMasterCourseAlreadyAssociatedToProduct.Equals("False") || isMasterCourseAlreadyAssociatedToProduct.Equals(""))
                {
                    GenericTestStep.StepToBrowsedUrlForPegasusUser("HED CS Admin");
                    GenericTestStep.StepToLoggedIntoTheCourseSpaceAsHedCSAdmin();
                    GenericTestStep.StepToItShouldShowTheManageProductsPage();
                    GenericTestStep.StepToSelectCourseInManageProductsPage("MySpanishLab Master Course");
                    GenericTestStep.StepToSelectTheProductInTheRightFrame("HedCoreProgram");
                    GenericTestStep.StepToAssociateTheCourseToProduct();
                    GenericTestStep.StepToItShouldDisplaySuccessfulMessage("Approved courses programmed successfully.");
                    DatabaseTools.UpdateProductMaterCourseAssociatedStatus(productName);
                    GenericTestStep.StepToIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: Step Definition for Creation of SMS User(s)
        [Given(@"SMS user is already created if not then create SMS user")]
        public void GivenSMSUserIsAlreadyCreatedIfNotThenCreateSMSUser()
        {
            try
            {
                string isInstructorAlreadyCreated = DatabaseTools.GetUsername(Enumerations.UserType.CsSmsInstructor);
                if (isInstructorAlreadyCreated == null || isInstructorAlreadyCreated.Equals("False") ||
                    isInstructorAlreadyCreated.Equals(""))
                {
                    GenericTestStep.StepToBrowsedUrlForPegasusUser("SMSRegistration");
                    GenericTestStep.StepToClickedTheIAcceptButton();
                    GenericTestStep.StepToCreateNewSmsUser("CsSmsInstructor");
                }
                string isstudentAlreadyCreated = DatabaseTools.GetUsername(Enumerations.UserType.CsSmsStudent);
                if (isstudentAlreadyCreated == null || isstudentAlreadyCreated.Equals("False") || isstudentAlreadyCreated.Equals(""))
                {
                    GenericTestStep.StepToBrowsedUrlForPegasusUser("SMSRegistration");
                    GenericTestStep.StepToClickedTheIAcceptButton();
                    GenericTestStep.StepToCreateNewSmsUser("CsSmsStudent");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }



        //Purpose: Step Definition for Enrolling User To The Instructor Course 
        [Given(@"SMS user is already enrolled into the instructor course if not then enroll the SMS user in instructor course")]
        public void GivenSMSUserIsAlreadyEnrolledIntoTheInstructorCourseIfNotThenEnrollTheSMSUserInInstructorCourse()
        {
            try
            {
                string isInstructorEnrolledInCourse = DatabaseTools.GetEnrolledUser(Enumerations.UserType.CsSmsInstructor);
                if (isInstructorEnrolledInCourse == null || isInstructorEnrolledInCourse.Equals("False") || isInstructorEnrolledInCourse.Equals(""))
                {
                    GenericTestStep.StepToBrowsedUrlForPegasusUser("CsSmsInstructor");
                    GenericTestStep.StepToLoggedIntoTheCourseSpaceAsSMSInstructor();
                    GenericTestStep.StepToIAmOnThePage("Global Home");
                    GenericTestStep.StepToCreateInstructorCourse();
                    GenericTestStep.StepToClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                }
                string isStudentEnrolledInCourse = DatabaseTools.GetEnrolledUser(Enumerations.UserType.CsSmsStudent);
                if (isStudentEnrolledInCourse == null || isStudentEnrolledInCourse.Equals("False") || isStudentEnrolledInCourse.Equals(""))
                {
                    GenericTestStep.StepToBrowsedUrlForPegasusUser("CsSmsStudent");
                    GenericTestStep.StepToLoggedIntoTheCourseSpaceAsSMSStudent();
                    GenericTestStep.StepToCloseStudentHelpTextWindow();
                    GenericTestStep.StepToIAmOnThePage("Global Home");
                    GenericTestStep.StepToEnrolStudentToCourse("MasterCourse");
                    GenericTestStep.StepToClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: Step Definition for User Enrollment in Program Type Course
        [Given(@"SMS user is already enrolled into the program if not then enroll the SMS user in program")]
        public void GivenSMSUserIsAlreadyEnrolledIntoTheProgramIfNotThenEnrollTheSMSUserInProgram()
        {
            try
            {
                string isProgramCourseCreated = DatabaseTools.GetCourse(Enumerations.CourseType.ProgramCourse);
                if (isProgramCourseCreated == null || isProgramCourseCreated.Equals("False") || isProgramCourseCreated.Equals(""))
                {
                    GenericTestStep.StepToBrowsedUrlForPegasusUser("CsSmsInstructor");
                    GenericTestStep.StepToLoggedIntoTheCourseSpaceAsSMSInstructor();
                    GenericTestStep.StepToIAmOnThePage("Global Home");
                    GenericTestStep.StepToCreateProgramCourse();
                    GenericTestStep.StepToClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();

                    GenericTestStep.StepToBrowsedUrlForPegasusUser("CsSmsStudent");
                    GenericTestStep.StepToLoggedIntoTheCourseSpaceAsSMSStudent();
                    GenericTestStep.StepToCloseStudentHelpTextWindow();
                    GenericTestStep.StepToIAmOnThePage("Global Home");
                    GenericTestStep.StepToEnrolStudentToCourse("ProductTypeProg");
                    GenericTestStep.StepToClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        // purpose : Step definition to verify the enrollment of SMS student to the section
        [Given(@"SMS Student is already enrolled into the Section if not then enroll the SMS user to Section")]
        public void GivenSmsStudentisalreadyenrolledintotheSectionifnotthenenrolltheSmSusertoSection()
        {
            try
            {
                string isStudentEnrolled = DatabaseTools.GetEnrolledUser(Enumerations.UserType.CsSmsStudent);
                if (isStudentEnrolled == null || isStudentEnrolled.Equals("False") || isStudentEnrolled.Equals(""))
                {
                    GenericTestStep.StepToBrowsedUrlForPegasusUser("CsSmsInstructor");
                    GenericTestStep.StepToLoggedIntoTheCourseSpaceAsSMSInstructor();
                    GenericTestStep.StepToIAmOnThePage("Global Home");
                    GenericTestStep.StepToCreateProgramCourse();
                    GenericTestStep.StepToClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();

                    GenericTestStep.StepToBrowsedUrlForPegasusUser("CsSmsStudent");
                    GenericTestStep.StepToLoggedIntoTheCourseSpaceAsSMSStudent();
                    GenericTestStep.StepToCloseStudentHelpTextWindow();
                    GenericTestStep.StepToIAmOnThePage("Global Home");
                    GenericTestStep.StepToEnrolStudentToCourse("ProductTypeProg");
                    GenericTestStep.StepToSelectTheSectionName();
                    GenericTestStep.StepToClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }



        //Purpose: Step Definition To Select the section  Course from the Global Home Page
        [When(@"I select the section from the Global home page")]
        public void WhenISelectTheSectionFromTheGlobalHomePage()
        {
            try
            {
                bool announcementClose = GenericHelper.CloseAnnouncementPage();
                if (announcementClose)
                {
                    GenericHelper.Logs("Annoucement page has been closed successfully", "Passed");
                }
                else
                {
                    GenericHelper.Logs("Annoucement page is still not closed", "Failed");
                }
                string courseName = DatabaseTools.GetSectionName(Enumerations.CourseType.ProgramCourse).Trim();
                GenericHelper.WaitUntilElement(By.PartialLinkText(courseName));
                WebDriver.FindElement(By.PartialLinkText(courseName)).SendKeys("");
                WebDriver.FindElement(By.PartialLinkText(courseName)).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericStepDefinition.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} cau" + "ght: {1}", e.GetType(), e.Message));
            }
        }


        //Purpose: Step Definition To Select the Instructor Course from the Global Home Page
        [When(@"I select the course from Global home page")]
        public void IselectthecoursefromGlobalhomepage()
        {
            try
            {
                bool announcementClose = GenericHelper.CloseAnnouncementPage();
                if (announcementClose)
                {
                    GenericHelper.Logs("Annoucement page has been closed successfully", "Passed");
                }
                else
                {
                    GenericHelper.Logs("Annoucement page is still not closed", "Failed");
                }
                string courseName = DatabaseTools.GetCourse(Enumerations.CourseType.InstructorCourse).Trim();
                GenericHelper.WaitUntilElement(By.PartialLinkText(courseName));
                WebDriver.FindElement(By.PartialLinkText(courseName)).SendKeys("");
                WebDriver.FindElement(By.PartialLinkText(courseName)).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericStepDefinition.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} cau" + "ght: {1}", e.GetType(), e.Message));
            }
        }

        //Purpose: Step Definition To Select Program From Global Home Page
        [When(@"I select the Program course from Global home page")]
        public void SelectTheProgramCourseFromGlobalHomePage()
        {
            try
            {
                bool announcementClose = GenericHelper.CloseAnnouncementPage();
                if (announcementClose)
                {
                    GenericHelper.Logs("Annoucement page has been closed successfully", "Passed");
                }
                else
                {
                    GenericHelper.Logs("Annoucement page is still not closed", "Failed");
                }
                string courseName = DatabaseTools.GetCourse(Enumerations.CourseType.ProgramCourse).Trim();
                GenericHelper.WaitUntilElement(By.PartialLinkText(courseName));
                WebDriver.FindElement(By.PartialLinkText(courseName)).SendKeys("");
                WebDriver.FindElement(By.PartialLinkText(courseName)).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericStepDefinition.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} cau" + "ght: {1}", e.GetType(), e.Message));
            }
        }

        //Purpose: Step Definition To Enter the Template as Teacher
        [Then(@"I enter the template as teacher")]
        [When(@"I enter the template as teacher")]
        public void WhenIEnterTheTemplateAsTeacher()
        {

            try
            {
                _manageTemplateHed.ToSearchForAssignedHedProgramAdmin();
                GenericTestStep.StepToIAmOnThePage("Calendar");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericStepDefinition.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} cau" +
                                       "ght: {1}", e.GetType(), e.Message));
            }
        }

        /// <summary>
        /// To Create section inside program
        /// </summary>
        [Given(@"SMS user is already created the section if not then create the section")]
        public void SMSUserIsAlreadyCreatedTheSection()
        {
            try
            {
                string IsSectionCreated = DatabaseTools.GetSectionName(Enumerations.CourseType.ProgramCourse);
                if (IsSectionCreated == null || IsSectionCreated.Equals("False") || IsSectionCreated.Equals(""))
                {
                    _manageTemplateHed.ToCreateSections();
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericStepDefinition.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} cau" + "ght: {1}", e.GetType(), e.Message));
            }

        }

        //Purpose: Step Definition To Enter the Section as Teacher
        [Then(@"I enter the section as teacher")]
        [When(@"I enter the section as teacher")]
        public void WhenIEnterSectionAsTeacher()
        {
            try
            {
                string sectionName = DatabaseTools.GetSectionName(Enumerations.CourseType.ProgramCourse);
                GenericHelper.SelectWindow("Program Administration");
                GenericHelper.WaitUntilElement(By.Id("_ctl0_PageContent_ifrmMiddle"));
                WebDriver.FindElement(By.Id("_ctl0_PageContent_ifrmMiddle"));
                WebDriver.SwitchTo().Frame("_ctl0_PageContent_ifrmMiddle");
                GenericHelper.WaitUntilElement(By.PartialLinkText("Search"));
                WebDriver.FindElement(By.PartialLinkText("Search")).Click();
                //WebDriver.SwitchTo().ActiveElement();
                GenericHelper.WaitUntilElement(By.Id("txtSectionDetail"));
                WebDriver.FindElement(By.Id("txtSectionDetail")).Clear();
                WebDriver.FindElement(By.Id("txtSectionDetail")).SendKeys(sectionName);
                GenericHelper.WaitUntilElement(By.Id("lnkbuttonsearch"));
                WebDriver.FindElement(By.Id("lnkbuttonsearch")).Click();
                WebDriver.SwitchTo().DefaultContent();
                GenericHelper.SelectWindow("Program Administration");
                GenericHelper.WaitUntilElement(By.Id("_ctl0_PageContent_ifrmMiddle"));
                WebDriver.FindElement(By.Id("_ctl0_PageContent_ifrmMiddle"));
                WebDriver.SwitchTo().Frame("_ctl0_PageContent_ifrmMiddle");
                GenericHelper.WaitUntilElement(By.XPath("//div[@id='grdTemplateSection$divContent']/descendant::th[@class='thCourseInQ']/span"));
                IWebElement sectionClick = WebDriver.FindElement(By.XPath("//div[@id='grdTemplateSection$divContent']/descendant::th[@class='thCourseInQ']/span"));
                sectionClick.Click();
                GenericHelper.WaitUtilWindow("Calendar");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericStepDefinition.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Assert.Fail(string.Format("Exception of type {0} cau" + "ght: {1}", e.GetType(), e.Message));
            }
        }

        //Purpose: Step Definition To Edit the Study Plan
        [Then(@"I edit the study plan")]
        public void ThenIEditStudyPlan()
        {
            try
            {
                _editStudy.EditTheStudyPlan();
            }
            catch (Exception e)
            {
                Assert.Fail(string.Format("Exception of type {0} cau" + "ght: {1}", e.GetType(), e.Message));
            }
        }

    }
}



