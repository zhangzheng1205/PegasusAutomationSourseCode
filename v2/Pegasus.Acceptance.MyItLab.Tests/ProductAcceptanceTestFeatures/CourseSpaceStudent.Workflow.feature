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
And I click on submit button answering incorrectly of "Excel" type "Training" mode activity "Excel Chapter 1 Skill-Based Training" by "ZeroScore" student
Then I should be on the "Course Materials" page
And I should see the "Not passed" status for the activity "Excel Chapter 1 Skill-Based Training"
And I should see "0%" score for the activity "Excel Chapter 1 Skill-Based Training" in course material page

#Purpose : Submitting Sim 5 Word activity and Student scoring a Zero.
#Test case ID : peg-21989.
#Products : MyItLab.
#Pre condition : Word SIM5 activity should be created by instructor/Author in the following course and “Trap ALT+TAB and Browser Lock-Down” option should be un checked in the activity preference tab.
#Dependency : Always dependent.
Scenario: Student scoring 0 in SIM5 Word activity
When I select "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" in "Course Materials" by "CsSmsStudent"
And I launch the "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" activity by "CsSmsStudent" with "ZeroScore"
And I click on submit button answering incorrectly of "Word" type "Exam" mode activity "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" by "ZeroScore" student
Then I should be on the "Course Materials" page
And I should see the "Not passed" status for the activity "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)"
And I should see "0%" score for the activity "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" in course material page


#Purpose : Submitting Sim 5 Powerpoint activity and Student scoring a Zero.
#Test case ID : peg-21991.
#Products : MyItLab.
#Pre condition : Power Point SIM5 activity should be created by instructor/Author in the following course and “Trap ALT+TAB and Browser Lock-Down” option should be un checked in the activity preference tab.
#Dependency : Always dependent.
Scenario: Student scoring 0 in SIM5 PowerPoint activity
When I select "PowerPoint Chapter 1 Skill-Based Training" in "Course Materials" by "CsSmsStudent"
And I launch the "PowerPoint Chapter 1 Skill-Based Training" activity by "CsSmsStudent" with "ZeroScore"
And I click on submit button answering incorrectly of "PowerPoint" type "Training" mode activity "PowerPoint Chapter 1 Skill-Based Training" by "ZeroScore" student
Then I should be on the "Course Materials" page
And I should see the "Not passed" status for the activity "PowerPoint Chapter 1 Skill-Based Training"
And I should see "0%" score for the activity "PowerPoint Chapter 1 Skill-Based Training" in course material page


#Purpose : Submitting Sim 5 Access activity and Student scoring a Zero
#Test case ID : peg-21992.
#Products : MyItLab.
#Pre condition : Access SIM5 activity should be created by instructor/Author in the following course and “Trap ALT+TAB and Browser Lock-Down” option should be un checked in the activity preference tab.
#Dependency : Always dependent.
Scenario: Student scoring 0 in SIM5 Access activity
When I select "Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" in "Course Materials" by "CsSmsStudent"
And I launch the "Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" activity by "CsSmsStudent" with "ZeroScore"
And I click on submit button answering incorrectly of "Access" type "Exam" mode activity "Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" by "ZeroScore" student
Then I should be on the "Course Materials" page
And I should see the "Not passed" status for the activity "Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)"
And I should see "0%" score for the activity "Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" in course material page
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
Then I should see a "Passed" status for the activity "PowerPoint Chapter 1 Grader Project [Homework 3]" in "Course Materials" by "CsSmsStudent" 
And I should see "100%" score for the activity "PowerPoint Chapter 1 Grader Project [Homework 3]" in course material page
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
Then I should see a "Not passed" status for the activity "PowerPoint Chapter 1 Grader Project [Homework 3]" in "Course Materials" by "CsSmsStudent" 
And I should see "0%" score for the activity "PowerPoint Chapter 1 Grader Project [Homework 3]" in course material page
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
Then I should see a "Passed" status for the activity "PowerPoint Chapter 1 Grader Project [Homework 3]" in "Course Materials" by "CsSmsStudent" 
And I should see "74%" score for the activity "PowerPoint Chapter 1 Grader Project [Homework 3]" in course material page
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
Then I should see a "Passed" status for the activity "Word Chapter 1 Grader Project [Assessment 3]" in "Course Materials" by "CsSmsStudent" 
And I should see "74.5%" score for the activity "Word Chapter 1 Grader Project [Assessment 3]" in course material page
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
Then I should see a "Not passed" status for the activity "Word Chapter 1 Grader Project [Assessment 3]" in "Course Materials" by "CsSmsStudent" 
And I should see "0%" score for the activity "Word Chapter 1 Grader Project [Assessment 3]" in course material page
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
Then I should see a "Passed" status for the activity "Word Chapter 1 Grader Project [Assessment 3]" in "Course Materials" by "CsSmsStudent" 
And I should see "100%" score for the activity "Word Chapter 1 Grader Project [Assessment 3]" in course material page
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
Then I should see a "Passed" status for the activity "Excel Chapter 1 Grader Project [Homework 3]" in "Course Materials" by "CsSmsStudent" 
And I should see "100%" score for the activity "Excel Chapter 1 Grader Project [Homework 3]" in course material page
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
Then I should see a "Not passed" status for the activity "Excel Chapter 1 Grader Project [Homework 3]" in "Course Materials" by "CsSmsStudent" 
And I should see "0%" score for the activity "Excel Chapter 1 Grader Project [Homework 3]" in course material page
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
Then I should see a "Passed" status for the activity "Excel Chapter 1 Grader Project [Homework 3]" in "Course Materials" by "CsSmsStudent" 
And I should see "71.8%" score for the activity "Excel Chapter 1 Grader Project [Homework 3]" in course material page
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
Then I should see a "Not passed" status for the activity "Access Chapter 1 Grader Project [Assessment 3]" in "Course Materials" by "CsSmsStudent" 
And I should see "0%" score for the activity "Access Chapter 1 Grader Project [Assessment 3]" in course material page
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
Then I should see a "Passed" status for the activity "Access Chapter 1 Grader Project [Assessment 3]" in "Course Materials" by "CsSmsStudent" 
And I should see "76%" score for the activity "Access Chapter 1 Grader Project [Assessment 3]" in course material page
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
Then I should see a "Passed" status for the activity "Access Chapter 1 Grader Project [Assessment 3]" in "Course Materials" by "CsSmsStudent" 
And I should see "100%" score for the activity "Access Chapter 1 Grader Project [Assessment 3]" in course material page
When I refresh the View All Course Materials frame
Then I should be on the "Course Materials" page
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page
#Purpose : Submitting training material in SIM5 Study Plan 
#Test Case ID : peg-22011.
#Product : MyItLab.
Scenario: Student submitting training material in SIM5 Word activity study plan
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select "Word Chapter 1 Study Plan [Skill-Based]: Training > Post-Test" in "Course Materials" by "CsSmsStudent" 
And I open the activity named as "Word Chapter 1 Study Plan [Skill-Based]: Training > Post-Test"
Then I should be on the "myitlab Study Plan" page
When I click on 'Start Training' button of the "Word Chapter 1 Skill-Based Training" activity by "CsSmsStudent" with "ZeroScore"
Then I should see the score "0%" for the activity "Word Chapter 1 Study Plan [Skill-Based]: Training > Post-Test" also the status as"In Progress" 

