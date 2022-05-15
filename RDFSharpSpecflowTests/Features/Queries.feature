Feature: Queries

Testing different queries on the RDFSharp project

@quereies
Scenario: Executing a query to get the phones with the longest battery life
	Given a graph with phones and their battery capacity
	And a query that selects the top 3 phones with the longest battery life based on battery capacity
	When executing the created query on the graph
	Then the result, query and graph objects are not null and result contains 3 objects
	And receiving the actual top 3 phones with the longest battery life

Scenario: Executing a query to get the average of temperature values
	Given a graph with 3 days data and 5 temperature value for each day
	And a query thet selects the days with their temperature values
	And a GroupBy modifier to calculate the average value for each day
	When executing the created query on the graph
	Then the result, query and graph objects are not null and result contains 3 objects
	And the average of temperatures should be calculated correctly for 3 day
