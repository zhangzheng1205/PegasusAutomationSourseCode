using System.Configuration;
using System.Diagnostics;
using System.Linq;

namespace Pearson.Pegasus.TestAutomation.Frameworks
{
    /// <summary>
    /// This class handles the processes.
    /// </summary>
    internal class BrowserProcessFactory
    {
        /// <summary>
        ///  Provides all the processes currently running.
        /// </summary>
        /// <returns></returns>
        public static Process[] GetProcessInstance()
        {
            Process[] processes = GetCommonProcess();
            processes.Union(Process.GetProcessesByName("IEDriverServer"));
            processes.Union(Process.GetProcessesByName("QTAgent32"));
            return processes;
        }

        /// <summary>
        /// Gets the the processes.
        /// </summary>
        /// <returns>Processes to be killed.</returns>
        public static Process[] GetCommonProcess()
        {
            string browserName = ConfigurationManager.AppSettings["Browser"];
            Process[] processes = null;
            switch (browserName)
            {
                case PegasusBaseTestFixture.InternetExplorer: processes = Process.GetProcessesByName("iexplore"); break;
                case PegasusBaseTestFixture.FireFox: processes = Process.GetProcessesByName("firefox"); break;
                case PegasusBaseTestFixture.Safari: processes = Process.GetProcessesByName("safari"); break;
                case PegasusBaseTestFixture.Chrome: processes = Process.GetProcessesByName("chrome"); break;
            }

            processes.Union(Process.GetProcessesByName("IEDriverServer.exe"));
            processes.Union(Process.GetProcessesByName("chromedriver"));

            return processes;
        }
    }
}
