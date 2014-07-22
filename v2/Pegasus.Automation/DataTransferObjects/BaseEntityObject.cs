using System;
using Pearson.Pegasus.TestAutomation.Frameworks;

namespace Pegasus.Automation.DataTransferObjects
{
    /// <summary>
    /// This is the base entity object.
    /// </summary>
    public class BaseEntityObject : BaseDataTransferObject
    {
        /// <summary>
        /// This is the name.
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// This tells if the object is created.
        /// </summary>
        public bool IsCreated { get; set; }

    }
}
