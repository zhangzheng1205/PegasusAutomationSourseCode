Feature: CourseSpaceAdmin
					As a CS Admin 
					I want to manage all the coursespace admin related usecases 
					so that I would validate all the coursespace admin scenarios are working fine.

#Purpose: Approve master course in Course space
@ApproveCourse
Scenario: Approve Master Course by Cs Admin
When I navigate to "Manage Products" subtab from "Publishing" maintab
Then I should be on the "Manage Products" page
When I search the "MySpanishLabMaster" course in coursespace
Then I should be able to see the searched "MySpanishLabMaster" course in the left frame
When I click on "Approve" cmenu option of course in coursespace
Then I should see the successfull message "Published course marked as Approved."

#Given I am on the 'Manage Programs' Page
#Purpose: UseCase To create Program in course space
@CreateProgram
Scenario: Program Creation In CourseSpace by Cs Admin
When I navigate to "Manage Programs" subtab from "Publishing" tab
Then I should be on the "Manage Programs" page
When I click on the Create New Program  Link
And I create the "HedCore" Program in coursespace
Then I should see the successfull message "Program created successfully."

#Given I am on the 'Manage Products' Page
#Purpose: Create General Product
@CreateProduct
Scenario: Create General Product by Cs Admin
When I navigate to "Manage Products" subtab from "Publishing" maintab
Then I should be on the "Manage Products" page
When I click on the 'Create New Product' Link
And I create "HedCoreGeneral" type product using "HedCore" program type 
Then I should see the successfull message "New product created successfully."

#Purpose: Create Program Product
Scenario: Create Program Product by Cs Admin
When I navigate to "Manage Products" subtab from "Publishing" maintab
Then I should be on the "Manage Products" page
When I click on the 'Create New Product' Link
And I create "HedCoreProgram" type product using "HedCore" program type 
Then I should see the successfull message "New product created successfully."

#Purpose: To associate courses to the General Product
Scenario: Associate Course to the General Product by Cs Admin
When I navigate to "Manage Products" subtab from "Publishing" maintab
Then I should be on the "Manage Products" page
When I search the "MySpanishLabMaster" course in coursespace
Then I should be able to see the searched "MySpanishLabMaster" course in the left frame
When I select course in left frame
And I select product type "HedCoreGeneral" in right frame
When I associate the course to Pegasus product
Then I should see the successfull message "Approved courses programmed successfully."

#Purpose: To associate courses to the Program Type Product
@AssociateToProgram
Scenario: Associate Course to the Program Type Product by Cs Admin
When I navigate to "Manage Products" subtab from "Publishing" maintab
Then I should be on the "Manage Products" page
When I search the "MySpanishLabMaster" course in coursespace
Then I should be able to see the searched "MySpanishLabMaster" course in the left frame
When I select course in left frame
And I select product type "HedCoreProgram" in right frame
When I associate the course to Pegasus product
Then I should see the successfull message "Approved courses programmed successfully."


#Purpose : Creating the System Announcement
Scenario: Create System Announcement by CS Admin
When I navigate to "Course Enrollment" tab of the "Course Enrollment" page
Then I should be on the "Course Enrollment" page
When I change the WS Admin Time Zone to Indian GMT in MyProfile
And I navigate to "Announcement" tab of the "Announcement Archive" page
Then I should be on the "Announcement Archive" page
When I create "CsSystem" Announcement
Then I should see the successfull message "Announcement created successfully."

#Purpose : Delete the Created General Type Product
Scenario: Delete the Created General Type Product by CS Admin
When I navigate to "Manage Products" subtab from "Publishing" maintab
Then I should be on the "Manage Products" page
When I search the product type "HedCoreGeneral" in right frame
And I click on "Delete" cmenu option of product in coursespace
Then I should see the successfull message "Products deleted successfully."

#Purpose : Delete the Created Program Type Product
Scenario: Delete the Created Program Type Product by CS Admin
When I navigate to "Manage Products" subtab from "Publishing" maintab
Then I should be on the "Manage Products" page
When I search the product type "HedCoreProgram" in right frame
And I click on "Delete" cmenu option of product in coursespace
Then I should see the successfull message "Products deleted successfully."

#Purpose: Approve Empty Course in Course space
Scenario: Approve Empty Course by Cs Admin
When I navigate to "Manage Products" subtab from "Publishing" maintab
Then I should be on the "Manage Products" page
When I search the "HedEmptyClass" course in coursespace
Then I should be able to see the searched "HedEmptyClass" course in the left frame
When I click on "Approve as Empty Class" cmenu option of course in coursespace
Then I should see the successfull message "Published course marked as Approved."


