Feature: CourseSpaceAuthor
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


#Purpose: To create the GradeIT Question (2010) in coursespace
Scenario: Create the GradeIT Question (2010) in coursespace
When I select 'Add Course Materials' option
And I select "Grader Project" option
And I create "SIMGraderQuestion" grader IT Question using "Personal Finances" project 
Then I should see the successfull message "Question added successfully.""
And I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."