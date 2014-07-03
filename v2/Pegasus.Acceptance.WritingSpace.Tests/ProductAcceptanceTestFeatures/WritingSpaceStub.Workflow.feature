Feature: WritingSpaceStub
					As a Mock GradeBook Repository
					I want to manage all the Mock GradeBook Repository related usecases 
					so that I would validate all the Mock GradeBook Repository scenarios are working fine.

Scenario: To Fetch External CourseID From Mock Application
Given I browse the ExternalCourseID URL WritingSpaceMock Application
When I enter the "PegasusCourseID" details to mock application
Then I should see the External CourseID

Scenario: Post The Item To WritingSpace GBR
Given I browse the WritingSpace Assessment Mock Application URL
When I enter the "ItemPost" URL in Mock Application
And I select the "Post" request type option
And I send the "ItemPost" request to Mock GBR Application 
Then I should see the response in mock assessment application

Scenario: Post The Grade To WritingSpace GBR
Given I browse the WritingSpace Assessment Mock Application URL
When I enter the "GradePost" URL in Mock Application
And I select the "Post" request type option
And I send the "GradePost" request to Mock GBR Application 
Then I should see the grade post response in mock application