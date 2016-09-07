Feature: WorkSpaceInstructor
	                As a Ws Instructor 
					I want to manage all the workspace Instructor related usecases 
					so that I would validate all the workspace Instructor scenarios are working fine.

#Used General Course
#Purpose: To Verify Copy of content across the course
# TestCase Id: HSS_Core_PWF_217
Scenario: To Verify Copy of content across the course
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I navigate to the "Copy Content" tab in Preferences Page
Then I should be on the "Copy Content" subtab
When I enable the 'Copy Content' option
And I save the Preferences
And I navigate back to the "Course Materials" tab
Then I should see the "Change Source" option displayed in the 'Course Materials' tab
When I click on the 'Change Source' option
Then I should see the "MySpanishLabMaster" source course in the dropdown
When I click on the "MySpanishLabMaster" source course
And I select the "PA-01 Span Practice- Vocabulary: Saludos, despedidas y presentaciones" activity in source course
And I click on the Add button
And I add the Activity to Course Content in target course
Then I should see the successfull message "Content item is added to My Course"
And I should see "PA-01 Span Practice- Vocabulary: Saludos, despedidas y presentaciones" activity in course content in target course

#Used Master Course
#Purpose : To Create Test With Basic Random Activity
Scenario: To Create Test with Basic Random Activity By WS Instructor
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Test" activity type
Then I should be on the "Create activity" page
When I create "Test" type activity of behavioral mode 'BasicRandom'
Then I should see the successfull message "Activity added successfully."
When I associate the "Test" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"

#Used Master Course
#Purpose: To Create Homework With Basic Random Activity By Ws Instructor 
Scenario: To Create Homework with Basic Random Activity By WS Instructor
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Homework" activity type
Then I should be on the "Create activity" page
When I create "HomeWork" type activity of behavioral mode 'BasicRandom'
Then I should see the successfull message "Activity added successfully."
When I associate the "HomeWork" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"

#Used Master Course
#Purpose: To Create Quiz Activity With Essay Question By Ws Instructor 
Scenario: To Create Quiz with Manual Gradable Activity By WS Instructor
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Quiz" activity type
Then I should be on the "Create activity" page
When I create "Quiz" activity of behavioral mode type using Essay question
Then I should see the successfull message "Activity added successfully."
When I associate the "Quiz" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"

#Used Master Course
#Purpose: Create The Page By Ws Instructor 
Scenario: To Create The Page By Ws Instructor
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Add Page" activity type
Then I should be on the "Create page" page
When I create the "Page" activity in Content Library
Then I should see the successfull message "Page saved successfully."
When I associate the "Page" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"

#Used Master Course
#Purpose: Create The File By Ws Instructor 
Scenario: To Create The File By Ws Instructor
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Add File" activity type
Then I should be on the "Add File" page 
When I create the "File" activity in Content Library
Then I should see the successfull message "File saved successfully."
When I associate the "File" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"

#Used Master Course
#Purpose: Create The Link By Ws Instructor 
Scenario: To Create The Link By Ws Instructor
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Add Link" activity type
Then I should be on the "Add link" page
When I create the "Link" activity in Content Library
Then I should see the successfull message "Link saved successfully."
When I associate the "Link" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"

#Used Master Course
#Purpose: Create The Discussion Topic By Ws Instructor
Scenario: To Create The Discussion Topic By Ws Instructor
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Add Discussion Topic" activity type
Then I should be on the "Add Discussion Topic" page
When I create the "DiscussionTopic" activity in Content Library
Then I should see the successfull message "Discussion topic saved successfully."
When I associate the "DiscussionTopic" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"

#Used Master Course
#Purpose: Create SkillStudyPlan in Content Library
Scenario: Create SkillStudyPlan in Content Library By Ws Instructor
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Add Skill Study Plan" activity type
Then I should be on the "Create Skill Study Plan" page
When I create "SkillStudyPlan" activity in "HedWsInstructor"
Then I should see the successfull message "Study Plan added successfully."
When I associate the "SkillStudyPlan" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"

#Purpose: Create Folder in content library and then create link to my course frame
Scenario: Creation of folder in Course Materials
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Add Folder" activity type
Then I should be on the "Create New Folder" page
When I create "Folder" type Folder
Then I should see the successfull message "Folder saved successfully."
When I associate the "Folder" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"

