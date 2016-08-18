Feature: MMNDStandaloneIns
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: MMND student access the course link
Given user access the course link "MMNDCoOrdinate"
Then user should land inside the "MMNDCoOrdinate" course

Scenario: MMND student access the Pegasus link
Given user access the Pegaus link "View_All_Content"
Then user should land inside the "View All Course Materials" page

Scenario: MMND Instructor access the course link
Given user access the course template "MMNDCoOrdinate"
When user access the course link "MMNDCoOrdinate"
Then user should land inside the "MMNDCoOrdinate" course

	
Scenario: MMND Instructor access the Pegasus link
Given user access the Pegaus link "Grades"
Then user should land inside the Grades page
