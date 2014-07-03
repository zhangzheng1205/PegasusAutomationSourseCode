#Purpose: Feature Description
Feature:Course Creation
					As a MMND Instructor
					I want to create Course
					so that I would enroll the users inside this Course.

#Purpose: Open URL for MMND Cert
Background: 
Given I browsed the URL of "MMNDInstructor"
When I login to MMND Cert as "MMNDInstructor"
Then I should be logged in successfully as "MMNDInstructor"

#Purpose: UseCase To Create NonCoOrdinate Course
Scenario: Create NonCoOrdinate Course
Given I am on the "MyLab & Mastering | Pearson" page
When I select 'Create/Copy course' option
And I enter the access code id
And I select "MMNDNonCoOrdinate" course from the list
And I create "MMNDNonCoOrdinate" course
Then The course should be successfully created
When I fetch the course id of "MMNDNonCoOrdinate" course
And I log out from the application as "MMNDInstructor"
Then I should see the application logout successfully

#Purpose: Tool Launch For NonCoOrdinate Course by MMNDInstructor
Scenario: Tool Launch For NonCoOrdinate course by MMNDInstructor
Given I am on the "MyLab & Mastering | Pearson" page
When I navigate inside "MMNDNonCoOrdinate" course
Then I should see the course links
When I add a new Tool/Asset launch subtab link to the navigation bar
And I paste CBOM request in Tool/Asset launch "MMND" link
And I launch Instructor tools from the Tool/Asset launch "MMND" link
And I fetch and store pegasus course id
Then I should see Instructor tool launched successfully for "MMNDNonCoOrdinate" course
When I launch Student tool from the Tool/Asset launch "MMND" link
Then I should see Student tool launched successfully for "MMNDNonCoOrdinate" course
When I log out from the application
Then I should see the application logout successfully

#Purpose: Usecase to Perform AssigendtoCopyforNonCoOrdinate Course
Scenario: Perform AssigendtoCopyforNonCoOrdinate Course
Given I am on the "MyLab & Mastering | Pearson" page
When I verify the "MMNDNonCoOrdinate" course from processing state
Then I should see the "MMNDNonCoOrdinate" course in active state
When I log out from the application as "MMNDInstructor"
Then I should see the application logout successfully