#Purpose: Verify the tab navigation in workspace teacher
Scenario: To Verify Tab Navigation By Ws Instructor
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#Purpose: Instructor enable General preference for SAM activity type
Scenario: Workspace Instructor enable General preference for SAM activity type
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I click on the "Activities" tab
And I Create a new "RegSAMActivity" SAM activity type
Then I should see the successfull message "preferences updated successfully"
When I click on "RegSAMActivity" edit link
Then I should see the "Default preferences" popup
When I set the "General" preference for "RegSAMActivity" activity type
And I set the "Messages" preference for "RegSAMActivity" activity type
And I set the "Timing" preference for "RegSAMActivity" activity type
And I set the "Feedback" preference for "RegSAMActivity" activity type
And I set the "Res. Toolbar" preference for "RegSAMActivity" activity type
And I set the "Grading" preference for "RegSAMActivity" activity type
And I set the "Sections" preference for "RegSAMActivity" activity type
And I set the "Video Chat" preference for "RegSAMActivity" activity type
And I click on "Save" button for "RegSAMActivity"
Then I should see the successfull message "Preference settings updated for selected activity type."


#Purpose: Create Activity of RegSAMActivity type by adding questions from Create New Question 
#Pre-requisites: RegSAMActivity SAM activity should be either created during runtime or use the saved RegSAMActivity 
                 # if not created during runtime
#JIRA ID| #JIRA ID | TestLink ID:PEGASUS-45292 |peg-19509
Scenario: Create Activity of RegSAMActivity type by adding questions from Create New Question 
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "RegSAMActivity" SAM activity type
Then I should be on the "Create activity" page
When I Create "RegChildActivity" activity with Behavioral Mode "Basic Random"
And I Add Questions using "Create New Question" option
And I create "True/False" question using "Create New Question"
When I perform "Save and Return" for "Questions"
Then I should see the successfull message "Activity added successfully."
When I associate the "RegChildActivity" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"


#Purpose:Creation of Random activity of RegSAMActivity type by selecting questions from question library
#Pre-requisites: RegSAMActivity SAM activity should be either created during runtime or use the saved RegSAMActivity 
#JIRA ID| #JIRA ID | TestLink ID:PEGASUS-45292 |peg-20703
Scenario: Creation of Random activity of RegSAMActivity type by selecting questions from question library
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "RegSAMActivity" SAM activity type
Then I should be on the "Create activity" page
When I Create "RegChildActivity" activity with Behavioral Mode "Basic Random"
And I Add Questions using "Select Questions from Bank" option
And I should Add question from Question Bank
When I perform "Save and Return" for "Questions"
Then I should see the successfull message "Activity added successfully."
When I associate the "RegChildActivity" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"




#Purpose:Creation of Random activity of RegSAMActivity type by selecting questions from Question Groups
#Pre-requisites: 1)RegSAMActivity SAM activity should be either created during runtime or use the saved RegSAMActivity 
               # if not created during runtime
			   # 2)AssessmentRegressionQuestion Question Group should be either created during runtime or use the 
			   # saved AssessmentRegressionQuestion 
#JIRA ID| #JIRA ID | TestLink ID:PEGASUS-45292 |peg-20704
Scenario:Creation of Random activity of RegSAMActivity type by selecting questions from Question Groups
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "RegSAMActivity" SAM activity type
Then I should be on the "Create activity" page
When I Create "RegChildActivity" activity with Behavioral Mode "Basic Random"
And I Add Questions using "Select Question Groups" option
And I should select "AssessmentRegressionQuestion" Question Group
When I perform "Save and Return" for "Questions"
Then I should see the successfull message "Activity added successfully."
When I associate the "RegChildActivity" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"


#Purpose:Creation of Random activity of RegSAMActivity type by adding section
#Pre-requisites: 1)RegSAMActivity SAM activity should be either created during runtime or use the saved RegSAMActivity 
#JIRA ID| #JIRA ID | TestLink ID:PEGASUS-45292 |peg-20711
Scenario:Creation of Random activity of RegSAMActivity type by adding section
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "RegSAMActivity" SAM activity type
Then I should be on the "Create activity" page
When I Create "RegChildActivity" activity with Behavioral Mode "Basic Random"
And I perform "Create New Section" of name "Section1"
And select "Select Questions from Bank" option at add question for Section "1"
And I should Add question from Question Bank
When I perform "Save and Return" for "Questions"
Then I should see the successfull message "Activity added successfully."
When I associate the "RegChildActivity" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"

