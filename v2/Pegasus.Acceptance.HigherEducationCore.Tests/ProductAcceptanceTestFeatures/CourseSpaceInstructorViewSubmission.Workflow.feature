Feature: CourseSpaceInstructorViewSubmission
	                As a CS Instructor 
					I want to manage all the coursespace view submission related usecases 
					so that I would validate all the view submission scenarios are working fine.

#Purpose: Login as Cs Instructor
Background:
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page 

#Purpose: To edit a grade from the View Submissions window
# TestCase Id: HSS_Core_PWF_681
Scenario: To edit a grade from the View Submissions window by SMS Instructor
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Calendar" page
When I navigate to the "Gradebook" tab
Then I should be on the "Gradebook" page
When I click on cmenu "ViewAllSubmissions" of asset "Test" 
And I edit the grade in view submission window
Then I should see the edited grade "33" in view submission page
When I close the "View Submission" window

