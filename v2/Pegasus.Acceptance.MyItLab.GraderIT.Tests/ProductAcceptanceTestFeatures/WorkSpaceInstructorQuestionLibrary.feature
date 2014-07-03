Feature: WorkSpaceAuthor
	                As a WorkSpace Autohor
					I want to manage all the workspace author related usecases 
					so that I would validate all the workspace author scenarios are working fine.


#Purpose: Open Ws Url and login as WsTeacher
Background:
#Purpose: Open Ws Url 
Given I browsed the login url for "HedWsInstructor"
When I logged into the Pegasus as "HedWsInstructor" in "WorkSpace"
Then I should logged in successfully
Given I am on the "Global Home" page


#Purpose: To create the GradeIT Question (2010) And validate all the c-menu option
Scenario: Create the GradeIT Question (2010) And validate all the c-menu option
When I enter in the "GraderITSIM5Course" from the Global Home page as "HedWsInstructor"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
And I select the "Manage Question Bank" tab
Then I should be on the "Question Bank" page
When I select 'Add Course Materials' option
And I select "Grader Project" option
And I create "SIMGraderQuestion" grader IT Question using "Personal Finances" project 
Then I should see the successfull message "Question added successfully.""
When I click on "Tryout" cmenu option of "SIMGraderQuestion" question in manage question bank
Then I should be on the "Test Presentation" page
When I close the "Test Presentation" window
And I click on "Edit" cmenu option of "SIMGraderQuestion" question in manage question bank
Then I should be on the edit page
When I click on "Delete" cmenu option of "SIMGraderQuestion" question in manage question bank
Then I should be on the "Pegasus" page
When I close the "Pegasus" window
And I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."



#Purpose: To create the GradeIT Question (2013) And validate all the c-menu option
Scenario: Create the GradeIT Question (2013) And validate all the c-menu option
When I enter in the "GraderITSIM5Course" from the Global Home page as "HedWsInstructor"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
And I select the "Manage Question Bank" tab
Then I should be on the "Question Bank" page
When I select 'Add Course Materials' option
And I select "Grader Project" option
And I create "SIMGraderQuestion" grader IT Question using "Whisenhunt Enterprises" project 
Then I should see the successfull message "Question added successfully.""
When I click on "Tryout" cmenu option of "SIMGraderQuestion" question in manage question bank
Then I should be on the "Test Presentation" page
When I close the "Test Presentation" window
And I click on "Edit" cmenu option of "SIMGraderQuestion" question in manage question bank
Then I should be on the edit page
When I click on "Delete" cmenu option of "SIMGraderQuestion" question in manage question bank
Then I should be on the "Pegasus" page
When I close the "Pegasus" window
And I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."


#Purpose:Delete Context menu option for Grader IT Project
Scenario: Delete Context menu option for Grader IT Project
When I enter in the "GraderITSIM5Course" from the Global Home page as "HedWsInstructor"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
And I select the "Manage Question Bank" tab
And I click on "Delete" cmenu option of "SIMGraderQuestion" question in manage question bank
Then I should be on the "Pegasus" page
When I click on the alert OK button
Then I should see the successfull message "Assets deleted successfully.""
When I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Access point(From Question Libarary, And Create Activity) already covered in following scenarios
# To create the GradeIT Question (2013) And validate all the c-menu option
# To Create Grader IT Activity with 2013
#Purpose: Grader IT questions creation from all access point
Scenario: Grader IT questions creation from all access point
When I enter in the "GraderITSIM5Course" from the Global Home page as "HedWsInstructor"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
And I select the "Map Learning Objectives to Questions" tab
Then I should be on the "Question Bank" page
When I select 'Add Course Materials' option
And I select "Grader Project" option
And I create "SIMGraderQuestion" grader IT Question using "Whisenhunt Enterprises" project 
Then I should see "SIMGraderQuestion" in the Map Learning Objectives in Questions tab
When I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."


