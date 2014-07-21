using System;
using System.Linq;

namespace Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects
{
    /// <summary>
    /// This class represents a workspace.
    /// </summary>
    public class WorkSpace : BaseEntityObject
    {

        /// <summary>
        /// This is the type of the workspace
        /// </summary>
        public enum WorkSpaceTypeEnum
        {
            DPWorkSpace = 1,
            NovaNETWorkSpace = 2,
            HEDMilWorkSpace=3
        }

        /// <summary>
        /// This is the password.
        /// </summary>
        public String Password { get; set; }   

        /// <summary>
        /// This is the type of the workspace.
        /// </summary>
        public WorkSpaceTypeEnum WorkSpaceType { get; set; }

        /// <summary>
        /// This is the workspace Description.
        /// </summary>
        public String WorkSpaceDescription { get; set; }

        /// <summary>
        /// This method inserts a new workspace into the system.
        /// </summary>]
        public void StoreWorkSpaceInMemory()
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Insert(this);
        }

        /// <summary>
        /// This method selects a single workspace based on the type.
        /// </summary>
        /// <param name="workSpaceType">This is the workspace type.</param>
        /// <returns>A single workspace.</returns>
        public static WorkSpace Get(WorkSpaceTypeEnum workSpaceType)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<WorkSpace>(x => x.WorkSpaceType == workSpaceType && x.IsCreated).OrderByDescending(
                x => x.CreationDate).First();
        }

        /// <summary>
        /// Returns a workspace based on name.
        /// </summary>
        /// <param name="workSpace">The name of the workspace.</param>
        /// <returns>The workspace.</returns>
        public static WorkSpace Get(String workSpace)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<WorkSpace>(x => x.Name == workSpace && x.IsCreated).OrderByDescending(
                x => x.CreationDate).First(); ;
        }
    }
}
