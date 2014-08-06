Feature: CourseSpaceInstructorGradebook
	                As a Cs Instructor 
					I want to manage all the coursespace Gradebook related usecases 
					so that I would validate all the coursespace Instructor Gradebook scenarios are working fine.

#Purpose: To Verify Display of Grades in the Gradebook
# TestCase Id: HED_MIL_PWF_861
#MyItLabProgramCourse
Scenario: Display of Grades in the Gradebook By SMS Instructor
When I navigate to "Sections" tab of the "Program Administration" page
Then I should be on the "Program Administration" page
When I search the "MyItLabProgramCourse" first section
And I click the "Enter Section as Instructor"
Then I should be on the "Today's View" page
When I navigate to the "Gradebook" tab
Then I should be on the "Gradebook" page
And I should see the score "100" of "SIM5Activity" activity of behavioral mode "SkillBased" type
When I select 'Home' option
Then I should be on the "Program Administration" page

#Purpose: To Associate Activity Content From Course Materials Frame To MyCourse
#MyItLabInstructorCourse
Scenario: Associate Activity From Course Materials Frame To MyCourse
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I associate the "SIM5Activity" activity of behavioral mode "SkillBased" to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"

#Purpose: To Associate SIM5 Studyplan Content From Course Materials Frame To MyCourse
#MyItLabInstructorCourse
Scenario: Associate SIM5 Studyplan From Course Materials Frame To MyCourse
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I associate the "SIM5StudyPlan" activity of behavioral mode "SkillBased" to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"

#Purpose: Verify the functionality of "Apply Grade schema" in Gradebook
# TestCase Id: HED_MIL_PWF_882
#MyItLabInstructorCourse
Scenario: Verify the functionality of "Apply Grade schema" in Gradebook by SmsInstructor
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page
When I click on view grade "SIM5StudyPlan" of behavioral mode type "SkillBased" in Gradebook 
And I click on cmenu "ApplyGradeSchema" of studyplan Training Material "Sim5PreTest"
Then I should be on the "Gradebook schema" page
When I 'Apply' the grade schema for the submitted activity
Then I should see the successfull message "Schema applied successfully." in "Gradebook" window
And I should see the "Sim5PreTest" activity status "A" in Gradebook for all the enrollled "CsSmsStudent"
When I click on cmenu "ModifyGradeSchema" of studyplan Training Material "Sim5PreTest"
And I update the schema of the submitted activity
Then I should see the successfull message "Schema applied successfully." in "Gradebook" window
When I click on cmenu "RemoveGradeSchema" of studyplan Training Material "Sim5PreTest"
Then I should see the successfull message "Grade schema removed successfully." in "Gradebook" window
And I should see the "Sim5PreTest" activity status "100" in Gradebook for all the enrollled "CsSmsStudent"

#Purpose : Edit Grade in View Submission for Manual Gradable Activity
#Test Case Id : HED_MIL_PWF_509
#MyItLabInstructorCourse
Scenario: Edit Grade in View Submission for Manual Gradable Activity By SMS Instructor
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page
When I click the cmenu "ViewAllSubmissions" of asset "Quiz" 
Then I should be on the "View Submission" page
When I edit the grade in view submission page

#Purpose : To check the Gradebook view for multiple visit in same session
#Test Case Id : HED_MIL_PWF_1002
#MyItLabInstructorCourse
Scenario: To check the Gradebook view for multiple visit in same session By SMS Instructor
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page
When I apply 'Assignment Types' filter in gradebook
And I navigate to "Today's View" tab
And I navigate to "Gradebook" tab
Then I should see the filter selection changes made earlier

#Purpose : To confirm that edited score of any status should propagate throughout the course
#Test Case Id : HED_MIL_PWF_1008
#MyItLabInstructorCourse
Scenario: To confirm that edited score of status in course By SMS Instructor
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page
When I click the cmenu "ViewAllSubmissions" of asset "Test" 
Then I should be on the "View Submission" page
When I edit the score in view submission page
Then I should see the grade under activity column of the submitted "Test" activity for "CsSmsStudent"

#Purpose: Instructor Validating student grade in instructor grade book
# TestCase Id: peg-22025
#MyItLabProgramCourse
Scenario: Instructor Validating student grade in instructor grade book By SMS Instructor
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page
When I navigate inside the folder level type "Word" in instructor gradebook
Then I should see the score "0" of "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" activity for "CsSmsStudent"

#Purpose: Instructor Validaing student submissin and grade in Instructor Gradebook
# TestCase Id: peg-22028
#MyItLabProgramCourse
Scenario: Instructor Validaing student submissin and grade in Instructor Gradebook By SMS Instructor
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page
When I navigate inside the folder level type "Word" in instructor gradebook
And I select the cmenu "ViewAllSubmissions" of asset "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)"
Then I should see "70" score in view submission page

#Purpose: Validating Apply GradeSchema in Instructor Gradebook
# TestCase Id: peg-22030
#MyItLabProgramCourse
Scenario: Validating Apply GradeSchema in Instructor Gradebook By SMS Instructor
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page
When I navigate inside the folder level type "Word" in instructor gradebook
And I select the cmenu "ApplyGradeSchema" of asset "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)"
And I 'Apply' the grade schema for the submitted activity
Then I should see the "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" activity status "F" in Gradebook for enrollled "CsSmsStudent"

#Purpose: Instructor Validating student Study Plan Grade in Instructor Gradebook
# TestCase Id: peg-22027
#MyItLabProgramCourse
Scenario: Instructor Validating student Study Plan Grade in Instructor Gradebook By SMS Instructor
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page
When I navigate inside the folder level type "Excel" in instructor gradebook
And I click on view grades of "Excel Chapter 1 Study Plan [Skill-Based]: Training > Post-Test" in gradebook
Then I should see the score "70" of "Excel Chapter 1 Skill-Based Training - Pre-test Training" activity for "CsSmsStudent"
And I should see the score "70" of "Excel Chapter 1 Skill-Based Exam (Scenario 1)-Post Test" activity for "CsSmsStudent"
