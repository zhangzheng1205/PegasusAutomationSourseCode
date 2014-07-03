#Purpose: Feature Description
Feature: US58871_User Enrollment In Class
In order to Enroll User 
As a Pearson Admin 
I want to enroll user(s) into class as Teacher and Student

#Purpose: Open Cs Url
Background: 
Given I have browsed url for "CS Admin"
When  I have logged into the Course space as CSAdmin  

#Purpose: UseCase To enroll Teacher to class
Scenario: Create Teacher Enrollment in Class 
Given I am on the 'Manage Organization' page 
And   I navigate to the "Enrollment" Tab
And   I Select the "Template" class
When  I select the "Teacher" under User Frame
And   I click on the 'Enroll in Selected' button
Then  It should display successful message "Users enrolled successfully." in "Manage Organization" page
And  I Update the Enroll status in DB for "CsTeacher" Enrollment

#Purpose: UseCase To enroll student to class
Scenario: Create Student Enrollment in Class 
Given I am on the 'Manage Organization' page 
And   I navigate to the "Enrollment" Tab
And   I Select the "Template" class
When  I select the "Student" under User Frame
And   I click on the 'Enroll in Selected' button
Then  It should display successful message "Users enrolled successfully." in "Manage Organization" page
And  I Update the Enroll status in DB for "CsStudent" Enrollment
And   I close the Manage Organization Window and log out from the application
