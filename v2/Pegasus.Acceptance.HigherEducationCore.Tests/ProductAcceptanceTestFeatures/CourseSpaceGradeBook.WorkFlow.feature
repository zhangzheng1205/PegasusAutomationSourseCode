Feature: CourseSpaceGradeBook
                     As a CS Instructor 
					I want to manage all the coursespace gradebook related usecases 
					so that I would validate all the gradebook scenarios are working fine.

#Verify the usecase in InstructorCourse
#Purpose : To View grades by the Instructor in Cs
Scenario: View Activity Grade by SMS Instructor
When I navigate to "Gradebook" tab of the "Gradebook" page
Then I should be on the "Gradebook" page
And I should see the grades for submitted activity

#Verify the usecase in InstructorCourse
#Purpose : To View Manually Graded grades by the Instructor in Cs
Scenario: Manually Grade the Activity by SMS Instructor
When I navigate to "Gradebook" tab of the "Gradebook" page
Then I should be on the "Gradebook" page
When I manually grade the activity
Then I should see the successfull message "Batch update completed successfully."

#Verify the usecase in InstructorCourse
#Purpose :To Check GradeBook Page Loaded Successfully
Scenario:To Verify GradeBook Page is Loaded Successfully
When I navigate to "Gradebook" tab of the "Gradebook" page
Then I should be on the "Gradebook" page
And I should see GradeBook page loaded successfully
When I navigate to CustomView sub tab in a Page
Then I should be on CustomView in a GradeBook Page
When I navigate to Grades Subtab in a GradeBook Page
Then I should see GradeBook page loaded successfully

#Verify the usecase in InstructorCourse
#Purpose: To check the display of Activities in Gradebook
# TestCase Id: HSS_Core_PWF_069 
Scenario: To check the display of Activities in Gradebook by SMS Instructor
When I navigate to "Gradebook" tab of the "Gradebook" page
Then I should be on the "Gradebook" page
Then I should see the "Test" activity in Gradebook for all the enrollled "CsSmsStudent"

#Verify the usecase in InstructorCourse
#Purpose: To check the display of skill StudyPlan in Gradebook
# TestCase Id: HSS_Core_PWF_072
Scenario: To check the display of SkillStudyPlan in Gradebook by SMS Instructor
When I navigate to "Gradebook" tab of the "Gradebook" page
Then I should be on the "Gradebook" page
Then I should see the "SkillStudyPlan" activity in Gradebook for all the enrollled "CsSmsStudent"

#Verify the usecase in InstructorCourse
#Purpose: To Verify the functionality of 'Apply Grade Schema' in gradebook
# TestCase Id: HSS_Core_PWF_079
Scenario: To Verify the functionality of Apply Grade Schema in gradebook
When I navigate to "Gradebook" tab of the "Gradebook" page
Then I should be on the "Gradebook" page
When I navigate to the subfolder "ADDITIONALPRACTICE" of asset in gradebook
And I click on cmenu "ApplyGradeSchema" of asset "PA-01 Span Practice- Vocabulary: Saludos, despedidas y presentaciones"
Then I should be on the "Gradebook schema" page
When I 'Apply' the grade schema for the submitted activity
Then I should see the successfull message "Schema applied successfully." in "Gradebook" window
Then I should see the updated schema value "F"
When I click on cmenu "ModifyGradeSchema" of asset "PA-01 Span Practice- Vocabulary: Saludos, despedidas y presentaciones"
When I update the schema of the submitted activity
Then I should see the successfull message "Grade schema updated successfully." in "Gradebook schema" window
When I save the Updated schema
Then I should see the successfull message "Schema applied successfully." in "Gradebook" window
When I click on cmenu "RemoveGradeSchema" of asset "PA-01 Span Practice- Vocabulary: Saludos, despedidas y presentaciones"
Then I should see the successfull message "Grade schema removed successfully." in "Gradebook" window
Then I should see the updated schema value "11,1"

#Verify the usecase in InstructorCourse
#Purpose: To Verify the functionality of "Remove from custom view" option
# TestCase Id: HSS_Core_PWF_085
Scenario: Verify the functionality of Remove from custom view option By SMS Instructor
When I navigate to "Gradebook" tab of the "Gradebook" page
Then I should be on the "Gradebook" page
When I click on cmenu "SavetoCustomView" of asset "Test"
Then I should see the successfull message "Column successfully saved to Custom View."
And I should see cmenu "Remove from Custom View" of asset "Test"
When I navigate to CustomView sub tab in a Page
Then I should be on the "Custom View" page
When I click on cmenu "RemovefromCustomView" of asset "Test" in Custom View
Then I should see the successfull message "Column successfully removed from Custom View."

