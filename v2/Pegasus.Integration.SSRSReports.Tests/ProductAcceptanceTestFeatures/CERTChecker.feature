Feature: CERTChecker
	

Scenario: CERTScanner for selected Environment
Given I start the Scanner
And Feed in the Environment
Then I should get all the results of DNS certificate in the environment
	
