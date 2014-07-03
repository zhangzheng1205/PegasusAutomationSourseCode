Feature: PEGASUS-2119 Hide Grace Period preference for SIM study plan [Pretest/Posttest]
						As a Hed Mil Instructor
						I want to verify presence of Grace Period preference for SIM study plan [Pretest/Posttest]
						so that setting "Grace Period preference" should be hidden.

#Purpose: Open HigherEducation coursespace URL
Background:  
Given I browsed the login url for "HedMilAcceptanceInstructor"
When I logged into the Pegasus as "HedMilAcceptanceInstructor" in "CourseSpace"
Then I should logged in successfully

#Purpose : Check visbility of questions tab for Basic Random Badged activity
Scenario: To make sure "Enable Grace Period" setting is hidden in CourseSpace
Given I am on the "Global Home" page
When I enter in the "HedMilAcceptanceSIMProgramCourse" from the Global Home page as "HedMilAcceptanceInstructor"
Then I should be on the "Program Administration" page
When I select the "Sections" tab
Then I should see the Section created from "HedMilAcceptanceSIMProgramCourse" course Template to be successfully out of AssignedToCopy state
When I click the "Enter Section as Instructor"
And I navigate to the "Preference" tab
Then I should be on the "Preferences" page
When I click on the "Study Plan" tab
Then I should see the "Customize Study Plan" in the page
When I click on "Edit" link of "PreTest"
Then I should be on the "Default preferences" page
When I select the "Timing" tab
Then I should not see the "Enable Grace Period" in the page
When I click on "Cancel" button in "Default preferences"
Then I should be on the "Preferences" page
When I click on "Edit" link of "PostTest"
Then I should be on the "Default preferences" page
When I select the "Timing" tab
Then I should not see the "Enable Grace Period" in the page
When I click on "Cancel" button in "Default preferences"
Then I should be on the "Preferences" page
When I "Sign out" from the "HedMilAcceptanceInstructor"
Then I should see the successfull message "You have been signed out of the application."