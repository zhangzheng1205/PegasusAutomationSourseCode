Feature: TestBedPreparation
			In order to preparation od bed that will takes care of particular activity 
			As a different user roles
			So that once the test bed is ready then we start executing the test cases as already documented.

# Assign Assets in My Course Frame
Scenario: To Assign Content In My Course Frame For Test Bed Preparation
When I navigate to "Course Materials" tab
And I selected activity "Access Chapter 1: End-of-Chapter Quiz" and add in My Course frame
Then I should see the successfull message "Content item is added to My Course"
When I selected all activity and change the status from "Hidden"

# Set Activity Properties In My Course Frame
Scenario: To Set Activity Properties In My Course Frame For Test Bed Preparation
When I navigate to "Course Materials" tab
And I search the activity "Access Chapter 1: End-of-Chapter Quiz" in My Course frame
And I select cmenu "Properties" option of activity "Access Chapter 1: End-of-Chapter Quiz"
And I set the properties for activity "Access Chapter 1: End-of-Chapter Quiz"
Then I should see the successfull message "Properties updated successfully."

# Set Activity Level Preferences In My Course Frame
Scenario: To Set Activity Level Preferences In My Course Frame For Test Bed Preparation
When I navigate to "Course Materials" tab
And I search the activity "Access Chapter 1: End-of-Chapter Quiz" in My Course frame
And I select cmenu "Edit" option of activity "Access Chapter 1: End-of-Chapter Quiz"
And I select "Edit Random activity" page and select "Preferences" Tab
And I set the activity level preferences for "Access Chapter 1: End-of-Chapter Quiz"
Then I should see the successfull message "Activity updated successfully."

