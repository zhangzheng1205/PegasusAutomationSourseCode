Feature: CourseSpaceAdmin
					As a CS Admin 
					I want to manage all the coursespace admin related usecases 
					so that I would validate all the coursespace admin scenarios are working fine.

#Purpose: Approve master course in Course space
#HED_MIL_PWF_149
Scenario: Approve Master Course by Cs Admin
When I navigate to "Manage Products" subtab from "Publishing" tab
Then I should be on the "Manage Products" page
When I search the "MyItLabSIM5MasterCourse" course in coursespace
Then I should be able to see the searched "MyItLabSIM5MasterCourse" course in the left frame
When I click on "Approve" cmenu option of course in coursespace
Then I should see the successfull message "Published course marked as Approved."

#Purpose: UseCase To create Program in course space
Scenario: Program Creation In CourseSpace by Cs Admin
When I navigate to "Manage Programs" subtab from "Publishing" tab
Then I should be on the "Manage Programs" page
When I click on the Create New Program  Link
And I create the "HedMil" Program in coursespace
Then I should see the successfull message "Program created successfully."

#Purpose: Create Program Product
#HED_MIL_PWF_152
Scenario: Create Program Product by Cs Admin
When I navigate to "Manage Products" subtab from "Publishing" tab
Then I should be on the "Manage Products" page
When I click on the 'Create New Product' Link
And I create "HedMilProgram" type product using "HedMil" program type 
Then I should see the successfull message "New product created successfully."

#Purpose: Create General Product
#HED_MIL_PWF_153
Scenario: Create General Product by Cs Admin
When I navigate to "Manage Products" subtab from "Publishing" tab
Then I should be on the "Manage Products" page
When I click on the 'Create New Product' Link
And I create "HedMilGeneral" type product using "HedMil" program type 
Then I should see the successfull message "New product created successfully."

#Purpose: To associate courses to the General Product
#HED_MIL_PWF_154
Scenario: Associate Course to the General Product by Cs Admin
When I navigate to "Manage Products" subtab from "Publishing" tab
Then I should be on the "Manage Products" page
When I search the "MyItLabSIM5MasterCourse" course in coursespace
Then I should be able to see the searched "MyItLabSIM5MasterCourse" course in the left frame
When I select course in left frame
And I select product type "HedMilGeneral" in right frame
When I associate the course to Pegasus product
Then I should see the successfull message "Approved courses programmed successfully."

#Purpose: To associate courses to the Program Type Product
#HED_MIL_PWF_155
Scenario: Associate Course to the Program Type Product by Cs Admin
When I navigate to "Manage Products" subtab from "Publishing" tab
Then I should be on the "Manage Products" page
When I search the "MyItLabSIM5MasterCourse" course in coursespace
Then I should be able to see the searched "MyItLabSIM5MasterCourse" course in the left frame
When I select course in left frame
And I select product type "HedMilProgram" in right frame
When I associate the course to Pegasus product
Then I should see the successfull message "Approved courses programmed successfully."

#Purpose : Delete the Created General Type Product
Scenario: Delete the Created General Type Product by CS Admin
When I navigate to "Manage Products" subtab from "Publishing" tab
Then I should be on the "Manage Products" page
When I search the product type "HedMilGeneral" in right frame
And I click on "Delete" cmenu option of product in coursespace
Then I should see the successfull message "Products deleted successfully."

#Purpose : Delete the Created Program Type Product
Scenario: Delete the Created Program Type Product by CS Admin
When I navigate to "Manage Products" subtab from "Publishing" tab
Then I should be on the "Manage Products" page
When I search the product type "HedMilProgram" in right frame
And I click on "Delete" cmenu option of product in coursespace
Then I should see the successfull message "Products deleted successfully."

#Purpose: Approve Empty Course in Course space
Scenario: Approve Empty Course by Cs Admin
When I navigate to "Manage Products" subtab from "Publishing" tab
Then I should be on the "Manage Products" page
When I search the "HedEmptyClass" course in coursespace
Then I should be able to see the searched "HedEmptyClass" course in the left frame
When I click on "Approve as Empty Class" cmenu option of course in coursespace
Then I should see the successfull message "Published course marked as Approved."




