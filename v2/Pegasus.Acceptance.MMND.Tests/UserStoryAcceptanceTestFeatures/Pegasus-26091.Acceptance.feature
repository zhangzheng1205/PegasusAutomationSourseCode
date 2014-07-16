Feature: WS Gradebook Instructor
				As a MMND Instructor 
				I want to manage all the MMND Instructor Gradebook related usecases 
				so that I would validate all the MMND Instructor Gradebook scenarios are working fine.


Background: 
Given I browsed the URL of "MMNDInstructor"
When I login to MMND Cert as "MMNDInstructor"
Then I should be logged in successfully as "MMNDInstructor"
Given I am on the "MyLab & Mastering | Pearson" page
When I navigate inside "MMNDNonCoOrdinate" course in "MMNDInstructor"
Then I should be on the "Course Home" page

#Purpose: Start and Stop LMS Synch for activity in Gradebook
Scenario: To Verify Start/Stop LMS Grade Synch for Test Activity Displayed in Gradebook by MMND Instructor
When I click on "Course Home" subtab
And I click the "Grades" link
Then I should see the "Test" activity in Gradebook
When I click the "Test" activity cmenu option
Then I should able to see the Display of c-menu options for activity
| ExpectedResult		   | ActualResult         |
| Stop LMS Synchronization | Stop LMS Synchronization |
When I click on cmenu "StopLMSSynchronization" of "Test" Activity
Then I should see the successfull message "LMS Synchronization is stopped" in gradebook
When I click the "Test" activity cmenu option
Then I should able to see the Display of c-menu options for activity
| ExpectedResult       | ActualResult         |
| Synchronize with LMS | Synchronize with LMS |
When I click on cmenu "SynchronizewithLMS" of "Test" Activity
Then I should see the successfull message "LMS Synchronization is enabled" in gradebook

#Purpose: Start and Stop LMS Synch for calculated column activity in Gradebook
Scenario: To Create Custom Column And Verify LMS Grade Synch in Gradebook by MMND Instructor
When I click on "Course Home" subtab
And I click the "Grades" link
Then I should see the "Test" activity in Gradebook
And I should see the "Homework" activity in Gradebook
When I click on the Create Column drop down and select "Calculated" Column
Then I should be on the "Create Calculated Column" window
When I enter Calculated Column name
And I select checkbox of activities "Test" and "Homework" 
And I click the on Add button 
And I click on Save Button
Then I should see the "CalculatedColumn" activity in Gradebook
When I click the "CalculatedColumn" activity cmenu option
Then I should able to see the Display of c-menu options for activity
| ExpectedResult       | ActualResult         |
| Synchronize with LMS | Synchronize with LMS |
When I click on cmenu "SynchronizewithLMS" of "CalculatedColumn" Activity
Then I should see the successfull message "LMS Synchronization is enabled" in gradebook
#When I click the "CalculatedColumn" activity cmenu option
#Then I should able to see the Display of c-menu options for activity
#| ExpectedResult		   | ActualResult         |
#| Stop LMS Synchronization | Stop LMS Synchronization |
#When I click on cmenu "StopLMSSynchronization" of "CalculatedColumn" Activity
#Then I should see the successfull message "LMS Synchronization is stopped" in gradebook