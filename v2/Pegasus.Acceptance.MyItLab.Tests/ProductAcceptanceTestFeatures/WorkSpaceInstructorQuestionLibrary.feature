Feature: WorkSpaceAuthor
	                As a WorkSpace Autohor
					I want to manage all the workspace author related usecases 
					so that I would validate all the workspace author scenarios are working fine.


#Purpose: UseCase To Create SIM5Activity
#Test Case Id : HED_MIL_PWF_053
#MyItLabSIM5MasterCourse
Scenario: Create SIM5Activity by WS Teacher
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select 'Add Course Materials' in 'My Course'
And I click on the "Homework" activity type
Then I should be on the "Create activity" page
When I create "SIM5Activity" activity of behavioral mode "SkillBased" type
Then I should see the successfull message "Activity added successfully."

#Purpose: UseCase To Create SIM5Studyplan
#MyItLabSIM5MasterCourse
Scenario: Create SIM5Studyplan by WS Teacher
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select 'Add Course Materials' in 'My Course'
And I click on the "myitlab Study Plan" activity type
Then I should be on the "Add myitlab Study Plan" page
When I create "SIM5StudyPlan" of behavioral mode "SkillBased" type
Then I should see the successfull message "Myitlab Study Plan added successfully."

#Purpose: Instructor sets the behavioral mode for the SIM and grader activity (Basic Random)
#Test Case Id : HED_MIL_PWF_052
#MyItLabSIM5MasterCourse
Scenario: Instructor sets the behavioral mode for the SIM and grader activity (Basic Random)
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select 'Add Course Materials' in 'My Course'
And I click on the "Test" activity type
Then I should be on the "Create activity" page
When I create "Test" type activity of behavioral mode 'BasicRandom'
Then I should see the successfull message "Activity added successfully."

#Purpose: To check the Workspace Instructor sets the behavioral mode for the SIM and grader activity (Grader IT Project/ [Drop box] File upload)                      
#TestCase Id: HED_MIL_PWF_055
#MyItLabSIM5MasterCourse
Scenario: To check the Workspace Instructor sets the behavioral mode for the SIM and grader activity By Ws Instructor 
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select 'Add Course Materials' in 'My Course'
And I click on the "Homework" activity type
Then I should be on the "Create activity" page
When I create "SIM5GraderActivity" of grader activity of behavioral mode "Assignment" type
Then I should see the successfull message "Activity added successfully."

#Purpose: To add the 2010 SIM question form SIM Repository
#TestCase Id:HED_MIL_PWF_065
#MyItLabSIMMasterCourse
Scenario: To add the 2010 SIM question form SIM Repository
When I navigate to "Course Materials" tab and selected "Manage Question Bank" subtab
Then I should be on the "Question Bank" page
When I select 'Add Course Materials' option
And I select "Add SIM Question" option
Then I should be on the "Select Questions" page
When I Added "GO! Office 2010" SIM question from SIM Repository
Then I should see the successfull message "Sim questions added successfully."

#Purpose: To add the 2007 SIM question form SIM Repository
#TestCase Id:HED_MIL_PWF_065
#MyItLabSIMMasterCourse
Scenario: To add the 2007 SIM question form SIM Repository
When I navigate to "Course Materials" tab and selected "Manage Question Bank" subtab
Then I should be on the "Question Bank" page
When I select 'Add Course Materials' option
And I select "Add SIM Question" option
Then I should be on the "Select Questions" page
When I Added "GO! Office 2007" SIM question from SIM Repository
Then I should see the successfull message "Sim questions added successfully."

#Purpose: Creation and accessibility of Grader IT questions (2007) 
#TestCase Id: HED_MIL_PWF_059
#MyItLabSIM5MasterCourse
Scenario: Creation and accessibility of Grader IT questions (2007) by Workspace Instructor 
When I navigate to "Preferences" tab
Then I should be on the "Preferences" page
When I enable 'Enable Instructor Resource Toolbar Preference' preference
Then I should see the successfull message "preferences updated successfully"
When I navigate to "Course Materials" tab and selected "Manage Question Bank" subtab
Then I should be on the "Question Bank" page
When I select 'Add Course Materials' option
And I select "Grader Project" option
And I create "SIM5GraderQuestion" grader IT Question using "Software Upgrade" project 
Then I should see the successfull message "Question added successfully."
When I click on "Edit" cmenu option of "SIM5GraderQuestion" question in manage question bank
Then I should be on the edit page
When I click on "Tryout" cmenu option of "SIM5GraderQuestion" question in manage question bank
Then I should be on the "Test Presentation" page
And I close the "Test Presentation" window

