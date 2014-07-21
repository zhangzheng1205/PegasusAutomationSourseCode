Feature: CourseSpaceTeacher
	                As a CS Teacher 
					I want to manage all the coursespace teacher  related usecases 
					so that I would validate all the coursespace teacher scenarios are working fine.

#Purpose: Open CSTeacher Url
Background:
Given I browsed the login url for "DPCsTeacher"
When I login to Pegasus as "DPCsTeacher" in "CourseSpace"
Then I should be logged in successfully
Given I am on the "Home" page

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
Scenario: View Enrolled Classes in Classes Frame by CS Teacher
When I navigate to the "Classes" tab
Then I should see the Enrolled "DigitalPathMasterLibrary" in classes frame
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






