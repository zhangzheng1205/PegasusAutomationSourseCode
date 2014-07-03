Feature: PEGASUS-10482: Customize Multiple/Single Content In Curriculum Tab and Launch MGM by CS Teacher
		As a CS Teacher
		I want to navigate inside Class 
		so that I can customize the content.	
#Purpose: Open CS Teacher Url
Background: 
Given I browsed the login url for "DPCsTeacher"
When I login to Pegasus as "DPCsTeacher" in "CourseSpace"
Then I should be logged in successfully

#Purpose: Customize Single Content In Curriculum Tab and Launch MGM by CS Teacher
Scenario: Customize Single Content In Curriculum Tab and Launch MGM by CS Teacher
Given I am on the "Home" page
When I navigate to the "Curriculum" tab
And I customize the content "Test" in curriculum tab
Then I should see the successfull message "You have successfully added custom content." in Curriculum tab
When I click on the custom content link
Then I should see the ML in the custom content view
When I click on the expand button of MasterLibrary in the custom content view
Then I should see the customized "Test" content of the ML in the custom content view
When I navigate to the "Home" tab
Then I should be on the "Home" page
When I "Sign Out" from the "DPCsTeacher"
Then I should see the "Signed Out" message

#Purpose: Customize multiple Content In Curriculum Tab and Launch MGM by CS Teacher
Scenario: Customize multiple Content In Curriculum Tab and Launch MGM by CS Teacher
Given I am on the "Home" page
When I navigate to the "Curriculum" tab
And I customize the content "Test" in curriculum tab
Then I should see the successfull message "You have successfully added custom content." in Curriculum tab
When I click on the custom content link
Then I should see the ML in the custom content view
When I click on the expand button of MasterLibrary in the custom content view
Then I should see the customized "Test" content of the ML in the custom content view
When I navigate to the "Curriculum" tab
And I customize the StudyPlan "SkillStudyPlan" in curriculum tab
Then I should see the successfull message "You have successfully added custom content." in Curriculum tab
When I click on the custom content link
Then I should see the ML in the custom content view
When I click on the expand button of MasterLibrary in the custom content view
Then I should see the customized "SkillStudyPlan" content of the ML in the custom content view
When I navigate to the "Home" tab
Then I should be on the "Home" page
When I "Sign Out" from the "DPCsTeacher"
Then I should see the "Signed Out" message

