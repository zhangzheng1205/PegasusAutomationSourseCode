using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Configuration;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.RestServicePost;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using System.Threading;
using System.Text.RegularExpressions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class contains static utility methods that are used by contineo project.
    /// </summary>
    public class PostRestServicePage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(PostRestServicePage));

        /// <summary>
        /// Get CMS Subscription Url From Config.
        /// </summary>
        String getProsperoClassEventTestClientUrl = ConfigurationManager.
            AppSettings["ProsperoClassEventTestClientURL"];

        /// <summary>
        /// Get Service Absolute URL
        /// </summary>
        String getAbsoluteURL = ConfigurationManager.
            AppSettings["ServiceURL"];

        /// <summary>
        /// This is the service request Enum.
        /// </summary>
        public enum EventEnum
        {
            // This is create event
            Create = 1,
            // this is update event
            Update = 2,
            // this is delete event
            Unenroll = 3,
        }

        /// <summary>
        /// This is the Posting Data In Mock Enum.
        /// </summary>
        public enum PostingTheDataInMockEnum
        {
            //this is to post the Item
            ItemPost = 1,
            //This is to post the Grade 
            GradePost = 2
        }

        /// <summary>
        /// This function is responsible for processing the request on basis of event.
        /// </summary>
        /// <param name="eventEnum">This is the event type.</param>
        /// <param name="classId">This is the class id.</param>
        /// <param name="className">This is the class name.</param>
        /// <param name="organizationId">This is the organization id.</param>
        /// <param name="ownerId">This is the owner id.</param>
        /// <param name="studentId">This is the studnet id.</param>
        /// <param name="rumbaProductId">This is the remba product id.</param>
        public String ProcessRequest(PostRestServicePage.EventEnum eventEnum, String classId,
            String className, String organizationId,
            String ownerId, String studentId, String rumbaProductId)
        {
            Logger.LogMethodEntry("PostRestServicePage", "ProcessRequest",
           base.IsTakeScreenShotDuringEntryExit);
            // This is the request body 
            string getRequestBody = string.Empty;
            // This is the status
            switch (eventEnum)
            {
                case PostRestServicePage.EventEnum.Create:
                    // this is the request body for create
                    getRequestBody = GetJsonRequestToCreateClass(
                    classId, className, organizationId, ownerId, studentId, rumbaProductId);
                    break;
                case PostRestServicePage.EventEnum.Update:
                    // this is the request body for Update 
                    getRequestBody = GetJsonRequestToUpdateUserDetails(
                    classId, className, organizationId, ownerId);
                    break;
                case PostRestServicePage.EventEnum.Unenroll:
                    // this is the request body for unenroll user
                    getRequestBody = GetJsonRequestToUnenrollUser(classId,
                         className, organizationId, ownerId);
                    break;
            }
            // Get the service status
            string getStatus = GetTheServiceStatus(getRequestBody);
            Logger.LogMethodExit("PostRestServicePage", "ProcessRequest",
           base.IsTakeScreenShotDuringEntryExit);
            return getStatus;
        }

        /// <summary>
        /// This method is used to get the JSON status.
        /// </summary>
        /// <param name="request">This is the requested body.</param>
        /// <returns>Status of Request.</returns>
        public String GetTheServiceStatus(String request)
        {
            Logger.LogMethodEntry("PostRestServicePage", "GetCreateClassStatus",
            base.IsTakeScreenShotDuringEntryExit);
            // This is the relative URL
            string getRelativeURL = PostRestServiceResource.
                PostRestService_Page_Relative_Path;
            // Append the url with the relative URL
            string getCompleteURL = getAbsoluteURL + getRelativeURL;
            //Send CMS Subscription Request
            this.CreateCmsSSubscription(request, getCompleteURL);
            Logger.LogMethodExit("PostRestServicePage", "GetCreateClassStatus",
                base.IsTakeScreenShotDuringEntryExit);
            return GetPostServiceResponse();
        }

        /// <summary>
        /// Get Post Service Response.
        /// </summary>
        /// <returns>Returns The Status of The Service Response.</returns>
        private String GetPostServiceResponse()
        {
            //Get Service Response
            Logger.LogMethodEntry("PostRestServicePage", "GetPostServiceResponse",
               base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(PostRestServiceResource.
                PostRestService_Page_Response_TextBox_Id_Locator));
            // Get complete response status
            String getResponseStatus = base.GetElementTextById(PostRestServiceResource.
                PostRestService_Page_Response_TextBox_Id_Locator);
            //Get the service status from the response
            String[] getServiceCodeStatus = getResponseStatus.Split('>');
            // Get OK status
            String getOKStatus = getServiceCodeStatus[4].Substring(0, 2);
            Logger.LogMethodExit("PostRestServicePage", "GetPostServiceResponse",
                base.IsTakeScreenShotDuringEntryExit);
            return getOKStatus;
        }

        /// <summary>
        /// Create CMS Subscription Request.
        /// </summary>
        /// <param name="request">This is Json Request.</param>
        /// <param name="serviceURL">This is post request relative Url.</param>
        private void CreateCmsSSubscription(String request, String serviceURL)
        {
            //Create CMS Subscription
            Logger.LogMethodEntry("PostRestServicePage", "CreateCmsSSubscription",
                base.IsTakeScreenShotDuringEntryExit);
            //Open The CMS Url
            base.NavigateToBrowseUrl(getProsperoClassEventTestClientUrl);
            //Select Base Window
            base.SelectDefaultWindow();
            //Wait For Element
            base.WaitForElement(By.Id(PostRestServiceResource.
                PostRestService_Page_PostServiceURL_TextBox_Id_Locator), 10);
            //Fill Relative Url In TextBox
            base.FillTextBoxById(PostRestServiceResource.
                PostRestService_Page_PostServiceURL_TextBox_Id_Locator, serviceURL);
            //Wait For Element
            base.WaitForElement(By.Id(PostRestServiceResource.
                PostRestService_Page_JsonRequest_TextBox_Id_Locator));
            //Fill Json Request In TextBox
            base.FillTextBoxById(PostRestServiceResource.
                PostRestService_Page_JsonRequest_TextBox_Id_Locator, request);
            //Wait For Element
            base.WaitForElement(By.Id(PostRestServiceResource.
                PostRestService_Page_Post_Button_Id_Locator));
            //Click Post Button
            base.ClickButtonById(PostRestServiceResource.
                PostRestService_Page_Post_Button_Id_Locator);
            Logger.LogMethodExit("PostRestServicePage", "CreateCmsSSubscription",
                true);
        }

        /// <summary>
        /// This method prepares the JSON that will be posted as part of the CreateClass request.
        /// </summary>
        /// <param name="classId">This is section ID.</param>
        /// <param name="className">This is section Name.</param>
        /// <param name="organizationId">This is Organization ID.</param>
        /// <param name="ownerId">This is Teacher ID.</param>
        /// <param name="studentId">This is student ID.</param>
        /// <param name="rumbaProductId">This is Rumba Product ID.</param>
        /// <returns>JSON Request.</returns>
        private String GetJsonRequestToCreateClass(String classId,
            String className, String organizationId,
            String ownerId, String studentId, String rumbaProductId)
        {
            Logger.LogMethodEntry("PostRestServicePage", "GetJsonRequest",
            base.IsTakeScreenShotDuringEntryExit);
            Logger.LogMethodExit("PostRestServicePage", "GetJsonRequest",
              base.IsTakeScreenShotDuringEntryExit);
            // This is the JSON request 
            return string.Format(PostRestServiceResource.PostRestService_Page_JSON_Create_Request,
                classId, className, organizationId, studentId, ownerId, rumbaProductId);
        }

        /// <summary>
        /// This method prepares the JSON that will be posted as part of the Schedular Service.
        /// </summary>
        /// <param name="classId">This is section ID.</param>
        /// <param name="className">This is section Name.</param>
        /// <param name="organizationId">This is Organization ID.</param>
        /// <param name="ownerId">This is Teacher ID.</param>
        /// <returns>JSON Request</returns>
        private String GetJsonRequestToUpdateUserDetails(String classId,
            String className, String organizationId,
            String ownerId)
        {
            Logger.LogMethodEntry("PostRestServicePage", "GetJsonRequestToUpdateUserDetails",
            base.IsTakeScreenShotDuringEntryExit);
            Logger.LogMethodExit("PostRestServicePage", "GetJsonRequestToUpdateUserDetails",
              base.IsTakeScreenShotDuringEntryExit);
            // This is the JSON request 
            return string.Format(PostRestServiceResource.PostRestService_Page_JSON_Update_Request,
                classId, className, organizationId, ownerId);
        }

        /// <summary>
        /// This method prepares the JSON that will be posted as part of Unenroll Event.
        /// </summary>
        /// <param name="classId">This is section ID.</param>
        /// <param name="className">This is section Name.</param>
        /// <param name="organizationId">This is Organization ID.</param>
        /// <param name="ownerId">This is Teacher ID.</param>
        /// <returns>JSON Request</returns>
        private String GetJsonRequestToUnenrollUser(String classId,
            String className, String organizationId,
            String ownerId)
        {
            Logger.LogMethodEntry("PostRestServicePage", "GetJsonRequestToUnenrollUser",
            base.IsTakeScreenShotDuringEntryExit);
            Logger.LogMethodExit("PostRestServicePage", "GetJsonRequestToUnenrollUser",
              base.IsTakeScreenShotDuringEntryExit);
            // This is the JSON request 
            return string.Format(PostRestServiceResource.PostRestService_Page_JSON_Unenroll_Request,
                classId, className, organizationId, ownerId);
        }

        /// <summary>
        /// This method is used for saving the section ID with the corresponding class name.
        /// </summary>
        public void StoreSectionIDWithClassName()
        {
            Logger.LogMethodEntry("PostRestServicePage", "StoreSectionIDWithClassName",
             base.IsTakeScreenShotDuringEntryExit);
            // This is the Class Section ID
            Guid classID = Guid.NewGuid();
            // This is the classname
            Guid className = Guid.NewGuid();
            // store class name w.r.t to section id
            Class rumbaClass = new Class
            {
                RumbaSectionID = classID.ToString(),
                Name = className.ToString(),
                IsCreated = true,
                ClassType = Class.ClassTypeEnum.DigitalPathContineoMasterLibrary,
            };
            rumbaClass.StoreClassInMemory();
            Logger.LogMethodExit("PostRestServicePage", "StoreSectionIDWithClassName",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter The Course Details To Mock Application.
        /// </summary>
        /// <param name="courseId">This is Pegasus CourseID.</param>
        public void EnterTheCourseDetailsInMockApplication(string courseId)
        {
            //Enter The Course Details To Mock Application
            Logger.LogMethodEntry("PostRestServicePage",
                "EnterTheCourseDetailsInMockApplication",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the window
                new ContentLibraryUXPage().SelectTheWindowName(PostRestServiceResource.
                    PostRestServicePage_FetchExternalCourse_Window_Name);
                string authorizationKey = PostRestServiceResource.
                    PostRestServicePage_Authorization_KeyValue;
                //Fill The Authorization Key Value
                this.FillTheMockApplicationDetailsValue(authorizationKey,
                    PostRestServiceResource.
                    PostRestServicePage_Authorization_Key_TextBox_Id_Locator);
                //Fill the CourseId
                this.FillTheMockApplicationDetailsValue(courseId,
                    PostRestServiceResource.
                    PostRestServicePage_PegasusCourseId_TextBox_Id_Locator);
                //Click The External CourseID Button
                this.ClickTheExternalCourseIDButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("PostRestServicePage",
                "EnterTheCourseDetailsInMockApplication",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill The Mock Application Details Value.
        /// </summary>
        /// <param name="mockDetailsValue">This is textbox mock detail value.</param>
        /// <param name="textBoxID">This is Textbox Id locator.</param>
        private void FillTheMockApplicationDetailsValue(
            string mockDetailsValue, string textBoxID)
        {
            //Fill The Mock Application Details Value
            Logger.LogMethodEntry("PostRestServicePage",
                "FillTheMockApplicationDetailsValue", base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(textBoxID));
            //Clear the textbox
            base.GetWebElementPropertiesById(textBoxID).Clear();
            //Enter the value
            base.GetWebElementPropertiesById(textBoxID).SendKeys(mockDetailsValue);
            Logger.LogMethodExit("PostRestServicePage",
                "FillTheMockApplicationDetailsValue", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Click The External CourseID Button.
        /// </summary>
        private void ClickTheExternalCourseIDButton()
        {
            //Click The External CourseID Button
            Logger.LogMethodEntry("PostRestServicePage", "ClickTheExternalCourseIDButton",
             base.IsTakeScreenShotDuringEntryExit);
            //Wait for the External CourseID button
            base.WaitForElement(By.Id(PostRestServiceResource.
                PostRestServicePage_ExternalCourseId_Button_Id_Locator));
            IWebElement getExternalCourseIdButton = base.GetWebElementPropertiesById
                (PostRestServiceResource.
                PostRestServicePage_ExternalCourseId_Button_Id_Locator);
            //Click on the 'External CourseID' button
            base.ClickByJavaScriptExecutor(getExternalCourseIdButton);
            Logger.LogMethodExit("PostRestServicePage", "ClickTheExternalCourseIDButton",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get External CourseID.
        /// </summary>
        /// <returns>CourseID.</returns>
        public String GetExternalCourseID()
        {
            //Get External CourseID
            Logger.LogMethodEntry("PostRestServicePage", "GetExternalCourseID",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialized Course Text
            string getCourseId = string.Empty;
            try
            {
                //Wait for Element
                base.WaitForElement(By.Id(PostRestServiceResource.
                    PostRestServicePage_ExternalCourseId_TextBox_Id_Locator));
                //Get Course Text
                getCourseId = base.GetElementTextById(PostRestServiceResource.
                    PostRestServicePage_ExternalCourseId_TextBox_Id_Locator);
                //Store External courseId in Memory
                this.StoreExternalCourseIDInMemory(getCourseId);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("PostRestServicePage", "GetExternalCourseID",
                base.IsTakeScreenShotDuringEntryExit);
            return getCourseId;
        }

        /// <summary>
        ///Store External CourseID In Memory .
        /// </summary>
        /// <param name="getCourseId">This is CourseID.</param>
        private void StoreExternalCourseIDInMemory(string getCourseId)
        {
            //Store External CourseID In Memory .
            Logger.LogMethodEntry("PostRestServicePage",
                "StoreExternalCourseIDInMemory", base.IsTakeScreenShotDuringEntryExit);
            //Store the CourseId into memory
            Course course = new Course
            {
                ExternalCourseId = getCourseId,
                CourseType = Course.CourseTypeEnum.ExternalCourse,
                IsCreated = true,
            };
            course.StoreCourseInMemory();
            Logger.LogMethodExit("PostRestServicePage",
                "StoreExternalCourseIDInMemory", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Browse The Writing Spce Mock ApplicationURL.
        /// </summary>
        /// <param name="writingSpaceMockUrl">This is Url fetch from Appconfig.</param>
        public void BrowseTheWritingSpceMockApplicationURL(string writingSpaceMockUrl)
        {
            //Browse The Writing Spce Mock ApplicationURL
            Logger.LogMethodEntry("PostRestServicePage",
                "BrowseTheWritingSpceMockApplicationURL",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Browse the url
                base.NavigateToBrowseUrl(writingSpaceMockUrl);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("PostRestServicePage",
                "BrowseTheWritingSpceMockApplicationURL",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Url in Mock Application.
        /// </summary>
        /// <param name="itemUrl">This is Item Url.</param>
        /// <param name="externalCourseId">This is External Course Id.</param>
        /// <param name="appendValue">This is Append Value.</param>
        public void EnterUrlInMockApplication(
            PostingTheDataInMockEnum postingTheDataInMockEnum,
            string getWritingspaceHeaderUrl, string externalCourseId, string appendValue)
        {
            //Enter Url in Mock Application
            Logger.LogMethodEntry("PostRestServicePage", "EnterUrlInMockApplication",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getConcatenatedItemUrl = string.Empty;
            //Initialize Variable
            string getConcatenatedGradeUrl = string.Empty;
            try
            {
                //Select the window
                new ContentLibraryUXPage().SelectTheWindowName(PostRestServiceResource.
                    PostRestServicePage_HomePage_Mock_Window_Name);
                switch (postingTheDataInMockEnum)
                {
                    case PostingTheDataInMockEnum.ItemPost:
                        //Get Concatenated item URL
                        getConcatenatedItemUrl =
                            getWritingspaceHeaderUrl + externalCourseId + appendValue;
                        //Fill The Post Item URL Value
                        this.FillTheMockApplicationDetailsValue(getConcatenatedItemUrl,
                            PostRestServiceResource.PostRestServicePage_URL_Text_Id_Locator);
                        break;
                    case PostingTheDataInMockEnum.GradePost:
                        //Fetch the activity from memory
                        Activity activity = Activity.Get(Activity.ActivityTypeEnum.WritingSpace);
                        //Get the concatenated grade URL
                        getConcatenatedGradeUrl = getWritingspaceHeaderUrl + externalCourseId +
                            appendValue +
                            PostRestServiceResource.PostRestServicePage_HeaderUrl_Slash_Character
                            + activity.ActivityId +
                            PostRestServiceResource.PostRestServicePage_HeaderUrl_Appendgrades;
                        //Fill The Post Grade URL Value
                        this.FillTheMockApplicationDetailsValue(getConcatenatedGradeUrl,
                            PostRestServiceResource.PostRestServicePage_URL_Text_Id_Locator);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("PostRestServicePage", "EnterUrlInMockApplication",
                          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Request Type Option.
        /// </summary>
        /// <param name="requestType">This is Request Type.</param>
        public void SelectRequestTypeOption(string requestType)
        {
            //Select Request Type Option
            Logger.LogMethodEntry("PostRestServicePage", "SelectRequestTypeOption",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the window
                new ContentLibraryUXPage().SelectTheWindowName(PostRestServiceResource.
                    PostRestServicePage_HomePage_Mock_Window_Name);
                base.WaitForElement(By.Id(PostRestServiceResource.
                    PostRestServicePage_RequestType_Dropdown_Id_Locator));
                //Select Post Request Option
                base.SelectDropDownValueThroughTextById(PostRestServiceResource.
                    PostRestServicePage_RequestType_Dropdown_Id_Locator, requestType);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("PostRestServicePage", "SelectRequestTypeOption",
                          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Send The Request Details To Add Activity In GBR.
        /// </summary>
        /// <param name="activity">This is post Data Type Enum.</param>
        public void SendTheRequestDetailsToAddActivityInGBR(
            PostingTheDataInMockEnum postingTheDataInMockEnum)
        {
            //Get Searched Course in Course Space
            Logger.LogMethodEntry("PostRestServicePage",
                "SendTheRequestDetailsToAddActivityInGBR",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Fetch the Course ID from memory
                Course course = Course.Get(Course.CourseTypeEnum.ExternalCourse);
                string getcourseId = course.ExternalCourseId;
                Activity activity = Activity.Get(Activity.ActivityTypeEnum.WritingSpace);
                //Split the course id
                string getexternalCorseId = getcourseId.Split(Convert.ToChar
                    (PostRestServiceResource.PostRestServicePage_Split_ColonSeperated))
                    [Convert.ToInt32(PostRestServiceResource.
                    PostRestServicePage_Split_Array_SecondValue)];
                //Select the window
                new ContentLibraryUXPage().SelectTheWindowName(PostRestServiceResource.
                    PostRestServicePage_HomePage_Mock_Window_Name);
                switch (postingTheDataInMockEnum)
                {
                    case PostingTheDataInMockEnum.ItemPost:
                        //Enter the course details in Requestbody
                        this.EnterTheCourseDetailsInRequestBody(getcourseId,
                            getexternalCorseId, activity.Name);
                        break;
                    case PostingTheDataInMockEnum.GradePost:
                        //Enter The Course Details To Post The Grade In RequestBody
                        this.EnterTheCourseDetailsToPostTheGradeInRequestBody(getcourseId,
                            getexternalCorseId);
                        break;
                }
                //Click The Execute Button
                this.ClickTheExecuteButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("PostRestServicePage",
                "SendTheRequestDetailsToAddActivityInGBR",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="getcourseId"></param>
        /// <param name="getexternalCorseId"></param>
        private void EnterTheCourseDetailsToPostTheGradeInRequestBody(
            string getcourseId, string getexternalCorseId)
        {
            //Enter the course details in Requestbody
            Logger.LogMethodEntry("PostRestServicePage",
                "EnterTheCourseDetailsToPostTheGradeInRequestBody",
               base.IsTakeScreenShotDuringEntryExit);
            // This is the request body 
            string getRequestBody = string.Empty;
            // this is the request body for add activity
            getRequestBody = PostRestServiceResource.
                PostRestService_Page_GradePostJSON_GBR_Request;
            string getReplaceRequestDetails = getRequestBody.
                Replace(PostRestServiceResource.
                PostRestServicePage_requestbody_CourseId_Value, getcourseId).
                Replace(PostRestServiceResource.
                PostRestServicePage_requestbody_ExternalCourseId_Value, getexternalCorseId);
            //Fill The Authorization Key Value
            this.FillTheMockApplicationDetailsValue(getReplaceRequestDetails,
                PostRestServiceResource.
                PostRestServicePage_RequestBody_TextBox_Id_Locator);
            Logger.LogMethodExit("PostRestServicePage",
               "EnterTheCourseDetailsToPostTheGradeInRequestBody",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter the course details in Requestbody.
        /// </summary>
        /// <param name="getcourseId">this is CourseId Value.</param>
        /// <param name="getexternalCorseId">This is External CourseId Split Value.</param>
        /// <param name="activity">This is Activity Name.</param>
        private void EnterTheCourseDetailsInRequestBody(string getcourseId,
            string getexternalCorseId, string activity)
        {
            //Enter the course details in Requestbody
            Logger.LogMethodEntry("PostRestServicePage",
                "EnterTheCourseDetailsInRequestBody",
               base.IsTakeScreenShotDuringEntryExit);
            // This is the request body 
            string getRequestBody = string.Empty;
            // this is the request body for add activity
            getRequestBody = PostRestServiceResource.
                PostRestService_Page_ItemPostJSON_GBR_Request;
            string getReplaceRequestDetails = getRequestBody.
                Replace(PostRestServiceResource.
                PostRestServicePage_requestbody_CourseId_Value, getcourseId).
                Replace(PostRestServiceResource.
                PostRestServicePage_requestbody_ExternalCourseId_Value, getexternalCorseId).
                Replace(PostRestServiceResource.
                PostRestServicePage_requestbody_Activity_Value, activity);
            //Fill The Authorization Key Value
            this.FillTheMockApplicationDetailsValue(getReplaceRequestDetails,
                PostRestServiceResource.
                PostRestServicePage_RequestBody_TextBox_Id_Locator);
            Logger.LogMethodExit("PostRestServicePage",
               "EnterTheCourseDetailsInRequestBody",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Execute Button.
        /// </summary>
        private void ClickTheExecuteButton()
        {
            //Click The Execute Button
            Logger.LogMethodEntry("PostRestServicePage", "ClickTheExecuteButton",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(PostRestServiceResource.
                PostRestServicePage_MockApplication_ExecuteButton_Id_Locator));
            IWebElement getExicuteButton = base.GetWebElementPropertiesById
                (PostRestServiceResource.
                PostRestServicePage_MockApplication_ExecuteButton_Id_Locator);
            //Click the 'Execute' button
            base.ClickByJavaScriptExecutor(getExicuteButton);
            Thread.Sleep(Convert.ToInt32(PostRestServiceResource.
                PostRestServicePage_Element_Delay));
            Logger.LogMethodExit("PostRestServicePage", "ClickTheExecuteButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get The Response From Mock Appication.
        /// </summary>
        /// <returns>Response Text.</returns>
        public String GetTheResponseFromMockAppication()
        {
            //Get The Response From Mock Appication
            Logger.LogMethodEntry("PostRestServicePage",
                "GetTheResponseFromMockAppication",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialized Response Text
            string getResponseDetails = string.Empty;
            try
            {
                //Wait for Element
                base.WaitForElement(By.Id(PostRestServiceResource.
                    PostRestServicePage_ResponseBody_TextBox_Id_Locator));
                //Get Response Text
                getResponseDetails = base.GetElementTextById(PostRestServiceResource.
                    PostRestServicePage_ResponseBody_TextBox_Id_Locator);
                //Get the ItemId
                string getItemId = Regex.Split(getResponseDetails, PostRestServiceResource.
                    PostRestServicePage_Split_MultipleSeperated_Value)
                    [Convert.ToInt16(PostRestServiceResource.
                    PostRestServicePage_Split_Array_FirstValue)].
                    Split(Convert.ToChar(PostRestServiceResource.
                    PostRestServicePage_Split_Quotes_Value))
                    [Convert.ToInt16(PostRestServiceResource.
                    PostRestServicePage_Split_Array_ZeroValue)];
                //Store ItemID in Memory
                this.StoreTheActivityIDInMemory(getItemId);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("PostRestServicePage",
                "GetTheResponseFromMockAppication",
                base.IsTakeScreenShotDuringEntryExit);
            return getResponseDetails;
        }

        /// <summary>
        /// Store activityID In Memory.
        /// </summary>
        /// <param name="getItemId">This is ItemId.</param>
        private void StoreTheActivityIDInMemory(string getItemId)
        {
            //Store activityID In Memory
            Logger.LogMethodEntry("PostRestServicePage",
                "StoreTheActivityIDInMemory", base.IsTakeScreenShotDuringEntryExit);
            //Store the Activity into memory
            Activity activity = new Activity
            {
                ActivityId = getItemId,
                ActivityType = Activity.ActivityTypeEnum.WritingSpace,
                IsCreated = true,
            };
            activity.StoreActivityInMemory();
            Logger.LogMethodExit("PostRestServicePage",
                "StoreTheActivityIDInMemory", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get The GradePost Response From Mock Appication.
        /// </summary>
        /// <returns>Response Text.</returns>
        public string GetTheGradePostResponseFromMockApplication()
        {
            //Get The GradePost Response From Mock Appication
            Logger.LogMethodEntry("PostRestServicePage",
                "GetTheGradePostResponseFromMockApplication",
                base.IsTakeScreenShotDuringEntryExit);
            //Get The Response From Mock Appication
            Logger.LogMethodEntry("PostRestServicePage",
                "GetTheResponseFromMockAppication",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialized Response Text
            string getResponseDetails = string.Empty;
            try
            {
                //Wait for Element
                base.WaitForElement(By.Id(PostRestServiceResource.
                    PostRestServicePage_ResponseBody_TextBox_Id_Locator));
                //Get Response Text
                getResponseDetails = base.GetElementTextById(PostRestServiceResource.
                    PostRestServicePage_ResponseBody_TextBox_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("PostRestServicePage",
                "GetTheGradePostResponseFromMockApplication",
                base.IsTakeScreenShotDuringEntryExit);
            return getResponseDetails;
        }

        /// <summary>
        /// Browse The LMS Grade Posting Mock Application URL.
        /// </summary>
        /// <param name="LMSGradeSynchSpaceMockUrl">This Url is fetched from Appconfig.</param>
        public void BrowseTheLMSGradeSynchMockApplicationURL(string LMSGradeSynchSpaceMockUrl)
        {
            //Browse The LMS Grade Posting Mock ApplicationURL
            Logger.LogMethodEntry("PostRestServicePage", "BrowseTheLMSGradeSynchMockApplicationURL", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Browse the url
                base.NavigateToBrowseUrl(LMSGradeSynchSpaceMockUrl);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("PostRestServicePage", "BrowseTheLMSGradeSynchMockApplicationURL", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get The Response From LMS Mock Appication
        /// </summary>
        /// <param name="activityTypeEnum"></param>
        /// <returns></returns>
        public bool GetTheResponseFromLMSMockAppication(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Get The Response From Mock Appication
            Logger.LogMethodEntry("PostRestServicePage", "GetTheResponseFromLMSMockAppication", base.IsTakeScreenShotDuringEntryExit);
            //Initialized Response Text
            string getResponseDetails = string.Empty;
            String[] ResponseValues;
            String getItemEvent = String.Empty;
            bool ItemSavePresent = false;
            try
            {
                Activity activity = Activity.Get(activityTypeEnum);
                //Get Response Text
                getResponseDetails = base.GetElementTextById("jsonContainer");
                getResponseDetails = getResponseDetails.Substring(17);
                //Get the ItemId
                string[] getItemId = Regex.Split(getResponseDetails, "},{");
                foreach (String ResponseItemValues in getItemId)
                {
                    if (ResponseItemValues.Contains(activity.ActivityId))// 6000000000384474
                    {
                        ResponseValues = ResponseItemValues.Split(',');
                        string[] PayLoadValues = ResponseValues[2].Split('&');
                        string[] ItemLoadValues = PayLoadValues[1].Split('=');
                        getItemEvent = ItemLoadValues[1];
                        if (getItemEvent.Contains("GradebookRepo.Item.Save.ExternalIntegration") || getItemEvent.Contains("GradebookRepo.Item.Delete.ExternalIntegration"))
                        {
                            ItemSavePresent = true;
                            break;
                        }                      

                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("PostRestServicePage", "GetTheResponseFromLMSMockAppication", base.IsTakeScreenShotDuringEntryExit);
            return ItemSavePresent;
        }


        public void LoadWindow()
        {
            string windowName = base.GetPageTitle;
            base.WaitUntilWindowLoads(windowName);
            base.SelectWindow(windowName);
        }
    }
}
