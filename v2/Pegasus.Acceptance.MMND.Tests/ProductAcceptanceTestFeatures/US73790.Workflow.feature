#Purpose: Feature Description
Feature: US73790 - Course Creation
					As a MMND Admin 
					I want to create Course
					so that I would enroll the users inside this Course.

#Purpose: Open URL for MMND Cert
Background: 
Given I browsed the URL of "MMNDInstructor"
When I login to MMND Cert as "MMNDInstructor"
Then I should be logged in successfully as "MMNDInstructor"

#Purpose: UseCase To Create NonCoOrdinate Course
@CreateNonCoOrdinateCourse
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

#Purpose: Usecase to Create CoOrdinate Course
@CreateCoOrdinateCourse
Scenario: Create CoOrdinate Course
Given I am on the "MyLab & Mastering | Pearson" page
When I select 'Create/Copy course' option
And I enter the access code id
And I select "MMNDCoOrdinate" course from the list
And I create "MMNDCoOrdinate" course
Then The course should be successfully created
When I fetch the course id of "MMNDCoOrdinate" course
When I log out from the application as "MMNDInstructor"
Then I should see the application logout successfully

#Purpose: Usecase to Create Section course
@CreateSectionCourse
Scenario: Create Section course
Given I am on the "MyLab & Mastering | Pearson" page
When I select 'Create/Copy course' option
And I select "MMNDCoOrdinate" course from the dropdown
And I create "MMNDSection"
Then The course should be successfully created
When I fetch the course id of "MMNDSection" course
And I log out from the application as "MMNDInstructor"
Then I should see the application logout successfully

#Purpose: Usecase to Perform AssigendtoCopyforNonCoOrdinate Course
@PerformAssigendtoCopyforNonCoOrdinateCourse
Scenario: Perform AssigendtoCopyforNonCoOrdinate Course
Given I am on the "MyLab & Mastering | Pearson" page
When I verify the "MMNDNonCoOrdinate" course from processing state
Then I should see the "MMNDNonCoOrdinate" course in active state
When I log out from the application as "MMNDInstructor"
Then I should see the application logout successfully

#Purpose : Usecase to Perform AssignedToCopyForCoOrdinate Course
@PerformAssignedToCopyForCordinateCourse
Scenario: Perform AssignedToCopyForCoOrdinate Course
Given I am on the "MyLab & Mastering | Pearson" page
When I verify the "MMNDCoOrdinate" course from processing state
Then I should see the "MMNDCoOrdinate" course in active state
When I log out from the application as "MMNDInstructor"
Then I should see the application logout successfully


#Purpose : Usecase to Perform AssignedToCopyForSection Course
@PerformAssignedToCopyForSectionCourse
Scenario: Perform AssignedToCopyForSection Course
Given I am on the "MyLab & Mastering | Pearson" page
When I verify the "MMNDSection" section from processing state
Then I should see the "MMNDSection" course in active state
When I log out from the application as "MMNDInstructor"
Then I should see the application logout successfully