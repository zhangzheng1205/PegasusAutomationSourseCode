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
When I select "DigitalPathCustomContent" Product in the Curriculum dropdown
Then I should see the ML in the custom content view
When I click on the expand button of "MasterLibrary" in the custom content view
Then I should see the customized "Test" content of the ML in the custom content view

#Purpose: Teacher assign customized content and validate print tool
Scenario: Teacher customize the content and assign customized content
When I navigate to the "Curriculum" tab
And I customize the content "Test" in curriculum tab
Then I should see the successfull message "You have successfully added custom content." in Curriculum tab
When I select "DigitalPathCustomContent" Product in the Curriculum dropdown
Then I should see the ML in the custom content view
When I click on the expand button of "MasterLibrary" in the custom content view
When I select "Assign" cmenu option of "Test" in table of contents 
And I set the due date for the "Test" activity in curriculum
And I select "Print" cmenu option of "Test" in table of contents 
Then I should see the "Download" option in print window
And I close the "Print tool" window

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







#Purpose: To validate the Activity result by student report generation from teacher user.
Scenario: Generate and save the "Activity Results by Student" as a teacher
When I navigate to the "Reports" tab in DP class
And I click on "Activity Results by Student" report link as "DPCsTeacher"
And I select "Topic 2 Test" asset in "Select Activity" by "DPCsTeacher"
And I 'Select All' in 'Student Options' by "DPCsTeacher"
And I select 'save settings to My Reports' option by "DPCsTeacher"
And I click on the "Run Report" button in reports by "DPCsTeacher"
Then I should see "Save settings to My Reports" popup
When I select "Createnewreport" radiobutton
And  I enter the "DPActivityResultsByStudent" report name
And  I click on "SaveandRun" button
Then I should be on the "Report: Activity Results by Student" popup
And I should see the "Topic 2 Test" with course name "MasterLibrary" with average score "70%" 
And I should see the "MathXL Test" as Activity type
And I should see the "70%" in Percent column for "DPCsStudent" in "ARBS" report
When I close the "Report: Activity Results by Student" window
And I click on the "Cancel" button in reports by "DPCsTeacher"
And I select "Run Report" for "DPActivityResultsByStudent" report in 'My Reports' grid by "DPCsTeacher"
Then I should be on the "Report: Activity Results by Student" popup
When I close the "Report: Activity Results by Student" window

#Purpose: To validate the Student result by activity report generation from teacher user.
Scenario: Generate and save the "Student Results by Activity" as a teacher
When I navigate to the "Reports" tab in DP class
And I click on "Student Results by Activity" report link as "DPCsTeacher"
And I select "DPCsStudent" student in "Select Student" by "DPCsTeacher"
And I select "Topic 2 Test" asset in "Select Activities" by "DPCsTeacher"
And I select 'save settings to My Reports' option by "DPCsTeacher"
And I click on the "Run Report" button in reports by "DPCsTeacher"
Then I should see "Save settings to My Reports" popup
When I select "Createnewreport" radiobutton
And  I enter the "DPStudentResultByActivity" report name
And  I click on "SaveandRun" button
Then I should be on the "Report: Student Results by Activity" popup
Then I should see the course name "MasterLibrary" for "DPCsStudent" with average score "70%" 
And I should see "Topic 2 Test" "MathXL Test" details in the report
And I should see the "70%" in Percent column for "DPCsStudent" in "SRBA" report
When I close the "Report: Activity Results by Student" window
And I click on the "Cancel" button in reports by "DPCsTeacher"
And I select "Run Report" for "DPStudentResultByActivity" report in 'My Reports' grid by "DPCsTeacher"
Then I should be on the "Report: Student Results by Activity" popup
When I close the "Report: Student Results by Activity" window

