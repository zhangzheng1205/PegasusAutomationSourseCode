using System;
using System.Collections.Generic;
using System.Linq;
using Pearson.Pegasus.TestAutomation.Frameworks;

namespace Pegasus.Automation.DataTransferObjects
{
    /// <summary>
    /// This entity represnts a class
    /// </summary>
    public class Class : BaseEntityObject
    {

        /// <summary>
        /// This is the type of the class
        /// </summary>
        public enum ClassTypeEnum
        {
            NovaNETTemplate =1,
            NovaNETMasterLibrary=2,
            DigitalPathTemplate=3,
            DigitalPathMasterLibrary=4,
            NovaNETPlaceHolder=5,
            DigitalPathPlaceHolder=6,
            DigitalPathContineoMasterLibrary=7,
            MediaServerClass = 8,
            S7eTextClass = 9,
            DigitalPathWCMasterLibrary = 10
        }

        /// <summary>
        /// This is the type of the class
        /// </summary>
        public ClassTypeEnum ClassType { get; set; }

        /// <summary>
        /// This is the Rumba Section ID
        /// </summary>
        public String RumbaSectionID { get; set; }

        /// <summary>
        /// Inserts the class into the database
        /// </summary>
        public void StoreClassInMemory()
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Insert(this);
        }


        /// <summary>
        /// Gets the last created class from the application.
        /// </summary>
        /// <param name="classTypeEnum">This is the class type enum.</param>
        /// <returns>The class</returns>
        public static Class Get(ClassTypeEnum classTypeEnum)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<Class>(x => x.ClassType == classTypeEnum 
                && x.IsCreated).OrderByDescending(x => x.CreationDate).First();
        }

        /// <summary>
        /// Returns Class based on custom query
        /// </summary>
        /// <param name="predicate">The where condition</param>
        /// <returns>List of class</returns>
        public static List<Class> Get(Func<Class, bool> predicate)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany(predicate);
        }

        /// <summary>
        /// This method is used to update the class name.
        /// </summary>
        /// <param name="className">This is the class name.</param>
        public void UpdateClassName(string className)
        {
            Class Class = InMemoryDatabaseSingleton.DatabaseInstance.SelectTopOne<Class>(x => x.Name == Name);
            Class.Name = className;
        }

        /// <summary>
        /// This method is used to update the user.
        /// </summary>
        public void UpdateClassInMemory(Class classUpdate)
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Update(classUpdate);
        }

        /// <summary>
        /// This method returns all created class of the given type.
        /// </summary>
        /// <param name="classType">This is the type of the class.</param>
        /// <returns>Class List.</returns>
        public static List<Class> GetAll(ClassTypeEnum classType)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<Class>(
                x => x.ClassType == classType).OrderByDescending(
                x => x.CreationDate).ToList();
        }
    }
}
