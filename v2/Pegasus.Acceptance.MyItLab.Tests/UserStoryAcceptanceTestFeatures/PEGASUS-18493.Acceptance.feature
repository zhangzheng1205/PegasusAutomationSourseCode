Feature: PEGASUS-18493 Launch SIM5 Assessment and Record Time Taken
						As a Hed Mil Student
						I want to calculate time taken to launch SIM5 test
						so that I can get the accurate time to launch SIM5 test.


#Purpose : To Launch SIM5 Assessment and Record Time Taken
Scenario: Calculate the transaction timings for SIM5 Assessment Launch by single user
Given I browsed the login url for "HedMilPPEStudent"
When I logged into the Pegasus as "HedMilPPEStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "HedMyItLabPPECourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Assignments" tab
Then I should be on the "Assignments - To Do" page
When I open "SIM5 60 Questions WORD Assessment 1" activity
And I launch SIM5 "60" questions in "SIM5 60 Questions WORD Assessment 1" activity
When I open "SIM5 60 Questions EXCEL Assessment 1" activity
And I launch SIM5 "60" questions in "SIM5 60 Questions EXCEL Assessment 1" activity
When I open "SIM5 60 Questions PPT Assessment 1" activity
And I launch SIM5 "60" questions in "SIM5 60 Questions PPT Assessment 1" activity
When I open "SIM5 60 Questions ACCESS Assessment 1" activity
And I launch SIM5 "60" questions in "SIM5 60 Questions ACCESS Assessment 1" activity

 


