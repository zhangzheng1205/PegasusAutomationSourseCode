Feature: PEGASUS-27620: Automation: (Admin Modules) Validating PMCID for created shared Library course
					As a CS Program admin
					I want to search a Template 
					so that I can create a shared library from the searched template.
					

#Purpose: Open CS Url and navigate to my course and test banks.
Background:
Given I browsed the login url for "CsSmsInstructor"
When I logged into the Pegasus as "CsSmsInstructor" in "CourseSpace"
When I enter in the "ProgramCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Program Administration" page

#Purpose: To copy as shared library.
Scenario: To copy as shared library.
When I click the "Copy as Shared Library" option
Then I should be on the "Copy as Shared Library" page
When I click "Save" button to "Copy as Shared Library"
Then I should see the successfull message "Please wait… copying is in progress. This may take up to 24 hours. To see your copies, you may need to refresh your screen. To view items you copied as a Shared Library, go to the Sections tab."
