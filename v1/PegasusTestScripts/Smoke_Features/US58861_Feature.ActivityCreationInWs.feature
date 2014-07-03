#Purpose: Feature Description
Feature: US58861 - Manage Activity Creation and Association
In order to Create Activity
As a WS Teacher
I want to create a activity and associate into MyCourse frame

@initial_setup
#Purpose: Open Ws Url
Background: 
Given I have browsed url for "WSTeacher"
When I have logged into the work space as WS Teacher  
Then  It should show the "Global Home" page

@CreateSkillStudyPlan @ignore
#Purpose: UseCase To Create Skill Study Plan
Scenario: Create Skill study plan in the Add Content from Library
Given I am on the "Global Home" page
When I select the course name with prefix BDDML
Then It should show the "Overview" page
And I navigate to the "Preference" Tab
When I selected the 'Standards and Skills' sub tab
And I Add new frameworks
Then It should display successful message "Selected frameworks successfully added to current course."
And I saved the preferences
Then It should display successful message "Preferences updated successfully."
And I navigate to the "Content" Tab
When I selected the 'More' dropdown link
And I selected the "Map Questions to Skills" sub tab
And Map the questions to the skill
And I select the "Add Content from Library" sub tab
When I select 'Skill Study Plan' activity type
And I create 'Skill Study Plan - Pre test / Post test
Then It should display successful message "Study Plan added successfully."
#And I clicked on the Logout link to get logged out from the application
And I select the Home button to go back on Global Home page
  
@AssociateActivityToMyCourseFrame @ignore
#Purpose: UseCase To Associate Activity to My Course
Scenario: Associate Activity to My Course frame
Given I am on the "Global Home" page
When I select the course name with prefix BDDML
Then It should show the "Overview" page
And I navigate to the "Content" Tab
When I select the MathXL activity
And I Click on the Add button
Then It should display successful message "Content item is added to My Course"
When I clicked on the Search/View button in "ifrmRight" frame
When I unhide the activity from right frame
And  I clicked on the Logout link to get logged out from the application



	
