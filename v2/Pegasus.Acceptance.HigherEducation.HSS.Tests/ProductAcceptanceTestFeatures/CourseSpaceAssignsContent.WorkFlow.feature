Feature: CourseSpaceAssignsContent
                    As a CS Instructor 
					I want to manage all the coursespace assign content usecases 
					so that I would validate all the assign content scenarios are working fine.

#Purpose :Instructor assign the asset with duedate in Managecoursework
#TestCase Id: peg-22221
#MyPsychLab for Ciccarelli, Psychology, 3/e
Scenario: Instructor assign the asset with duedate in Managecoursework
When I navigate to "Course Materials" tab and selected "Manage Course Materials" subtab
Then I should be on the "Course Materials" page
When I navigate to "Review the Chapter 04 Learning Objectives" asset in "Course Materials" tab as "HSSCsSmsInstructor"
And I click on "Properties" option in c menu of "Review the Chapter 04 Learning Objectives" asset
Then I should be on the "Properties" page
When I assign asset with due date and save
Then I should see the successfull message "Properties updated successfully."
And I should see assigned icon for "Review the Chapter 04 Learning Objectives" 

