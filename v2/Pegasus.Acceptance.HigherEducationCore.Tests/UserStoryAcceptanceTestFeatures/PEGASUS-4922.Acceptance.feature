#Purpose : Feature Description
Feature: PEGASUS-4922 - Display Count and Activities in Today's View for 'Unread Comments' Channel
	                    As a Master Course Author
	                    I should be able to see the Count of Unread Comments and Should be able to see the related activities in right frame
						So that I can validate the increment/decreament of count in Unread Comments channel option
						

#Purpose: Open the HEDWSInstructor Url
Background: 
Given I browsed the login url for "HedWsInstructor"
When I logged into the Pegasus as "HedWsInstructor" in "WorkSpace"
Then I should logged in successfully