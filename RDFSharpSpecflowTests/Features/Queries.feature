Feature: Queries

Testing different queries on the RDFSharp project

@quereies
Scenario Outline: Executing a query to get the phones with the longest battery life
	Given a graph with <numOfPhones> phones and their battery capacity
	And a query that selects the top <numOfPhones> phones with the longest battery life based on battery capacity
	When executing the created query on the graph
	Then the result, query and graph objects are not null and result contains <numOfPhones> objects
	And receiving the actual top <numOfPhones> phones with the longest battery life

	Examples:
    | numOfPhones |
    |           3 |
    |           7 |
    |           9 |

Scenario Outline: Executing a query to get the average of temperature values
	Given a graph with <numOfdays> days data and <numOfTempValues> temperature value for each day
	And a query thet selects the days with their temperature values
	And a GroupBy modifier to calculate the average value for each day
	When executing the created query on the graph
	Then the result, query and graph objects are not null and result contains <numOfdays> objects
	And the average of <numOfTempValues> temperatures should be calculated correctly for <numOfdays> day

	Examples:
    | numOfdays | numOfTempValues |
    |         3 |               5 |
    |        10 |               9 |
    |        55 |             111 |

Scenario Outline: Executing a query to get the maximum temperature for a day
	Given a graph with <numOfdays> days data and <numOfTempValues> temperature value for each day
	And a query thet selects the days with their temperature values
	And a GroupBy modifier to calculate the max value for each day
	When executing the created query on the graph
	Then the result, query and graph objects are not null and result contains <numOfdays> objects
	And the max of <numOfTempValues> temperature values should be determined correctly for <numOfdays> day

	Examples:
    | numOfdays | numOfTempValues |
    |         5 |               7 |
    |        11 |              13 |
    |        88 |              99 |


