#Purpose: Feature Description
Feature: CourseSpaceQuestionLibrary
	                As a CsInstructor 
					I want to manage all the Usecases related to Question Library 
					so that I would validate all the Instructor related usecases for Question Library.


#Purpose: Login as Cs Instructor
Background:
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Calendar" page
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I navigate to the "Manage Question Bank" tab
Then I should be on the "Question Bank" page

#Purpose: File upload Question Creation in Question Bank By CsInstructor
Scenario: File upload Question Creation in Question Bank By CsInstructor
When I select 'Add Course Materials' option
And I select "File Upload" question type
Then I should be on the "Create File Upload" page
When I create "FileUpload" question
Then I should see the successfull message "Question added successfully."


#Purpose: Fill in the blanks Question Creation in Question Bank By CsInstructor
Scenario: Fill in the blanks Question Creation in Question Bank By CsInstructor
When I select 'Add Course Materials' option
And I select "Fill in the Blank" question type
Then I should be on the "Create Fill in the Blank" page
When I create "FillInTheBlank" question
Then I should see the successfull message "Question added successfully."


#Purpose : Drop down list  Question Creation in Question Bank By CsInstructor
Scenario: Drop down list  Question Creation in Question Bank By CsInstructor
When I select 'Add Course Materials' option
And I select "Drop-down List" question type
Then I should be on the "Create Drop-down List" page
When I create "DropDownList" question
Then I should see the successfull message "Question added successfully."



#Purpose : Entry List Question Creation in Question Bank By CsInstructor
Scenario: Entry List Question Creation in Question Bank By CsInstructor
When I select 'Add Course Materials' option
And I select "Entry List" question type
Then I should be on the "Create Entry List" page
When I create "EntryList" question
Then I should see the successfull message "Question added successfully."


#Purpose : Essay Question Creation in Question Bank By CsInstructor
Scenario: Essay Question Creation in Question Bank By CsInstructor
When I select 'Add Course Materials' option
And I select "Essay" question type
Then I should be on the "Create Essay" page
When I create "Essay" question
Then I should see the successfull message "Question added successfully."



#Purpose: Matching Question Creation in Question Bank By CsInstructor
#TestCase Id: HSS_Core_PWF_193
Scenario: Matching Question Creation in Question Bank By CsInstructor
When I select 'Add Course Materials' option
And I select "Matching" question type
Then I should be on the "Create Matching" page
When I create "Matching" question
Then I should see the successfull message "Question added successfully."



#Purpose : Multiple Response Question Creation in Question Bank By CsInstructor
#TestCase Id: HSS_Core_PWF_193
Scenario: Multiple Response Question Creation in Question Bank By CsInstructor
When I select 'Add Course Materials' option
And I select "Multiple Response" question type
Then I should be on the "Create Multiple Response" page
When I create "MultipleResponse" question
Then I should see the successfull message "Question added successfully."



#Purpose : TextMatch Question Creation in Question Bank By CsInstructor
#TestCase Id : HSS_Core_Pwf_193
Scenario: Text Match Question Creation in Question Bank By CsInstructor
When I select 'Add Course Materials' option
And I select "Text Match" question type
Then I should be on the "Create Text Match" page
When I create "TextMatch" question
Then I should see the successfull message "Question added successfully."



#Purpose : Numeric Question Creation in Question Bank By CsInstructor
#TestCase Id :HSS_Core_Pwf_193
Scenario: Numeric Question Creation in Question Bank by CsInstructor
When I select 'Add Course Materials' option
And I select "Numeric" question type
Then I should be on the "Create Numeric" page
When I create "Numeric" question
Then I should see the successfull message "Question added successfully."


#Purpose: Creation of question folder and its accessibility
#TestCase Id: HSS_Core_PWF_190
Scenario: Creation of question folder and its accessibility By CsInstructor
When I select 'Add Course Materials' option
And I select "Add Folder" option
Then I should be on the "Create New Folder" page
When I create question "Folder"
Then I should see the created question "Folder"


#Purpose : To verify the functionality of accessing the clipboard items in question bank
#TestCase Id :HSS_Core_PWF_173
Scenario:To verify the functionality of accessing the clipboard items in question bank by CsInstructor
Then I should see the 'Delete','Copy','Cut','Paste','Reports' action row options
When I select the "MyLanguageLabs Student Quiz q1" question from question bank
Then I should see 'Delete','Copy','Cut' options should get enabled
When I click on the 'Copy' clipboard option
Then I should see 'Paste' options should get enabled


#Purpose : Accessing the folder c-menu options in question bank - folder preferences
#TestCase Id :HSS_Core_PWF_198
Scenario:Accessing the folder c-menu options in question bank folder preferences by CsInstructor
When I navigate to folder "Capítulo 01: ¿Quiénes somos?"
And I set the score "10" for questions in "ADDITIONAL PRACTICE" folder using "Question Preferences"
Then I should see the updated score "10" for question "01-01 SPAN PRACTICE q1 VOCABULARY" in "ADDITIONAL PRACTICE" folder

