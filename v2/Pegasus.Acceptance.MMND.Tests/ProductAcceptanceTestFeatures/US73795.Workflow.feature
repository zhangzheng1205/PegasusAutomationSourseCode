#Purpose: Feature Description
Feature: US73795 - Tool Launch by MMND Student
				   As a MMND student
				   I want to Launch the Tool
				   so that I can Access the Pegasus Courses.
	

#Purpose: Open URL for MMND Cert
Background: 
Given I browsed the URL of "MMNDStudent"
When I login to MMND Cert as "MMNDStudent"
Then I should be logged in successfully as "MMNDStudent"

#Purpose: UseCase Launch Tool For NonCoOrdinate Course by Student
Scenario:Tool Launch in Non Co-ordinate course by MMND Student
Given I am on the "MyLab & Mastering | Pearson" page
When I navigate inside "MMNDNonCoOrdinate" course
Then I should see the course links
When I navigate inside the "MMND" subtab
And I launch Student tool from the Tool/Asset launch "MMND" link
Then I should see Student tool launched successfully for "MMNDNonCoOrdinate" course
When I log out from the application
Then I should see the application logout successfully

#Purpose: UseCase Launch Tool For NonCoOrdinate Course student
Scenario: Tool Launch in section course by MMND Student
Given I am on the "MyLab & Mastering | Pearson" page
When I navigate inside "MMNDSection" course
Then I should see the course links
When I navigate inside the "MMND" subtab
And I launch Student tool from the Tool/Asset launch "MMND" link
Then I should see Student tool launched successfully for "MMNDSection" course
When I log out from the application
Then I should see the application logout successfully

