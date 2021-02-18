Feature: SampleCase1

# The doctype templates etc, are specific to our system which is used for document storage, download, preview, edition. In this case is a simple crud validation,
# checking the availability of those documents in the repository, and also testing the Api CREATE endpoint

@documents
@Regression
Scenario Outline: SampleTestCase1
	Given I got the template value <template>
	And I got the DocType <docType>
	And the DocSubtype <docSubtype>
	When I update the documentType with those metadata values
	And the document is sent to WebService through the create document service
	Then the render document service must run successfully
	And the response must contain the documentID
	And in the database the following columns are correctly set '<docType>','<docSubtype>'

	Examples:
		| docSubtype     | docType        | template          |
		| SampleDocType  | SampleSubType  | Template/Template |
		| SampleDocType2 | SampleSubType2 | Template/Template |