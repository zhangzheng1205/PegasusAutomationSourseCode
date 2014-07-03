Feature: CourseSpaceInstructorCourseContent
	     As a Cs Instructor 
		I want to manage all the coursespace Instructor related usecases 
		so that I would validate all the coursespace Instructor scenarios are working fine.

Background:
#Purpose: Open Cs Url
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyItLabInstructorCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page

#Purpose: To Create Grader IT Activity with 2010 in coursespace
Scenario: Create Grader IT Activity with 2010 in coursespace
When I click on the 'Add Course Materials' option
And I click on the "Homework" activity type
Then I should be on the "Create activity" page
When I create "SIMGraderActivity" of grader activity of behavioral mode "Assignment" type using "Personal Finances" project in "MyCourse"
Then I should see the successfull message "Activity added successfully."
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To Previews the Grader IT Activity in the my Course tab in coursespace
Scenario: Previews the Grader IT Activity in the my Course tab in coursespace
When I search "SIMGraderActivity" activity of behavioral mode "Assignment" type in Mycourse
And I select the Cmenu option "Preview"
Then I should be on the "Test Presentation" page
When I close the "Test Presentation" window
And I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."

