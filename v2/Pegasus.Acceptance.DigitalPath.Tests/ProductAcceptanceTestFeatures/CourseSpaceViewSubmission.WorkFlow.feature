Feature: CourseSpaceViewSubmission
	                As a CS Student 
					I want to manage all the coursespace student view submission related usecases 
					so that I would validate all the view submission scenarios are working fine.

#Purpose: Display of StudyPlan Grades in View Submission Page by student   
Scenario: Display of StudyPlan Grade in View Submission Page by CS Student
When I navigate to the "Grades" tab
And I click on the "StudyPlan" cmenu option
Then I should see the 'Grade' in View Submission page

#Purpose: Display of Test Grades in View Submission Page by student 
Scenario: Display of Test Grade in View Submission Page by CS Student
When I navigate to the "Grades" tab
And I click on the "Test" cmenu option
Then I should see the 'Grade' in View Submission page

#Purpose: Display of StudyPlan Grades in Grades Tab by student 
Scenario: Display of StudyPlan Grade in Grades Tab by CS Student
When I navigate to the "Grades" tab
And I open the activity named as "StudyPlan" in Grades Tab
Then I should see the "StudyPlan" for 'Grade' in GradeBook tab

#Purpose: Display of Test Grades in Grades Tab by student 
Scenario: Display of Test Grade in Grades Tab by CS Student
When I navigate to the "Grades" tab
And I check the "Test" in Grades Tab
Then I should see the "Test" for 'Grade' in GradeBook tab


#Purpose : Math XL study plan submission and student scoring 0% in pre test.
#Test case ID : peg-22597
#Products : MGM
#Pre condition : Math XL study plan should be assigned by teacher in the course.
#Dependency : Following script can ne execute only in MGM/Digits product with Master course Id : WS601249 and course name: Digits - Grade 6
Scenario: Math XL study plan submission and student scoring 0% in pre test
When I navigate to the "To Do" tab
Then I should see "Topic 1 Test with Study Plan" displayed under "To Do" tab
When I click on "Start" button next to the asset "Topic 1 Test with Study Plan"
Then I should see study plan page "Open Study Plan" will be opened with "Topic 1 Test" pre test /Study Material frame
When I click on "Begin" button under pre test frame
Then I should see alert message "You can only try this activity once. After you complete the activity, your score is recorded and sent to your teacher." with "Continue" and "Cancel" button
When I click on "Continue" button in activity alert pop up 
Then I should see pre test presentation page "Take a Test - Student Stu" should be displayed
When I answer all the questions incorrectly for activity "Topic 1 Test with Study Plan" to score "0%"
Then I should see "Test Summary" page should be displayed with score and for each question along with button "Close"
When I click on "Close" button in "Test Summary" page
Then I should see control navigate to study plan page and pre test score should be displayed as “0%” under pre test frame
When I click on "Return to Course" button in study plan page


#Purpose : Math XL LLC activity and student scoring 0%.
#Test case ID : peg-22576
#Products : MGM
#Pre condition : Math XL LLC should be assigned by teacher in the course.
#Dependency : Following script can ne execute only in MGM/Digits product with Master course Id : WS601249 and course name: Digits - Grade 6
Scenario: Math XL LLC activity and student scoring 0%
When I navigate to the "To Do" tab
Then I should see "1-1 Homework" displayed under "To Do" tab
When I click on "Start" button next to the asset "1-1 Homework"
Then I should see pre test presentation page "Do Homework - Student Stu" should be displayed
When I answer all the questions incorrectly for activity "1-1 Homework" to score "0%"
Then I should see submitted activity "1-1 Homework" should be displayed in "Assignments - To Do" Tab as “0.00%” score and status "I'm Done" with "Try Again" button


#Purpose : Math XL Practice set activity and student scoring 0%.
#Test case ID : peg-22559
#Products : MGM
#Pre condition : Math XL Practice set activity should be assigned by teacher in the course.
#Dependency : Following script can ne execute only in MGM/Digits product with Master course Id : WS601249 and course name: Digits - Grade 6
Scenario: Math XL Practice set activity and student scoring 0%
When I navigate to the "To Do" tab
Then I should see "i1-1 Practice" displayed under "To Do" tab
When I click on "Start" button next to the asset "i1-1 Practice"
Then I should see pre test presentation page "Do Practice Set" should be displayed
When I answer all the questions incorrectly for activity "i1-1 Practice" to score "0%"
Then I should see submitted activity "i1-1 Practice" should be displayed in "Assignments - To Do" Tab as “0.00%” score and status "I'm Done" with "Try Again" button

#Purpose : As a Student, I should be able to view and validate the grades(70%) in Gradebook for submitted MathXL Homework activity.
#Test case ID : peg-12986.
#Products : MGM Grade 6.
#Pre condition : Student should have submitted the activity with 70% score.
#Dependency : One time dependent(This scenario can be run against existing data).
Scenario: Student validating score in grade book for Math XL Homework activities
Given I browsed the login url for "DPCsStudent"
When I login to Pegasus as "DPCsStudent" in "CourseSpace"
Then I should be logged in successfully
When I navigate to the "Overview" tab
Then I should be on the "Overview" page
Then I should see the "DigitalPathMasterLibrary" class present in the overview tab
When I navigate to the "Grades" tab
Then I should be on the "Gradebook" page
When I click on cmenu option "View Submissions" of asset "1-2 Mixed Review"
Then I should see the "View Submission" popup
And I should see "70" score in view submission page
When I close the "View Submission" window
Then I should be on the "Gradebook" page

#Purpose : As a Student, I should be able to view and validate the grades(70%) in Gradebook for submitted MathXL study plan.
#Test case ID : peg-22612.
#Products : MGM Grade 6.
#Pre condition : Student should have submitted the activity with 70% score.
#Dependency : One time dependent(This scenario can be run against existing data).
Scenario: Student validating score in grade book for Math XL study plan
Given I browsed the login url for "DPCsStudent"
When I login to Pegasus as "DPCsStudent" in "CourseSpace"
Then I should be logged in successfully
When I navigate to the "Overview" tab
Then I should be on the "Overview" page
Then I should see the "DigitalPathMasterLibrary" class present in the overview tab
When I navigate to the "Grades" tab
Then I should be on the "Gradebook" page
When I click on View Grades button of asset "Topic 1 Test with Study Plan"
And I click on cmenu option "View Submissions" of asset "Topic 1 Test - Pre-Test"
Then I should see the "View Submission" popup
And I should see "43" score in view submission page
When I close the "View Submission" window
Then I should be on the "Gradebook" page
