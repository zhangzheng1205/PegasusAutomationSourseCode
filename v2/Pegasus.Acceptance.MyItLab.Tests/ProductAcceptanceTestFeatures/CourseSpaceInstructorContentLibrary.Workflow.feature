Feature: CourseSpaceInstructorContentLibrary
	     As a Cs Instructor 
		I want to manage all the coursespace Content Library related usecases 
		so that I would validate all the coursespace Content Library scenarios are working fine.

#Purpose: To save an activity in Content Library with HelpLink
Scenario: To save an activity in Content Library with HelpLink
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option in Content Library
And I click on the "Homework" activity type
Then I should be on the "Create activity" page
When I create "Homework" activity of behavioral mode "BasicRandom" type using True-False question
Then I should see the successfull message "Activity added successfully."
When I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To Create a Skill based activity with Native and SIM5 questions
Scenario: To Create a Skill based activity with Native and SIM5 questions
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option in Content Library
And I click on the "Exam [Skill-Based]" activity type
Then I should be on the "Create activity" page
When I create a "SIM5Activity" of behavioral mode "SkillBased" type
And I add "SIM5" question in created "Exam [Skill-Based]" activity
And I add "Native" question as "True/False" in created activity and save this activity
Then I should see the successfull message "Activity added successfully."

#Purpose: To verify all native questions are present
Scenario: To verify all native questions are present
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option in Content Library
And I click on the "Exam [Skill-Based]" activity type
Then I should be on the "Create activity" page
When I create a "SIM5Activity" of behavioral mode "SkillBased" type
And I click on "Create New Question" link
Then I should be on the "Create New Question" page
And I should see all native questions present

#Purpose: To edit an activity in Content Library and preview the HelpLink
Scenario: To edit an activity in Content Library and preview the HelpLink
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on the Activity Name in Content Library frame
Then I should be on the "Edit Random activity" page
When I click on the HelpLinks activity subtab
Then I should be on the "Edit Random activity" page
When I click on the Preview link in c-menu of Helplink
Then I should be on the "Homework" page
When I close the "Homework" window
Then I should be on the "Edit Random activity" page
When I click on the "Cancel" button
Then I should be on the "Cancel Activity" page
When I click on the "Don't Save" button
Then I should be on the "Course Materials" page

#Purpose : To test functionality of Cut Copy Paste Delete, in Advanced Content Library for Multiple Assets by CS Instructor
Scenario: Cut Copy Paste Delete functionality in Advanced Content Library for Multiple Assets by CS Instructor
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I select Advanced Options link
And I select checkbox of 1 assets 
Then I should see "Copy" button on Content Library header get "Enabled"
When I select checkbox of 4 assets 
Then I should see "Copy" button on Content Library header get "Enabled"
When I select "Copy" button on Content Library header
Then I should see Clipboard Items Count as 3
And I should see Asset title in "Red" color and "Italic" style. 
When I select "Paste" button on Content Library header
And I Select "PasteAtTop" on Paste Advanced Options on Content Library
Then I should see the successfull message "Items copied successfully."
And I should see Asset displayed at "Top" place
When I select checkbox of 3 assets 
Then I should see "Cut" button on Content Library header get "Enabled"
When I select "Cut" button on Content Library header
Then I should see Clipboard Items Count as 3
And I should see Asset title in "Red" color and "Italic" style. 
When I select "Paste" button on Content Library header
And I Select "PasteAtBottom" on Paste Advanced Options on Content Library
When I select checkbox of 3 assets 
Then I should see "Delete" button on Content Library header get "Enabled"
When I select "Delete" button on Content Library header
Then I should see a "Delete" confirmation pop up should display with "OK" button and "Cancel" button
When I click on OK button on Delete confirmation pop up 
Then I should see the successfull message "Items deleted successfully."