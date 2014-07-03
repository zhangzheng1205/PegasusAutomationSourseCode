#Purpose: Feature Description
Feature:WritingspaceInstructorTodaysView
					As a MMND Instructor
					I want to manage all the MMND instructor todaysview related usecases 
					so that I would validate all the instructor todaysview related scenarios are working fine.

#Purpose: To Verify Display of Writingspace Activity in Today's View
Scenario: Verify display of writingspace assessment in Todays View by MMND Instructor
When I click on "Course Home" subtab
And I click the "Todays_View" link
And I click on 'New Grades' alert option
Then I should not see the "WritingSpace" assessment
When I click on the "Course Performance" option
Then I should not see the "WritingSpace" assessment in course performance channel
When I click on the "Student Performance" option
Then I should not see the "WritingSpace" assessment in student performance channel
