Feature: CourseSpaceToday'sView
	                As a CS Instructor 
					I want to manage all the coursespace Today's View related usecases 
					so that I would validate all the Today's View scenarios are working fine.



#Purpose: To View Activity Alerts by CS Instructor
@ViewActivityAlert
Scenario: View Activity Alerts by SMS Instructor
Given I am on the "Global Home" page 
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Calendar" page
When I navigate to "Today's View" page by More option
Then I should successfully see the alert for New Grades
When I click New Grades alert option
Then I should successfully see the submitted activity name


#Purpose: Sending Messages to Users
#TestCase Id:HSS_PWF_171
Scenario: Sending Mail Message by CS Teacher
Given I am on the "Global Home" page 
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsInstructor" 
Then I should be on the "Calendar" page
When I navigate to the "Communicate" tab
And I select 'Mail' option
When I create a mail by "CsSmsInstructor" for "InstructorCourse"
And I send the created mail to CourseSpace users
Then I should see the successfull message "Your message has been sent." in "Course Mail" window
