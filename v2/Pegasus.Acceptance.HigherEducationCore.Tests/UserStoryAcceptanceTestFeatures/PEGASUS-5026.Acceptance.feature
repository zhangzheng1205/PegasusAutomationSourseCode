#Purpose : Feature Description
Feature: PEGASUS-5026 - Include Unread Comments channel in Customize Notification
	                    As a Master Course Author
	                    I want to enable the checkbox 'Notify me when students have unread instructor comments' in Customize Notification popup
						So that I can validate Unread Comments channel option present in Today's view page


# Used MySpanishLabMaster course
#Purpose: Remove Unread Comments channel in Customize Notification 
Scenario: Remove Unread Comments channel in Today's view page for HedWsInstructor 
When I navigate to "Today's View" tab of the "Today's View" page
Then I should be on the "Today's View" page
When I click on the CUSTOMIZE button 
Then I should be on "Customize Notifications" popup Window
When I select the "About This Course" channel as default in Default View drop down
And I uncheck the 'Notify me when student have unread instructor comments' checkbox option
When I click on Save and Close button
Then I should not see "Unread Comments" Channel in Today's view page

# Used MySpanishLabMaster course
#Purpose: Include Unread Comments channel in Customize Notification 
Scenario: Include Unread Comments channel in Today's view page for HedWsInstructor 
When I navigate to "Today's View" tab of the "Today's View" page
Then I should be on the "Today's View" page
When I click on the CUSTOMIZE button 
Then I should be on "Customize Notifications" popup Window
When I select the "Unread Comments" channel as default in Default View drop down
And I check the 'Notify me when student have unread instructor comments' checkbox option
When I click on Save and Close button
Then I should see "Unread Comments" Channel in Today's view page



