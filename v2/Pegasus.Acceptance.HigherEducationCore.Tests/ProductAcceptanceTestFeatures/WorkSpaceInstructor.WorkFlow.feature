﻿Feature: WorkSpaceInstructor
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


