Feature: PEGASUS-3786- Create Rumba Product , Licenses and User(s)
					As a Rumba Admin 
					I want to manage all the rumba admin related usecases 
					so that I would validate all the rumba admin scenarios are working fine.

Background: 
#Purpose : Open Rumba url
Given I browsed the login url for "RUMBAAdmin"
When I login to rumba as "RUMBAAdmin"
Then I should be logged in successfully

#Purpose : Rumba Licensing the product
Scenario:  Create Rumba Products and Licenses
Given I am on the "Welcome to RADmin" page
When I create a organizational product
Then I should see the product successfully created with valid product id
When I create a organizational resource
Then I should see the resource successfully created with valid resource id
When I add the created resource to the product
Then I should see the resource successfully added in the created product
When I place a new order for a license to use a "PowerSchool" level product in "DigitalPath"
Then I should see product order placed successfully
When I "Sign Out" from Rumba
Then I should see the "Signed Out" message

#Purpose: Create Domain Student By Radmin
Scenario: Create Domain Student(PS) by Radmin
Given I am on the "Welcome to RADmin" page
When I select the "Create a User Account" tab
Then I should be on the "Create a User Account" page
When I create a "RumbaStudent" user as radmin in "PowerSchool" organization in "DigitalPath"
Then I should see the created "RumbaStudent" in manage frame
When I select the "Search" tab
And I search the "RumbaStudent" user 
Then I should see the created "RumbaStudent" user
When I save the Owner ID of "RumbaStudent" user
And I "Sign Out" from Rumba
Then I should see the "Signed Out" message

#Purpose: Create Domain Teacher By Radmin
Scenario: Create Domain Teacher(PS) by Radmin
Given I am on the "Welcome to RADmin" page
When I select the "Create a User Account" tab
Then I should be on the "Create a User Account" page
When I create a "RumbaTeacher" user as radmin in "PowerSchool" organization in "DigitalPath"
Then I should see the created "RumbaTeacher" in manage frame
When I select the "Search" tab
And I search the "RumbaTeacher" user 
Then I should see the created "RumbaTeacher" user
When I save the Owner ID of "RumbaTeacher" user
And I "Sign Out" from Rumba
Then I should see the "Signed Out" message




