Feature: PEGASUS-31801


Scenario: WSInstructor Launches the Amplifire using section course 
When I enter in the "MySpanishLabMaster" from the Global Home page as "HedWsInstructor"
Then I should be on the "Today's View" page
When I navigate to "Course Materials" tab
Then I should be on the "Course Materials" page
When I click on "Capítulo preliminar: Bienvenidos a Unidos" folder as "HedWsInstructor"
And I click on "¡Comprueba lo que sabes!" folder as "HedWsInstructor"
And I open the "Amplifire Study Module 0P: Vocabulario en contexto" Activity from MyCourse
Then I should see "You don't have subscription to the site. Please confirm that your subscription includes access to the Amplifire product." warning
