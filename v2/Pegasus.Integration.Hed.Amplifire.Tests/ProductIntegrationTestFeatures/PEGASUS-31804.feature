Feature: PEGASUS-31804
	Student should be able to launch the Amplifire and Should be able to SSO to Amplifire page.


	Scenario: User Login As CsSMSStudent Navigate To InstructorCourse
	Given I browsed the login url for "CsSmsStudent"
	When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
	Then I should be logged in successfully
	Given I am on the "Global Home" page
	When I enter in the "InstructorCourse" from the Global Home page as "CsSmsStudent"