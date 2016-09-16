using System;
using System.Collections.Generic;
using System.Linq;
using Pearson.Pegasus.TestAutomation.Frameworks;

namespace Pegasus.Automation.DataTransferObjects
{
    /// <summary>
    /// This class represents a course.
    /// </summary>
    public class Course : BaseEntityObject
    {
        /// <summary>
        /// This is h type of course.
        /// </summary>
        public enum CourseTypeEnum
        {
            // NovaNet and DigitalPath courses
            EmptyClass = 1,
            Container = 2,
            MasterLibrary = 3,
            MasterCourse = 4,
            NovaNETAuthored = 5,
            DigitsAuthoredCourse = 6,
            CTCDigitsAuthoredCourse = 7,
            DigitsCourse = 8,
            // Hed WL courses
            MySpanishLabAuthored = 9,
            MySpanishLabMaster = 10,
            InstructorCourse = 11,
            ProgramCourse = 12,
            HEDGeneral = 13,
            MySpanishLabCopiedMaster = 14,
            MySpanishLabTestingMaster = 15,
            // MMND courses
            MMNDCoOrdinate = 16,
            MMNDNonCoOrdinate = 17,
            MMNDSection = 18,
            CopiedDigitsAuthoredCourse = 19,
            // ecollege courses
            ECollege = 20,
            MySpanishLabMasterVm = 21,
            NovaNETMasterLibrary = 22,
            //MyTest Course Enum
            MyTestMasterCourse = 23,
            MyTestBankCourse = 24,
            MyTestInstructorCourse = 25,
            MyTestProgramCourse = 26,
            // mil Courses
            MyItLabAuthoredCourse = 27,
            MyItLabMasterCourse = 28,
            MyItLabSIMMasterCourse = 29,
            MyItLabSIM5MasterCourse = 30,
            MyItLabInstructorCourse = 31,
            MyItLabProgramCourse = 32,
            MyItLabSIMCourse = 33,
            HedMyItLabPPECourse = 34,
            MyITLabOffice2013Program = 35,
            MyITLabForOffice2013Master =36,
            // mil Acceptance Test Course Enum
            HedMilAcceptanceSIMProgramCourse = 37,
            HedMilAcceptanceSIM5ProgramCourse = 38,
            // hed WL Acceptance Test Course Enum
            HedCoreAcceptanceInstructorCourse = 39,
            HedCoreAcceptanceProgramCourse = 40,
            IntegrationPointID = 41,
            PegasusCourseID = 42,
            ExternalCourse = 43,
            HedEmptyClass = 44,
            // mil GraderIT Courses
            GraderITSIM5Course = 45,
            HedMilSelfStudy = 46,
            //HSS Course and Template Enum
            HedMyPsychLabProgram=47,
            HedMyPsychLabMaster=48,
            NNMasterLibrary=49,
            MyTestAuthoredCourse=50,
            HSSMyPsychLabProgram = 51,
            HSSMyPsychLabMaster = 52,
            MySpanishLabProgram=53,
            MySpanishLabMasterMyTest =54,
            MySpanishLabProgramMyTest = 55,
            //Amplifier Course
            AmpWSCourse = 54,
            AmpProgramCourse = 55,
            AmpInstructorCourse = 56,
            BBCourse = 57,
            //SSRS Course            
            HED5xPMC = 58,
            WVUCourse = 59,
            CanvasKioskCourse = 61,
            D2LKioskCourse = 62,
            MoodleKioskCourse = 63,
            D2LDirectCourse = 64,
            MoodleDirectCourse = 65,
            MyItLabSIM5AnotherWorkSpaceMasterCourse=66,
            ExistingCourseForPublish=67,
            ExistingPublishedCourse=68,
            MasterLibrarySameProduct=69,
            MasterLibraryDifferentProduct=70,
            MyITLabOffice2013ProgramCourseCreation=71,
            MyITLabForOffice2013MasterCourseCreation=72,
            RegMySpanishLabMaster=73,
            CanvasDirectCourse = 74,
            RegWLMasterCourse = 75,
            BadgingCourse = 76,
            BadgingCourseProgram = 77,
            eTextCourse=78
        }

