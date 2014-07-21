Feature: CTGPublisherAdmin
					As a CTG Publisher Admin 
					I want to manage all the publisher admin related usecases 
					so that I would validate all the publisher admin scenarios are working fine.

#Purpose : View the Default Contents For DPCTGPublisherAdmin
Scenario: Default view of the Workspaces tab for CTG Publisher admin
When I navigate to the "Workspaces" tab
Then I should be on the "Workspaces" page
Then I should see Preference and Workspaces Tabs
And I should see default view as Workspaces tab
And I should see the default contents of Workspace tab

#Purpose: UseCase To Create the Workspace by CTG Publisher Admin
Scenario: Creating the Workspace by CTG Publisheradmin
When I navigate to the "Workspaces" tab
Then I should be on the "Workspaces" page
When I "Create" the new "DPWorkSpace" admin
Then I should see the successfull message "New workspace created successfully."

#Purpose: UseCase To Edit the Workspace by CTG Publisher Admin
Scenario: Editing the Workspace by CTG Publisheradmin
When I navigate to the "Workspaces" tab
Then I should be on the "Workspaces" page
When I search the "DPWorkSpace" and click on the "Update" cmenu link
Then I should see the cmenu options
When I click on the 'Edit Workspace info' cmenu option
Then I should see the displayed Textbox fields 
When I "Update" the new "DPWorkSpace" admin
Then I should see the successfull message "Workspace updated successfully."

#Purpose: UseCase To Delete the Workspace by CTG Publisher Admin
Scenario: Deleting the Workspac by CTG Publisheradmin
When I navigate to the "Workspaces" tab
Then I should be on the "Workspaces" page
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
