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
Then I should see the "Instructor Grading (1)" channels in 'Todays view' page
And I should see the alert count updated as "1" in "Instructor Grading (1)" channel

#Purpose:Validate the functionality of Tutorials link in Today's View tab
#Test case ID : 
#Products : MyItLab, HSS and World Language.
Scenario: Validate the functionality of Tutorial link in Today's view tab as WLCsSmsInstructor
Given I browsed the login url for "WLCsSmsInstructor"
When I logged into the Pegasus as "WLCsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MySpanishLabProgram" from the Global Home page as "WLCsSmsInstructor"
And I navigate to "Today's View" tab
Then I should be on the "Today's View" page
When I click on "Tutorial" link
Then I should be on the "Tutorials" page
When I close the "Tutorials" window
Then I should be on the "Today's View" page

#Purpose:Validate the functionality of Glossary link in Today's View tab
#Test case ID : 
#Products : MyItLab, HSS and World Language.
Scenario: Validate the functionality of Glossary link in Today's view tab as WLCsSmsInstructor
Given I browsed the login url for "WLCsSmsInstructor"
When I logged into the Pegasus as "WLCsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MySpanishLabProgram" from the Global Home page as "WLCsSmsInstructor"
And I navigate to "Today's View" tab
Then I should be on the "Today's View" page
When I click on "Glossary" link
Then I should be on the "Glossary" page
When I close the "Glossary" window
Then I should be on the "Today's View" page

#Purpose:Validate the functionality of Verb Chart link in Today's View tab
#Test case ID : 
#Products : MyItLab, HSS and World Language.
Scenario: Validate the functionality of Verb Chart link in Today's view tab as WLCsSmsInstructor
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page
When I click on "Verb Chart" link
Then I should be on the "Verb Chart" page
When I close the "Verb Chart" window
Then I should be on the "Today's View" page

#Purpose:Validate the functionality of User Guide link in Today's View tab
#Test case ID : 
#Products : MyItLab, HSS and World Language.
Scenario: Validate the functionality of User Guide link in Today's view tab as WLCsSmsInstructor
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page
When I click on "User Guide" link
Then I should be on the "Instructor User Guide" page  
When I close the "Instructor User Guide" window
Then I should be on the "Today's View" page

#Purpose:Validate the functionality of More Resources  link in Today's View tab
#Test case ID : 
#Products : MyItLab, HSS and World Language.
Scenario: Validate the functionality of More Resources link in Today's view tab as WLCsSmsInstructor
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page
When I click on "More Resources" link
Then I should be on the "More Resources" page 
When I close the "More Resources" window
Then I should be on the "Today's View" page                  