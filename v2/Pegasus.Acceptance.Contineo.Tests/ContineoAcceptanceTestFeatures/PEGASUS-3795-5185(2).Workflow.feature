Feature: PEGASUS-3795(2) - Validate the Enrolled Class and Course for Rumba Student
						   As a Rumba Student 
						   I want to login
						   so that I would be able to validate the enrolled class and courses.

#Purpose: Open the Cs Url and Login as Rumba Student
Background: 
Given I browsed the login url for "RumbaStudent"
When I login to Pegasus as "RumbaStudent" in "CourseSpace"
Then I should be logged in successfully

#Purpose: Validate Enrolled Class for Rumba Student
Scenario: Validate Enrolled Class for Rumba Student
Given I am on the "Overview" page
When I close the welcome message
Then I should see the welcome message popup closed successfully for "RumbaStudent"
And I should see the Enrolled "DigitalPathContineoMasterLibrary" class displayed and accesible by student
When I "Sign Out" from the "RumbaStudent"
Then I should see the "Signed Out" message

