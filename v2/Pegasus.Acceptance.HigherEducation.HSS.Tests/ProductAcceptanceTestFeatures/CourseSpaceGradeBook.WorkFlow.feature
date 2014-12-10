Feature: CourseSpaceGradeBook
                     As a CS Instructor 
					I want to manage all the coursespace gradebook related usecases 
					so that I would validate all the gradebook scenarios are working fine.

#Purpose: Instructor Validaing student submission and grade in Instructor Gradebook-HSS
# TestCase Id: peg-22228
#PEGASUS-29776/PEGASUS-29777
# HED Instructor course
# Pre Condition: Activity should be submitted by student
Scenario: Instructor Validating student grade in instructor grade book By SMS Instructor
When I navigate to "Gradebook" tab of the "Gradebook" page
Then I should be on the "Gradebook" page
When I select "Take the Chapter 1 Exam" in "Gradebook" by "HSSCsSmsInstructor"
And I click on cmenu option "ViewAllSubmissions" of asset "Take the Chapter 1 Exam"
Then I should be on the "View Submission" page
And I should see "100" score in view submission page for a student "CsSmsStudent"
Then I should be on the "Gradebook" page
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#Purpose: As a Instructor for HSS Product ,Validating forcefull submission of saved activity
# TestCase Id: peg-22229
#PEGASUS-29775
# HED Instructor course
# Pre Condition: Activity should be past due and submitted by student
Scenario: Instructor Validating forcefull submission of saved activity
When I navigate to "Gradebook" tab of the "Gradebook" page
Then I should be on the "Gradebook" page
When I select "Take the Chapter 3 Exam" in "Gradebook" by "HSSCsSmsInstructor"
And I click on cmenu option "ViewAllSubmissions" of asset "Take the Chapter 3 Exam"
Then I should be on the "View Submission" page
And I should search student "CsSmsStudent" from student frame in view submission page
Then I should see "Decline" and "Accept" options in instructor view submission page
When I select the option "Accept" in view submission page
Then I should see "32" score in view submission page
Then I should be on the "Gradebook" page
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page