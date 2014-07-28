Feature: 27617:Automation: (Admin Modules) Verifying Start Copy Functuionality
         As a Program admin
		 I want to create new template
		 But I should see the message "You cannot copy this course due to publisher restrictions."
		 As PMC is enabled with stop copy option.
         



#purpose to open CsSmsInstructore Home Page
Scenario: Create Template as a Course Space Instructor 
When I create Template using "MySpanishLabMasterVm" course as a program admin
Then I should see the successfull message "You cannot copy this course due to publisher restrictions."
























