Feature: CanvasInstructorAction
	                As a Canvas Instructor 
					I want to manage all the usecase in Canvas 
					so that I would validate all the Canvas integration scenarios are working fine.

#Purpose : Canvas instructor crossover to pegasus via direct integrated course
Scenario: Canvas Instructor crossover to Pegasus via direct integrated course
Given I browsed the login url for "CanvasDirectTeacher"
When I login to Canvas as "CanvasDirectTeacher"
And I enter into Canvas direct course "CanvasDirectCourse"
When I click "Instructor Grade Book" link in "CanvasDirectCourse" page as "CanvasDirectTeacher"
Then I should see "Gradebook" page of "CanvasDirectTeacher" embedded at "Instructor Grade Book" page
When I logout of Canvas
Then I should be on the "Log In to Canvas" page

#Purpose : Canvas student crossover to pegasus via direct integrated course
Scenario: Canvas student crossover to Pegasus via direct integrated course
Given I browsed the login url for "CanvasDirectStudent"
When I login to Canvas as "CanvasDirectStudent"
And I enter into Canvas direct course "CanvasDirectCourse"
When I click "Student Grade Book" link in "CanvasDirectCourse" page as "CanvasDirectStudent"
Then I should see "Gradebook" page of "CanvasDirectStudent" embedded at "Student Grade Book" page
When I logout of Canvas
Then I should be on the "Log In to Canvas" page