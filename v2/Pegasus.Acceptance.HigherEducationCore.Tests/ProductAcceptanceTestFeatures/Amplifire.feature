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

Scenario: WLUser sees Amplifire Content - Automation 
Given I am on the "Course Materials" page
And I should see "Amplifire Content - Automation" link in iframe
Then I should be able to launch the "Amplifire Content - Automation" link

Scenario: WLUser sees Amplifire Reporting - Automation 
Given I am on the "Course Materials" page
And I should see "Amplifire Reporting - Automation" link in iframe
Then I should be able to launch the "Amplifire Reporting - Automation" link

Scenario: WLUser sees Amplifire Content BLANK TARGET - Automation 
Given I am on the "Course Materials" page
And I should see "Amplifire Content BLANK TARGET - Automation" link in iframe
Then I should be able to launch the "Amplifire Content BLANK TARGET - Automation" link