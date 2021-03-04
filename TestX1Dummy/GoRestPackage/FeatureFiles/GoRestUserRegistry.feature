Feature: GoRestUserRegistry

@GET
Scenario: Get all users from api endpoint
	Given I get the api endpoint GetUsers
	When I create my find all user request
	And I select a single user from the returned list
	And I send the single user request
	Then I receive the correct status

@POST
Scenario Outline: Post users from datafile
	Given I get the api endpoint CreateUsers
	And I get my Data file '<FileName>'
	#When I check if my emails are unique // TODO
	When I prepare the post user request
	And I send my post users request
	Then I validate the created users
	And I delete my created users

	Examples:
		| FileName    |
		| Massa1.json |
		| Massa2.yaml |