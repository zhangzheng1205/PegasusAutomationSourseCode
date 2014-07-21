Feature: CourseSpaceAuthor
	                As a Courspace Author
					I want to manage all the CourseSpace author related usecases 
					so that I would validate all the CourseSpace author scenarios are working fine.

#Verify the usecase in InstructorCourse
#Purpose: Creation of Basic Random Activity By Cs Instructor
# TestCase Id: HSS_Core_PWF_206 | Story Id: PEGASUS-3338
Scenario: Creation PracticeTest of Basic Random Activity By Cs Instructor
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Practice Test" activity type
Then I should be on the "Create activity" page
When I create "PracticeTest" activity of behavioral mode "BasicRandom" type
Then I should see the successfull message "Activity added successfully."

#Verify the usecase in InstructorCourse
#Purpose : Preview The Activity By Cs Instructor
Scenario: Preview The Activity By Cs Instructor
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
And I should see "Test" activity in the Content Library Frame
When I click on "Preview" cmenu option of activity in "CsSmsInstructor"
Then I should be on the "Test" page
When I close the "Test" window

#Verify the usecase in InstructorCourse
#Purpose : Creation of Assignment Activity By Cs Instructor
# TestCase Id: HSS_Core_PWF_206 | Story Id: PEGASUS-3338
Scenario: Creation of Assignement Activity By Cs Instructor
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Test" activity type
Then I should be on the "Create activity" page
When I create "Test" activity of behavioral mode "Assignment" type
Then I should see the successfull message "Activity added successfully."
And I should see "Test" activity of behaviorla mode "Assignment" in the Content Library Frame
When I click on "Preview" cmenu option of activity in "CsSmsInstructor"
Then I should be on the "Test" page
When I close the "Test" window

#Verify the usecase in InstructorCourse
#Purpose : To Create Test With Basic Random Activity
Scenario: To Create Test with Basic Random Activity By WS Instructor
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Test" activity type
Then I should be on the "Create activity" page
When I create "Test" type activity of behavioral mode 'BasicRandom'
Then I should see the successfull message "Activity added successfully."
When I associate the "Test" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"

#Verify the usecase in InstructorCourse
#Purpose: To Create Homework With Basic Random Activity By Ws Instructor 
Scenario: To Create Homework with Basic Random Activity By WS Instructor
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Homework" activity type
Then I should be on the "Create activity" page
When I create "HomeWork" type activity of behavioral mode 'BasicRandom'
Then I should see the successfull message "Activity added successfully."
When I associate the "HomeWork" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"

#Verify the usecase in InstructorCourse
#Purpose: To Create Quiz Activity With Essay Question By Ws Instructor 
Scenario: To Create Quiz with Manual Gradable Activity By WS Instructor
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Quiz" activity type
Then I should be on the "Create activity" page
When I create "Quiz" activity of behavioral mode type using Essay question
Then I should see the successfull message "Activity added successfully."
When I associate the "Quiz" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"

#Verify the usecase in InstructorCourse
#Purpose: Create The Page By Ws Instructor 
Scenario: To Create The Page By Ws Instructor
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Add Page" activity type
Then I should be on the "Create page" page
When I create the "Page" activity in Content Library
Then I should see the successfull message "Page saved successfully."
When I associate the "Page" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"

#Verify the usecase in InstructorCourse
#Purpose: Create The File By Ws Instructor 
Scenario: To Create The File By Ws Instructor
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Add File" activity type
Then I should be on the "Add File" page 
When I create the "File" activity in Content Library
Then I should see the successfull message "File saved successfully."
When I associate the "File" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"

#Verify the usecase in InstructorCourse
#Purpose: Create The Link By Ws Instructor 
Scenario: To Create The Link By Ws Instructor
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Add Link" activity type
Then I should be on the "Add link" page
When I create the "Link" activity in Content Library
Then I should see the successfull message "Link saved successfully."
When I associate the "Link" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"

#Verify the usecase in InstructorCourse
#Purpose: Create The Discussion Topic By Ws Instructor
Scenario: To Create The Discussion Topic By Ws Instructor
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Add Discussion Topic" activity type
Then I should be on the "Add Discussion Topic" page
When I create the "DiscussionTopic" activity in Content Library
Then I should see the successfull message "Discussion topic saved successfully."
When I associate the "DiscussionTopic" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"

#Verify the usecase in InstructorCourse
#Purpose: Create SkillStudyPlan in Content Library
Scenario: Create SkillStudyPlan in Content Library By Ws Instructor
When I navigate to "Course Materials" tab of the "Course Materials" page
Then I should be on the "Course Materials" page
When I click on the 'Add Course Materials' option
And I click on the "Add Skill Study Plan" activity type
Then I should be on the "Create Skill Study Plan" page
When I create "SkillStudyPlan" activity in "HedWsInstructor"
Then I should see the successfull message "Study Plan added successfully."
When I associate the "SkillStudyPlan" activity Content Library to MyCourse frame
Then I should see the successfull message "Content item is added to My Course"


