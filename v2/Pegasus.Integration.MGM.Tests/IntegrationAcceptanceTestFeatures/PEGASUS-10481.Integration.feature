Feature: PEGASUS-10481: Content Copy and Customize Content in MathXL
                  As a CS Admin 
				  I want to navigate inside Class by Enter Class as Teacher 
				  so that I can customize the content.	

#Purpose: Open CS Url
Background: 
Given I browsed the login url for "CsAdmin"
When I login to Pegasus as "CsAdmin" in "CourseSpace"
Then I should be logged in successfully

#Purpose: Navigate inside the Course through Cmenu option "Enter Class as Teacher" to Single customize content
Scenario: Navigate Inside Class by Enter Class as Teacher to Customize Single Content by CS Admin
Given I am on the 'Manage Organization' page of "School" level in the "DigitalPath"
When I navigate to the "Classes" tab
And I search "DigitalPathMasterLibrary" class in Coursespace
Then I should be able to see the searched "DigitalPathMasterLibrary" class
When I click on Enter Class as Teacher cmenu option of class in coursespace
Then I should see the "Select Course" popup
When I select the course and enter inside the course
Then I should see the default tabs for teacher view
When I navigate to the "Content" tab
And I click on masterlibrary in class content library
And I select the "Test" activity in class content library
And I Click on Add button
Then I should see the successfull message "Content item is added to My Course" in "Content" window
When I verify the copy state for contents in MyCourse Frame
Then I should see "Test" activity in the MyCourse Frame
When I click on "Edit" cmenu option of activity in "CsAdmin"
And I customize single content
Then I should see the successfull message "Activity updated successfully." in "Content" window 
When I navigate outside of the class from "Content" window
Then I should be on the "Manage Organization" page
When I close the "Manage Organization" window
And I "Sign out" from the "CsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Navigate inside the Course through Cmenu option "Enter Class as Teacher" to customize multiple content
Scenario: Navigate Inside Class by Enter Class as Teacher to Customize Multiple Content by CS Admin
Given I am on the 'Manage Organization' page of "School" level in the "DigitalPath"
When I navigate to the "Classes" tab
And I search "DigitalPathMasterLibrary" class in Coursespace
Then I should be able to see the searched "DigitalPathMasterLibrary" class
When I click on Enter Class as Teacher cmenu option of class in coursespace
Then I should see the "Select Course" popup
When I select the course and enter inside the course
Then I should see the default tabs for teacher view
When I navigate to the "Content" tab
And I click on masterlibrary in class content library
And I select the "Test" activity in class content library
And I select the "SkillStudyPlan" activity in class content library
And I Click on Add button
Then I should see the successfull message "Content item is added to My Course" in "Content" window
When I verify the copy state for contents in MyCourse Frame
Then I should see "Test" activity in the MyCourse Frame
When I click on "Edit" cmenu option of activity in "CsAdmin"
And I customize single content
Then I should see the successfull message "Activity updated successfully." in "Content" window 
When I search the content of type "SkillStudyPlan" in MyCourse Frame
And I click on "Edit" cmenu option of activity in "CsAdmin"
And I customize the content 'SkillStudyPlan'
Then I should see the successfull message "Study Plan updated successfully." in "Content" window
When I navigate outside of the class from "Content" window
Then I should be on the "Manage Organization" page
When I close the "Manage Organization" window
And I "Sign out" from the "CsAdmin"
Then I should see the successfull message "You have been signed out of the application."

	