#Verify the usecase in InstructorCourse
#Purpose: Verify the functionality of "View All Submission" cmenu option 
# TestCase Id: HSS_Core_PWF_081
Scenario: Verify the functionality of "View All Submission" option by SMS Instructor
When I navigate to "Gradebook" tab of the "Gradebook" page
Then I should be on the "Gradebook" page
When I click on cmenu "ViewAllSubmissions" of asset "Test" 
Then I should see all submission for that particular activity 
When I close the "View Submission" window

#Verify the usecase in InstructorCourse
#Purpose: Grade cell C-menu options for the activity under Gradebook 
# TestCase Id:HSS_Core_PWF_090
Scenario: Display of Grade cell C-menu options for the activity under Gradebook by SMS Instructor
When I navigate to "Gradebook" tab of the "Gradebook" page
Then I should be on the "Gradebook" page
When I click on the Grade cell cmenu of "Test" activity in gradebook
Then I should see the cmenu under grade cell activity

#Verify the usecase in InstructorCourse
#Purpose: To Verify The functionality of Grade cell cmenu option'Edit Grades' 
#TestCase Id:HSS_Core_PWF_091
Scenario: To Verify The functionality of Grade cell cmenu option'Edit Grades' 
When I navigate to "Gradebook" tab of the "Gradebook" page
Then I should be on the "Gradebook" page
When I navigate to the subfolder "ADDITIONALPRACTICE" of asset in gradebook
And I click on Grade cell cmenu options of asset "PA-01 Span Practice- Vocabulary: Saludos, despedidas y presentaciones"
And I select the "EditGrade" in grade cell cmenu option
And I update the grade for the submitted activity
Then I should see the updated grade "50" for the asset "PA-01 Span Practice- Vocabulary: Saludos, despedidas y presentaciones" for "CsSmsStudent"
And I should see the grade icon of "PA-01 Span Practice- Vocabulary: Saludos, despedidas y presentaciones" for "CsSmsStudent"

#Verify the usecase in InstructorCourse
#Purpose: To verify the functionality of options displayed when Grade cell c.menu is "View Grade/Submission"
# TestCase Id: HSS_Core_PWF_092
Scenario: Verify the functionality of options displayed when Grade cell cmenu is View Grade/Submission By SMS Instructor
When I navigate to "Gradebook" tab of the "Gradebook" page
Then I should be on the "Gradebook" page
When I navigate to the subfolder "ADDITIONALPRACTICE" of asset in gradebook
And I click on Grade cell cmenu options of asset "PA-01 Span Practice- Vocabulary: Saludos, despedidas y presentaciones"
And I select the "ViewGradeSubmission" in grade cell cmenu option
Then I should be on the "View Submission" page
And I should see the edited grade "50" in view submission page
When I close the "View Submission" window

#Verify the usecase in InstructorCourse
#Purpose: Verify the functionality of options displayed when Grade cell c.menu is Grade History
# TestCase Id: HSS_Core_PWF_093
Scenario: Verify the functionality of options displayed when Grade cell cmenu is View Grade History By SMS Instructor
When I navigate to "Gradebook" tab of the "Gradebook" page
Then I should be on the "Gradebook" page
When I navigate to the subfolder "ADDITIONALPRACTICE" of asset in gradebook
And I click on Grade cell cmenu options of asset "PA-01 Span Practice- Vocabulary: Saludos, despedidas y presentaciones"
And I select the "ViewGradeHistory" in grade cell cmenu option
Then I should be on the "Grade history" page
And I should see the score by "CsSmsInstructor" in grade history page
When I close the "Grade history" window

#Verify the usecase in InstructorCourse
#Purpose: To Check the functionality of total weight field
# TestCase Id: HSS_PWF_114_03
Scenario: To Check the functionality of total weight field By SMS Instructor
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I associate the "Test" activity of behavioral mode "Assignment" to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"
When I navigate to the "Gradebook" tab
And I click on the 'Create Column' drop down 
Then I should be on the "Create Total Column" page
When I select checkbox of "Test" activity of behavioral mode "BasicRandom" 
And I select checkbox of "Test" activity of behavioral mode "Assignment"
And I should click on Add button 
And I have entered "50" and "30" into weight box
Then I should able to see the result in Total Weight is "80" 

#Verify the usecase in InstructorCourse
#Purpose: Display of Total weight percentage column for SMS instructor and its functionality 
#TestCase Id:HSS_PWF_114_02
Scenario: Display of Total weight percentage column for SMS instructor and its functionality By SMS Instructor
When I navigate to "Gradebook" tab of the "Gradebook" page
Then I should be on the "Gradebook" page
When I click on the 'Create Column' drop down 
Then I should be on the "Create Total Column" page
And I should see the 'Total Weight' field with value "0"

#Purpose: Instructor Validating student grade in instructor grade book
# TestCase Id: peg-22228
# HED Instructor course
# Pre Condition: Activity should be submitted by student
Scenario: Instructor Validating student grade in instructor grade book By SMS Instructor
When I navigate to "Gradebook" tab of the "Gradebook" page
Then I should be on the "Gradebook" page
When I select "Take the Chapter 1 Exam" in "Gradebook" by "CsSmsInstructor"
And I click on cmenu option "ViewAllSubmissions" of asset "Take the Chapter 1 Exam"
Then I should be on the "View Submission" page
And I should see "100" score in view submission page for a student "CsSmsStudent"

