Feature: CourseSpaceTeacher
	                As a CS Teacher 
					I want to manage all the coursespace teacher  related usecases 
					so that I would validate all the coursespace teacher scenarios are working fine.

#Purpose: To View CS System Announcement
Scenario: View System Announcement by CS Teacher
When I navigate to the "Home" tab
Then I should be on the "Home" page
When I changed the CS User Time Zone to Indian GMT in MyProfile by "DPCsTeacher"
And I click on the Messages and select the View All link by "DPCsTeacher"
And  I select "System Announcements" in 'View by' drop down  
Then I should see the details of  "CsSystem" Announcement in Announcement Light box

#Purpose: To Create Class Announcement
Scenario: Create Class Announcement by CS Teacher
When I navigate to the "Home" tab
Then I should be on the "Home" page
When I click on the Messages and select the View All link by "DPCsTeacher"
And I create "CsCourse" Announcement in coursespace
Then I should see the successfull message "Announcement created successfully." in Announcements Frame

#Purpose: To Create Class Announcement
Scenario: Create Course Announcement by CS Teacher
When I navigate to the "Home" tab
Then I should be on the "Home" page
When I enter into the "DigitalPathMasterLibrary" class 
When I create CS Course Announcement
Then I should see the successfull message "Announcement created successfully." in Announcements Frame
When I navigate to the "Home" tab
Then I should be on the "Home" page

#Purpose: UseCase To View the welcome message as teacher
Scenario: View Welcome Message by CS Teacher
When I navigate to the "Home" tab
Then I should be on the "Home" page
Then I should see the welcome message
When I close the welcome message
Then I should see the welcome message popup closed successfully for "DPCsTeacher"

#Purpose: UseCase To Validate Home Page tabs
Scenario: View Home Page Tabs by CS Teacher
When I navigate to the "Home" tab
Then I should be on the "Home" page
Then I should see the Home Page tabs 

#Purpose: UseCase To Check Enrolled classes in classes frame
Scenario: To Verify Tab Navigation by CS Teacher
When I navigate to the "Classes" tab
Then I should be on the "Classes" page
When I navigate to the "Home" tab
Then I should be on the "Home" page

#Purpose: UseCase To Check Basal Products in the Curriculum Channel
Scenario: View Basal Products in the Curriculum Channel by CS Teacher
When I navigate to the "Curriculum" tab
Then I should see the "DigitalPath" Product in the Curriculum Channel
When I navigate to the "Home" tab
Then I should be on the "Home" page

#Purpose: AccessClass By Teacher 
Scenario: Access Class by CS Teacher
When I navigate to the "Home" tab
Then I should be on the "Home" page
When I click on the Add button 
Then I should be able to see the "DigitalPath" product
When I click on the Cancel button
Then I should able to see the "DigitalPathMasterLibrary" class
When I enter into the "DigitalPathMasterLibrary" class 
Then I should be on the "Classes" page
When I navigate to the "Planner" tab
Then I should be on the "Planner" page

#Purpose : Basic Search in Curriculum tab
Scenario: Basic Search in Curriculum Tab by CS Teacher
When I navigate to the "Curriculum" tab
And I search the asset type "Test" by "TableofContents" criteria
Then I should see the searched asset "Test"
When I clear the searched result
Then I should not see the searched result
When I search the asset type "Test" by "Skill" criteria
Then I should see the searched asset "Test"
When I clear the searched result
Then I should not see the searched result
When I search the asset type "Test" by "ContentType" criteria
Then I should see the searched asset "Test"
When I clear the searched result
Then I should not see the searched result

#Purpose : Advanced Search in Curriculum tab
Scenario: Advanced Search in Curriculum Tab by CS Teacher
When I navigate to the "Curriculum" tab
And I search the asset type "Test" in "Curriculum" tab using Advanced Search
Then I should see the searched asset "Test"
When I clear the searched result
Then I should not see the searched result

#Purpose : Basic Search in planner tab
Scenario: Basic Search in Planner Tab by CS Teacher
When I navigate to the "Planner" tab
And I search the asset "Test"
Then I should see the searched asset "Test" successfully
When I clear the searched result in planner tab
Then I should not see the searched result in planner tab

