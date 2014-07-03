Feature: PEGASUS-8551-MMND Sidedoor: Customize Pegasus default pages (UI) for MMND backdoor login users
	In order to validate use case for Pegasus-8551
	As a Instructor/student/TA
	I want to Customize Pegasus default pages (UI) for MMND backdoor login

Scenario: Backdoor login Verify Pegasus default pages for Instructor
Given I browsed the login url for "HedBackdoorLoginInstructor"
Then I should see the Url appended correctly
But I should not see the ForgotPassword and Registration link available on the page
When I logged into the Pegasus as "HedBackdoorLoginInstructor" in "CourseSpace"
Then I should be on the "Global Home" page
And I should not see the Enroll To Course and Search Catalog button on the MyCourses and TestBank channel for "HedBackdoorLoginInstructor"
And I should not see the MyProfile and Feedback link on the global home page
When I enter in the "HedCoreAcceptanceInstructorCourse" from the Global Home page as "HedBackdoorLoginInstructor"
Then I should be on the "Today's View" page
And I should see "Sign out" link
When I "Sign out" from the "HedBackdoorLoginInstructor"
Then I should see the successfull message "You have been signed out of the application."

Scenario: Backdoor login Verify Pegasus default pages for Student
Given I browsed the login url for "HedBackdoorLoginStudent"
Then I should see the Url appended correctly
But I should not see the ForgotPassword and Registration link available on the page
When I logged into the Pegasus as "HedBackdoorLoginStudent" in "CourseSpace"
Then I should be on the "Global Home" page
And I should not see the Enroll To Course button on the MyCourses and TestBank channel for "HedBackdoorLoginStudent"
And I should not see the MyProfile and Feedback link on the global home page
When I enter in the "HedCoreAcceptanceInstructorCourse" from the Global Home page as "HedBackdoorLoginStudent"
Then I should be on the "Today's View" page
And I should see "Sign out" link
When I "Sign out" from the "HedBackdoorLoginStudent"
Then I should see the successfull message "You have been signed out of the application."