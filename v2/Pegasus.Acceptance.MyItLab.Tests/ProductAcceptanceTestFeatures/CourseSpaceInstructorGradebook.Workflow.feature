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
When I select "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" in "Gradebook" by "CsSmsInstructor"
Then I should see score "0" of "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" activity for "ZeroScore"  with "CsSmsStudent" 
And I click on 'My Course' link in gradebook by "CsSmsInstructor"

#Purpose: Instructor Validaing student submissin and grade in Instructor Gradebook
# TestCase Id: peg-22028
#MyItLabProgramCourse
Scenario: Instructor Validaing student submissin and grade in Instructor Gradebook By SMS Instructor
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page
When I select "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" in "Gradebook" by "CsSmsInstructor"
And I select the cmenu "ViewAllSubmissions" of asset "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)"
Then I should see the "0" score in view submission page for a "ZeroScore" with "CsSmsStudent"
And I click on 'My Course' link in gradebook by "CsSmsInstructor"

#Purpose: Validating Apply GradeSchema in Instructor Gradebook
# TestCase Id: peg-22030
#MyItLabProgramCourse
Scenario: Validating Apply GradeSchema in Instructor Gradebook By SMS Instructor
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page
When I select "PowerPoint Chapter 1 Skill-Based Training" in "Gradebook" by "CsSmsInstructor"
And I select the cmenu "ApplyGradeSchema" of asset "PowerPoint Chapter 1 Skill-Based Training"
And I 'Apply' the grade schema for the submitted activity
Then I should see the "PowerPoint Chapter 1 Skill-Based Training" activity status "A" in Gradebook for enrollled "CsSmsStudent"
When I select the cmenu "RemoveGradeSchema" of asset "PowerPoint Chapter 1 Skill-Based Training"
Then I click on 'My Course' link in gradebook by "CsSmsInstructor"

#Purpose: Instructor Validating student Study Plan Grade in Instructor Gradebook
# TestCase Id: peg-22027
#MyItLabProgramCourse
Scenario: Instructor Validating student Study Plan Grade in Instructor Gradebook By SMS Instructor
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page
When I select "Excel Chapter 1 Study Plan [Skill-Based]: Training > Post-Test" in "Gradebook" by "CsSmsInstructor"
And I click on view grades of "Excel Chapter 1 Study Plan [Skill-Based]: Training > Post-Test" in gradebook
Then I should see the score "100" of "Excel Chapter 1 Skill-Based Training - Pre-test Training" activity for "CsSmsStudent"
And I should see the score "100" of "Excel Chapter 1 Skill-Based Exam (Scenario 1)-Post Test" activity for "CsSmsStudent"
And I click on 'My Course' link in gradebook by "CsSmsInstructor"

#Purpose: :Instructor Accepting Pastdue Submission in Instructor Gradebook
#TestCase Id: peg-22029
#MyItLabProgramCourse
Scenario: Instructor Accepting Pastdue Submission in Instructor Gradebook By SMS Instructor
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page
When I select "Excel Chapter 1 Skill-Based Training" in "Gradebook" by "CsSmsInstructor"
And I select the cmenu "ViewAllSubmissions" of asset "Excel Chapter 1 Skill-Based Training"
Then I should see "Decline" and "Accept" options in view submission page
When I select the option "Accept" in view submission page
And I close the "View Submission" window
Then I should see the score "0" of "Excel Chapter 1 Skill-Based Training" activity for "CsSmsStudent"
And I click on 'My Course' link in gradebook by "CsSmsInstructor"

#Purpose: Instructor Validating badge in instructor grade book
Scenario: Instructor Validating badge in instructor grade book By SMS Instructor
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page
When I select "Word Chapter 1 Grader Project [Assessment 3]" in "Gradebook" by "CsSmsInstructor"
Then I should see the badge icon for "Word Chapter 1 Grader Project [Assessment 3]" as "CsSmsInstructor"

#---------------------------------------------------------------------------------------------------------------------

#Purpose: :Instructor validating the functionality of saving column to Custom View from Gradebook tab
#TestCase Id: 
#MyItLabProgramCourse, MySpanishLabCourse
#Pre Condition: Activity should have submission
Scenario:Instructor Validating the functionality of saving columns to custom view from Gradebook tab
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
When I enter in the "MyItLabInstructorCourse" course from the Global Home page as "CsSmsInstructor"
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page
When I select "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" in "Gradebook" by "CsSmsInstructor"
And I select the cmenu "Save to Custom View" of asset "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)"
Then I should be able to see "Column successfully saved to Custom View." message
When I navigate to "Gradebook" tab
And I select "Excel Chapter 1 Study Plan [Skill-Based]: Training > Post-Test" in "Gradebook" by "CsSmsInstructor"
And I select the cmenu "Save to Custom View" of asset "Excel Chapter 1 Study Plan [Skill-Based]: Training > Post-Test"
Then I should be able to see "Column successfully saved to Custom View." message

#Purpose: :Instructor validating the functionality of removing column from Custom View from Gradebook tab
#TestCase Id: 
#MyItLabProgramCourse, MySpanishLabCourse
#Pre Condition: Activity should have submission
Scenario:Instructor Validating the functionality of removing saved custom columns from Gradebook tab
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyItLabInstructorCourse" course from the Global Home page as "CsSmsInstructor"
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page
When I select "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" in "Gradebook" by "CsSmsInstructor"
And I select the cmenu "Remove from Custom View" of asset "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)"
Then I should be able to see "Column successfully removed from Custom View." message