#Purpose : Submitting Sim 5 Access activity and Student scoring a Zero for past due activity.
#Products : MyItLab.
#Pre condition : Access SIM5 activity should be created by instructor/Author in the following course and
# “Trap ALT+TAB and Browser Lock-Down” option should be un checked in the activity preference tab.
#Dependency : Always dependent.
Scenario:  Sim5 Access submission for past due date activity
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select "Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" in "Course Materials" by "CsSmsStudent"
And I see past duedate icon for "Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" activity in "Course Materials" by "CsSmsStudent"
And I launch the "Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" activity by "CsSmsStudent" with "100Score"
And I click on submit button answering incorrectly of "Access" type "Exam" mode activity "Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" by "100Score" student
Then I should be on the "Course Materials" page

#Purpose : Submitting Sim 5 Word activity and Student scoring a Zero.
#Products : MyItLab.
#Pre condition : Word SIM5 activity should be created by instructor/Author in the following course and “Trap ALT+TAB and Browser Lock-Down” option should be un checked in the activity preference tab.
#Dependency : Always dependent.
Scenario: Sim5 Word submission for past due date activity
When I select "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" in "Course Materials" by "CsSmsStudent"
And I launch the "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" activity by "CsSmsStudent" with "100Score"
And I click on submit button answering incorrectly of "Word" type "Exam" mode activity "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" by "100Score" student
Then I should be on the "Course Materials" page

#Purpose : Submitting Sim 5 Powerpoint activity and Student scoring a Zero.
#Products : MyItLab.
#Pre condition : Power Point SIM5 activity should be created by instructor/Author in the following course and “Trap ALT+TAB and Browser Lock-Down” option should be un checked in the activity preference tab.
#Dependency : Always dependent.
Scenario: Sim5 PowerPoint submission for past due date activity
When I select "PowerPoint Chapter 1 Skill-Based Training" in "Course Materials" by "CsSmsStudent"
And I launch the "PowerPoint Chapter 1 Skill-Based Training" activity by "CsSmsStudent" with "100Score"
And I click on submit button answering incorrectly of "PowerPoint" type "Training" mode activity "PowerPoint Chapter 1 Skill-Based Training" by "100Score" student
Then I should be on the "Course Materials" page


#Purpose : Submitting Sim 5 Excel activity and Student scoring a Zero.
#Products : MyItLab.
#Pre condition : Excel SIM5 should be assigned with due date and due date should be passed.
# TestLink Id: peg:19330
#Dependency : Always dependent.
Scenario: Sim5 Excel submission for past Due Activity
When I select "Excel Chapter 1 Skill-Based Training" in "Course Materials" by "CsSmsStudent"
And I launch the "Excel Chapter 1 Skill-Based Training" activity by "CsSmsStudent" with "100Score"
And I click on submit button answering incorrectly of "Excel" type "Training" mode activity "Excel Chapter 1 Skill-Based Training" by "100Score" student
Then I should be on the "Course Materials" page

#Purpose: Student Launches and submit Posttest with score Zero
# TestCase Id: peg-22019
#MyItLabProgramCourse
Scenario: Student Launches and submit Posttest with score Zero
When I select "Excel Chapter 1 Study Plan [Skill-Based]: Training > Post-Test" in "Course Materials" by "CsSmsStudent"
And I launch the "Excel Chapter 1 Study Plan [Skill-Based]: Training" activity by "CsSmsStudent" with "ZeroScore"
And I click on submit button answering incorrectly of "Excel" type "Training" mode activity "Excel Chapter 1 Study Plan [Skill-Based]: Training" by "100Score" student
Then I should be on the "Course Materials" page

#Purpose : Submitting Sim 5 Powerpoint activity and Student scoring 70
#Test case ID : peg-21995.
#Products : MyItLab.
#Pre condition : This test case depends on Power Point SIM5 activity should be created by instructor/Author in the following course and 
#“Trap ALT+TAB and Browser Lock-Down” option  should be un checked in the activity preference tab.
#Dependency : Always dependent.
Scenario: Student scoring 70 in SIM5 Powerpoint activity
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select "PowerPoint Chapter 1 Skill-Based Training" in "Course Materials" by "CsSmsStudent"
And I launch the "PowerPoint Chapter 1 Skill-Based Training" activity in content by "CsSmsStudent"
And I attempt questions "70%" in "PowerPoint Chapter 1 Skill-Based Training"
Then I should be on the "Course Materials" page
And I should see the "Passed" status for the activity "PowerPoint Chapter 1 Skill-Based Training"
And I should see "72.7%" score for the activity "PowerPoint Chapter 1 Skill-Based Training" in course material page
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page

