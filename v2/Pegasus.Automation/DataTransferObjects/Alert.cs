using System;
using System.Collections.Generic;
using System.Linq;
using Pearson.Pegasus.TestAutomation.Frameworks;


namespace Pegasus.Automation.DataTransferObjects
{
    /// <summary>
    /// This class is represents an activity.
    /// </summary>
    public class Alert : BaseEntityObject
    {
        /// <summary>
        /// This is the type of the grade
        /// </summary>
        public enum AlertTypeEnum
        {
            RegNotPassedAlertCount =1,
            RegNewGradesAlertCount=2,
            RegIdleStudentCount=3,
            RegPastDueSubmittedCount=4,
            RegPastDueNotSubmittedCount=5,
            RegUnreadCommentsCount=6,
            RegAlertsCount=7,
        }

        /// <summary>
        /// This is the type of the grade
        /// </summary>
        public AlertTypeEnum AlertType { get; set; }

        /// <summary>
        /// This is the Rumba Section ID
        /// </summary>
        public string AlertCount { get; set; }

        /// <summary>
        /// Inserts the grade into the database
        /// </summary>
        public void StoreAlertInMemory()
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Insert(this);
        }


        /// <summary>
        /// Gets the last created class from the application.
        /// </summary>
        /// <param name="gradeTypeEnum">This is the grade type enum.</param>
        /// <returns>The grade</returns>
        public static Alert Get(AlertTypeEnum alertTypeEnum)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<Alert>(x => x.AlertType == alertTypeEnum
                && x.IsCreated).OrderByDescending(x => x.CreationDate).First();
        }

        /// <summary>
        /// Returns Grade based on custom query
        /// </summary>
        /// <param name="predicate">The where condition</param>
        /// <returns>List of grade</returns>
        public static List<Alert> Get(Func<Alert, bool> predicate)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany(predicate);
        }

        /// <summary>
        /// This method is used to update the grade name.
        /// </summary>
        /// <param name="score">This is the grade name.</param>
        public void UpdateAlertName(string alertCount)
        {
            Alert Alert = InMemoryDatabaseSingleton.DatabaseInstance.SelectTopOne<Alert>(x => x.AlertCount == AlertCount);
            Alert.AlertCount = alertCount;
        }

        /// <summary>
        /// This method is used to update the user.
        /// </summary>
        public void UpdateAlertInMemory(Alert alertUpdate)
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Update(alertUpdate);
        }

        /// <summary>
        /// This method returns all created grade of the given type.
        /// </summary>
        /// <param name="gradeType">This is the type of the grade.</param>
        /// <returns>Grade List.</returns>
        public static List<Alert> GetAll(AlertTypeEnum alertType)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<Alert>(
                x => x.AlertType == alertType).OrderByDescending(
                x => x.CreationDate).ToList();
        }
    }
}