# Feature Description To Verify Defect US66317
Feature: US66317
In order to verify the defect #US66317 
As a CS Instructor
I want to verify the expected result(s) at different access point(s) in pegasus

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

# Creation of Test Data : Association of Authored Course to General Type Product
Given Course association to general type product is already created if not then create association

# Creation of Test Data : Association of Authored Course to program Type Product
Given Course association to program type product is already created if not then create association

# Creation of Test Data : Creation of SMS User(s)
Given SMS user is already created if not then create SMS user 

# Creation of Test Data : Enrollment of SMS user in Instructor Course
Given SMS user is already enrolled into the instructor course if not then enroll the SMS user in instructor course

# Creation of Test Data : Enrollment of SMS user in Program
Given SMS user is already enrolled into the program if not then enroll the SMS user in program

# Creation of Test Data : Enrollment of SMS user in Program
Given SMS user is already created the section if not then create the section 

# To verify Defect at Access Point
Scenario: US66317_AccessPoint_InstructorCourse
Given I have browsed url for "CsSmsInstructor"
When I have logged into the course space as SMS Instructor
Then It should show the "Global Home" page
When I select the course from Global home page
Then It should show the "Calendar" page
And I edit the study plan
Then It should display successful message "Study Plan updated successfully" with no exception
And I clicked on the Logout link to get logged out from the application

# To verify Defect at Access Point
Scenario: US66317_AccessPoint_EntertheTemplateasInstructor
Given I have browsed url for "CsSmsInstructor"
When I have logged into the course space as SMS Instructor
Then It should show the "Global Home" page
When I select the Program course from Global home page
Then It should show the "Program Administration" page
And I enter the template as teacher
Then It should show the "Calendar" page
And I edit the study plan
Then It should display successful message "Study Plan updated successfully" with no exception
And I clicked on the Logout link to get logged out from the application

# To verify Defect at Access Point
Scenario: US66317_AccessPoint_EntertheSectionasInstructor
Given I have browsed url for "CsSmsInstructor"
When I have logged into the course space as SMS Instructor
Then It should show the "Global Home" page
When I select the Program course from Global home page
Then It should show the "Program Administration" page
And I verify the Template under the Template tab
And I navigate to the "Sections" Tab
And I enter the section as teacher
Then It should show the "Calendar" page
And I edit the study plan
Then It should display successful message "Study Plan updated successfully" with no exception
And I clicked on the Logout link to get logged out from the application