#Purpose : Submitting Sim 5 Powerpoint activity and Student scoring 100
#Test case ID : peg-21999.
#Products : MyItLab.
#Pre condition : This test case depends on Power Point SIM5 activity should be created by instructor/Author in the following course and 
#“Trap ALT+TAB and Browser Lock-Down” option  should be un checked in the activity preference tab.
#Dependency : Always dependent.
Scenario: Student scoring 100 in SIM5 Powerpoint activity
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyITLabOffice2013Program" course from the Global Home page as "CsSmsStudent"
And I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select "PowerPoint Chapter 1 Skill-Based Training" in "Course Materials" by "CsSmsStudent"
And I launch the "PowerPoint Chapter 1 Skill-Based Training" activity in content by "CsSmsStudent"
And I attempt questions "100%" in "PowerPoint Chapter 1 Skill-Based Training"
Then I should be on the "Course Materials" page
And I should see the "Passed" status for the activity "PowerPoint Chapter 1 Skill-Based Training"
And I should see "0.00%" score for the activity "PowerPoint Chapter 1 Skill-Based Training" in course material page

#PEGASUS-29285 
#PEGASUS-29985 
#PEGASUS-29987
#PEGASUS-30866
#peg-21998:Sim 5 Excel activity and Student scoring a 100%
#Purpose : Student launches a Sim 5 Excel activity and Student scoring a 100%
Scenario: Student launches a Sim 5 Excel activity and Student scoring a 100% compares the result and status
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select "Excel Chapter 1 Skill-Based Training" in "Course Materials" by "CsSmsStudent"
And I launch the "Excel Chapter 1 Skill-Based Training" activity in content by "CsSmsStudent"
And I should answer activity "Excel Chapter 1 Skill-Based Training" correctly and click on Submit button with score "70%"
Then I should be on the "Course Materials" page
And I should see the "Passed" status for the activity "Excel Chapter 1 Skill-Based Training"
And I should see "70.4%" score for the activity "Excel Chapter 1 Skill-Based Training" in course material page

#PEGASUS-29245
#peg-21994:Sim 5 Excel activity and Student scoring a 70%
#Purpose : Student launches a Sim 5 Excel activity and Student scoring a 70%
Scenario: Student launches a Sim 5 Excel activity and Student scoring a 70% compares the result and status
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select "Excel Chapter 1 Skill-Based Training" in "Course Materials" by "CsSmsStudent"
And I launch the "Excel Chapter 1 Skill-Based Training" activity in content by "CsSmsStudent"
And I should answer activity "Excel Chapter 1 Skill-Based Training" correctly and click on Submit button with score "70%"
Then I should be on the "Course Materials" page
And I should see the "Passed" status for the activity "Excel Chapter 1 Skill-Based Training"
And I should see "70.4%" score for the activity "Excel Chapter 1 Skill-Based Training" in course material page

#Purpose : Submitting Sim 5 Word activity and Student scoring 70
#Test case ID : peg-21993.
#Products : MyItLab.
#Pre condition : This test case depends on Word SIM5 activity should be created by instructor/Author in the following course and 
#“Trap ALT+TAB and Browser Lock-Down” option  should be un checked in the activity preference tab.
#Dependency : Always dependent.
Scenario: Student scoring 70 in SIM5 Word activity
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" in "Course Materials" by "CsSmsStudent"
And I open the activity named as "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)"
And I attempt questions for "70%" in activity "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)"
Then I should see the "Passed" status for the activity "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)"
And I should see "75%" score for the activity "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" in course material page

#Products : MyItLab.
#Pre condition : This test case depends on Word SIM5 activity should be created by instructor/Author in the following course and 
#“Trap ALT+TAB and Browser Lock-Down” option  should be un checked in the activity preference tab.
Scenario: Student launches a Sim 5 Excel activity Pre-test and Student scoring a 70% result
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyITLabOffice2013Program" course from the Global Home page as "CsSmsStudent"
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select "Excel Chapter 1 Study Plan [Skill-Based]: Training > Post-Test" in "Course Materials" by "CsSmsStudent"
And I launch the "Excel Chapter 1 Study Plan [Skill-Based]: Training > Post-Test" activity in content by "CsSmsStudent" for Pre-test
And I should answer activity "Excel Chapter 1 Skill-Based Training" correctly and click on Submit button with score "100%"
And I attempt questions for "70%" in activity "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)"

#Purpose : Submitting Sim 5 Word activity and Student scoring 100
#Test case ID : peg-21997.
#Products : MyItLab.
#Pre condition : This test case depends on Word SIM5 activity should be created by instructor/Author in the following course and 
#“Trap ALT+TAB and Browser Lock-Down” option  should be un checked in the activity preference tab.
#Dependency : Always dependent.
Scenario: Student scoring 100 in SIM5 Word activity
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyITLabOffice2013Program" course from the Global Home page as "CsSmsStudent"
And I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" in "Course Materials" by "CsSmsStudent"
And I open the activity named as "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)"
And I attempt questions for "100%" in activity "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)"


