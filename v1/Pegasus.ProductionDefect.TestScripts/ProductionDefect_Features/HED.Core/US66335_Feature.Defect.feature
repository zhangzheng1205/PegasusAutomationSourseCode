# Feature Description To Verify Defect US66335
Feature: US66335
In order to verify the defect #US66335 
As a CS Instructor
I want to verify the expected result(s) at Activity Preference Tab in pegasus

Background: 
# Creation of Test Data : Course Copy
Given Authored course copy already created if not then create the authored course copy

# Creation of Test Data : Publish Course
Given Authored course copy is already published if not then publish the authored course copy

# Creation of Test Data : Approve Course
Given Autohored course is already approved in the course space if not then approve the authored course in course space

# Creation of Test Data : Creation of Program
Given HED program is already created if not then create the HED program

# Creation of Test Data : Creation of General Product
Given HED general type product is already created if not then create a new general type product

# Creation of Test Data : Creation of Program Type Product
Given Program type product is already created if not then create a new program type product

# Creation of Test Data : Association of Authored Course to general Type Product
Given Course association to general type product is already created if not then create association

# Creation of Test Data : Association of Authored Course to program Type Product
Given Course association to program type product is already created if not then create association

# Creation of Test Data : Creation of SMS Instructor
Given SMS user is already created if not then create SMS user 

# Creation of Test Data : Enrollment of SMS user in Instructor Course
Given SMS user is already enrolled into the instructor course if not then enroll the SMS user in instructor course


# To verify Defect at ActivityPreferenceTab of DefaultTime
Scenario: US66335_DefaultTime_ActivityPreferenceTab

Given I have browsed url for "CsSmsInstructor"
When I have logged into the course space as SMS Instructor
Then It should show the "Global Home" page
When I select the course from Global home page
#When I navigate to the "MyTest" Tab
#And  I create a Test under Test bank
When I navigate to the "Course Materials" Tab
And  I navigate to My Tests Folder
#And  I Edit the activity and navigate to preferences tab
#And  I changed the Value of "Time required to complete the activity" 
#And  I changed the Value of "Display this number of questions per page" 
#And  I changed the Value of "Select style sheet" in the edit activity page
#And  I changed the Value as 1 for 'Specify number of attempts'
#And  I navigate to grades tab in the edit activity page
#Then It should not show grade schema "Default" value for "Select grade schema" unless and until user selects the schema
#And  I select Default Schema for "Select grade schema"
#And  I Save the activity in grades tab and return to the Course material
And  I Preview the Activity
Then It should show Specified time value in the activity preview
Then It should display specified number of questions in the presentation
Then It should display changed style applied for the activity presentation
Then It should be allowed to attempt activity for specified number of times for student 
When I have logged into the course space as SMS Instructor
Then It should show the "Global Home" page
When I select the course from Global home page
Then It should be on "Calendar" page
#When I navigate to the "Course Materials" Tab
#And  I navigate to My Tests Folder
#And  I Edit the activity and navigate to grades tab
#Then It should display Default Schema for "Select grade schema"
#And  I navigate to preferences tab in the edit activity page
#Then It should display Specified time value in the edit activity page
#Then It should remains same as Specified question count value in the edit activity page
#Then It should display recently changed style sheet  value for the "Select style sheet" preference options
#Then It should display recent value provided for 'Specify number of attempts' in the edit activity page
#And  I Save the activity and return to the Course materials
When I navigate to the "Preferences" Tab
And  I edit the activity type and change the values of the preferences sets and clicked on 'Apply to all'
#Then It should shown up  the Changes done in the default preferences of the activity for the existing activity
Then It should shown up  the Changes done in the default preferences of the activity for the newly created activity
And  I clicked on the Logout link to get logged out from the application








 
