#Purpose: To validate the Student Activity report generation from teacher user.
Scenario: Generate and save the "Student Activity" report as a teacher
When I navigate to the "Reports" tab in DP class
And I click on "Student Activity" report link as "DPCsTeacher"
And I select "DPCsStudent" student in "Select Students" by "DPCsTeacher"
Then I should see the added Student "DPCsStudent" in Report criteria page
When I select 'save settings to My Reports' option by "DPCsTeacher"
And I click on the "Run Report" button in reports by "DPCsTeacher"
Then I should see "Save settings to My Reports" popup
When I select "Createnewreport" radiobutton
And  I enter the "DPStudentActivity" report name
And  I click on "SaveandRun" button
Then I should be on the "Student Activity Report" popup
And I should see "Student" data
And I should see "Class" data
And I should see "Course" data
And I should see "Start Date" data
And I should see "Last Attempt" data
And I should see "Days Online" data
And I should see "Time on Task" data
When I Click on Detailed Report button
Then I should see "Detailed Student Activity Report" popup
And I should see "Date" data in detailed student activity pop up
And I should see "Sign On" data in detailed student activity pop up
And I should see "Sign Off" data in detailed student activity pop up
And I should see "Session Duration" data in detailed student activity pop up
When I expand the date in detailed student activity report pop up
Then I should see "Activity" data in detailed student activity pop up
And I should see "Time" data in detailed student activity pop up
And I should see "Start Time" data in detailed student activity pop up
And I should see "End Time" data in detailed student activity pop up
And I should see "Activity Status" data in detailed student activity pop up
And I should see "Score" data in detailed student activity pop up
When I close the "Detailed Student Activity Report" window
Then I should be on the "Student Activity Report" popup
When I close the "Student Activity Report" window
And I click on the "Cancel" button in reports by "DPCsTeacher"
Then I should be on the "Classes" page
When I select "Run Report" for "DPStudentActivity" report in 'My Reports' grid by "DPCsTeacher"
Then I should be on the "Student Activity Report" popup
When I close the "Student Activity Report" window

#Purpose: To validate the "Individual Student Mastery" report generation from teacher user.
Scenario: Generate and save the "Individual Student Mastery" as a teacher
When I navigate to the "Reports" tab in DP class
And I click on "Individual Student Mastery" report link as "DPCsTeacher"
And I select "DPCsStudent" in "Select Students" by "DPCsTeacher" in "IndividualStudentByGroup"
Then I should see the added Student "DPCsStudent" in Report criteria page
When I select the "Skill" radio button
And I click on Select Standards button
And I select "digits - grade 6 skills" skills from the drop down
When I select 'save settings to My Reports' option by "DPCsTeacher"
And I click on the "Run Report" button in reports by "DPCsTeacher"
Then I should see "Save settings to My Reports" popup
When I select "Createnewreport" radiobutton
And  I enter the "IndividualStudentMasteryReport" report name
And  I click on "SaveandRun" button
Then I should be on the "Mastery Report" popup
And I should see the "DigitalPathMasterLibrary" class with course name "MasterLibrary"
When I close the "Mastery Report" window
And I click on the "Cancel" button in reports by "DPCsTeacher"

#Purpose: To validate the "Class Mastery" report generation from teacher user.
Scenario: Generate and save the "Class Mastery" as a teacher
When I navigate to the "Reports" tab in DP class
And I click on "Class Mastery" report link as "DPCsTeacher"
When I select the "Skill" radio button
And I click on Select Standards button
And I select "digits - grade 6 skills" skills from the drop down
And I select a "DPCsStudent" in "Select Students"
And I select 'save settings to My Reports' option by "DPCsTeacher"
And I click on the "Run Report" button in reports by "DPCsTeacher"
Then I should see "Save settings to My Reports" popup
When I select "Createnewreport" radiobutton
And  I enter the "ClassMasteryReport" report name
And  I click on "SaveandRun" button
Then I should be on the "Mastery Report" popup
And I should see the "DigitalPathMasterLibrary" class with course name "MasterLibrary"
When I close the "Mastery Report" window
And I click on the "Cancel" button in reports by "DPCsTeacher"

#Test case id: peg-1456
#PEGASUS-27282
#Purpose: To create DP class by teacher
#Product: Digital Path
Scenario: Class creation from classes channel
When I navigate to the "Home" tab
Then I should be on the "Home" page
When I click on Create button
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

#Test case id: peg-12670
#PEGASUS-35401
#Purpose: To Add the Product in Curriculumn Channel.
#Product: Digital Path
Scenario: Add Product In Home Page
When I navigate to the "Home" tab
Then I should be on the "Home" page
When I Click on Add button 
And  I select "DigitalPath" Product
When I Click on the Save button 
Then I should see the successfull message "Your products have been successfully added." on setup wizard
When I Click On the Save and Exit button
Then I should see the product "DigitalPath" in the Curriculum channel