Scenario:Add RegChildAbruptActivity Activity to My Course and set as shown
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I associate the "RegChildAbruptActivity" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"
When I search "RegChildAbruptActivity" in "My Course" frame  of "Course Materials" tab
Then I should be displayed with "RegChildAbruptActivity" in My Course frame  of "Course Materials" tab
When I click on "ShowHide"  of "RegChildAbruptActivity" in  "Course Materials" tab as "RegHedWsInstructor"

#Purpose:Instructor enable Feedback preference for random activity
Scenario: Instructor enable Feedback preference for random activity
When I enable "Correct Answer" with "Always" for Feedback preference
And I enable "Display feedback" with "Always" for Feedback preference

#Purpose:Click on Save and return button based on the page type in activity creation page
Scenario: Instructor click on Save and Return button based on the page type in activity creation page
When I perform "Save and Return" for "Questions" 

Scenario: Instructor enable Enable late submissions for Random activity
When I enable "Enable late submissions" in activity preference

#Purpose:Creatiion of Activity with multiple Fill In The Blanks Question of RegSAMActivity type
#Pre-requisites: 1)RegSAMActivity SAM activity should be either created during runtime or use the saved RegSAMActivity
Scenario:Creation of Random activity of RegSAMActivity type by adding section with multiple questions
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "RegSAMActivity" SAM activity type
Then I should be on the "Create activity" page
When I Create "RegChildActivity" activity with Behavioral Mode "Basic Random"
And I perform "Save and Continue" for "Activity Details"
And I perform "Create New Section" of name "Section1"
And I perform "Create New Section" of name "Section2"
And I perform "Create New Section" of name "Section3"
Then I add '3' questions of type "Fill in the Blank" at Section "1"
And I add '1' questions of type "Fill in the Blank" at Section "2"
And I add '1' questions of type "Fill in the Blank" at Section "3"

Scenario:Creation of Random activity of RegSAMActivity type by adding single section
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "RegSAMActivity" SAM activity type
Then I should be on the "Create activity" page
When I Create "RegChildAbruptActivity" activity with Behavioral Mode "Basic Random"
And I perform "Save and Continue" for "Activity Details"
And I perform "Create New Section" of name "Section1"
Then I add '2' questions of type "Fill in the Blank" at Section "1"


#Purpose:Add messages at activity level
#Test Link No:peg-20713
Scenario:Add messages at activity level
When I perform "Navigate" for "Messages" 
Then I add "Beginning of activity" message
And  I add "Direction lines (instructions)" message
And I add "End of activity" message
When I perform "Save and Continue" for "Messages" 

#Purpose:Verification of set preferences and overwritting preferences .
Scenario:Verification of set preferences and overwritting preferences
When I perform "Navigate" for "Preferences" 
Then I reset style sheet to "Default" 
And I check Allow students to skip questions
And I reset number of questions per page value as "2"

#-----------------------------Save activity--------------------------------
#Purpose: Save activity from various tabs in activity creation wizard
Scenario: Save and return from activity Activity Details tab
When I perform "Save and Return" for "Activity Details"
Then I should see the successfull message "Activity added successfully."

Scenario: Save and return from activity Questions tab
When I perform "Save and Return" for "Questions"
Then I should see the successfull message "Activity added successfully."

Scenario: Save and return from activity Messages tab
When I perform "Save and Return" for "Messages"
Then I should see the successfull message "Activity added successfully."

Scenario: Save and return from Grades tab
When I perform "Save and Return" for "Grades"
Then I should see the successfull message "Activity added successfully."

Scenario: Save and return from Teaching Support tab
When I perform "Save and Return" for "Teaching Support"
Then I should see the successfull message "Activity added successfully."

Scenario: Save and return from HelpLinks tab
When I perform "Save and Return" for "HelpLinks"
Then I should see the successfull message "Activity added successfully."

