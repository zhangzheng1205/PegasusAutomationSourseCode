Feature: CourseSpaceInstructor
	                As a courseSpace Instructor
					I want to manage all the coursespace Instructor related usecases 
					so that I would validate all the coursespace Instructor scenarios are working fine.

Background:
#Purpose: Open Cs Url
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyItLabInstructorCourse" from the Global Home page as "CsSmsInstructor" 
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
And I select the "Manage Question Bank" tab
Then I should be on the "Question Bank" page


#Purpose: To create the GradeIT Question in coursespace
Scenario: Create the GradeIT Question in coursespace by CsSmsInstructor
When I select 'Add Course Materials' option
And I select "Grader Project" option
And I create "SIMGraderQuestion" grader IT Question using "A Kiss Of Chocolate" project in 'CourseSpace'
Then I should see the successfull message "Question added successfully.""
And I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To Verify “Edit Grader Project Instructions” should be visible user Edit the Question
Scenario: Verify “Edit Grader Project Instructions” should be visible user Edit the Question by CsSmsInstructor
When I click on "Edit" cmenu option of "SIMGraderQuestion" question in manage question bank
Then I should see instead of 'Preference', 'Edit Grader Project Instruction' is visible 
And I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."