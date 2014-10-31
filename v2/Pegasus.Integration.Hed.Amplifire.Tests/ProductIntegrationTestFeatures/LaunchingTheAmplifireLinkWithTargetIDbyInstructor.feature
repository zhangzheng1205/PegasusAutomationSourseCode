
Feature: Instructor side Amplifier
				As a sms instructor, 
				I should be able to launch the amplifier link successfully 
				and the control should go to the specified page number.

#Purpose: Open Instructor Url
Background: 
Given I browsed the login url for "HedProgramAdmin"
When  I logged into the Pegasus as "HedProgramAdmin" in "CourseSpace"
Then  I should logged in successfully
Given I am on the "Global Home" page

#Purpose : To launch the Amplifier link from instructor side
#Test case ID : peg-5957
#Products : HED BVT
#Pre condition : Atleat one Amplifier link should be created in the CC with the given name
#Dependency : No dependency test can run with existing data
Scenario: LaunchingTheAmplifireLinkWithTargetIDbyInstructor
	