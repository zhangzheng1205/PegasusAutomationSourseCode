#Purpose: Feature Description
Feature: CourseSpaceInstructorCourseContent
	                As a CS Instructor 
	                I want to manage all the coursespace coursecontent related usecases 
					so that I would validate all the coursecontent scenarios are working fine.

#Purpose: Login as Cs Instructor
Background:
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully

#Purpose: Advance Search In 'Course Materails' Tab by CourseSpace Instructor
#Test Case Id : HSS_Core_PWF_220
Scenario: Advance Search In Course Materails Tab by CourseSpace Instructor
Given I am on the "Global Home" page
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Calendar" page
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on searchview option in "ContentLibrary"
And I search "File" asset in "ContentLibrary"
Then I should see the "File" in 'Course Materials Library'
When I click on searchview option in "ContentLibrary"
And I search "UnavaliableAssetname" asset by advancedsearch option
Then I should see the "There are no matches for your search criteria. Please try again." in 'Course Materials Library' frame


#Purpose: Advance Search In 'My Course' Tab by CourseSpace Instructor
#Test Case Id : HSS_Core_PWF_220
Scenario: Advance Search In My Course Tab by CourseSpace Instructor
Given I am on the "Global Home" page
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Calendar" page
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on searchview option in "CourseContent"
And I search "File" asset in "CourseContent"
Then I should see the "File" in 'My Course'
When I click on searchview option in "CourseContent"
And I search "UnavaliableAssetname" asset by advancedsearch option
Then I should see the "There are no matches for your search criteria. Please try again." in 'My Course' frame
