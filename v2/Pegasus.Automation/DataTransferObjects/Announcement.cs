using System;
using System.Collections.Generic;
using System.Linq;

namespace Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects
{
    /// <summary>
    /// This class is represents an announcement
    /// </summary>
    public class Announcement: BaseEntityObject
    {

        /// <summary>
        /// This is the type of announcement
        /// </summary>
        public enum AnnouncementTypeEnum
        {
            WsSystem = 1,
            CsSystem = 2,
            Global = 3,
            WsCourse = 4,
            CsCourse = 5,
            Class = 6
        }

        /// <summary>
        /// This is the type of announcement
        /// </summary>
        public AnnouncementTypeEnum AnnouncementType { get; set; }
        
        /// <summary>
        /// This method is used to save new announcement
        /// </summary>
        public void StoreAnnouncementInMemory()
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Insert(this);
        }

        /// <summary>
        /// This method gets the announcement based on the type
        /// </summary>
        /// <param name="announcementType">This is the type of the announcement</param>
        /// <returns>The Announcement</returns>
        public static Announcement Get(AnnouncementTypeEnum announcementType)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<Announcement>(
                x => x.AnnouncementType == announcementType && x.IsCreated).OrderByDescending(
                x => x.creationDate).First();
        }

        /// <summary>
        /// Returns announcement based on custom query
        /// </summary>
        /// <param name="predicate">The where condition</param>
        /// <returns>List of announcements</returns>
        public static List<Announcement> Get(Func<Announcement, bool> predicate)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany(predicate);
        }

    }
}
