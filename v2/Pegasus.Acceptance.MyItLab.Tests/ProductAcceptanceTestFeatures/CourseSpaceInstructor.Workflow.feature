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




#------------------------------------ Assessment------------------------------------------------------------------------------
Scenario:Creation of Random activity of RegCSSAMActivity type by adding section with multiple questions in Coursespace test
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyItLabInstructorCourse" course from the Global Home page as "CsSmsInstructor"
When I click on "Add from Library" subtab in "Course Materials" tab as "CsSmsInstructor" user
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "RegCSSAMActivity" SAM activity type
Then I should be on the "Create activity" page
When I Create "RegChildActivity" activity with Behavioral Mode "Basic Random"
And I perform "Save and Continue" for "Activity Details"
And I perform "Create New Section" of name "Section1"
And I perform "Create New Section" of name "Section2"
And I perform "Create New Section" of name "Section3"
Then I add '3' questions of type "Fill in the Blank" at Section "1"
And I add '1' questions of type "Fill in the Blank" at Section "2"
And I add '1' questions of type "Fill in the Blank" at Section "3"
#Purpose:Clicking on Add link of "Direction Lines" under each section
#Test Link id:peg-19554
#Scenario:Add Section Direction Lines
When I "Add" Directions at Section "1"
Then I should see Directions "added" to Section "1"
When I "Add" Directions at Section "2"
Then I should see Directions "added" to Section "2"
When I "Edit" Directions at Section "2"
Then I should see Directions "edited" to Section "2"
When I "Delete" Directions at Section "2"
Then I should see Directions deleted at Section "2"
When I "Add" Directions at Section "3"
Then I should see Directions "added" to Section "3"
When I perform "Save and Continue" for "Questions" 
#Purpose:Add messages at activity level
#Test Link No:peg-20713
#Scenario:Add messages at activity level
When I perform "Navigate" for "Messages" 
Then I add "Beginning of activity" message
And  I add "Direction lines (instructions)" message
And I add "End of activity" message
When I perform "Save and Continue" for "Messages" 


#------------------------------Save and Continue from various tabs in Activity Creation Wizard-----------------------
Scenario: Save and Continue from Activity Details tab
When I perform "Save and Continue" for "Activity Details"
Then I should be on the "Create Random Activity" page

Scenario: Save and Continue from Questions tab
When I perform "Save and Continue" for "Questions"
Then I should be on the "Create Random Activity" page

Scenario: Save and Continue from Help Links tab
When I perform "Save and Continue" for "HelpLinks"
Then I should be on the "Create Random Activity" page

Scenario: Save and Continue from Messages tab
When I perform "Save and Continue" for "Messages"
Then I should be on the "Create Random Activity" page

Scenario: Save and Continue from Grades tab
When I perform "Save and Continue" for "Grades"
Then I should be on the "Create Random Activity" page

Scenario: Save and Continue from Teaching Support tab
When I perform "Save and Continue" for "Teaching Support"
Then I should be on the "Create Random Activity" page

Scenario: Instructor configore HelpLink and Grades preference for random activity
When I configure the 'Grades' preference
And I add 'HelpLinks'

#------------------------------------------------------------------------------------------------------------------------------------#
							#Creating New folder in Course Materials tab and Creating Assets inside the new folder#
#------------------------------------------------------------------------------------------------------------------------------------#
#Purpose: Creating new folder in Course materials tab
#MyItLabProgramCourse
#Testcase ID: 
Scenario: Instructor creates new folder in Course Materials tab
When I click on "Manage Course Materials" subtab in "Course Materials" tab as "CsSmsInstructor" user
Then I should be on the "Course Materials" page
And I should be on "Course Materials Wizard" lightbox
When I click on "Return to Course Materials" button in 'Course Materials Wizard' lightbox
And I click on 'Folder' option
And I create "RegFolderAsset" activity
When I click on "Return to Course Materials" button in 'Course Materials Wizard' lightbox
Then I should be displayed with "RegFolderAsset" in 'Manage Course Materials' frame

#Purpose: Creating Link asset inside new folder in Course materials tab
#MyItLabProgramCourse
#Testcase ID: 
Scenario: Instructor creating Link asset inside a folder
When I enter into "RegFolderAsset" folder
When I click on 'Materials' option
And I click on the "Add Link" asset type
Then I should be on "Add Link" lightbox
When I create "RegLinkAsset" activity
Then I should be displayed with "RegLinkAsset" in 'Manage Course Materials' frame

