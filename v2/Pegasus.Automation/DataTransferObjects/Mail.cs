using System;
using System.Collections.Generic;
using System.Linq;

namespace Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects
{
    /// <summary>
    /// This class is represents mail messages.
    /// </summary>
    public class Mail : BaseEntityObject
    {
        /// <summary>
        /// This is the type of mail.
        /// </summary>
        public enum MailTypeEnum
        {
            DPCsTeacher = 1,
            CsSmsInstructor = 2
        }

        /// <summary>
        /// This is the Mail Subject.
        /// </summary>
        public String Subject { get; set; }

        /// <summary>
        /// This is the Mail Body Message.
        /// </summary>
        public String Message { get; set; }

        /// <summary>
        /// This is the type of Mail send by user.
        /// </summary>
        public MailTypeEnum MailType { get; set; }

        /// <summary>
        /// This method is used to save new mail.
        /// </summary>
        public void StoreMailMessageInMemory()
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Insert(this);
        }

        /// <summary>
        /// This method gets the mail based on the type.
        /// </summary>
        /// <param name="mailTypeEnum">This is the type of the mail.</param>
        /// <returns>The mail details.</returns>
        public static Mail Get(MailTypeEnum mailTypeEnum)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<Mail>(
                x => x.MailType == mailTypeEnum && x.IsCreated).OrderByDescending(
                x => x.CreationDate).First();
        }

        /// <summary>
        /// Returns Mail based on custom query.
        /// </summary>
        /// <param name="predicate">The where condition.</param>
        /// <returns>List of mail.</returns>
        public static List<Mail> Get(Func<Mail, bool> predicate)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany(predicate);
        }

        /// <summary>
        /// This method returns all created mail of the given type.
        /// </summary>
        /// <param name="mailType">This is the type of the mail.</param>
        /// <returns>Mail List.</returns>
        public static List<Mail> GetAll(MailTypeEnum mailType)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<Mail>(
                x => x.MailType == mailType).OrderByDescending(
                x => x.CreationDate).ToList();
        }
    }
}
