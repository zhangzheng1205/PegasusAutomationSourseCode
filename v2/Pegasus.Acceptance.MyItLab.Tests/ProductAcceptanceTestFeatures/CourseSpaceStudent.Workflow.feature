Feature: CourseSpaceStudent Submission
	                 As a CS Student 
					I want to manage all the coursespace student Submission related usecases 
					so that I would validate all the coursespace student Submission scenarios are working fine.

#Purpose: To Submit Sim Activity Inside Instructor Course
#MyItLabInstructorCourse
Scenario: Activity Submission Inside Instructor Course by SMS Student
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page
When I submit the "SIM5Activity" activity of behavioral mode "SkillBased" type
Then I should see the "Passed" status of the "SIM5Activity" activity of behavioral mode "SkillBased" type

# Purpose: SIM study Plan  launch (Skill based) and display of Question status in VS Page
# TestCase ID: HED_MIL_PWF_392
#MyItLabInstructorCourse
Scenario: To Check The Student Launch The SIM study Plan PreTest by SMS Student
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I submit the "SIM5StudyPlan" pretest activity of behavioral mode type "SkillBased"
Then I should see the "In Progress" status of the "SIM5StudyPlan" activity of behavioral mode "SkillBased" type

#Purpose: To check the Student : SIM study Plan  launch (Skill based) and display of Total time taken in VS Page
#TestCase Id: HED_MIL_PWF_393
#MyItLabInstructorCourse
Scenario: To check the Student : SIM study Plan  launch (Skill based) and display of Total time taken in VS Page
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I open the "SIM5StudyPlan" Activity
Then I should be on the "myitlab Study Plan" page
When I click on Start Pre test button of SIM Study Plan by SMS Student
And I Submit the SIM Study Plan "Sim5PreTest"
Then I should see the "In Progress" status of the "SIM5StudyPlan" activity of behavioral mode "SkillBased" type

# Purpose: To check that Student launches the Study materials and submits it
# TestCase ID: HED_MIL_PWF_395
#MyItLabInstructorCourse
Scenario: To Check The Student Launch The SIM study Plan Trainig Material by SMS Student
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I submit the "SIM5StudyPlan" activity of behavioral mode type "SkillBased" using Training Material
Then I should see the "In Progress" status of the "SIM5StudyPlan" activity of behavioral mode "SkillBased" type

#Purpose: Display Grades in Gradebook
#TestCase Id: HED_MIL_PWF_390
#MyItLabInstructorCourse
Scenario: Display Grades in Gradebook
When I navigate to "Grades" tab
Then I should be on the "Gradebook" page
When I click on the "SIM5StudyPlan" 'View Grades' option 
Then I should see the pre test "Sim5PreTest" score "0"
When I click on cmenu "View Submissions" of asset "Sim5PreTest"
Then I should be on the "View Submission" page
And I should the status of submitted SIM5 activity question as "Incomplete"
When I close the "View Submission" window

#Purpose :Display of View Grades for Students (Training materials / Study materials)
#TestCase Id : HED_MIL_PWF_396
#MyItLabInstructorCourse
Scenario: Display of View Grades for Students Training materials
When I navigate to "Grades" tab
Then I should be on the "Gradebook" page
When I click on the "SIM5StudyPlan" 'View Grades' option 
Then I should see the pre test training "Sim5PreTest" score "100"

#PEGASUS-29285 
#PEGASUS-29985 
#PEGASUS-29987
#peg-21998:Sim 5 Excel activity and Student scoring a 100%
#Purpose : Student launches a Sim 5 Excel activity and Student scoring a 100%
Scenario: Student launches a Sim 5 Excel activity and Student scoring a 100% compares the result and status
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select "Excel Chapter 1 Skill-Based Training" in "Course Materials" by "CsSmsStudent"
And I launch the "Excel Chapter 1 Skill-Based Training" activity in content by "CsSmsStudent"
And I should answer activity "Excel Chapter 1 Skill-Based Training" correctly and click on Submit button
Then I should be on the "Course Materials" page
When I click on cmenu "ViewSubmissions" of asset "Excel Chapter 1 Skill-Based Training" with mode "SkillBased" in Course Materials
Then I should be on the "View Submission" page
When I click on the last submission
Then I should see the grade is "22.22%" in View Submission page

