Feature: CourseSpaceInstructor
	                As a CS Instructor 
					I want to manage all the coursespace instructor related usecases 
					so that I would validate all the coursespace instructor scenarios are working fine.

#Global Home Page Scenario
#Purpose: Create TestBank course through catalog by CS instructor
#TestCase Id: HED_MYTest_PWF_075
@InsCourse
Scenario: Add TestBank From Catalog by SMS Instructor
When I add TestBank from Course type "MySpanishLabMaster" course from Search Catalog
Then I should see "MyTestBankCourse" on the Global Home page

#Global Home Page Scenario
#Purpose: Validate TestBank Course To Get Out From Assigned To Copy State
Scenario: Validate TestBank Course To Get Out From Assigned To Copy State
When I select course to validate Inactive State to Active State on Global Home page
Then I should see "MyTestBankCourse" on the Global Home page in Active State

#Global Home Page Scenario
#Purpose: To verify the functionality of check box Enable on the "Upgrade text pop up"
#TestCase Id: HED_MYTest_PWF_069
Scenario: To verify the functionality of check box Enable on the "Upgrade text pop up"
When I click on Up arrow image followed by Upgrade Available link of the "MyTestBankCourse" course
Then I should see the Keep My Test course check box which is enabled by default on Upgrade Popup

#MyTestBankCourse Scenario
#Purpose: To verify the availability of Upgrade to Text/ Image option inside course
#TestCase Id: HED_MYTest_PWF_072
Scenario: To verify the availability of Upgrade to Text/ Image option inside course
When I navigate to the "MyTest" tab
Then I should be on the "MyTest" page
When I click on Upgrade to Link inside course
Then I should be on the "frmUpgrade" page

#MyTestInstructorCourse Scenario
#Purpose: To check the Saved Preferences changes to the activity
#TestCase Id: HED_MYTest_PWF_076
Scenario: To check the Saved Preferences changes to the activity By SMS Instructor
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
And I should see "MyTest" activity in the MyCourse Frame in CourseSpace
When I click the activity ShowHide cmenu option in MyCourse Frame
And I click the activity cmenu option in MyCourse Frame
And I click on "Edit" cmenu option
And I navigate to the "Preferences" tab
Then I should see the 'Allow students to Try Again' checkbox selected

#MyTestBankCourse Scenario
#Purpose: Upgrade the MyTestCourse to Instructor Course 
Scenario: Upgrade the MyTestCourse to Instructor Course by SMS Instructor
When I navigate to the "MyTest" tab
Then I should be on the "MyTest" page
When I click on Upgrade to Link inside course
Then I should be on the "frmUpgrade" page
When I click on 'OK' button

#Global Home Page Scenario
#Purpose: Validate Upgrade Instructor Course To Get Out From Assigned To Copy State
Scenario: Validate Upgrade Instructor Course To Get Out From Assigned To Copy State by SMS Instructor
When I select course to validate Inactive State to Active State on Global Home page
Then I should see "MyTestInstructorCourse" on the Global Home page in Active State

#MyTestInstructorCourse Scenario
#Purpose: Create new Test in MyTest Tab By SMS Instructor
#TestCase Id : HED_MYTest_PWF_001 
Scenario: Create New Test By SMS Instructor
When I navigate to "MyTest" tab
Then I should be on the "MyTest" page
When I click on the "Create New Test" link in Manage Your Tests and created Test using "TrueFalse" question
Then I should see the successfull message "Test saved successfully." in MyTest tab

#MyTestInstructorCourse Scenario
#Purpose: Display of View All Test Button inside a Test
#TestCase Id: HED_MYTest_PWF_078
Scenario: Display of View All Test Button inside a Test By SMS Instructor
When I navigate to "MyTest" tab
Then I should be on the "MyTest" page
When I select "Open" c-menu option from "MyTest" activity
Then I should see the "View all tests" button

#MyTestInstructorCourse Scenario
#Purpose: Verify the Funtionality of View All Test button inside a Test
#TestCase Id: HED_MYTest_PWF_079
Scenario: Verify the Funtionality of View All Test button inside a Test
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page
When I navigate to "MyTest" tab
Then I should be on the "MyTest" page
When I select "Open" c-menu option from "MyTest" activity
Then I should see the "View all tests" button
When I click on 'View all tests' button inside test
Then I should navigate back to "Manage Your Tests" Frame

#MyTestInstructorCourse Scenario
#Purpose : Display of Download option in Test Folder
#TestCase Id: HED_MYTest_PWF_082
Scenario: Display of Download option in Test Folder By SMS Instructor
When I navigate to "MyTest" tab
Then I should be on the "MyTest" page
When I select "Open" c-menu option from "MyTest" activity
Then  I should see the "Download" button

#MyTestInstructorCourse Scenario
#Purpose : Functionality of Download option
#TestCase Id: HED_MYTest_PWF_083
Scenario: Functionality of Download option By SMS Instructor
When I navigate to the "MyTest" tab
Then I should be on the "MyTest" page
When I select "Open" c-menu option from "MyTest" activity
And I click on the 'Download' options
Then I should able to see Display of Download cmenu options for test
| ExpectedResult            | ActualResult               |
| as Word (doc)             | as Word (doc)				 |
| as PDF (pdf)              | as PDF (pdf)				 |
| Blackboard Pool Manager   | Blackboard Pool Manager	 |
| Blackboard Test Manager   | Blackboard Test Manager    |
| Blackboard Vista(WebCT)   | Blackboard Vista(WebCT)    |

