Feature: BlackboardInstructorCourseAction
	                As a BB Instructor 
					I want to manage all the Blackboard course management usecases 
					so that I would validate all the course mana scenarios are working fine.

#Purpose:Blackboard Instructors Selects Course
Scenario: Blackboard Instructors Selects Course
Given I am on the "My Institution" page of Blackboard
When I Select PegasusCourse link
Then I should see "Content" links for Pegasus

#Purpose:Blackboard Instructors Selects Pegasus Course Links
Scenario: Blackboard Instructors Selects Pegasus Course Links
#Given I am on the "My Institution" page of Blackboard
When I Select "Content" links for Pegasus
Then I should see "Gradebook" link for Pegasus

#Purpose:Blackboard Instructors Search activity
Scenario: Blackboard Instructors Search activity
Given I am on the "Gradebook" page of Pegasus
When I search "Access Chapter 1 Grader Project [Assessment 3]" of Pegasus course
Then I should see "Access Chapter 1 Grader Project [Assessment 3]" in Gradebook

#Purpose:Blackboard Instructor editing score of Pegasus activity
Scenario: Blackboard Instructor editing score of Pegasus activity
When instructor sets score for "Access Chapter 1 Grader Project [Assessment 3]" activity for "BBStudent1"
Then I should see edited score for "Access Chapter 1 Grader Project [Assessment 3]" in Gradebook for "BBStudent1"

#Purpose:Blackboard Instructor closing Pegasus Page
Scenario: Blackboard Instructor closing Pegasus Page
When instructor closes "Gradebook" page
Then I should not see "Gradebook" page opened

#Purpose:Blackboard Instructor accessing GradeCenter
Scenario: Blackboard Instructor accessing GradeCenter
Given I am on the "Content" page of blackboard
When I select "Grade Center" of Blackboard
Then I should see "Full Grade Center" link

#Purpose : Blackboard Instructor validate startsync and stop sync option functionality
Scenario: Blackboard Instructor validate startsync and stop sync
When I select the cmenu "StopLMSSynchronization" of asset "GO! Excel Chapter 1 Skill-Based Exam (Scenario 1)"
Then I should see the successfull message "LMS Synchronization is stopped" in "Gradebook" window
When I select the cmenu "SynchronizewithLMS" of asset "GO! Excel Chapter 1 Skill-Based Exam (Scenario 1)"
Then I should see the successfull message "LMS Synchronization is enabled" in "Gradebook" window

#Purpose : Blackboard Instructor edit grade in gradebook in Pegasus
#MyItLabInstructorCourse
Scenario: Blackboard instructor Edit Grade in Pegasus
When I enter into blackboard course "BBCourse"
Then I should be displayed with "Home Page"
When I click on the "Content" link at "Home Page" 
And I click on the "Gradebook" link at "Content"
Then I should be on the "Gradebook" page
When I select "1 New Grade Act" in "Gradebook" by "CsSmsInstructor"
When I select the cmenu "ViewAllSubmissions" of asset "1 New Grade Act"
And I click on Edit Grade "PegasusEditedGrade" of "BBEditActivity" activity for "BBStudent" in Pegasus
Then I should see the score "PegasusEditedGradePerc" of "1 New Grade Act" activity for "BBStudent" in Pegasus
When I "Close" from the "BBInstructor"
And I click on the "Grade Center" link at "Content"
And I click on the "Full Grade Center" link at "Content" 
Then I refresh and see "PegasusEditedGrade" for "1 New Grade Act" activity for "BBStudent" in BlackBoard at "Grade Center"
When I "Logout" of Blackboard as "BBInstructor"

#Purpose : Blackbord student submit the activity
Scenario: BBStudent submit activity
When I enter into blackboard course "BBCourse"
Then I should be displayed with "Home Page"
When I click on the "Content" link at "Home Page"
And I click on the "Grades" link at "Content"
When I navigate to "Course Materials" tab
And I select "1 New Grade Act" in "Course Materials" by "CsSmsStudent"
And I open the activity named as "1 New Grade Act"
Then I am on "BBGradeSynchActivity" window
When I attempt the questions in activity
Then I should successfully submit activity for grading
Then I should see a "Passed" status for the activity "1 New Grade Act" in "Course Materials" by "CsSmsStudent" 
And I should see "PegasusNewGradePerc" score "PegasusNewGrade" for the activity "1 New Grade Act" in course material page in Pegasus
When I "Close" from the "BBStudent"
And I logout of Pegasus

#Purpose : Blackboard instructor validate the newly submited grades in Pegasus
Scenario: BBInstructor validate new activity submission in Pegasus
Given I browsed the URL of "BBInstructor"
When I login to Blackboard Cert as "BBInstructor"
Then I should be logged in successfully as "BBInstructor"
When I enter into blackboard course "BBCourse"
Then I should be displayed with "Home Page"
When I click on the "Content" link at "Home Page"
And I click on the "Gradebook" link at "Content"
Then I should be on the "Gradebook" page
When I select "1 New Grade Act" in "Gradebook" by "CsSmsInstructor"
Then I should see GBSync icon for "1 New Grade Act" activity
And I should see the score "PegasusNewGradePerc" of "1 New Grade Act" activity for "BBStudent" in Pegasus
When I "Close" from the "BBInstructor"

#Purpose : Blackboard instructor validate the sync grades in Pegasus
Scenario: BBInstructor validate newly sync grades in Blackboard
When I click on the "Grade Center" link at "Content"
And I click on the "Full Grade Center" link at "Content" 
Then I refresh and see "PegasusNewGrade" for "1 New Grade Act" activity for "BBStudent" in BlackBoard at "Grade Center"

#Purpose:To Delete All Submissions for BBStudent
Scenario:Delete All Submissions for BBStudent
Given I browsed the URL of "BBInstructor"
When I login to Blackboard Cert as "BBInstructor"
Then I should be logged in successfully as "BBInstructor"
When I enter into blackboard course "BBCourse"
Then I should be displayed with "Home Page"
When I click on the "Content" link at "Home Page"
And I click on the "Gradebook" link at "Content"
Then I should be on the "Gradebook" page
When I select "1 New Grade Act" in "Gradebook" by "CsSmsInstructor"
And I select the cmenu "ViewAllSubmissions" of asset "1 New Grade Act"
And I perform Delete All Submission "BBStudent" for the activity
When I "Close" from the "BBInstructor" 
