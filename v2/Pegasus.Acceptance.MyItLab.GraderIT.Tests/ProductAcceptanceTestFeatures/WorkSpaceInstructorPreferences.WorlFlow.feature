Feature: WorkSpaceInstructorPreferences
					As a Ws Instructor 
					I want to manage all the workspace Instructor Preferences related usecases 
					so that I would validate all the workspace Instructor scenarios are working fine.

Background:
#Purpose: Open Ws Url 
Given I browsed the login url for "HedWsInstructor"
When I logged into the Pegasus as "HedWsInstructor" in "WorkSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose:Adding the GraderItSIM5 Question in the Manage Question Bank
Scenario: Adding the GraderItSIM5 Question in the Manage Question Bank
When I enter in the "GraderITSIM5Course" from the Global Home page as "HedWsInstructor"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
And I navigate to the "Manage Question Bank" tab
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
When I close the "SIM Question Preview" window
And I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose:Necessary preference setting before publishing the SIM Course
Scenario: Workspace Instructor Sets General preference settings
When I enter in the "GraderITSIM5Course" from the Global Home page as "HedWsInstructor"
Then I should be on the "Today's View" page
When I navigate to the "Preferences" tab
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
And I enable 'Display Integrity detection to students automatically for Grader projects' preference
Then I should see the successfull message "preferences updated successfully"
When I click on the "Question" tab
And I enable 'Enable SIM5 questions' preference
And I enable 'Grader Project' question type preference
Then I should see the successfull message "preferences updated successfully"

#Purpose: UseCase To Set Preferences for Empty Course
Scenario: Set Preferences for Empty Course by Ws Teacher
When I enter in the "HedEmptyClass" from the Global Home page as "HedWsInstructor"
And I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I set the preferences for Copy Content
Then I should see the successfull message "Preferences updated successfully."