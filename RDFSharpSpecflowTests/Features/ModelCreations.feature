Feature: Model Creation Testing

@mytag
Scenario: Test the creation of a new RDF Variable
	Given an RDFVariable with test data
	Then the RDFVariable has been successfuly created
 
Scenario: Test the creation of a new RDFPattern
	Given a subject, object, predicate resources
	When create a pattern with the variables
	Then the correct pattern should be created successfuly

Scenario: Test the creation of a triple
	Given a resource https://hu.wikipedia.org/wiki/Bill_Gates
	And a resource http://xmlns.com/foaf/spec/#term_gender
	And a string literal Male
	When create a new triple from the resources
	Then a correct triple object will be created

Scenario: Test the creation of a graph
	Given 5 triples filled with mock data
	And crate 2 empty graphs
	When creating graph 1 with tuples from 1 to 3
	And creating graph 2 with tuples from 4 to 5
	Then graph 1 contains triples from 1 to 3
	And graph 2 contains triples from 4 to 5

Scenario: Test the conversion of a graph into a DataTable
	Given 3 triples filled with mock data
	And crate 1 empty graphs
	When graph is converted to a DataTable
	Then the received DataTable object is correct



