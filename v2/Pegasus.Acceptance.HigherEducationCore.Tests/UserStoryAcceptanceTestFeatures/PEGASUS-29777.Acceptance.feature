Feature: PEGASUS-29777
Automation : HED BVT: peg-22228:Instructor Validaing student submission and grade in Instructor Gradebook-HSS

#Verify the usecases in Instructor Course
#Purpose:Verify The User Login As CourseSpaceSMSInstructor
Scenario: User Login As CsSMSInstructor
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "ProgramCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Program Administration" page
When I select the "Sections" tab
When I search section of "ProgramCourse"
And I click the "Enter Section as Instructor" option


#Purpose: Instructor Validating student grade in instructor grade book
# TestCase Id: peg-22228
#MyItLabProgramCourse
Scenario: Instructor Validating student grade in instructor grade book By SMS Instructor
When I navigate to "Gradebook" tab of the "Gradebook" page
Then I should be on the "Gradebook" page
When I select "Take the Chapter 1 Exam" in "Gradebook" by "CsSmsInstructor"
And I click on cmenu option "ViewAllSubmissions" of asset "Take the Chapter 1 Exam"
Then I should be on the "View Submission" page
When I am on the "View Submission" page
Then I should see "100" score in view submission page


