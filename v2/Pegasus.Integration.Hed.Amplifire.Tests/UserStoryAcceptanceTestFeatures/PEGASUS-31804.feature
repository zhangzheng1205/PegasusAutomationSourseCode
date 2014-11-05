Feature: PEGASUS-31804
	Student should be able to launch the Amplifire and Should be able to SSO to Amplifire page.

@mytag
Scenario: To launch the Amplifire and to SSO to Amplifire

	Scenario: User Login As CsSMSStudent Navigate To InstructorCourse
	Given I browsed the login url for "CsSmsStudent"
	When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
	Then I should logged in successfully
	Given I am on the "Global Home" page
	When I enter in the "InstructorCourse" from the Global Home page as "CsSmsStudent"
	
	Scenario: Instructor Managecoursework
	When I navigate to "Course Materials" tab and selected "Manage Course Materials" subtab
	Then I should be on the "Course Materials" page
	When I navigate to "Review the Chapter 04 Learning Objectives" asset in "Course Materials" tab as "CsSmsStudent"
	And I select cmenu "open" option of activity "Review the Chapter 04 Learning Objectives"
	Then I should be on the "Pegasus" page
