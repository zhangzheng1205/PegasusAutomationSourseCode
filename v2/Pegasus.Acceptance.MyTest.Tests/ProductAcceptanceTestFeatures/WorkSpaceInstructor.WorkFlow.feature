Feature: WorkSpace Teacher Work Flow
					As a  HedWsInstructor 
					I want to manage all the workspace Teacher related usecases 
					so that I would validate all the workspace Teacher scenarios are working fine.

#Purpose: Create new Test in MyTest Tab By HedWsInstructor
#TestCase Id : HED_MYTest_PWF_001 
Scenario: Create New Test By HedWsInstructor
When I navigate to "MyTest" tab of the "MyTest" page
Then I should be on the "MyTest" page
When I click on the "Create New Test" link in Manage Your Tests and created Test using "TrueFalse" question
Then I should see the successfull message "Test saved successfully." in MyTest tab

#Purpose: Create Test with Question Group in MyTest Tab By HedWsInstructor 
#TestCase Id : HED_MYTest_PWF_002
Scenario: Test Creation with Question Group By HedWsInstructor
When I navigate to "MyTest" tab of the "MyTest" page
Then I should be on the "MyTest" page
When I select "Open" c-menu option from the Test drop down
And I click on "CreateQuestionGroup" link in the Manage Your Test frame
And I enter the Question Group title, Add the question from the Questions banks and click on Save and close button in Create Question Group pop up
And I click on Save button in action row of Manage your test frame
Then I should see the successfull message "Test saved successfully." in MyTest tab

#Purpose: Creating New Test with Essay Question.
#TestCase Id : HED_MYTest_PWF_003
Scenario: Creating New Test with Essay Question By HedWsInstructor
When I navigate to "MyTest" tab of the "MyTest" page
Then I should be on the "MyTest" page
When I click on the "Create New Test" link in Manage Your Tests and created Test using "Essay" question
Then I should see the successfull message "Test saved successfully." in MyTest tab

#Purpose: Creating New Test with Adding the Questions to the test from Testbank Using "Number of Random Questions to add" option.
# HED_MYTest_PWF_010
Scenario: Creating New Test with Adding the Questions to the test from Testbank Using "Number of Random Questions to add" option By HedWsInstructor
When I navigate to "MyTest" tab of the "MyTest" page
Then I should be on the "MyTest" page
When I select "Open" c-menu option from the Test drop down
And I Select questions in Filter Test bank Frame and enter "2" number in the Number of random questions to add field 
Then I should see the successfull message "Test saved successfully." in MyTest tab

#Purpose: Create Test with Question Group and Save the Test through Cancel Test Confirmation pop up. 
#TestCase Id : HED_MYTest_PWF_013
Scenario: Test Creation with Question Group and Save the Test through Cancel Test Confirmation pop up By HedWsInstructor
When I navigate to "MyTest" tab of the "MyTest" page
Then I should be on the "MyTest" page
When I select "Open" c-menu option from the Test drop down
And I click on "CreateQuestionGroup" link in the Manage Your Test frame
And I enter the Question Group title, Add the question from the Questions banks and click on Save and close button in Create Question Group pop up
And I click on Close button in action row of Manage your test frame
Then I should see the successfull message "Test saved successfully." in MyTest tab

#Purpose: Deleting the Test in Manage your test Frame
#New activity created to execute delete functionality to preserve Test data
#TestCase Id : HED_MYTest_PWF_016
Scenario: Deleting the Test in Manage your test Frame By HedWsInstructor 
When I navigate to "MyTest" tab of the "MyTest" page
Then I should be on the "MyTest" page
When I click on the "Create New Test" link in Manage Your Tests and created Test using "TrueFalse" question
Then I should see the successfull message "Test saved successfully." in MyTest tab
When I select "Delete" c-menu option from the Test drop down
And I click on 'OK' button in confirmation popup
Then I should see the successfull message "Test deleted successfully."

#Purpose: Verifiy the print pop up details on My test download popup
#TestCase Id: HED_MYTest_PWF_018 
Scenario: Verifiy the print pop up details on My test download popup
When I navigate to "MyTest" tab of the "MyTest" page
Then I should be on the "MyTest" page
When I select "Download as Word (.doc)" c-menu option from the Test drop down
Then I should see print details are in disabled state by default
When I click On cancel button on MyTest download popup

