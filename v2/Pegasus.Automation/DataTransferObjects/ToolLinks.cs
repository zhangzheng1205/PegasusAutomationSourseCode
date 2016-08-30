﻿using System;
using System.Collections.Generic;
using System.Linq;
using Pearson.Pegasus.TestAutomation.Frameworks;

namespace Pegasus.Automation.DataTransferObjects
{
    /// <summary>
    /// This class represents Integration tool links.
    /// </summary>
    public class ToolLinks : BaseEntityObject
    {
        /// <summary>
        /// This is the type of Link
        /// </summary>
        public enum LinkTypeEnum
        {
           MoodleDirectInstructorLink=1,
           MoodleDirectStudentLink=2
        }

        /// <summary>
        /// This is the type of Link authored by Integration User
        /// </summary>
        public LinkTypeEnum LinkType { get; set; }



        /// <summary>
        /// This method is used to save new link.
        /// </summary>
        public void StoreLinkInMemory()
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Insert(this);
        }

        /// <summary>
        /// This method gets the link based on the type.
        /// </summary>
        /// <param name="linkTypeEnum">This is the type of the link.</param>
        /// <returns>link details.</returns>
        public static ToolLinks Get(LinkTypeEnum linkTypeEnum)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<ToolLinks>(
                x => x.LinkType == linkTypeEnum && x.IsCreated).OrderByDescending(
                x => x.CreationDate).First();
        }

        /// <summary>
        /// Returns link based on custom query.
        /// </summary>
        /// <param name="predicate">The where condition.</param>
        /// <returns>List of links.</returns>
        public static List<ToolLinks> Get(Func<ToolLinks, bool> predicate)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany(predicate);
        }

    }
}