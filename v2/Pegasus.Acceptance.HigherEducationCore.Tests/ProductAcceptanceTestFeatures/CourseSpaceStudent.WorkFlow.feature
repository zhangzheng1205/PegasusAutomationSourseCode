Feature: CourseSpaceStudent
	                 As a CS Student 
					I want to manage all the coursespace student related usecases 
					so that I would validate all the coursespace student scenarios are working fine.

#Used GlobalHome Page
#Purpose: To Enroll student to Section
@EnrollStudentToSection
Scenario: Enroll student to Section by SMS Student
When I enroll SMS Student in "ProgramCourse"
Then I should see enrolled Section in Global Home Page 

#Used GlobalHome Page
#Purpose: To Enroll student to Instructor Course
@EnrollStudentToInsCourse
Scenario: Enroll student to Instructor Course by SMS Student
When I enroll SMS Student in "InstructorCourse"
Then I should see enrolled InstructorCourse in Global Home Page 

#Used Instructor Course
#Purpose : To Lauch Activity by the Student in Cs
@LaunchActivity
Scenario: Launch Activity by SMS Student
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I open the Activity 
Then I should see the activity successfully launched

#Used Instructor Course
#Purpose : To Activity Submission by the Student in Cs
Scenario: Activity Submission by SMS Student
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I open the Activity 
And I submit the activity
Then I should see the activity submitted successfully for grading

#Used Instructor Course
#Purpose : To View Activity Submission by the Student in Cs
@StudentViewSubmission
Scenario: View Activity Submission by SMS Student
When I navigate to "Grades" tab of the "Gradebook" page
Then I should be on the "Gradebook" page
When I navigate inside the activity
Then I should see the grade under grade column of the submitted activity

#Used Instructor Course
#Purpose : To Submit Manually Graded Activity by Student in CS
@ManuallyGradableActivitySubmission
Scenario: Manually Gradable Activity Submission by SMS Student
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I open the "Quiz" Activity
And I submit the 'Manually Gradable' Activity
Then I should see the status of activity as "Submitted"

#Used Instructor Course
#Purpose : To View Grades For Manually Graded Activity by CS Student
Scenario: View Grades For Manually Graded Activity by SMS Student
When I navigate to "Grades" tab of the "Gradebook" page
Then I should be on the "Gradebook" page
When I navigate inside the folder
Then I should see the grades for manually graded activity 

#Used Instructor Course
#Purpose: Display of Course Materials and Activity Name in Grades tab by SMS Student
@StudentGradestab
Scenario: Display of Course Materials and Activity Name in Grades tab by SMS Student
When I navigate to "Grades" tab of the "Gradebook" page
Then I should be on the "Gradebook" page
Then I should see the 'Course Materials' text in grades tab
And I should see the 'Activity' column text in grades tab "AllItems"

#Used Instructor Course
#Purpose: Display of Completed items in Grades Tab By SMS Student
Scenario: Display of Completed items in Grades tab by SMS Student
When I navigate to "Grades" tab of the "Gradebook" page
Then I should be on the "Gradebook" page
When I click on 'Completed items' option in grades tab
Then I should see the 'Activity' column text in grades tab "CompletedItems"

#Used Instructor Course
#Purpose: Display of Assigned items in Grades Tab By SMS Student
Scenario: Display of Assigned items in Grades tab by SMS Student
When I navigate to "Grades" tab of the "Gradebook" page
Then I should be on the "Gradebook" page
When I click on 'Assigned items' option in grades tab
Then I should see the 'Activity' column text in grades tab "AssignedItems"

#Used Instructor Course
#Purpose: Verify  Activity Summary Report through Activity C-menu 'View Report' in Grades Tab By SMS Student
#Testing Course Should contain Assetname as "HomeWork" (with 2 Question and score of "100%(2.0/2.0)" ) 
#in the first row of Student Grade Allitems Activity Grid. 
Scenario: Display of Activity Summary Report in grades tab by SMS Student
When I navigate to "Grades" tab of the "Gradebook" page
Then I should be on the "Gradebook" page
When I click on 'HomeWork' Cmenu option ViewReport in grades tab
Then I should see Activity Summary Report data in Pop up

