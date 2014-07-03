Feature: CourseSpaceAuthor
	                As a Courspace Author
					I want to manage all the CourseSpace author related usecases 
					so that I would validate all the CourseSpace author scenarios are working fine.


#Purpose: Login as Cs Instructor
Background:
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose: Creation of Basic Random Activity By Cs Instructor
# TestCase Id: HSS_Core_PWF_206 | Story Id: PEGASUS-3338
Scenario: Creation PracticeTest of Basic Random Activity By Cs Instructor
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsInstructor"
And I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Practice Test" activity type
Then I should be on the "Create activity" page
When I create "PracticeTest" activity of behavioral mode "BasicRandom" type
Then I should see the successfull message "Activity added successfully."


#Purpose : Preview The Activity By Cs Instructor
Scenario: Preview The Activity By Cs Instructor
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsInstructor"
And I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
And I should see "Quiz" activity in the Content Library Frame
When I click on "Preview" cmenu option of activity in "CsSmsInstructor"
Then I should be on the "Quiz" page
When I close the "Quiz" window


#Purpose : Creation of Assignment Activity By Cs Instructor
# TestCase Id: HSS_Core_PWF_206 | Story Id: PEGASUS-3338
Scenario: Creation of Assignement Activity By Cs Instructor
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsInstructor"
And I navigate to the "Course Materials" tab
When I click on the 'Add Course Materials' option
And I click on the "Test" activity type
Then I should be on the "Create activity" page
When I create "Test" activity of behavioral mode "Assignment" type
Then I should see the successfull message "Activity added successfully."
And I should see "Test" activity of behaviorla mode "Assignment" in the Content Library Frame
When I click on "Preview" cmenu option of activity in "CsSmsInstructor"
Then I should be on the "Test" page
When I close the "Test" window


