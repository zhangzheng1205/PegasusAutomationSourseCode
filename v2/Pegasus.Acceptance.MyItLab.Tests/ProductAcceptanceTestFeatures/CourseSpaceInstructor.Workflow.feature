Feature: CourseSpaceInstructorViewSubmission
	As a CS Instructor 
					I want to manage all the coursespace instructor workflow related usecases 
					so that I would validate all the coursespace instructor workflow related scenarios are working fine.

#Purpose : Set Time limit for SIM Study Plan Pre test as SMS Instructor
#MyItLabInstructorCourse
Scenario: Set Time limit for SIM Study Plan Pre test as SMS Instructor
When I navigate to "Course Materials" tab and selected "Add from Library" subtab
Then I should be on the "Course Materials" page
And I should see "SIM5StudyPlan" activity in the Content Library Frame
When I click on "Edit" cmenu option of activity in "CsSmsInstructor"
And I edit the "PreTest"
Then I should be on the "Create Pre-test:" page
When I Click on "Preferences" Tab of Edit SIM PreTest
And I enter "02" minute in Set time limit for activity preference
Then I should see the successfull message "Myitlab Study Plan updated successfully."

#Purpose : To Set Feedback Preference for Test with Basic Random Activity By SMS Instructor
# TestCase Id: HED_MIL_PWF_492
#MyItLabInstructorCourse
Scenario: To Set Feedback Preference for Test with Basic Random Activity By SMS Instructor
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
And I should see "Test" activity in the Content Library Frame
When I click on "Edit" cmenu option of activity in "CsSmsInstructor"
And I set the feedback correct answer preference
Then I should see the successfull message "Activity updated successfully."


#Purpose :Instructor assign the asset with duedate in Managecoursework
#TestCase Id: peg-22005
#MyITLabOffice2013SectionCourse
Scenario: Instructor assign the asset with duedate in Managecoursework
When I navigate to "Course Materials" tab and selected "Manage Course Materials" subtab
Then I should be on the "Course Materials" page
When I navigate to "Excel Chapter 1 Project 1A Skill-Based Training" asset in "Course Materials" tab as "CsSmsInstructor"
And I click on "SetSchedulingOptions" option in c menu of "Excel Chapter 1 Project 1A Skill-Based Training" asset
Then I should be on the "Properties" page
When I assign asset with due date and save
Then I should see the successfull message "Properties updated successfully."
And I should see assigned icon for "Excel Chapter 1 Project 1A Skill-Based Training" 
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page

#Purpose : Instructor assign the assets with duedate,startdate and endate in Managecoursework
#TestCase Id: peg-22006
#MyITLabOffice2013SectionCourse
Scenario: Instructor assign the assets with duedate,startdate and endate in Managecoursework
When I navigate to "Course Materials" tab and selected "Manage Course Materials" subtab
Then I should be on the "Course Materials" page
When I navigate to "Excel Chapter 1 Project 1A Skill-Based Training" asset in "Course Materials" tab as "CsSmsInstructor"
When I click on "SetSchedulingOptions" option in c menu of "Excel Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" asset
Then I should be on the "Properties" page
When I assign and schedule the asset and save
Then I should see the successfull message "Properties updated successfully."
And I should see assigned icon for "Excel Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" 
And I should see scheduled icon for "Excel Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" 
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page

#Purpose: : Instructor Validating student grade in view submission
#TestCase Id: peg-22002
#MyItLabProgramCourse
Scenario: Instructor validating the grade of student in view submission page By Instructor 
When I navigate to "Course Materials" tab and selected "Manage Course Materials" subtab
When I select "Word Chapter 1 Grader Project [Assessment 3]" in "Course Materials" by "CsSmsInstructor"
And I click on "ViewSubmissions" option in c menu of "Word Chapter 1 Grader Project [Assessment 3]" asset
Then I should see the "0" score in view submission page for a "ZeroScore" with "CsSmsStudent"
And I close the "View Submission" window
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page

#Purpose: Assign Access Sim5 Activity to past due date
#MyItLabProgramCourse
Scenario:Assign Access Sim5 Activity to past due date
When I navigate to "Course Materials" tab and selected "Manage Course Materials" subtab
Then I should be on the "Course Materials" page
When I navigate to "Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" asset in "Course Materials" tab as "CsSmsInstructor"
And I click on "SetSchedulingOptions" option in c menu of "Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" asset
Then I should be on the "Properties" page
When I assign the asset to with a due date near to past due date
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page



#Purpose: Assign Word Sim5 Activity to past due date
#MyItLabProgramCourse
Scenario:Assign Word Sim5 Activity to past due date
When I navigate to "Course Materials" tab and selected "Manage Course Materials" subtab
Then I should be on the "Course Materials" page
When I navigate to "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" asset in "Course Materials" tab as "CsSmsInstructor"
And I click on "SetSchedulingOptions" option in c menu of "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" asset
Then I should be on the "Properties" page
When I assign the asset to with a due date near to past due date
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page


#Purpose: Assign PowerPoint Sim5 Activity to past due date
#MyItLabProgramCourse
Scenario:Assign PowerPoint Sim5 Activity to past due date
When I navigate to "Course Materials" tab and selected "Manage Course Materials" subtab
Then I should be on the "Course Materials" page
When I navigate to "PowerPoint Chapter 1 Skill-Based Training" asset in "Course Materials" tab as "CsSmsInstructor"
And I click on "SetSchedulingOptions" option in c menu of "PowerPoint Chapter 1 Skill-Based Training" asset
Then I should be on the "Properties" page
And I should unassign the activity and save
When I click on "SetSchedulingOptions" option in c menu of "PowerPoint Chapter 1 Skill-Based Training" asset
And I assign the asset to with a due date near to past due date
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page