#Purpose : Submitting Sim 5 excel activity and Student scoring a Zero.
#Test case ID : peg-21990.
#Products : MyItLab.
#Pre condition : Excel SIM5 activity should be created by instructor/Author in the following course and
# “Trap ALT+TAB and Browser Lock-Down” option should be un checked in the activity preference tab.
#Dependency : Always dependent.
Scenario: Sim 5 excel activity and Student scoring a Zero.
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select "Excel Chapter 1 Skill-Based Training" in "Course Materials" by "CsSmsStudent"
And I launch the "Excel Chapter 1 Skill-Based Training" activity by "CsSmsStudent" with "ZeroScore"
And I click on submit button answering incorrectly of "Excel" type "Training" mode activity "Excel Chapter 1 Skill-Based Training"
Then I should be on the "Course Materials" page
And I should see the "Not passed" status for the activity "Excel Chapter 1 Skill-Based Training"
And I should see "0.00%" score for the activity "Excel Chapter 1 Skill-Based Training" in course material page

#Purpose : Submitting Sim 5 Word activity and Student scoring a Zero.
#Test case ID : peg-21989.
#Products : MyItLab.
#Pre condition : Word SIM5 activity should be created by instructor/Author in the following course and “Trap ALT+TAB and Browser Lock-Down” option should be un checked in the activity preference tab.
#Dependency : Always dependent.
Scenario: Student scoring 0 in SIM5 Word activity
When I select "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" in "Course Materials" by "CsSmsStudent"
And I launch the "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" activity by "CsSmsStudent" with "ZeroScore"
And I click on submit button answering incorrectly of "Word" type "Exam" mode activity "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)"
Then I should be on the "Course Materials" page
And I should see the "Not passed" status for the activity "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)"
And I should see "0.00%" score for the activity "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" in course material page


#Purpose : Submitting Sim 5 Powerpoint activity and Student scoring a Zero.
#Test case ID : peg-21991.
#Products : MyItLab.
#Pre condition : Power Point SIM5 activity should be created by instructor/Author in the following course and “Trap ALT+TAB and Browser Lock-Down” option should be un checked in the activity preference tab.
#Dependency : Always dependent.
Scenario: Student scoring 0 in SIM5 PowerPoint activity
When I select "PowerPoint Chapter 1 Skill-Based Training" in "Course Materials" by "CsSmsStudent"
And I launch the "PowerPoint Chapter 1 Skill-Based Training" activity by "CsSmsStudent" with "ZeroScore"
And I click on submit button answering incorrectly of "PowerPoint" type "Training" mode activity "PowerPoint Chapter 1 Skill-Based Training"
Then I should be on the "Course Materials" page
And I should see the "Not passed" status for the activity "PowerPoint Chapter 1 Skill-Based Training"
And I should see "0.00%" score for the activity "PowerPoint Chapter 1 Skill-Based Training" in course material page


#Purpose : Submitting Sim 5 Access activity and Student scoring a Zero
#Test case ID : peg-21992.
#Products : MyItLab.
#Pre condition : Access SIM5 activity should be created by instructor/Author in the following course and “Trap ALT+TAB and Browser Lock-Down” option should be un checked in the activity preference tab.
#Dependency : Always dependent.
Scenario: Student scoring 0 in SIM5 Access activity
When I select "Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" in "Course Materials" by "CsSmsStudent"
And I launch the "Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" activity by "CsSmsStudent" with "ZeroScore"
And I click on submit button answering incorrectly of "Access" type "Exam" mode activity "Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)"
Then I should be on the "Course Materials" page
And I should see the "Not passed" status for the activity "Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)"
And I should see "0.00%" score for the activity "Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" in course material page
And I click on 'Back' link in View all course materials

