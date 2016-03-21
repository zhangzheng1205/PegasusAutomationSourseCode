Feature: eCollegeCourseAction
	

#Feature: Instructor navigating to Pegasus course link in eCollege home Page
Scenario: eCollege Instructor selecting a Academics PSH link in home Page
Given I am on the home PSH of eCollege
When I select "Academics PSH" link
Then I should see "Academics PSH" Page contents

Scenario: eCollege Instructor selecting a Pegasus link in Academics PSH
#Given I am on the home PSH of eCollege
When I select "MIL Course" Pegasus course
Then I should see "MIL Course" contents

Scenario: eCollege Instructor selecting a Pegasus Grades
When I select "Grades" of Pegasus course
Then I should see Pegasus "Gradebook"

Scenario: eCollege Instructor searching Pegasus activity
When I search "Access Chapter 1 Grader Project [Assessment 3]" of Pegasus course
Then I should see "Access Chapter 1 Grader Project [Assessment 3]" in Gradebook

Scenario: eCollege Instructor editing score of Pegasus activity
When instructor sets score for "Access Chapter 1 Grader Project [Assessment 3]" activity for "ECollegeStudent"
Then I should see edited score for "Access Chapter 1 Grader Project [Assessment 3]" in Gradebook for "ECollegeStudent"

Scenario: eCollege Instructor closing Pegasus Page
When instructor closes "Gradebook" page
Then I should not see "Gradebook" page opened

Scenario: eCollege Instructor validating GradeSynch in Academics PSH
Given I am on the "DotNextLaunch" page of eCollege
When I select "Gradebook" of eCollege
Then I should see grade synch for student "ECollegeStudent"

Scenario: eCollege Student selecting a Pegasus link in Academics PSH
#Given I am on the home PSH of eCollege
When I select "MIL Course" Pegasus course
Then I should see StudentGrades in "MIL Course" contents

Scenario: eCollege student selecting a Pegasus Grades
When student select "StudentGrades" of Pegasus course
Then I should see Pegasus "Gradebook"

#Purpose : Submitting GraderIT Access activity and Student scoring a 100%.
#Test case ID : peg-22016.
#Products : MyItLab.
#Pre condition : This test case depends on Grader IT activity should be created by instructor/Author.
#Dependency : Always dependent.
Scenario: eCollege Student GraderIT Access Activity and student scoring 100%
When I navigate to "Course Materials" tab
And I select "Access Chapter 1 Grader Project [Assessment 3]" in "Course Materials" by "ECollegeStudent"
And I open the activity named as "Access Chapter 1 Grader Project [Assessment 3]"
Then I should see a "Test Presentation" pop up displayed with "Download Files" button and "Upload Completed File" button
When I click on Download Files button on Test Presentation pop up
And I click on download icon of "go_a01_grader_a3_Open_Houses.accdb"
And I click on Close and Return button
Then I should see a "Test Presentation" pop up displayed with "Download Files" button and "Upload Completed File" button
When I click on Upload Completed File button on Test Presentation pop up
And I upload the downloaded file "Grader Access file for 100%"
Then I should see message "Your completed file has been successfully uploaded." on "Test Presentation" popup page
When I submit "Access Chapter 1 Grader Project [Assessment 3]" activity
Then I should see message "Your file, go_a01_grader_a3_Open_Houses.accdb, has been successfully received by myitlab:grader." on "Test Feedback" popup page
When I click on Return To Course button
Then I should be on the "Course Materials" page
When I select "Access Chapter 1 Grader Project [Assessment 3]" in "Course Materials" by "ECollegeStudent"
Then I should see a "Passed" status for the activity "Access Chapter 1 Grader Project [Assessment 3]" in "Course Materials" by "ECollegeStudent" 
And I should see "100%" score for the activity "Access Chapter 1 Grader Project [Assessment 3]" in course material page

Scenario: eCollege Student closing Pegasus Page
When instructor closes "Course Materials" page
Then I should not see "Course Materials" page opened

Scenario: eCollege Student validating GradeSynch in Academics PSH
Given I am on the "DotNextLaunch" page of eCollege
When I select "Gradebook" of eCollege
Then I should see 100 grades for student "ECollegeStudent"