#Purpose : Advanced Search in planner tab
Scenario: Advanced Search in Planner Tab by CS Teacher
When I navigate to the "Planner" tab
And I search the asset type "Test" in "Planner" tab using Advanced Search
Then I should see the searched asset "Test" in planner tab
When I clear the searched result in planner tab
Then I should not see the searched result in planner tab

#Purpose : Customize Content
Scenario: Customize Content In Curriculum Tab by CS Teacher
When I navigate to the "Curriculum" tab
And I customize the content "Test" in curriculum tab
Then I should see the successfull message "You have successfully added custom content." in Curriculum tab
When I click on the custom content link
Then I should see the ML in the custom content view
When I click on the expand button of MasterLibrary in the custom content view
Then I should see the customized "Test" content of the ML in the custom content view
When I navigate to the "Home" tab
Then I should be on the "Home" page

#Purpose: Creation Licenced Assets in Global by CS Teacher 
Scenario: Create Licenced Assets in Global by CS Teacher
When I navigate to the "Home" tab
Then I should be on the "Home" page
When I click The "Custom Content" link in Home Page
Then I should see the "MasterLibrary" course in the custom content view
When I mouseover on the Licensed content
And I create the global "Licensed" content "Test" activity and 'TrueFalse' question in global 
Then I should see the successfull message "Activity added successfully." in Curriculum tab

#Purpose: Creation NonLicenced TestAssets in Global by CS Teacher
Scenario: Create NonLicenced TestAssets in Global by CS Teacher
When I navigate to the "Home" tab
Then I should be on the "Home" page
When I click The "Custom Content" link in Home Page
Then I should see the "MasterLibrary" course in the custom content view
When I Create the custom content "Folder" activity global
Then I should see the successfull message "Folder saved successfully." in Curriculum tab
When I mouseOver on the NonLicensed Assets
And I create the global "NonLicensed" content "Test" activity and 'TrueFalse' question in global 
Then I should see the successfull message "Activity added successfully." in Curriculum tab

#Purpose: Creation NonLicenced LinkAssets in Global by CS Teacher
Scenario: Create NonLicenced LinkAssets in Global by CS Teacher
When I navigate to the "Home" tab
Then I should be on the "Home" page
When I click The "Custom Content" link in Home Page
Then I should see the "MasterLibrary" course in the custom content view
When I create the nonGgadable "Link" activity 
Then I should see the successfull message "Link saved successfully." in Curriculum tab

#Purpose: Copy paste of licensed assets by CS Teacher 
Scenario: Copy paste of Licensed Assets by CS Teacher 
When I navigate to the "Home" tab
Then I should be on the "Home" page
When I click The "Custom Content" link in Home Page
Then I should see the "MasterLibrary" course in the custom content view
When I click on the expand button of MasterLibrary in the custom content view
And I should able to see the "Licensed" customized content "Test" Assets
And I select the "Licensed" CopyPaste link 
Then I should see the successfull message "Items copied successfully." in Curriculum tab
When I Clear the Clipboard link
And I click on the expand button of MasterLibrary in the custom content view
And I remove the "Licensed" copied content
Then I should see the successfull message "Items deleted successfully." in Curriculum tab
When I should able to see the "Licensed" customized content "Test" Assets
And I select the "Licensed" CutPaste link
Then I should see the successfull message "Selected items moved successfully." in Curriculum tab

#Purpose: Copy paste of NonLicensed Assets by CS
Scenario: Copy paste of NonLicensed Assets by CS Teacher 
When I navigate to the "Home" tab
Then I should be on the "Home" page
When I click The "Custom Content" link in Home Page
Then I should see the "MasterLibrary" course in the custom content view
When I click on the expand button of Non licensed Folder
And I should able to see the "NonLicensed" customized content "Test" Assets
And I select the "NonLicensed" CopyPaste link
Then I should see the successfull message "Items copied successfully." in Curriculum tab
When I Clear the Clipboard link
And I click on the expand button of Non licensed Folder
And I remove the "NonLicensed" copied content
Then I should see the successfull message "Items deleted successfully." in Curriculum tab
When I should able to see the "NonLicensed" customized content "Test" Assets
And I select the "NonLicensed" CutPaste link
Then I should see the successfull message "Selected items moved successfully." in Curriculum tab

