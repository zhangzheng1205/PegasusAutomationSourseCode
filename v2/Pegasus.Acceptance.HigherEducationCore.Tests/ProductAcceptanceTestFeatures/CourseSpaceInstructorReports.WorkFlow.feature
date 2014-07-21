Feature: CourseSpaceInstructorReports
	                 As a CS Instructor 
					I want to manage all the instructor reports 
					so that I would validate all the instructor report scenarios are working fine.

#Used Instructor Course
#Purpose: View Report in Course Space
@InstrctorReport
Scenario: Generate Activity Results by Student Report by SMS Instructor
When I navigate to "Gradebook" tab and selected "Reports" subtab
Then I should be on the "Gradebook" page
When I generate the "ActivityResultsbyStudent" of student "CsSmsStudent" 
Then I should successfully see the student name and score under launched report

#Used Instructor Course
#Purpose: View Report in Course Space
@StudentResultsbyActivityReport
Scenario: Generate Student Results by Activity Report by SMS Instructor
When I navigate to "Gradebook" tab and selected "Reports" subtab
Then I should be on the "Gradebook" page
When I generate the "StudentResultsbyActivity" of student "CsSmsStudent" 
Then I should successfully see the activity name and score under launched report

#Used Instructor Course
#Purpose: View Study Plan Results Report in HED Course Space
@StudyPlanResultsReport
Scenario: Generate Study Plan Results Report by SMS Instructor
When I navigate to "Gradebook" tab and selected "Reports" subtab
Then I should be on the "Gradebook" page
When I generate the "StudyPlanResults" of student "CsSmsStudent" 
Then I should successfully see the studyplan name, student name and average score under launched report

#Used Instructor Course
#Purpose: Functionality of select activity when the Activity with quote and > symbol in its name (For ex: ada’s > Test) are available in the course
# TestCase Id: HSS_Core_PWF_724
Scenario: Functionality of select activity when the Activity with quote and > symbol in its name are available in the course by SMS Instructor
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I associate the "Test" activity of behavioral mode "BasicRandom" to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"
And I should see "Test" activity of behavioral mode "BasicRandom" in MyCourse Frame
When I click the activity ShowHide cmenu option in MyCourse Frame

#Used Instructor Course
#Purpose: Functionality of select activity when the Activity with Report
# TestCase Id: HSS_Core_PWF_724
Scenario: Functionality of select activity report by SMS Instructor
When I navigate to "Gradebook" tab and selected "Reports" subtab
Then I should be on the "Gradebook" page
When I select the report and click on "Select Activity"
Then I should be on the "Select Activities" page 
And I should see "Test" activity of behavioral mode "BasicRandom"

 