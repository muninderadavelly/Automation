Feature: EndToEndMonitoring

Background:
 Given I enter url in 'Chrome' browser

@Monitoring
Scenario: Monitoring test to ensure application is working 
	When I am on google search page
	And I click on sign-in
	Then I verify i am on sign in page