#Purpose: Sending Messages to Users
Scenario: Sending Mail Message by CS Teacher
When I navigate to the "Home" tab
Then I should be on the "Home" page
When I create mail by "DPCsTeacher" in CourseSpace
And I send created mail to CourseSpace users
Then I should see the successfull message "Your message has been sent." in the send mail popup
When I close the mail popup
Then I should see the mail popup closed successfully

#Test case id: peg-22536
#Purpose: Validate assigned LCC display in Manage courework  tab
Scenario: Teacher validates the display of assigned LCC in Manage course work
When I navigate to the "Home" tab
Then I should be on the "Home" page
When I enter into the DP "Class digits 6" class
Then I should be on the "Classes" page
When I navigate to the "Manage Coursework" tab
Then I should see assigned LCC "1-1 Homework"
And I should see status as "Not started" for LCC "1-1 Homework"
And I should see the due date for LCC "1-1 Homework"
And I should see "All" text in Shown to column for LCC "1-1 Homework"
And I should see Assigned icon for LCC "1-1 Homework"

#Test case id: peg-12653
#Purpose: Teacher enrolling students to Class
#Product: Digital Path
Scenario: Teacher validating the student enrollment to class
When I navigate to the "Home" tab
And I click on Cmenu option of Class "DigitalPathMasterLibrary" and select "Enrollments" option
Then I should see the "Manage Students" popup
When I Click on Create New button
And I select "Enroll from School" drop down option
Then I should see the "Enroll from School" popup
When I click on Search button
And I enter student username "dpstud152015" to search
Then I should see searched username "dpstud152015" in search list
When I select the student and click on Add button
Then I should see the success message "Users enrolled successfully."
When I close Enroll from school pop up
Then I should see "Enroll from School" pop up closed
And I should see the student "dpstud152015" displayed in manage student pop up
When I close Manage student pop up

#Test case id: peg-22538
#Purpose: To validate display of assigned study plan in class course
Scenario: Teacher validating display of assigned study plan under manage coursework on current date
When I navigate to the "Home" tab
And I enter into the DP "DigitalPathMasterLibrary" class
Then I should be on the "Classes" page
When I navigate to the "Manage Coursework" tab
Then I should see assigned study plan "Topic 1 Test with Study Plan"
And I should see status as "Begin" for study plan "Topic 1 Test with Study Plan"
And I should see the due date for study plan "Topic 1 Test with Study Plan"
And I should see "All" text in Shown to column for study plan "Topic 1 Test with Study Plan"
And I should see Assigned icon for study plan "Topic 1 Test with Study Plan"

#Test case id: peg-22537
#Purpose: To validate display of assigned Math XL activity in class course
Scenario: Teacher validating display of assigned Math XL activity under manage coursework on current date
When I navigate to the "Home" tab
And I enter into the DP "DigitalPathMasterLibrary" class
Then I should be on the "Classes" page
When I navigate to the "Manage Coursework" tab
Then I should see assigned MathXL activity "Topic 1 Test"
And I should see status as "Not started" for MathXL activity "Topic 1 Test"
And I should see the due date for MathXL activity "Topic 1 Test"
And I should see "All" text in Shown to column for MathXL activity "Topic 1 Test"
And I should see Assigned icon for MathXL activity "Topic 1 Test"


#Test case id: peg-1456
#Purpose: To create DP class by teacher
Scenario: Class creation from classes channel
When I navigate to the "Home" tab
And I click on Create button
Then I should see "Setup Wizard" light box
When I enter class name of "DigitalPathMasterLibrary"
And I click on Select product button
Then I should see "Select Product" page
When I select product and Click on Manage enrollments button
Then I should see "Manage Enrollments" page
When I click on Save Class button
Then I should see the successfull message "Your class has been successfully created and saved." in setup wizard
When I click No,Save and Exit button
Then I should see "DigitalPathMasterLibrary" class displayed in classes channel


