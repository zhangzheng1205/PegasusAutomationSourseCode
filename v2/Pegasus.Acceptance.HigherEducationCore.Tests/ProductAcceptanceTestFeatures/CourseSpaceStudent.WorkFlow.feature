Feature: CourseSpaceStudent
	                 As a CS Student 
					I want to manage all the coursespace student related usecases 
					so that I would validate all the coursespace student scenarios are working fine.

#Purpose: Open Student Url
Background: 
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose: To Enroll student to Section
@EnrollStudentToSection
Scenario: Enroll student to Section by SMS Student
When I enroll SMS Student in "ProgramCourse"
Then I should see enrolled Section in Global Home Page 
Then I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To Enroll student to Instructor Course
@EnrollStudentToInsCourse
Scenario: Enroll student to Instructor Course by SMS Student
When I enroll SMS Student in "InstructorCourse"
Then I should see enrolled InstructorCourse in Global Home Page 
Then I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : To Lauch Activity by the Student in Cs
@LaunchActivity
Scenario: Launch Activity by SMS Student
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
And  I open the Activity 
Then I should see the activity successfully launched
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : To Activity Submission by the Student in Cs
Scenario: Activity Submission by SMS Student
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
And  I open the Activity 
And I submit the activity
Then I should see the activity submitted successfully for grading
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : To View Activity Submission by the Student in Cs
@StudentViewSubmission
Scenario: View Activity Submission by SMS Student
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
And I navigate to the "Grades" tab
And I navigate inside the activity
Then I should see the grade under grade column of the submitted activity
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : To Submit Manually Graded Activity by Student in CS
@ManuallyGradableActivitySubmission
Scenario: Manually Gradable Activity Submission by SMS Student
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
And I open the "Quiz" Activity
And I submit the 'Manually Gradable' Activity
Then I should see the status of activity as "Submitted"
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : To View Grades For Manually Graded Activity by CS Student
Scenario: View Grades For Manually Graded Activity by SMS Student
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
And I navigate to the "Grades" tab
When I navigate inside the folder
Then I should see the grades for manually graded activity 
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Display of Course Materials and Activity Name in Grades tab by SMS Student
@StudentGradestab
Scenario: Display of Course Materials and Activity Name in Grades tab by SMS Student
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Grades" tab
Then I should see the 'Course Materials' text in grades tab
And I should see the 'Activity' column text in grades tab "AllItems"
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Display of Completed items in Grades Tab By SMS Student
Scenario: Display of Completed items in Grades tab by SMS Student
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Grades" tab
And I click on 'Completed items' option in grades tab
Then I should see the 'Activity' column text in grades tab "CompletedItems"
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Display of Assigned items in Grades Tab By SMS Student
Scenario: Display of Assigned items in Grades tab by SMS Student
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Grades" tab
And I click on 'Assigned items' option in grades tab
Then I should see the 'Activity' column text in grades tab "AssignedItems"
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Verify  Activity Summary Report through Activity C-menu 'View Report' in Grades Tab By SMS Student
#Testing Course Should contain Assetname as "HomeWork" (with 2 Question and score of "100%(2.0/2.0)" ) 
#in the first row of Student Grade Allitems Activity Grid. 
Scenario: Display of Activity Summary Report in grades tab by SMS Student
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Grades" tab
And I click on 'HomeWork' Cmenu option ViewReport in grades tab
Then I should see Activity Summary Report data in Pop up  
When I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."

 
