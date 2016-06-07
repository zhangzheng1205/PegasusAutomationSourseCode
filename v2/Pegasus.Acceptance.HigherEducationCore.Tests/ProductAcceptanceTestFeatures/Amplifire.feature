Feature: Amplifire
	This feature contains Amplifire integration scenarios for a WL course.
	Test cases for both instructor and student reside here

@mytag
#Purpose: WLInstructor accessing a Amplifire Course
Scenario: WLUser accessing a Amplifire Course
Given I am on the "Global Home" page
When enter into "Amplifier" course 
Then I should be on the "Today's View" page

Scenario: WLUser accessing Course Materials page
Given I am on the "Today's View" page
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page

Scenario: WLUser sees Amplifire Content
Given I am on the "Course Materials" page
Then I should see "Amplifire Content - Automation" link in iframe