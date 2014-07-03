using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Framework.Common;
using System;
namespace Pegasus_DataAccess.Database_Support
{
    public class DatabaseTools
    {
        //Purpose: Method To Get Last Single Column Data
        public static string GetdataDb(string connString, string selecTionQuery, string columnName)
        {
            try
            {
                // Purpose: Creating SQL Connection
                SqlConnection myConnection = new SqlConnection(connString);
                myConnection.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(selecTionQuery, myConnection);
                myReader = myCommand.ExecuteReader();
                string value1 = null;
                while (myReader.Read())
                {
                    value1 = myReader[columnName].ToString();
                }
                myCommand.Connection.Close();
                myConnection.Close();
                return value1;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        //Purpose: Method To Execute query To Connecting DB
        public static void ExecuteQueryDb(string connString, string insertQuery)
        {
            try
            {
                // Purpose: Creating SQL Connection
                SqlConnection myConnection = new SqlConnection(connString);
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(insertQuery, myConnection);
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();
                myConnection.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Purpose: Fetch Connection String
        public static readonly string StrConnection = ConfigurationManager.ConnectionStrings["Pegasus_SpecFlow.Properties.Settings.BDD_DBConnectionString"].ConnectionString;

        //Purpose: Method to Fetch Url FROM The DB in respective of User(s)
        public static string GetUrl(Enumerations.UserType role)
        {
            try
            {
                string url = string.Empty;
                switch (role)
                {
                    //Purpose: Query To SELECT Ws Url FROM DB for Ws Admin
                    case Enumerations.UserType.WsAdmin:
                        url = GetdataDb(StrConnection, "SELECT WS_URL FROM BDD_UrlInfo", "WS_URL") +
                              "frmLogin.aspx?mode=admin";
                        break;
                    //Purpose: Query To SELECT Cs Url FROM DB for Cs Admin
                    case Enumerations.UserType.CsAdmin:
                        url = GetdataDb(StrConnection, "SELECT CS_URL FROM BDD_UrlInfo", "CS_URL") +
                              "frmLogin.aspx?mode=admin";
                        break;
                    //Purpose: Query To SELECT Ws Url FROM DB for Ws Teacher
                    case Enumerations.UserType.WsTeacher:
                        url = GetdataDb(StrConnection, "SELECT WS_URL FROM BDD_UrlInfo", "WS_URL") + "frmLogin.aspx?";
                        break;
                    //Purpose: Query To SELECT Ws Url FROM DB for Ws Student
                    case Enumerations.UserType.WsStudent:
                        url = GetdataDb(StrConnection, "SELECT WS_URL FROM BDD_UrlInfo", "WS_URL") + "frmLogin.aspx?";
                        break;
                    //Purpose: Query To SELECT Cs Url FROM DB for Cs Teacher
                    case Enumerations.UserType.CsTeacher:
                        url = GetdataDb(StrConnection, "SELECT CS_URL FROM BDD_UrlInfo", "CS_URL") + "frmLogin.aspx?";
                        break;
                    //Purpose: Query To SELECT Cs Url FROM DB for Cs Student
                    case Enumerations.UserType.CsStudent:
                        url = GetdataDb(StrConnection, "SELECT CS_URL FROM BDD_UrlInfo", "CS_URL") + "frmLogin.aspx?";
                        break;
                    //Purpose: Query To SELECT SMS_URL FROM DB
                    case Enumerations.UserType.SMSRegistration:
                        url = GetdataDb(StrConnection, "SELECT SMS_URL FROM BDD_UrlInfo", "SMS_URL");
                        break;
                    //Purpose: Query To SELECT HED Ws Url FROM DB for WS admin
                    case Enumerations.UserType.HedWsAdmin:
                        url = GetdataDb(StrConnection, "SELECT WSURL_HED FROM BDD_UrlInfo", "WSURL_HED") + "frmLogin.aspx?mode=admin";
                        break;
                    //Purpose: Query To SELECT HED Cs Url FROM DB for Cs admin
                    case Enumerations.UserType.HedCsAdmin:
                        url = GetdataDb(StrConnection, "SELECT CSURL_HED FROM BDD_UrlInfo", "CSURL_HED") + "frmlogin.aspx?mode=admin&isnative=1";
                        break;
                    //Purpose: Query To SELECT HED Cs Url FROM DB for Cs Instructor
                    case Enumerations.UserType.CsSmsInstructor:
                        url = GetdataDb(StrConnection, "SELECT CSURL_HED FROM BDD_UrlInfo", "CSURL_HED") + "frmLogin.aspx?";
                        break;
                    //Purpose: Query To SELECT HED Cs Url FROM DB for Cs Student
                    case Enumerations.UserType.CsSmsStudent:
                        url = GetdataDb(StrConnection, "SELECT CSURL_HED FROM BDD_UrlInfo", "CSURL_HED") + "frmLogin.aspx?";
                        break;
                    //Purpose: Query To SELECT HED WS teacher Url FROM DB for instructor
                    case Enumerations.UserType.HedWsInstructor:
                        url = GetdataDb(StrConnection, "SELECT WSURL_HED FROM BDD_UrlInfo", "WSURL_HED") + "frmLogin.aspx?";
                        break;
                }
                return url;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Fetch SQLConnection DB
        public static SqlConnection GetSqlConnection()
        {
            try
            {
                // Purpose: Creating SQL Connection
                string connectionString = DatabaseTools.StrConnection;
                var sqlConnection = new SqlConnection(connectionString);
                return sqlConnection;
            }
            catch (SqlException e)
            {
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Method to UPDATE User Details in DB
        public static void UpdateUserDb(Enumerations.UserType role, string userName, string password, string email, int userTypeId, bool status)
        {
            try
            {
                // Purpose: Query To SELECT Last Created User
                int maxrow =
                    Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(UserID),0) as UserID FROM BDD_User",
                                              "UserID"));
                // Purpose: Query To UPDATE User Details in DB
                ExecuteQueryDb(StrConnection,
                               "INSERT INTO BDD_User (UserID,LoginName,Password,Email,FirstName,MiddleName,LastName,UserTypeID,CreationStatus) values (" +
                               (maxrow + 1) + ",'" + userName + "','" + password + "','" + email + "','" + userName +
                               "','" + userName + "','" + userName + "'," + userTypeId + "," + Convert.ToByte(status) +
                               ")");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Fetch UserName From DB
        public static string GetUsername(Enumerations.UserType role)
        {
            try
            {
                string userName = string.Empty;
                switch (role)
                {
                    // Purpose: Query To Retrieve Username for Ws Admin
                    case Enumerations.UserType.WsAdmin:
                        userName = GetdataDb(StrConnection,
                                             "SELECT LoginName FROM BDD_User WHERE UserTypeID = 1 and CreationStatus = 1",
                                             "LoginName");
                        break;
                    // Purpose: Query To Retrieve Username for Cs Admin
                    case Enumerations.UserType.CsAdmin:
                        userName = GetdataDb(StrConnection,
                                             "SELECT LoginName FROM BDD_User WHERE UserTypeID = 2 and CreationStatus = 1",
                                             "LoginName");
                        break;
                    // Purpose: Query To Retrieve Username Ws Teacher
                    case Enumerations.UserType.WsTeacher:
                        userName = GetdataDb(StrConnection,
                                             "SELECT LoginName FROM BDD_User WHERE UserTypeID = 3 and CreationStatus = 1",
                                             "LoginName");
                        break;
                    // Purpose: Query To Retrieve Username for Ws Student
                    case Enumerations.UserType.WsStudent:
                        userName = GetdataDb(StrConnection,
                                             "SELECT LoginName FROM BDD_User WHERE UserTypeID = 4 and CreationStatus = 1",
                                             "LoginName");
                        break;
                    // Purpose: Query To Retrieve Username for Cs Teacher
                    case Enumerations.UserType.CsTeacher:
                        userName = GetdataDb(StrConnection,
                                             "SELECT LoginName FROM BDD_User WHERE UserTypeID = 5 and CreationStatus = 1",
                                             "LoginName");
                        break;
                    // Purpose: Query To Retrieve Username for Cs Student
                    case Enumerations.UserType.CsStudent:
                        userName = GetdataDb(StrConnection,
                                             "SELECT LoginName FROM BDD_User WHERE UserTypeID = 6 and CreationStatus = 1",
                                             "LoginName");
                        break;
                    // Purpose: Query To Retrieve Username for Cs Org. Admin
                    case Enumerations.UserType.CsOrganizationAdmin:
                        userName = GetdataDb(StrConnection,
                                             "SELECT LoginName FROM BDD_User WHERE UserTypeID = 7 and CreationStatus = 1",
                                             "LoginName");
                        break;
                    // Purpose: Query To Retrieve Username for Cs Aide
                    case Enumerations.UserType.CsAide:
                        userName = GetdataDb(StrConnection,
                                             "SELECT LoginName FROM BDD_User WHERE UserTypeID = 8 and CreationStatus = 1;",
                                             "LoginName");
                        break;
                    // Purpose: Query To Retrieve Username for HED Ws Admin
                    case Enumerations.UserType.HedWsAdmin:
                        userName = GetdataDb(StrConnection,
                                             "SELECT LoginName FROM BDD_User WHERE UserTypeID = 10 and CreationStatus = 1",
                                             "LoginName");
                        break;
                    // Purpose: Query To Retrieve Username for HED Cs Admin
                    case Enumerations.UserType.HedCsAdmin:
                        userName = GetdataDb(StrConnection,
                                             "SELECT LoginName FROM BDD_User WHERE UserTypeID = 11 and CreationStatus = 1",
                                             "LoginName");
                        break;
                    // Purpose: Query To Retrieve Username for HED SMS Cs Instructor
                    case Enumerations.UserType.CsSmsInstructor:
                        userName = GetdataDb(StrConnection,
                                             "SELECT LoginName FROM BDD_User WHERE UserTypeID = 13 and CreationStatus = 1",
                                             "LoginName");
                        break;
                    // Purpose: Query To Retrieve Username for HED SMS Cs Student
                    case Enumerations.UserType.CsSmsStudent:
                        userName = GetdataDb(StrConnection,
                                             "SELECT LoginName FROM BDD_User WHERE UserTypeID = 14 and CreationStatus = 1",
                                             "LoginName");
                        break;
                    // Purpose: Query To Retrieve Username for HED WS instructor
                    case Enumerations.UserType.HedWsInstructor:
                        userName = GetdataDb(StrConnection,
                                             "SELECT LoginName FROM BDD_User WHERE UserTypeID = 12 and CreationStatus = 1",
                                             "LoginName");
                        break;
                }
                return userName;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Fetch Password From DB
        public static string GetPassword(Enumerations.UserType role)
        {
            try
            {
                string password = string.Empty;
                switch (role)
                {
                    // Purpose: Query To Retrieve Password for Ws Admin
                    case Enumerations.UserType.WsAdmin:
                        password = GetdataDb(StrConnection,
                                             "SELECT Password FROM BDD_User WHERE UserTypeID = 1 and CreationStatus = 1;",
                                             "Password");
                        break;
                    // Purpose: Query To Retrieve Password for Cs Admin
                    case Enumerations.UserType.CsAdmin:
                        password = GetdataDb(StrConnection,
                                             "SELECT Password FROM BDD_User WHERE UserTypeID = 2 and CreationStatus = 1;",
                                             "Password");
                        break;
                    // Purpose: Query To Retrieve Password for Ws Teacher
                    case Enumerations.UserType.WsTeacher:
                        password = GetdataDb(StrConnection,
                                             "SELECT Password FROM BDD_User WHERE UserTypeID = 3 and CreationStatus = 1;",
                                             "Password");
                        break;
                    // Purpose: Query To Retrieve Password for Ws Student
                    case Enumerations.UserType.WsStudent:
                        password = GetdataDb(StrConnection,
                                             "SELECT Password FROM BDD_User WHERE UserTypeID = 4 and CreationStatus = 1;",
                                             "Password");
                        break;
                    // Purpose: Query To Retrieve Password for Cs Teacher
                    case Enumerations.UserType.CsTeacher:
                        password = GetdataDb(StrConnection,
                                             "SELECT Password FROM BDD_User WHERE UserTypeID = 5 and CreationStatus = 1;",
                                             "Password");
                        break;
                    // Purpose: Query To Retrieve Password for Cs Student
                    case Enumerations.UserType.CsStudent:
                        password = GetdataDb(StrConnection,
                                             "SELECT Password FROM BDD_User WHERE UserTypeID = 6 and CreationStatus = 1;",
                                             "Password");
                        break;
                    // Purpose: Query To Retrieve Password for Cs Org. Admin
                    case Enumerations.UserType.CsOrganizationAdmin:
                        password = GetdataDb(StrConnection,
                                             "SELECT Password FROM BDD_User WHERE UserTypeID = 7 and CreationStatus = 1;",
                                             "Password");
                        break;
                    // Purpose: Query To Retrieve Password for Cs Aide
                    case Enumerations.UserType.CsAide:
                        password = GetdataDb(StrConnection,
                                             "SELECT Password FROM BDD_User WHERE UserTypeID = 8 and CreationStatus = 1;",
                                             "Password");
                        break;
                    // Purpose: Query To Retrieve Username for HED Ws Admin
                    case Enumerations.UserType.HedWsAdmin:
                        password = GetdataDb(StrConnection,
                                             "SELECT Password FROM BDD_User WHERE UserTypeID = 10 and CreationStatus = 1",
                                             "Password");
                        break;
                    // Purpose: Query To Retrieve Username for HED Cs Admin
                    case Enumerations.UserType.HedCsAdmin:
                        password = GetdataDb(StrConnection,
                                             "SELECT Password FROM BDD_User WHERE UserTypeID = 11 and CreationStatus = 1",
                                             "Password");
                        break;
                    // Purpose: Query To Retrieve Username for HED SMS Cs Instructor
                    case Enumerations.UserType.CsSmsInstructor:
                        password = GetdataDb(StrConnection,
                                             "SELECT Password FROM BDD_User WHERE UserTypeID = 13 and CreationStatus = 1",
                                             "Password");
                        break;
                    // Purpose: Query To Retrieve Username for HED SMS Cs Student
                    case Enumerations.UserType.CsSmsStudent:
                        password = GetdataDb(StrConnection,
                                             "SELECT Password FROM BDD_User WHERE UserTypeID = 14 and CreationStatus = 1",
                                             "Password");
                        break;

                    // Purpose: Query To Retrieve Username for HED SMS Cs Student
                    case Enumerations.UserType.HedWsInstructor:
                        password = GetdataDb(StrConnection,
                                             "SELECT Password FROM BDD_User WHERE UserTypeID = 12 and CreationStatus = 1",
                                             "Password");
                        break;
                }
                return password;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Update Username and Password in DB
        public static void UpdatePassword(string username, string password)
        {
            try
            {
                // Purpose: Execute Query To UPDATE Username and Password
                ExecuteQueryDb(StrConnection,
                               "UPDATE BDD_User SET Password='" + password + "'WHERE LoginName='" + username + "'");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Fetch CourseName From DB
        public static string GetCourse(Enumerations.CourseType courseType)
        {
            try
            {
                string courseName = string.Empty;
                switch (courseType)
                {
                    // Purpose: Query To Retrieve Course Type Empty Course
                    case Enumerations.CourseType.EmptyCourse:
                        courseName = GetdataDb(StrConnection, "SELECT Name FROM BDD_Course WHERE CourseTypeID = 1 and CreationStatus = 1", "Name");
                        break;
                    // Purpose: Query To Retrieve Course Type Container Course
                    case Enumerations.CourseType.ContainerCourse:
                        courseName = GetdataDb(StrConnection, "SELECT Name FROM BDD_Course WHERE CourseTypeID = 2 and CreationStatus = 1", "Name");
                        break;
                    // Purpose: Query To Retrieve Course Type Master Library
                    case Enumerations.CourseType.MasterLibrary:
                        courseName = GetdataDb(StrConnection, "SELECT Name FROM BDD_Course WHERE CourseTypeID = 3 and CreationStatus = 1", "Name");
                        break;
                    // Purpose: Query To Retrieve Course Type Master Course
                    case Enumerations.CourseType.MasterCourse:
                        courseName = GetdataDb(StrConnection, "SELECT Name FROM BDD_Course WHERE CourseTypeID = 4 and CreationStatus = 1", "Name");
                        break;
                    // Purpose: Query To Retrieve Authored Master Library
                    case Enumerations.CourseType.AuthoredMasterLibrary:
                        courseName = GetdataDb(StrConnection, "SELECT Name FROM BDD_Course WHERE CourseTypeID = 5 and CreationStatus = 1", "Name");
                        break;
                    // Purpose: Query To Retrieve Course Type Authored for Copy Purpose
                    case Enumerations.CourseType.AuthoredCourse:
                        courseName = GetdataDb(StrConnection, "SELECT Name FROM BDD_Course WHERE CourseTypeID = 6 and CreationStatus = 1 and PreferenceStatus = 0 and PublishStatus = 0 ", "Name");
                        break;
                    // Purpose: Query To Retrieve Course Type Authored for Copy Purpose in HED
                    case Enumerations.CourseType.MySpanishLabAuthoredCourse:
                        courseName = GetdataDb(StrConnection, "SELECT Name FROM BDD_Course WHERE CourseTypeID = 7 and CreationStatus = 1 and PreferenceStatus = 0 and PublishStatus = 0 ", "Name");
                        break;
                    // Purpose: Query To Retrieve Course Type copied Master course in HED
                    case Enumerations.CourseType.MySpanishLabMasterCourse:
                        courseName = GetdataDb(StrConnection, "SELECT Name FROM BDD_Course WHERE CourseTypeID = 8 and CreationStatus = 1", "Name");
                        break;
                    // Purpose: Query To Retrieve Instructor course in HED
                    case Enumerations.CourseType.InstructorCourse:
                        courseName = GetdataDb(StrConnection, "SELECT Name FROM BDD_Course WHERE CourseTypeID = 9 and CreationStatus = 1", "Name");
                        break;
                    // Purpose: Query To Retrieve program course in HED
                    case Enumerations.CourseType.ProgramCourse:
                        courseName = GetdataDb(StrConnection, "SELECT Name FROM BDD_Course WHERE CourseTypeID = 10 and CreationStatus = 1", "Name");
                        break;
                    // Purpose: Query To Retrieve program course in HED
                    case Enumerations.CourseType.TestingCourse:
                        courseName = GetdataDb(StrConnection, "SELECT Name FROM BDD_Course WHERE CourseTypeID = 11 and CreationStatus = 1", "Name");
                        break;
                }
                return courseName;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Update Course in DB
        public static void UpdateCourse(Enumerations.CourseType courseType, string courseName)
        {
            try
            {
                // Purpose: Query To Retrieve Last Created Course FROM DB
                int maxrow =
                    Convert.ToInt16(GetdataDb(StrConnection,
                                              "SELECT IsNull(MAX(CourseID),0) as CourseID FROM bdd_course", "CourseID"));
                switch (courseType)
                {
                    // Purpose: Query To Insert Course Type Master Library
                    case Enumerations.CourseType.MasterLibrary:
                        ExecuteQueryDb(StrConnection,
                                       "INSERT INTO BDD_Course (CourseID,CourseTypeID,Name,CreationStatus,PublishStatus) values (" +
                                       (maxrow + 1) + "," + 3 + ",'" + courseName + "'," + Convert.ToByte(true) + "'," + Convert.ToByte(false) + ")");
                        break;
                    // Purpose: Query To Insert Course Type Empty Course
                    case Enumerations.CourseType.EmptyCourse:
                        ExecuteQueryDb(StrConnection,
                                       "INSERT INTO BDD_Course (CourseID,CourseTypeID,Name,CreationStatus,PreferenceStatus,PublishStatus) values (" +
                                       (maxrow + 1) + "," + 1 + ",'" + courseName + "'," + Convert.ToByte(true) + "," + Convert.ToByte(false) + "," + Convert.ToByte(false) + ")");
                        break;
                    // Purpose: Query To Insert Course Type Container Course
                    case Enumerations.CourseType.ContainerCourse:
                        ExecuteQueryDb(StrConnection,
                                       "INSERT INTO BDD_Course (CourseID,CourseTypeID,Name,CreationStatus,PreferenceStatus,PublishStatus) values (" +
                                       (maxrow + 1) + "," + 2 + ",'" + courseName + "'," + Convert.ToByte(true) + "," + Convert.ToByte(false) + "," + Convert.ToByte(false) + ")");
                        break;
                    // Purpose: Query To Insert Course Type Master Course
                    case Enumerations.CourseType.MasterCourse:
                        ExecuteQueryDb(StrConnection,
                                       "INSERT INTO BDD_Course (CourseID,CourseTypeID,Name,CreationStatus,PublishStatus) values (" +
                                       (maxrow + 1) + "," + 4 + ",'" + courseName + "'," + Convert.ToByte(true) + "," + Convert.ToByte(false) + ")");
                        break;
                    // Purpose: Query To Insert Course Type Authored Master Library
                    case Enumerations.CourseType.AuthoredMasterLibrary:
                        ExecuteQueryDb(StrConnection,
                                       "INSERT INTO BDD_Course (CourseID,CourseTypeID,Name,CreationStatus,PublishStatus) values (" +
                                       (maxrow + 1) + "," + 5 + ",'" + courseName + "'," + Convert.ToByte(true) + "," + Convert.ToByte(false) + ")");
                        break;
                    // Purpose: Query To Insert Course Type Authored Master Library
                    case Enumerations.CourseType.MySpanishLabMasterCourse:
                        ExecuteQueryDb(StrConnection,
                                       "INSERT INTO BDD_Course (CourseID,CourseTypeID,Name,CreationStatus,PublishStatus) values (" +
                                       (maxrow + 1) + "," + 8 + ",'" + courseName + "'," + Convert.ToByte(true) + "," + Convert.ToByte(false) + ")");
                        break;
                    // Purpose: Query To Insert Course Type Instrucotor course
                    case Enumerations.CourseType.InstructorCourse:
                        ExecuteQueryDb(StrConnection,
                                       "INSERT INTO BDD_Course (CourseID,CourseTypeID,Name,CreationStatus,PublishStatus) values (" +
                                       (maxrow + 1) + "," + 9 + ",'" + courseName + "'," + Convert.ToByte(true) + "," + Convert.ToByte(false) + ")");
                        break;
                    case Enumerations.CourseType.ProgramCourse:
                        ExecuteQueryDb(StrConnection,
                                       "INSERT INTO BDD_Course (CourseID,CourseTypeID,Name,CreationStatus,PublishStatus) values (" +
                                       (maxrow + 1) + "," + 10 + ",'" + courseName + "'," + Convert.ToByte(true) + "," + Convert.ToByte(false) + ")");
                        break;

                    case Enumerations.CourseType.TestingCourse:
                        ExecuteQueryDb(StrConnection,
                                       "INSERT INTO BDD_Course (CourseID,CourseTypeID,Name,CreationStatus,PublishStatus) values (" +
                                       (maxrow + 1) + "," + 11 + ",'" + courseName + "'," + Convert.ToByte(true) + "," + Convert.ToByte(false) + ")");
                        break;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Get Question Name From DB
        public static string GetQuestionName(Enumerations.QuestionType questionType)
        {
            try
            {
                string questionName = string.Empty;
                switch (questionType)
                {
                    // Purpose: Query To Retrieve Question Type 'Multiple Choice'
                    case Enumerations.QuestionType.MultipleChoice:
                        questionName = GetdataDb(StrConnection,
                                                 "SELECT top(1) QuestionName FROM BDD_Question WHERE QuestionTypeID=1 and CreationStatus=1 ORDER BY QuestionID DESC",
                                                 "QuestionName");
                        break;
                    // Purpose: Query To Retrieve Question Type 'Fill in the Blank'
                    case Enumerations.QuestionType.FillInTheBlank:
                        questionName = GetdataDb(StrConnection,
                                                 "SELECT top(1) QuestionName FROM BDD_Question WHERE QuestionTypeID=2 and CreationStatus=1 ORDER BY QuestionID DESC",
                                                 "QuestionName");
                        break;
                    // Purpose: Query To Retrieve Question Type 'SCO'
                    case Enumerations.QuestionType.SCO:
                        questionName = GetdataDb(StrConnection,
                                                 "SELECT top(1) QuestionName FROM BDD_Question WHERE QuestionTypeID=3 and CreationStatus=1 ORDER BY QuestionID DESC",
                                                 "QuestionName");
                        break;
                }
                return questionName;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Insert Question Name in DB
        public static void UpdateQuestions(Enumerations.QuestionType questionType, string questionName)
        {
            try
            {
                // Purpose: Query To SELECT Last Created Question Name
                int maxrow =
                    Convert.ToInt16(GetdataDb(StrConnection,
                                              "SELECT IsNull(MAX(QuestionID), 0) as QuestionID FROM BDD_Question",
                                              "QuestionID"));

                switch (questionType)
                {
                    // Purpose: Query To Insert Question Type 'Multiple Choice'
                    case Enumerations.QuestionType.MultipleChoice:
                        ExecuteQueryDb(StrConnection,
                                       "INSERT INTO BDD_Question (QuestionID,QuestionTypeID,QuestionName,CreationStatus) values (" +
                                       (maxrow + 1) + "," + 1 + ",'" + questionName + "'," + Convert.ToByte(true) + ")");
                        break;
                    // Purpose: Query To Insert Question Type 'Fill In The Blank'
                    case Enumerations.QuestionType.FillInTheBlank:
                        ExecuteQueryDb(StrConnection,
                                       "INSERT INTO BDD_Question (QuestionID,QuestionTypeID,QuestionName,CreationStatus) values (" +
                                       (maxrow + 1) + "," + 2 + ",'" + questionName + "'," + Convert.ToByte(true) + ")");
                        break;
                    // Purpose: Query To Insert Question Type 'SCO'
                    case Enumerations.QuestionType.SCO:
                        ExecuteQueryDb(StrConnection,
                                       "INSERT INTO BDD_Question (QuestionID,QuestionTypeID,QuestionName,CreationStatus) values (" +
                                       (maxrow + 1) + "," + 3 + ",'" + questionName + "'," + Convert.ToByte(true) + ")");
                        break;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Insert Activity Name in DB
        public static void UpdateActivity(Enumerations.ActivityType activityType, string activityName)
        {
            try
            {
                // Purpose: Query To SELECT Last Created Activity Name
                int maxrow = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(ActivityID), 0) as ActivityID FROM BDD_Activity", "ActivityID"));

                switch (activityType)
                {
                    // Purpose: Query To Insert Activity Type 'Skill Study Plan'
                    case Enumerations.ActivityType.SkillStudyPlan:
                        ExecuteQueryDb(StrConnection,
                                       "INSERT INTO BDD_Activity (ActivityID,ActivityTypeID,ActivityName,CreationStatus) values (" +
                                       (maxrow + 1) + "," + 1 + ",'" + activityName + "'," + Convert.ToByte(true) + ")");
                        break;
                    // Purpose: Query To Insert Activity Type 'Homework'
                    case Enumerations.ActivityType.Homework:
                        ExecuteQueryDb(StrConnection,
                                       "INSERT INTO BDD_Activity (ActivityID,ActivityTypeID,ActivityName,CreationStatus) values (" +
                                       (maxrow + 1) + "," + 2 + ",'" + activityName + "'," + Convert.ToByte(true) + ")");
                        break;
                    // Purpose: Query To Insert Activity Type 'MyTest'
                    case Enumerations.ActivityType.MyTest:
                        ExecuteQueryDb(StrConnection,
                                       "INSERT INTO BDD_Activity (ActivityID,ActivityTypeID,ActivityName,CreationStatus,SubmissionStatus) values (" +
                                       (maxrow + 1) + "," + 5 + ",'" + activityName + "'," + Convert.ToByte(true) + "," + Convert.ToByte(false) + ")");
                        break;
                    // Purpose: Query To Insert Activity Type 'Study Plan'
                    case Enumerations.ActivityType.StudyPlan:
                        ExecuteQueryDb(StrConnection,
                                       "INSERT INTO BDD_Activity (ActivityID,ActivityTypeID,ActivityName,CreationStatus,SubmissionStatus) values (" +
                                       (maxrow + 1) + "," + 6 + ",'" + activityName + "'," + Convert.ToByte(true) + "," + Convert.ToByte(false) + ")");
                        break;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Update Submission Status of Activity
        public static void UpdateSubmissionStatusOfActivity(string activityName)
        {
            try
            {
                // Purpose: Update Submission Status of the Activity
                ExecuteQueryDb(StrConnection, "UPDATE BDD_Activity SET SubmissionStatus ='" + Convert.ToByte(true) + "'WHERE ActivityName='" + activityName + "'");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Get Submission Status of Activity
        public static string GetSubmissionStatusOfActivity(Enumerations.ActivityType activityType)
        {
            string activitySubmissionStatus = string.Empty;
            // Purpose: Query To Retrieve Last Created Activity Type ID
            int activityTypeID = Convert.ToInt16(GetdataDb(StrConnection, "SELECT ActivityTypeID FROM BDD_ActivityTypeLookUp WHERE ActivityType='" + activityType + "'", "ActivityTypeID"));
            //Purpose: Execute Query Depend on the courseType
            switch (activityType)
            {
                // Purpose: Query To Retrieve Activity Type Essay
                case Enumerations.ActivityType.Essay:
                    // Purpose: Query To Retrieve Last Created Activity Name Row
                    int maxRowActivityEssay = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(ActivityID), 0) as ActivityID FROM BDD_Activity WHERE ActivityTypeID=" + activityTypeID + " and CreationStatus = 1", "ActivityID"));
                    // Purpose: Query To Retrieve Last Created Essay Activity
                    activitySubmissionStatus = GetdataDb(StrConnection, "SELECT SubmissionStatus FROM BDD_Activity WHERE ActivityTypeID = " + activityTypeID + " and ActivityID= " + maxRowActivityEssay + " and CreationStatus=1", "SubmissionStatus");
                    break;
                // Purpose: Query To Retrieve Activity Type Essay
                case Enumerations.ActivityType.StudyPlan:
                    // Purpose: Query To Retrieve Last Created Activity Name Row
                    int maxRowActivityStudyPlan = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(ActivityID), 0) as ActivityID FROM BDD_Activity WHERE ActivityTypeID=" + activityTypeID + " and CreationStatus = 1", "ActivityID"));
                    // Purpose: Query To Retrieve Last Created Essay Activity
                    activitySubmissionStatus = GetdataDb(StrConnection, "SELECT SubmissionStatus FROM BDD_Activity WHERE ActivityTypeID = " + activityTypeID + " and ActivityID= " + maxRowActivityStudyPlan + " and CreationStatus=1", "SubmissionStatus");
                    break;
                // Purpose: Query To Retrieve Activity Type Essay
                case Enumerations.ActivityType.SpWith1Rem:
                    // Purpose: Query To Retrieve Last Created Activity Name Row
                    int maxRowActivitySpWith1Rem = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(ActivityID), 0) as ActivityID FROM BDD_Activity WHERE ActivityTypeID=" + activityTypeID + " and CreationStatus = 1", "ActivityID"));
                    // Purpose: Query To Retrieve Last Created Essay Activity
                    activitySubmissionStatus = GetdataDb(StrConnection, "SELECT SubmissionStatus FROM BDD_Activity WHERE ActivityTypeID = " + activityTypeID + " and ActivityID= " + maxRowActivitySpWith1Rem + " and CreationStatus=1", "SubmissionStatus");
                    break;
                // Purpose: Query To Retrieve Activity Type Essay
                case Enumerations.ActivityType.Sp1With3Rem:
                    // Purpose: Query To Retrieve Last Created Activity Name Row
                    int maxRowActivitySp1With3Rem = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(ActivityID), 0) as ActivityID FROM BDD_Activity WHERE ActivityTypeID=" + activityTypeID + " and CreationStatus = 1", "ActivityID"));
                    // Purpose: Query To Retrieve Last Created Essay Activity
                    activitySubmissionStatus = GetdataDb(StrConnection, "SELECT SubmissionStatus FROM BDD_Activity WHERE ActivityTypeID = " + activityTypeID + " and ActivityID= " + maxRowActivitySp1With3Rem + " and CreationStatus=1", "SubmissionStatus");
                    break;
                // Purpose: Query To Retrieve Activity Type Essay
                case Enumerations.ActivityType.Sp2With3Rem:
                    // Purpose: Query To Retrieve Last Created Activity Name Row
                    int maxRowActivitySp2With3Rem = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(ActivityID), 0) as ActivityID FROM BDD_Activity WHERE ActivityTypeID=" + activityTypeID + " and CreationStatus = 1", "ActivityID"));
                    // Purpose: Query To Retrieve Last Created Essay Activity
                    activitySubmissionStatus = GetdataDb(StrConnection, "SELECT SubmissionStatus FROM BDD_Activity WHERE ActivityTypeID = " + activityTypeID + " and ActivityID= " + maxRowActivitySp2With3Rem + " and CreationStatus=1", "SubmissionStatus");
                    break;
            }
            return activitySubmissionStatus;
        }

        //Purpose: Method to Get Submission Status of Activity
        public static string GetPromotedAsTAstatus(Enumerations.UserType userType)
        {
            string promotedasTaStatus = string.Empty;
            switch (userType)
            {
                // Purpose: Query To Retrieve Activity Type Essay
                case Enumerations.UserType.CsSmsStudent:
                    // Purpose: Query To Retrieve Last Created Activity Name Row
                    int maxRowStudent = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(UserID), 0) as UserID FROM BDD_User WHERE UserTypeID=14 and CreationStatus = 1", "UserID"));
                    // Purpose: Query To Retrieve Last Created Essay Activity
                    promotedasTaStatus = GetdataDb(StrConnection, "SELECT PromotedAsTA FROM BDD_User WHERE UserTypeID = 14 and UserID= " + maxRowStudent + " and CreationStatus=1", "PromotedAsTA");
                    break;
            }
            return promotedasTaStatus;
        }

        //Purpose: Method to Update Program Details
        public static void UpdateProgram(string programName, string emptyCourse, Enumerations.ProgramInstance programInstance)
        {
            try
            {
                // Purpose: Query To SELECT Last Created Program Name
                int maxrow =
                    Convert.ToInt16(GetdataDb(StrConnection,
                                              "SELECT IsNull(MAX(ProgramID), 0) as ProgramID FROM BDD_Program",
                                              "ProgramID"));

                // Purpose: Query To SELECT Empty Course for Program Creation

                int courseid =
                 Convert.ToInt16(GetdataDb(StrConnection,
                                           "SELECT CourseID FROM BDD_Course WHERE Name='" + emptyCourse +
                                           "'and CreationStatus = 1", "CourseID"));



                int programInstanceId = Convert.ToInt32(programInstance);

                // Purpose: Query To Insert Program Details in DB
                ExecuteQueryDb(StrConnection,
                               "INSERT INTO BDD_Program (ProgramID,ProgramName,EmptyCourseID,CreationStatus,ProgramTypeID) values (" +
                               (maxrow + 1) + ",'" + programName + "'," + courseid + "," + Convert.ToByte(true) + "," + programInstanceId + ")");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Update Program Details for HED
        public static void UpdateHEDProgram(string programName, Enumerations.ProgramInstance programInstance)
        {
            try
            {

                // Purpose: Query To SELECT Last Created Program Name
                int maxrow =
                    Convert.ToInt16(GetdataDb(StrConnection,
                                              "SELECT IsNull(MAX(ProgramID), 0) as ProgramID FROM BDD_Program",
                                              "ProgramID"));

                int programInstanceId = Convert.ToInt32(programInstance);

                // Purpose: Query To Insert Program Details in DB
                ExecuteQueryDb(StrConnection,
                               "INSERT INTO BDD_Program (ProgramID,ProgramName,CreationStatus,ProgramTypeID) values (" +
                               (maxrow + 1) + ",'" + programName + "'," + Convert.ToByte(true) + "," + programInstanceId + ")");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Get Program Information FROM DB
        public static string GetProgram(Enumerations.ProgramInstance programInstance)
        {
            try
            {
                int programInstanceId = Convert.ToInt32(programInstance);
                int maxrowProgram = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(ProgramID), 0) as ProgramID FROM BDD_Program WHERE Creationstatus = 1and ProgramTypeID =" + programInstanceId, "ProgramID"));
                // Purpose: Query To SELECT Program Name
                string programName = GetdataDb(StrConnection, "SELECT ProgramName FROM BDD_Program WHERE  ProgramID = " + maxrowProgram, "ProgramName");
                return programName;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Update Product Details in DB
        public static void UpdateProduct(string productName, string programName, Enumerations.ProductInstance productInstance)
        {
            try
            {
                // Purpose: Query To SELECT Last Created Product Name
                int maxrow = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(ProductID), 0) as ProductID FROM BDD_Product", "ProductID"));

                // Purpose: Query To SELECT Program Name for Creation of Product
                int programid = Convert.ToInt16(GetdataDb(StrConnection, "SELECT ProgramID FROM BDD_Program WHERE ProgramName='" + programName + "'and CreationStatus = 1", "ProgramID"));

                int productInstanceId = Convert.ToInt32(productInstance);
                // Purpose: Query To Insert Product Name
                ExecuteQueryDb(StrConnection, "INSERT INTO BDD_Product (ProductID,ProductName,ProgramCourseID,CreationStatus,ProductTypeID) values (" + (maxrow + 1) + ",'" + productName + "'," + programid + "," + Convert.ToByte(true) + "," + productInstanceId + ")");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Get Product Name From DB
        public static string GetProduct(Enumerations.ProductInstance productInstance)
        {
            try
            {
                int productInstanceId = Convert.ToInt32(productInstance);
                int maxrowProduct = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(ProductID), 0) as ProductID FROM BDD_Product WHERE Creationstatus = 1and ProductTypeID =" + productInstanceId, "ProductID"));
                // Purpose: Query To SELECT Product Name
                string productName = GetdataDb(StrConnection, "SELECT ProductName FROM BDD_Product WHERE  ProductID = " + maxrowProduct, "ProductName");
                return productName;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Update Organization Details in DB with True Status
        public static void UpdateOrganizationTrue(string orgName, Enumerations.OrgLevelType orgLevelType)
        {
            try
            {
                // Purpose: Query To SELECT Last Created Organization Name
                int maxrow =
                    Convert.ToInt16(GetdataDb(StrConnection,
                                              "SELECT IsNull(MAX(OrgID), 0) as OrgID FROM BDD_Organization", "OrgID"));

                // Purpose: Query To SELECT Level Name for the Organization
                int levelId =
                    Convert.ToInt16(GetdataDb(StrConnection,
                                              "SELECT LevelID FROM BDD_OrgLeveTypeLookUp WHERE LevelName='" +
                                              orgLevelType + "'", "LevelID"));

                // Purpose: Query To Insert Organization Name
                ExecuteQueryDb(StrConnection,
                               "INSERT INTO BDD_Organization (OrgID,OrgName,LevelTypeID,CreationStatus) values (" +
                               (maxrow + 1) + ",'" + orgName + "'," + levelId + "," + Convert.ToByte(true) + ")");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Update Organization Details in DB with False Status
        public static void UpdateOrganizationFalse(string orgName, Enumerations.OrgLevelType orgLevelType)
        {
            try
            {
                // Purpose: Query To SELECT Last Created Organization Name
                int maxrow =
                    Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(OrgID), 0) as OrgID FROM BDD_Organization", "OrgID"));

                // Purpose: Query To SELECT Level Name for the Organization
                int levelId = Convert.ToInt16(GetdataDb(StrConnection, "SELECT LevelID FROM BDD_OrgLeveTypeLookUp WHERE LevelName='" + orgLevelType + "'", "LevelID"));

                // Purpose: Query To Insert Organization Name
                ExecuteQueryDb(StrConnection, "INSERT INTO BDD_Organization (OrgID,OrgName,LevelTypeID,CreationStatus) values (" + (maxrow + 1) + ",'" + orgName + "'," + levelId + "," + Convert.ToByte(false) + ")");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to get Organization Name From DB
        public static string GetOrganization(Enumerations.OrgLevelType orgLevelType)
        {
            try
            {
                // Purpose: Query To SELECT Organization Level 
                int levelId = Convert.ToInt16(GetdataDb(StrConnection, "SELECT LevelID FROM BDD_OrgLeveTypeLookUp WHERE LevelName='" + orgLevelType + "'", "LevelID"));

                // Purpose: Query To SELECT Last Created Organization
                int maxrow =
                    Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(OrgID), 0) as OrgID FROM BDD_Organization WHERE LevelTypeID=" + levelId + "", "OrgID"));

                // Purpose: Query To SELECT Organization 
                string orgName = GetdataDb(StrConnection, "SELECT OrgName FROM BDD_Organization WHERE LevelTypeID=" + levelId + " and CreationStatus = 1 and OrgID='" + maxrow + "'", "OrgName");
                return orgName;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Get District Level Organization From DB for Licensing
        public static string GetDistrictLevelforLicensing(Enumerations.OrgLevelType orgLevelType)
        {
            try
            {
                string orgName = string.Empty;
                switch (orgLevelType)
                {
                    // Purpose: Query To SELECT District Level of Organization 
                    case Enumerations.OrgLevelType.District:
                        orgName = GetdataDb(StrConnection,
                                            "SELECT top(1) OrgName FROM BDD_Organization WHERE LevelTypeID=3 and CreationStatus=1 ORDER BY OrgID DESC",
                                            "orgName");
                        break;
                    // Purpose: Query To SELECT Region Level of Organization 
                    case Enumerations.OrgLevelType.Region:
                        orgName = GetdataDb(StrConnection,
                                            "SELECT top(1) OrgName FROM BDD_Organization WHERE LevelTypeID=3 and CreationStatus=1 ORDER BY OrgID DESC",
                                            "orgName");
                        break;
                    // Purpose: Query To SELECT School Level of Organization 
                    case Enumerations.OrgLevelType.School:
                        orgName = GetdataDb(StrConnection,
                                            "SELECT top(1) OrgName FROM BDD_Organization WHERE LevelTypeID=3 and CreationStatus=1 ORDER BY OrgID DESC",
                                            "orgName");
                        break;
                    // Purpose: Query To SELECT State Level of Organization 
                    case Enumerations.OrgLevelType.State:
                        orgName = GetdataDb(StrConnection,
                                            "SELECT top(1) OrgName FROM BDD_Organization WHERE LevelTypeID=3 and CreationStatus=1 ORDER BY OrgID DESC",
                                            "orgName");
                        break;

                }
                return orgName;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Update Class in the DB
        public static void UpdateClass(Enumerations.ClassType classtype, string className)
        {
            try
            {
                // Purpose: Query To SELECT Last Created Class Name
                int maxrow =
                    Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(ClassId), 0) as ClassId FROM BDD_Class",
                                              "ClassId"));
                switch (classtype)
                {
                    // Purpose: Query To Insert Class Name created by using Template
                    case Enumerations.ClassType.NovaNETTemplate:
                        ExecuteQueryDb(StrConnection,
                                       "INSERT INTO BDD_Class (ClassId,ClassName,ClassTypeID,CreationStatus) values (" +
                                       (maxrow + 1) + ",'" + className + "'," + 1 + "," + Convert.ToByte(true) + ")");
                        break;
                    // Purpose: Query To Insert Class Name created by using Master Library
                    case Enumerations.ClassType.NovaNETMasterLibrary:
                        ExecuteQueryDb(StrConnection,
                                       "INSERT INTO BDD_Class (ClassId,ClassName,ClassTypeID,CreationStatus) values (" +
                                       (maxrow + 1) + ",'" + className + "'," + 2 + "," + Convert.ToByte(true) + ")");
                        break;
                    // Purpose: Query To Insert Placeholder Class Name
                    case Enumerations.ClassType.NovaNETPlaceHolder:
                        ExecuteQueryDb(StrConnection,
                                       "INSERT INTO BDD_Class (ClassId,ClassName,ClassTypeID,CreationStatus) values (" +
                                       (maxrow + 1) + ",'" + className + "'," + 5 + "," + Convert.ToByte(true) + ")");
                        break;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Get Class Name From the DB
        public static string GetClass(Enumerations.ClassType classtype)
        {
            try
            {
                string ClassName = string.Empty;
                // Purpose: Query To Retrieve Class Name created by using Master Library
                int classTypeID =
                    Convert.ToInt16(GetdataDb(StrConnection,
                                              "SELECT ClassTypeID FROM BDD_ClassTypeLookUp WHERE ClassType='" +
                                              classtype + "'", "ClassTypeID"));
                // Purpose: Query To Retrieve Last Created Class Name
                int maxrow =
                    Convert.ToInt16(GetdataDb(StrConnection,
                                              "SELECT IsNull(MAX(ClassID), 0) as ClassID FROM BDD_Class WHERE ClassTypeID=" +
                                              classTypeID + "", "ClassID"));

                // Purpose: Query To Retrieve Class Name created by using Template
                ClassName = GetdataDb(StrConnection,
                                      "SELECT ClassName FROM BDD_Class WHERE ClassTypeID=" + classTypeID +
                                      " and CreationStatus = 1 and ClassID='" + maxrow + "'", "ClassName");
                return ClassName;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Update Template Name in DB
        public static void UpdateTemplate(string templateName)
        {
            try
            {
                // Purpose: Query To SELECT Last Created Template Name
                int maxrow =
                    Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(TemplateID), 0) as TemplateID FROM BDD_Template",
                                              "TemplateID"));

                // Purpose: Query To Insert Template Name
                ExecuteQueryDb(StrConnection,
                               "INSERT INTO BDD_Template (TemplateID,TemplateName,CreationStatus) values (" +
                               (maxrow + 1) + ",'" + templateName + "'," + Convert.ToByte(true) + ")");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Get Template Name From the DB
        public static string GetTemplate()
        {
            try
            {
                string templateName;
                // Purpose: Query To SELECT Last Created Template Name
                int maxrow = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(TemplateID), 0) as TemplateID FROM BDD_Template", "TemplateID"));
                templateName = GetdataDb(StrConnection, "SELECT TemplateName FROM BDD_Template WHERE CreationStatus = 1 and TemplateID='" + maxrow + "'", "TemplateName");
                return templateName;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to get Activity Name From the DB
        public static string GetActivityName(Enumerations.ActivityType activityType)
        {
            try
            {
                string activityName = string.Empty;
                switch (activityType)
                {
                    // Purpose: Query To SELECT Last Created Activity Type Skill Study Plan
                    case Enumerations.ActivityType.SkillStudyPlan:
                        activityName = GetdataDb(StrConnection,
                                                 "SELECT top(1) ActivityName FROM BDD_Activity WHERE ActivityTypeID=1 and CreationStatus=1 ORDER BY ActivityID DESC",
                                                 "activityName");
                        break;
                    // Purpose: Query To SELECT Last Created Activity Type Homework
                    case Enumerations.ActivityType.Homework:
                        activityName = GetdataDb(StrConnection,
                                                 "SELECT top(1) ActivityName FROM BDD_Activity WHERE ActivityTypeID=2 and CreationStatus=1 ORDER BY ActivityID DESC",
                                                 "activityName");
                        break;
                    // Purpose: Query To SELECT Last Created Activity Type Folder
                    case Enumerations.ActivityType.Folder:
                        activityName = GetdataDb(StrConnection,
                                                 "SELECT top(1) ActivityName FROM BDD_Activity WHERE ActivityTypeID=3 and CreationStatus=1 ORDER BY ActivityID DESC",
                                                 "activityName");
                        break;
                    // Purpose: Query To SELECT Last Created Activity Type Essay
                    case Enumerations.ActivityType.Essay:
                        activityName = GetdataDb(StrConnection,
                                                 "SELECT top(1) ActivityName FROM BDD_Activity WHERE ActivityTypeID=4 and CreationStatus=1 ORDER BY ActivityID DESC",
                                                 "activityName");
                        break;

                    // Purpose: Query To SELECT Last Created Activity Type MyTest
                    case Enumerations.ActivityType.MyTest:
                        activityName = GetdataDb(StrConnection,
                                                 "SELECT top(1) ActivityName FROM BDD_Activity WHERE ActivityTypeID=5 and CreationStatus=1 ORDER BY ActivityID DESC",
                                                 "activityName");
                        break;
                    // Purpose: Query To SELECT Last Created Activity Type StudyPlan
                    case Enumerations.ActivityType.StudyPlan:
                        activityName = GetdataDb(StrConnection,
                                                 "SELECT top(1) ActivityName FROM BDD_Activity WHERE ActivityTypeID=6 and CreationStatus=1 ORDER BY ActivityID DESC",
                                                 "activityName");
                        break;
                    // Purpose: Query To SELECT Last Created Activity Type StudyPlan with 1 study material
                    case Enumerations.ActivityType.SpWith1Rem:
                        activityName = GetdataDb(StrConnection,
                                                 "SELECT top(1) ActivityName FROM BDD_Activity WHERE ActivityTypeID=7 and CreationStatus=1 ORDER BY ActivityID DESC",
                                                 "activityName");
                        break;
                    // Purpose: Query To SELECT Last Created Activity Type StudyPlan with 3 study materials
                    case Enumerations.ActivityType.Sp1With3Rem:
                        activityName = GetdataDb(StrConnection,
                                                 "SELECT top(1) ActivityName FROM BDD_Activity WHERE ActivityTypeID=8 and CreationStatus=1 ORDER BY ActivityID DESC",
                                                 "activityName");
                        break;
                    // Purpose: Query To SELECT Last Created Activity Type StudyPlan with 3 study materials
                    case Enumerations.ActivityType.Sp2With3Rem:
                        activityName = GetdataDb(StrConnection,
                                                 "SELECT top(1) ActivityName FROM BDD_Activity WHERE ActivityTypeID=9 and CreationStatus=1 ORDER BY ActivityID DESC",
                                                 "activityName");
                        break;

                   
                }
                return activityName;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Fetch Enabled Preference and Published CourseName From DB
        public static string GetEnabledCourse(Enumerations.CourseType courseType)
        {
            try
            {
                string courseName = string.Empty;

                // Purpose: Query To Retrieve Last Created Course Type ID
                int courseTypeID = Convert.ToInt16(GetdataDb(StrConnection, "SELECT CourseTypeID FROM BDD_CourseTypeLookUp WHERE CourseType='" + courseType + "'", "CourseTypeID"));

                //Purpose: Execute Query Depend on the courseType
                switch (courseType)
                {
                    // Purpose: Query To Retrieve Course Type Master Library
                    case Enumerations.CourseType.MasterLibrary:
                        // Purpose: Query To Retrieve Last Created Course Name Row
                        int maxRowMasterLibrary = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(CourseID), 0) as CourseID FROM BDD_Course WHERE CourseTypeID=" + courseTypeID + " and CreationStatus = 1 and PreferenceStatus = 0 and PublishStatus = 1", "CourseID"));
                        // Purpose: Query To Retrieve Last Created Course Name
                        courseName = GetdataDb(StrConnection, "SELECT Name FROM BDD_Course WHERE CourseTypeID = " + courseTypeID + " and CourseID= " + maxRowMasterLibrary + "", "Name");
                        break;
                    // Purpose: Query To Retrieve Course Type Empty Course
                    case Enumerations.CourseType.EmptyCourse:
                        // Purpose: Query To Retrieve Last Created Course Name Row
                        int maxRowEmptyCourse = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(CourseID), 0) as CourseID FROM BDD_Course WHERE CourseTypeID=" + courseTypeID + " and CreationStatus = 1 and PreferenceStatus = 1 and PublishStatus = 1", "CourseID"));
                        // Purpose: Query To Retrieve Last Created Course Name
                        courseName = GetdataDb(StrConnection, "SELECT Name FROM BDD_Course WHERE CourseTypeID = " + courseTypeID + " and CourseID= " + maxRowEmptyCourse + "", "Name");
                        break;
                    // Purpose: Query To Retrieve Course Type Container Course
                    case Enumerations.CourseType.ContainerCourse:
                        // Purpose: Query To Retrieve Last Created Course Name Row
                        int maxRowAuthoredContainerCourse = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(CourseID), 0) as CourseID FROM BDD_Course WHERE CourseTypeID=" + courseTypeID + " and CreationStatus = 1 and PreferenceStatus = 1 and PublishStatus = 1", "CourseID"));
                        // Purpose: Query To Retrieve Last Created Course Name
                        courseName = GetdataDb(StrConnection, "SELECT Name FROM BDD_Course WHERE CourseTypeID = " + courseTypeID + " and CourseID= " + maxRowAuthoredContainerCourse + "", "Name");
                        break;
                    // Purpose: Query To Retrieve Course Type Container Course
                    case Enumerations.CourseType.AuthoredMasterLibrary:
                        // Purpose: Query To Retrieve Last Created Course Name Row
                        int maxRowAuthoredMasterLibrary = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(CourseID), 0) as CourseID FROM BDD_Course WHERE CourseTypeID=" + courseTypeID + " and CreationStatus = 1 and PublishStatus = 1", "CourseID"));
                        // Purpose: Query To Retrieve Last Created Course Name
                        courseName = GetdataDb(StrConnection, "SELECT Name FROM BDD_Course WHERE CourseTypeID =  " + courseTypeID + " and CourseID= " + maxRowAuthoredMasterLibrary + "", "Name");
                        break;
                    case Enumerations.CourseType.MySpanishLabMasterCourse:
                        // Purpose: Query To Retrieve Last Created Course Name Row
                        int maxRowMySpanishLabMasterCourse = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(CourseID), 0) as CourseID FROM BDD_Course WHERE CourseTypeID=" + courseTypeID + " and CreationStatus = 1 and PublishStatus = 1", "CourseID"));
                        // Purpose: Query To Retrieve Last Created Course Name
                        courseName = GetdataDb(StrConnection, "SELECT Name FROM BDD_Course WHERE CourseTypeID =  " + courseTypeID + " and CourseID= " + maxRowMySpanishLabMasterCourse + "", "Name");
                        break;
                }
                return courseName;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Update Publish Status for the Course
        public static void UpdateCoursePrferenceStatusTrue(string courseName)
        {
            try
            {
                // Purpose: Execute Query To UPDATE PreferenceStatus
                ExecuteQueryDb(StrConnection,
                               "UPDATE BDD_Course SET PreferenceStatus='" + Convert.ToByte(true) + "'WHERE Name='" + courseName + "'");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to UPDATE Publish Status for the Course
        public static void UpdateCoursePublishStatusTrue(string courseName)
        {
            try
            {
                // Purpose: Execute Query To UPDATE Publish Status
                ExecuteQueryDb(StrConnection,
                               "UPDATE BDD_Course SET PublishStatus='" + Convert.ToByte(true) + "'WHERE Name='" + courseName + "'");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to UPDATE Approve Status for the Course
        public static void UpdateCourseApproveStatusTrue(string courseName)
        {
            try
            {
                // Purpose: Execute Query To UPDATE Publish Status
                ExecuteQueryDb(StrConnection,
                               "UPDATE BDD_Course SET ApproveStatus='" + Convert.ToByte(true) + "'WHERE Name='" + courseName + "'");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to GET Approve Status for the Course
        public static string GetCourseApproveStatus(Enumerations.CourseType courseType)
        {
            try
            {
                string courseApproveStatus = string.Empty;
                // Purpose: Query To Retrieve Last Created Course Type ID
                int courseTypeID = Convert.ToInt16(GetdataDb(StrConnection, "SELECT CourseTypeID FROM BDD_CourseTypeLookUp WHERE CourseType='" + courseType + "'", "CourseTypeID"));
                //Purpose: Execute Query Depend on the courseType
                switch (courseType)
                {
                    // Purpose: Query To Retrieve Course Type Master Library
                    case Enumerations.CourseType.MySpanishLabMasterCourse:
                        // Purpose: Query To Retrieve Last Created Course Name Row
                        int maxRowMasterLibrary = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(CourseID), 0) as CourseID FROM BDD_Course WHERE CourseTypeID=" + courseTypeID, "CourseID"));
                        // Purpose: Query To Retrieve Publish statusfor Ceated Course
                        courseApproveStatus = GetdataDb(StrConnection, "SELECT ApproveStatus FROM BDD_Course WHERE CourseTypeID = " + courseTypeID + " and CreationStatus = 1 and PublishStatus =1 and CourseID= " + maxRowMasterLibrary + "", "ApproveStatus");
                        break;
                }
                return courseApproveStatus;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to GET Publish Status for the Course
        public static string GetCoursePublishStatus(Enumerations.CourseType courseType)
        {
            try
            {
                string coursePublishStatus = string.Empty;
                // Purpose: Query To Retrieve Last Created Course Type ID
                int courseTypeID = Convert.ToInt16(GetdataDb(StrConnection, "SELECT CourseTypeID FROM BDD_CourseTypeLookUp WHERE CourseType='" + courseType + "'", "CourseTypeID"));
                //Purpose: Execute Query Depend on the courseType
                switch (courseType)
                {
                    // Purpose: Query To Retrieve Course Type Master Library
                    case Enumerations.CourseType.MySpanishLabMasterCourse:
                        // Purpose: Query To Retrieve Last Created Course Name Row
                        int maxRowMasterLibrary = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(CourseID), 0) as CourseID FROM BDD_Course WHERE CourseTypeID=" + courseTypeID, "CourseID"));
                        // Purpose: Query To Retrieve Publish statusfor Ceated Course
                        coursePublishStatus = GetdataDb(StrConnection, "SELECT PublishStatus FROM BDD_Course WHERE CourseTypeID = " + courseTypeID + " and CourseID= " + maxRowMasterLibrary + " and CreationStatus =1", "PublishStatus");
                        break;
                }
                return coursePublishStatus;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to UPDATE Prference Status for the Course
        public static void UpdateCoursePrferenceStatusFalse(string courseName)
        {
            try
            {
                // Purpose: Execute Query To UPDATE PreferenceStatus
                ExecuteQueryDb(StrConnection,
                               "UPDATE BDD_Course SET PreferenceStatus='" + Convert.ToByte(false) + "'WHERE Name='" + courseName + "'");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Update Publish Status for the Course
        public static void UpdateCoursePublishStatusFalse(string courseName)
        {
            try
            {
                // Purpose: Execute Query To UPDATE Publish Status
                ExecuteQueryDb(StrConnection,
                               "UPDATE BDD_Course SET PublishStatus='" + Convert.ToByte(false) + "'WHERE Name='" + courseName + "'");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Fetch Enabled Preference CourseName From DB
        public static string GetEnabledPreferenceCourse(Enumerations.CourseType courseType)
        {
            try
            {
                string courseName = string.Empty;

                // Purpose: Query To Retrieve Last Created Course Type ID
                int courseTypeID = Convert.ToInt16(GetdataDb(StrConnection, "SELECT CourseTypeID FROM BDD_CourseTypeLookUp WHERE CourseType='" + courseType + "'", "CourseTypeID"));

                switch (courseType)
                {
                    // Purpose: Query To Retrieve Course Type Empty Course
                    case Enumerations.CourseType.EmptyCourse:
                        // Purpose: Query To Retrieve Last Created Course Name Row
                        int maxRowEmptyCourse = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(CourseID), 0) as CourseID FROM BDD_Course WHERE CourseTypeID=" + courseTypeID + " and CreationStatus = 1 and PreferenceStatus = 1", "CourseID"));
                        // Purpose: Query To Retrieve Last Created Course Name
                        courseName = GetdataDb(StrConnection, "SELECT Name FROM BDD_Course WHERE CourseTypeID = " + courseTypeID + " and CourseID= " + maxRowEmptyCourse + "", "Name");
                        break;
                    // Purpose: Query To Retrieve Course Type Container Course
                    case Enumerations.CourseType.ContainerCourse:
                        // Purpose: Query To Retrieve Last Created Course Name Row
                        int maxRowContainerCourse = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(CourseID), 0) as CourseID FROM BDD_Course WHERE CourseTypeID=" + courseTypeID + " and CreationStatus = 1 and PreferenceStatus = 1", "CourseID"));
                        // Purpose: Query To Retrieve Last Created Course Name
                        courseName = GetdataDb(StrConnection, "SELECT Name FROM BDD_Course WHERE CourseTypeID = " + courseTypeID + " and CourseID= " + maxRowContainerCourse + "", "Name");
                        break;
                }
                return courseName;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Update Enroll  Status True for the User
        public static void UpdateUserEnrollStatusTrue(string username)
        {
            try
            {
                // Purpose: Execute Query To UPDATE Enroll Status
                ExecuteQueryDb(StrConnection,
                               "UPDATE BDD_User SET EnrollStatus='" + Convert.ToByte(true) + "'WHERE LoginName='" + username + "'");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Update Enroll  Status True for the User
        public static void UpdateUserPromotedStatusTrue(string username)
        {
            try
            {
                // Purpose: Execute Query To UPDATE Enroll Status
                ExecuteQueryDb(StrConnection,
                               "UPDATE BDD_User SET PromotedAsTA='" + Convert.ToByte(true) + "'WHERE LoginName='" + username + "'");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Update Enroll  Status False for the User
        public static void UpdateUserEnrollStatusFalse(string username)
        {
            try
            {
                // Purpose: Execute Query To UPDATE Enroll Status
                ExecuteQueryDb(StrConnection,
                               "UPDATE BDD_User SET EnrollStatus='" + Convert.ToByte(false) + "'WHERE LoginName='" + username + "'");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Fetch Enrolled User Name From DB
        public static string GetEnrolledUser(Enumerations.UserType userType)
        {
            try
            {
                string userName = string.Empty;
                switch (userType)
                {
                    // Purpose: Query To Retrieve User Type Ws Teacher
                    case Enumerations.UserType.WsTeacher:
                        userName = GetdataDb(StrConnection, "select LoginName from BDD_User where UserTypeID = 3 and CreationStatus = 1 and EnrollStatus = 1", "LoginName");
                        break;
                    // Purpose: Query To Retrieve User Type Cs Teacher
                    case Enumerations.UserType.CsTeacher:
                        userName = GetdataDb(StrConnection, "select LoginName from BDD_User where UserTypeID = 5 and CreationStatus = 1 and EnrollStatus = 1", "LoginName");
                        break;
                    // Purpose: Query To Retrieve User Type Cs Student
                    case Enumerations.UserType.CsTStudent:
                        userName = GetdataDb(StrConnection, "select LoginName from BDD_User where UserTypeID = 6 and CreationStatus = 1 and EnrollStatus = 1", "LoginName");
                        break;
                    // Purpose: Query To Retrieve User Type Cs Student
                    case Enumerations.UserType.HedWsInstructor:
                        userName = GetdataDb(StrConnection, "select LoginName from BDD_User where UserTypeID = 12 and CreationStatus = 1 and EnrollStatus = 1", "LoginName");
                        break;
                    // Purpose: Query To Retrieve User Type SMS Instructor
                    case Enumerations.UserType.CsSmsInstructor:
                        userName = GetdataDb(StrConnection, "select LoginName from BDD_User where UserTypeID = 13 and CreationStatus = 1 and EnrollStatus = 1", "LoginName");
                        break;
                    // Purpose: Query To Retrieve User Type SMS Student
                    case Enumerations.UserType.CsSmsStudent:
                        userName = GetdataDb(StrConnection, "select LoginName from BDD_User where UserTypeID = 14 and CreationStatus = 1 and EnrollStatus = 1", "LoginName");
                        break;
                }
                return userName;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Fetch UserName From DB
        public static string GetEnrolledUserLoginName(Enumerations.UserType userType)
        {
            try
            {
                string userName = string.Empty;

                // Purpose: Query To Retrieve Last Created User Type ID
                int userTypeID = Convert.ToInt16(GetdataDb(StrConnection, "SELECT UserTypeID FROM BDD_UserTypeLookUp WHERE UserType='" + userType + "'", "UserTypeID"));

                //Purpose: Execute Query Depend on the User Type
                switch (userType)
                {
                    // Purpose: Query To Retrieve User Type Ws Teacher
                    case Enumerations.UserType.WsTeacher:
                        // Purpose: Query To Retrieve Last Created User Name Row
                        int maxRowWsTeacher = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(UserID), 0) as UserID FROM BDD_User WHERE UserTypeID=" + userTypeID + " and CreationStatus = 1 and EnrollStatus = 0", "UserID"));
                        // Purpose: Query To Retrieve Last Created User Name
                        userName = GetdataDb(StrConnection, "SELECT LoginName FROM BDD_User WHERE UserTypeID = " + userTypeID + " and UserID= " + maxRowWsTeacher + "", "LoginName");
                        break;
                    // Purpose: Query To Retrieve User Type Cs Teacher
                    case Enumerations.UserType.CsTeacher:
                        // Purpose: Query To Retrieve Last Created User Name Row
                        int maxRowCsTeacher = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(UserID), 0) as UserID FROM BDD_User WHERE UserTypeID=" + userTypeID + " and CreationStatus = 1 and EnrollStatus = 1", "UserID"));
                        // Purpose: Query To Retrieve Last Created User Name
                        userName = GetdataDb(StrConnection, "SELECT LoginName FROM BDD_User WHERE UserTypeID = " + userTypeID + " and UserID= " + maxRowCsTeacher + "", "LoginName");
                        break;
                    // Purpose: Query To Retrieve Username for Cs Student
                    case Enumerations.UserType.CsStudent:
                        // Purpose: Query To Retrieve Last Created User Name Row
                        int maxRowCsStudent = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(UserID), 0) as UserID FROM BDD_User WHERE UserTypeID=" + userTypeID + " and CreationStatus = 1 and EnrollStatus = 1", "UserID"));
                        // Purpose: Query To Retrieve Last Created User Name
                        userName = GetdataDb(StrConnection, "SELECT LoginName FROM BDD_User WHERE UserTypeID = " + userTypeID + " and UserID= " + maxRowCsStudent + "", "LoginName");
                        break;
                    case Enumerations.UserType.CsSmsInstructor:
                        // Purpose: Query To Retrieve Last Created User Name Row
                        int maxRowHedcsTeacher = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(UserID), 0) as UserID FROM BDD_User WHERE UserTypeID=" + userTypeID + " and CreationStatus = 1", "UserID"));
                        // Purpose: Query To Retrieve Last Created User Name
                        userName = GetdataDb(StrConnection, "SELECT LoginName FROM BDD_User WHERE UserTypeID = " + userTypeID + " and UserID= " + maxRowHedcsTeacher + "", "LoginName");
                        break;
                    case Enumerations.UserType.CsSmsStudent:
                        // Purpose: Query To Retrieve Last Created User Name Row
                        int maxRowHedcsStudent = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(UserID), 0) as UserID FROM BDD_User WHERE UserTypeID=" + userTypeID + " and CreationStatus = 1", "UserID"));
                        // Purpose: Query To Retrieve Last Created User Name
                        userName = GetdataDb(StrConnection, "SELECT LoginName FROM BDD_User WHERE UserTypeID = " + userTypeID + " and UserID= " + maxRowHedcsStudent + "", "LoginName");
                        break;
                    case Enumerations.UserType.CsTeachingAssitant:
                        // Purpose: Query To Retrieve Last Created User Name Row
                        int maxRowHedcsTA = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(UserID), 0) as UserID FROM BDD_User WHERE UserTypeID=" + userTypeID + " and CreationStatus = 1 and PromotedAsTA =1", "UserID"));
                        // Purpose: Query To Retrieve Last Created User Name
                        userName = GetdataDb(StrConnection, "SELECT LoginName FROM BDD_User WHERE UserTypeID = " + userTypeID + " and UserID= " + maxRowHedcsTA + "", "LoginName");
                        break;

                }
                return userName;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Fetch UserName From DB
        public static string GetEnrolledTAUserName(Enumerations.UserType userType)
        {
            try
            {
                string userName = string.Empty;

                // Purpose: Query To Retrieve Last Created User Type ID
                int userTypeID = Convert.ToInt16(GetdataDb(StrConnection, "SELECT UserTypeID FROM BDD_UserTypeLookUp WHERE UserTypeID=14", "UserTypeID"));
              
                switch (userType)
                {
                    case Enumerations.UserType.CsTeachingAssitant:
                        // Purpose: Query To Retrieve Last Created User Name Row
                        int maxRowHedcsTA =
                            Convert.ToInt16(GetdataDb(StrConnection,
                                                      "SELECT IsNull(MAX(UserID), 0) as UserID FROM BDD_User WHERE UserTypeID=" +
                                                      userTypeID + " and CreationStatus = 1 and PromotedAsTA =1", "UserID"));
                        // Purpose: Query To Retrieve Last Created User Name
                        userName = GetdataDb(StrConnection,
                                             "SELECT LoginName FROM BDD_User WHERE UserTypeID = " + userTypeID +
                                             " and UserID= " + maxRowHedcsTA + "", "LoginName");
                        break;

                }
                return userName;
            }
                
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Fetch UserName From DB
        public static string GetEnrolledTAPassword(Enumerations.UserType userType)
        {
            try
            {
                string userPassword = string.Empty;

                // Purpose: Query To Retrieve Last Created User Type ID
                int userTypeID = Convert.ToInt16(GetdataDb(StrConnection, "SELECT UserTypeID FROM BDD_UserTypeLookUp WHERE UserTypeID=14", "UserTypeID"));

                switch (userType)
                {
                    case Enumerations.UserType.CsTeachingAssitant:
                        // Purpose: Query To Retrieve Last Created User Name Row
                        int maxRowHedcsTA = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(UserID), 0) as UserID FROM BDD_User WHERE UserTypeID=" + userTypeID + " and CreationStatus = 1 and PromotedAsTA = 1", "UserID"));
                        // Purpose: Query To Retrieve Last Created User Name
                        userPassword = GetdataDb(StrConnection, "SELECT Password FROM BDD_User WHERE UserTypeID = " + userTypeID + " and UserID= " + maxRowHedcsTA + "", "Password");
                        break;

                }
                return userPassword;
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Fetch Password From DB
        public static string GetEnrolledUserPassword(Enumerations.UserType userType)
        {
            try
            {
                string userPassword = string.Empty;

                // Purpose: Query To Retrieve Last Created User Type ID
                int userTypeID =
                    Convert.ToInt16(GetdataDb(StrConnection, "SELECT UserTypeID FROM BDD_UserTypeLookUp WHERE UserType='" + userType + "'", "UserTypeID"));

                //Purpose: Execute Query Depend on the User Type
                switch (userType)
                {
                    // Purpose: Query To Retrieve User Type Ws Teacher
                    case Enumerations.UserType.WsTeacher:
                        // Purpose: Query To Retrieve Last Created User Name Row
                        int maxRowWsTeacher = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(UserID), 0) as UserID FROM BDD_User WHERE UserTypeID=" + userTypeID + " and CreationStatus = 1 and EnrollStatus = 0", "UserID"));
                        // Purpose: Query To Retrieve Last Created User Name
                        userPassword = GetdataDb(StrConnection, "SELECT Password FROM BDD_User WHERE UserTypeID = " + userTypeID + " and UserID= " + maxRowWsTeacher + "", "Password");
                        break;
                    // Purpose: Query To Retrieve User Type Cs Teacher
                    case Enumerations.UserType.CsTeacher:
                        // Purpose: Query To Retrieve Last Created User Name Row
                        int maxRowCsTeacher = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(UserID), 0) as UserID FROM BDD_User WHERE UserTypeID=" + userTypeID + " and CreationStatus = 1 and EnrollStatus = 1", "UserID"));
                        // Purpose: Query To Retrieve Last Created User Name
                        userPassword = GetdataDb(StrConnection, "SELECT Password FROM BDD_User WHERE UserTypeID = " + userTypeID + " and UserID= " + maxRowCsTeacher + "", "Password");
                        break;
                    // Purpose: Query To Retrieve Username for Cs Student
                    case Enumerations.UserType.CsStudent:
                        // Purpose: Query To Retrieve Last Created User Name Row
                        int maxRowCsStudent = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(UserID), 0) as UserID FROM BDD_User WHERE UserTypeID=" + userTypeID + " and CreationStatus = 1 and EnrollStatus = 1", "UserID"));
                        // Purpose: Query To Retrieve Last Created User Name
                        userPassword = GetdataDb(StrConnection, "SELECT Password FROM BDD_User WHERE UserTypeID = " + userTypeID + " and UserID= " + maxRowCsStudent + "", "Password");
                        break;
                    case Enumerations.UserType.CsSmsInstructor:
                        // Purpose: Query To Retrieve Last Created User Name Row
                        int maxRowHedcsTeacher = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(UserID), 0) as UserID FROM BDD_User WHERE UserTypeID=" + userTypeID + " and CreationStatus = 1", "UserID"));
                        // Purpose: Query To Retrieve Last Created User Name
                        userPassword = GetdataDb(StrConnection, "SELECT Password FROM BDD_User WHERE UserTypeID = " + userTypeID + " and UserID= " + maxRowHedcsTeacher + "", "Password");
                        break;

                    case Enumerations.UserType.CsSmsStudent:
                        // Purpose: Query To Retrieve Last Created User Name Row
                        int maxRowHedcsStudent = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(UserID), 0) as UserID FROM BDD_User WHERE UserTypeID=" + userTypeID + " and CreationStatus = 1", "UserID"));
                        // Purpose: Query To Retrieve Last Created User Name
                        userPassword = GetdataDb(StrConnection, "SELECT Password FROM BDD_User WHERE UserTypeID = " + userTypeID + " and UserID= " + maxRowHedcsStudent + "", "Password");
                        break;
                    case Enumerations.UserType.CsTeachingAssitant:
                        // Purpose: Query To Retrieve Last Created User Name Row
                        int maxRowHedcsTA = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(UserID), 0) as UserID FROM BDD_User WHERE UserTypeID=" + userTypeID + " and CreationStatus = 1 and PromotedAsTA = 1", "UserID"));
                        // Purpose: Query To Retrieve Last Created User Name
                        userPassword = GetdataDb(StrConnection, "SELECT Password FROM BDD_User WHERE UserTypeID = " + userTypeID + " and UserID= " + maxRowHedcsTA + "", "Password");
                        break;
                }
                return userPassword;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Fetch Mater Course Associated Status for product From DB
        public static string GetProductMaterCourseAssociatedStatus(string productName)
        {
            try
            {
                string status = GetdataDb(StrConnection, "SELECT MCAssStatus FROM BDD_Product WHERE ProductName= '" + productName + "' ", "MCAssStatus");
                return status;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Purpose: Method to UPDATE MaterCourseAssociated Status for product
        public static void UpdateProductMaterCourseAssociatedStatus(string productName)
        {
            try
            {
                // Purpose: Execute Query To UPDATE MaterCourseAssociated Status
                ExecuteQueryDb(StrConnection,
                               "UPDATE BDD_Product SET MCAssStatus='" + Convert.ToByte(true) + "'WHERE ProductName='" + productName + "'");
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        //Purpose: Method to Update Enrol Course ID  For the HED Course
        public static void UpdateEnrolCourseID(string courseName, string enrolCourseID)
        {
            try
            {
                // Purpose: Execute Query To UPDATE Enroll Course ID
                ExecuteQueryDb(StrConnection, "UPDATE BDD_Course SET EnrolCourseID='" + enrolCourseID + "'WHERE Name='" + courseName + "'");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Get Enrol Course ID  For the HED Course
        public static string GetEnrolCourseID(Enumerations.CourseType courseType)
        {
            try
            {
                string courseEnrolID = string.Empty;
                // Purpose: Query To Retrieve Last Created Course Type ID
                int courseTypeID = Convert.ToInt16(GetdataDb(StrConnection, "SELECT CourseTypeID FROM BDD_CourseTypeLookUp WHERE CourseType='" + courseType + "'", "CourseTypeID"));
                //Purpose: Execute Query Depend on the courseType
                switch (courseType)
                {
                    // Purpose: Query To Retrieve Course Type Instructor Course
                    case Enumerations.CourseType.InstructorCourse:
                        // Purpose: Query To Retrieve Last Created Course Name Row
                        int maxInstructorCourse = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(CourseID), 0) as CourseID FROM BDD_Course WHERE CourseTypeID=" + courseTypeID, "CourseID"));
                        // Purpose: Query To Retrieve Enrol ID for Ceated Course
                        courseEnrolID = GetdataDb(StrConnection, "SELECT EnrolCourseID FROM BDD_Course WHERE CourseTypeID = " + courseTypeID + " and CourseID= " + maxInstructorCourse + " and CreationStatus =1", "enrolCourseID");
                        break;
                    // Purpose: Query To Retrieve Course Type Program Course
                    case Enumerations.CourseType.ProgramCourse:
                        // Purpose: Query To Retrieve Last Created Course Name Row
                        int maxProgramCourse = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(CourseID), 0) as CourseID FROM BDD_Course WHERE CourseTypeID=" + courseTypeID, "CourseID"));
                        // Purpose: Query To Retrieve Enrol ID for Ceated Course
                        courseEnrolID = GetdataDb(StrConnection, "SELECT EnrolCourseID FROM BDD_Course WHERE CourseTypeID = " + courseTypeID + " and CourseID= " + maxProgramCourse + " and CreationStatus =1", "enrolCourseID");
                        break;
                  

                }
                return courseEnrolID;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Update Section Name for the Program Course
        public static void UpdateSectionName(string sectionName)
        {
            try
            {
                // Purpose: Execute Query To UPDATE PreferenceStatus
                ExecuteQueryDb(StrConnection, "UPDATE BDD_Course SET SectionName ='" + sectionName + "'  WHERE CourseTypeID= 10");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method to Get Section Name for the Program Course
        public static string GetSectionName(Enumerations.CourseType courseType)
        {
            try
            {
                string sectionName = string.Empty;
                // Purpose: Query To Retrieve Last Created Course Type ID
                int courseTypeID = Convert.ToInt16(GetdataDb(StrConnection, "SELECT CourseTypeID FROM BDD_CourseTypeLookUp WHERE CourseType='" + courseType + "'", "CourseTypeID"));
                //Purpose: Execute Query Depend on the courseType
                switch (courseType)
                {
                    // Purpose: Query To Retrieve Course Type Instructor Course
                    case Enumerations.CourseType.ProgramCourse:
                        // Purpose: Query To Retrieve Last Created Course Name Row
                        int maxInstructorCourse = Convert.ToInt16(GetdataDb(StrConnection, "SELECT IsNull(MAX(CourseID), 0) as CourseID FROM BDD_Course WHERE CourseTypeID=" + courseTypeID, "CourseID"));
                        // Purpose: Query To Retrieve Enrol ID for Ceated Course
                        sectionName = GetdataDb(StrConnection, "SELECT SectionName FROM BDD_Course WHERE CourseTypeID = " + courseTypeID + " and CourseID= " + maxInstructorCourse + " and CreationStatus =1", "sectionName");
                        break;
                }
                return sectionName;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}




