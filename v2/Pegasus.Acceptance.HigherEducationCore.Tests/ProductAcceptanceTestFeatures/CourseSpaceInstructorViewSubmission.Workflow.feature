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

#Purpose: :Instructor validating the View Submission page of submitted activity
#TestCase Id:
#Pre Condition: Activity should be submitted by the student
Scenario:Instructor verifying the View Submission page of activity in Student Mode
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I select "RegWLSubmissionActivity" in "Gradebook" tab by "CsSmsInstructor" 
And I click on cmenu option "ViewAllSubmissions" of the asset "RegWLSubmissionActivity"
Then I should be on the "View Submission" page
And I should see "RegWLSubmissionActivity" activity name 
And I should see "16.7" score in view submission page for a student "CsSmsStudent"

#Purpose: :Instructor validating the View Submission page of submitted activity
#TestCase Id:
#Pre Condition: Activity should be submitted by the student
Scenario:Instructor verifying the View Submission page of activity in Question Mode
When I navigate to the "Gradebook" tab
Then I should be on the "Gradebook" page
When I select "RegWLSubmissionActivity" in "Gradebook" tab by "CsSmsInstructor" 
And I click on cmenu option "ViewAllSubmissions" of the asset "RegWLSubmissionActivity"
Then I should be on the "View Submission" page
And I should see "RegWLSubmissionActivity" activity name 
When I select "Questions" mode in view submission page
And click on the 'Question 3' in question list 
Then I should see "Question 3" in view submission frame
And I should see "1" score for the question in view submission page for 'Zero' "WLCsSmsStudent"
And I should see "0" score for the question in view submission page for "WLCsSmsStudent"