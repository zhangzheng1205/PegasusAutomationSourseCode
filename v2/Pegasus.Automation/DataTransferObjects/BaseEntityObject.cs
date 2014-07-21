using System;
namespace Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects
{
    /// <summary>
    /// This is the base entity object
    /// </summary>
    public class BaseEntityObject : BaseDataTransferObject
    {
        /// <summary>
        /// This is the name
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// This tells if the object is created
        /// </summary>
        public bool IsCreated { get; set; }

        /// <summary>
        /// This is the date time of creation
        /// </summary>
        public DateTime CreationDate = DateTime.Now;
    }
}
