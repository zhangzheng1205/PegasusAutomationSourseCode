Feature: CourseSpaceTeacherReports
                    As a CS Teacher 
					I want to manage all the coursespace teacher reports  related usecases 
					so that I would validate all the coursespace teacher report scenarios are working fine.

#Purpose : Open the CS url 
Background: 
Given I browsed the login url for "NovaNETCsTeacher"
When I login to Pegasus as "NovaNETCsTeacher" in "CourseSpace"
Then I should be logged in successfully

#Purpose: To View Reports by CS teacher 
Scenario: View Reports by the Teacher in Cs
Given I am on the "Global Home" page
When I enter in the "NovaNETMasterLibrary" course as "NovaNETCsTeacher" from the Global Home page
And I navigate to the "Gradebook" tab
Then I Should be on the "Gradebook" page 
When I select the "Reports" sub tab
And I generate the "StudentActivityReport" of student "NovaNETCsStudent" 
And It Should display the grades under launched report
Then It Should display the 'Score' under launched report
When I click on the Close button 
Then I Should be on the "Reports" page
When I "Sign Out" from the "NovaNETCsTeacher"
Then I should see the "Signed Out" message

#Purpose: To View Class Mastery Reports by CS Teacher 
Scenario: View Class Matery Report by NovaNETCsTeacher
Given I am on the "Global Home" page
When I enter in the "NovaNETMasterLibrary" course as "NovaNETCsTeacher" from the Global Home page
And I navigate to the "Gradebook" tab
Then I should be on the "Gradebook" page
When I select the "Reports" sub tab
And I generate the "ClassMasteryReport" for "NovaNET US History A" skill
Then I should see the "ClassMasteryReport" for "NovaNET US History A" skill
When I click the Close button 
Then I should be on the "Reports" page
When I "Sign Out" from the "NovaNETCsTeacher"
Then I should see the "Signed Out" message

#Purpose: To View Student Mastery Reports by CS Teacher 
Scenario: View Student Matery Report by NovaNETCsTeacher
Given I am on the "Global Home" page
When I enter in the "NovaNETMasterLibrary" course as "NovaNETCsTeacher" from the Global Home page
And I navigate to the "Gradebook" tab
Then I should be on the "Gradebook" page
When I select the "Reports" sub tab
And I generate the "IndividualStudentMasteryReport" for "NovaNET US History A" skill
Then I should see the "IndividualStudentMasteryReport" for "NovaNET US History A" skill
When I click the Close button 
Then I should be on the "Reports" page
When I "Sign Out" from the "NovaNETCsTeacher"
Then I should see the "Signed Out" message