Feature: PEGASUS-8167: Launch eText in Section Course by Student
	      As a CS Student
		  I want to lanuch etext inside section course
		  so that I would validate launching of eText is working fine.
		  
Background:
#Purpose: Open Ws Url 
Given I browsed the login url for "CsSmsStudent"
When I login to Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should be logged in successfully

#Launch eText in Section Course By SMS Student
Scenario:Launch eText in Section Course By SMS Student
Given I am on the "Global Home" page 
When I enter in the "ProgramCourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
And  I open the "eText" Activity 
Then I should see the 'etext' launched successfully
When I close etext "Pearson eText" presentation window
And I "Sign out" from the "CsSmsStudent"
Then I should see the successfull message "You have been signed out of the application."
