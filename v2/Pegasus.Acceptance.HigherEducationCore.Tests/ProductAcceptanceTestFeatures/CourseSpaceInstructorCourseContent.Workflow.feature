#Purpose: Feature Description
Feature: CourseSpaceInstructorCourseContent
	                As a CS Instructor 
	                I want to manage all the coursespace coursecontent related usecases 
					so that I would validate all the coursecontent scenarios are working fine.

#Used Instructor Course
#Purpose: Advance Search In 'Course Materails' Tab by CourseSpace Instructor
#Test Case Id : HSS_Core_PWF_220
Scenario: Advance Search In Course Materails Tab by CourseSpace Instructor
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I click on searchview option in "ContentLibrary"
And I search "File" asset in "ContentLibrary"
Then I should see the "File" in 'Course Materials Library'
When I click on searchview option in "ContentLibrary"
And I search "UnavaliableAssetname" asset by advancedsearch option
Then I should see the "There are no matches for your search criteria. Please try again." in 'Course Materials Library' frame

#Used Instructor Course
#Purpose: Advance Search In 'My Course' Tab by CourseSpace Instructor
#Test Case Id : HSS_Core_PWF_220
Scenario: Advance Search In My Course Tab by CourseSpace Instructor
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I click on searchview option in "CourseContent"
And I search "File" asset in "CourseContent"
Then I should see the "File" in 'My Course'
When I click on searchview option in "CourseContent"
And I search "UnavaliableAssetname" asset by advancedsearch option
Then I should see the "There are no matches for your search criteria. Please try again." in 'My Course' frame
