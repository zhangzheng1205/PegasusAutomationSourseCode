Feature: CourseSpaceInstructorContentLibrary
	     As a Cs Instructor 
		I want to manage all the coursespace Instructor related usecases 
		so that I would validate all the coursespace Instructor scenarios are working fine.


Background:
#Purpose: Open CS Url 
Given I browsed the login url for "HedWsInstructor"
When I logged into the Pegasus as "HedWsInstructor" in "WorkSpace"
Then I should logged in successfully

#Purpose: To save an activity in Content Library with HelpLink
Scenario: To save an activity in Content Library with HelpLink
When I enter in the "MyItLabInstructorCourse" from the Global Home page as "HedWsInstructor" 
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option in Content Library
And I click on the "Homework" activity type
Then I should be on the "Create activity" page
When I create "Homework" activity of behavioral mode "BasicRandom" type using True-False question
Then I should see the successfull message "Activity added successfully."
When I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To edit an activity in Content Library and preview the HelpLink
Scenario: To edit an activity in Content Library and preview the HelpLink
When I enter in the "MyItLabInstructorCourse" from the Global Home page as "HedWsInstructor" 
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the Activity Name in Content Library frame
Then I should be on the "Edit Random activity" page
When I click on the HelpLinks activity subtab
Then I should be on the "Edit Random activity" page
When I click on the 'Preview' link in c-menu of Helplink
Then I should be on the "Homework" page
When I close the "Homework" window
Then I should be on the "Edit Random activity" page
When I click on the "Cancel" button
Then I should be on the "Cancel Activity" page
When I click on the "Don't Save" button
Then I should be on the "Course Materials" page