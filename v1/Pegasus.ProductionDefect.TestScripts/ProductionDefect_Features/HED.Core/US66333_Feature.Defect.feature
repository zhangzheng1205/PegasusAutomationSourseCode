# Feature Description To Verify Defect US66317
Feature: US66333
In order to verify the defect #US66333
As a CS TA
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

# Creation of Test Data : Association of Authored Course to General Type Product
Given Course association to general type product is already created if not then create association

# Creation of Test Data : Creation of SMS User(s)
Given SMS user is already created if not then create SMS user

# Creation of Test Data : Enrollment of SMS user in Instructor Course
Given SMS user is already enrolled into the instructor course if not then enroll the SMS user in instructor course

# Creation of Test Data : Enrollment of SMS user in Program Course
Given SMS user is already enrolled into the program course if not then enroll the SMS user in program course


# To Verify Defect TA enrollment Glitch with Pegasus 5x
Scenario: US66333_AccessPoint_InstructorCourse
Given I have browsed url for "CsSmsInstructor"
When I have logged into the course space as SMS Instructor
#And I created Instructor course from the authored course
#And I get the course ID of instructor course
#And I enroll the student to the course
When I grant the student as TA
When I have logged into the course space as SMS Instructor
And I created Instructor course from the authored course
And I get the course ID of instructor course
And I enroll the student to the course
When I grant the student as TA
When I have logged into the course space as SMS Student
Then It should display the courses
And I clicked on the Logout link to get logged out from the application

# To Verify Defect TA enrollment Glitch with Pegasus 5x
Scenario: US66333_AccessPoint_ProgramCourse
Given I have browsed url for "CsSmsInstructor"
When I have logged into the course space as SMS Instructor
#And I created Instructor course from the authored course
#And I get the course ID of instructor course
#And I enroll the student to the course
When I grant the student as TA
When I have logged into the course space as SMS Instructor
And I created Instructor course from the authored course
And I get the course ID of instructor course
And I enroll the student to the course
When I grant the student as TA
When I have logged into the course space as SMS Student
Then It should display the courses
And I clicked on the Logout link to get logged out from the application