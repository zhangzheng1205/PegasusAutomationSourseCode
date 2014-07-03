Feature: WSInstructorCourseContent
	            As a MMND Instructor 
				I want to manage all the MMND Instructor Course Content related usecases 
				so that I would validate all the MMND Instructor Course Content scenarios are working fine.


#Purpose: Verify The Display Of Writingspace Activity Type in Course Materials
Scenario: Verify The Display Of Writingspace Activity Type in Course Materials by MMND Instructor
When I click on "Course Home" subtab
And I click the "Add_Content_from_Library" link
And I search the "WritingSpace" Activity in "ContentLibrary"
Then I should see the "There are no matches for your search criteria. Please try again." message in "ContentLibrary"
When I click on the 'Add Course Materials' button in "ContentLibrary"
Then I should not see the "Writing Space Assessment"
When I search the "WritingSpace" Activity in "CourseContent"
Then I should see the "There are no matches for your search criteria. Please try again." message in "CourseContent"
When I click on the 'Add Course Materials' button in "CourseContent"
Then I should not see the "Writing Space Assessment"