#Used Instructor Course
#Verify the usecase in InstructorCourse 
#Purpose: Calendar SetUp For Multiple Assets by CS Student
Scenario: :Verify The Assigned Assets by SMS Student
When I navigate to "Assignments" tab and selected "Course Calendar" subtab
Then I should be on the "Course Materials" page
When I click on calendar icon
Then I should see the assigned asset "Quiz"

Scenario: Gradable Activity with Learnosity Audio Question Submission by SMS Student
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsStudent"
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I open the activity with learnosity audio essay question 
And I submit the 'Manually Gradable' Activity with learnosity audio question
Then I should see the status of activity with learnosity audio question as "Submitted"

# To Verify the Tab Navigation By SMS Student
Scenario: To Verify Tab Navigation By SMS Student
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I navigate to "Grades" tab
Then I should be on the "Gradebook" page
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page 

#Purpose: Student submits Essay activity from Course Calendar tab
#peg-22419
#MySpanishLabProgram
Scenario:Student submits Essay activity from Course Calendar tab
When I navigate to "Assignments" tab
Then I should be on the "Course Materials" page
When I select "SAM 01-05 Heritage Language: tu español. [Vocabulario 1. La familia]" in "Course Materials" page by "WlCsSmsStudent"
And I submit the essay activity
Then I should see "Submitted" status for the activity "SAM 01-05 Heritage Language: tu español. [Vocabulario 1. La familia]" in "Course Materials" page by "WlCsSmsStudent"
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page 

#Purpose: Student submits sam activity from Course Calendar tab and score 100
#Test Case Id:peg-22418
#PEGASUS-30113
#MySpanishLabProgram
Scenario: Student submits sam activity from Course Calendar tab and score 100
When I navigate to "Assignments" tab
Then I should be on the "Course Materials" page
When I select "SAM 01-02 Las familias hispanas. [Vocabulario 1. La familia]" in "Course Materials" page by "WLCsSmsStudent"
And I submit the SAM Activity to score '100'
Then I should see "Passed" status for the activity "SAM 01-02 Las familias hispanas. [Vocabulario 1. La familia]" in "Course Materials" page by "WLCsSmsStudent"
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page 

#Purpose:Student submits sam activity from Course Calendar tab and score 0
#Test Case Id:peg-22405
#PEGASUS-30113
#MySpanishLabProgram
Scenario: Student submits sam activity from Course Calendar tab and score 0
When I navigate to "Assignments" tab
Then I should be on the "Course Materials" page
When I select "SAM 01-02 Las familias hispanas. [Vocabulario 1. La familia]" in "Course Materials" page by "WLCsSmsStudent"
And I submit SAM Activity to score '0'
Then I should see "Not passed" status for the activity "SAM 01-02 Las familias hispanas. [Vocabulario 1. La familia]" in "Course Materials" page by "WLCsSmsStudent"
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page 

#Purpose: Student submits Learsonsity activity  from Course Calendar tab
#Test Case Id:peg-22432
#PEGASUS-30115
#MySpanishLabProgram
Scenario: Student submits Learsonsity activity  from Course Calendar tab
When I navigate to "Assignments" tab and selected "Course Calendar" subtab
Then I should be on the "Course Materials" page
When I select "SAM 01-19 Singular y plural." in "Course Materials" page by "WLCsSmsStudent"
And I submit the learnocity activity
Then I should see "Not passed" status for the activity "SAM 01-19 Singular y plural." in "Course Materials" page by "WLCsSmsStudent"

#Purpose: Regression automation for display correct answers after activity is submitted.

Scenario: Student resbumits the activity
When I navigate to "Assignments" tab
Then I should be on the "Course Materials" page
When I select "SAM 01-02 Las familias hispanas. [Vocabulario 1. La familia]" in "Course Materials" page by "WLCsSmsStudent"
And I submit the SAM Activity to score '100'
Then I should see "Passed" status for the activity "SAM 01-02 Las familias hispanas. [Vocabulario 1. La familia]" in "Course Materials" page by "WLCsSmsStudent"
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