#Purpose : Student submitting past due Sim 5 excel activity.
#Test case ID : peg-19330.
#Products : MyItLab.
#Pre condition : Excel SIM5 activity should be created by instructor/Author in the following course and
# “Trap ALT+TAB and Browser Lock-Down” option should be un checked in the activity preference tab.
#Dependency : Always dependent.
Scenario: Student submitting past due Sim 5 excel activity
When I navigate to "Assignments" tab
Then I should be on the "Course Materials" page
And I should see 'past due date icon' for "Excel Chapter 1 Skill-Based Training" activity
When I select "Excel Chapter 1 Skill-Based Training" activity in "Course Materials"
And I should answer activity "Excel Chapter 1 Skill-Based Training" correctly and click on Submit button with score "70%"

#Purpose : Student launches and crash the posttest
#Test Case ID : peg-22023
#Product : MyItLab
Scenario: Student launches and crash the Sim5 Access activity
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select "Access Chapter 1 Study Plan [Skill-Based]: Training > Post-Test" in "Course Materials" by "CsSmsStudent" 
And I open the activity named as "Access Chapter 1 Study Plan [Skill-Based]: Training > Post-Test"
Then I should be on the "myitlab Study Plan" page
When I launch the "Start Training" button of the "Access Chapter 1 Skill-Based Training" of activity by "CsSmsStudent"
And I answer activity "Access Chapter 1 Study Plan [Skill-Based]: Training > Post-Test" correctly
When I launch the "Start Post-Test" button of the "Access Chapter 1 Skill-Based Exam (Scenario 1)" of activity by "CsSmsStudent" 
When I close the "Access Chapter 1 Skill-Based Exam (Scenario 1) - BDD 4976" window
Then I should see the "In Progress" status for the activity "Access Chapter 1 Study Plan [Skill-Based]: Training > Post-Test"

#Purpose : Student Launches and submit post test and score 100 when training material score is 100
#Test Case ID : peg-22022
#Product : MyItLab
Scenario: Student Launches and submit post test and score 100 when training material score is 100
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyITLabOffice2013Program" course from the Global Home page as "CsSmsStudent"
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select "Access Chapter 1 Study Plan [Skill-Based]: Training > Post-Test" in "Course Materials" by "CsSmsStudent" 
And I open the activity named as "Access Chapter 1 Study Plan [Skill-Based]: Training > Post-Test"
Then I should be on the "myitlab Study Plan" page
When I launch the "Start Post-Test" button of the "Access Chapter 1 Skill-Based Exam (Scenario 1)" of activity by "CsSmsStudent" 
And I should answer activity "Access Chapter 1 Skill-Based Exam (Scenario 1)" correctly and click on Submit button with score "100%"
Then I should see the "InProgress" status for the activity "Access Chapter 1 Study Plan [Skill-Based]: Training > Post-Test"

#Purpose : Student Launches and submit training material with score 100
#Test Case ID : peg-22018
#Product : MyItLab
Scenario: Student Launches and submit training material with score 100
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyITLabOffice2013Program" course from the Global Home page as "CsSmsStudent"
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select "Access Chapter 1 Study Plan [Skill-Based]: Training > Post-Test" in "Course Materials" by "CsSmsStudent" 
And I open the activity named as "Access Chapter 1 Study Plan [Skill-Based]: Training > Post-Test"
Then I should be on the "myitlab Study Plan" page
When I launch the "Start Post-Test" button of the "Access Chapter 1 Skill-Based Exam (Scenario 1)" of activity by "CsSmsStudent" 
And I should answer activity "Access Chapter 1 Skill-Based Exam (Scenario 1)" correctly and click on Submit button with score "70%"
Then I should see the "InProgress" status for the activity "Access Chapter 1 Study Plan [Skill-Based]: Training > Post-Test"

#Purpose : Submitting Sim 5 Word activity and Student scoring 70
#Test case ID : peg-21993.
#Products : MyItLab.
#Pre condition : This test case depends on Word SIM5 activity should be created by instructor/Author in the following course and 
#“Trap ALT+TAB and Browser Lock-Down” option  should be un checked in the activity preference tab.
#Dependency : Always dependent.
Scenario: Student scoring 70 in SIM5 Access activity
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select "Access Chapter 1 Skill-Based Training" in "Course Materials" by "CsSmsStudent"
And I open the activity named as "Access Chapter 1 Skill-Based Training"
And I attempt the questions for "70%" in activity "Access Chapter 1 Skill-Based Training"
Then I should see the "Passed" status for the activity "Access Chapter 1 Skill-Based Training"
And I should see "72%" score for the activity "Access Chapter 1 Skill-Based Training" in course material page

#Purpose : Student GraderIT Word Activity submission to verify Badging
Scenario: Student GraderIT Word Activity submission to verify Badging
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
When I click on Return To Course button for badged activity
Then I should see a Congratulation message



#Purpose : Submitting GraderIT PowerPoint activity and Student scoring a 70%.
#Test case ID : peg-22008.
#Products : MyItLab.
#Pre condition : This test case depends on Grader IT activity should be created by instructor/Author.
#Dependency : Always dependent.
Scenario: Submit Grader IT Access Activity for 2016 course
When I navigate to "Course Materials" tab
And I open the activity named as "GradeIT Access 2016 Assessment 5"
Then I should see a pop up with "Download Materials" and "Choose File" 
When I click on the button "Download Materials" 
And I click on the button "Download All Files" 
Then I successfully download the files 
When I click on the button "Close" 
Then I should see a pop up with "Download Materials" and "Choose File" 
When I click on the button "Choose File" 
And I upload the downloaded file "Grader Access file for 70%" for course 2016
And I click on the button "Upload" 
Then I should see success message on upload
When I click on the button "Submit for Grading"  
Then I should see success message on successful submission
When I click on the button "Close Assignment"
Then I should be on the "Course Materials" page
Then I should see a "Not passed" status for the activity "GradeIT Access 2016 Assessment 5" in "Course Materials" by "CsSmsStudent" 