#Purpose: Creating Page asset inside new folder in Course materials tab
#MyItLabProgramCourse
#Testcase ID: 
Scenario: Instructor creating Page asset inside a folder
#When I enter into "RegFolderAsset" folder
When I click on 'Materials' option
And I click on the "Add Page" asset type
Then I should be on "Add Page" lightbox
When I create "RegPageAsset" activity
#And I click on "Return to Course Materials" button in 'Add from Library' lightbox
Then I should be displayed with "RegPageAsset" in 'Manage Course Materials' frame

#Purpose: Creating e-Text link inside new folder in Course materials tab
#MyItLabProgramCourse
#Testcase ID: 
Scenario: Instructor creating e-Text Link asset inside a folder
When I click on 'Materials' option
And I click on the "Add eText Link" asset type
Then I should be on "Add eText Link" lightbox
When I create "RegEtextLinkAsset" activity
When I enter into "RegFolderAsset" folder
Then I should be displayed with "RegEtextLinkAsset" in 'Manage Course Materials' frame

#Purpose: Creating Discussion Topic inside new folder in Course materials tab
#MyItLabProgramCourse
#Testcase ID: 
Scenario: Instructor creating Discussion Topic asset inside a folder
When I click on 'Materials' option
And I click on the "Add Discussion Topic" asset type
Then I should be on "Add Discussion Topic" lightbox
When I create "RegDiscussionTopic" activity
And I click on "Manage Course Materials" subtab in "Course Materials" tab as "CsSmsInstructor" user
And I enter into "RegFolderAsset" folder
Then I should be displayed with "RegDiscussionTopic" in 'Manage Course Materials' frame

#Purpose: Re-order the assets inside new folder in Course materials tab
#MyItLabProgramCourse
#Testcase ID:
Scenario: Reorder the assets inside the folder in Course materials tab
When I click on "Manage Course Materials" subtab in "Course Materials" tab as "CsSmsInstructor" user
Then I should be on the "Course Materials" page
Then I should be on "Course Materials Wizard" lightbox
When I click on "Return to Course Materials" button in 'Course Materials Wizard' lightbox
Then I should be displayed with "RegFolderAsset" in 'Manage Course Materials' frame
When I enter into "RegFolderAsset" folder
And I reorder "RegLinkAsset"

#Purpose: Preview the Link asset inside new folder in Course materials tab
#MyItLabProgramCourse
#Testcase ID:
Scenario: Preview the assets in folder
When I click on "Manage Course Materials" subtab in "Course Materials" tab as "CsSmsInstructor" user
Then I should be on the "Course Materials" page
Then I should be on "Course Materials Wizard" lightbox
When I click on "Return to Course Materials" button in 'Course Materials Wizard' lightbox
Then I should be displayed with "RegFolderAsset" in 'Manage Course Materials' frame
When I enter into "RegFolderAsset" folder
And I click on "Preview" cmenu option of "RegLinkAsset" asset

#-----------------------------------------------------------------------------------------------------------------------------
										#Show/Hide asset in Course Materials#
#-----------------------------------------------------------------------------------------------------------------------------
#Purpose: Show/Hide the assets inside new folder in Course materials tab
#MyItLabProgramCourse
#Testcase ID:
Scenario: Search asset in CourseMaterials and Show/Hide as CsSmsInstructor
When I click "Show" of "RegLinkAsset" in "Course Materials" tab
Then I should see "RegLinkAsset" with "Show" status


#Purpose: Show/Hide the assets inside new folder in Course materials tab
#MyItLabProgramCourse
#Testcase ID:
Scenario: Show the folder asset in Course Materials
When I click on "Manage Course Materials" subtab in "Course Materials" tab as "CsSmsInstructor" user
Then I should be on the "Course Materials" page
When I click on "Return to Course Materials" button in 'Course Materials Wizard' lightbox
Then I should be displayed with "RegFolderAsset" in 'Manage Course Materials' frame
When I click "Show" of "RegFolderAsset" in "Course Materials" tab
Then I should see "RegFolderAsset" with "Show" status

#Purpose: Show/Hide the assets inside new folder in Course materials tab
#MyItLabProgramCourse
#Testcase ID:
Scenario: Show the study plan asset in Course Materials
Then I should be displayed with "SIM5StudyPlan" in 'Manage Course Materials' frame
When I click "Show" of "SIM5StudyPlan" in "Course Materials" tab
Then I should see "SIM5StudyPlan" with "Show" status

#-----------------------------------------------------------------------------------------------------------------------------
										#Copy paste asset in Course Materials#
