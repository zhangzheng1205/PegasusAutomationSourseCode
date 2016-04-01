Feature: D2LInstructorAction
	                As a D2L Instructor 
					I want to manage all the usecase in D2L 
					so that I would validate all the D2L integration scenarios are working fine.

#Purpose : D2L instructor login to direct integration
Scenario: D2L Instructor login to D2L portal
Given I browsed the login url for "D2LDirectTeacher"
When I login to D2L as "D2LDirectTeacher"
Then I should be on the "Instructor Dashboard" page
When I enter into D2L direct course "D2LDirectCourse" as "D2LDirectTeacher"
And I navigate to D2L "Content" tab
And I click on "FilePegausMIL" link in Content tab
And I SSO to Pegasus by click on "MyPsychLab Gradebook" link
Then I should be on pegasus "Gradebook" page as "D2LDirectTeacher"

#Purpose : D2L student login to direct integration
Scenario: D2L student login to D2L portal
Given I browsed the login url for "D2LDirectStudent"
When I login to D2L as "D2LDirectStudent"
Then I should be on the "Homepage - HE Brightspace" page
When I enter into D2L direct course "D2LDirectCourse" as "D2LDirectStudent"
And I navigate to D2L "Content" tab
And I click on "FilePegausMIL" link in Content tab
And I SSO to Pegasus by click on "MyPsychLab studentGrades" link
Then I should be on pegasus "Gradebook" page as "D2LDirectStudent"