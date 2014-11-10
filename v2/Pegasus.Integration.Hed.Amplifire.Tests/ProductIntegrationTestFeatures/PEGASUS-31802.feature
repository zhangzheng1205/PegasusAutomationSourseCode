Feature: PEGASUS-31802
	Teacher should be able to launch the Amplifire and Should be able to SSO to Amplifire page.




#PEGASUS-31802 Automation : HED BVT : peg-16872:Teacher should be able to launch the Amplifire and Should be able to SSO to Amplifire page.
Scenario:Launch amplifier and SSO to amplifier page as SMS Instructor
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsInstructor"
When I navigate to "Course Materials" tab and selected "Add from Library" subtab
Then I should be on the "Course Materials" page
And I should see "Amplifier link 1(Content)" activity in the MyCourse
When I click the activity cmenu option in MyCourse Frame
When I click on "Open" cmenu option
Then I should be on the "Pegasus" page
