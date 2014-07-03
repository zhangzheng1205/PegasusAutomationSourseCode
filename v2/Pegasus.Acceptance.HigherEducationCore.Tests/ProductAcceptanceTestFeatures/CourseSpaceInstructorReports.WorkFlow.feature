Feature: CourseSpaceInstructorReports
	                 As a CS Instructor 
					I want to manage all the instructor reports 
					so that I would validate all the instructor report scenarios are working fine.

#Purpose: Login as Cs Instructor
Background:
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully

#Purpose: View Report in Course Space
@InstrctorReport
Scenario: Generate Activity Results by Student Report by SMS Instructor
Given I am on the "Global Home" page
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsInstructor"
And I navigate to the "Gradebook" tab
And I navigate to the "Reports" tab
When I generate the "ActivityResultsbyStudent" of student "CsSmsStudent" 
Then I should successfully see the student name and score under launched report
Then I "Sign out" from the "CsSmsInstructor"

#Purpose: View Report in Course Space
@StudentResultsbyActivityReport
Scenario: Generate Student Results by Activity Report by SMS Instructor
Given I am on the "Global Home" page
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsInstructor"
And I navigate to the "Gradebook" tab
And I navigate to the "Reports" tab
When I generate the "StudentResultsbyActivity" of student "CsSmsStudent" 
Then I should successfully see the activity name and score under launched report
Then I "Sign out" from the "CsSmsInstructor"

#Purpose: Functionality of select activity when the Activity with quote and > symbol in its name (For ex: ada’s > Test) are available in the course
# TestCase Id: HSS_Core_PWF_724
Scenario: Functionality of select activity when the Activity with quote and > symbol in its name are available in the course by SMS Instructor
Given I am on the "Global Home" page
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsInstructor"
And I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I associate the "Test" activity of behavioral mode "BasicRandom" to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"
And I should see "Test" activity of behavioral mode "BasicRandom" in MyCourse Frame
When I click the activity ShowHide cmenu option in MyCourse Frame
And I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
And I click on "Test" activity of behavioral mode "BasicRandom"
And I submit the "Test" activity
Then I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsInstructor"
And I navigate to the "Gradebook" tab
And I navigate to the "Reports" tab
And I select the report and click on "Select Activity"
Then I should be on the "Select Activities" page 
And I should see "Test" activity of behavioral mode "BasicRandom"
And I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

 