#--------------------------------------------------- Student launch non gradable asset ----------------------------------------------
Scenario: Student launch non gradable asset
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyItLabInstructorCourse" course from the Global Home page as "CsSmsStudent"
When I navigate to "Today's View" tab
Then I should be on the "Today's View" page
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
And I should be displayed with "RegFolderAsset" in "Course Materials" frame
When I enter into "RegFolderAsset" folder in "Course Materials" frame
Then I should be displayed with status "Not viewed" for "RegLinkAsset"
When I launch "RegLinkAsset"
Then I should be displayed with status "Viewed" for "RegLinkAsset" 

#--------------------------------------------------------------------------------------------------------------------------
										#Submit WORD Grader Activity having 0, 70, 100 scores#
#--------------------------------------------------------------------------------------------------------------------------
#Purpose : Submitting GraderIT Word activity and Student scoring a 0%
#Test case ID : 
#Products : MyItLab.
#Pre condition : This test case depends on Grader IT activity should be created by instructor/Author.
#Dependency : Always dependent.
Scenario: Student submitting GraderIT Word activity with 0 score
When I navigate to "Course Materials" tab
When I launch "RegWordGraderActivity"
Then I should see a pop up with "Download Materials" and "Choose File" 
When I click on the button "Download Materials" 
And I click on the button "Download All Files" 
Then I successfully download the files 
When I click on the button "Close" 
Then I should see a pop up with "Download Materials" and "Choose File" 
When I click on the button "Choose File" 
And I upload the downloaded file "Grader Word file for 0%" for course 2016
And I click on the button "Upload" 
Then I should see success message on upload
When I click on the button "Submit for Grading"  
Then I should see success message on successful submission
When I click on the button "Close Assignment"
Then I should be on the "Course Materials" page
Then I should be displayed with status "Not passed" for "RegWordGraderActivity" 
When I navigate to "Grades" tab
Then I should be on the "Gradebook" page
And I should see "RegWordGraderActivity" activity in Grades tab with "GraderIT0Score" grade

#Purpose : Submitting GraderIT Word activity and Student scoring a 70%
#Test case ID : 
#Products : MyItLab.
#Pre condition : This test case depends on Grader IT activity should be created by instructor/Author.
#Dependency : Always dependent.
Scenario: Student submitting GraderIT Word activity with 70 score
When I navigate to "Course Materials" tab
When I launch "RegWordGraderActivity"
Then I should see a pop up with "Download Materials" and "Choose File" 
When I click on the button "Download Materials" 
And I click on the button "Download All Files" 
Then I successfully download the files 
When I click on the button "Close" 
Then I should see a pop up with "Download Materials" and "Choose File" 
When I click on the button "Choose File" 
And I upload the downloaded file "Grader Word file for 70%" for course 2016
And I click on the button "Upload" 
Then I should see success message on upload
When I click on the button "Submit for Grading"  
Then I should see success message on successful submission
When I click on the button "Close Assignment"
Then I should be on the "Course Materials" page
Then I should be displayed with status "Passed" for "RegWordGraderActivity" 
And I should see "RegWordGraderActivity" activity in Grades tab with "GraderIT70Score" grade

#Purpose : Submitting GraderIT Word activity and Student scoring a 100%
#Test case ID : 
#Products : MyItLab.
#Pre condition : This test case depends on Grader IT activity should be created by instructor/Author.
#Dependency : Always dependent.
Scenario: Student submitting GraderIT Word activity with 100 score
When I navigate to "Course Materials" tab
When I launch "RegWordGraderActivity"
Then I should see a pop up with "Download Materials" and "Choose File" 
When I click on the button "Download Materials" 
And I click on the button "Download All Files" 
Then I successfully download the files 
When I click on the button "Close" 
Then I should see a pop up with "Download Materials" and "Choose File" 
When I click on the button "Choose File" 
And I upload the downloaded file "Grader Word file for 100%" for course 2016
And I click on the button "Upload" 
Then I should see success message on upload
When I click on the button "Submit for Grading"  
Then I should see success message on successful submission
When I click on the button "Close Assignment"
Then I should be on the "Course Materials" page
Then I should be displayed with status "Passed" for "RegWordGraderActivity" 
And I should see "RegWordGraderActivity" activity in Grades tab with "GraderIT100Score" grade

#Purpose : Folder Navigation and student validating view submission for Word Grader activity in Grades tab
#Test case ID :
#Products : MyItLab.
#Pre condition : 
Scenario: Student validating view submission for Word Grader activity
When I navigate to "Grades" tab
Then I should be on the "Gradebook" page
#When I navigate to "RegWordGraderActivity" activity in "Grades" by "CsSmsStudent"
Then I should see "RegWordGraderActivity" activity in Grades tab with "GraderIT0Score" grade
When I click on "View Submissions" cmenu option of "RegWordGraderActivity" as "CsSmsStudent" user
Then I should be on the "View Submission" page
And I should see "RegWordGraderActivity" activity name 
When I click on attempt "1"
Then I should see "scoring 0" "CsSmsStudent" with "GraderIT0Score" score 

#--------------------------------------------------------------------------------------------------------------------------
										#Submit EXCEL Grader Activity having 0, 70, 100 scores#
#--------------------------------------------------------------------------------------------------------------------------
#Purpose : Submitting GraderIT Excel activity and Student scoring a 0%
#Test case ID : 
#Products : MyItLab.
#Pre condition : This test case depends on Grader IT activity should be created by instructor/Author.
#Dependency : Always dependent.
Scenario: Student submitting GraderIT Excel activity with 0 score
When I navigate to "Course Materials" tab
When I launch "RegExcelGraderActivity"
Then I should see a pop up with "Download Materials" and "Choose File" 
When I click on the button "Download Materials" 
And I click on the button "Download All Files" 
Then I successfully download the files 
When I click on the button "Close" 
Then I should see a pop up with "Download Materials" and "Choose File" 
When I click on the button "Choose File" 
And I upload the downloaded file "Grader Excel file for 0%" for course 2016
And I click on the button "Upload" 
Then I should see success message on upload
When I click on the button "Submit for Grading"  
Then I should see success message on successful submission
When I click on the button "Close Assignment"
Then I should be on the "Course Materials" page
Then I should be displayed with status "Not passed" for "RegExcelGraderActivity" 
And I should see "RegExcelGraderActivity" activity in Grades tab with "GraderIT0Score" grade