#Purpose: Functionality of Adding the duplicate questions using drag drop
#TestCase Id : HED_MYTest_PWF_039
Scenario: Functionality of Adding the duplicate questions using drag drop By HedWsInstructor
When I navigate to "MyTest" tab of the "MyTest" page
Then I should be on the "MyTest" page 
When I select "Open" c-menu option from the Test drop down
And I click on expand button of "My Questions Folder" in filtertest bank
And I drag and drop of "Essay" question from Filter Test Bank  to Manage Your Test Frame 
Then I should see the "Pegasus" popup
And I should see confirmation message "You are about to add or copy questions that are already included in your test. Do you want to create duplicate test questions?"
When I click on 'OK' button in "Pegasus" popup 
Then I should see the "Essay" question in manage your test

#Purpose: Availability of Questions in My Questions folder in Filter test bank frame
#TestCase Id : HED_MYTest_PWF_043
Scenario: Availability of Questions in My Questions folder in Filter test bank frame By HedWsInstructor
When I navigate to "MyTest" tab of the "MyTest" page
Then I should be on the "MyTest" page
Then I should see the "Essay" question in mytest

#Purpose: Display of Test options in Manage your Test frame action row
#TestCase Id :HED_MYTest_PWF_050
Scenario: Display of Test options in Manage your Test frame action row By HedWsInstructor
When I navigate to "MyTest" tab of the "MyTest" page
Then I should be on the "MyTest" page
Then I should see the Display of Test options headers in manage your tests frame

#Purpose: Display of MyTest Folder order in Add content from library.
#TestCase Id :HED_MYTest_PWF_056
Scenario: Display of MyTest Folder order in Add content from library By HedWsInstructor
When I navigate to "Preferences" tab of the "Preferences" page
Then I should be on the "Preferences" page
When I navigate to the "MyTest" tab in Preferences Page
Then I should be on the "MyTest" subtab
When I enable the 'MyTest' options
And I save the Preferences
And I navigate back to the "Course Materials" tab
Then I should be on the "Course Materials" page
And I should see the "My Tests Folder" and displayed "2" order in add course materials library

#Purpose: Display of Test inside the MyTest Folder order in Add content from library.
#TestCase Id: HED_MYTest_PWF_057
Scenario: Display of Test inside the MyTest Folder order in Add content from library By HedWsInstructor
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I click on 'My Tests Folder' folder in Add Course Materials
Then I should see the 'MyTest' in My Test Folder in Add content from library

#Purpose: Adding of Test from CL to  CC.
#TestCase Id: HED_MYTest_PWF_058
Scenario: Adding of Test from CL to  CC By HedWsInstructor
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I click on 'My Tests Folder' folder in Add Course Materials
And I add the "MyTest" activity from Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"

#Purpose: Display of c-menu options for Test in My course frame.
#TestCase Id: HED_MYTest_PWF_059
Scenario: Display of c-menu options for Test in My course frame By HedWsInstructor
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
And I should see "MyTest" activity in the MyCourse Frame
When I click on 'ShowHide' option of Activity
And I click the activity cmenu option in MyCourse Frame
Then I should able to see the Display of c-menu options for activity
| ExpectedResult                   | ActualResult                     |
| Edit                             | Edit                             |
| Preview                          | Preview                          |
| Properties                       | Properties                       |
| Print                            | Print                            |
| View Grades                      | View Grades                      |
| View Submissions                 | View Submissions                 |
| Activity Report1                 | Activity Report1                 |
| Activity Report2                 | Activity Report2                 |
| Show/Hide                        | Show/Hide                        |
| Get Information                  | Get Information                  |
| Remove						   | Remove                           |

#Purpose: Create The Page By Ws Instructor 
Scenario: To Create The Page By Ws Instructor
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Add Page" activity type
Then I should be on the "Create page" page
When I create the "Page" activity in Content Library
Then I should see the successfull message "Page saved successfully."
When I associate the "Page" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"

