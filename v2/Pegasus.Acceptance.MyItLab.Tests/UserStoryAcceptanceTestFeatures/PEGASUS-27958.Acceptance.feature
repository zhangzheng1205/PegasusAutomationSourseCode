Feature: PEGASUS-27958
	As a CS Instructor 
	I want to manage Functionality of Delete / Copy / Cut / Paste in Advanced Content Library
	so that I would validate Functionality of Delete / Copy / Cut / Paste, related scenarios are working fine.

#As a Teacher, I should be able to perform Remove / Copy / Cut / Paste functionality in Advanced Content Library of Master Course

Scenario: Delete functionality in Advanced Content Library
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I select Advanced Options link
And I select checkbox of 1 assets 
Then "Delete" button on Content Library header should get "Enabled"
When I select "Delete" button on Content Library header
Then A "Delete" confirmation pop up should display with "OK" button and "Cancel" button
When I click on OK button on Delete confirmation pop up 
Then I should see the successfull message "Items deleted successfully."

Scenario: Delete functionality in Advanced Content Library Multiple Assets
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I select Advanced Options link
And I select checkbox of 3 assets 
Then "Delete" button on Content Library header should get "Enabled"
When I select "Delete" button on Content Library header
Then A "Delete" confirmation pop up should display with "OK" button and "Cancel" button
When I click on OK button on Delete confirmation pop up 
Then I should see the successfull message "Items deleted successfully."

Scenario: Cut Paste functionality in Advanced Content Library
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I select Advanced Options link
And I select checkbox of 3 assets 
Then "Cut" button on Content Library header should get "Enabled"
When I select "Cut" button on Content Library header
Then Count 3 should be displayed in Clipboard Items
And Asset title should display in "Red" color and "Italic" style. 
When I select "Paste" button on Content Library header
And I Select "PasteAtTop" on Paste Advanced Options on Content Library
Then I should see the successfull message "Items copied successfully."
And Asset should should display at "Top" place

Scenario: Copy Paste functionality in Advanced Content Library
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I select Advanced Options link
And I select checkbox of 1 assets 
Then "Copy" button on Content Library header should get "Enabled"
When I select "Copy" button on Content Library header
Then Count 1 should be displayed in Clipboard Items
And Asset title should display in "Red" color and "Italic" style. 
When I select "Paste" button on Content Library header
And I Select "PasteAtTop" on Paste Advanced Options on Content Library
Then I should see the successfull message "Items copied successfully."
And Asset should should display at "Top" place

Scenario: Copy Paste functionality in Advanced Content Library Multiple Assets
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I select Advanced Options link
And I select checkbox of 1 assets 
Then "Copy" button on Content Library header should get "Enabled"
When I select checkbox of 4 assets 
Then "Copy" button on Content Library header should get "Enabled"
When I select "Copy" button on Content Library header
Then Count 3 should be displayed in Clipboard Items
And Asset title should display in "Red" color and "Italic" style. 
When I select "Paste" button on Content Library header
And I Select "PasteAtTop" on Paste Advanced Options on Content Library
Then I should see the successfull message "Items copied successfully."
And Asset should should display at "Top" place


