Feature: WorkSpaceInstructorContentLibrary
	                As a Ws Instructor 
					I want to manage all the workspace Instructor related usecases 
					so that I would validate all the workspace Instructor scenarios are working fine.

#Purpose: Instructor Manage location settings
# TestCase Id: HED_MIL_PWF_056
#MyItLabSIM5MasterCourse
Scenario: Instructor Manage location settings
When I navigate to "Preferences" tab
Then I should be on the "Preferences" page
When I navigate to the "Manage Locations" tab in Preferences Page
Then I should be on the "Manage Locations" subtab
When I create the mac address for computer
Then I should see the successfull message "New computer added successfully."
When I create the location
Then I should see the successfull message "New location created successfully."
When I associate the computer to location
Then I should see the successfull message "Computers added successfully."

#Purpose: Creation of non gradable assets Link in MIL course By Ws Instructor 
# TestCase Id: HED_MIL_PWF_090 
#MyItLabSIM5MasterCourse
Scenario: Creation of non gradable assets Link in MIL course By Ws Instructor 
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Add Link" activity type
Then I should be on the "Add link" page
When I create the nongradable "Link" activity 
Then I should see the successfull message "Link saved successfully."
And I should see "Link" Activity in the MyCourse Frame
When I click the "Open" cmenu option

#Purpose: To create the Instructor Gradable Asset 
# TestCase Id: HED_MIL_PWF_125
#MyItLabSIMMasterCourse
Scenario: To create the Instructor Gradable Essay Asset By Ws Instructor 
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Homework" activity type
Then I should be on the "Create activity" page
When I create "HomeWork" activity of behavioral mode "BasicRandom" type using Essay question
Then I should see the successfull message "Activity added successfully."

#Purpose: Assign the activity in mycourse frame 
# TestCase Id: HED_MIL_PWF_123
#MyItLabSIMMasterCourse
Scenario: Assign the activity in mycourse frame By Ws Instructor
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
And I should see the "SIMStudyPlan2010" activity of behavioral mode "SkillBased" type using SIM question
When I assign the activity in mycourse

#Purpose: Creation of non gradable assets Page in MIL course By Ws Instructor 
# TestCase Id: HED_MIL_PWF_090 
#MyItLabSIM5MasterCourse
Scenario: Creation of non gradable assets Page in MIL course By Ws Instructor 
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Add Page" activity type
Then I should be on the "Create page" page
When I create the nongradable "Page" activity 
Then I should see the successfull message "Page saved successfully."
And I should see "Page" Activity in the MyCourse Frame
When I click the "Preview" cmenu option

#Purpose: Creation of non gradable assets File in MIL course By Ws Instructor 
# TestCase Id: HED_MIL_PWF_090 
#MyItLabSIM5MasterCourse
Scenario: Creation of non gradable assets File in MIL course By Ws Instructor
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Add File" activity type
Then I should be on the "Add File" page
When I create the nongradable "File" activity 
Then I should see the successfull message "File saved successfully."
And I should see "File" Activity in the MyCourse Frame
When I click the "Preview" cmenu option

#Purpose: Creation of non gradable assets Discussion Topic in MIL course By Ws Instructor 
# TestCase Id: HED_MIL_PWF_090 
#MyItLabSIM5MasterCourse
Scenario: Creation of non gradable assets Discussion Topic in MIL course By Ws Instructor 
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Add Discussion Topic" activity type
Then I should be on the "Add Discussion Topic" page
When I create the nongradable "DiscussionTopic" activity 
Then I should see the successfull message "Discussion topic saved successfully."
And I should see "DiscussionTopic" Activity in the MyCourse Frame
When I click the "Open" cmenu option

#Purpose: To check the Creation of Exam Skill based activities with 2010 SIM Questions
# TestCase Id: HED_MIL_PWF_084
#MyItLabSIMMasterCourse
Scenario: Creation of Exam Skill Based Activities with 2010 SIM Questions By Ws Instructor 
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Homework" activity type
Then I should be on the "Create activity" page
When I create "SIMExamActivity" activity of behavioral mode "SkillBased" type using SIM question
Then I should see the successfull message "Activity added successfully."

