Feature: CourseSpaceAssignsContent
                    As a CS Teacher 
					I want to manage all the coursespace assign content usecases 
					so that I would validate all the assign content scenarios are working fine.

#Purpose : Open the CS url 
Background: 
Given I browsed the login url for "NovaNETCsTeacher"
When I login to Pegasus as "NovaNETCsTeacher" in "CourseSpace"
Then I should be logged in successfully

#Purpose : To assign activity by CS Teacher through assignment calendar
Scenario: Calendar Creation by Cs Teacher
Given I am on the "Global Home" page
When I enter in to "NovaNETTemplate" class
And I navigate to the "Content" tab
Then I should be on the "Content" page
When I navigate to the "Calendar" tab
Then I should be on the "Calendar" page
When I Setup the Calendar
And  I drag and drop the "01:The American Revolution" to the calendar
Then I should see the content message "Your content is being prepared and will be available soon." 
When I "Sign Out" from the "NovaNETCsTeacher"
Then I should see the "Signed Out" message

#Purpose : Assign to copy state of activity by CS Teacher
Scenario: Assign To Copy State of Calendar Creation by Cs Teacher
Given I am on the "Global Home" page
When I enter in to "NovaNETTemplate" class
And I navigate to the "Content" tab
Then I should be on the "Content" page
When I navigate to the "Calendar" tab
Then "01:The American Revolution" should be successfully assigned to the calendar
When I "Sign Out" from the "NovaNETCsTeacher"
Then I should see the "Signed Out" message