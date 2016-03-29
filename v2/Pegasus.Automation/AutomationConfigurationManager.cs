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
            switch (Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_TEST_ENVIRONMENT_KEY.ToUpper())
                ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.TestEnvironment_Key].ToUpper())
            {
                case "PPE":
                    applicationCsUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.CourseSpaceURLRootPPE_Key];
                    break;
                case "CGIE":
                    applicationCsUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.CourseSpaceURLRootCGIE_Key];
                    break;
                case "PROD":
                    applicationCsUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.CourseSpaceURLRootPROD_Key];
                    break;
                case "VCD":
                    applicationCsUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.CourseSpaceURLRootVCD_Key];
                    break;
                case "VCDAKAMAI":
                    applicationCsUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.CourseSpaceURLRootVCDAkamai_Key];
                    break;
                case "CGIEAKAMAI":
                    applicationCsUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.CourseSpaceURLRootCGIEAkamai_Key];
                    break;
                case "PPEAKAMAI":
                    applicationCsUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.CourseSpaceURLRootPPEAkamai_Key];
                    break;
                case "PRODAKAMAI":
                    applicationCsUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.CourseSpaceURLRootPRODAkamai_Key];
                    break;
                case "VCDNP":
                    applicationCsUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.CourseSpaceURLVCDNP_Key];
                    break;
                case "CGIENP":
                    applicationCsUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.CourseSpaceURLRootCGIENP_Key];
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
            switch (Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_TEST_ENVIRONMENT_KEY.ToUpper())
                ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.TestEnvironment_Key].ToUpper())
            {
                case "VCD":
                    applicationMmnDurl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.MMNDCertAdminURLRoot_Key];
                    break;
                case "PPE":
                    applicationMmnDurl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.MMNDPPEAdminURLRoot_Key];
                    break;
                case "PROD":
                    applicationMmnDurl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.MMNDPRODAdminURLRoot_Key];
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
            switch (Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_TEST_ENVIRONMENT_KEY.ToUpper())
                ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.TestEnvironment_Key].ToUpper())
            {
                case "ST":
                    applicationWsurl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.WorkSpaceURLRootST_Key];
                    break;
                case "CGIE":
                    applicationWsurl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.WorkSpaceURLRootCGIE_Key];
                    break;
                case "PPE":
                    applicationWsurl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.WorkSpaceURLRootPPE_Key];
                    break;
                case "PROD":
                    applicationWsurl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.WorkSpaceURLRootPROD_Key];
                    break;
                case "VCD":
                    applicationWsurl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.WorkSpaceURLRootVCD_Key];
                    break;
                case "VCDAKAMAI":
                    applicationWsurl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.CourseSpaceURLRootVCDAkamai_Key];
                    break;
                case "CGIEAKAMAI":
                    applicationWsurl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.CourseSpaceURLRootCGIEAkamai_Key];
                    break;
                case "PPEAKAMAI":
                    applicationWsurl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.CourseSpaceURLRootPPEAkamai_Key];
                    break;
                case "PRODAKAMAI":
                    applicationWsurl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.CourseSpaceURLRootPRODAkamai_Key];
                    break;
                case "VCDNP":
                    applicationWsurl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.WorkSpaceURLRootVCDNP_Key];
                    break;
                case "CGIENP":
                    applicationWsurl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.WorkSpaceURLRootCGIENP_Key];
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
                    ?? Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                    + "\\..\\..\\..\\Pegasus.Pages".Replace("file:\\", "");
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
                       ?? Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName
                           (System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase))))
                       + "\\Pegasus.Pages\\ApplicationDownloadedFiles";
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
            switch (Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_TEST_ENVIRONMENT_KEY.ToUpper())
                ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.TestEnvironment_Key].ToUpper())
            {
                case "ST":
                    url = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSAdminURLRootST_Key];
                    break;
                case "CGIE":
                case "CGIENP":
                    url = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSAdminURLRootCGIE_Key];
                    break;
                case "PPE":
                    url = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSAdminURLRootPPE_Key];
                    break;
                case "PROD":
                    url = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSAdminURLRootPROD_Key];
                    break;
                case "VCD":
                case "VCDNP":
                    url = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSAdminURLRootVCD_Key];
                    break;
                default: throw new ArgumentException("The suggested application environment was not found");
            }
            return url;
        }

        /// <summary>        /// Property SSRSadmin url root.
        /// </summary> 
        public static string SSRSAdminUrl
        {
            get { return GetSSRSAdminUrlRoot(); }
        }

        /// <summary>
        /// Find sms admin url root based on application environment.
        /// </summary> 
        /// <returns>SSRS admin url.</returns>
        private static string GetSSRSAdminUrlRoot()
        {
            string url;
            switch (Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_TEST_ENVIRONMENT_KEY.ToUpper())
                ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.TestEnvironment_Key].ToUpper())
            {
                case "CGIE":
                case "CGIENP":
                    url = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SSRSURLRootCGIE_Key];
                    break;
                case "PPE":
                    url = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SSRSURLRootCGIE_Key];
                    break;
                case "PROD":
                    url = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SSRSURLRootPROD_Key];
                    break;
                case "VCD":
                case "VCDNP":
                    url = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SSRSURLRootCGIE_Key];
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
            switch (Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_TEST_ENVIRONMENT_KEY.ToUpper())
                ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.TestEnvironment_Key].ToUpper())
            {
                case "CGIE":
                    url = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSAdminStudentURLRootCGIE_Key];
                    break;
                case "VCD":
                    url = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSAdminStudentURLRootVCD_Key];
                    break;
                case "PPE":
                    url = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSAdminStudentURLRootPPE_Key];
                    break;
                case "PROD":
                    url = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSAdminStudentURLRootPROD_Key];
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
            switch (Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_TEST_ENVIRONMENT_KEY.ToUpper())
                ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.TestEnvironment_Key].ToUpper())
            {
                case "VCD":
                    url = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.MMNDVCDPortalURLRoot_Key];
                    break;
                case "PPE":
                    url = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.MMNDPPEPortalURLRoot_Key];
                    break;
                case "PROD":
                    url = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.MMNDPRODPortalURLRoot_Key];
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
            switch (Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_TEST_ENVIRONMENT_KEY.ToUpper())
                ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.TestEnvironment_Key].ToUpper())
            {
                case "ST":
                    smsStuAccessCode = ConfigurationManager.AppSettings
                        [AutomationConfigurationManagerResource.SMSStudentAccessCodeST_Key];
                    break;
                case "CGIE":
                case "CGIENP":
                    smsStuAccessCode = ConfigurationManager.AppSettings
                        [AutomationConfigurationManagerResource.SMSStudentAccessCodeCGIE_Key];
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
                case "VCDNP":
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
            switch (Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_TEST_ENVIRONMENT_KEY.ToUpper())
                ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.TestEnvironment_Key].ToUpper())
            {
                case "ST":
                    smsInsAccessCode = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSInstructorAccessCodeST_Key];
                    break;
                case "CGIE":
                case "CGIENP":
                    smsInsAccessCode = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSInstructorAccessCodeCGIE_Key];
                    break;
                case "PPE":
                    smsInsAccessCode = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSInstructorAccessCodePPE_Key];
                    break;
                case "PROD":
                    smsInsAccessCode = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSInstructorAccessCodePROD_Key];
                    break;
                case "VCD":
                case "VCDNP":
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
            switch (Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_TEST_ENVIRONMENT_KEY.ToUpper())
                ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.TestEnvironment_Key].ToUpper())
            {
                case "ST":
                    smsModuleId = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSModuleIDST_Key];
                    break;
                case "CGIE":
                case "CGIENP":
                    smsModuleId = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSModuleIDCGIE_key];
                    break;
                case "PPE":
                    smsModuleId = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSModuleIDPPE_key];
                    break;
                case "PROD":
                    smsModuleId = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.SMSModuleIDPROD_key];
                    break;
                case "VCD":
                case "VCDNP":
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
        /// Property for Blackboard url.
        /// </summary>
        public static string BBClassicUrlRoot
        {
            get { return GetBBClassicUrlRoot(); }
        }

        /// <summary>
        /// Property for D2L Kiosk url.
        /// </summary>
        public static string D2LKioskUrlRoot
        {
            get { return GetD2LKioskUrlRoot(); }
        }

        /// <summary>
        /// Property for Canvas Kiosk url.
        /// </summary>
      public static string CanvasKioskUrlRoot
        {
            get { return GetCanvasKioskUrlRoot(); }
        } 

        /// <summary>
        /// Property for Moodle Kiosk url.
        /// </summary>
        public static string MoodleKioskUrlRoot
        {
            get { return GetMoodleKioskUrlRoot(); }
        }

        /// <summary>
        /// Find the blackboard url based on application environment.
        /// </summary> 
        /// <returns>Blackboard Classic url.</returns>
        private static string GetBBClassicUrlRoot()
        {
            string applicationBBUrl;
            switch (Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_TEST_ENVIRONMENT_KEY.ToUpper())
                ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.TestEnvironment_Key].ToUpper())
            {
                case "VCD":
                case "VCDNP":
                    applicationBBUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.BBInstructorURLRootVCD_Key];
                    break;
                case "CGIE":
                case "CGIENP":
                    applicationBBUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.BBInstructorURLRootCGIE_Key];
                    break;
                //case "PROD":
                  //  applicationBBUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.BBInstructorURLRootCGIE_Key];
                   // break;
                default: throw new ArgumentException("The suggested application environment was not found");
            }
            return applicationBBUrl;
        }

        /// <summary>
        /// Find the D2L Kiosk url based on application environment.
        /// </summary> 
        /// <returns>D2l url.</returns>
      private static string GetD2LKioskUrlRoot()
        {
            string applicationBBUrl;
             switch (Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_TEST_ENVIRONMENT_KEY.ToUpper())
                 ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.TestEnvironment_Key].ToUpper())
             {
                 case "VCD":
                 case "VCDNP":
                     applicationBBUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.D2LKioskUrlRootVCD_Key];
                     break;
                 case "CGIE":
                 case "CGIENP":
                     applicationBBUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.D2LKioskUrlRootCGIE_Key];
                     break;
                 case "PROD":
                     applicationBBUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.D2LKioskUrlRootPROD_Key];
                     break;
                 default: throw new ArgumentException("The suggested application environment was not found");
             }
             return applicationBBUrl;
        } 
        
        /// <summary>
        /// Find the Canvas Kiosk url based on application environment.
        /// </summary> 
        /// <returns>Rumba url.</returns>
       private static string GetCanvasKioskUrlRoot()
        {
            string applicationBBUrl;
            switch (Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_TEST_ENVIRONMENT_KEY.ToUpper())
                ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.TestEnvironment_Key].ToUpper())
            {
                case "VCD":
                case "VCDNP":
                    applicationBBUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.CanvasKioskUrlRootVCD_Key];
                    break;
                case "CGIE":
                case "CGIENP":
                    applicationBBUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.CanvasKioskUrlRootCGIE_Key];
                    break;
                case "PROD":
                    applicationBBUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.CanvasKioskUrlRootPROD_Key];
                    break;
                default: throw new ArgumentException("The suggested application environment was not found");
            }
            return applicationBBUrl;
        } 

        /// <summary>
        /// Find the Moodle Kiosk url based on application environment.
        /// </summary> 
        /// <returns>Moodle Kiosk Url.</returns>
        private static string GetMoodleKioskUrlRoot()
        {
            string applicationMoodlerl;
            switch (Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_TEST_ENVIRONMENT_KEY.ToUpper())
                ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.TestEnvironment_Key].ToUpper())
            {
                case "VCD":
                case "VCDNP":
                    applicationMoodlerl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.MoodleKioskUrlRootVCD_Key];
                    break;
                case "CGIE":
                case "CGIENP":
                    applicationMoodlerl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.MoodleKioskUrlRootCGIE_Key];
                    break;
                case "PROD":
                    applicationMoodlerl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.MoodleKioskUrlRootPROD_Key];
                    break;
                default: throw new ArgumentException("The suggested application environment was not found");
            }
            return applicationMoodlerl;
        }


        /// <summary>
        /// Find the rumba url based on application environment.
        /// </summary> 
        /// <returns>Rumba url.</returns>
        private static string GetRumbaUrlRoot()
        {
            string applicationRumbaUrl;
            switch (ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.TestEnvironment_Key].ToUpper())
            {
                case "VCD":
                case "VCDNP":
                    applicationRumbaUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.RumbaURLRootVCD_Key];
                    break;
                case "CGIE":
                case "CGIENP":
                    applicationRumbaUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.RumbaURLRootCGIE_Key];
                    break;
                case "PROD":
                    applicationRumbaUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.RumbaURLRootPROD_Key];
                    break;
                default: throw new ArgumentException("The suggested application environment was not found");
            }
            return applicationRumbaUrl;
        }

        /// <summary>        /// Property for contineo url.
        /// </summary>
        public static string ContineoUrlRoot
        {
            get { return GetContineoUrlRoot(); }
        }

        /// <summary>
        /// Find the Contineo url based on application environment.
        /// </summary> 
        /// <returns>Contineo url.</returns>
        private static string GetContineoUrlRoot()
        {
            string applicationContineoUrl;
            switch (ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.TestEnvironment_Key].ToUpper())
            {
                case "VCD":
                case "VCDNP":
                    applicationContineoUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.ContineoURLRootVCD_Key];
                    break;
                case "CGIE":
                case "CGIENP":
                    applicationContineoUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.ContineoURLRootCGIE_Key];
                    break;
                case "PROD":
                    applicationContineoUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.ContineoURLRootPROD_Key];
                    break;
                default: throw new ArgumentException("The suggested application environment was not found");
            }
            return applicationContineoUrl;
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
            return Environment.GetEnvironmentVariable(
                AutomationConfigurationManagerResource.PEG_AUTOMATION_TEST_ENVIRONMENT_KEY.ToUpper())
                   ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.TestEnvironment_Key].ToUpper();
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
            return Environment.GetEnvironmentVariable(
                AutomationConfigurationManagerResource.PEG_AUTOMATION_BROWSER_KEY)
                   ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.BrowserName_Key];
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
            switch (Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_TEST_ENVIRONMENT_KEY.ToUpper())
                ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.TestEnvironment_Key].ToUpper())
            {
                case "ST":
                    pctInsUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.PCTInstructorResourceToolsST_Key];
                    break;
                case "CGIE":
                    pctInsUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.PCTInstructorResourceToolsCGIE_Key];
                    break;
                case "PPE":
                    pctInsUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.PCTInstructorResourceToolsCGIE_Key];
                    break;
                case "PROD":
                    pctInsUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.PCTInstructorResourceToolsCGIE_Key];
                    break;
                default: throw new ArgumentException("The suggested application environment was not found");
            }
            return pctInsUrl;
        }

        // for D2L 10.5
        public static string D2LKioskUrlRoot1
        {
            get { return GetD2LKioskUrlRoot1(); }
        }

        private static string GetD2LKioskUrlRoot1()
        {
            string applicationD2LUrl;
            switch (Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_TEST_ENVIRONMENT_KEY.ToUpper())
                ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.TestEnvironment_Key].ToUpper())
            {
               // case "VCD":
              //  case "VCDNP":
              //      applicationBBUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.D2LKioskUrlRootVCD_Key];
               //     break;
                //case "CGIE":
                case "PPE":
                    applicationD2LUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.D2LKioskUrlRoot1PPE_Key];
                    break;
               // case "PROD":
                //    applicationBBUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.D2LKioskUrlRootPROD_Key];
              //      break;
                default: throw new ArgumentException("The suggested application environment was not found");
            }
            return applicationD2LUrl;
        }
    


    //for eCollege

 
        public static string eCollegeURLRoot
        {
            get { return GeteCollegeURLRoot(); }
        }

        private static string GeteCollegeURLRoot()
        {
            string applicationeCollegeUrl;
            switch (Environment.GetEnvironmentVariable(AutomationConfigurationManagerResource.PEG_AUTOMATION_TEST_ENVIRONMENT_KEY.ToUpper())
                ?? ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.TestEnvironment_Key].ToUpper())
            {
               case "VCD":
              //  case "VCDNP":
              //      applicationBBUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.D2LKioskUrlRootVCD_Key];
               //     break;
               case "CGIE":
                   applicationeCollegeUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.eCollegeURLRootTE_key];
                //case "PPE":
                    //applicationeCollegeUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.D2LKioskUrlRoot1PPE_Key];
                    break;
               // case "PROD":
                //    applicationBBUrl = ConfigurationManager.AppSettings[AutomationConfigurationManagerResource.D2LKioskUrlRootPROD_Key];
              //      break;
                default: throw new ArgumentException("The suggested application environment was not found");
            }
            return applicationeCollegeUrl;
        }
    }
}