#MyTestInstructorCourse Scenario
#Purpose: Downloading the questions in word format
#TestCase Id: HED_MYTest_PWF_084
Scenario: Downloading the questions in word format By SMS Instructor
When I navigate to the "MyTest" tab
Then I should be on the "MyTest" page
When I select "Download as Word (.doc)" c-menu option from the Test drop down
Then I should see print details are in disabled state by default
When I select the "Create multiple versions" checkbox on My Test Download Page
Then I should see "Scramble question order" dropdown option is selected bydefault
When I select the "Include area for student response" checkbox on My Test Download Page
Then I should see "As blank on left side of test" radio is selected bydefault
When I select the "Include answer key in" checkbox on My Test Download Page
Then I should see "Separate file" radio button is selected bydefault
When I click On cancel button on MyTest download popup

#MyTestInstructorCourse Scenario
#Purpose: Downloading the questions in PDF format
#TestCase Id: HED_MYTest_PWF_085
Scenario: Downloading the questions in PDF format By SMS Instructor
When I navigate to the "MyTest" tab
Then I should be on the "MyTest" page
When I select "Download as PDF (.pdf)" c-menu option from the Test drop down
Then I should see print details are in disabled state by default
When I select the "Create multiple versions" checkbox on My Test Download Page
Then I should see "Scramble question order" dropdown option is selected bydefault
When I select the "Include area for student response" checkbox on My Test Download Page
Then I should see "As blank on left side of test" radio is selected bydefault
When I select the "Include answer key in" checkbox on My Test Download Page
Then I should see "Separate file" radio button is selected bydefault
When I click On cancel button on MyTest download popup

#MyTestInstructorCourse Scenario
#Purpose : Options c-menu for Test Folder 
#TestCase Id:HED_MYTest_PWF_095
Scenario: Options Cmenu for Test Folder By SMS Instructor
When I navigate to "MyTest" tab
Then I should be on the "MyTest" page
When I click on c-menu option of "MyTest" activity
Then I should able to see Display of cmenu options for test created 
| ExpectedResult                    | ActualResult                      |
| Open                              | Open                              |
| Save a copy as                    | Save a copy as                    |
| Rename as                         | Rename as                         |
| Download as Word (.doc)           | Download as Word (.doc)           |
| Download as PDF (.pdf)            | Download as PDF (.pdf)            |
| Download Blackboard Pool Manager  | Download Blackboard Pool Manager  |
| Download Blackboard Test Manager  | Download Blackboard Test Manager  |
| Download Blackboard Vista (WebCT) | Download Blackboard Vista (WebCT) |
| Delete                            | Delete                            |

#MyTestInstructorCourse Scenario
#Purpose : Test Creation with adding 500 random question option of Testbank 
#TestCase Id:HED_MYTest_PWF_095
Scenario: Creating New Test with Adding the 500 Questions to the test from Testbank Using "Number of Random Questions to add" option By SMS Instructor
When I navigate to the "MyTest" tab
Then I should be on the "MyTest" page
When I select "Open" c-menu option from the Test drop down
And I Enter "500" question to add randon question to MyTest
Then I should see validation message "You are about to add or copy questions that are already included in your test. Do you want to create duplicate test questions?"
When I click on 'OK' button in "Pegasus" popup

#MyTestInstructorCourse Scenario
#Purpose : Displaying Number of Test Versions
#TestCase Id:HED_MYTest_PWF_027
Scenario: Display of Number of Test Versions By SMS Instructor
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page
When I navigate to "MyTest" tab
Then I should be on the "MyTest" page
When I select "Download as Word (.doc)" c-menu option from the Test drop down
And  I enter "3" in the Create Multiple Versions text box and click on the ok button in Print pop up
Then I should see "3" versions entered in the Print pop up should be displayed in the Multiple version pop up

#MyTestInstructorCourse Scenario
#Purpose: Displaying Number of Test Versions when single version is selected
#TestCase Id:HED_MYTest_PWF_032
Scenario: Functionality of Number of Test Versions By SMS Instructor
When I navigate to "MyTest" tab
Then I should be on the "MyTest" page
When I select "Download as Word (.doc)" c-menu option from the Test drop down
And  I enter "1" in the Create Multiple Versions text box and click on the ok button in Print pop up
Then I should see "1" versions entered in the Print pop up should be displayed in the Multiple version pop up

#MyTestInstructorCourse Scenario
#Purpose: Deleting the Test in Manage your test Frame
#New activity created to execute delete functionality to preserve Test data
#TestCase Id : HED_MYTest_PWF_016
Scenario: Deleting the Test in Manage your test Frame By SMS Instructor
When I navigate to "MyTest" tab
Then I should be on the "MyTest" page
When I click on the "Create New Test" link in Manage Your Tests and created Test using "TrueFalse" question
Then I should see the successfull message "Test saved successfully." in MyTest tab
When I select "Delete" c-menu option from the Test drop down
And I click on 'OK' button in confirmation popup
Then I should see the successfull message "Test deleted successfully."

#MyTestInstructorCourse Scenario
#Purpose: Display of Test options in Manage your Test frame action row
#TestCase Id :HED_MYTest_PWF_050
Scenario: Display of Test options in Manage your Test frame action row By SMS Instructor
When I navigate to "MyTest" tab
Then I should be on the "MyTest" page
Then I should see the Display of Test options headers in manage your tests frame

#MyTestInstructorCourse Scenario
#Purpose: Creating New Test with Essay Question.
#TestCase Id : HED_MYTest_PWF_003
Scenario: Creating New Test with Essay Question By SMS Instructor
When I navigate to "Gradebook" tab
Then I should be on the "Gradebook" page
When I navigate to "MyTest" tab
Then I should be on the "MyTest" page
When I click on the "Create New Test" link in Manage Your Tests and created Test using "Essay" question
Then I should see the successfull message "Test saved successfully." in MyTest tab

