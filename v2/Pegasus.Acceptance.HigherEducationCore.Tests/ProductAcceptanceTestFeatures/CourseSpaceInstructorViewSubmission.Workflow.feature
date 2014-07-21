Feature: CourseSpaceInstructorViewSubmission
	                As a CS Instructor 
					I want to manage all the coursespace view submission related usecases 
					so that I would validate all the view submission scenarios are working fine.
 
#Used Instructor Course
#Purpose: To edit a grade from the View Submissions window
# TestCase Id: HSS_Core_PWF_681
Scenario: To edit a grade from the View Submissions window by SMS Instructor
When I navigate to "Gradebook" tab and selected "Grades" subtab
Then I should be on the "Gradebook" page
When I click on cmenu "ViewAllSubmissions" of asset "Test" 
And I edit the grade in view submission window
Then I should see the edited grade "33" in view submission page
When I close the "View Submission" window

