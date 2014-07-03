Feature: PEGASUS-3795(1) - Validate the Enrolled Class and Course for Rumba Teacher
						   As a Rumba Teacher 
						   I want to login
						   so that I would be able to validate the enrolled class and courses.

#Purpose: Open CS Url
Background: 
Given I browsed the login url for "RumbaTeacher"
When I login to Pegasus as "RumbaTeacher" in "CourseSpace"
Then I should be logged in successfully

#Purpose: Validate Enrolled Class for Rumba Teacher
Scenario: Validate Enrolled Class for Rumba Teacher
Given I am on the "Home" page
Then I should see the welcome message
When I close the welcome message
Then I should see the welcome message popup closed successfully for "RumbaTeacher"
And I should able to see the "DigitalPathContineoMasterLibrary" class
When I "Sign Out" from the "RumbaTeacher"
Then I should see the "Signed Out" message

#Purpose: Validate Updated Class for Rumba Teacher
Scenario: Validate Updated Class for Rumba Teacher
Given I am on the "Home" page
Then I should see the welcome message popup closed successfully for "RumbaTeacher"
And I should able to see the "DigitalPathContineoMasterLibrary" class
When I "Sign Out" from the "RumbaTeacher"
Then I should see the "Signed Out" message