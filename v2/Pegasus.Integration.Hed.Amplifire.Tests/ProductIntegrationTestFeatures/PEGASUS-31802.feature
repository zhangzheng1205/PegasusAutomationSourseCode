#Verify the global home page usecases
#Purpose:Verify The User Login As CourseSpaceSMSInstructor
Scenario: User Login As CsSMSInstructor
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should be logged in successfully
Given I am on the "Global Home" page


#Purpose :Instructor assign the asset with duedate in Managecoursework
#TestCase Id: peg-22221
#MyPsychLab for Ciccarelli, Psychology, 3/e
Scenario: Instructor Managecoursework
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsInstructor"
When I navigate to "Course Materials" tab and selected "Add from Library" subtab
Then I should be on the "Course Materials" page
And I should see "Amplifier link 1(Content)" activity in the MyCourse
When I click the activity cmenu option in MyCourse Frame
When I click on "Open" cmenu option
Then I should be on the "Pegasus" page
