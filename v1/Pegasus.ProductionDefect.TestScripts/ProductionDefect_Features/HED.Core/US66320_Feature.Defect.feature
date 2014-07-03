# Feature Description To Verify Defect US66320
Feature: US66320
In order to verify the defect #US66320 
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

# Creation of Test Data : Association of Authored Course to general Type Product
Given Course association to general type product is already created if not then create association

# Creation of Test Data : Association of Authored Course to program Type Product
Given Course association to program type product is already created if not then create association

# Creation of Test Data : Creation of SMS Instructor
Given SMS user is already created if not then create SMS user 

# Creation of Test Data : Enrollment of SMS user in Instructor Course
Given SMS user is already enrolled into the instructor course if not then enroll the SMS user in instructor course

# Creation of Test Data : Activity Submission by the Student

Given Activity is already submitted by the student if not then submit the activity by the student

# To verify Defect at Access Point
Scenario: US66320_Mouse hover in HTML Editor for Essay Question
Given I have browsed url for "CsSmsInstructor"
When I have logged into the course space as SMS Instructor
Then It should show the "Global Home" page
When I select the course from Global home page
When I navigate to the "Gradebook" Tab
And  I  click on the c-menu icon of activity column which has essay submitted and select view all submission
When I entered the text in HTML editor where student submitted answers displays of first essay question
Then It should display blue colour Instructor comments and upon placing cursor the colour of student answer should not change for first essay question
#When I entered the text in HTML editor where student submitted answers displays of second essay question
#Then It should display blue colour Instructor comments and upon placing cursor the colour of student answer should not change for second essay question
And  I clicked on the Logout link to get logged out from the application