#Purpose : Submitting GraderIT PowerPoint activity and Student scoring a 100%.
#Test case ID : peg-22015.
#Products : MyItLab.
#Pre condition : This test case depends on Grader IT activity should be created by instructor/Author.
#Dependency : Always dependent.
Scenario: Student GraderIT PPT Activity and student scoring 100%
When I navigate to "Course Materials" tab
And I select "PowerPoint Chapter 1 Grader Project [Homework 3]" in "Course Materials" by "CsSmsStudent"
And I open the activity named as "PowerPoint Chapter 1 Grader Project [Homework 3]"
Then I should see a "Test Presentation" pop up displayed with "Download Files" button and "Upload Completed File" button
When I click on Download Files button on Test Presentation pop up
And I click on download icon of "go_p01_grader_h3.pptx"
And I click on Close and Return button
Then I should see a "Test Presentation" pop up displayed with "Download Files" button and "Upload Completed File" button
When I click on Upload Completed File button on Test Presentation pop up
And I upload the downloaded file "Grader Power Point file for 100%"
Then I should see message "Your completed file has been successfully uploaded." on "Test Presentation" popup page
When I submit "PowerPoint Chapter 1 Grader Project [Homework 3]" activity
Then I should see message "Your file, go_p01_grader_h3.pptx, has been successfully received by myitlab:grader." on "Test Feedback" popup page
When I click on Return To Course button
Then I should be on the "Course Materials" page
When I select "PowerPoint Chapter 1 Grader Project [Homework 3]" in "Course Materials" by "CsSmsStudent"
Then I should see the "Passed" status for the activity "PowerPoint Chapter 1 Grader Project [Homework 3]"
And I should see "100.00%" score for the activity "PowerPoint Chapter 1 Grader Project [Homework 3]" in course material page
When I refresh the View All Course Materials frame
Then I should be on the "Course Materials" page
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#Purpose : Submitting GraderIT PowerPoint activity and Student scoring a 0%.
#Test case ID : peg-22007.
#Products : MyItLab.
#Pre condition : This test case depends on Grader IT activity should be created by instructor/Author.
#Dependency : Always dependent.
Scenario: Student GraderIT PPT Activity and student scoring 0%
When I navigate to "Course Materials" tab
And I select "PowerPoint Chapter 1 Grader Project [Homework 3]" in "Course Materials" by "CsSmsStudent"
And I open the activity named as "PowerPoint Chapter 1 Grader Project [Homework 3]"
Then I should see a "Test Presentation" pop up displayed with "Download Files" button and "Upload Completed File" button
When I click on Download Files button on Test Presentation pop up
And I click on download icon of "go_p01_grader_h3.pptx"
And I click on Close and Return button
Then I should see a "Test Presentation" pop up displayed with "Download Files" button and "Upload Completed File" button
When I click on Upload Completed File button on Test Presentation pop up
And I upload the downloaded file "Grader Power Point file for 0%"
Then I should see message "Your completed file has been successfully uploaded." on "Test Presentation" popup page
When I submit "PowerPoint Chapter 1 Grader Project [Homework 3]" activity
Then I should see message "Your file, go_p01_grader_h3.pptx, has been successfully received by myitlab:grader." on "Test Feedback" popup page
When I click on Return To Course button
Then I should be on the "Course Materials" page
When I select "PowerPoint Chapter 1 Grader Project [Homework 3]" in "Course Materials" by "CsSmsStudent"
Then I should see the "Not passed" status for the activity "PowerPoint Chapter 1 Grader Project [Homework 3]"
And I should see "0.00%" score for the activity "PowerPoint Chapter 1 Grader Project [Homework 3]" in course material page
When I refresh the View All Course Materials frame
Then I should be on the "Course Materials" page
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#Purpose : Submitting GraderIT PowerPoint activity and Student scoring a 70%.
#Test case ID : peg-22008.
#Products : MyItLab.
#Pre condition : This test case depends on Grader IT activity should be created by instructor/Author.
#Dependency : Always dependent.
Scenario: Student GraderIT PPT Activity and student scoring 70%
When I navigate to "Course Materials" tab
And I select "PowerPoint Chapter 1 Grader Project [Homework 3]" in "Course Materials" by "CsSmsStudent"
And I open the activity named as "PowerPoint Chapter 1 Grader Project [Homework 3]"
Then I should see a "Test Presentation" pop up displayed with "Download Files" button and "Upload Completed File" button
When I click on Download Files button on Test Presentation pop up
And I click on download icon of "go_p01_grader_h3.pptx"
And I click on Close and Return button
Then I should see a "Test Presentation" pop up displayed with "Download Files" button and "Upload Completed File" button
When I click on Upload Completed File button on Test Presentation pop up
And I upload the downloaded file "Grader Power Point file for 70%"
Then I should see message "Your completed file has been successfully uploaded." on "Test Presentation" popup page
When I submit "PowerPoint Chapter 1 Grader Project [Homework 3]" activity
Then I should see message "Your file, go_p01_grader_h3.pptx, has been successfully received by myitlab:grader." on "Test Feedback" popup page
When I click on Return To Course button
Then I should be on the "Course Materials" page
When I select "PowerPoint Chapter 1 Grader Project [Homework 3]" in "Course Materials" by "CsSmsStudent"
Then I should see the "Passed" status for the activity "PowerPoint Chapter 1 Grader Project [Homework 3]"
And I should see "74.00%" score for the activity "PowerPoint Chapter 1 Grader Project [Homework 3]" in course material page
When I refresh the View All Course Materials frame
Then I should be on the "Course Materials" page
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#Purpose : Submitting GraderIT Word activity and Student scoring a 70%
#Test case ID : peg-21983.
#Products : MyItLab.
#Pre condition : This test case depends on Grader IT activity should be created by instructor/Author.
#Dependency : Always dependent.
Scenario: Student GraderIT Word Activity and student scoring 70%
When I navigate to "Course Materials" tab
And I select "Word Chapter 1 Grader Project [Assessment 3]" in "Course Materials" by "CsSmsStudent"
And I open the activity named as "Word Chapter 1 Grader Project [Assessment 3]"
Then I should see a "Test Presentation" pop up displayed with "Download Files" button and "Upload Completed File" button
When I click on Download Files button on Test Presentation pop up
And I click on download icon of "go_w01_grader_a3.docx"
And I click on Close and Return button
Then I should see a "Test Presentation" pop up displayed with "Download Files" button and "Upload Completed File" button
When I click on Upload Completed File button on Test Presentation pop up
And I upload the downloaded file "Grader Word file for 70%"
Then I should see message "Your completed file has been successfully uploaded." on "Test Presentation" popup page
When I submit "Word Chapter 1 Grader Project [Assessment 3]" activity
Then I should see message "Your file, go_w01_grader_a3.docx, has been successfully received by myitlab:grader." on "Test Feedback" popup page
When I click on Return To Course button
Then I should be on the "Course Materials" page
When I select "Word Chapter 1 Grader Project [Assessment 3]" in "Course Materials" by "CsSmsStudent"
Then I should see the "Passed" status for the activity "Word Chapter 1 Grader Project [Assessment 3]"
And I should see "74.50%" score for the activity "Word Chapter 1 Grader Project [Assessment 3]" in course material page
When I refresh the View All Course Materials frame
Then I should be on the "Course Materials" page
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#Purpose : Submitting GraderIT Word activity and Student scoring a 0%
#Test case ID : peg-20927.
#Products : MyItLab.
#Pre condition : This test case depends on Grader IT activity should be created by instructor/Author.
#Dependency : Always dependent.
Scenario: Student GraderIT Word Activity and student scoring 0%
When I navigate to "Course Materials" tab
And I select "Word Chapter 1 Grader Project [Assessment 3]" in "Course Materials" by "CsSmsStudent"
And I open the activity named as "Word Chapter 1 Grader Project [Assessment 3]"
Then I should see a "Test Presentation" pop up displayed with "Download Files" button and "Upload Completed File" button
When I click on Download Files button on Test Presentation pop up
And I click on download icon of "go_w01_grader_a3.docx"
And I click on Close and Return button
Then I should see a "Test Presentation" pop up displayed with "Download Files" button and "Upload Completed File" button
When I click on Upload Completed File button on Test Presentation pop up
And I upload the downloaded file "Grader Word file for 0%"
Then I should see message "Your completed file has been successfully uploaded." on "Test Presentation" popup page
When I submit "Word Chapter 1 Grader Project [Assessment 3]" activity
Then I should see message "Your file, go_w01_grader_a3.docx, has been successfully received by myitlab:grader." on "Test Feedback" popup page
When I click on Return To Course button
Then I should be on the "Course Materials" page
When I select "Word Chapter 1 Grader Project [Assessment 3]" in "Course Materials" by "CsSmsStudent"
Then I should see the "Not passed" status for the activity "Word Chapter 1 Grader Project [Assessment 3]"
And I should see "0.00%" score for the activity "Word Chapter 1 Grader Project [Assessment 3]" in course material page
When I refresh the View All Course Materials frame
Then I should be on the "Course Materials" page
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#Purpose : Submitting GraderIT Word activity and Student scoring a 100%
#Test case ID : peg-22013.
#Products : MyItLab.
#Pre condition : This test case depends on Grader IT activity should be created by instructor/Author.
#Dependency : Always dependent.
Scenario: Student GraderIT Word Activity and student scoring 100%
When I navigate to "Course Materials" tab
And I select "Word Chapter 1 Grader Project [Assessment 3]" in "Course Materials" by "CsSmsStudent"
And I open the activity named as "Word Chapter 1 Grader Project [Assessment 3]"
Then I should see a "Test Presentation" pop up displayed with "Download Files" button and "Upload Completed File" button
When I click on Download Files button on Test Presentation pop up
And I click on download icon of "go_w01_grader_a3.docx"
And I click on Close and Return button
Then I should see a "Test Presentation" pop up displayed with "Download Files" button and "Upload Completed File" button
When I click on Upload Completed File button on Test Presentation pop up
And I upload the downloaded file "Grader Word file for 100%"
Then I should see message "Your completed file has been successfully uploaded." on "Test Presentation" popup page
When I submit "Word Chapter 1 Grader Project [Assessment 3]" activity
Then I should see message "Your file, go_w01_grader_a3.docx, has been successfully received by myitlab:grader." on "Test Feedback" popup page
When I click on Return To Course button
Then I should be on the "Course Materials" page
When I select "Word Chapter 1 Grader Project [Assessment 3]" in "Course Materials" by "CsSmsStudent"
Then I should see the "Passed" status for the activity "Word Chapter 1 Grader Project [Assessment 3]"
And I should see "100.00%" score for the activity "Word Chapter 1 Grader Project [Assessment 3]" in course material page
When I refresh the View All Course Materials frame
Then I should be on the "Course Materials" page
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#Purpose : Submitting GraderIT Excel activity and Student scoring a 100%
#Test case ID : peg-22014.
#Products : MyItLab.
#Pre condition : This test case depends on Grader IT activity should be created by instructor/Author.
#Dependency : Always dependent.
Scenario: Student GraderIT Excel Activity and student scoring 100%
When I navigate to "Course Materials" tab
And I select "Excel Chapter 1 Grader Project [Homework 3]" in "Course Materials" by "CsSmsStudent"
And I open the activity named as "Excel Chapter 1 Grader Project [Homework 3]"
Then I should see a "Test Presentation" pop up displayed with "Download Files" button and "Upload Completed File" button
When I click on Download Files button on Test Presentation pop up
And I click on download icon of "go_e01_grader_h3.xlsx"
And I click on Close and Return button
Then I should see a "Test Presentation" pop up displayed with "Download Files" button and "Upload Completed File" button
When I click on Upload Completed File button on Test Presentation pop up
And I upload the downloaded file "Grader Excel file for 100%"
Then I should see message "Your completed file has been successfully uploaded." on "Test Presentation" popup page
When I submit "GraderITExcel" activity
Then I should see message "Your file, go_e01_grader_h3.xlsx, has been successfully received by myitlab:grader." on "Test Feedback" popup page
When I click on Return To Course button
Then I should be on the "Course Materials" page
When I select "Excel Chapter 1 Grader Project [Homework 3]" in "Course Materials" by "CsSmsStudent"
Then I should see the "Passed" status for the activity "Excel Chapter 1 Grader Project [Homework 3]"
And I should see "100.00%" score for the activity "Excel Chapter 1 Grader Project [Homework 3]" in course material page
When I refresh the View All Course Materials frame
Then I should be on the "Course Materials" page
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#Purpose : Submitting GraderIT Excel activity and Student scoring a 0%
#Test case ID : peg-22003.
#Products : MyItLab.
#Pre condition : This test case depends on Grader IT activity should be created by instructor/Author.
#Dependency : Always dependent.
Scenario: Student GraderIT Excel Activity and student scoring 0%
When I navigate to "Course Materials" tab
And I select "Excel Chapter 1 Grader Project [Homework 3]" in "Course Materials" by "CsSmsStudent"
And I open the activity named as "Excel Chapter 1 Grader Project [Homework 3]"
Then I should see a "Test Presentation" pop up displayed with "Download Files" button and "Upload Completed File" button
When I click on Download Files button on Test Presentation pop up
And I click on download icon of "go_e01_grader_h3.xlsx"
And I click on Close and Return button
Then I should see a "Test Presentation" pop up displayed with "Download Files" button and "Upload Completed File" button
When I click on Upload Completed File button on Test Presentation pop up
And I upload the downloaded file "Grader Excel file for 0%"
Then I should see message "Your completed file has been successfully uploaded." on "Test Presentation" popup page
When I submit "Excel Chapter 1 Grader Project [Homework 3]" activity
Then I should see message "Your file, go_e01_grader_h3.xlsx, has been successfully received by myitlab:grader." on "Test Feedback" popup page
When I click on Return To Course button
Then I should be on the "Course Materials" page
When I select "Excel Chapter 1 Grader Project [Homework 3]" in "Course Materials" by "CsSmsStudent"
Then I should see the "Not passed" status for the activity "Excel Chapter 1 Grader Project [Homework 3]"
And I should see "0.00%" score for the activity "Excel Chapter 1 Grader Project [Homework 3]" in course material page
When I refresh the View All Course Materials frame
And I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#Purpose : Submitting GraderIT Excel activity and Student scoring a 70%.
#Test case ID : peg-22004.
#Products : MyItLab.
#Pre condition : This test case depends on Grader IT activity should be created by instructor/Author.
#Dependency : Always dependent.
Scenario: Student GraderIT Excel Activity and student scoring 70%
When I navigate to "Course Materials" tab
And I select "Excel Chapter 1 Grader Project [Homework 3]" in "Course Materials" by "CsSmsStudent"
And I open the activity named as "Excel Chapter 1 Grader Project [Homework 3]"
Then I should see a "Test Presentation" pop up displayed with "Download Files" button and "Upload Completed File" button
When I click on Download Files button on Test Presentation pop up
And I click on download icon of "go_e01_grader_h3.xlsx"
And I click on Close and Return button
Then I should see a "Test Presentation" pop up displayed with "Download Files" button and "Upload Completed File" button
When I click on Upload Completed File button on Test Presentation pop up
And I upload the downloaded file "Grader Excel file for 70%"
Then I should see message "Your completed file has been successfully uploaded." on "Test Presentation" popup page
When I submit "GraderITExcel" activity
Then I should see message "Your file, go_e01_grader_h3.xlsx, has been successfully received by myitlab:grader." on "Test Feedback" popup page
When I click on Return To Course button
Then I should be on the "Course Materials" page
When I select "Excel Chapter 1 Grader Project [Homework 3]" in "Course Materials" by "CsSmsStudent"
Then I should see the "Passed" status for the activity "Excel Chapter 1 Grader Project [Homework 3]"
And I should see "71.30%" score for the activity "Excel Chapter 1 Grader Project [Homework 3]" in course material page
When I refresh the View All Course Materials frame
Then I should be on the "Course Materials" page