Scenario: Save and return from activity preference page
When I perform "Save and Return" for "Preferences"
Then I should see the successfull message "Activity added successfully."

#Purpose:Add Activity to My Course and set as Shown
Scenario:Add RegChildActivity Activity to My Course and set as shown
When I associate the "RegChildActivity" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"
When I search "RegChildActivity" in "My Course" frame  of "Course Materials" tab
Then I should be displayed with "RegChildActivity" in My Course frame  of "Course Materials" tab
When I click on "Show"  of "RegChildActivity" in  "Course Materials" tab as "RegHedWsInstructor"

#------------------------------Add Section Direction Lines-----------------------
#Purpose:Clicking on Add link of "Direction Lines" under each section
#Test Link id:peg-19554
Scenario:Add Section Direction Lines
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


#Purpose:Workspace or coursespace teacher navigate to "Course Materials" tab and selected "Add from Library" subtab
Scenario: User navigate to Course Materials tab and selected Add from Library subtab
When I navigate to "Course Materials" tab and selected "Add from Library" subtab
Then I should be on the "Course Materials" page
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page

#------------------------------Fill Activity Details in Activity Creation Wizard-----------------------
#Purpose:Workspace instructor launch create activity wizard and enter activity name
Scenario: Workspace instructor launches random activity create wizard
When I click on the 'Add Course Materials' option
And I click on the "RegSAMActivity" SAM activity type
Then I should be on the "Create activity" page

Scenario: Add activity details in Activity Creation Wizard
When I Create "RegChildActivity" activity with Behavioral Mode "Basic Random"

#--------------------------------------Add Questions in Questions tab--------------------------------------
#Purpose: Workspace instructor adds questions to activity

#--------------------------------------Create New Question--------------------------------------
Scenario: Add questions using create new question
Then I Add Questions using "Create New Question" option
And I create "True/False" question using "Create New Question"

#---------------------------------Add Questions using "Select Question Groups"-------------------
Scenario: Add questions using Select Question Group
Then I Add Questions using "Select Question Groups" option
And I should select "AssessmentRegressionQuestion" Question Group

#---------------------------------Add Questions using "Select Question from Bank"-------------------
Scenario: Add questions using Select Questions from Bank
Then I Add Questions using "Select Questions from Bank" option
And I should Add question from Question Bank

#----------------------------------------------------Create Section--------------------------------------
Scenario: Create New Section in Questions tab
When I perform "Create New Section" of name "Section1"

#Purpose:Workspace instructor create single section and add multiple question to it
Scenario: Workspace instructor create new single section and add 3 fill in the blank question to section1
When I perform "Create New Section" of name "Section1"
Then I add '3' questions of type "Fill in the Blank" at Section "1"

Scenario: Instructor configore HelpLink and Grades preference for random activity
When I configure the 'Grades' preference
And I add 'HelpLinks'

#Purpose:Workspace instructor enable "Save response at the end of each page " preference for random activity
Scenario: Workspace instructor enable Save response at the end of each page 
When  I check Save response at the end of each page

#Workspace instructor enable Number of attempts is unlimited option for random activity prefernce
Scenario: Workspace instructor enable Number of attempts is unlimited preference
When I set specify number of Attempts to "unlimited"
#And I set specify number of Attempts to "1"

#Purpose : Workspace instructor adds newly created random activity from Content Library to MyCourse frame to make the content available for students
Scenario: Workspace instructor adds newly created random activity from Content Library to MyCourse frame
When I associate the "RegChildActivity" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"


#------------------------------------Navigate to various Course Tools on the Course Tool Bar--------------------
Scenario: Navigate to Manage Course Materials
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page


Scenario:Verification perfernece Save response at the end of each page
When I attempt questions listed in Page "1" of "RegSAMActivity" Activity Presentation Window
And I click on next button in "RegSAMActivity" Activity Presentation Window	
And I close activity presenation window Abruptly
Then I should be on the "Course Materials" page

When I click on "View Submissions" of  "RegChildActivity" Activity in "Course Materials" page
Then I should be on the "View Submission" page
And I should see the message "Activity has been started and saved for later but not yet submitted." in view submission page
When I close the "View Submission" window
Then I should be on the "Course Materials" page

