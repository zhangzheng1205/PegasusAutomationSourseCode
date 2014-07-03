#Purpose: Feature Description
Feature: US58860 - Manage Question Creation
In order to Create Question and Verify Cmenu Option(s)
As a WS Teacher
I want to create question(s) and Verify question Cmenu options in Ws

@initial_setup
#Purpose: Open Ws Url
Background: 
Given I have browsed url for "WSTeacher"
When I have logged into the work space as WS Teacher
Then  It should show the "Global Home" page

@CreateMultipleChoiceQuestion @ignore
#Purpose: UseCase To Create Multiple Type Question
Scenario Outline: Create Multiple Choice Question in the Manage Question Library  
Given I am on the "Global Home" page
When I select the course name with prefix <coursename>
Examples:
| coursename |
| BDDML      |
Then It should show the "Overview" page
When I navigate to the "Content" tab
And I select the "Manage Question Library" sub tab
And I click on the 'Add Content' button
When I select the 'Multiple Choice' question option
And I create the 'Multiple Choice' question
Then It should display successful message "Question added successfully."
And I select the Home button to go back on Global Home page

@CreateFillintheBlankQuestion @ignore
#Purpose: UseCase To Create Fill in the Blank Type Question
Scenario Outline: Create Fill in the Blank question in the Manage Question Library
Given I am on the "Global Home" page
When I select the course name with prefix <coursename>
Examples:
| coursename |
| BDDML      |
Then It should show the "Overview" page
When I navigate to the "Content" tab
And I select the "Manage Question Library" sub tab
Then I click on the 'Add Content' button
When I select the 'Fill in the Blank' question option
And I create the 'Fill in the Blank' question
Then It should display successful message "Question added successfully."
And I select the Home button to go back on Global Home page

@CreateSCOQuestion @ignore
#Purpose: UseCase To Create SCO Type Question
Scenario Outline: Import SCO question in the Manage Question Library  
Given I am on the "Global Home" page
When I select the course name with prefix <coursename>
Examples:
| coursename |
| BDDML      |
Then It should show the "Overview" page
When I navigate to the "Content" tab
And I select the "Manage Question Library" sub tab
Then I click on the 'Add Content' button
When I select the 'Import SCO Metadata' option
And I import the 'SCO' question
And I select the Home button to go back on Global Home page

@CreateImportSCOQuestion @ignore
#Purpose: UseCase To Import SCO Type Question
Scenario Outline: Create SCO question through Browse Repository  
Given I am on the "Global Home" page
When I select the course name with prefix <coursename>
Examples:
| coursename |
| BDDML      |
Then It should show the "Overview" page
When I navigate to the "Content" tab
And I select the "Manage Question Library" sub tab
Then I click on the 'Add Content' button
When I select the 'Browse Repository' option
And I import the 'SCO' question through browse repository
Then It should display successful message "SCO questions added successfully."
And I select the Home button to go back on Global Home page

@ViewSCOQuestionPreview @ignore
#Purpose: UseCase To Preview SCO Type Question
Scenario Outline: Preview SCO question in the Manage Question Library  
Given I am on the "Global Home" page
When I select the course name with prefix <coursename>
Examples:
| coursename |
| BDDML      |
Then It should show the "Overview" page
When I navigate to the "Content" tab
And I select the "Manage Question Library" sub tab
When I clicked on the Search/View button in "frmQuestionLibrary" frame
When I preview the 'SCO' question
And I select the Home button to go back on Global Home page
#And  I clicked on the Logout link to get logged out from the application