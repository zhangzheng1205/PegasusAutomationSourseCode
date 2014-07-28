Feature: PEGASUS-27615
         Restricting the Program admin to create number of sections in Section tab.Currently limit is set as 20 in the configuration file. 


#Purpose:To navigate to section tab
Background: 
When I select the "Sections" tab
Then I navigate to the "Sections" tab
When I click on Add Sections link from the Program Administration page

#Purpose:To Check the functionality of Add new section when section Count is greater than 20
Scenario:To Check the functionality of Add new section when section Count is greater than 20
When I create Section from "MyITLabForOffice2013Master" Template with section count as "21"
Then I should see the message "Number of sections should be between 1 to 20" in "Pegasus" window


#Purpose: To Check the functionality of Add new section when section Count is Zero
Scenario:To Check the functionality of Add new section when section Count is Zero
When I create Section from "MyITLabForOffice2013Master" Template with section count as "0"
Then I should see the message "Number of Sections cannot be zero or blank" in "Pegasus" window
