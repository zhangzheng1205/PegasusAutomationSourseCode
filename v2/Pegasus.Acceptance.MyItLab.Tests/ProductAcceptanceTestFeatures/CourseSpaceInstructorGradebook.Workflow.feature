Feature: CourseSpaceInstructorGradebook
	                As a Cs Instructor 
					I want to manage all the coursespace Gradebook related usecases 
					so that I would validate all the coursespace Instructor Gradebook scenarios are working fine.

Background:
#Purpose: Open Ws Url 
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully

#Purpose: To Verify Display of Grades in the Gradebook
# TestCase Id: HED_MIL_PWF_861
Scenario: Display of Grades in the Gradebook By SMS Instructor
When I enter in the "MyItLabProgramCourse" from the Global Home page as "CsSmsInstructor" 
Then I should be on the "Program Administration" page
When I select the "Sections" tab
And I click the "Enter Section as Instructor" option
Then I should be on the "Today's View" page
When I navigate to the "Gradebook" tab
Then I should be on the "Gradebook" page
And I should see the score "100" of "SIM5Activity" activity of behavioral mode "SkillBased" type
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To Associate Activity Content From Course Materials Frame To MyCourse
Scenario: Associate Activity From Course Materials Frame To MyCourse
When I enter in the "MyItLabInstructorCourse" from the Global Home page as "CsSmsInstructor" 
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I associate the "SIM5Activity" activity of behavioral mode "SkillBased" to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To Associate SIM5 Studyplan Content From Course Materials Frame To MyCourse
Scenario: Associate SIM5 Studyplan From Course Materials Frame To MyCourse
When I enter in the "MyItLabInstructorCourse" from the Global Home page as "CsSmsInstructor" 
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I associate the "SIM5StudyPlan" activity of behavioral mode "SkillBased" to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Verify the functionality of "Apply Grade schema" in Gradebook
# TestCase Id: HED_MIL_PWF_882
Scenario: Verify the functionality of "Apply Grade schema" in Gradebook by SmsInstructor
When I enter in the "MyItLabInstructorCourse" from the Global Home page as "CsSmsInstructor" 
Then I should be on the "Today's View" page
When I navigate to the "Gradebook" tab
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
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : Edit Grade in View Submission for Manual Gradable Activity
#Test Case Id : HED_MIL_PWF_509
Scenario: Edit Grade in View Submission for Manual Gradable Activity By SMS Instructor
When I enter in the "MyItLabInstructorCourse" from the Global Home page as "CsSmsInstructor" 
Then I should be on the "Today's View" page
When I navigate to the "Gradebook" tab
Then I should be on the "Gradebook" page
When I click the cmenu "ViewAllSubmissions" of asset "Quiz" 
Then I should be on the "View Submission" page
When I edit the grade in view submission page
And I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : To check the Gradebook view for multiple visit in same session
#Test Case Id : HED_MIL_PWF_1002
Scenario: To check the Gradebook view for multiple visit in same session By SMS Instructor
When I enter in the "MyItLabInstructorCourse" from the Global Home page as "CsSmsInstructor" 
Then I should be on the "Today's View" page
When I navigate to the "Gradebook" tab
Then I should be on the "Gradebook" page
When I apply 'Assignment Types' filter in gradebook
And I navigate to the "Today's View" tab
And I navigate to the "Gradebook" tab
Then I should see the filter selection changes made earlier
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : To confirm that edited score of any status should propagate throughout the course
#Test Case Id : HED_MIL_PWF_1008
Scenario: To confirm that edited score of status in course By SMS Instructor
When I enter in the "MyItLabInstructorCourse" from the Global Home page as "CsSmsInstructor" 
Then I should be on the "Today's View" page
When I navigate to the "Gradebook" tab
Then I should be on the "Gradebook" page
When I click the cmenu "ViewAllSubmissions" of asset "Test" 
Then I should be on the "View Submission" page
When I edit the score in view submission page
Then I should see the grade under activity column of the submitted "Test" activity for "CsSmsStudent"
And I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

