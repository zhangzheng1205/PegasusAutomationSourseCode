Feature: CommonUserScenarios
	            As a User
				I want to manage all the MyItLab User related usecases 
				so that I would validate all the MyItLab scenarios are working fine.


Scenario: User Login as PPEStudent in HedMil
Given I browsed the login url for "HedMilPPEStudent"
When I logged into the Pegasus as "HedMilPPEStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "HedMyItLabPPECourse" from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
When I navigate to the "Assignments" tab
Then I should be on the "Assignments - To Do" page
