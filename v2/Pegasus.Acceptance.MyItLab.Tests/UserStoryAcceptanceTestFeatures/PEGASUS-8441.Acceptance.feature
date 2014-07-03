Feature: PEGASUS-8441-  Verify Question Tab availability from Course Space Teacher
						As a CS HED Instructor
						I want to verify the question tab
						so that it is disabled state.

Background: 
#Purpose :Login in pegasus by SMS user
Given I browsed the login url for "HedMilAcceptanceInstructor"
When I logged into the Pegasus as "HedMilAcceptanceInstructor" in "CourseSpace"
Then I should logged in successfully
Given I am on the "Global Home" page

#Purpose : Check visbility of questions tab for Basic Random Badged activity
Scenario: Validate suppression of questions tab in Basic Random badged activity
When I enter in the "HedMilAcceptanceSIMProgramCourse" from the Global Home page as "HedMilAcceptanceInstructor"
Then I should be on the "Program Administration" page
When I select the "Sections" tab
Then I should see the Section created from "HedMilAcceptanceSIMProgramCourse" course Template to be successfully out of AssignedToCopy state
When I click the "Enter Section as Instructor"
And I navigate to the "Course Materials" tab
When I edit the "BasicRandom" Badged activity
Then I should see the Questions tab should be suppressed for "BasicRandom" Badged activity
When I "Sign out" from the "HedMilAcceptanceInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : Check visbility of questions tab for Assignment Badged activity
Scenario: Validate suppression of questions tab in Assignment badged activity
When I enter in the "HedMilAcceptanceSIMProgramCourse" from the Global Home page as "HedMilAcceptanceInstructor"
Then I should be on the "Program Administration" page
When I select the "Sections" tab
Then I should see the Section created from "HedMilAcceptanceSIMProgramCourse" course Template to be successfully out of AssignedToCopy state
When I click the "Enter Section as Instructor"
And I navigate to the "Course Materials" tab
When I edit the "Assignment" Badged activity
Then I should see the Questions tab should be suppressed for "Assignment" Badged activity
When I "Sign out" from the "HedMilAcceptanceInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : Check visbility of questions tab for Doc Based Badged activity
Scenario: Validate suppression of questions tab in Doc Based badged activity
When I enter in the "HedMilAcceptanceSIMProgramCourse" from the Global Home page as "HedMilAcceptanceInstructor"
Then I should be on the "Program Administration" page
When I select the "Sections" tab
Then I should see the Section created from "HedMilAcceptanceSIMProgramCourse" course Template to be successfully out of AssignedToCopy state
When I click the "Enter Section as Instructor"
And I navigate to the "Course Materials" tab
When I edit the "DocBased" Badged activity
Then I should see the Questions tab should be suppressed for "DocBased" Badged activity
When I "Sign out" from the "HedMilAcceptanceInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : Check visbility of questions tab for Skill Based Badged activity
Scenario: Validate suppression of questions tab in Skill badged activity
When I enter in the "HedMilAcceptanceSIMProgramCourse" from the Global Home page as "HedMilAcceptanceInstructor"
Then I should be on the "Program Administration" page
When I select the "Sections" tab
Then I should see the Section created from "HedMilAcceptanceSIMProgramCourse" course Template to be successfully out of AssignedToCopy state
When I click the "Enter Section as Instructor"
And I navigate to the "Course Materials" tab
When I edit the "SkillBased" Badged activity
Then I should see the Questions tab should be suppressed for "SkillBased" Badged activity
When I "Sign out" from the "HedMilAcceptanceInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : Check visbility of questions tab for Adaptive Badged activity
Scenario: Validate suppression of questions tab in Adaptive badged activity
When I enter in the "HedMilAcceptanceSIMProgramCourse" from the Global Home page as "HedMilAcceptanceInstructor"
Then I should be on the "Program Administration" page
When I select the "Sections" tab
Then I should see the Section created from "HedMilAcceptanceSIMProgramCourse" course Template to be successfully out of AssignedToCopy state
When I click the "Enter Section as Instructor"
And I navigate to the "Course Materials" tab
When I edit the "Adaptive" Badged activity
Then I should see the Questions tab should be suppressed for "Adaptive" Badged activity
When I "Sign out" from the "HedMilAcceptanceInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : Check visbility of questions tab in pretest of SIM study plan having Skill Based Activity
Scenario: Validate suppression of question tab in pretest of SIM study plan having Skill Based Activity 
When I enter in the "HedMilAcceptanceSIMProgramCourse" from the Global Home page as "HedMilAcceptanceInstructor"
Then I should be on the "Program Administration" page
When I select the "Sections" tab
Then I should see the Section created from "HedMilAcceptanceSIMProgramCourse" course Template to be successfully out of AssignedToCopy state
When I click the "Enter Section as Instructor"
And I navigate to the "Course Materials" tab
When I edit Badged SIM study plan [Pretest<Training] having "SkillBased" activity as pre test
And I edit the "PreTest"
Then I should see the Questions tab should be suppressed for "PreTest" having "SkillBased" Activity
When I "Sign out" from the "HedMilAcceptanceInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : Check visbility of questions tab in pretest of SIM study plan having Doc Based Activity
Scenario: Validate suppression of question tab in pretest of SIM study plan having Doc Based Activity 
When I enter in the "HedMilAcceptanceSIMProgramCourse" from the Global Home page as "HedMilAcceptanceInstructor"
Then I should be on the "Program Administration" page
When I select the "Sections" tab
Then I should see the Section created from "HedMilAcceptanceSIMProgramCourse" course Template to be successfully out of AssignedToCopy state
When I click the "Enter Section as Instructor"
And I navigate to the "Course Materials" tab
When I edit Badged SIM study plan [Pretest<Training] having "DocBased" activity as pre test
And I edit the "PreTest"
Then I should see the Questions tab should be suppressed for "PreTest" having "DocBased" Activity
When I "Sign out" from the "HedMilAcceptanceInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : Check visbility of questions tab in Post Test of SIM study plan [Pretest<Training<Posttest] having skill Based Activity
Scenario: Validate suppression of question tab in Post Test of SIM study plan [Pretest<Training<Posttest] having skill Based Activity
When I enter in the "HedMilAcceptanceSIMProgramCourse" from the Global Home page as "HedMilAcceptanceInstructor"
Then I should be on the "Program Administration" page
When I select the "Sections" tab
Then I should see the Section created from "HedMilAcceptanceSIMProgramCourse" course Template to be successfully out of AssignedToCopy state
When I click the "Enter Section as Instructor"
And I navigate to the "Course Materials" tab
When I edit Badged SIM study plan [Pretest<Training<Posttest] having "SkillBased" activity as Post test
And I edit the "PostTest"
Then I should see the Questions tab should be suppressed for "PostTest" having "SkillBased" Activity
When I "Sign out" from the "HedMilAcceptanceInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : Check visbility of questions tab in Post Test of SIM study plan [Pretest<Training<Posttest] having Doc Based Activity
Scenario:Validate suppression of question tab in Post Test of SIM study plan [Pretest<Training<Posttest] having Doc Based Activity
When I enter in the "HedMilAcceptanceSIMProgramCourse" from the Global Home page as "HedMilAcceptanceInstructor"
Then I should be on the "Program Administration" page
When I select the "Sections" tab
Then I should see the Section created from "HedMilAcceptanceSIMProgramCourse" course Template to be successfully out of AssignedToCopy state
When I click the "Enter Section as Instructor"
And I navigate to the "Course Materials" tab
When I edit Badged SIM study plan [Pretest<Training<Posttest] having "DocBased" activity as Post test
And I edit the "PostTest"
Then I should see the Questions tab should be suppressed for "PostTest" having "DocBased" Activity
When I "Sign out" from the "HedMilAcceptanceInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : Check visbility of questions tab in Post Test of SIM study plan [Training<Posttest] having skill Based Activity
Scenario: Validate suppression of question tab in Post Test of SIM study plan [Training<Posttest] having skill Based Activity
When I enter in the "HedMilAcceptanceSIMProgramCourse" from the Global Home page as "HedMilAcceptanceInstructor"
Then I should be on the "Program Administration" page
When I select the "Sections" tab
Then I should see the Section created from "HedMilAcceptanceSIMProgramCourse" course Template to be successfully out of AssignedToCopy state
When I click the "Enter Section as Instructor"
And I navigate to the "Course Materials" tab
When I edit Badged SIM study plan [Training<Posttest] having "SkillBased" activity as Post test
And I edit the "PostTest"
Then I should see the Questions tab should be suppressed for "PostTest" having "SkillBased" Activity
When I "Sign out" from the "HedMilAcceptanceInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : Check visbility of questions tab in Post Test of SIM study plan [Training<Posttest] having Doc Based Activity
Scenario:Validate suppression of question tab in Post Test of SIM study plan [Training<Posttest] having Doc Based Activity
When I enter in the "HedMilAcceptanceSIMProgramCourse" from the Global Home page as "HedMilAcceptanceInstructor"
Then I should be on the "Program Administration" page
When I select the "Sections" tab
Then I should see the Section created from "HedMilAcceptanceSIMProgramCourse" course Template to be successfully out of AssignedToCopy state
When I click the "Enter Section as Instructor"
And I navigate to the "Course Materials" tab
Given I am on the "Course Materials" page
When I edit Badged SIM study plan [Training<Posttest] having "DocBased" activity as Post test
And I edit the "PostTest"
Then I should see the Questions tab should be suppressed for "PostTest" having "DocBased" Activity
When I "Sign out" from the "HedMilAcceptanceInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : Check visbility of questions tab for Doc Based Badged activity in SIM-5 Course
Scenario: Validate suppression of questions tab in Doc Based badged activity in SIM-5 Course
When I enter in the "HedMilAcceptanceSIM5ProgramCourse" from the Global Home page as "HedMilAcceptanceInstructor"
Then I should be on the "Program Administration" page
When I select the "Sections" tab
Then I should see the Section created from "HedMilAcceptanceSIM5ProgramCourse" course Template to be successfully out of AssignedToCopy state
When I click the "Enter Section as Instructor"
And I navigate to the "Course Materials" tab
When I edit the "DocBased" Badged activity
Then I should see the Questions tab should be suppressed for "DocBased" Badged activity
When I "Sign out" from the "HedMilAcceptanceInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : Check visbility of questions tab for Skill Based Badged activity in SIM-5 Course
Scenario: Validate suppression of questions tab in Skill badged activity in SIM-5 Course
When I enter in the "HedMilAcceptanceSIM5ProgramCourse" from the Global Home page as "HedMilAcceptanceInstructor"
Then I should be on the "Program Administration" page
When I select the "Sections" tab
Then I should see the Section created from "HedMilAcceptanceSIM5ProgramCourse" course Template to be successfully out of AssignedToCopy state
When I click the "Enter Section as Instructor"
And I navigate to the "Course Materials" tab
When I edit the "SkillBased" Badged activity
Then I should see the Questions tab should be suppressed for "SkillBased" Badged activity
When I "Sign out" from the "HedMilAcceptanceInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : Check visbility of questions tab in pretest of SIM study plan having Skill Based Activity in SIM-5 Course
Scenario: Validate suppression of question tab in pretest of SIM study plan having Skill Based Activity in SIM-5 Course
When I enter in the "HedMilAcceptanceSIM5ProgramCourse" from the Global Home page as "HedMilAcceptanceInstructor"
Then I should be on the "Program Administration" page
When I select the "Sections" tab
Then I should see the Section created from "HedMilAcceptanceSIM5ProgramCourse" course Template to be successfully out of AssignedToCopy state
When I click the "Enter Section as Instructor"
And I navigate to the "Course Materials" tab
When I edit Badged SIM study plan [Pretest<Training] having "SkillBased" activity as pre test
And I edit the "PreTest"
Then I should see the Questions tab should be suppressed for "PreTest" having "SkillBased" Activity
When I "Sign out" from the "HedMilAcceptanceInstructor"
Then I should see the successfull message "You have been signed out of the application."

#Purpose : Check visbility of questions tab in pretest of SIM study plan having Doc Based Activity in SIM-5 Course
Scenario: Validate suppression of question tab in pretest of SIM study plan having Doc Based Activity in SIM-5 Course
When I enter in the "HedMilAcceptanceSIM5ProgramCourse" from the Global Home page as "HedMilAcceptanceInstructor"
Then I should be on the "Program Administration" page
When I select the "Sections" tab
Then I should see the Section created from "HedMilAcceptanceSIM5ProgramCourse" course Template to be successfully out of AssignedToCopy state
When I click the "Enter Section as Instructor"
And I navigate to the "Course Materials" tab
When I edit Badged SIM study plan [Pretest<Training] having "DocBased" activity as pre test
And I edit the "PreTest"
Then I should see the Questions tab should be suppressed for "PreTest" having "DocBased" Activity
When I "Sign out" from the "HedMilAcceptanceInstructor"
Then I should see the successfull message "You have been signed out of the application."