#Purpose: To create SIM question set with 2010 Excel question types
#TestCase Id:HED_MIL_PWF_070
#MyItLabSIMMasterCourse
Scenario: To create question set with 2010 Excel question types
When I navigate to "Course Materials" tab and selected "Manage Question Bank" subtab
Then I should be on the "Question Bank" page
When I select 'Add Course Materials' option
And I select "Create Question Set" option
Then I should be on the "Create Question Set" page
When I Craeted Question Set with "SIM2010ExcelQuestionSet" question type
Then I should see the successfull message "Question Set added successfully."
And I should see the "SIM2010ExcelQuestionSet" SIM question folder into question bank frame

#Purpose: To create SIM question set with 2010 Word question types
#TestCase Id:HED_MIL_PWF_071
#MyItLabSIMMasterCourse
Scenario: To create SIM question set with 2010 Word question types
When I navigate to "Course Materials" tab and selected "Manage Question Bank" subtab
Then I should be on the "Question Bank" page
When I select 'Add Course Materials' option
And I select "Create Question Set" option
Then I should be on the "Create Question Set" page
When I Craeted Question Set with "SIM2010WordQuestionSet" question type
Then I should see the successfull message "Question Set added successfully."
And I should see the "SIM2010WordQuestionSet" SIM question folder into question bank frame

#Purpose: To create SIM question set with 2010 Access question types
#TestCase Id:HED_MIL_PWF_072
#MyItLabSIMMasterCourse
Scenario: To create SIM question set with 2010 Access question types
When I navigate to "Course Materials" tab and selected "Manage Question Bank" subtab
Then I should be on the "Question Bank" page
When I select 'Add Course Materials' option
And I select "Create Question Set" option
Then I should be on the "Create Question Set" page
When I Craeted Question Set with "SIM2010MSAccessQuestionSet" question type
Then I should see the successfull message "Question Set added successfully."
And I should see the "SIM2010MSAccessQuestionSet" SIM question folder into question bank frame

#Purpose: To create SIM question set with 2010 Power Point question types
#TestCase Id:HED_MIL_PWF_073
#MyItLabSIMMasterCourse
Scenario: To create SIM question set with 2010 Power Point question types
When I navigate to "Course Materials" tab and selected "Manage Question Bank" subtab
Then I should be on the "Question Bank" page
When I select 'Add Course Materials' option
And I select "Create Question Set" option
Then I should be on the "Create Question Set" page
When I Craeted Question Set with "SIM2010PowerPointQuestionSet" question type
Then I should see the successfull message "Question Set added successfully."
And I should see the "SIM2010PowerPointQuestionSet" SIM question folder into question bank frame

#Purpose: To create SIM question set with 2007 Excel question types
# TestCase Id: HED_MIL_PWF_066
#MyItLabSIMMasterCourse
Scenario: To create SIM question set with 2007 Excel question types by WsInstructor
When I navigate to "Course Materials" tab and selected "Manage Question Bank" subtab
Then I should be on the "Question Bank" page
When I select 'Add Course Materials' option
And I select "Create Question Set" option
Then I should be on the "Create Question Set" page
When I Craeted Question Set with "SIM2007ExcelQuestionSet" question type
Then I should see the successfull message "Question Set added successfully."
And I should see the "SIM2007ExcelQuestionSet" SIM question folder into question bank frame

#Purpose: To create SIM question set with 2007 Word question types
# TestCase Id: HED_MIL_PWF_067
#MyItLabSIMMasterCourse
Scenario: To create SIM question set with 2007 Word question types by WsInstructor
When I navigate to "Course Materials" tab and selected "Manage Question Bank" subtab
Then I should be on the "Question Bank" page
When I select 'Add Course Materials' option
And I select "Create Question Set" option
Then I should be on the "Create Question Set" page
When I Craeted Question Set with "SIM2007WordQuestionSet" question type
Then I should see the successfull message "Question Set added successfully."
And I should see the "SIM2007WordQuestionSet" SIM question folder into question bank frame

#Purpose: To create SIM question set with 2007 Access question types
# TestCase Id: HED_MIL_PWF_068
#MyItLabSIMMasterCourse
Scenario: To create SIM question set with 2007 Access question types by WsInstructor
When I navigate to "Course Materials" tab and selected "Manage Question Bank" subtab
Then I should be on the "Question Bank" page
When I select 'Add Course Materials' option
And I select "Create Question Set" option
Then I should be on the "Create Question Set" page
When I Craeted Question Set with "SIM2007MSAccessQuestionSet" question type
Then I should see the successfull message "Question Set added successfully."
And I should see the "SIM2007MSAccessQuestionSet" SIM question folder into question bank frame

