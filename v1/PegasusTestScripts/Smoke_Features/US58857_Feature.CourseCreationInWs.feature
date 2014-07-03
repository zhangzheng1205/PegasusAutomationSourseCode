#Purpose: Feature Description
Feature: US58857 -  Course Creation
In order to Creation of Course 
As a WS Admin
I want to create course(s) as a Empty Course, Container Course and Master Library

@initial_setup
#Purpose: Open Ws Url
Background: 
Given I have browsed url for "WS Admin"
When I have logged into the work space as WSAdmin  
Then  It should show the "Course Enrollment" page

@CourseCreation
#Purpose: UseCase To Create New Course(s)
Scenario: Create the new Course using create course link
Given I am on the Course Creation page
When I create course with course details then verify the course creation successful Message
|Value|
|BDDEC|
#|BDDML|
|BDDCC|

