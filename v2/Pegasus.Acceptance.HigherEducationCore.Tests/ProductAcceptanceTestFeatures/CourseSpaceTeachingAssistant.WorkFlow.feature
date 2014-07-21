Feature: CourseSpaceTeachingAssistant
					As a CS Teacher Assistant
					I want to manage all the coursespace Teacher Assistant related usecases 
					so that I would validate all the coursespace Teacher Assistant scenarios are working fine.


#Used Instructor Course
#Purpose: To verify behavior and usage of the global link - Support for TA Instructor
# TestCase Id: HSS_Core_PWF_046 | Story Id: PEGASUS-3330
Scenario: To Verify Behavior And Usage Of The Global Link Support By TA Instructor
When I navigate to "Assignment Calendar" tab of the "Calendar" page
Then I should be on the "Calendar" page
When I click the 'Support' link by "HedTeacherAssistant" in global homepage 
Then I should see the user name of "HedTeacherAssistant" in popup

#Used Instructor Course
#Purpose: Switching the role to student from instructor using student view option
# TestCase Id: HSS_Core_PWF_052 | Story Id: PEGASUS-3318
Scenario: To Verify The Go to Student View Button Functionality By TA Instructor
When I navigate to "Assignment Calendar" tab of the "Calendar" page
Then I should be on the "Calendar" page
When I select the "Go to Student View" link in Global Home page
Then I should be on the "Today's View" page
And I should see the following tabs
| TabName                  | WindowTitle      |
| Course Materials         | Course Materials |
| Assignments              | Course Materials |
| Communicate              | Communicate      |
| Grades                   | Gradebook        |

#Used Instructor Course
#Purpose: To Verify Enabled Permissions by Teaching Assistant
# TestCase Id: HSS_Core_PWF_138
Scenario: To Verify Enabled Permissions By TA Instructor
When I navigate to "Gradebook" tab and selected "Reports" subtab
Then I should be on the "Reports" page
And I should see enabled permission preferences in reports tab
When I navigate to the "Course Materials" tab
Then I should see "Show/Hide" option of content in Mycourse

#Used GlobalHome PAge
#Purpose: Accessibility of SMS Courses which are having same start date and end date by SMS TA
# TestCase Id: HSS_Core_PWF_366
Scenario: Accessibility of SMS Courses which are having same start date and end date by SMS TA Instructor
Then I should see enrolled Section in Global Home Page 