Scenario: Student sees correct answers after submission
When I navigate to "Assignments" tab
Then I should be on the "Course Materials" page
When I select "SAM 01-02 Las familias hispanas. [Vocabulario 1. La familia]" in "Course Materials" page by "WLCsSmsStudent"
And I submit the SAM Activity to score and to see correct answers
Then I should see "Passed" status for the activity "SAM 01-02 Las familias hispanas. [Vocabulario 1. La familia]" in "Course Materials" page by "WLCsSmsStudent"

#Purpose:Coursespace SMS student launch newly authored activity RegCSSAMActivity
Scenario: Coursespace SMS student launch RegCSSAMActivity from Course Materials page
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I click on "Open" of  "RegChildActivity" Activity in "Course Materials" page

#Purpose:To Verify Presentation window, when "Allow student to Save for Later" option is selected
Scenario:To Verify Presentation window of RegCSSAMActivity when Allow student to Save for Later option is selected
Given I am on "RegCSSAMActivity" window
When I click on "Start" Button
Then I should the availibility of Save For Later is "true" in "RegCSSAMActivity" Activity Presentation Window
When I attempt "2" questions listed in Page "1" of "RegCSSAMActivity" Activity Presentation Window with "In Valid" answer
And I navigate to next page
Then I Verify Confirmation Message on Save the Activity for later

#Purpose:To verify Display of Direction Lines when “Enable activity-level direction lines” enabled
#Purpose:To Verify Display Direction Lines on Each Page option is selected 
#Purpose:To verify Display of Direction Lines when “ Enable activity section-level direction lines ” enabled
#Purpose:To verify section level direction lines
#Test Link ID:peg-8557
Scenario:Verify Activity and Section Direction Lines of RegCSSAMActivity
When I open the "RegChildActivity" Activity
Then I am on "RegCSSAMActivity" window
When I click on "Start" Button
Then I should see the availibility "Direction lines (instructions)" at Page is "True"
And I should see the Section Direction lines for Section "1"

Scenario:Student submit the RegCSSAMActivity activity with incorrect answer and fails
Then I should see "2" questions answers saved in Page "1" of "RegCSSAMActivity" Activity Presentation Window
When I navigate to next page
And I attempt "1" questions listed in Page "2" of "RegCSSAMActivity" Activity Presentation Window with "In Valid" answer
When I navigate to next page
And I attempt "1" questions listed in Page "3" of "RegCSSAMActivity" Activity Presentation Window with "Valid" answer
When I submit the answered activity "RegCSSAMActivity"

Scenario: Student resubmit the assessment RegCSSAMActivity by click on try again and secure 100 percent
Given I am on "RegCSSAMActivity" window
When I click on "Try Again" button of "RegCSSAMActivity" 
When I attempt "2" questions listed in Page "1" of "RegCSSAMActivity" Activity Presentation Window with "Valid" answer
When I navigate to next page
And I attempt "1" questions listed in Page "2" of "RegCSSAMActivity" Activity Presentation Window with "Valid" answer
When I navigate to next page
And I attempt "1" questions listed in Page "3" of "RegCSSAMActivity" Activity Presentation Window with "Valid" answer
When I submit the answered activity "RegCSSAMActivity" 

Scenario:Student verify feedback status in presenation window of RegCSSAMActivity
Then I should be displayed with Feedback Icon in "RegCSSAMActivity" window
When I click on the Feedback Icon in "RegCSSAMActivity" window
Then I should displayed with "Correct Feedback" text in "RegCSSAMActivity" window

Scenario:Student verify activity RegCSSAMActivity status as pass for correct submission
When I click on "Return to Course" button in "RegCSSAMActivity" window
Then I should be on the "Course Materials" page
And I should see "Passed" status for the activity "RegChildActivity" from "Course Materials" page