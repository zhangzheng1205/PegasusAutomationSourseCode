Feature: CourseSpaceInstructor
	                As a CS Instructor 
					I want to manage all the coursespace instructor related usecases 
					so that I would validate all the coursespace instructor scenarios are working fine.

#Verify in global home
#Purpose: Create Instructor course through catalog by CS instructor
@InsCourse
Scenario: Add Instructor Course From Catalog by SMS Instructor
When I add Product Course type "MySpanishLabMaster" course from Search Catalog
Then I should see "InstructorCourse" on the Global Home page

#Verify in global home
Scenario: Validate Instructor Course To Get Out From Assigned To Copy State
When I select course to validate Inactive State to Active State on Global Home page
Then I should see "InstructorCourse" on the Global Home page in Active State

#Verify in global home
#Purpose: Create Program type course through catalog by CS instructor
@ProgramCreation
Scenario: Add Program Course From Catalog by SMS Instructor
When I add Product type "HedCoreProgram" from Search Catalog
Then I should see "ProgramCourse" on the Global Home page

#Verify the usecase in ProgramCourse
#Purpose: To Create Template
Scenario: Create Template by Program Admin
When I navigate to "Templates" tab of the "Program Administration" page
Then I should be on the "Program Administration" page
When I create Template using "MySpanishLabMaster" course as a program admin

#Verify the usecase in ProgramCourse
#Purpose: Validate Template to get out from the assigned to copy state
Scenario: Validate Template To Get Out From Assigned To Copy State
When I navigate to "Templates" tab of the "Program Administration" page
Then I should be on the "Program Administration" page
When I verify the "MySpanishLabMaster" course Template for AssignedToCopy state
Then I should see the "MySpanishLabMaster" course Template to be successfully out of AssignedToCopy state

#Verify the usecase in ProgramCourse
#Purpose: To Create Section
Scenario: Create Section by Program Admin
When I navigate to "Sections" tab of the "Program Administration" page
Then I should be on the "Program Administration" page
When I click on Add Sections link from the Program Administration page
And I create Section from "MySpanishLabMaster" Template as a Program Admin

#Verify the usecase in ProgramCourse
#Purpose: Validate Section to get out from the assigned to copy state
Scenario: Validate Section To Get Out From Assigned To Copy State
When I navigate to "Sections" tab of the "Program Administration" page
Then I should be on the "Program Administration" page
When I verify the Section created from "ProgramCourse" course Template for AssignedToCopy state
Then I should see the Section created from "ProgramCourse" course Template to be successfully out of AssignedToCopy state

#Verify the usecase in ProgramCourse
#Purpose: To verify Enrolled SMSstudent present in Users Tab
@ViewStudent
Scenario: View Enrolled Student In Section in Users Tab by Program Admin
When I navigate to "Users" tab of the "Program Administration" page
Then I should be on the "Program Administration" page
And I should see enrolled "CsSmsStudent"

#Verify the usecase in ProgramCourse
#Purpose: To Enroll SmsStudent to Section from Enrollment Tab
@ManualEnrollStudent
Scenario: Manually Enroll Student to Section from Enrollment Tab by Program Admin
When I navigate to "Enrollments" tab of the "Program Administration" page
Then I should be on the "Program Administration" page
When I search the "CsSmsStudent" in the Users frame
Then I should see the searched "CsSmsStudent" in the Users frame
When I Select the searched User in the Users frame
And I search the Section2 in the Sections frame
Then I should see the searched section in section frame
When I entered into the searched section
And I Enroll user to section using "Add as Student" option

#Verify the usecase in InstructorCourse
#Purpose: To verify the tab navigation inside the course
# TestCase Id: HSS_Core_PWF_055| Story Id: PEGASUS-3332
Scenario: Enabled tabs display and their accessibility in pegasus course by SMS Instructor
When I navigate to "MyTest" tab of the "MyTest" page
Then I should be on the "MyTest" page
When I navigate to the "Course Materials" tab
Then I should see the following subtabs under Course Materials page
| SubtabName                           | WindowTitle      |
| Add from Library                     | Course Materials |
| Manage Course Materials              | Course Materials |
| Map Learning Objectives              | Course Materials |
| Manage Question Bank                 | Question Bank    |
When I navigate to the "Gradebook" tab
Then I should see the following subtabs under Gradebook page
| SubtabName      | WindowTitle      |
| Grades           | Gradebook        |
| Custom View      | Custom View      |
| Reports		   | Reports          |
When I navigate to the "Enrollments" tab
Then I should see the following subtabs in Enrollments page
| SubtabName      | WindowTitle |
| Manage Groups    | Enrollments |
When I navigate to the "Communicate" tab
Then I should be on the "Communicate" page
When I navigate to the "Today's View" tab
Then I should be on the "Today's View" page
When I navigate to the "Preferences" tab
Then I should be on the "Preferences" page

#Verify the usecase in InstructorCourse
#Purpose: Switching the role to student from instructor using student view option
# TestCase Id: HSS_Core_PWF_052 | Story Id: PEGASUS-3318
Scenario: To Verify The Go to Student View Button Functionality By SMS Instructor
When I navigate to "Today's View" tab of the "Today's View" page
Then I should be on the "Today's View" page
When I select the "Go to Student View" link in Global Home page
And I navigate to "Today's View" tab of the "Today's View" page
Then I should be on the "Today's View" page
And I should see the following tabs
| TabName                  | WindowTitle      |
| Course Materials         | Course Materials |
| Assignments              | Course Materials |
| Communicate              | Communicate      |
| Grades                   | Gradebook        |