#Purpose : Submitting GraderIT Excel activity and Student scoring a 70%
#Test case ID : 
#Products : MyItLab.
#Pre condition : This test case depends on Grader IT activity should be created by instructor/Author.
#Dependency : Always dependent.
Scenario: Student submitting GraderIT Excel activity with 70 score
When I navigate to "Course Materials" tab
When I launch "RegExcelGraderActivity"
Then I should see a pop up with "Download Materials" and "Choose File" 
When I click on the button "Download Materials" 
And I click on the button "Download All Files" 
Then I successfully download the files 
When I click on the button "Close" 
Then I should see a pop up with "Download Materials" and "Choose File" 
When I click on the button "Choose File" 
And I upload the downloaded file "Grader Excel file for 70%" for course 2016
And I click on the button "Upload" 
Then I should see success message on upload
When I click on the button "Submit for Grading"  
Then I should see success message on successful submission
When I click on the button "Close Assignment"
Then I should be on the "Course Materials" page
Then I should be displayed with status "Passed" for "RegExcelGraderActivity" 
And I should see "RegExcelGraderActivity" activity in Grades tab with "GraderIT70Score" grade

#Purpose : Submitting GraderIT Excel activity and Student scoring a 100%
#Test case ID : 
#Products : MyItLab.
#Pre condition : This test case depends on Grader IT activity should be created by instructor/Author.
#Dependency : Always dependent.
Scenario: Student submitting GraderIT Excel activity with 100 score
When I navigate to "Course Materials" tab
When I launch "RegExcelGraderActivity"
Then I should see a pop up with "Download Materials" and "Choose File" 
When I click on the button "Download Materials" 
And I click on the button "Download All Files" 
Then I successfully download the files 
When I click on the button "Close" 
Then I should see a pop up with "Download Materials" and "Choose File" 
When I click on the button "Choose File" 
And I upload the downloaded file "Grader Excel file for 100%" for course 2016
And I click on the button "Upload" 
Then I should see success message on upload
When I click on the button "Submit for Grading"  
Then I should see success message on successful submission
When I click on the button "Close Assignment"
Then I should be on the "Course Materials" page
Then I should be displayed with status "Passed" for "RegExcelGraderActivity" 
And I should see "RegExcelGraderActivity" activity in Grades tab with "GraderIT100Score" grade

#--------------------------------------------------------------------------------------------------------------------------
										#Submit ACCESS Grader Activity having 0, 70, 100 scores#
#--------------------------------------------------------------------------------------------------------------------------
#Purpose : Submitting GraderIT Access activity and Student scoring a 0%
#Test case ID : 
#Products : MyItLab.
#Pre condition : This test case depends on Grader IT activity should be created by instructor/Author.
#Dependency : Always dependent.
Scenario: Student submitting GraderIT Access activity with 0 score
When I navigate to "Course Materials" tab
When I launch "RegExcelGraderActivity"
Then I should see a pop up with "Download Materials" and "Choose File" 
When I click on the button "Download Materials" 
And I click on the button "Download All Files" 
Then I successfully download the files 
When I click on the button "Close" 
Then I should see a pop up with "Download Materials" and "Choose File" 
When I click on the button "Choose File" 
And I upload the downloaded file "Grader Access file for 0%" for course 2016
And I click on the button "Upload" 
Then I should see success message on upload
When I click on the button "Submit for Grading"  
Then I should see success message on successful submission
When I click on the button "Close Assignment"
Then I should be on the "Course Materials" page
Then I should be displayed with status "Not passed" for "RegAccessGraderActivity" 
And I should see "RegAccessGraderActivity" activity in Grades tab with "GraderIT0Score" grade

#Purpose : Submitting GraderIT Access activity and Student scoring a 70%
#Test case ID : 
#Products : MyItLab.
#Pre condition : This test case depends on Grader IT activity should be created by instructor/Author.
#Dependency : Always dependent.
Scenario: Student submitting GraderIT Access activity with 70 score
When I navigate to "Course Materials" tab
When I launch "RegExcelGraderActivity"
Then I should see a pop up with "Download Materials" and "Choose File" 
When I click on the button "Download Materials" 
And I click on the button "Download All Files" 
Then I successfully download the files 
When I click on the button "Close" 
Then I should see a pop up with "Download Materials" and "Choose File" 
When I click on the button "Choose File" 
And I upload the downloaded file "Grader Access file for 70%" for course 2016
And I click on the button "Upload" 
Then I should see success message on upload
When I click on the button "Submit for Grading"  
Then I should see success message on successful submission
When I click on the button "Close Assignment"
Then I should be on the "Course Materials" page
Then I should be displayed with status "Passed" for "RegAccessGraderActivity" 
And I should see "RegAccessGraderActivity" activity in Grades tab with "GraderIT70Score" grade