When I logged into the Pegasus as "HedWsInstructor" in "WorkSpace"
Then I should logged in successfully
When I enter in the "MySpanishLabMaster" from the Global Home page as "HedWsInstructor" 
When I navigate to "Course Materials" tab and selected "Add from Library" subtab
Then I should be on the "Course Materials" page
When I navigate to "Course Materials" tab

And I search "RegChildActivity" in "My Course" frame  of "Course Materials" tab
Then I should be displayed with "RegChildActivity" in My Course frame  of "Course Materials" tab

When I click on "View Submissions"  of "RegChildActivity" in  "Course Materials" tab as "HedWsInstructor"
Then I should be on the "View Submission" page
When I select the student "HedWsStudent" from student frame in view submission page
Then I should see "Submit Student's Answer" button in "View Submission" page
When I click  "Submit Student's Answer" button in "View Submission" page
Then I should be displayed with "Question was not attempted" for unanswered question

#----------------------------------------------------------------------------------------------------------------------------------------------------------
#Purpose:Creating Radom activity with number of attempts set to 1
#Pre-requisites: RegSAMActivity SAM activity should be either created during runtime or use the saved RegSAMActivity 
Scenario: Creating Radom activity with number of attempts set to 1
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "RegSAMActivity" SAM activity type
Then I should be on the "Create activity" page
When I Create "RegChildActivity" activity with Behavioral Mode "Basic Random"
And I perform "Create New Section" of name "Section1"
And I perform "Create New Section" of name "Section2"
And I perform "Create New Section" of name "Section3"
Then I add '3' questions of type "Fill in the Blank" at Section "1"
And I add '3' questions of type "Fill in the Blank" at Section "2"
And I add '3' questions of type "Fill in the Blank" at Section "3"

# Set number of attempts to 1
And I set Specify Number of Attempts to "1"
And I Save the activity
Then I should see the successfull message "Activity added successfully."

#Purpose:To Verify Presentation window when "Number of Attempts" option is set to 1
Scenario:To Verify Presentation window, when "Number of Attempts" option is set to 1
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I open the "RegChildActivity" Activity
And I should see Activity Alter indicating activity can be tried only once
And I attempt "5" questions listed in Page "1" of "RegSAMActivity" Activity Presentation Window
When I navigate to next page
And I attempt "4" questions listed in Page "2" of "RegSAMActivity" Activity Presentation Window
Then I should successfully submit activity for grading
When I open the "RegChildActivity" Activity
Then I should see a message "There are no more attempts available for this activity." in the "Test Presentation" Window

#Purpose: To verify Second attempt
#Scenario: To verify Second attempt
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I open the "RegChildActivity" Activity
Then I should see a message "There are no more attempts available for this activity." in the "Test Presentation" Window

#-----------------------------------------------------Add asset from Content Library to My Course----------------------
Scenario: Add asset from Content Library to My Course
When I associate the "RegChildActivity" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"


#-----------------------------------------------------Show/Hide asset in My Course ------------------------------------
Scenario: Search asset in MyCourse and Show/Hide
#When I search "RegChildActivity" in My Course frame  of "Course Materials" tab
When I search "RegChildActivity" in "My Course" frame  of "Course Materials" tab
Then I should be displayed with "RegChildActivity" in My Course frame  of "Course Materials" tab
When I click on "Show"  of "RegChildActivity" in  "Course Materials" tab as "RegHedWsInstructor"

Scenario: Search asset with Highest Score Preference in MyCourse and Show/Hide
When I associate the "RegHighestScoreActivity" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"
When I search "RegHighestScoreActivity" in "My Course" frame  of "Course Materials" tab
Then I should be displayed with "RegHighestScoreActivity" in My Course frame  of "Course Materials" tab
When I click on "Show"  of "RegHighestScoreActivity" in  "Course Materials" tab as "RegHedWsInstructor"

Scenario: Search asset with Lowest Score Preference in MyCourse and Show/Hide
When I associate the "RegLowestScoreActivity" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"
When I search "RegLowestScoreActivity" in "My Course" frame  of "Course Materials" tab
Then I should be displayed with "RegLowestScoreActivity" in My Course frame  of "Course Materials" tab
When I click on "Show"  of "RegLowestScoreActivity" in  "Course Materials" tab as "RegHedWsInstructor"

