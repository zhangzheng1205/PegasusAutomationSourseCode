Feature: CourseSpaceInstructorTodaysView
					As a CS Instructor 
					I want to manage all the Coursespace Instructor Today's View related usecases 
					so that I would validate all the coursespace instructor Today's View related scenarios are working fine.


#Purpose : To validate display of alert counts and contents in Not Passed alert channel
#Products : MGM Grade 6
#Pre condition : Student should not meet the threshold of the activity
#Dependency : One time dependent(This scenario can be run against existing data)
Scenario: Teacher views Alert update in Not Passed channel of Overview page for Activity
When I navigate to the "Classes" tab
And I select DigitalPath class "DigitalPathMasterLibrary" from Class selector dropdown
And I navigate to the "Overview" tab
Then I should see the "Notifications" channels in Overview page
And I should see the alert count updated as "1" in "Not Passed" channel
When I click on the "Not Passed" option
Then I should see "1" activity in the "Not Passed" channel

#Purpose : To validate display of alert counts and contents in New Grades alert channel
#Products : MGM Grade 6
#Pre condition : Student should have submitted the activity
Scenario: Teacher views Activity Alerts in New Grades channel
When I navigate to the "Home" tab
Then I should be on the "Home" page
When I enter into the DP "DigitalPathMasterLibrary" class
Then I should be on the "Classes" page
When I navigate to the "Overview" tab
Then I should be on the "Classes" page
Then I should see the alert count updated as "1" in "New Grades" channel
When I click on the "New Grades" option
Then I should see "1" activity in the "New Grades" channel

#Purpose : To validate display of alert counts in Idle Students alert channel
#Products : MGM Grade 6
#Pre condition : Student should be enrolled to the class and should be idle in the class
Scenario: Teacher views Idle Students in New Grades channel
When I navigate to the "Home" tab
Then I should be on the "Home" page
When I enter into the DP "DigitalPathMasterLibrary" class
Then I should be on the "Classes" page
When I navigate to the "Overview" tab
Then I should be on the "Classes" page
When I click on the "Idle Students" option
Then I should see "1" Idle Student "DPCsIdleStudent" of type "IdleScore" in "Idle Students" channel

#Purpose : To validate display of alert counts in Past Due: Not Submitted alert channel
#Products : MGM Grade 6
#Pre condition : Activity should have been assigned and should be past due
Scenario: Teacher views Past Due: Not Submitted channel
When I navigate to the "Classes" tab
And I select DigitalPath class "DigitalPathMasterLibrary" from Class selector dropdown
And I navigate to the "Overview" tab
Then I should see the alert count updated as "3" in "Past Due: Not Submitted" channel
When I click on the "Past Due: Not Submitted" option
Then I should see "3" activity in the "Past Due: Not Submitted" channel