#Purpose : Submitting GraderIT Access activity and Student scoring a 100%
#Test case ID : 
#Products : MyItLab.
#Pre condition : This test case depends on Grader IT activity should be created by instructor/Author.
#Dependency : Always dependent.
Scenario: Student submitting GraderIT Access activity with 100 score
When I navigate to "Course Materials" tab
When I launch "RegExcelGraderActivity"
Then I should see a pop up with "Download Materials" and "Choose File" 
When I click on the button "Download Materials" 
And I click on the button "Download All Files" 
Then I successfully download the files 
When I click on the button "Close" 
Then I should see a pop up with "Download Materials" and "Choose File" 
When I click on the button "Choose File" 
And I upload the downloaded file "Grader Access file for 100%" for course 2016
And I click on the button "Upload" 
Then I should see success message on upload
When I click on the button "Submit for Grading"  
Then I should see success message on successful submission
When I click on the button "Close Assignment"
Then I should be on the "Course Materials" page
Then I should be displayed with status "Passed" for "RegAccessGraderActivity" 
And I should see "RegAccessGraderActivity" activity in Grades tab with "GraderIT100Score" grade

#--------------------------------------------------------------------------------------------------------------------------
										#Submit POWERPOINT Grader Activity having 0, 70, 100 scores#
#--------------------------------------------------------------------------------------------------------------------------
#Purpose : Submitting GraderIT PowerPoint activity and Student scoring a 0%
#Test case ID : 
#Products : MyItLab.
#Pre condition : This test case depends on Grader IT activity should be created by instructor/Author.
#Dependency : Always dependent.
Scenario: Student submitting GraderIT PowerPoint activity with 0 score
When I navigate to "Course Materials" tab
When I launch "RegExcelGraderActivity"
Then I should see a pop up with "Download Materials" and "Choose File" 
When I click on the button "Download Materials" 
And I click on the button "Download All Files" 
Then I successfully download the files 
When I click on the button "Close" 
Then I should see a pop up with "Download Materials" and "Choose File" 
When I click on the button "Choose File" 
And I upload the downloaded file "Grader PowerPoint file for 0%" for course 2016
And I click on the button "Upload" 
Then I should see success message on upload
When I click on the button "Submit for Grading"  
Then I should see success message on successful submission
When I click on the button "Close Assignment"
Then I should be on the "Course Materials" page
Then I should be displayed with status "Not passed" for "RegPowerPointGraderActivity" 
And I should see "RegPowerPointGraderActivity" activity in Grades tab with "GraderIT0Score" grade

#Purpose : Submitting GraderIT PowerPoint activity and Student scoring a 70%
#Test case ID : 
#Products : MyItLab.
#Pre condition : This test case depends on Grader IT activity should be created by instructor/Author.
#Dependency : Always dependent.
Scenario: Student submitting GraderIT PowerPoint activity with 70 score
When I navigate to "Course Materials" tab
When I launch "RegExcelGraderActivity"
Then I should see a pop up with "Download Materials" and "Choose File" 
When I click on the button "Download Materials" 
And I click on the button "Download All Files" 
Then I successfully download the files 
When I click on the button "Close" 
Then I should see a pop up with "Download Materials" and "Choose File" 
When I click on the button "Choose File" 
And I upload the downloaded file "Grader PowerPoint file for 70%" for course 2016
And I click on the button "Upload" 
Then I should see success message on upload
When I click on the button "Submit for Grading"  
Then I should see success message on successful submission
When I click on the button "Close Assignment"
Then I should be on the "Course Materials" page
Then I should be displayed with status "Passed" for "RegPowerPointGraderActivity" 
And I should see "RegPowerPointGraderActivity" activity in Grades tab with "GraderIT70Score" grade

#Purpose : Submitting GraderIT PowerPoint activity and Student scoring a 100%
#Test case ID : 
#Products : MyItLab.
#Pre condition : This test case depends on Grader IT activity should be created by instructor/Author.
#Dependency : Always dependent.
Scenario: Student submitting GraderIT PowerPoint activity with 100 score
When I navigate to "Course Materials" tab
When I launch "RegExcelGraderActivity"
Then I should see a pop up with "Download Materials" and "Choose File" 
When I click on the button "Download Materials" 
And I click on the button "Download All Files" 
Then I successfully download the files 
When I click on the button "Close" 
Then I should see a pop up with "Download Materials" and "Choose File" 
When I click on the button "Choose File" 
And I upload the downloaded file "Grader PowerPoint file for 100%" for course 2016
And I click on the button "Upload" 
Then I should see success message on upload
When I click on the button "Submit for Grading"  
Then I should see success message on successful submission
When I click on the button "Close Assignment"
Then I should be on the "Course Materials" page
Then I should be displayed with status "Passed" for "RegPowerPointGraderActivity" 
And I should see "RegPowerPointGraderActivity" activity in Grades tab with "GraderIT100Score" grade

#--------------------------------------------------------------------------------------------------------------------------
										#Submit Pre Test,Post Test of Study Plan#
#--------------------------------------------------------------------------------------------------------------------------
#Purpose: Submit Pre test and Post test in Course materials tab
#MyItLabProgramCourse
#Testcase ID:
Scenario: Submit pre test as CsSmsStudent
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyItLabInstructorCourse" course from the Global Home page as "CsSmsStudent"
When I navigate to "Course Materials" tab

#---------------------------------------------------------------------------------------------------------------------------
										#Submit Word SIM Activity having 0, 70, 100 scores#
#---------------------------------------------------------------------------------------------------------------------------
#Purpose : Submitting SIM5 Word activity and Student scoring a 0%
#Test case ID : 
#Products : MyItLab.
#Pre condition : This test case depends on SIM5 activity should be created by instructor/Author.
#Dependency : Always dependent.
Scenario: Student submitting Word SIM Activity and scoring 0
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" in "Course Materials" by "CsSmsStudent"
And I launch the "RegWordSIMActivity" activity as "CsSmsStudent" with "ZeroScore" score
And I click on submit button answering incorrectly of "Word" type "Exam" activity "RegWordSIMActivity" by "ZeroScore" student
Then I should be on the "Course Materials" page
And I should see the status "Not passed" for the activity "RegWordSIMActivity"
When I navigate to "Grades" tab
Then I should be on the "Gradebook" page
When I navigate to "RegWordSIMActivity" activity in "Grades" by "CsSmsStudent"
Then I should see "RegWordSIMActivity" activity in Grades tab with "SimActivity0Score" grade

