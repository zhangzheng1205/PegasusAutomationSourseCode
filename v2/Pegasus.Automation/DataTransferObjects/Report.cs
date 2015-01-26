using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;

namespace Pegasus.Automation.DataTransferObjects
{
    /// <summary>
    /// This class represents a report.
    /// </summary>
    public class Report : BaseEntityObject
    {
        /// <summary>
        /// This is report type enum.
        /// </summary>
        public enum ReportTypeEnum
        {
            NovaNETStudentEnrollment = 1,
            DigitalPathStudentEnrollment = 2,
            HedCoreStudentEnrollment = 3,
            HedMilStudentEnrollment = 4,
            MyTestStudentEnrollment = 5,
            HedMilStudyPlanSingleStudent = 6,
            MyItLabTrainingFrequencyAnalysis = 7,
            MyItLabActivityResultsMultipleStudentsAdActivities = 8,
            MyITLabActivityResultsMultipleStudents = 9,
            MyITLabExamFrequencyAnalysis = 10,
            HSSActivityResultsByStudent = 11,
            HSSStudytPlanResults = 12,
            HSSStudentResultsbyActivity = 13,
            DPActivityResultsByStudent =14,
            DPStudentResultByActivity = 15

        }

        /// <summary>
        /// This is the type of report.
        /// </summary>
        public ReportTypeEnum ReportType { get; set; }

        /// <summary>
        /// This method is used to store a report.
        /// </summary>
        public void StoreReportInMemory()
        {
            InMemoryDatabaseSingleton.DatabaseInstance.Insert(this);
        }

        /// <summary>
        /// This method returns the last created report of the given type.
        /// </summary>
        /// <param name="reportTypeEnum">This is the type of the report.</param>
        /// <returns>The report.</returns>
        public static Report Get(ReportTypeEnum reportTypeEnum)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany<Report>(
                x => x.ReportType == reportTypeEnum && x.IsCreated).OrderByDescending(
                x => x.CreationDate).First();
        }

        /// <summary>
        /// This method returns the list of report of the given type.
        /// </summary>
        /// <param name="predicate">This is the condition to retrieve the report.</param>
        /// <returns>The report.</returns>
        public static List<Report> Get(Func<Report, bool> predicate)
        {
            return InMemoryDatabaseSingleton.DatabaseInstance.SelectMany(predicate);
        }
    }
}
