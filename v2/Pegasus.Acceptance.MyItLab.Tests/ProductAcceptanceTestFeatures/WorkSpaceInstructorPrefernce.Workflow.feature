Feature: WorkSpaceInstructor
	                As a Ws Instructor 
					I want to manage all the workspace Instructor related usecases 
					so that I would validate all the workspace Instructor scenarios are working fine.

#Purpose:Adding the SIM5 Question in the Manage Question Bank
## TestCase Id: HED_MIL_PWF_050
#MyItLabSIM5MasterCourse
Scenario: Adding the SIM5 Question in the Manage Question Bank
When I navigate to "Course Materials" tab and selected "Manage Question Bank" subtab
Then I should be on the "Question Bank" page
When I select 'Add Course Materials' option
And I select "Add SIM5 Question" option
Then I should be on the "SIM5 - Select Questions" page
When I add the question folder from sim repository
Then I should see the successfull message "Sim5 questions added successfully." in "Question Bank" window
And I should see the added question "WD Activity 1.02: Inserting Text from Another"
When I select cmenu "Preview" option for question "WD Activity 1.02: Inserting Text from Another"
Then I should be on the "SIM Question Preview" page
When I close the "SIM Question Preview" window
Then I should see the added question "XL Activity 1.02: Entering Text,"
When I select cmenu "Preview" option for question "XL Activity 1.02: Entering Text,"
Then I should be on the "SIM Question Preview" page
And I close the "SIM Question Preview" window

#Purpose:Necessary preference setting before publishing the SIM Course
## TestCase Id: HED_MIL_PWF_048
#MyItLabSIM5MasterCourse
Scenario: Workspace Instructor Sets General preference settings
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I click on the "General" tab
And I enable necessary general preference settings
Then I should see the successfull message "preferences updated successfully"
When I click on the "Catalog" tab
And I enable necessary catalog preference settings
Then I should see the successfull message "preferences updated successfully"
When I click on the "Course Materials" tab
And I disable 'Hide My Course materials on creation' preference
Then I should see the successfull message "preferences updated successfully"
When I click on the "Grading" tab
And I enable necessary grades preference settings
Then I should see the successfull message "preferences updated successfully"

#Purpose: To check the Workspace Instructor sets the preference for SIM 5 Course
## TestCase Id: HED_MIL_PWF_049
#MyItLabSIM5MasterCourse
Scenario: Workspace Instructor sets the preference for SIM 5 Course
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I click on the "Question" tab
And I enable 'Enable SIM5 questions' preference
Then I should see the successfull message "preferences updated successfully"

#Purpose: To check the Workspace Instructor sets the preference for Enable original SIM questions in Course
#MyItLabSIMMasterCourse
Scenario: Workspace Instructor sets the preference for original SIM questions in Course
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I click on the "Question" tab
And I enable 'Enable original SIM questions' preference
Then I should see the successfull message "preferences updated successfully"

#Purpose: Enabling preferences set for grader IT activity In SIM5 Course by Workspace Instructor 
## TestCase Id: HED_MIL_PWF_046
#MyItLabSIM5MasterCourse
Scenario: Enabling preferences set for grader IT activity In SIM5 Course by Workspace Instructor 
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I click on the "Question" tab
And I enable 'Grader Project' question type preference 
Then I should see the successfull message "preferences updated successfully"
When I click on the "Grading" tab
And I enable 'Display Integrity detection to students automatically for Grader projects' preference
Then I should see the successfull message "preferences updated successfully"

#Purpose: Enabling preferences set for grader IT activity In SIM Course by Workspace Instructor 
## TestCase Id: HED_MIL_PWF_098
#MyItLabSIMMasterCourse
Scenario: Enabling preferences set for grader IT activity In SIM Course by Workspace Instructor
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I click on the "General" tab
And I enable 'Enable Calendar' in general preference settings
Then I should see the successfull message "preferences updated successfully"
When I click on the "Question" tab
And I enable 'Grader Project' question type preference 
Then I should see the successfull message "preferences updated successfully"
When I click on the "Grading" tab
And I enable 'Display Integrity detection to students automatically for Grader projects' preference
Then I should see the successfull message "preferences updated successfully"
When I click on the "Course Materials" tab
And I disable 'Hide My Course materials on creation' preference
Then I should see the successfull message "preferences updated successfully"

#Purpose: UseCase To Set Preferences for Empty Course
#HedEmptyClass
Scenario: Set Preferences for Empty Course by Ws Teacher
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I set the preferences for Copy Content
Then I should see the successfull message "Preferences updated successfully."
