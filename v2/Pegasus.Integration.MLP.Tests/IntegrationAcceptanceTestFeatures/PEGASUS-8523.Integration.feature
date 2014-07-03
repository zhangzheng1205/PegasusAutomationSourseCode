Feature: PEGASUS-8523: ECollege Generate Integration Point Id
					As a CS Admin 
					I want to reterive eCollege Integration point id  
					so that I would validate the Integration point id is generating successfully.

#Purpose: Open CS Admin Url
Background: Open CS Admin Url
Given I browsed the login url for "HedCsAdmin"
When I logged into the Pegasus as "HedCsAdmin" in "CourseSpace"
Then I should logged in successfully
Given I am on the 'Manage Products' Page

#Purpose: Create General Product
@CreateProduct
Scenario: Create General Product by Cs Admin
When I click on the 'Create New Product' Link
And I create "HedCoreGeneral" type product using "HedCore" program type 
Then I should see the successfull message "New product created successfully."
When I "Sign out" from the "HedCsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To associate courses to the General Product through eCollege integration
Scenario: Associate Course to the General Product By Selecting eCollege Delivery Preference by Cs Admin
When I search the "MySpanishLabMasterVm" course in coursespace
Then I should be able to see the searched "MySpanishLabMasterVm" course in the left frame
When I select course in left frame
And I select product type "HedCoreGeneral" in right frame
When I associate the course to product by selecting "eCollege" delivery preference
Then I should see the successfull message "Approved courses programmed successfully."
When I "Sign out" from the "HedCsAdmin"
Then I should see the successfull message "You have been signed out of the application."

#Purpose: To validate ECollege TPI Integration Point Id
Scenario: Validate eCollege TPI Integration Point ID by Cs Admin
When I select product type "HedCoreGeneral" in right frame
And I select the ""MySpanishLabMasterVm" course "Preferences" option from the cMenu
Then I should see the eCollege TPI integration point Id
When I "Sign out" from the "HedCsAdmin"
Then I should see the successfull message "You have been signed out of the application."

