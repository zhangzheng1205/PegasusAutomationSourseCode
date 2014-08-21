using System;
using System.Collections.Generic;
using System.Linq;
using Pearson.Pegasus.TestAutomation.Frameworks;

namespace Pegasus.Automation.DataTransferObjects
{
    /// <summary>
    /// This class represents activity questions list.
    /// </summary>
    public class ActivityQuestionsList : BaseEntityObject
    {
        /// <summary>
        /// This is the first option.
        /// </summary>
        public String FirstOption { get; set; }

        /// <summary>
        /// This is the second option.
        /// </summary>
        public String SecondOption { get; set; }

        /// <summary>
        /// This is the third option.
        /// </summary>
        public String ThirdOption { get; set; }

        /// <summary>
        /// This is the fourth option.
        /// </summary>
        public String FourthOption { get; set; }

        /// <summary>
        /// This is the correct answer.
        /// </summary>
        public String CorrectOption { get; set; }

        /// <summary>
        /// This is the activity name.
        /// </summary>
        public enum ActivityNameEnum
        {
            #region Question Name
            TakeTheChapter1Exam = 1

            #endregion
        }

        /// <summary>
        /// This is the type activity behaviour mode.
        /// </summary>
        public enum ActivityBehaviourTypeEnum
        {
            #region Activity Type
            BasicRandom = 1
            #endregion
        }

        /// <summary>
        /// This is the type of activity.
        /// </summary>
        public enum ActivityTypeEnum
        {
            #region Activity Type
            Homework = 1
            #endregion
        }

        /// <summary>
        /// This is the name of activity.
        /// </summary>
        public ActivityNameEnum ActivityName { get; set; }

        /// <summary>
        /// This is the name of activity behaviour mode.
        /// </summary>
        public ActivityBehaviourTypeEnum ActivityBehaviourType { get; set; }

        /// <summary>
        /// This is the name of activity type.
        /// </summary>
        public ActivityTypeEnum ActivityType { get; set; }


        /// <summary>
        /// This method selects activity questions based on given condition.
        /// </summary>
        /// <param name="predicate">The condition.</param>
        /// <returns>A list of questions.</returns>
        public static List<ActivityQuestionsList> Get(Func<ActivityQuestionsList, bool> predicate)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany(predicate);
        }

        /// <summary>
        /// This method inserts questions in memory.
        /// </summary>]
        public void StoreActivityQuestionsInMemory()
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Insert(this);
        }

        /// <summary>
        /// This method selects a single question based on the activity Type, Name and Behaviour mode.
        /// </summary>
        /// <param name="activityNameEnum">This is name of the activity type.</param>
        /// <param name="activityBehaviourTypeEnum">This is name of activity behaviour mode.</param>
        /// <param name="activityTypeEnum">This is activity name.</param>
        /// <returns>A single question.</returns>
        public static ActivityQuestionsList Get(ActivityTypeEnum activityTypeEnum,
            ActivityBehaviourTypeEnum activityBehaviourTypeEnum, ActivityNameEnum activityNameEnum)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany
                <ActivityQuestionsList>(x => x.ActivityType == activityTypeEnum
                    && x.ActivityBehaviourType == activityBehaviourTypeEnum && x.ActivityName == activityNameEnum && x.IsCreated)
                .OrderByDescending(x => x.CreationDate).First();
        }

        /// <summary>
        /// This method returns all questions based on the activity Type, Name and Behaviour mode.
        /// </summary>
        /// <param name="activityNameEnum">This is name of the activity type.</param>
        /// <param name="activityBehaviourTypeEnum">This is name of the activity behaviour mode.</param>
        /// <param name="activityTypeEnum">This is activity name.</param>
        /// <returns>Questions List.</returns>
        public static List<ActivityQuestionsList> GetAll(ActivityTypeEnum activityTypeEnum,
            ActivityBehaviourTypeEnum activityBehaviourTypeEnum, ActivityNameEnum activityNameEnum)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<ActivityQuestionsList>(
                x => x.ActivityType == activityTypeEnum && x.ActivityBehaviourType == activityBehaviourTypeEnum
                    && x.ActivityName == activityNameEnum).OrderByDescending(x => x.CreationDate).ToList();
        }
    }
}
