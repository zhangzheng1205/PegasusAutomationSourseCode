using System;
using System.Collections.Generic;
using System.Linq;
using Pegasus.Automation.DataTransferObjects;

namespace Pearson.Pegasus.TestAutomation.
    Frameworks.DataTransferObjects
{
    /// <summary>
    /// This class represents a user.
    /// </summary>
    public class User : BaseEntityObject
    {
        /// <summary>
        /// This is the password.
        /// </summary>
        public String Password { get; set; }

        /// <summary>
        /// This is the email of the user.
        /// </summary>
        public String Email { get; set; }

        /// <summary>
        /// This is the first name of the user.
        /// </summary>
        public String FirstName { get; set; }

        /// <summary>
        /// This is the middle name of the user.
        /// </summary>
        public String MiddleName { get; set; }

        /// <summary>
        /// This is the last name of the user.
        /// </summary>
        public String LastName { get; set; }

        /// <summary>
        /// This is the Rumba Owner ID.
        /// </summary>
        public String RumbaOwnerId { get; set; }

        /// <summary>
        /// This is the enrolment status of the user.
        /// </summary>
        public bool EnrolementStatus { get; set; }

        /// <summary>
        /// This is the product Instance of the user.
        /// </summary>
        public String ProductInstance { get; set; }

        /// <summary>
        /// This is the last login Instance of the user.
        /// </summary>
        public DateTime LastLogin { get; set; }

        /// <summary>
        /// This is the Users Profile Date and Time.
        /// </summary>
        public DateTime CurrentProfileDateTime { get; set; }

        /// <summary>
        /// This is the type of the user
        /// </summary>
        public enum UserTypeEnum
        {
            #region Pegasus User Types
            WsAdmin = 1,
            CsAdmin = 2,
            WsTeacher = 3,
            WsStudent = 4,
            NovaNETCsTeacher = 5,
            NovaNETCsStudent = 6,
            NovaNETCsOrganizationAdmin = 7,
            NovaNETCsAide = 8,
            NovaNETDemoUser = 9,
            HedWsAdmin = 10,
            HedCsAdmin = 11,
            HedWsInstructor = 12,
            CsSmsInstructor = 13,
            CsSmsStudent = 14,
            DPCsTeacher = 15,
            DPCsStudent = 16,
            DPCsOrganizationAdmin = 17,
            DPCsAide = 18,
            DPDemoUser = 19,
            SMSAdmin = 20,
            RUMBAAdmin = 21,
            NovaNETWsAdmin = 22,
            NovaNETCsClassTeacher = 23,
            NovaNETCsClassStudent = 24,
            MMNDInstructor = 25,
            MMNDStudent = 26,
            MMNDAdmin = 27,
            NovaNETCTGPublisherAdmin = 28,
            DPCTGPPublisherAdmin = 29,
            HedProgramAdmin = 30,
            DPWsAdmin = 31,
            HedTeacherAssistant = 32,
            DPWorkSpacePramotedAdmin = 33,
            NNWorkSpacePramotedAdmin = 34,
            NNCourseSpacePramotedAdmin = 35,
            DPCourseSpacePramotedAdmin = 36,
            DPCsTeacherManageRoster = 37,
            DPCsStudentManageRoster = 38,
            DPCsAideManageRoster = 39,
            HedWsStudent = 40,
            RumbaTeacher = 41,
            RumbaStudent = 42,
            RumbaNonPSNTeacher = 43,
            ECollegeAdmin = 44,
            ECollegeTeacher = 45,
            ECollegeStudent = 46,
            HedCoreAcceptanceInstructor = 47,
            HedCoreAcceptanceStudent = 48,
            HEDCSCTGPPublisherAdmin = 49,
            HEDWSCTGPublisherAdmin = 50,
            HedMilAcceptanceInstructor = 51,
            HedMilAcceptanceStudent = 52,
            HedMiLWsAdmin = 53,
            HedCoreVmWsAdmin = 54,
            HedBackdoorLoginStudent = 55,
            HedBackdoorLoginInstructor = 56,
            HedMilPPEStudent = 57,
            SMSAdminStudent = 58,
            HSSCsSmsInstructor = 59,
            HSSCsSmsStudent = 60,
            HSSProgramAdmin = 61,
            WLCsSmsInstructor = 62,
            WLCsSmsStudent = 63,
            WLProgramAdmin = 64,
            MyTestSmsInstructor = 65,
            MyTestCsSmsStudent = 66,
            AmpWSInstructor = 65,
            AmpCsSmsInstructor = 66,
            AmpCsSmsStudent = 67,
            AmpProgramAdmin = 68,
            DPCsIdleStudent=69,
            DPCsStudentForUnenroll=70,
            DPCsNewStudent=71,
            DPCsNewTeacher=72,
            DPCsNewAide=73,
            BBInstructor = 74,
            BBStudent = 75,
            #endregion
        }

        /// <summary>
        /// This is User Creation Access Point(s) In Pegasus Product.
        /// </summary>
        public enum UserCreationAccessPoint
        {
            #region Pegasus User Creation Access Points
            WsAdminCourseEnrollment = 1,
            WsAdminAdministrators = 2,
            CsAdminCourseEnrollment = 3,
            CsAdminAdministrators = 4,
            PearsonAdminUsers = 5,
            PearsonAdminEnrollment = 6,
            ClassManageRoaster = 7,
            EnrollmentClassManageRoaster = 8,
            PromotedAdminUsers = 9,
            PromotedAdminEnrollment = 10,
            OrganizationAdminUsers = 11,
            OrganizationAdminEnrollment = 12,
            SMS = 13,
            Rumba = 14
            #endregion
        }

        /// <summary>
        /// This is the type of the user.
        /// </summary>
        public UserTypeEnum UserType { get; set; }

        /// <summary>
        /// This is the user Id.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// This method selects users based on given condition.
        /// </summary>
        /// <param name="predicate">The condition</param>
        /// <returns>A list of users</returns>
        public static List<User> Get(Func<User, bool> predicate)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany(predicate);
        }

        /// <summary>
        /// This method inserts a new user into the system.
        /// </summary>]
        public void StoreUserInMemory()
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Insert(this);
        }

        /// <summary>
        /// This method is used to update the user.
        /// </summary>
        public void UpdateUserInMemory(User user)
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Update(user);
        }

        /// <summary>
        /// This method selects a single user based on the role.
        /// </summary>
        /// <param name="userType">This is the user type.</param>
        /// <returns>A single user.</returns>
        public static User Get(UserTypeEnum userType)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany
                <User>(x => x.UserType == userType && x.IsCreated).OrderByDescending(x => x.CreationDate).First();
        }

        /// <summary>
        /// This method gets the user based on User ID.
        /// </summary>
        /// <param name="userId">This is user ID.</param>
        /// <returns>User based on ID.</returns>
        public static User Get(string userId)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<User>(x => x.UserId == userId && x.IsCreated)
                .OrderByDescending(x => x.CreationDate).First();
        }

        /// <summary>
        /// This method is used to update the user's password.
        /// </summary>
        /// <param name="password">This is the password of the user.</param>
        public void UpdatePassword(string password)
        {
            User user = InMemoryDatabaseSingleton.DatabaseInstance.SelectTopOne<User>(x => x.Name == Name);
            user.Password = password;
        }

        /// <summary>
        /// This method returns all created users of the given type.
        /// </summary>
        /// <param name="userType">This is the type of the user.</param>
        /// <returns>User List.</returns>
        public static List<User> GetAll(UserTypeEnum userType)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<User>(
                x => x.UserType == userType).OrderByDescending(
                x => x.CreationDate).ToList();
        }
    }
}
