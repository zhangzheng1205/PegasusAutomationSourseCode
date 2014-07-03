Feature: PEGASUS-8528: Course Authoring in ECollege Portal
	As a ECollege Teacher
	I want to authoring of ECollege course
	So that I would use the course as the ECollege Teacher.

#Purpose: Login on ECollege Portal as ECollege Teacher.
Background: Login as ECollege Teacher on ECollge Portal URL
Given I browsed the ECollege URL as "ECollegeTeacher"
When I login to Pearson TPI Cert as "ECollegeTeacher"
Then I should logged in successfully on ECollege

#Purpose: Author ECollege Course on ECollege Portal.
Scenario: Author ECollege Course on ECollege Portal	
Given I am on the "Home PSH" page
When I click on "Academics PSH" Option on Home PSH page
Then I should be on the "Academics PSH" page
When I enter inside "ECollege" course
And I select "AuthorTab" Option in left frame
And I author the ECollege Course 
When I select "CourseTab" Option in left frame
Then I should see the "Enter Course Link" on course home page
When I click on "Exit Course" button from bottom left frame
And I "Signoff" from the "ECollegeTeacher"
Then I should be on the "Pearson TPI Cert| WELCOME" page
	