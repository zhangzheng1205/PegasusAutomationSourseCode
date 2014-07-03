Feature: CTGPublisherAdmin
					As a CTG Publisher Admin 
					I want to manage all the publisher admin related usecases 
					so that I would validate all the publisher admin scenarios are working fine.

Background:
#Purpose: Open Ws Url
Given I browsed the login url for "DPCTGPPublisherAdmin"
When I login to Pegasus as "DPCTGPPublisherAdmin" in "WorkSpace"
Then I should be logged in successfully
Given I am on the "Workspaces" page

#Purpose : View the Default Contents For DPCTGPublisherAdmin
Scenario: Default view of the Workspaces tab for CTG Publisher admin
Then I should see Preference and Workspaces Tabs
And I should see default view as Workspaces tab
And I should see the default contents of Workspace tab
When I "Sign out" from the "DPCTGPPublisherAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: UseCase To Create the Workspace by CTG Publisher Admin
Scenario: Creating the Workspace by CTG Publisheradmin
When I "Create" the new "DPWorkSpace" admin
Then I should see the successfull message "New workspace created successfully."

#Purpose: UseCase To Edit the Workspace by CTG Publisher Admin
Scenario: Editing the Workspace by CTG Publisheradmin
When I search the "DPWorkSpace" and click on the "Update" cmenu link
Then I should see the cmenu options
When I click on the 'Edit Workspace info' cmenu option
Then I should see the displayed Textbox fields 
When I "Update" the new "DPWorkSpace" admin
Then I should see the successfull message "Workspace updated successfully."

#Purpose: UseCase To Delete the Workspace by CTG Publisher Admin
Scenario: Deleting the Workspac by CTG Publisheradmin
When I search the "DPWorkSpace" and click on the "Delete" cmenu link
And I click the delete link
Then I should see the successfull message "Workspaces deleted successfully."

#Purpose : View the Default Contents For DPCTGPublisherAdmin
Scenario: Uploading The Branding Image In Preference by CTG Publisheradmin
When I navigate to the "Preferences" tab
Then I should be on the "Preferences" page
And I should see all the default contents in the 'Preferences' page
When I upload the branding Image
And I enter the Welcome text and Registration URL
And I click on the Save button
Then I should see the successfull message "Preferences updated successfully."
When I navigate to the "Workspaces" tab
And I "Sign out" from the "DPCTGPPublisherAdmin"
Then I should see the Welcome text displayed in login page
And I should see the successfull message "You have been signed out of the application."