#Test case id: peg-12653
#PEGASUS-31824
#Purpose: Teacher enrolling students to Class
#Product: Digital Path
Scenario: Teacher validating the student enrollment to class
When I navigate to the "Home" tab
Then I should be on the "Home" page
When I click on Cmenu option of Class "DigitalPathMasterLibrary" and select "Enrollments" option
Then I should see the "Manage Students" popup
When I Click on Create New button
And I select "Enroll from School" drop down option
Then I should see the "Enroll from School" popup
When I click on Search button
And I enter student username "DPCsStudent" to search
Then I should see searched username "DPCsStudent" in search list
When I select the student and click on Add button
Then I should see the success message "Users enrolled successfully."
When I close Enroll from school pop up
Then I should see "Enroll from School" pop up closed
And I should see the student "DPCsStudent" displayed in manage student pop up
When I close Manage student pop up


#Purpose: DigitalPath teacher select product from the curriculum channel.
Scenario:Select product from Curriculum dropdown
When I navigate to the "Curriculum" tab
Then I should be on the "Curriculum" page
When I select "DigitalPath" Product in the Curriculum dropdown
Then I should see the "DigitalPath" Product in the Curriculum Channel

#Purpose: DigitalPath teacher assign Practice test from curriculum channel.
Scenario:Assign Practice test from curriculum channel
When I navigate to the "Curriculum" tab
Then I should be on the "Curriculum" page
When I select "Assign" cmenu of "i1-2 Practice" in table of content
And I click on Ok button in Alert pop up
Then I should see "Assign" pop up
When I set the due date for the "Test" activity in curriculum

#Purpose: DigitalPath Teacher select class from Class selector dropdown.
Scenario: Select DigitalPath class from Class selector dropdown by Teacher
When I navigate to the "Classes" tab
Then I should be on the "Classes" page
When I select DigitalPath class "DigitalPathMasterLibrary" from Class selector dropdown
Then I should able to see the "DigitalPathMasterLibrary" class


#Test case id: peg-22536
#Purpose: Validate assigned LCC display in Manage courework  tab
Scenario: Teacher validates the display of assigned LCC in Manage course work
When I navigate to the "Home" tab
Then I should be on the "Home" page
When I enter into the DP "DigitalPathMasterLibrary" class
Then I should be on the "Classes" page
When I navigate to the "Manage Coursework" tab
Then I should be on the "Classes" page
Then I should see assigned LCC "1-1 Homework"
And I should see status as "Not started" for LCC "1-1 Homework"
And I should see the due date for LCC "1-1 Homework"
And I should see "All" text in Shown to column for LCC "1-1 Homework"
And I should see Assigned icon for study plan "1-1 Homework"

#Test case id: peg-22537
#Purpose: To validate display of assigned Math XL activity in class course
Scenario: Teacher validating display of assigned Math XL activity under manage coursework on current date
When I navigate to the "Home" tab
Then I should be on the "Home" page
When I enter into the DP "DigitalPathMasterLibrary" class
Then I should be on the "Classes" page
When I navigate to the "Manage Coursework" tab
Then I should be on the "Classes" page
Then I should see assigned MathXL activity "Topic 1 Test"
And I should see status as "Not started" for MathXL activity "Topic 1 Test"
And I should see the due date for MathXL activity "Topic 1 Test"
And I should see "All" text in Shown to column for MathXL activity "Topic 1 Test"
And I should see Assigned icon for MathXL activity "Topic 1 Test"

#Test case id: peg-22538
#Purpose: To validate display of assigned study plan in class course
Scenario: Teacher validating display of assigned study plan under manage coursework on current date
When I navigate to the "Manage Coursework" tab
Then I should see assigned study plan "Topic 2 Test with Study Plan"
And I should see status as "Begin" for study plan "Topic 2 Test with Study Plan"
And I should see the due date for study plan "Topic 2 Test with Study Plan"
And I should see "All" text in Shown to column for study plan "Topic 2 Test with Study Plan"
And I should see Assigned icon for study plan "Topic 2 Test with Study Plan"

#Purpose: Verify assigned Practice test at curriculum channel in Manage Coursework
Scenario: Teacher validating display of assigned Practice test at curriculum channel in Manage Coursework
When I navigate to the "Home" tab
Then I should be on the "Home" page
When I enter into the DP "DigitalPathMasterLibrary" class
Then I should be on the "Classes" page
When I navigate to the "Manage Coursework" tab
Then I should be on the "Classes" page
Then I should see assigned MathXL activity "i1-2 Practice"
And I should see status as "Not started" for MathXL activity "i1-2 Practice"
And I should see "All" text in Shown to column for MathXL activity "i1-2 Practice"
And I should see Assigned icon for MathXL activity "i1-2 Practice"

