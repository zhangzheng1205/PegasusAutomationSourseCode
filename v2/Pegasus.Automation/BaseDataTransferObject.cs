using System;

namespace Pearson.Pegasus.TestAutomation.Frameworks
{
    public class BaseDataTransferObject
    {
        /// <summary>
        /// This is the Guid id og the object. This is used by DB to update the list
        /// </summary>
        private readonly Guid _guidId = Guid.NewGuid();

        public Guid GuidId 
        {
            get { return _guidId; } 
        }

        public DateTime CreationDate { get; set; }
    }
}
