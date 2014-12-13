Feature: CourseSpaceToday'sView
	                As a CS Instructor 
					I want to manage all the coursespace Today's View related usecases 
					so that I would validate all the Today's View scenarios are working fine.


#Used Instructor Course
#Purpose: To View Activity Alerts by CS Instructor
@ViewActivityAlert
Scenario: View Activity Alerts by SMS Instructor
When I navigate to "Today's View" page by More option
Then I should successfully see the alert for New Grades
When I click New Grades alert option
Then I should successfully see the submitted activity name

#Used Instructor Course
#Purpose: Sending Messages to Users
#TestCase Id:HSS_PWF_171
Scenario: Sending Mail Message by CS Teacher
When I navigate to "Communicate" tab and selected "Mail" subtab
Then I should be on the "Course Mail" page
When I create a mail by "CsSmsInstructor" for "InstructorCourse"
And I send the created mail to CourseSpace users
Then I should see the successfull message "Your message has been sent." in "Course Mail" window

#Purpose: Instructor should be notified with alert count in "Instructor Grading" channel when student submits Manual Gradable activities
#Test Case Id:peg-16744
#PEGASUS-29247
Scenario: Instructor should be notified with alert count in "Instructor Grading" channel when student submits Manual Gradable activities
Given I browsed the login url for "HSSCsSmsInstructor"
When I logged into the Pegasus as "HSSCsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MySpanishLabProgram" from the Global Home page as "HSSCsSmsInstructor"
Then I should be on the "Today's View" page
Then I should see the "Instructor Grading (1)" channels in 'Todays view' page
And I should see the alert count updated as "1" in "Instructor Grading (1)" channel
When I click on the "Instructor Grading (1)" option
Then I should see the activity "SAM Activity:SAM 01-05 Heritage Language: tu español. [Vocabulario 1. La familia]" in the Instructor grading channel
                                