#Purpose: To create SIM question set with 2007 Power Point question types
# TestCase Id: HED_MIL_PWF_069
#MyItLabSIMMasterCourse
Scenario: To create SIM question set with 2007 Power Point question types by WsInstructor
When I navigate to "Course Materials" tab and selected "Manage Question Bank" subtab
Then I should be on the "Question Bank" page
When I select 'Add Course Materials' option
And I select "Create Question Set" option
Then I should be on the "Create Question Set" page
When I Craeted Question Set with "SIM2007PowerPointQuestionSet" question type
Then I should see the successfull message "Question Set added successfully."
And I should see the "SIM2007PowerPointQuestionSet" SIM question folder into question bank frame

#Purpose : Multiple Choice Question Creation in Question Bank By WsInstructor
#TestCase Id: HED_MIL_PWF_047
#MyItLabSIM5MasterCourse
Scenario: Multiple Choice Question Creation in Question Bank By WsInstructor
When I navigate to "Course Materials" tab and selected "Manage Question Bank" subtab
Then I should be on the "Question Bank" page
When I select 'Add Course Materials' option
And I select "Multiple Choice" question type
Then I should be on the "Create Multiple Choice" page
When I create "MultipleChoice" question
Then I should see the successfull message "Question added successfully."

#Purpose : Ranking Question Creation in Question Bank By WsInstructor
#TestCase Id: HED_MIL_PWF_047
#MyItLabSIM5MasterCourse
Scenario: Ranking Question Creation in Question Bank By WsInstructor
When I navigate to "Course Materials" tab and selected "Manage Question Bank" subtab
Then I should be on the "Question Bank" page
When I select 'Add Course Materials' option
And I select "Ranking" question type
Then I should be on the "Create Ranking" page
When I create "Ranking" question
Then I should see the successfull message "Question added successfully."

#Purpose : To check Preview c-menu option of the Question set
#TestCase Id: HED_MIL_PWF_078
#MyItLabSIMMasterCourse
Scenario: To check Preview c-menu option of the Question set By WsInstructor
When I navigate to "Course Materials" tab and selected "Manage Question Bank" subtab
Then I should be on the "Question Bank" page
When I click on "Preview" cmenu option of "SIM2010WordQuestionSet" question in manage question bank
Then I should be on the "SIM Question Preview" page
And I close the "SIM Question Preview" window

#Purpose: To check Edit c-menu option of the Question set By Ws Instructor 
# TestCase Id: HED_MIL_PWF_077
#MyItLabSIMMasterCourse
Scenario: To check Edit c-menu option of the Question set By Ws Instructor 
When I navigate to "Course Materials" tab and selected "Manage Question Bank" subtab
Then I should be on the "Question Bank" page
When I click on "Edit" cmenu option of "SIM2010WordQuestionSet" question in manage question bank
Then I should be on the "Edit Question Set" page
When I update the Question Set with "SIM2010ExcelQuestionSet" question type
Then I should see the successfull message "Question Set updated successfully."

#Purpose: To check the functionality of c-menu Option of the SIM, Grader IT and question set (Preview)
# TestCase Id: HED_MIL_PWF_074
#MyItLabSIMMasterCourse
Scenario: To check the functionality of context menu option of the SIM, Grader IT and question set (Preview) By Ws Instructor 
When I navigate to "Course Materials" tab and selected "Manage Question Bank" subtab
Then I should be on the "Question Bank" page
When I click on "Preview" cmenu option of "XL Activity 3.12: Using Parentheses" question
Then I should be on the "SIM Question Preview" page
When I close the "SIM Question Preview" window
And I select 'Add Course Materials' option
And I select "Grader Project" option
And I create "SIMGraderQuestion" grader IT Question using "Software Upgrade" project
Then I should see the successfull message "Question added successfully."
When I click on "Tryout" cmenu option of "SIMGraderQuestion" question in manage question bank
Then I should be on the "Test Presentation" page
And I close the "Test Presentation" window

#Purpose: To check the functionality of c-menu Option of the SIM, Grader IT and question set (Set Point Value)
# TestCase Id: HED_MIL_PWF_075
#MyItLabSIMMasterCourse
Scenario: To check the functionality of c-menu Option of the SIM, Grader IT and question set (Set Point Value) By Ws Instructor 
When I navigate to "Course Materials" tab and selected "Manage Question Bank" subtab
Then I should be on the "Question Bank" page
When I click on "Set Point Value" cmenu option of "WD Activity 3.11: Inserting a Clip" question
And I set the point value "10" for the added question
Then I should see the point value "10" for the added question "WD Activity 3.11: Inserting a Clip" 