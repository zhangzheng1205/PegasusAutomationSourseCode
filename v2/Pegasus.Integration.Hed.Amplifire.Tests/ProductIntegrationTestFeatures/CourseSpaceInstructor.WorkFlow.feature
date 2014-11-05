Feature: CourseSpaceInstructor
				As a SMS CS instructor, 
				I should be able to launch the amplifier link successfully.

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
Scenario: LaunchingTheAmplifireLinkByInstructor
When I enter in the "InstructorCourse" from the Global Home page as "CsSmsInstructor"
Then I should be on the "Today's View" page
When I navigate to the "Course Materials" tab
Then I should be on the "Course Materials" page
When I navigate to "Capítulo preliminar: Bienvenidos a Unidos" asset in "Course Materials" tab as "CsSmsInstructor" 
Then I should be on the "Course Materials" page
When I navigate to "¡Comprueba lo que sabes!" asset in "Course Materials" tab as "CsSmsInstructor" 
Then I should be on the "Course Materials" page
When I open the "Amplifire Study Module 0P: Vocabulario en contexto" Activity
Then I should see the activity successfully launched by Instructor
When I "Sign out" from the "CsSmsInstructor"
Then I should see the successfull message "You have been signed out of the application."