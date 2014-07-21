Feature: CourseSpaceTeacherReports
                    As a CS Teacher 
					I want to manage all the coursespace teacher reports  related usecases 
					so that I would validate all the coursespace teacher report scenarios are working fine.


#NovaNETMasterLibrary Scenario
#Purpose: To View Reports by CS teacher 
Scenario: View Reports by the Teacher in Cs
When I navigate to the "Gradebook" tab
Then I Should be on the "Gradebook" page 
When I select the "Reports" sub tab
And I generate the "StudentActivityReport" of student "NovaNETCsStudent" 
And It Should display the grades under launched report
Then It Should display the 'Score' under launched report
When I click on the Close button 
Then I Should be on the "Reports" page

#NovaNETMasterLibrary Scenario
#Purpose: To View Class Mastery Reports by CS Teacher 
Scenario: View Class Matery Report by NovaNETCsTeacher
When I navigate to the "Gradebook" tab
Then I should be on the "Gradebook" page
When I select the "Reports" sub tab
And I generate the "ClassMasteryReport" for "NovaNET US History A" skill
Then I should see the "ClassMasteryReport" for "NovaNET US History A" skill
When I click the Close button 
Then I should be on the "Reports" page

#NovaNETMasterLibrary Scenario
#Purpose: To View Student Mastery Reports by CS Teacher 
Scenario: View Student Matery Report by NovaNETCsTeacher
When I navigate to the "Gradebook" tab
Then I should be on the "Gradebook" page
When I select the "Reports" sub tab
And I generate the "IndividualStudentMasteryReport" for "NovaNET US History A" skill
Then I should see the "IndividualStudentMasteryReport" for "NovaNET US History A" skill
When I click the Close button 
Then I should be on the "Reports" page
