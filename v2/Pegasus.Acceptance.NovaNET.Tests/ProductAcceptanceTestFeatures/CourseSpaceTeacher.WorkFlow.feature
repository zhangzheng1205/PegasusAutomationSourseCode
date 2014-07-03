﻿Feature: CourseSpaceTeacher
	                 As a CS Teacher 
					I want to manage all the coursespace teacher  related usecases 
					so that I would validate all the coursespace teacher scenarios are working fine.

#Purpose : Open the CS url 
Background: 
Given I browsed the login url for "NovaNETCsTeacher"
When I login to Pegasus as "NovaNETCsTeacher" in "CourseSpace"
Then I should be logged in successfully
Given I am on the "Global Home" page
					 
#Purpose : To View Activity Alerts by CS teacher
Scenario: View Activity Alerts by CS Teacher
When I enter in the "NovaNETMasterLibrary" course as "NovaNETCsTeacher" from the Global Home page
And I navigate to the "Overview" tab
Then I should be on the "Overview" page
And I should see the alert for New Grades
When I select New Grades option
Then I should see name of submitted activity as "Posttest"
When I "Sign Out" from the "NovaNETCsTeacher"
Then I should see the "Signed Out" message

#Purpose : To Create Course by CS teacher
Scenario: Create Course by CS Teacher
When I navigate to the "Classes" tab
And I select the 'Create Course' option in 'Classes' Page
And I create the course using master libraries
Then I should see the successfull message "Item created successfully."
When I "Sign Out" from the "NovaNETCsTeacher"
Then I should see the "Signed Out" message

#Purpose: UseCase to User Enrollment by CS Teacher
Scenario: User Enrollment by Cs Teacher
When I enter in to "NovaNETTemplate" class
And I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
When I enable roster in Preferences tab
Then I should see the successfull message "Preferences updated successfully"
When I navigate to the "Enrollments" tab
And I navigate to the "Roster" tab
And I create "NovaNETCsClassStudent" user as coursespace teacher
Then I should see the successfull message "User has been created successfully."
When I "Sign Out" from the "NovaNETCsTeacher"
Then I should see the "Signed Out" message

#Purpose : To Verify The Functionality of Teacher Manage announcements
#Usecase ID : NN_PWF_288
Scenario: To Verify The Functionality of Teacher Manage announcements by CS Teacher
When I click on the 'Manage All' button in global home
And I create "Class" Announcement in coursespace
Then I should see the successfull message "Announcement created successfully." in Announcements Frame
When I click on the 'Manage All' button in global home
And  I select "Class Announcements" in 'View by' drop down  
Then I should see the details of  "Class" Announcement in Announcement Light box
When I "Sign Out" from the "NovaNETCsTeacher"
Then I should see the "Signed Out" message	

#Purpose : Teacher Manages Enrollments During Class Creation
#Usecase ID : NN_PWF_273
Scenario: Teacher Manages Enrollments During Class Creation by CS Teacher
When I click on 'Create Class' button in Global home
Then I should see the "Create Class" popup
When I create the class using "Container" template in Global Home
And I select the user from create class window
Then I should see the "Add User" popup
When I create a new "DPCsTeacher" user in Coursespace Global Home
Then I should see the successfull message "New users added successfully." in Create Class Popup
When I "Sign Out" from the "NovaNETCsTeacher"
Then I should see the "Signed Out" message	