#Purpose : Folder Navigation and student validating view submission for SIM5 Word activity in Grades tab
#Test case ID :
#Products : MyItLab.
#Pre condition : 
Scenario: Student validating view submission for SIM5 Word activity
When I navigate to "Grades" tab
Then I should be on the "Gradebook" page
When I navigate to "RegWordSIMActivity" activity in "Grades" by "CsSmsStudent"
Then I should see "RegWordSIMActivity" activity in Grades tab with "SimActivity0Score" grade
When I click on "View Submissions" cmenu option of "RegWordSIMActivity" as "CsSmsStudent" user
Then I should be on the "View Submission" page
And I should see "RegWordSIMActivity" activity name 
When I click on attempt "1"
#Then I should see "scoring 0" "CsSmsStudent" with "SimActivity0Score" score 

#Purpose: Validate SIM5 Word activity 'New Grades' channel of Notifications channel in Today's view tab
#Test case ID : 
#Products : MyItLab.
#Dependancy: SIM5 Activity should be submitted by students
Scenario: Student validates the New Grades channel of Notifications channel in Todays view tab
When I navigate to "Today's View" tab
When I expand "Alerts" channel
When I click on "New Grades" alert option
Then I should see the "RegWordGraderActivity"

#Purpose : Submitting SIM5 Word activity and Student scoring a 70%
#Products : MyItLab.
#Pre condition : This test case depends on SIM5 activity should be created by instructor/Author.
#Dependency : Always dependent.
Scenario: Student submitting  Word Activity and scoring 70
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select "RegWordSIMActivity" in "Course Materials" by "CsSmsStudent"
And I launch the "RegWordSIMActivity" activity as "CsSmsStudent"
And I attempt questions in "RegWordSIMActivity" to score "SimActivity70Score" 
Then I should be on the "Course Materials" page
And I should see the status "Not passed" for the activity "RegWordSIMActivity"
When I navigate to "Grades" tab
Then I should be on the "Gradebook" page
When I navigate to "RegWordSIMActivity" activity in "Grades" by "CsSmsStudent"
Then I should see "RegWordSIMActivity" activity in Grades tab with "SimActivity70Score" grade
When I click on "view submission" cmenu option of "RegCustomViewActivity1" as "CsSmsStudent" user
Then I should be on the "View Submission" page
And I should see "RegCustomViewActivity1" activity name 
And I should see 'Attempts' grid with "Date" "Grade" columns having "2" entries as "CsSmsStudent" user
When I click on attempt "1"
Then I should see "scoring 100" "CsSmsStudent" with "SimActivity70Score" score 

#Purpose : Submitting SIM5 Word activity and Student scoring a 100%
#Test case ID : 
#Products : MyItLab.
#Pre condition : This test case depends on SIM5 activity should be created by instructor/Author.
#Dependency : Always dependent.
Scenario: Student submitting  Word Activity and scoring 100
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I select "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" in "Course Materials" by "CsSmsStudent"
And I launch the "RegWordSIMActivity" activity as "CsSmsStudent"
And I attempt questions in "RegWordSIMActivity" to score "SimActivity100Score" 
Then I should be on the "Course Materials" page
And I should see the status "Not passed" for the activity "RegWordSIMActivity"
When I navigate to "Grades" tab
Then I should be on the "Gradebook" page
When I navigate to "RegWordSIMActivity" activity in "Grades" by "CsSmsStudent"
Then I should see "RegWordSIMActivity" activity in Grades tab with "SimActivity100Score" grade

#---------------------------------------------------------------------------------------------------------------------------
										#Submit SIM5 Pre Test#
#---------------------------------------------------------------------------------------------------------------------------
# Purpose: SIM5 pre test submission and study plan sataus for 0 scored pre test 
# TestCase ID: 
#MyItLabInstructorCourse
Scenario: Submit SIM5 study Plan PreTest as SMS Student
Given I browsed the login url for "CsSmsStudent"
When I logged into the Pegasus as "CsSmsStudent" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page
When I enter in the "MyItLabInstructorCourse" course from the Global Home page as "CsSmsStudent"
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I enter into "RegFolderAsset" folder in "Course Materials" frame
And I launch "SIM5StudyPlan"
And I click on the "Start Pre-Test" button of "SIM5StudyPlan" study plan
And I click on submit button answering incorrectly of "Word" type "Exam" activity "Sim5PreTest" by CsSmsStudent
Then I should see the "In Progress" status of the "SIM5StudyPlan" activity of behavioral mode "SkillBased" type

# Purpose: SIM5 training submission and study plan sataus after training
# TestCase ID: 
#MyItLabInstructorCourse
Scenario: Submit SIM5 study Plan training as SMS Student 100 score
When I launch "SIM5StudyPlan"
And I click on the "Start Training" button of "SIM5StudyPlan" study plan
And I submit "Word" type "Exam" activity "SIMTrainingActivity" by "CsSmsStudent" student
Then I should see the "In Progress" status of the "SIM5StudyPlan" activity of behavioral mode "SkillBased" type

# Purpose: SIM5 post test submission and study plan sataus for 100 score 
# TestCase ID: 
#MyItLabInstructorCourse
Scenario: Submit SIM5 study Plan post test as SMS Student 100 score with completed status
When I launch "SIM5StudyPlan"
And I click on the "Start Post-Test" button of "SIM5StudyPlan" study plan
And I submit "Word" type "Exam" activity "Sim5PostTest" by "CsSmsStudent" student
Then I should see the "Completed" status of the "SIM5StudyPlan" activity of behavioral mode "SkillBased" type