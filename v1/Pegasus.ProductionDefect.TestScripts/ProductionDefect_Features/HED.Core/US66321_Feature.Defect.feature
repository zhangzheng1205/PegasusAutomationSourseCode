# Feature Description To Verify Defect US66321
Feature: US66321
In order to verify the defect #US66321
As a CS Instructor
I want to verify the expected result(s) at Study plan Results Report in pegasus

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

# Creation of Test Data : Creation of Program Type Product
Given Program type product is already created if not then create a new program type product

# Creation of Test Data : Association of Authored Course to general Type Product
Given Course association to general type product is already created if not then create association

# Creation of Test Data : Association of Authored Course to program Type Product
Given Course association to program type product is already created if not then create association

# Creation of Test Data : Creation of SMS Instructor
Given SMS user is already created if not then create SMS user 

# Creation of Test Data : Enrollment of SMS user in Instructor Course
Given SMS user is already enrolled into the instructor course if not then enroll the SMS user in instructor course

# Creation of Test Data : Submission of Study plans
Given Student has already submitted the StudyPlans if not then Submit the StudyPlans

# 3 studyplans and 7 remediations shd be created at ws before publishing
# in sp (pretest, post test and remdiation contains one True/flase question) and pass creteria is set as 50 %
# 1. sp contains 1 remediation  --on taking presentation , pretest should be failed and study material should pass with 100 score
# 2. sp contains 3 remediations --on taking presentation , pretest should be failed and  1st study material should fail with score 0,2nd & 3rd study materials should pass with 100 score
# 3. sp contains 3 remediations --on taking presentation , pretest should be failed and  1st study material should fail with score 0,2nd & 3rd study materials should pass with 100 score

# calculation part of study paln results report

# 1. Generating report with by selecting one study plan containing one remediation
# rem1=1/1   user avg =(1/1) * 100 =100%,  total remediations = 1  so class avg 100/1 =100

# 2. Generating report with by selecting two study plans each containing 3 remediations
# for study plan 2-- rem1=0/1 rem2 =1/1 , rem3 =1/1  so total = 2/3, user avg =(2/3) * 100 =66.7, 
# for study plan 3-- rem1=0/1 rem2 =1/1 , rem3 =1/1  so total = 2/3, user avg =(2/3) * 100 =66.7, 

# from two study palns the total remediations = 6 
# for study plan 2-- classAvg = 66.7/6 =11.1
# for study plan 3-- classAvg = 66.7/6 =11.1



# To verify Defect at StudyPlan Results Report of class avg and user avg
Scenario: US66321_StudyPlanResultsReport

Given I have browsed url for "CsSmsInstructor"
When I have logged into the course space as SMS Instructor
Then It should show the "Global Home" page
When I select the course from Global home page
And I navigate to the "Gradebook" Tab
And I navigate to the "Reports" Tab
And I Select Study Plan Results Option
And I generate report by selecting single study plan which having single remediation
Then Study material Average Should be Calculated based on the Raw Score
Then Study Material Average of User level and the class level should display the same values 
And I generate report by selecting two study plan
Then Study Material Average at both Class level and User level should display the different values
And I clicked on the Logout link to get logged out from the application
