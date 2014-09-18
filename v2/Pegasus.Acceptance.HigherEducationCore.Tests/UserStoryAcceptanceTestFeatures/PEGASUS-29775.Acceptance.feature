Feature: PEGASUS-29775
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

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


#Purpose: As a Instructor for HED Product  ,i need to make force full submission of saved actviity
# TestCase Id: peg-22229
# HED Core Program Course
# Pre Condition: Activity should be past due and submitted by student
Scenario: Instructor Validating student grade in instructor grade book By SMS Instructor
When I navigate to "Gradebook" tab of the "Gradebook" page
Then I should be on the "Gradebook" page
When I select "Take the Chapter 3 Exam" in "Gradebook" by "CsSmsInstructor"
And I click on cmenu option "ViewAllSubmissions" of asset "Take the Chapter 3 Exam"
Then I should be on the "View Submission" page
Then I should see "Decline" and "Accept" options in view submission page
When I select the option "Accept" in view submission page
Then I should see "32 " score in view submission page