        /// <summary>
        /// This is the course type enum.
        /// </summary>
        public CourseTypeEnum CourseType { get; set; }

        /// <summary>
        /// This gives the course sction id.
        /// </summary>
        public String SectionId { get; set; }

        /// <summary>
        /// This gives the course section name.
        /// </summary>
        public String SectionName { get; set; }

        /// <summary>
        /// This gives the shared library id.
        /// </summary>
        public String SharedLibraryId { get; set; }

        /// <summary>
        /// This gives the shared library name.
        /// </summary>
        public String SharedLibraryName { get; set; }

        /// <summary>
        /// This gives the shared library name.
        /// </summary>
        public String ExistingSharedLibraryName { get; set; }

        /// <summary>
        /// This gives the course section name.
        /// </summary>
        public String SectionNameForJobDependent { get; set; }

        /// <summary>
        /// This gives the course template name.
        /// </summary>
        public String TemplateName { get; set; }

        /// <summary>
        /// This gives the course  copy template name.
        /// </summary>
        public String CopyTemplateName { get; set; }

        /// <summary>
        /// This gives the course  copy template name.
        /// </summary>
        public String SharedLibraryCopyTemplateName { get; set; }

        /// <summary>
        /// This gives the preference status.
        /// </summary>
        public bool IsPreferenceStatus { get; set; }

        /// <summary>
        /// This tells if the course is published.
        /// </summary>
        public bool IsPublished { get; set; }

        /// <summary>
        /// This tells if the course is approved.
        /// </summary>
        public bool IsApproved { get; set; }

        /// <summary>
        /// This is instructor course id.
        /// </summary>
        public String InstructorCourseId { get; set; }

        /// <summary>
        /// This is Integration Point id.
        /// </summary>
        public String IntegrationPointId { get; set; }

        /// <summary>
        /// This is Pegasus Course id.
        /// </summary>
        public String PegasusCourseId { get; set; }

        /// <summary>
        /// This is External Course id.
        /// </summary>
        public String ExternalCourseId { get; set; }

        /// <summary>        
        /// This is SMS Course id.
        /// </summary>
        public String SMSCourseId { get; set; }

        /// <summary>        
        /// This is Descipline.
        /// </summary>
        public String Desciplines { get; set; }

        /// <summary>
        /// This is eCollege course integration id.
        /// </summary>
        public String ECollegeIntegrationId { get; set; }

        /// <summary>
        /// This gives the course workspace id.
        /// </summary>
        public String WorkSpaceId { get; set; }

        /// <summary>
        /// This gives the course enrollment date.
        /// </summary>
        public DateTime EnrollmentDate { get; set; }

        public String Template { get; set; }
        /// <summary>
        /// This class returns the course based on condition.
        /// </summary>
        /// <param name="predicate">This is the condition.</param>
        /// <returns>This is a list of courses.</returns>
        public static List<Course> Get(Func<Course, bool> predicate)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany(predicate);
        }

        /// <summary>
        /// This method selects the course of given type which is created.
        /// </summary>
        /// <param name="courseType">This is the type of the course.</param>
        /// <returns>A course</returns>
        public static Course Get(CourseTypeEnum courseType)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<Course>
                (x => x.CourseType == courseType && x.IsCreated).OrderByDescending(
                x => x.CreationDate).First();
        }

        /// <summary>
        /// This class creates a new course.
        /// </summary>
        public void StoreCourseInMemory()
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Insert(this);
        }

        /// <summary>
        /// This method is used to update the course.
        /// </summary>
        public void UpdateCourseInMemory(Course course)
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Update(course);
        }

        /// <summary>
        /// This gets course based on name.
        /// </summary>
        /// <param name="name">The name of the course.</param>
        /// <returns>A single course</returns>
        public static Course Get(string name)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectTopOne<Course>(x => x.Name == name && x.IsCreated);
        }

        /// <summary>
        /// This method returns all created course of the given type.
        /// </summary>
        /// <param name="courseType">This is the type of the course.</param>
        /// <returns>course List.</returns>
        public static List<Course> GetAll(CourseTypeEnum courseType)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<Course>(
                x => x.CourseType == courseType).OrderByDescending(
                x => x.CreationDate).ToList();
        }
    }
}