Scenario: Search asset with First Score Preference in MyCourse and Show/Hide
When I associate the "RegFirstScoreActivity" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"
When I search "RegFirstScoreActivity" in "My Course" frame  of "Course Materials" tab
Then I should be displayed with "RegFirstScoreActivity" in My Course frame  of "Course Materials" tab
When I click on "Show"  of "RegFirstScoreActivity" in  "Course Materials" tab as "RegHedWsInstructor"

Scenario: Search asset with Last Score Preference in MyCourse and Show/Hide
When I associate the "RegLastScoreActivity" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"
When I search "RegLastScoreActivity" in "My Course" frame  of "Course Materials" tab
Then I should be displayed with "RegLastScoreActivity" in My Course frame  of "Course Materials" tab
When I click on "Show"  of "RegLastScoreActivity" in  "Course Materials" tab as "RegHedWsInstructor"

Scenario: Search asset with Average Score Preference in MyCourse and Show/Hide
When I associate the "RegAverageScoreActivity" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"
When I search "RegAverageScoreActivity" in "My Course" frame  of "Course Materials" tab
Then I should be displayed with "RegAverageScoreActivity" in My Course frame  of "Course Materials" tab
When I click on "Show"  of "RegAverageScoreActivity" in  "Course Materials" tab as "RegHedWsInstructor"

#------------------------------Create activity for verifying "Record this score in Gradebook" functionality-----------------------
#Purpose: Create activity for verifying "Record this score in Gradebook" functionality

#--------------------------------------Verify Highest Score--------------------------------------
Scenario: Create activity for verifying Highest score
When I Create "RegHighestScoreActivity" activity with Behavioral Mode "Basic Random"

#--------------------------------------Verify Lowest Score--------------------------------------
Scenario: Create activity for verifying Lowest score
When I Create "RegLowestScoreActivity" activity with Behavioral Mode "Basic Random"

#--------------------------------------Verify First Score--------------------------------------
Scenario: Create activity for verifying First score
When I Create "RegFirstScoreActivity" activity with Behavioral Mode "Basic Random"

#--------------------------------------Verify Last Score--------------------------------------
Scenario: Create activity for verifying Last score
When I Create "RegLastScoreActivity" activity with Behavioral Mode "Basic Random"

#--------------------------------------Verify Average Score--------------------------------------
Scenario: Create activity for verifying Average score
When I Create "RegAverageScoreActivity" activity with Behavioral Mode "Basic Random"


#-----------------------------------------------------Record this score in Gradebook------------------------------------
#Purpose: Verifying the "Record this score in Gradebook" option
#TestLink id: peg-20728
Scenario: Setting the "Record this score in Gradebook" option to First
Then set Record this score in Gradebook option to "First"

Scenario: Setting the "Record this score in Gradebook" option to Last
Then set Record this score in Gradebook option to "Last"

Scenario: Setting the "Record this score in Gradebook" option to Highest
Then set Record this score in Gradebook option to "Highest"

Scenario: Setting the "Record this score in Gradebook" option to Lowest
Then set Record this score in Gradebook option to "Lowest"

Scenario: Setting the "Record this score in Gradebook" option to Average
Then set Record this score in Gradebook option to "Average"

#------------------------Navigate to various tabs in the Activity Creation Wizard---------------------
Scenario: Navigate to Activity Details tab in Activity Creation Wizard
When I perform "Navigate" for "Activity Details"

Scenario: Navigate to Questions tab in Activity Creation Wizard
When I perform "Navigate" for "Questions"

Scenario: Navigate to Messages tab in Activity Creation Wizard
When I perform "Navigate" for "Messages"

Scenario: Navigate to Grades tab in Activity Creation Wizard
When I perform "Navigate" for "Grades"

Scenario: Navigate to Teaching Support tab in Activity Creation Wizard
When I perform "Navigate" for "Teaching Support"

Scenario: Navigate to HelpLinks tab in Activity Creation Wizard
When I perform "Navigate" for "HelpLinks"

Scenario: Navigate to Preferences tab in Activity Creation Wizard
When I perform "Navigate" for "Preferences"

