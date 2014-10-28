Feature: CourseSpaceGradeBook
	                As a CS Teacher 
					I want to manage all the coursespace gradebook related usecases 
					so that I would validate all the gradebook scenarios are working fine.


#NovaNETMasterLibrary Scenario					 
#Purpose : To View Activity Score by CS Teacher
Scenario: View Activity Score by CS Teacher
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page
And I should see the grade under activity column of the submitted "01:Posttest" activity for "NovaNETCsStudent"

#NovaNETMasterLibrary Scenario
#Purpose : To Verify The Functionality of Edit C-menu Options of Grade book column / Grade cell
#TestCase Id: NN_PWF_456 
Scenario: To Verify The Functionality of Edit C-menu Options of Grade Column by CS Teacher
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page
When I click on cmenu "EditGrades" of asset "NNTest"
And I edit the score in Edit Grade Window
Then I should see the successfull message "Batch update completed successfully.  "Test""

#NovaNETMasterLibrary Scenario
#Purpose : To Verify The Functionality of Apply Grade Schema c-menu options of Grade Column by CS Teacher
#TestCase Id: NN_PWF_457
Scenario: To Verify The Functionality of Apply Grade Schema c-menu options of Grade Column by CS Teacher
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page
When I click on cmenu "ApplyGradeSchema" of asset "NNTest"
And I 'Apply' the grade schema for the submitted activity
Then I should see the successfull message "Schema applied successfully." in "Gradebook" window
And I should see the updated apply grade schema value "B" for Activity "NNTest"

#NovaNETMasterLibrary Scenario
#Purpose :Digital path teacher selects View All Submissions c-menu options of column / Cell in Grade book
#TestCase Id: NN_PWF_460 
Scenario: To Verify The Functionality of View All Submissions c-menu options of Grade Column by CS Teacher
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page
When I click on cmenu "ViewAllSubmissions" of asset "NNTest"
And I edit the grade in view submission window
Then I should see the edited grade "33" in view submission page
When I close the "View Submission" window

#NovaNETMasterLibrary Scenario
#Purpose :Digital path teacher selects Search Student filtering options in grade book 
#TestCase Id: NN_PWF_474 
Scenario: To Verify teacher selects Search Student Filtering Options in GradeBook by CS Teacher
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page
When I click the 'View Filters' link in gradebook

#NovaNETMasterLibrary Scenario
#Purpose :Digital path teacher selects Show Status for all items filtering options in grade book 
#TestCase Id: NN_PWF_475  
Scenario: To Verify teacher selects Show Status for all items Filtering Options in GradeBook by CS Teacher
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page
When I select 'Show Status for All Items' filter option
Then I should see the "NNTest" activity in Gradebook for all the enrollled "NovaNETCsStudent"

#NovaNETMasterLibrary Scenario
#Purpose :Digital path teacher selects Assignment type filtering options in grade book 
#TestCase Id: NN_PWF_477
Scenario: To verify teacher selects Assignment type filtering options in grade book by CS Teacher
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page
When I click on 'Assignment Types' link in gradebook
And I select "Test" Assignment Type
Then I should see the "NNTest" activity in Gradebook

#NovaNETMasterLibrary Scenario
Scenario: To Verify the tab navigation by CS Teacher
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page
When I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
