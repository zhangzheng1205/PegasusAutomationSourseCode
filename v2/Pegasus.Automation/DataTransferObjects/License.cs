using System;
using System.Collections.Generic;
using System.Linq;
using Pearson.Pegasus.TestAutomation.Frameworks;

namespace Pegasus.Automation.DataTransferObjects
{
    public class License : BaseEntityObject
    {

        /// <summary>
        /// This is the License type enum
        /// </summary>
        public enum LicenseTypeEnum
        {
            Rumba = 1,
            Pegasus = 2
        }

        /// <summary>
        /// This is the Start Data of the License
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// This is the End Date of the License </summary>
        public string EndDate { get; set; }

        /// <summary>
        /// This is the Total License Number
        /// </summary>
        public int LicenseQuantity { get; set; }

        /// <summary>
        /// This is the License Resourse ID
        /// </summary>
        public int ResourceID { get; set; }

        /// <summary>
        /// This is the License Product ID
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// This is the Order ID
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// This is the type of the License.
        /// </summary>
        public LicenseTypeEnum LicenseType { get; set; }

        /// <summary>
        /// This method selects License based on given condition
        /// </summary>
        /// <param name="predicate">The condition</param>
        /// <returns>A list of license</returns>
        public static List<License> Get(Func<License, bool> predicate)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany(predicate);
        }

        /// <summary>
        /// This method inserts a new user into the system
        /// </summary>]
        public void StoreLicenseInMemory()
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Insert(this);
        }

        /// <summary>
        /// This method selects a single license based on the name
        /// Name is defined in the enum type
        /// </summary>
        /// <param name="licenseName">This is the license name</param>
        /// <returns>A single license</returns>
        public static License Get(LicenseTypeEnum licenseName)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<License>(x => x.LicenseType == licenseName && x.IsCreated).OrderByDescending(
                x => x.CreationDate).First();
        }

        /// <summary>
        /// Returns a license based on type
        /// </summary>
        /// <param name="licenseName">The name of the license</param>
        /// <returns>The license</returns>
        public static License Get(String licenseName)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<License>(x => x.Name == licenseName && x.IsCreated).OrderByDescending(
                x => x.CreationDate).First(); ;
        }

        /// <summary>
        /// This method is used to update the rumba resource ID
        /// </summary>
        /// <param name="resourceId">This is the rumba resource ID</param>
        public void UpdateResourceId(int resourceId)
        {
            License license = InMemoryDatabaseSingleton.DatabaseInstance.SelectTopOne<License>(x => x.Name == Name);
            license.ResourceID = resourceId;
        }

        /// <summary>
        /// This method returns all created license of the given type.
        /// </summary>
        /// <param name="licenseType">This is the type of the license.</param>
        /// <returns>License List.</returns>
        public static List<License> GetAll(LicenseTypeEnum licenseType)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<License>(
                x => x.LicenseType == licenseType).OrderByDescending(
                x => x.CreationDate).ToList();
        }
    }
}