#Purpose: As a Instructor for HED Product  ,i need to make force full submission of saved actviity
# TestCase Id: peg-22229
# HED Instructor course
# Pre Condition: Activity should be past due and submitted by student
Scenario: Instructor Validating forcefull submission of saved activity
When I navigate to "Gradebook" tab of the "Gradebook" page
Then I should be on the "Gradebook" page
When I select "Take the Chapter 3 Exam" in "Gradebook" by "CsSmsInstructor"
And I click on cmenu option "ViewAllSubmissions" of asset "Take the Chapter 3 Exam"
Then I should be on the "View Submission" page
And I should search student "CsSmsStudent" from student frame in view submission page
Then I should see "Decline" and "Accept" options in instructor view submission page
When I select the option "Accept" in view submission page
Then I should see "32" score in view submission page
#------------------------------------------------------------------
#Purpose: :Instructor Providing comments to essay activity WL
#TestCase Id: peg-22422
#PEGASUS-30121
##MySpanishLabProgram
Scenario: Instructor Providing comments to essay activity WL
Given I browsed the login url for "WLCsSmsInstructor"
When I logged into the Pegasus as "WLCsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MySpanishLabProgram" from the Global Home page as "WLCsSmsInstructor"
When I navigate to "Gradebook" tab of the "Gradebook" page
Then I should be on the "Gradebook" page
When I search for "SAM 01-05" in "Gradebook" window
And I click on cmenu option "ViewAllSubmissions" of asset "SAM 01-05 Heritage Language: tu español. [Vocabulario 1. La familia]"
Then I should be on the "View Submission" page
And I select the student "CsSmsStudent" from student frame in view submission page
And and provide "Good Performance" feedback for the activity submitted by student
And I click on "Save and Close"
Then I should be on the "Gradebook" page

#Purpose: :Instructor grading essay activity with maximum score in WL
#TestCase Id: peg-22420
#PEGASUS-30120
##MySpanishLabProgram
Scenario: Instructor grading essay activity with maximum score
Given I browsed the login url for "WLCsSmsInstructor"
When I logged into the Pegasus as "WLCsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MySpanishLabProgram" from the Global Home page as "WLCsSmsInstructor"
When I navigate to "Gradebook" tab of the "Gradebook" page
Then I should be on the "Gradebook" page
When I search for "SAM 01-05" in "Gradebook" window
And I click on cmenu option "ViewAllSubmissions" of asset "SAM 01-05 Heritage Language: tu español. [Vocabulario 1. La familia]"
Then I should be on the "View Submission" page
And I select the student "CsSmsStudent" from student frame in view submission page
And I provide "1" for the activity
And I click on "Save and Close"
Then I should be on the "Gradebook" page

#Purpose: :Instructor grading essay activity with minimum score in WL
#TestCase Id: peg-22421
#PEGASUS-30122
##MySpanishLabProgram
Scenario: Instructor grading essay activity with minimum score
Given I browsed the login url for "WLCsSmsInstructor"
When I logged into the Pegasus as "WLCsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MySpanishLabProgram" from the Global Home page as "WLCsSmsInstructor"
When I navigate to "Gradebook" tab of the "Gradebook" page
Then I should be on the "Gradebook" page
When I search for "SAM 01-05" in "Gradebook" window
And I click on cmenu option "ViewAllSubmissions" of asset "SAM 01-05 Heritage Language: tu español. [Vocabulario 1. La familia]"
Then I should be on the "View Submission" page
And I select the 'Zero' scoring "CsSmsStudent" from student frame in view submission page
And I provide "0" for the activity
And I click on "Save and Close"
Then I should be on the "Gradebook" page

#Purpose: :Instructor grading lernosity activity and providing score 0
#TestCase Id: peg-22433
#PEGASUS-30124
##MySpanishLabProgram
Scenario: Instructor grading lernosity activity and providing score 0
Given I browsed the login url for "WLCsSmsInstructor"
When I logged into the Pegasus as "WLCsSmsInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MySpanishLabProgram" from the Global Home page as "WLCsSmsInstructor"
When I navigate to "Gradebook" tab of the "Gradebook" page
Then I should be on the "Gradebook" page
When I search for "SAM 01-19" in "Gradebook" window
And I click on cmenu option "ViewAllSubmissions" of asset "SAM 01-19 Singular y plural.  [Gramática 3. Sustantivos singulares y plurales] Voice Recording."
Then I should be on the "View Submission" page
And I select the student "CsSmsStudent" from student frame in view submission page
And I provide "0" for the activity
And I click on "Save and Close"
Then I should be on the "Gradebook" page



