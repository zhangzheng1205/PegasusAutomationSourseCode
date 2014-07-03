Feature: CourseSpaceAdmin
	                As a CS Admin 
					I want to manage all the coursespace admin related usecases 
					so that I would validate all the coursespace admin scenarios are working fine.

#Purpose: Open CS Url
Background: 
Given I browsed the login url for "HedCsAdmin"
When I logged into the Pegasus as "HedCsAdmin" in "CourseSpace"
Then I should logged in successfully

#Purpose: Approve master course in Course space
Scenario: Approve General Course by Cs Admin
Given I am on the "Course Enrollment" page
When I navigate to the "Publishing" tab
And I select the "Manage Products" tab
Then I should be on the "Manage Products" page
When I search the "HEDGeneral" course in coursespace
Then I should be able to see the searched "HEDGeneral" course in the left frame
When I click on "Approve" cmenu option of course in coursespace
Then I should see the successfull message "Published course marked as Approved."
When I "Sign out" from the "HedCsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: UseCase To create Program in course space
Scenario: Program Creation In CourseSpace by Cs Admin
Given I am on the 'Manage Programs' Page
When I click on the Create New Program  Link
And I create the "HedCore" Program in coursespace
Then I should see the successfull message "Program created successfully."
When I "Sign out" from the "HedCsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: Create General Product
Scenario: Create General Product by Cs Admin
Given I am on the 'Manage Products' Page
When I click on the 'Create New Product' Link
And I create "HedCoreGeneral" type product using "HedCore" program type 
Then I should see the successfull message "New product created successfully."
When I "Sign out" from the "HedCsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To associate courses to the General Product And Get IntegrationPointID 
Scenario: Associate Course to the General Product And Get IntegrationPointID by Cs Admin
Given I am on the 'Manage Products' Page
When I search the "HEDGeneral" course in coursespace
Then I should be able to see the searched "HEDGeneral" course in the left frame
When I select course in left frame
And I select product type "HedCoreGeneral" in right frame
And I associate the Master Course through CCNG Integration to pegasus product 
Then I should see the successfull message "Approved courses programmed successfully."
When I get the 'IntegrationPointID' in general product
And I "Sign out" from the "HedCsAdmin"
Then I should see the successfull message "You have been signed out of the application."