#Purpose: :Instructor validating the display of saved column name, students and score in Custom View subtab
#TestCase Id: 
#MyItLabProgramCourse, MySpanishLabCourse
#Pre Condition: Column should be saved to Custom view tab
Scenario:Instructor verifying the display of saved custom column in custom view tab
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyItLabInstructorCourse" course from the Global Home page as "CsSmsInstructor"
When I navigate to "Gradebook" tab and selected "Custom View" subtab
Then I should be on the "Custom View" page
And I should see "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" activity with "0" score for "ZeroScore" with "CsSmsStudent" in Custom view tab
And I should see "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" activity with "100" score for "CsSmsStudent" in Custom view tab

#---------------------------------------------------------------------------------------------------------------------------------------------------------------

#Purpose: :Instructor validating the View Submission page of past due submitted activity
#TestCase Id: 
#MyItLabProgramCourse
#Pre Condition: Pastdue activity should be submitted by the student
Scenario:Instructor verifying the View Submission page of past due submitted activity
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I search the "RegMILPastDueActivity" in My Course frame
Then I should see the "RegMILPastDueActivity" in 'My Course'
When I click the activity cmenu option in MyCourse Frame
And I click on "View Submissions" cmenu option
Then I should be on the "View Submission" page
And I should see "RegMILPastDueActivity" activity name 
And I should see 'StudentsList' grid with "Name" "Grade" columns having "4" entries as "CsSmsInstructor" user
When I click on "CsSmsStudent" in the StudentList
Then I should see "CsSmsStudent" with "Pastdue" icon

#Purpose: :Instructor validating the View Submission page of an activity submitted forcefully
#TestCase Id: 
#MyItLabProgramCourse
#Pre Condition: An activity should be saved for later by the student
Scenario:Instructor verifying the View Submission page of forcefully submitted activity
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I search the "RegMILForcefullSubmissionActivity" in My Course frame
Then I should see the "RegMILForcefullSubmissionActivity" in 'My Course'
When I click the activity cmenu option in MyCourse Frame
And I click on "View Submissions" cmenu option
Then I should be on the "View Submission" page
And I should see "RegMILForcefullSubmissionActivity" activity name 
And I should see 'StudentsList' grid with "Name" "Grade" columns having "4" entries as "CsSmsInstructor" user
And I should see "CsSmsStudent" with "--" grade
When I click on "CsSmsStudent" in the StudentList
And I click on 'Submit Students Answer' button
Then I should see "CsSmsStudent" with "0" submission grade 

#--------------------------------------------------------------------------------------------------------------------------
										#Validate Grades for Grader IT in GB as Instructor#
#--------------------------------------------------------------------------------------------------------------------------
Scenario: Instructor validate GraderIT score for zero percent in Gradebook
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyItLabInstructorCourse" course from the Global Home page as "CsSmsInstructor"
When I click on "Grades" subtab in "Gradebook" tab as "CsSmsInstructor" user
Then I should be on the "Gradebook" page
When I select "RegWordGraderActivity" in "Gradebook" as "CsSmsInstructor"
Then I should see the score "100" for "RegWordGraderActivity" activity for "CsSmsStudent"


#--------------------------------------------------------------------------------------------------------------------------
										#Validate Grades for SIM5 in GB as Instructor#
#--------------------------------------------------------------------------------------------------------------------------

Scenario: Instructor validate SIM5 submission for zero percent in Gradebook
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyItLabInstructorCourse" course from the Global Home page as "CsSmsInstructor"
When I click on "Grades" subtab in "Gradebook" tab as "CsSmsInstructor" user
Then I should be on the "Gradebook" page
When I select "RegWordSIMActivity" in "Gradebook" as "CsSmsInstructor"
Then I should see the score "0" for "RegWordSIMActivity" activity for "CsSmsStudent"

#--------------------------------------------------------------------------------------------------------------------------
										#Validate Grades in Viewsubmission as Instructor#
#--------------------------------------------------------------------------------------------------------------------------

Scenario: Instructor validate SIM5 submission in viewsubmission from Gradebook
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyItLabInstructorCourse" course from the Global Home page as "CsSmsInstructor"
When I click on "Grades" subtab in "Gradebook" tab as "CsSmsInstructor" user
Then I should be on the "Gradebook" page
When I select "RegWordSIMActivity" in "Gradebook" as "CsSmsInstructor"
When I click the cmenu "ViewAllSubmissions" of asset "RegWordSIMActivity" 
Then I should be displayed with "SimActivity0Score" for "RegWordSIMActivity"  for "CsSmsStudent" user "scoring 0" scenario

#--------------------------------------------------------------------------------------------------------------------------
										#Delete Grades in Viewsubmission as Instructor#
#--------------------------------------------------------------------------------------------------------------------------
Scenario: Instructor delete grades in view submission from gradebook
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyItLabInstructorCourse" course from the Global Home page as "CsSmsInstructor"
When I click on "Grades" subtab in "Gradebook" tab as "CsSmsInstructor" user
Then I should be on the "Gradebook" page
When I select "RegWordSIMActivity" in "Gradebook" as "CsSmsInstructor"
When I click the cmenu "ViewAllSubmissions" of asset "RegWordSIMActivity" 
And I delete all submission for "RegWordSIMActivity" of "CsSmsStudent" user "scoring 0" scenario
