using Pegasus.Automation;
using System;
using System.Configuration;
using System.IO;

namespace Pearson.Pegasus.TestAutomation.Frameworks
{
    /// <summary>
    /// This class handles app settings configuration.
    /// </summary>
    public class AutomationConfigurationManager
    {
        /// <summary>
        /// Property course space url root.
        /// </summary>
        public static string CourseSpaceUrlRoot
        {
            get { return GetCourseSpaceUrlRoot(); }
        }

        /// <summary>
        /// Find course space url root based on application environment.
        /// </summary> 
        /// <returns>Application cs url.</returns>
        private static string GetCourseSpaceUrlRoot()
        {
            string applicationCsUrl;
            switch (ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.TestEnvironment_Key])
            {
                case "ST":
                    applicationCsUrl = Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_ST_CSURL_Key)
                        ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.CourseSpaceURLRootST_Key];
                    break;
                case "VM":
                    applicationCsUrl = Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_VM_CSURL_Key)
                        ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.CourseSpaceURLRootVM_Key];
                    break;
                case "PPE":
                    applicationCsUrl = Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_PPE_CSURL_Key)
                        ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.CourseSpaceURLRootPPE_Key];
                    break;
                case "PROD":
                    applicationCsUrl = Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_PROD_CSURL_Key)
                        ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.CourseSpaceURLRootPROD_Key];
                    break;
                case "VCD":
                    applicationCsUrl = Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_VCD_CSURL_Key)
                        ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.CourseSpaceURLRootVCD_Key];
                    break;
                default: throw new ArgumentException("The suggested application environment was not found");
            }
            return applicationCsUrl;
        }

        /// <summary>
        /// Property work space url root.
        /// </summary>
        public static string WorkSpaceUrlRoot
        {
            get { return GetWorkSpaceUrlRoot(); }
        }

        /// <summary>
        /// Property MMND Admin url root.
        /// </summary>
        public static string MmndUrlRoot
        {
            get { return GetMmndUrlRoot(); }
        }

        /// <summary>
        /// Find Mmnd url root based on application environment.
        /// </summary>
        /// <returns>Mmnd root url.</returns>
        private static string GetMmndUrlRoot()
        {
            string applicationMmnDurl;
            switch (ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.TestEnvironment_Key])
            {
                case "VM":
                    applicationMmnDurl = Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_ST_WSURL_Key)
                        ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.MMNDCertAdminURLRoot_Key];
                    break;
                case "PPE":
                    applicationMmnDurl = Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_ST_WSURL_Key)
                        ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.MMNDPPEAdminURLRoot_Key];
                    break;
                case "PROD":
                    applicationMmnDurl = Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_ST_WSURL_Key)
                        ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.MMNDPRODAdminURLRoot_Key];
                    break;
                default: throw new ArgumentException("The suggested application environment was not found");
            }
            return applicationMmnDurl;

        }

        /// <summary>
        /// Find work space url root based on application environment.
        /// </summary> 
        /// <returns>Application ws url.</returns>
        private static string GetWorkSpaceUrlRoot()
        {
            string applicationWsurl;

            switch (ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.TestEnvironment_Key])
            {     
                        
                case "ST":

                    applicationWsurl = Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_ST_WSURL_Key)
                        ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.WorkSpaceURLRootST_Key];
                    break;
                case "VM":
                    applicationWsurl = Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_VM_WSURL_Key)
                        ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.WorkSpaceURLRootVM_Key];
                    break;
                case "PPE":                    
                    applicationWsurl = Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_PPE_WSURL_Key)
                        ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.WorkSpaceURLRootPPE_Key];
                    break;
                case "PROD":
                    applicationWsurl = Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_PROD_WSURL_Key)
                        ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.WorkSpaceURLRootPROD_Key];
                    break;
                case "VCD":
                    applicationWsurl = Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_VCD_WSURL_Key)
                        ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.WorkSpaceURLRootVCD_Key];
                    break;
                default: throw new ArgumentException("The suggested application environment was not found");
            }
            return applicationWsurl;
        }

        /// <summary>
        /// Property application Test Data path.
        /// </summary> 
        public static string TestDataPath
        {
            get
            {
                return Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_TESTDATA_PATH_Key)
                    ?? Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\..\\..\\..\\Pegasus.Automation";
            }
        }

        /// <summary>
        /// Property application Test Data path in Pegasus Pages.
        /// </summary> 
        public static string PegasusPagesTestDataPath
        {
            get
            {
                return Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_TESTDATA_PATH_Key)
                    ?? Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\..\\..\\..\\Pegasus.Pages";
            }
        }

        /// <summary>
        /// Property application download file path.
        /// </summary>
        public static string DownloadFilePath
        {
            get
            {
                return Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_DOWNLOAD_PATH_Key)
                    ?? Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\..\\..\\..\\Pegasus.Pages";
            }
        }

        /// <summary>
        /// Property SMS admin url root.
        /// </summary> 
        public static string SmsAdminUrlRoot
        {
            get { return GetSmsAdminUrlRoot(); }
        }

        /// <summary>
        /// Find sms admin url root based on application environment.
        /// </summary> 
        /// <returns>SMS admin url.</returns>
        private static string GetSmsAdminUrlRoot()
        {
            string url;
            switch (ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.TestEnvironment_Key])
            {
                case "ST":
                    url = Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_SMSAdminURLRoot_Key)
                        ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSAdminURLRootST_Key];
                    break;
                case "VM":
                    url = Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_SMSAdminURLRoot_Key)
                        ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSAdminURLRootVM_Key];
                    break;
                case "PPE":
                    url = Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_SMSAdminURLRoot_Key)
                        ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSAdminURLRootPPE_Key];
                    break;
                case "PROD":
                    url = Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_SMSAdminURLRoot_Key)
                        ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSAdminURLRootPROD_Key];
                    break;
                case "VCD":
                    url = Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_SMSAdminURLRoot_Key)
                        ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSAdminURLRootVCD_Key];
                    break;
                default: throw new ArgumentException("The suggested application environment was not found");
            }
            return url;
        }

        /// <summary>
        /// Get SMS registration URL for MMND student.
        /// </summary>
        public static string SmsMmndStudentRegistrationUrl
        {
            get { return GetSmsMmndStudentRegistrationRoot(); }
        }

        /// <summary>
        /// Find Sms Mmnd Student Registration Root Url.
        /// </summary>
        /// <returns>Mmnd Sms Student Url.</returns>
        private static string GetSmsMmndStudentRegistrationRoot()
        {
            string url;
            switch (ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.TestEnvironment_Key])
            {
                case "VM":
                    url = Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_SMSAdminURLRoot_Key)
                        ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSAdminStudentURLRootVM_Key];
                    break;
                case "PPE":
                    url = Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_SMSAdminURLRoot_Key)
                        ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSAdminStudentURLRootPPE_Key];
                    break;
                case "PROD":
                    url = Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_SMSAdminURLRoot_Key)
                        ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSAdminStudentURLRootPROD_Key];
                    break;
                default: throw new ArgumentException("The suggested application environment was not found");
            }
            return url;
        }

        /// <summary>
        /// Get MMND users login URL.
        /// </summary>
        public static string MmndUsersLoginUrl
        {
            get { return GetMmndUsersLoginUrlRoot(); }
        }

        /// <summary>
        /// Find Mmnd users login url root based on application environment.
        /// </summary>
        /// <returns>Mmnd users login url.</returns>
        private static string GetMmndUsersLoginUrlRoot()
        {
            string url = string.Empty;
            switch (ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.TestEnvironment_Key])
            {
                case "VM":
                    url = Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_SMSAdminURLRoot_Key)
                        ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.MMNDVMPortalURLRoot_Key];
                    break;
                case "PPE":
                    url = Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_SMSAdminURLRoot_Key)
                        ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.MMNDPPEPortalURLRoot_Key];
                    break;
                case "PROD":
                    url = Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_SMSAdminURLRoot_Key)
                        ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.MMNDPRODPortalURLRoot_Key];
                    break;
                default: throw new ArgumentException("The suggested application environment was not found");
            }
            return url;
        }

        /// <summary>
        /// Property SMS student access code.
        /// </summary> 
        public static string SmsStudentAccessCode
        {
            get { return GetSmsstuAccessCode(); }
        }

        /// <summary>
        /// Find sms student access code based on application environment.
        /// </summary> 
        /// <returns>SMS student access code.</returns>
        private static string GetSmsstuAccessCode()
        {
            string smsStuAccessCode;
            switch (ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.TestEnvironment_Key])
            {
                case "ST":
                    smsStuAccessCode = ConfigurationManager.AppSettings
                        [AutomationConfigurationManagerResource.SMSStudentAccessCodeST_Key];
                    break;
                case "VM":
                    smsStuAccessCode = ConfigurationManager.AppSettings
                        [AutomationConfigurationManagerResource.SMSStudentAccessCodeVM_Key];
                    break;
                case "PPE":
                    smsStuAccessCode = ConfigurationManager.AppSettings
                        [AutomationConfigurationManagerResource.SMSStudentAccessCodePPE_Key];
                    break;
                case "PROD":
                    smsStuAccessCode = ConfigurationManager.AppSettings
                        [AutomationConfigurationManagerResource.SMSStudentAccessCodePROD_Key];
                    break;
                case "VCD":
                    smsStuAccessCode = ConfigurationManager.AppSettings
                        [AutomationConfigurationManagerResource.SMSStudentAccessCodeVCD_Key];
                    break;
                default: throw new ArgumentException("The suggested application environment was not found");
            }
            return smsStuAccessCode;
        }

        /// <summary>
        /// Property SMS instructor access code.
        /// </summary> 
        public static string SmsInstructorAccessCode
        {
            get { return GetSmsinsAccessCode(); }
        }

        /// <summary>
        /// Find sms instructor access code based on application environment.
        /// </summary> 
        /// <returns>SMS instructor access code.</returns>
        private static string GetSmsinsAccessCode()
        {
            string smsInsAccessCode;
            switch (ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.TestEnvironment_Key])
            {
                case "ST":
                    smsInsAccessCode = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSInstructorAccessCodeST_Key];
                    break;
                case "VM":
                    smsInsAccessCode = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSInstructorAccessCodeVM_Key];
                    break;
                case "PPE":
                    smsInsAccessCode = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSInstructorAccessCodePPE_Key];
                    break;
                case "PROD":
                    smsInsAccessCode = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSInstructorAccessCodePROD_Key];
                    break;
                case "VCD":
                    smsInsAccessCode = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSInstructorAccessCodeVCD_Key];
                    break;
                default: throw new ArgumentException("The suggested application environment was not found");
            }
            return smsInsAccessCode;
        }

        /// <summary>
        /// Property SMS module Id.
        /// </summary>
        public static string SmsMuduleId
        {
            get { return GetSmsModuleId(); }
        }

        /// <summary>
        /// Find sms module id based on application environment.
        /// </summary> 
        /// <returns>SMS module id.</returns>
        private static string GetSmsModuleId()
        {
            string smsModuleId;
            switch (ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.TestEnvironment_Key])
            {
                case "ST":
                    smsModuleId = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSModuleIDST_Key];
                    break;
                case "VM":
                    smsModuleId = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSModuleIDVM_key];
                    break;
                case "PPE":
                    smsModuleId = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSModuleIDPPE_key];
                    break;
                case "PROD":
                    smsModuleId = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSModuleIDPROD_key];
                    break;
                case "VCD":
                    smsModuleId = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSModuleIDVCD_Key];
                    break;
                default: throw new ArgumentException("The suggested application environment was not found");
            }
            return smsModuleId;
        }

        /// <summary>
        /// Property for rumba url.
        /// </summary>
        public static string RumbaUrlRoot
        {
            get { return GetRumbaUrlRoot(); }
        }

        /// <summary>
        /// Find the rumba url based on application environment.
        /// </summary> 
        /// <returns>Rumba url.</returns>
        private static string GetRumbaUrlRoot()
        {
            string applicationRumbaUrl;
            switch (ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.TestEnvironment_Key])
            {
                case "ST":
                    applicationRumbaUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.RumbaURLRootST_Key];
                    break;
                case "VM":
                    applicationRumbaUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.RumbaURLRootVM_Key];
                    break;
                case "PROD":
                    applicationRumbaUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.RumbaURLRootPROD_Key];
                    break;
                default: throw new ArgumentException("The suggested application environment was not found");
            }
            return applicationRumbaUrl;
        }

        /// <summary>
        /// Property application environment.
        /// </summary>
        public static string ApplicationTestEnvironment
        {
            get { return GetApplicationTestEnvironment(); }
        }

        /// <summary>
        /// Find application environment.
        /// </summary> 
        /// <returns>Application environment.</returns>
        public static string GetApplicationTestEnvironment()
        {
            return Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.TestEnvironment_Key)
                        ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.TestEnvironment_Key];
        }

        /// <summary>
        /// Property browser instance.
        /// </summary>
        public static string BrowserExecutionInstance
        {
            get { return GetExecutionBrowser(); }
        }

        /// <summary>
        /// Find execution browser.
        /// </summary> 
        /// <returns>Browser instance.</returns>
        private static string GetExecutionBrowser()
        {
            return ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.BrowserName_Key];
        }

        /// <summary>
        /// Property to get PCT Instructor Resource Tools URL.
        /// </summary>
        public static string PctInstructorResourceToolsUrl
        {
            get { return GetPctInstructorResourceToolsUrl(); }
        }
        /// <summary>
        /// Get PCT Instructor Resource Tools URL.
        /// </summary>
        /// <returns>PCT Instructor Resource Tools URL.</returns>
        private static string GetPctInstructorResourceToolsUrl()
        {
            string pctInsUrl;
            switch (ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.TestEnvironment_Key])
            {
                case "ST":
                    pctInsUrl = Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_ST_CSURL_Key)
                    ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.PCTInstructorResourceToolsST_Key];
                    break;
                case "VM":
                    pctInsUrl = Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_ST_CSURL_Key)
                    ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.PCTInstructorResourceToolsVM_Key];
                    break;
                case "PPE":
                    pctInsUrl = Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_ST_CSURL_Key)
                    ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.PCTInstructorResourceToolsVM_Key];
                    break;
                case "PROD":
                    pctInsUrl = Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_ST_CSURL_Key)
                    ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.PCTInstructorResourceToolsVM_Key];
                    break;
                default: throw new ArgumentException("The suggested application environment was not found");
            }
            return pctInsUrl;
        }

    }
}
