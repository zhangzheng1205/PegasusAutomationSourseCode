Feature: WorkSpaceInstructorCourseContent
	     As a Ws Instructor 
		I want to manage all the workspace Instructor related usecases 
		so that I would validate all the workspace Instructor scenarios are working fine.

Background:
#Purpose: Open Ws Url 
Given I browsed the login url for "HedWsInstructor"
When I logged into the Pegasus as "HedWsInstructor" in "WorkSpace"
Then I should logged in successfully
Given I am on the "Global Home" page



#Purpose: To Create Grader IT Activity with 2010
Scenario: Create Grader IT Activity with 2010
When I enter in the "GraderITSIM5Course" from the Global Home page as "HedWsInstructor"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I select 'Add Course Materials' in 'My Course'
And I click on the "Homework" activity type
Then I should be on the "Create activity" page
When I create "SIMGraderActivity" of grader activity of behavioral mode "Assignment" type using "Personal Finances" project in "contentLibrary"
Then I should see the successfull message "Activity added successfully."
When I associate the "SIMGraderActivity" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"
When I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To Create Grader IT Activity with 2013
Scenario: Create Grader IT Activity with 2013
When I enter in the "GraderITSIM5Course" from the Global Home page as "HedWsInstructor"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I select 'Add Course Materials' in 'My Course'
And I click on the "Homework" activity type
Then I should be on the "Create activity" page
When I create "SIMGraderActivity" of grader activity of behavioral mode "Assignment" type using "Whisenhunt Enterprises" project in "contentLibrary"
Then I should see the successfull message "Activity added successfully."
When I associate the "SIMGraderActivity" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"
When I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."

