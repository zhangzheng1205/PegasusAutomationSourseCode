Feature: CourseSpaceInstructor Assignment
	As a CS Instructor
	I want to manage all the coursespace instructor Assignment related use cases 
	so that I would validate all the coursespace instructor Assignment scenarios are working fine.

#Purpose: To drag and drop a folder in assignment calendar.
#Test case ID : peg-21948.
#Pre condition : Word SIM5 activity should be created by instructor/Author in the following course.
#MyITLabOffice2013Program
Scenario: Instructor drag and drop a folder in assignment calendar by SMS Instructor
When I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
And I should see "GO! with Microsoft Office 2013, Volume 1" asset
And I should see the current date highlighted in the calendar frame
When I select "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)" in "Calendar" by "CsSmsInstructor"
And I drag and drop the 'Word Chapter 1: Simulation Activities' folder to the current date
Then I should see Due Date Icon displayed in current date

#Purpose: To drag and drop multiple assets in assignment calendar.
#Test case ID : peg-21981.
#Pre condition :Excel SIM5 activity should be created by instructor/Author in the following course.
#MyITLabOffice2013Program
Scenario: Drag and drop the more than one assets to current date in Assignment calendar
When I navigate to the "Assignment Calendar" tab
Then I should be on the "Calendar" page
And I should see "GO! with Microsoft Office 2013, Volume 1" asset
And I should see the current date highlighted in the calendar frame
When I select "Excel Chapter 1 Skill-Based Training" in "Calendar" by "CsSmsInstructor"
And I select the check box of any 2 activities in "Excel Chapter 1: Simulation Activities"
And I should drag and drop multiple assets to the current date
Then I should see due date icon displayed in current date




