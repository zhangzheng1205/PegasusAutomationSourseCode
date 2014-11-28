Feature: CourseSpaceAssignsContent
                    As a CS Instructor 
					I want to manage all the coursespace assign content usecases 
					so that I would validate all the assign content scenarios are working fine.

#Purpose :Instructor assign the asset with duedate in Managecoursework
#TestCase Id: peg-22221
#MyPsychLab for Ciccarelli, Psychology, 3/e
Scenario: Instructor assign the asset with duedate in Managecoursework
Given I browsed the login url for "HSSCsSmsInstructor"
When I logged into the Pegasus as "HSSCsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "HSSMyPsychLabProgram" from the Global Home page as "HSSCsSmsInstructor"
When I navigate to "Course Materials" tab and selected "Manage Course Materials" subtab
Then I should be on the "Course Materials" page
When I select "Review the Chapter 4 Learning Objectives" in "Course Materials" by "HSSCsSmsInstructor"
And I click on "Properties" option in c menu of "Review the Chapter 4 Learning Objectives" asset
Then I should be on the "Properties" page
When I assign asset with due date and save
Then I should see the successfull message "Properties updated successfully."
And I should see assigned icon for "Review the Chapter 4 Learning Objectives" 




#Purpose: To drag and drop a folder in assignment calendar.
#Test case ID : peg-21948.
#MyITLabOffice2013Program
Scenario: Instructor drag and drop a folder in assignment calendar by SMS Instructor
When I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
And I should see "Chapter 1: The Science of Psychology" asset
When I drag and drop the "Chapter 1: The Science of Psychology" folder to the current date


