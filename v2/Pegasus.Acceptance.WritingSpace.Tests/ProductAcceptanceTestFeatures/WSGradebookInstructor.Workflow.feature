Feature: WS Gradebook Instructor
				As a MMND Instructor 
				I want to manage all the MMND Instructor Gradebook related usecases 
				so that I would validate all the MMND Instructor Gradebook scenarios are working fine.


#Purpose: Writingspace Course Assessment Displayed in Gradebook
Scenario: Writingspace Activity Displayed in Gradebook by MMND Instructor
When I click on "Course Home" subtab
And I click the "Grades" link
Then I should see the "WritingSpace" activity in Gradebook
And I should see the "WritingSpace" activity with grade for the enrollled "MMNDStudent"

#Purpose: Display Of Cmenu Options For Writing Space Activity
Scenario:Display Of Cmenu Options For Writing Space Activity by MMND Instructor
When I click the "WritingSpace" activity cmenu option
Then I should able to see the Display of c-menu options for activity
| ExpectedResult       | ActualResult         |
| Apply Grade Schema   | Apply Grade Schema   |
| Hide for Student     | Hide for Student     |
| Synchronize with LMS | Synchronize with LMS |
| Export               | Export               |
| Save to Custom View  | Save to Custom View  |

#Purpose: To Verify the functionality of "Hide For Student" Cmenu Option
Scenario: To Verify the functionality of Hide For Student Cmenu Option by MMND Instructor
When I click the "Grades" link
And I click on cmenu "HideforStudent" of "WritingSpace" Activity
Then I should see the successfull message "Column successfully hidden." in gradebook

#Purpose: To Verify the functionality of 'Save to Custom View' Cmenu Option
Scenario:To Verify the functionality of Save to Custom View Cmenu Option by MMND Instructor
When I click on cmenu "SavetoCustomView" of "WritingSpace" Activity
Then I should see the successfull message "Column successfully saved to Custom View." in gradebook
When I click on "Course Home" subtab
And I click the "Custom_View" link
When I click on cmenu "RemovefromCustomView" of asset "WritingSpace" in Custom View
Then I should see the successfull message "Column successfully removed from Custom View." in gradebook

#Purpose: To Verify Display of Grade Cmenu Option in Gradebook
Scenario: Verify Display of Grade Cmenu Option in Gradebook by MMND Instructor
When I click on "WritingSpace" Activity grade cmenu
Then I should be able to see "View Grade History" grade cmenu

#Purpose: To Verify the functionality of 'Apply Grade Schema' Activity Cmenu in Gradebook
Scenario: Verify the functionality of Apply Grade Schema Activity Cmenu in Gradebook by MMND Instructor
When I click on cmenu "ApplyGradeSchema" of "WritingSpace" Activity
And I 'Apply' the grade schema for the submitted activity
Then I should see the successfull message "Schema applied successfully." in gradebook
When I click on cmenu "RemoveGradeSchema" of "WritingSpace" Activity
Then I should see the successfull message "Grade schema removed successfully." in gradebook


