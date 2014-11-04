Feature: PEGASUS-31804
	Student should be able to launch the Amplifire and Should be able to SSO to Amplifire page.


	Scenario: User Login As CsSMSStudent Navigate To InstructorCourse
	Given I browsed the login url for "CsSmsStudent"
	When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
	Then I should be logged in successfully
	Given I am on the "Global Home" page
	When I enter in the "InstructorCourse" from the Global Home page as "CsSmsStudent"
	Then I should be on the "Today's View" page

	When I navigate to "Course Materials" tab and selected "View All Course Materials" subtab
	Then I should be on the "Course Materials" page
	When I navigate to "Amplifire Study Module 0P: Vocabulario en contexto" asset in "Course Materials" tab as "CsSmsStudent" 
	And I open the "Amplifire Study Module 0P: Vocabulario en contexto" Activity
	Then I should see the activity successfully launched