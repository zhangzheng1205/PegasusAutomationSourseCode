#Purpose: Feature Description
Feature: US73791 - Tool Launch by MMND Instructor
				   As a MMND Instructor
				   I want to Launch the Tool
				   so that I can Access the Pegasus Courses.

#Purpose: Open URL for MMND Cert
Background: 
Given I browsed the URL of "MMNDInstructor"
When I login to MMND Cert as "MMNDInstructor"
Then I should be logged in successfully as "MMNDInstructor"

#Purpose: Tool Launch For NonCoOrdinate Course by MMNDInstructor
@ToolLaunchForNonCoOrdinateCourseByMMNDInstructor
Scenario: Tool Launch For NonCoOrdinate course by MMNDInstructor
Given I am on the "MyLab & Mastering | Pearson" page
When I navigate inside "MMNDNonCoOrdinate" course
Then I should see the course links
When I add a new Tool/Asset launch subtab link to the navigation bar
And I paste CBOM request in Tool/Asset launch "MMND" link
And I launch Instructor tools from the Tool/Asset launch "MMND" link
Then I should see Instructor tool launched successfully for "MMNDNonCoOrdinate" course
When I launch Student tool from the Tool/Asset launch "MMND" link
Then I should see Student tool launched successfully for "MMNDNonCoOrdinate" course
When I launch Asset tool from the Tool/Asset launch "MMND" link
Then I should see Asset tool launched successfully for the course
When I log out from the application
Then I should see the application logout successfully

#Purpose: Tool Launch For Section Course by MMNDInstructor
@ToolLaunchForCoOrdinateCourseByMMNDInstructor
Scenario: Tool Launch For Section course by MMNDInstructor
Given I am on the "MyLab & Mastering | Pearson" page
When I navigate inside "MMNDSection" course
Then I should see the course links
When I add a new Tool/Asset launch subtab link to the navigation bar
And I paste CBOM request in Tool/Asset launch "MMND" link
And I launch Instructor tools from the Tool/Asset launch "MMND" link
Then I should see Instructor tool launched successfully for "MMNDSection" course
When I launch Student tool from the Tool/Asset launch "MMND" link
Then I should see Student tool launched successfully for "MMNDSection" course
When I launch Asset tool from the Tool/Asset launch "MMND" link
Then I should see Asset tool launched successfully for the course
When I log out from the application
Then I should see the application logout successfully