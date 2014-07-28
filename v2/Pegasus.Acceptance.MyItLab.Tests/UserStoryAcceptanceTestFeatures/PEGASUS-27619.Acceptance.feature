Feature: PEGASUS-27619:Automation: (Admin Modules) Stop and Start Copy functionality for Self Study courses
					As a CS student
					I want to view and enter into self study courses 
					even when stop copy, stop enrollment are enabled to PMC course.

#Pegasus-27619
#Purpose: To view and enter inside the self study course as SMS student when PMC is sent with stop copy and stop enrollment.
Scenario: User Login as SMS Student and Navigate to Selfstudy course when PMC is set with stop copy and enrollment.
When I enter in the "HedMilSelfStudy" course from the Global Home page as "CsSmsStudent"
Then I should be on the "Today's View" page
