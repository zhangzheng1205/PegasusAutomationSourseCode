#Purpose: Feature Description
Feature: US73796 - Asset Launch by MMND Student
	               As a MMND Student
				   I want to Launch the Asset
				   so that I can Access the Assets directly from Pegasus Courses. 

#Purpose: Open URL for MMND Cert
Background: 
Given I browsed the URL of "MMNDStudent"
When I login to MMND Cert as "MMNDStudent"
Then I should be logged in successfully as "MMNDStudent"

#Purpose: Asset Launch For NonCoOrdinate Course by MMNDStudent
@LaunchAssetForNonCoOrdinateCoursebyMMNDStudent
Scenario: Asset Launch For NonCoOrdinate course by MMNDStudent
Given I am on the "MyLab / Mastering | Pearson" page
When I navigate inside "MMNDNonCoOrdinate" course
Then I should see the course links
When I navigate inside the "MMND" subtab
And I launch Asset tool from the Tool/Asset launch "MMND" link
Then I should see Asset tool launched successfully for the course
When I log out from the application
Then I should see the application logout successfully

#Purpose: Asset Launch For Section by MMNDStudent
@LaunchAssetForSectionCoursebyMMNDStudent
Scenario: Asset Launch For Section course by MMND Student
Given I am on the "MyLab / Mastering | Pearson" page
When I navigate inside "MMNDSection" course
Then I should see the course links
When I navigate inside the "MMND" subtab
And I launch Asset tool from the Tool/Asset launch "MMND" link
Then I should see Asset tool launched successfully for the course
When I log out from the application
Then I should see the application logout successfully