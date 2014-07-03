# Feature Description To Verify Defect US66317
Feature: US66348
In order to verify the defect #US66348
As Teaching Aide
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

# Creation of Test Data : Enrollment of SMS Student to section
Given SMS Student is already enrolled into the Section if not then enroll the SMS user to Section

# Creation of Test Data : Manual Graded question is already submitted or not
Given Manual Graded question is already submitted by the student if not then submit the manual graded question by the student


# To verify Defect at Access Point
Scenario: US66348_View Submission By TA 
Given I have browsed url for "SMSRegistration"
When I Create a new SMS Student
And I enroll the student to the section
When I promote the student user as TA in Section
And I have logged into the course space as HED Teaching Assistant
Then It should show the "Global Home" page
When I select the section from the Global home page
Then It should show the "Calendar" page
When I navigate to the "Course Materials" Tab
And I open the view submission of the submitted activity
And I verify the grades by TA
And  I clicked on the Logout link to get logged out from the application

