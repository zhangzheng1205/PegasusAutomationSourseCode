using System;
using System.Collections.Generic;
using System.Linq;

namespace Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects
{
    /// <summary>
    /// This is the class which represents an organization.
    /// </summary>
    public class Organization : BaseEntityObject
    {
        /// <summary>
        /// This is the organization type enum.
        /// </summary>
        public enum OrganizationTypeEnum
        {
            NovaNET = 1,
            DigitalPath = 2,
            DigitalPathDemo = 3
        }

        /// <summary>
        /// This is the organization type.
        /// </summary>
        public OrganizationTypeEnum OrganizationType { get; set; }

        /// <summary>
        /// This is the organization Id.
        /// </summary>
        public String RumbaOrgId { get; set; }

        /// <summary>
        /// This si the organization level enum.
        /// </summary>
        public enum OrganizationLevelEnum
        {
            State = 1,
            Region = 2,
            District = 3,
            School = 4,
            PowerSchool = 5,
            Schools = 6
        }

        /// <summary>
        /// This is the level of the organization.
        /// </summary>
        public OrganizationLevelEnum OrganizationLevel { get; set; }

        /// <summary>
        /// This method creats an organization.
        /// </summary>
        public void StoreOrganizationInMemory()
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Insert(this);
        }

        /// <summary>
        /// This method returns an organization of given level which was last created.
        /// </summary>
        /// <param name="organizationLevel">This is organization level enum.</param>
        /// <param name="organizationTypeEnum">This is organization type enum.</param>
        public static Organization Get(OrganizationLevelEnum organizationLevel, 
            OrganizationTypeEnum organizationTypeEnum)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<Organization>(
                x => x.OrganizationLevel == organizationLevel && x.OrganizationType == organizationTypeEnum && x.IsCreated).OrderByDescending(
                x => x.CreationDate).First();
        }

        /// <summary>
        /// Returns Organization based on custom query.
        /// </summary>
        /// <param name="predicate">The where condition.</param>
        /// <returns>List of organization.</returns>
        public static List<Organization> Get(Func<Organization, bool> predicate)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany(predicate);
        }

        /// <summary>
        /// This method returns all the created organizations of the given level and type.
        /// </summary>
        /// <param name="organizationLevel">This is the type of the organization level.</param>
        /// /// <param name="organizationType">This is the type of the organization type.</param>
        /// <returns>Organization List.</returns>
        public static List<Organization> GetAll(OrganizationLevelEnum organizationLevel,
            OrganizationTypeEnum organizationType)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<Organization>(
                x => x.OrganizationType == organizationType && x.OrganizationLevel == organizationLevel && x.IsCreated).OrderByDescending(
                x => x.CreationDate).ToList();
        }
    }
}
