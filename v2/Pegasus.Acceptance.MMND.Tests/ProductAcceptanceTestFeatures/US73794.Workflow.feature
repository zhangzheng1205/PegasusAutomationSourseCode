#Purpose: Feature Description
Feature: US73794  - Enroll Student to section course
					As a SMS Student 
					I want to register new section
					so that I can access the section

#Purpose: Open SMS Url
Background:  
Given I browsed the URL of "MMNDStudent"
When I login to MMND Cert as "MMNDStudent"
Then I should be logged in successfully as "MMNDStudent"

#Enroll Student to section
@EnrollStudenttoSectionCourse
Scenario: Enroll Student to section course
Given I am on the "MyLab & Mastering | Pearson" page
When I select enroll in a course option
And I enter the "MMNDSection" section id
Then I should see the enrolled "MMNDNonCoOrdinate" section
When I log out from the application as "MMNDStudent"
Then I should see the application logout successfully