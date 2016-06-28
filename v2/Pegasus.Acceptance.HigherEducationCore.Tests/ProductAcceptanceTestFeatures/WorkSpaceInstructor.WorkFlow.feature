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
When I Create "RegChildActivity" SAM activity
And I Add Questions using "Create New Question" option
And I create "True/False" question type for at "Create New Question" for Random Activity and Save Activity
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
When I Create "RegChildActivity" SAM activity
And I Add Questions using "Select Questions from Bank" option
And I should Add question from Question Bank and Save Activity
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
When I Create "RegChildActivity" SAM activity
And I Add Questions using "Select Question Groups" option
And I should select "AssessmentRegressionQuestion" Question Group and Save Activity
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
When I Create "RegChildActivity" SAM activity
And I perform "Create New Section" of name "Section1"
And select "Select Questions from Bank" option at add question for Section "1"
And I should Add question from Question Bank and Save Activity
Then I should see the successfull message "Activity added successfully."
When I associate the "RegChildActivity" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"

#Purpose:Creatiion of Activity with multiple Fill In The Blanks Question of RegSAMActivity type
#Pre-requisites: 1)RegSAMActivity SAM activity should be either created during runtime or use the saved RegSAMActivity
Scenario:Creation of Random activity of RegSAMActivity type by adding section with multiple questions
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "RegSAMActivity" SAM activity type
Then I should be on the "Create activity" page
When I Create "RegChildActivity" SAM activity
And I perform "Create New Section" of name "Section1"
And I perform "Create New Section" of name "Section2"
And I perform "Create New Section" of name "Section3"
Then I add '1' questions of type "Fill in the Blank" at Section "1"
And I add '1' questions of type "Fill in the Blank" at Section "2"
And I add '1' questions of type "Fill in the Blank" at Section "3"



#Purpose:Add messages at activity level
#Test Link No:peg-20713
Scenario:Add messages at activity level
When I perform "Navigate" for "Messages" 
Then I add "Beginning of activity" message
And  I add "Direction lines (instructions)" message
And I add "End of activity" message
When I perform "Save and Continue" for "Messages" 



#Purpose:Verification of set preferences and overwritting preferences
Scenario:Verification of set preferences and overwritting preferences
When I perform "Navigate" for "Preferences" 
Then I reset style sheet to "Default" 
And I check Allow students to skip questions
And I reset number of questions per page value as "2"
When I perform "Save and Return" for "Preferences"

#Purpose:Add Activity to My Course and set as Shown
Scenario:Add Activity to My Course and set as shown
Given I should see the successfull message "Activity added successfully."
When I associate the "RegChildActivity" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"
When I select cmenu "ShowHide" option of activity "RegChildActivity"

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