Scenario: Instructor Views Average Score in View Submission
When I search "RegAverageScoreActivity" in "My Course" frame  of "Course Materials" tab
Then I should be displayed with "RegAverageScoreActivity" in My Course frame  of "Course Materials" tab
When I click on "View Submissions"  of "RegAverageScoreActivity" in  "Course Materials" tab as "RegHedWsInstructor"
Then I should be on the "View Submission" page
When I view all submissions of "RegHedWsStudent" in view submission page
Then as "RegHedWsInstructor" I should see the "Average" score recorded

Scenario: Instructor Views First Score in View Submission
When I search "RegFirstScoreActivity" in "My Course" frame  of "Course Materials" tab
Then I should be displayed with "RegFirstScoreActivity" in My Course frame  of "Course Materials" tab
When I click on "View Submissions"  of "RegFirstScoreActivity" in  "Course Materials" tab as "RegHedWsInstructor"
Then I should be on the "View Submission" page
When I view all submissions of "RegHedWsStudent" in view submission page
Then as "RegHedWsInstructor" I should see the "First" score recorded 

Scenario: Instructor Views Last Score in View Submission
When I search "RegLastScoreActivity" in "My Course" frame  of "Course Materials" tab
Then I should be displayed with "RegLastScoreActivity" in My Course frame  of "Course Materials" tab
When I click on "View Submissions"  of "RegLastScoreActivity" in  "Course Materials" tab as "RegHedWsInstructor"
Then I should be on the "View Submission" page
When I view all submissions of "RegHedWsStudent" in view submission page
Then as "RegHedWsInstructor" I should see the "Last" score recorded 

Scenario: Instructor Views Highest Score in View Submission
When I search "RegHighestScoreActivity" in "My Course" frame  of "Course Materials" tab
Then I should be displayed with "RegHighestScoreActivity" in My Course frame  of "Course Materials" tab
When I click on "View Submissions"  of "RegHighestScoreActivity" in  "Course Materials" tab as "RegHedWsInstructor"
Then I should be on the "View Submission" page
When I view all submissions of "RegHedWsStudent" in view submission page
Then as "RegHedWsInstructor" I should see the "Highest" score recorded 

Scenario: Instructor Views Lowest Score in View Submission
When I search "RegLowestScoreActivity" in "My Course" frame  of "Course Materials" tab
Then I should be displayed with "RegLowestScoreActivity" in My Course frame  of "Course Materials" tab
When I click on "View Submissions"  of "RegLowestScoreActivity" in  "Course Materials" tab as "RegHedWsInstructor"
Then I should be on the "View Submission" page
When I view all submissions of "RegHedWsStudent" in view submission page
Then as "RegHedWsInstructor" I should see the "Lowest" score recorded 

Scenario: Close View Submission Page
When I close the "View Submission" window
Then I should be on the "Course Materials" page

#Purpose: Create Folder in content library and then create link to my course frame
Scenario: Creation of folder in Course Materials Library
When I click on the 'Add Course Materials' option
And I click on the "Add Folder" activity type
Then I should be on the "Create New Folder" page
When I create "RegFolderGBPreference" type Folder
Then I should see the successfull message "Folder saved successfully."

#Purpose: Open a folder
Scenario: Opening a folder in Course Materials tab
When I open the "RegFolderGBPreference" in "Course Materials Library" frame

#Purpose: Navigate one level up using the back button in Course Materials
Scenario: Navigate one level up using the back button in Course Materials
When I click on back arrow icon in the "Course Materials Library" frame
Then I should be on the "Course Materials" page

#Purpose: Add Folder from Course Materials Library to My Course and Unhide the contents
Scenario: Add Folder from Course Materials Library to My Course and Unhide the contents
When I associate the "RegFolderGBPreference" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"
When I search "RegFolderGBPreference" in "My Course" frame  of "Course Materials" tab
Then I should be displayed with "RegFolderGBPreference" in My Course frame  of "Course Materials" tab
When I click on "Show"  of "RegFolderGBPreference" in  "Course Materials" tab as "RegHedWsInstructor"

#Purpose: Open folder in My Course frame
Scenario: Open folder in My Course frame
When I open the "RegFolderGBPreference" in "My Course" frame
#And I select all the contents
#And I click ShowHide in MyCourse
#Then I should see the contents in "Shown" state