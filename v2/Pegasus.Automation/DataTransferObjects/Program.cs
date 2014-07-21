using System;
using System.Collections.Generic;
using System.Linq;

namespace Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects
{
    /// <summary>
    /// This is the program class
    /// </summary>
    public class Program : BaseEntityObject
    {
        /// <summary>
        /// This is the name of the empty course
        /// </summary>
        private String CourseName { get; set; }

        /// <summary>
        /// This returns the course of the program
        /// </summary>
        public Course Course
        {
            get
            {
                return Course.Get(CourseName);
            }
        }

        /// <summary>
        /// This is the program type enum
        /// </summary>
        public enum ProgramTypeEnum
        {
            NovaNET = 1,
            DigitalPath = 2,
            HedCore = 3,
            HedMil = 4,
            PromotedAdminDigitalPathProgram = 5,
            PromotedAdminNovaNETProgram = 6,
        }

        /// <summary>
        /// This is the type of the program
        /// </summary>
        public ProgramTypeEnum ProgramType { get; set; }

        /// <summary>
        /// This method creates a program
        /// </summary>
        public void StoreProgramInMemory()
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Insert(this);
        }

        /// <summary>
        /// This gets the given program by type which was created last
        /// </summary>
        /// <param name="programTypeEnum"> The name of the program by type</param>
        public static Program Get(ProgramTypeEnum programTypeEnum)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<Program>(
                x => x.ProgramType == programTypeEnum && x.IsCreated).OrderByDescending(
                x => x.CreationDate).First();
        }

        /// <summary>
        /// Returns Program based on custom query
        /// </summary>
        /// <param name="predicate">The where condition</param>
        /// <returns>List of Program</returns>
        public static List<Program> Get(Func<Program, bool> predicate)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany(predicate);
        }

        /// <summary>
        /// This method returns all created program of the given type.
        /// </summary>
        /// <param name="programType">This is the type of the program.</param>
        /// <returns>Program List.</returns>
        public static List<Program> GetAll(ProgramTypeEnum programType)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<Program>(
                x => x.ProgramType == programType).OrderByDescending(
                x => x.CreationDate).ToList();
        }
    }
}
