namespace Framework.Common
{
    public sealed class Enumerations
    {
        //Purpose: Defined Course Type Entity
        public enum CourseType : int
        {
            EmptyCourse = 1,
            ContainerCourse,
            MasterLibrary,
            MasterCourse,
            AuthoredMasterLibrary,
            AuthoredCourse,
            MySpanishLabAuthoredCourse,
            MySpanishLabMasterCourse,
            InstructorCourse,
            ProgramCourse,
            TestingCourse,
            SectionCourse
        }

        //Purpose: Defined User Type Entity
        public enum UserType : int
        {
            WsAdmin = 1,
            CsAdmin,
            WsTeacher,
            WsStudent,
            CsTeacher,
            CsStudent,
            CsOrganizationAdmin,
            CsAide,
            CsTStudent,
            HedWsAdmin,
            HedCsAdmin,
            HedWsInstructor,
            CsSmsInstructor,
            CsSmsStudent,
            CsTeachingAssitant,
            DPCsTeacher,
            DPCsStudent,
            DPCsOrganization,
            DPCsAide,
            SMSRegistration,
            RUMBARegistration,
            RumbaAdmin
        }

        //Purpose: Defined User Search Parameter(s)
        public enum UserSearchType : int
        {
            Firstname = 1,
            Lastname,
            Username
        }

        //Purpose: Defined Question Type Entity
        public enum QuestionType : int
        {
            MultipleChoice = 1,
            FillInTheBlank,
            SCO
        }

        //Purpose: Defined Activity Type Entity
        public enum ActivityType : int
        {
            SkillStudyPlan = 1,
            Homework,
            Folder,
            Essay,
            MyTest,
            StudyPlan,
            SpWith1Rem,
            Sp1With3Rem,
            Sp2With3Rem,
            MyTestBank
        }

        //Purpose: Defined Organization Type Entity
        public enum OrgLevelType : int
        {
            State = 1,
            Region,
            District,
            School
        }

        //Purpose: Defined Class Type Entity
        public enum ClassType : int
        {
            NovaNETTemplate = 1,
            NovaNETMasterLibrary,
            DigitalPathTemplate,
            DigitalPathMasterLibrary,
            NovaNETPlaceHolder,
            DigitalPathPlaceHolder
        }

        //Purpose: Defined Pegasus Instance Type Entity
        public enum ProductInstance : int
        {
            NovaNET = 1,
            DigitalPath,
            HedCoreGeneral,
            HedCoreProgram,
            HedMilGeneral,
            HedMilProgram
        }

        //Purpose: Defined Product Type Entity
        public enum ProgramInstance : int
        {
            NovaNET = 1,
            DigitalPath,
            HedCore,
            HedMil
        }

        //Purpose: Defined Template Type Entity
        public enum TemplateInstance : int
        {
            NovaNET = 1,
            DigitalPath
        }

        //Purpose: Defined Organization Type Entity
        public enum OrganizationInstance : int
        {
            NovaNET = 1,
            DigitalPath
        }
    }
}
