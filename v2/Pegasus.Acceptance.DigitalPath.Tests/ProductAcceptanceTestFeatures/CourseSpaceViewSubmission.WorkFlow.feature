Feature: CourseSpaceViewSubmission
	                As a CS Student 
					I want to manage all the coursespace student view submission related usecases 
					so that I would validate all the view submission scenarios are working fine.

#Purpose: Display of StudyPlan Grades in View Submission Page by student   
Scenario: Display of StudyPlan Grade in View Submission Page by CS Student
When I navigate to the "Grades" tab
And I click on the "StudyPlan" cmenu option
Then I should see the 'Grade' in View Submission page

#Purpose: Display of Test Grades in View Submission Page by student 
Scenario: Display of Test Grade in View Submission Page by CS Student
When I navigate to the "Grades" tab
And I click on the "Test" cmenu option
Then I should see the 'Grade' in View Submission page

#Purpose: Display of StudyPlan Grades in Grades Tab by student 
Scenario: Display of StudyPlan Grade in Grades Tab by CS Student
When I navigate to the "Grades" tab
And I open the activity named as "StudyPlan" in Grades Tab
Then I should see the "StudyPlan" for 'Grade' in GradeBook tab

#Purpose: Display of Test Grades in Grades Tab by student 
Scenario: Display of Test Grade in Grades Tab by CS Student
When I navigate to the "Grades" tab
And I check the "Test" in Grades Tab
Then I should see the "Test" for 'Grade' in GradeBook tab

