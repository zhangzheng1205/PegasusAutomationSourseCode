using System;
using System.Collections.Generic;
using System.Linq;

namespace Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects
{
    /// <summary>
    /// This is the question entity
    /// </summary>
    public class Question : BaseEntityObject
    {

        /// <summary>
        /// This is the question type enum
        /// </summary>
        public enum QuestionTypeEnum
        {
            MultipleChoice = 1,
            FillInTheBlank = 2,
            SCO = 3,
            MGM = 4,
            TrueFalse = 5,
            DropDownList = 6,
            FileUpload = 7,
            Essay = 8,
            EntryList = 9,
            MultipleResponse = 10,
            Numeric = 11,
            SelectABlank = 13,
            TextMatch = 14,
            Flash = 15,
            Matching = 16,
            Ranking = 17,
            CreateQuestionGroup = 18,
            SIMGraderQuestion = 19,
            SIM2010ExcelQuestionSet = 20,
            SIM2010WordQuestionSet = 21,
            SIM2010PowerPointQuestionSet = 22,
            SIM2010MSAccessQuestionSet = 23,
            SIM2007ExcelQuestionSet = 24,
            SIM2007WordQuestionSet = 25,
            SIM2007PowerPointQuestionSet = 26,
            SIM2007MSAccessQuestionSet = 27,
            SIM5GraderQuestion = 28
        }

        /// <summary>
        /// This is the type of the question
        /// </summary>
        public QuestionTypeEnum QuestionType { get; set; }

        /// <summary>
        /// This is the question Id.
        /// </summary>
        public string QuestionId { get; set; }

        /// <summary>
        /// This method creates a new question
        /// </summary>
        public void StoreQuestionInMemory()
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Insert(this);
        }

        /// <summary>
        /// This class is used to get the last question of the given type
        /// </summary>
        /// <param name="questionType">This is the question type</param>
        /// <returns>Returna a question</returns>
        public static Question Get(QuestionTypeEnum questionType)
        {

            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<Question>(
                x => x.QuestionType == questionType && x.IsCreated
                ).OrderByDescending(x => x.CreationDate).First();

        }

        /// <summary>
        /// Returns Question based on custom query
        /// </summary>
        /// <param name="predicate">The where condition</param>
        /// <returns>List of Question</returns>
        public static List<Question> Get(Func<Question, bool> predicate)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany(predicate);
        }

        /// <summary>
        /// This method gets the question based on question Id.
        /// </summary>
        /// <param name="questionId">This is activity ID.</param>
        /// <returns>Returns Activity based in ID.</returns>
        public static Question Get(string questionId)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<Question>(x => x.QuestionId == questionId && x.IsCreated).First();
        }

        /// <summary>
        /// This method returns all created quesions of the given type.
        /// </summary>
        /// <param name="questionType">This is the type of the question.</param>
        /// <returns>Questions List.</returns>
        public static List<Question> GetAll(QuestionTypeEnum questionType)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<Question>(
                x => x.QuestionType == questionType).OrderByDescending(
                x => x.CreationDate).ToList();
        }
    }
}
