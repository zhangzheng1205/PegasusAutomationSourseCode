Feature: CourseSpaceStudent Submission
	                 As a CS Student 
					I want to manage all the coursespace student Submission related usecases 
					so that I would validate all the coursespace student Submission scenarios are working fine.

#Purpose: To Submit Sim Activity Inside Instructor Course
#MyItLabInstructorCourse
Scenario: Activity Submission Inside Instructor Course by SMS Student
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page
When I submit the "SIM5Activity" activity of behavioral mode "SkillBased" type
Then I should see the "Passed" status of the "SIM5Activity" activity of behavioral mode "SkillBased" type

# Purpose: SIM study Plan  launch (Skill based) and display of Question status in VS Page
# TestCase ID: HED_MIL_PWF_392
#MyItLabInstructorCourse
Scenario: To Check The Student Launch The SIM study Plan PreTest by SMS Student
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I submit the "SIM5StudyPlan" pretest activity of behavioral mode type "SkillBased"
Then I should see the "In Progress" status of the "SIM5StudyPlan" activity of behavioral mode "SkillBased" type

#Purpose: To check the Student : SIM study Plan  launch (Skill based) and display of Total time taken in VS Page
#TestCase Id: HED_MIL_PWF_393
#MyItLabInstructorCourse
Scenario: To check the Student : SIM study Plan  launch (Skill based) and display of Total time taken in VS Page
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I open the "SIM5StudyPlan" Activity
Then I should be on the "myitlab Study Plan" page
When I click on Start Pre test button of SIM Study Plan by SMS Student
And I Submit the SIM Study Plan "Sim5PreTest"
Then I should see the "In Progress" status of the "SIM5StudyPlan" activity of behavioral mode "SkillBased" type

# Purpose: To check that Student launches the Study materials and submits it
# TestCase ID: HED_MIL_PWF_395
#MyItLabInstructorCourse
Scenario: To Check The Student Launch The SIM study Plan Trainig Material by SMS Student
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I submit the "SIM5StudyPlan" activity of behavioral mode type "SkillBased" using Training Material
Then I should see the "In Progress" status of the "SIM5StudyPlan" activity of behavioral mode "SkillBased" type

#Purpose: Display Grades in Gradebook
#TestCase Id: HED_MIL_PWF_390
#MyItLabInstructorCourse
Scenario: Display Grades in Gradebook
When I navigate to "Grades" tab
Then I should be on the "Gradebook" page
When I click on the "SIM5StudyPlan" 'View Grades' option 
Then I should see the pre test "Sim5PreTest" score "0"
When I click on cmenu "View Submissions" of asset "Sim5PreTest"
Then I should be on the "View Submission" page
And I should the status of submitted SIM5 activity question as "Incomplete"
When I close the "View Submission" window

#Purpose :Display of View Grades for Students (Training materials / Study materials)
#TestCase Id : HED_MIL_PWF_396
#MyItLabInstructorCourse
Scenario: Display of View Grades for Students Training materials
When I navigate to "Grades" tab
Then I should be on the "Gradebook" page
When I click on the "SIM5StudyPlan" 'View Grades' option 
Then I should see the pre test training "Sim5PreTest" score "100"

#Purpose : Student launches a Sim 5 activity for Excel Application. Scores a 100% and compares the result and status
Scenario: Student launches a Sim 5 activity for Excel Application. Scores a 100% and compares the result and status
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select "Excel Chapter 1 Skill-Based Training" in "Course Materials" by "CsSmsStudent"
And I launch the activity named as "Excel Chapter 1 Skill-Based Training" in Course Materials
And I should answer activity "Excel Chapter 1 Skill-Based Training" correctly and click on Submit button
Then I should be on the "Course Materials" page
When I click on cmenu "ViewSubmissions" of asset "Excel Chapter 1 Skill-Based Training" with mode "SkillBased" in Course Materials
Then I should be on the "View Submission" page
When I click on the last submission
Then I should see the grade is "7.41%" in View Submission page
