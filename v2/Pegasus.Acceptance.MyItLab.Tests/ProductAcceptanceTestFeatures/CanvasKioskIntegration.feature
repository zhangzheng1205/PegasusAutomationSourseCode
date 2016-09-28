Feature: CanvasKioskIntegration
	                As a Canvas User 
					I want to manage all the usecase in Canvas LMS Integration with Pegasus
					so that I would validate all the Canvas integration scenarios are working fine.

#Purpose: Canvas Instructor crossover to pegasus via kiosk integrated course
Scenario: Canvas Instructor crossover to Pegasus via kiosk integrated course
Given I browsed the login url for "CanvasKioskTeacher"
When I login to Canvas as "CanvasKioskTeacher"
And I enter into "CanvasKioskCourse" course
When I click "MyLab and Mastering" link in "CanvasKioskCourse" page as "CanvasKioskTeacher"
Then I should see "MyLab and Mastering" page of "CanvasKioskTeacher" embedded at "MyLab and Mastering" page
When I click "MyITLab Course Home" link in "CanvasKioskCourse" page as "CanvasKioskTeacher"
Then I should be on the "Notifications" page of MMND portal

#Purpose: Canvas Student crossover to pegasus via kiosk integrated course
Scenario: Canvas Student crossover to Pegasus via kiosk integrated course
Given I browsed the login url for "CanvasKioskStudent"
When I login to Canvas as "CanvasKioskStudent"
And I enter into "CanvasKioskCourse" course
When I click "MyLab and Mastering" link in "CanvasKioskCourse" page as "CanvasKioskStudent"
Then I should see "MyLab and Mastering" page of "CanvasKioskStudent" embedded at "MyLab and Mastering" page
When I click "MyITLab Course Home" link in "CanvasKioskCourse" page as "CanvasKioskStudent"
Then I should be on the "Notifications" page of MMND portal

#Purpose: Canvas Student navigates to Course Materials
Scenario: Canvas Student navigates to Course Materials
Given user accesses the Pegaus link "Course Materials"
Then I should be on the "Course Materials" page of MMND portal

#Purpose: Canvas Student launch from Course Materials page
Scenario: Canvas Student launch from Course Materials page
When I click on "Open" of  "1 Grade Synch Activity" Activity in "Course Materials" page
Then I am on "CanvasGradeSynchActivity" window
When I select "correct" answer for True/False question
Then I should successfully submit activity for grading

#Purpose: Canvas Student opens Folder
Scenario: Canvas Student Opens folder in Course Materials page
When I click on "Open" of  "CanvasGradeSyncFolder" Folder in "Course Materials" page

#Purpose: Logout of Canvas LMS
Scenario: Logout of Canvas LMS
When I logout of Canvas
Then I should be on the "Log In to Canvas" page

#Purpose: Verify GradeSynch for Canvas Kiosk
Scenario:Verifi Gradesynch for Canvas Kiosk
Given I am on the "MyLab and Mastering" page
Then I perform "Grade Sync" for "CanvasKioskGradeSynchActivity" 