#Purpose: To check the Creation of Training Skill based activities with 2010 SIM Questions
# TestCase Id: HED_MIL_PWF_083
#MyItLabSIMMasterCourse
Scenario: Creation of Training Skill Based Activities with 2010 SIM Questions By Ws Instructor 
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Homework" activity type
Then I should be on the "Create activity" page
When I create "SIMTrainingActivity" activity of behavioral mode "SkillBased" type using SIM question
Then I should see the successfull message "Activity added successfully."

#Purpose: To check the Creation of Exam Project based activities with 2010 SIM Questions
# TestCase Id: HED_MIL_PWF_086
#MyItLabSIMMasterCourse
Scenario: Creation of Exam Project Based Activities with 2010 SIM Questions By Ws Instructor 
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Homework" activity type
Then I should be on the "Create activity" page
When I create "SIMExamActivity" activity of behavioral mode "DocBased" type using SIM question
Then I should see the successfull message "Activity added successfully."

#Purpose: To check the Creation of Training Project based activities with 2010 SIM Questions
# TestCase Id: HED_MIL_PWF_085
#MyItLabSIMMasterCourse
Scenario: Creation of Training Project Based Activities with 2010 SIM Questions By Ws Instructor
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Homework" activity type
Then I should be on the "Create activity" page
When I create "SIMTrainingActivity" activity of behavioral mode "DocBased" type using SIM question
Then I should see the successfull message "Activity added successfully."

#Purpose: To check the Creation of SIM Study Plan with 2010 SIM Questions
#TestCase : HED_MIL_PWF_087
#MyItLabSIMMasterCourse
Scenario: Creation of SIMStudyplan with 2010 SIM Questions by WS Teacher
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "myitlab Study Plan" activity type
Then I should be on the "Add myitlab Study Plan" page
When I create "SIMStudyPlan2010" activity of behavioral mode "SkillBased" type using SIM question
Then I should see the successfull message "Myitlab Study Plan added successfully."

#Purpose: Instructor Previews the sim study Plan
# TestCase Id: HED_MIL_PWF_093
#MyItLabSIMMasterCourse
Scenario: Instructor Previews the sim study Plan
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I search "SIMStudyPlan2010" activity of behavioral mode "SkillBased" type
And I select the Cmenu option "Preview"
Then I should be on the "myitlab Study Plan Preview" page

#Purpose: To check the Creation of SIM Study Plan Document Based with 2010 SIM Questions
#TestCase : HED_MIL_PWF_092
#MyItLabSIMMasterCourse
Scenario: Creation of SIMStudyplan Document Based with 2010 SIM Questions by WS Teacher
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "myitlab Study Plan" activity type
Then I should be on the "Add myitlab Study Plan" page
When I create "SIMStudyPlan2010" activity of behavioral mode "DocBased" type using SIM question
Then I should see the successfull message "Myitlab Study Plan added successfully."

#Purpose: Instructor Previews SIMStudyplan Document Based Activity
# TestCase Id: HED_MIL_PWF_092
#MyItLabSIMMasterCourse
Scenario: Instructor Previews SIMStudyplan Document Based Activity by WS Teacher
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I search "SIMStudyPlan2010" activity of behavioral mode "DocBased" type
And I select the Cmenu option "Preview"
Then I should be on the "myitlab Study Plan Preview" page

#Purpose: To check the Creation of SIM Study Plan with 2007SIM Questions
#TestCase : HED_MIL_PWF_110
#MyItLabSIMMasterCourse
Scenario: Creation of SIMStudyplan with 2007 SIM Questions by WS Teacher
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "myitlab Study Plan" activity type
Then I should be on the "Add myitlab Study Plan" page
When I create "SIMStudyPlan2007" activity of behavioral mode "SkillBased" type using SIM question
Then I should see the successfull message "Myitlab Study Plan added successfully."

#Purpose: Instructor Previews the sim study Plan with 2007 SIM Questions
# TestCase Id: HED_MIL_PWF_110
#MyItLabSIMMasterCourse
Scenario: Instructor Previews the sim study Plan with 2007 SIM Questions
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I search "SIMStudyPlan2007" activity of behavioral mode "SkillBased" type
And I select the Cmenu option "Preview"
Then I should be on the "myitlab Study Plan Preview" page

