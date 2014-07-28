using System;
using System.Collections.Generic;
using System.Linq;
using Pearson.Pegasus.TestAutomation.Frameworks;

namespace Pegasus.Automation.DataTransferObjects
{
    /// <summary>
    /// This class is represents an activity.
    /// </summary>
    public class Activity : BaseEntityObject
    {
        /// <summary>
        /// This is the behavioral modes of activity.
        /// </summary>
        public enum ActivityBehavioralModesEnum
        {
            BasicRandom = 1,
            Assignment = 2,
            DocBased = 3,
            SkillBased = 4,
            Adaptive = 5,
            WritingCoach = 6
        }

        /// <summary>
        /// This is the type of activity.
        /// </summary>
        public enum ActivityTypeEnum
        {
            Null = 0, // When there is no activity type we can pass this. So that rewriting the same function is not required
            SkillStudyPlan = 1,
            HomeWork = 2,
            Folder = 3,
            Test = 4,
            Link = 5,
            StudyPlan = 6,
            eText = 7,
            MyTest=8,
            SIM5Activity =9,
            SIM5StudyPlan =10,
            Sim5PreTest=11,
            Sim5PostTest=12,
            SIM5GraderActivity=13,
            File = 14,
            DiscussionTopic = 15,
            Page = 16,
            SIMExamActivity=17,
            SIMTrainingActivity=18,            
            SIMStudyPlan2007 =19,
            SIMStudyPlan2010=20,
            SIMGraderActivity=21,
            Quiz=22,
            WritingSpace=23,
            PracticeTest=24,
            PreTest=25,
            CalculatedColumn=26,
            QuestionFolder = 27
        }

        /// <summary>
        /// Specifies Shown /  hidden status.
        /// </summary>
        public enum ShowHideStatusEnum
        {
            None = 1,
            Shown = 2,
            Hidden = 3
        }

        /// <summary>
        /// This is the type of activity.
        /// </summary>
        public ActivityTypeEnum ActivityType { get; set; }

        /// <summary>
        /// This is the activity behavioral mode.
        /// </summary>
        public ActivityBehavioralModesEnum ActivityBehavioralMode { get; set; }

        /// <summary>
        /// This is the activity ID.
        /// </summary>
        public string ActivityID { get; set; }

        /// <summary>
        /// This is activity show-hide status.
        /// </summary>
        public ShowHideStatusEnum ShowHideStatus { get; set; }

        /// <summary>
        /// This is the Audio Page activity ID.
        /// </summary>
        public string AudioPageAssetID { get; set; }
        
        /// <summary>
        /// This method is used to create a new activity.
        /// </summary>
        public void StoreActivityInMemory()
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Insert(this);
        }

        /// <summary>
        /// This method gets the activity based on the type.
        /// </summary>
        /// <param name="activityType">This is the type of the activity.</param>
        /// <returns>The activity.</returns>
        public static Activity Get(ActivityTypeEnum activityType)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<Activity>(
                x => x.ActivityType == activityType && x.IsCreated).OrderByDescending(
                x => x.CreationDate).First();
        }

        /// <summary>
        /// Gets activity based on show-hide status.
        /// </summary>
        /// <param name="showHideStatus">Show-hide status.</param>
        /// <returns>Activity based on Show-hide status.</returns>
        public static Activity Get(ShowHideStatusEnum showHideStatus)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance
                .SelectMany<Activity>(x => x.ShowHideStatus == showHideStatus && x.IsCreated)
                .FirstOrDefault();
        }

        /// <summary>
        /// This method gets the activity based on the behaviour mode.
        /// </summary>
        /// <param name="activityTypeEnum">This is activity type enum.</param>
        /// <param name="activityBehavioralModesEnum">This is the behaviour of the activity.</param>
        /// <returns>The activity.</returns>
        public static Activity Get(ActivityTypeEnum activityTypeEnum, ActivityBehavioralModesEnum activityBehavioralModesEnum)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<Activity>(
                x => x.ActivityType == activityTypeEnum && x.ActivityBehavioralMode == activityBehavioralModesEnum && x.IsCreated).OrderByDescending(
                x => x.CreationDate).First();
        }

        /// <summary>
        /// This method gets the activity based on Activity ID.
        /// </summary>
        /// <param name="activityId">This is activity ID.</param>
        /// <returns>Returns Activity based in ID.</returns>
        public static Activity Get(string activityId)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<Activity>(x => x.ActivityID == activityId && x.IsCreated).First();
        }

        /// <summary>
        /// Returns activity based on custom query.
        /// </summary>
        /// <param name="predicate">The where condition.</param>
        /// <returns>List of activities.</returns>
        public static List<Activity> Get(Func<Activity, bool> predicate)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany(predicate);
        }

        /// <summary>
        /// This method is used to update the activity.
        /// </summary>
        public void UpdateActivityInMemory(Activity activity)
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Update(activity);
        }

        /// <summary>
        /// This method returns all created activity of the given type.
        /// </summary>
        /// <param name="activityType">This is the type of the activity.</param>
        /// <returns>Activity List.</returns>
        public static List<Activity> GetAll(ActivityTypeEnum activityType)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<Activity>(
                x => x.ActivityType == activityType).OrderByDescending(
                x => x.CreationDate).ToList();
        }
    }
}
