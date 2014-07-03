Feature: WSReportInstructor
	            As a MMND Instructor 
				I want to manage all the MMND Instructor Reports related usecases 
				so that I would validate all the MMND Instructor Reports scenarios are working fine.

#Purpose: To Generate Activity Results for Single Student Report in Gradebook
Scenario: Generate Activity Results for Single Student Report in Gradebook by MMND Instructor
When I click the "Reports" link
And I generate the "ActivityResultsbyStudent" report of "MMNDStudent" 
Then I should successfully see the student name and score under launched report