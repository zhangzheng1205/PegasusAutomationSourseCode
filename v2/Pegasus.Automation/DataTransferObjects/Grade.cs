using System;
using System.Collections.Generic;
using System.Linq;
using Pearson.Pegasus.TestAutomation.Frameworks;

namespace Pegasus.Automation.DataTransferObjects
{
    /// <summary>
    /// This class is represents an activity.
    /// </summary>
    public class Grade : BaseEntityObject
    {

        /// <summary>
        /// This is the type of the grade
        /// </summary>
        public enum GradeTypeEnum
        {
            BBNewGrade = 1,
            BBEditedGrade = 2,
            PegasusNewGrade = 3,
            PegasusEditedGrade = 4,
            D2LDirectIntegrationEditedGrade = 5,
            D2LDirectNewGrade = 6,
            PegasusEditedGradePerc = 7,
            PegasusNewGradePerc = 8,
            GraderIT0Score = 9,
            GraderIT70Score = 10,
            GraderIT100Score =11            
        }

        /// <summary>
        /// This is the type of the grade
        /// </summary>
        public GradeTypeEnum GradeType { get; set; }

        /// <summary>
        /// This is the Rumba Section ID
        /// </summary>
        public String GradeScore { get; set; }

        /// <summary>
        /// Inserts the grade into the database
        /// </summary>
        public void StoreGradeInMemory()
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Insert(this);
        }


        /// <summary>
        /// Gets the last created class from the application.
        /// </summary>
        /// <param name="gradeTypeEnum">This is the grade type enum.</param>
        /// <returns>The grade</returns>
        public static Grade Get(GradeTypeEnum gradeTypeEnum)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<Grade>(x => x.GradeType == gradeTypeEnum
                && x.IsCreated).OrderByDescending(x => x.CreationDate).First();
        }

        /// <summary>
        /// Returns Grade based on custom query
        /// </summary>
        /// <param name="predicate">The where condition</param>
        /// <returns>List of grade</returns>
        public static List<Grade> Get(Func<Grade, bool> predicate)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany(predicate);
        }

        /// <summary>
        /// This method is used to update the grade name.
        /// </summary>
        /// <param name="score">This is the grade name.</param>
        public void UpdateGradeName(string score)
        {
            Grade Grade = InMemoryDatabaseSingleton.DatabaseInstance.SelectTopOne<Grade>(x => x.GradeScore == GradeScore);
            Grade.GradeScore = score;
        }

        /// <summary>
        /// This method is used to update the user.
        /// </summary>
        public void UpdateGradeInMemory(Grade gradeUpdate)
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Update(gradeUpdate);
        }

        /// <summary>
        /// This method returns all created grade of the given type.
        /// </summary>
        /// <param name="gradeType">This is the type of the grade.</param>
        /// <returns>Grade List.</returns>
        public static List<Grade> GetAll(GradeTypeEnum gradeType)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<Grade>(
                x => x.GradeType == gradeType).OrderByDescending(
                x => x.CreationDate).ToList();
        }
    }
}