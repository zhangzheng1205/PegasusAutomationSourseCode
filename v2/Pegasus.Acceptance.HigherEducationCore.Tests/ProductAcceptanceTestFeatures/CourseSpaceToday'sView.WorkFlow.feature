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
#MySpanishLabProgram
Scenario: Instructor should be notified with alert count in "Instructor Grading" channel when student submits Manual Gradable activities
Then I should see the "Unread Comments (1)" channels in 'Todays view' page
And I should see the alert count updated as "1" in "Unread Comments (1)" channel

                                