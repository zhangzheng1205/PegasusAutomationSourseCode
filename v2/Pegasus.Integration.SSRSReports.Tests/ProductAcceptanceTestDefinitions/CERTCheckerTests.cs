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


        private static Logger Logger = Logger.GetInstance(typeof(CertCheckerTests));
        private CertChecker certCheckerObject = new CertChecker();
        /*private static string connectionString = System.Configuration.ConfigurationManager.
                                                    ConnectionStrings["AutomationDB"].ConnectionString;*/
        private static string connectionString = "Server=ES-LAPTOP-272\\SQL2008;Database=Automation;uid=sa;pwd=mylife612;";
        private static string environment = ConfigurationManager.AppSettings["TestEnvironment"];
        private static string query = "select * from dbo.CERTIFICATE Where Environment='{0}'";
        private static string Query = string.Format(query,environment);
        private static string variable = null;


        [Given(@"I start the Scanner")]
        public void GivenIStartTheScanner()
        {
            Logger.LogMethodEntry("CertCheckerTests", "GivenIStartTheScanner", base.IsTakeScreenShotDuringEntryExit);


           Assert.AreEqual(true,certCheckerObject.fireUPSSLServerTest());


           Logger.LogMethodExit("CertCheckerTests", "GivenIStartTheScanner", base.IsTakeScreenShotDuringEntryExit);
        }

        [Given(@"Feed in the Environment")]
        public void GivenFeedInTheEnvironment()
        {
            Logger.LogMethodEntry("CertCheckerTests", "GivenFeedInTheEnvironment", base.IsTakeScreenShotDuringEntryExit);


            var datalistDNS = SQLConnectors.dataStreamer(connectionString, Query, "DNS");
            var datalistExpectedRating = SQLConnectors.dataStreamer(connectionString, Query, "CERT Rating");
            int counter = 0;
            foreach(string dns in datalistDNS)
            {
                 variable =certCheckerObject.scanDns(dns);
                 Assert.AreEqual(datalistExpectedRating[counter], variable);
                 counter++;
                 
            }
            

            Logger.LogMethodExit("CertCheckerTests", "GivenFeedInTheEnvironment", base.IsTakeScreenShotDuringEntryExit);
        }

    }
}
