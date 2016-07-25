using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Automation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SQLConnector;

namespace Pegasus.Nonfunctional.Tests.ProductAcceptanceTestDefinitions
{
    [Binding]
         
    public class CertCheckerTests : BasePage
    {


        private static Logger CertCheckerTestsLogger = Logger.GetInstance(typeof(CertCheckerTests));
        private CertChecker certCheckerObject = new CertChecker();
        private static string connectionString = ConfigurationManager.
                                                    ConnectionStrings["AutomationDB"].ConnectionString;
        private static string environment = ConfigurationManager.AppSettings["TestEnvironment"];
        private static string query = "select * from dbo.CERTIFICATE Where Environment='{0}'";
        private static string Query = string.Format(query,environment);
        private static string variable = null;
        List<string> datalistDNS = null;
        List<string> datalistExpectedRating = null;



        [Given(@"I start the Scanner")]
        public void GivenIStartTheScanner()
        {
            CertCheckerTestsLogger.LogMethodEntry("CertCheckerTests", "GivenIStartTheScanner", 
                base.IsTakeScreenShotDuringEntryExit);

            try
            {
                Assert.AreEqual(true, certCheckerObject.fireUPSSLServerTest());
            }
           
            catch(Exception e)
            {
                CertCheckerTestsLogger.LogException("CertCheckerTests", "GivenIStartTheScanner()", e, true);
            }


           CertCheckerTestsLogger.LogMethodExit("CertCheckerTests", "GivenIStartTheScanner", 
               base.IsTakeScreenShotDuringEntryExit);
        }




        [Given(@"Feed in the Environment")]
        public void GivenFeedInTheEnvironment()
        {
            CertCheckerTestsLogger.LogMethodEntry("CertCheckerTests", "GivenFeedInTheEnvironment", 
                base.IsTakeScreenShotDuringEntryExit);

            try
            {
                datalistDNS = SQLConnectors.dataStreamer(connectionString, Query, "DNS");
                datalistExpectedRating = SQLConnectors.dataStreamer(connectionString, Query, "CERT Rating");
            }
            
            catch(Exception e)
            {
                CertCheckerTestsLogger.LogException("CertCheckerTests", "GivenFeedInTheEnvironment()", e, true);
            }
            
            CertCheckerTestsLogger.LogMethodExit("CertCheckerTests", "GivenFeedInTheEnvironment", 
                base.IsTakeScreenShotDuringEntryExit);
        }





        [Then(@"I should get all the results of DNS certificate in the environment")]
        public void ResultsOfDNSCertificateInTheEnvironment()
        {

            CertCheckerTestsLogger.LogMethodEntry("CertCheckerTests", "ResultsOfDNSCertificateInTheEnvironment", 
                base.IsTakeScreenShotDuringEntryExit);
            int counter = 0;
            try
            {
                foreach (string dns in datalistDNS)
                {
                    variable = certCheckerObject.scanDns(dns);
                    Assert.AreEqual(datalistExpectedRating[counter].ToString().Trim(), variable);
                    counter++;

                }
            }

            catch (Exception e)
            {
                CertCheckerTestsLogger.LogException("CertCheckerTests", "ResultsOfDNSCertificateInTheEnvironment()", e, true);
            }
            
            CertCheckerTestsLogger.LogMethodExit("CertCheckerTests", "ResultsOfDNSCertificateInTheEnvironment", 
                base.IsTakeScreenShotDuringEntryExit);
        }





    }
}
