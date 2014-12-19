Feature: CourseSpaceStudentTodaysView
	                As a CS Student 
					I want to manage all the coursespace student Today's View related usecases 
					so that I would validate all the coursespace student scenarios are working fine.


#Used Instructor Course
#Purpose: To lookup the obtained grades in student side
# TestCase Id: HSS_Core_PWF_410
Scenario: To lookup the obtained grades By SMS Student
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I open the "Test" Activity
And I submit the activity in course material


#Used Instructor Course
#Purpose: To lookup the obtained grades in student side
# TestCase Id: HSS_Core_PWF_410
Scenario: To Verify The New Grades By SMS Student
When I navigate to "Today's View" tab of the "Today's View" page
Then I should be on the "Today's View" page
And I should successfully see the alert for New Grades
When I click New Grades alert option
Then I should see the successfully submitted "Test" activity name
When I click the cmenu option 'ViewAllSubmissions' in student side
Then I should see the grade "100" in view submission page
When I close the "View Submission" window

#Used Instructor Course
#Usecase To View and Read Mail Message
#TestCase Id: HSS_Core_PWF_171
Scenario: View Mail Message by Cs Student
When I navigate to "Communicate" tab and selected "Mail" subtab
Then I should be on the "Course Mail" page
And I should see the mail message sent by "CsSmsInstructor" 


#Used MySpanishLabAuthored Course
#Usecase To Student views Alert in "Instructor Comments" channel of Todays View page
#TestCase Id: peg-21980
Scenario: Student views Alert in Instructor Comments channel by Cs Student
Then I should be on the "Today's View" page
Then I should see the "Instructor Comments (2)" channels in 'Todays view' page
And I should see the alert count updated as "2" in "Instructor Comments (2)" channel
When I click on the "Instructor Comments" option
Then I should see the activity "SAM Activity : SAM 01-19 Singular y plural. [Gramática 3. Sustantivos singulares y plurales] Voice Recording." in the Instructor Comments channel
And I should see the activity "SAM Activity : SAM 01-05 Heritage Language: tu español. [Vocabulario 1. La familia]" in the Instructor Comments channel

#Purpose : Display of "Getting Started" channel in Overview tab for Student
#Test case ID : peg-16754
#Products : World Languages - MySpanishLab Authored Course
#Pre condition : Getting started channel should be enabled
#Dependency : Testcase can run with existing data
Scenario: Availability and display of Getting started in Overview tab for Student
Then I should be on the "Today's View" page
And I should see the "Getting Started" channel
And I should see the "Click on the icons below & follow the on-screen instructions for the best course experience!" inside the Getting started channel

#Purpose: Student views Alert update in "Instructor Comments" channel of Todays View page
#TestCase Id: peg-16751
#US:PEGASUS-29237
Scenario: Student views Alert update in "Instructor Comments" channel of Todays View page
When I navigate to "Todays view" tab
Then I should see the "Instructor Comments (1)" channels in 'Todays view' page
And I should see the alert count updated as "1" in "Instructor Comments (1)" channel
When I click on the "Instructor Comments" option
Then I should see the activity "SAM Activity : SAM 01-05 Heritage Language: tu español. [Vocabulario 1. La familia]" in the Instructor Comments channel
When I click on "View All Submissions" of the activity "SAM Activity : SAM 01-05 Heritage Language: tu español. [Vocabulario 1. La familia]"
And I Click on "Mark as Read" button displayed in the right frame
Then I should see the alert count updated as "0" in "Instructor Comments (0)" channel