#-----------------------------------------------------------------------------------------------------------------------------
#Purpose: Copy the asset inside new folder in Course materials tab
#MyItLabProgramCourse
#Testcase ID:
Scenario: Search asset in CourseMaterials and Copy paste as CsSmsInstructor
When I click on "Manage Course Materials" subtab in "Course Materials" tab as "CsSmsInstructor" user
Then I should be on the "Course Materials" page
And I should be on "Course Materials Wizard" lightbox
When I click on "Return to Course Materials" button in 'Course Materials Wizard' lightbox
When I enter into "RegFolderAsset" folder
Then I should be displayed with "RegPageAsset" in Manage Course Materials frame of "Course Materials" tab
When I click 'Copy' of "RegPageAsset" in "Course Materials" tab
Then I should be displayed with count "1" in Paste button
When I click on 'Paste' button and I select "Paste at Bottom" option

#-----------------------------------------------------------------------------------------------------------------------------
										#Assign asset using Assign/Unassign option in Course Materials#
#-----------------------------------------------------------------------------------------------------------------------------
#Purpose: Assign the asset using Assign link inside new folder in Course materials tab
#MyItLabProgramCourse
#Testcase ID:
Scenario: Search asset in CourseMaterials and Assign as CsSmsInstructor
#When I click on "Manage Course Materials" subtab in "Course Materials" tab as "CsSmsInstructor" user
#Then I should be on the "Course Materials" page
#And I should be on "Add from Library" lightbox
#When I click on "Return to Course Materials" button in 'Course Materials Wizard' lightbox
#When I enter into "RegFolderAsset" folder
#Then I should be displayed with "RegLinkAsset" in Manage Course Materials frame of "Course Materials" tab
When I click on 'Assign' button for "RegLinkAsset" in "Course Materials" tab
Then I should see "Assigned" status for "RegLinkAsset" in "Course Materials" tab

#--------------------------------------------------------------------------------------------------------------------------
										#Delete asset using Delete option in Course Materials#
#--------------------------------------------------------------------------------------------------------------------------
#Purpose: Delete the asset using Delete option inside new folder in Course materials tab
#MyItLabProgramCourse
#Testcase ID:
Scenario: Delete asset using Delete option in Course Materials as CsSmsInstructor
When I click on "Manage Course Materials" subtab in "Course Materials" tab as "CsSmsInstructor" user
Then I should be on the "Course Materials" page
Then I should be on "Course Materials Wizard" lightbox
When I click on "Return to Course Materials" button in 'Course Materials Wizard' lightbox
Then I should be displayed with "RegFolderAsset" in 'Manage Course Materials' frame
When I enter into "RegFolderAsset" folder
Then I should be displayed with "RegPageAsset" in Manage Course Materials frame of "Course Materials" tab
When I click on 'Delete' button for "RegPageAsset" in "Course Materials" tab
Then I should see "Items deleted successfully." message in "Course Materials" page

#--------------------------------------------------------------------------------------------------------------------------
										#Add notes in Course Materials#
#--------------------------------------------------------------------------------------------------------------------------
#Purpose: Add note in CourseMaterials as CsSmsInstructor
#MyItLabProgramCourse
#Testcase ID:
Scenario: Add note in CourseMaterials as CsSmsInstructor
When I click on "Manage Course Materials" subtab in "Course Materials" tab as "CsSmsInstructor" user
Then I should be on the "Course Materials" page
Then I should be on "Course Materials Wizard" lightbox
When I click on "Return to Course Materials" button in 'Course Materials Wizard' lightbox
Then I should be displayed with "RegFolderAsset" in 'Manage Course Materials' frame
When I click on 'Note' icon in "Course Materials" page
Then I should be on "Note" lightbox
When I click on 'Edit' button

#--------------------------------------------------------------------------------------------------------------------------
										#Create Pre Test,Post Test and Study Plan#
#--------------------------------------------------------------------------------------------------------------------------
#Purpose: Create Pre Test,Post Test and Study Plan inside new folder in Course materials tab
#MyItLabProgramCourse
#Testcase ID:
Scenario: Instructor create studyplan in course materials
When I click on 'Materials' option
And I click on the "myitlab Study Plan" asset type
Then I should be on "Add myitlab Study Plan" page
When I save the "SIM5StudyPlan" details tab
Then I should be on "Build Study Plan" tab 
When I create a "Sim5PreTest" of behavioral mode "SkillBased" Pretest
And I add "SIM5" question in created "Exam [Skill-Based]" activity
And I save "Sim5PreTest" pre test 
Then I should see the "Sim5PreTest" pre test created
When I create a "Sim5PostTest" of behavioral mode "SkillBased" posttest
And I add "SIM5" question in created "Exam [Skill-Based]" activity
And I save "Sim5PostTest" post test
Then I should see the "Sim5PostTest" post test created 
When I save the study plan
#Then I should see the successfull message "Study Plan added successfully."

