
Feature: CourseSpaceInstructor
				As a SMS CS instructor, 
				I should be able to launch the amplifier link successfully 
				and the control should go to the specified page number.

#Purpose: Open Instructor Url
Background: 
Given I browsed the login url for "CsSmsInstructor"
When  I login to Pegasus as "CsSmsInstructor" in "CourseSpace"
Then  I should be logged in successfully
Given I am on the "Global Home" page

#Purpose : To launch the Amplifier link from instructor side
#Test case ID : peg-5957
#Products : HED BVT
#Pre condition : Atleat one Amplifier link should be created in the CC with the given name
#Dependency : No dependency test can run with existing data
Scenario: LaunchingTheAmplifireLinkWithTargetIDbyInstructor
When I enter in the "MySpanishLabMaster" from the Global Home page as "CsSmsInstructor"
And  I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page

When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."