Feature: CTGPublisherAdmin
					As a CTG Publisher Admin 
					I want to manage all the publisher admin related usecases 
					so that I would validate all the publisher admin scenarios are working fine.

#Purpose : View the Default Contents For DPCTGPublisherAdmin
Scenario: Default view of the Workspaces tab for CTG Publisher admin
Then I should see Preference and Workspaces Tabs
And I should see default view as Workspaces tab
And I should see the default contents of Workspace tab

#Purpose: Creating the Workspace by CTG Publisheradmin
# TestCase Id : HED_MIL_PWF_003
Scenario: Creating the Workspace by CTG Publisheradmin
When I "Create" the new "HedWsAdmin" admin
Then I should see the successfull message "New workspace created successfully."
