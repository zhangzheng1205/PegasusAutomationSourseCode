Feature: PEGASUS-8522 - Use PSN+ profile name and k12int parameter on all Login page redirects
						As a Rumba Student
						I want to login And logout
						so that I would be able to see the required Contineo parameters.	
											
Background: 
Given I browsed the login url for "RumbaStudent"
	
#Purpose: Validate Contineo required parameters on RUL URL 
Scenario: Verify Contineo Required Parameters before login
Then I should see Contineo parameters "Profile" and "k12Int" in the Rumba Universal Login URL

#Purpose: Validate Contineo required parameters for RumbaStudent after Logout
Scenario: Verify Contineo Required Parameters After Logout
Then I login to Pegasus as "RumbaStudent" in "CourseSpace"
Then I should be logged in successfully
When I "Sign Out" from the "RumbaStudent"
Then I should see the "Signed Out" message
When I click on the Sign In "button" in Rumba Page
Then I should see Contineo parameters "Profile" and "k12Int" in the Rumba Universal Login URL













