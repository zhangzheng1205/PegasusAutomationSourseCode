using System;
using System.Collections.Generic;
using System.Linq;
using Pearson.Pegasus.TestAutomation.Frameworks;

namespace Pegasus.Automation.DataTransferObjects
{
    /// <summary>
    /// This class is represents an activity.
    /// </summary>
    public class WelcomeMessage : BaseEntityObject
    {
        /// <summary>
        /// This is the type of the grade
        /// </summary>
        public enum WelcomeMessageTypeEnum
        {
            RegTVInsWelcomeMsg = 1,
        }

        /// <summary>
        /// This is the type of the grade
        /// </summary>
        public WelcomeMessageTypeEnum WelcomeMessageType { get; set; }

        /// <summary>
        /// This is the Rumba Section ID
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Inserts the grade into the database
        /// </summary>
        public void StoreWelcomeMessageInMemory()
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Insert(this);
        }


        /// <summary>
        /// Gets the last created class from the application.
        /// </summary>
        /// <param name="gradeTypeEnum">This is the grade type enum.</param>
        /// <returns>The grade</returns>
        public static WelcomeMessage Get(WelcomeMessageTypeEnum welcomeMessageTypeEnum)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<WelcomeMessage>(x => x.WelcomeMessageType == welcomeMessageTypeEnum
                && x.IsCreated).OrderByDescending(x => x.CreationDate).First();
        }

        /// <summary>
        /// Returns Grade based on custom query
        /// </summary>
        /// <param name="predicate">The where condition</param>
        /// <returns>List of grade</returns>
        public static List<WelcomeMessage> Get(Func<WelcomeMessage, bool> predicate)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany(predicate);
        }

        /// <summary>
        /// This method is used to update the grade name.
        /// </summary>
        /// <param name="score">This is the grade name.</param>
        public void UpdateWelcomeMessageName(string message)
        {
            WelcomeMessage WelcomeMessage = InMemoryDatabaseSingleton.DatabaseInstance.SelectTopOne<WelcomeMessage>(x => x.Message == Message);
            WelcomeMessage.Message = message;
        }

        /// <summary>
        /// This method is used to update the user.
        /// </summary>
        public void UpdateeWelcomeMessageInMemory(WelcomeMessage welcomeMessageUpdate)
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Update(welcomeMessageUpdate);
        }

        /// <summary>
        /// This method returns all created grade of the given type.
        /// </summary>
        /// <param name="gradeType">This is the type of the grade.</param>
        /// <returns>Grade List.</returns>
        public static List<WelcomeMessage> GetAll(WelcomeMessageTypeEnum welcomeMessageType)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<WelcomeMessage>(
                x => x.WelcomeMessageType == welcomeMessageType).OrderByDescending(
                x => x.CreationDate).ToList();
        }
    }
}