#Purpose: Assign Excel Sim5 Activity to past due date
#MyItLabProgramCourse
Scenario:Assign Excel Sim5 Activity to past due date
When I navigate to "Course Materials" tab and selected "Manage Course Materials" subtab
Then I should be on the "Course Materials" page
When I navigate to "Excel Chapter 1 Skill-Based Training" asset in "Course Materials" tab as "CsSmsInstructor"
And I click on "SetSchedulingOptions" option in c menu of "Excel Chapter 1 Skill-Based Training" asset
Then I should be on the "Properties" page
When I assign the asset to with a due date near to past due date

#Purpose: PCT crossover by SMS Instructor
Scenario:SMS Instructor launch PCT link
When I navigate to the "Today's View" tab
Then I should be on the "Today's View" page
When I click on Tools DropDown
And I click "Project Creation Tool" link
Then I should be on the "Project Creation Tool" page
And I should see PCT page loaded sucessfully

#Purpose: CSSMS Instructor setup new PCT word project
Scenario:SMS Instructor setup new PCT word project
When I click on Create link
And I select "Word" project type
And I enter project name of "PCTWordProject"
And I Click on Done button
Then I should be on the "Project Creation Tool" page
When I click on upload icon of "Final Document"
And I upload the file "Final Document Word File"
Then I should see file "final.docx" uploaded sucessfully in "Final Document" frame
When I click on upload icon of "Start Document"
And I upload the file "Start Document Word File"
Then I should see file "initial.docx" uploaded sucessfully in "Start Document" frame
When I click on upload icon of "Instruction Document"
And I upload the file "Instruction Document Word File"
Then I should see file "Instruction.docx" uploaded sucessfully in "Instruction Document" frame
When I map skill "Table Styles" from "TABLE"
And I publish the project in project creation tool page
When I close the "Project Creation Tool" window
Then I should be on the "Today's View" page

#Purpose: CSSMS Instructor setup new PCT excel project
Scenario:SMS Instructor setup new PCT Excel project
When I click on Create link
And I select "Excel" project type
And I enter project name of "PCTExcelProject"
And I Click on Done button
Then I should be on the "Project Creation Tool" page
When I click on upload icon of "Final Document"
And I upload the file "Final Document Excel File"
Then I should see file "excel.xlsx" uploaded sucessfully in "Final Document" frame
When I click on upload icon of "Start Document"
And I upload the file "Start Document Excel File"
Then I should see file "excel.xlsx" uploaded sucessfully in "Start Document" frame
When I click on upload icon of "Instruction Document"
And I upload the file "Instruction Document Excel File"
Then I should see file "Instruction.docx" uploaded sucessfully in "Instruction Document" frame
When I map skill "Excel Options - Advanced" from "FILE"
And I publish the project in project creation tool page
When I close the "Project Creation Tool" window
Then I should be on the "Today's View" page

#Purpose: CSSMS Instructor setup new PCT PPT project
Scenario:SMS Instructor setup new PCT PPT project
When I click on Create link
And I select "PPT" project type
And I enter project name of "PCTPPTProject"
And I Click on Done button
Then I should be on the "Project Creation Tool" page
When I click on upload icon of "Final Document"
And I upload the file "Final Document PPT File"
Then I should see file "testcase.pptx" uploaded sucessfully in "Final Document" frame
When I click on upload icon of "Start Document"
And I upload the file "Start Document PPT File"
Then I should see file "blank.pptx" uploaded sucessfully in "Start Document" frame
When I click on upload icon of "Instruction Document"
And I upload the file "Instruction Document PPT File"
Then I should see file "Instruction.docx" uploaded sucessfully in "Instruction Document" frame
When I map skill "Presentation Properties" from "FILE"
And I publish the project in project creation tool page
When I close the "Project Creation Tool" window
Then I should be on the "Today's View" page

#Purpose: CSSMS Instructor create new GraderIT word question
Scenario:SMS Instructor create new grader word question
When I navigate to the "Course Materials" tab
And I select the "Manage Question Bank" tab
Then I should be on the "Question Bank" page
When I select 'Add Course Materials' option
And I select "Grader Project" option
And I create "SIMGraderQuestion" question with "PCTWordProject" project
When I navigate to the "Today's View" tab
Then I should be on the "Today's View" page

#Purpose: CSSMS Instructor create new GraderIT PPT question
Scenario:SMS Instructor create new grader PPT question
When I navigate to the "Course Materials" tab
And I select the "Manage Question Bank" tab
Then I should be on the "Question Bank" page
When I select 'Add Course Materials' option
And I select "Grader Project" option
And I create "SIMGraderQuestion" question with "PCTPPTProject" project
When I navigate to the "Today's View" tab
Then I should be on the "Today's View" page

#Purpose: CSSMS Instructor create new GraderIT Excel question
Scenario:SMS Instructor create new grader Excel question
When I navigate to the "Course Materials" tab
And I select the "Manage Question Bank" tab
Then I should be on the "Question Bank" page
When I select 'Add Course Materials' option
And I select "Grader Project" option
And I create "SIMGraderQuestion" question with "PCTExcelProject" project
When I navigate to the "Today's View" tab
Then I should be on the "Today's View" page

#Purpose: CSSMS Instructor close PCT tool
Scenario:SMS Instructor close PCT popup
Then I should see the "Project Creation Tool" popup
When I close Project creation tool popup
Then I should be on the "Today's View" page


