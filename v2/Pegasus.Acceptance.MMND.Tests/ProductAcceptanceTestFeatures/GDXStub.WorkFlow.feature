Feature: GDXStub
	As a Mock GradeBook Repository
					I want to manage all the Mock GradeBook Repository related usecases 
					so that I would validate all the Mock GradeBook Repository scenarios are working fine.

Scenario: Verify LMS Item save event is posted on mock url
Given I browse the LMS Grade Synch Mock Application URL
Then I should see the LMS Grade Synch Mock Application with Item Save event posted for "Test" activity