#Purpose : Submitting GraderIT Access activity and Student scoring a 0%.
#Test case ID : peg-22009.
#Products : MyItLab.
#Pre condition : This test case depends on Grader IT activity should be created by instructor/Author.
#Dependency : Always dependent.
Scenario: Student GraderIT Access Activity and student scoring 0%
When I navigate to "Course Materials" tab
And I select "Access Chapter 1 Grader Project [Assessment 3]" in "Course Materials" by "CsSmsStudent"
And I open the activity named as "Access Chapter 1 Grader Project [Assessment 3]"
Then I should see a "Test Presentation" pop up displayed with "Download Files" button and "Upload Completed File" button
When I click on Download Files button on Test Presentation pop up
And I click on download icon of "go_a01_grader_a3_Open_Houses.accdb"
And I click on Close and Return button
Then I should see a "Test Presentation" pop up displayed with "Download Files" button and "Upload Completed File" button
When I click on Upload Completed File button on Test Presentation pop up
And I upload the downloaded file "Grader Access file for 0%"
Then I should see message "Your completed file has been successfully uploaded." on "Test Presentation" popup page
When I submit "Access Chapter 1 Grader Project [Assessment 3]" activity
Then I should see message "Your file, go_a01_grader_a3_Open_Houses.accdb, has been successfully received by myitlab:grader." on "Test Feedback" popup page
When I click on Return To Course button
Then I should be on the "Course Materials" page
When I select "Access Chapter 1 Grader Project [Assessment 3]" in "Course Materials" by "CsSmsStudent"
Then I should see the "Not passed" status for the activity "Access Chapter 1 Grader Project [Assessment 3]"
And I should see "0.00%" score for the activity "Access Chapter 1 Grader Project [Assessment 3]" in course material page
When I refresh the View All Course Materials frame
Then I should be on the "Course Materials" page
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#Purpose : Submitting GraderIT Access activity and Student scoring a 70%.
#Test case ID : peg-22010.
#Products : MyItLab.
#Pre condition : This test case depends on Grader IT activity should be created by instructor/Author.
#Dependency : Always dependent.
Scenario: Student GraderIT Access Activity and student scoring 70%
When I navigate to "Course Materials" tab
And I select "Access Chapter 1 Grader Project [Assessment 3]" in "Course Materials" by "CsSmsStudent"
And I open the activity named as "Access Chapter 1 Grader Project [Assessment 3]"
Then I should see a "Test Presentation" pop up displayed with "Download Files" button and "Upload Completed File" button
When I click on Download Files button on Test Presentation pop up
And I click on download icon of "go_a01_grader_a3_Open_Houses.accdb"
And I click on Close and Return button
Then I should see a "Test Presentation" pop up displayed with "Download Files" button and "Upload Completed File" button
When I click on Upload Completed File button on Test Presentation pop up
And I upload the downloaded file "Grader Access file for 70%"
Then I should see message "Your completed file has been successfully uploaded." on "Test Presentation" popup page
When I submit "Access Chapter 1 Grader Project [Assessment 3]" activity
Then I should see message "Your file, go_a01_grader_a3_Open_Houses.accdb, has been successfully received by myitlab:grader." on "Test Feedback" popup page
When I click on Return To Course button
Then I should be on the "Course Materials" page
When I select "Access Chapter 1 Grader Project [Assessment 3]" in "Course Materials" by "CsSmsStudent"
Then I should see the "Passed" status for the activity "Access Chapter 1 Grader Project [Assessment 3]"
And I should see "76.00%" score for the activity "Access Chapter 1 Grader Project [Assessment 3]" in course material page
When I refresh the View All Course Materials frame
Then I should be on the "Course Materials" page
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#Purpose : Submitting GraderIT Access activity and Student scoring a 100%.
#Test case ID : peg-22016.
#Products : MyItLab.
#Pre condition : This test case depends on Grader IT activity should be created by instructor/Author.
#Dependency : Always dependent.
Scenario: Student GraderIT Access Activity and student scoring 100%
When I navigate to "Course Materials" tab
And I select "Access Chapter 1 Grader Project [Assessment 3]" in "Course Materials" by "CsSmsStudent"
And I open the activity named as "Access Chapter 1 Grader Project [Assessment 3]"
Then I should see a "Test Presentation" pop up displayed with "Download Files" button and "Upload Completed File" button
When I click on Download Files button on Test Presentation pop up
And I click on download icon of "go_a01_grader_a3_Open_Houses.accdb"
And I click on Close and Return button
Then I should see a "Test Presentation" pop up displayed with "Download Files" button and "Upload Completed File" button
When I click on Upload Completed File button on Test Presentation pop up
And I upload the downloaded file "Grader Access file for 100%"
Then I should see message "Your completed file has been successfully uploaded." on "Test Presentation" popup page
When I submit "Access Chapter 1 Grader Project [Assessment 3]" activity
Then I should see message "Your file, go_a01_grader_a3_Open_Houses.accdb, has been successfully received by myitlab:grader." on "Test Feedback" popup page
When I click on Return To Course button
Then I should be on the "Course Materials" page
When I select "Access Chapter 1 Grader Project [Assessment 3]" in "Course Materials" by "CsSmsStudent"
Then I should see the "Passed" status for the activity "Access Chapter 1 Grader Project [Assessment 3]"
And I should see "100.00%" score for the activity "Access Chapter 1 Grader Project [Assessment 3]" in course material page
When I refresh the View All Course Materials frame
Then I should be on the "Course Materials" page
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#Purpose : Submitting Sim 5 Powerpoint activity and Student scoring 70
#Test case ID : peg-21995.
#Products : MyItLab.
#Pre condition : This test case depends on Power Point SIM5 activity should be created by instructor/Author in the following course and 
#“Trap ALT+TAB and Browser Lock-Down” option  should be un checked in the activity preference tab.
#Dependency : Always dependent.
Scenario: Student scoring 70 in SIM5 Powerpoint activity
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyITLabOffice2013Program" course from the Global Home page as "CsSmsStudent"
And I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select "PowerPoint Chapter 1 Skill-Based Training" in "Course Materials" by "CsSmsStudent"
And I launch the "PowerPoint Chapter 1 Skill-Based Training" activity by "CsSmsStudent" with "Set Idle"
And I attempt questions in "PowerPoint Chapter 1 Skill-Based Training"