using System;
using System.Collections.Generic;
using System.Linq;
using Pearson.Pegasus.TestAutomation.Frameworks;

namespace Pegasus.Automation.DataTransferObjects
{
    public class Section : BaseEntityObject
    {
        /// <summary>
        /// This is the section type enum
        /// </summary>
        public enum SectionTypeEnum
        {
            HEDCore = 1,
            HEDMil = 2
        }

        /// <summary>
        /// This is course name
        /// </summary>
        public string CourseName { get; set; }

        /// <summary>
        /// This is course section id
        /// </summary>
        public String SectionId { get; set; }

        /// <summary>
        /// This is the type of the section
        /// </summary>
        public SectionTypeEnum SectionType { get; set; }

        /// <summary>
        /// This creates a Section
        /// </summary>
        public void StoreSectionInMemory()
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Insert(this);
        }

        /// <summary>
        /// This method returns last creatd section.
        /// </summary>
        public static Section Get(SectionTypeEnum sectionType, string courseName)
        {
            return
                InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<Section>(x => x.SectionType == 
                    sectionType && x.CourseName == courseName && x.IsCreated).OrderByDescending(x => x.CreationDate).First();
        }

        /// <summary>
        /// Returns Section based on custom query
        /// </summary>
        /// <param name="predicate">The where condition</param>
        /// <returns>List of Section</returns>
        public static List<Section> Get(Func<Section, bool> predicate)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany(predicate);
        }

        /// <summary>
        /// This method is used to update the section.
        /// </summary>
        public void UpdateSectionInMemory()
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Update(this);
        }

        /// <summary>
        /// This method returns all created sections of the given type.
        /// </summary>
        /// <param name="sectionType">This is the type of the section.</param>
        /// <returns>Section List.</returns>
        public static List<Section> GetAll(SectionTypeEnum sectionType)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<Section>(
                x => x.SectionType == sectionType).OrderByDescending(
                x => x.CreationDate).ToList();
        }
    }
}
