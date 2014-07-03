Feature: WorkspaceInstructorGlobalHome
					As a Ws Instructor 
					I want to manage all the workspace Instructor global home page related usecases 
					so that I would validate all the workspace Instructor scenarios are working fine.

Background:
#Purpose: Open Ws Url 
Given I browsed the login url for "HedWsInstructor"
When I logged into the Pegasus as "HedWsInstructor" in "WorkSpace"
Then I should logged in successfully

#Purpose: To View System Announcement
# TestCase Id: HSS_Core_PWF_015
Scenario: View System Announcement by WS Teacher
When I changed the WS User Time Zone to Indian GMT in MyProfile
And I click on the "WsSystem" Announcement listed in Announcement Channel
Then I should see the details of  "WsSystem" Announcement in Announcement Frame
When I "Sign out" from the "HedWsInstructor"
Then I should see the successfull message "You have been signed out of the application."

