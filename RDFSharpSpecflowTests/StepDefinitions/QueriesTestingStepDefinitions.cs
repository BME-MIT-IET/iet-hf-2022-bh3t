using System;
using TechTalk.SpecFlow;
using static RDFSharp.Model.RDFVocabulary;

namespace RDFSharpSpecflowTests.StepDefinitions
{

    [Binding]
    public class QueriesTestingStepDefinitions
    {
        private RDFGraph graph;
        private RDFSelectQuery query;
        private RDFSelectQueryResult result;

        [Given(@"a graph with (.*) phones and their battery capacity")]
        public void GivenAGraphWithPhonesAndTheirBatteryCapacity(int numOfPhones)
        {
            graph = new RDFGraph();

            for (int i = 0; i < numOfPhones; i++)
            {
                RDFResource phone = new RDFResource(RDF.BASE_URI + "phone" + i);
                string value = (4000 + i * 500).ToString();
                RDFTypedLiteral batteryCapacity = new RDFTypedLiteral(value, RDFModelEnums.RDFDatatypes.XSD_INTEGER);
                RDFResource predicate = new RDFResource(RDF.BASE_URI + "batteryCapacity");

                graph.AddTriple(new RDFTriple(phone, predicate, batteryCapacity));
            }
        }

        [Given(@"a query that selects the top (.*) phones with the longest battery life based on battery capacity")]
        public void GivenAQueryThatSelectsThePhonesWithTheLongestBatteryLifeBasedOnBatteryCapacity(int tops)
        {
            query = new RDFSelectQuery();

            RDFVariable phone = new RDFVariable("phone");
            RDFVariable batteryCapacity = new RDFVariable("batteryCapacity");
            RDFResource predicate = new RDFResource(RDF.BASE_URI + "batteryCapacity");
            RDFPatternGroup patternGroup = new RDFPatternGroup("PatternGroup");

            patternGroup.AddPattern(new RDFPattern(phone, predicate, batteryCapacity));

            query.AddPatternGroup(patternGroup);
            query.AddProjectionVariable(phone);
            query.AddProjectionVariable(batteryCapacity);
            query.AddModifier(new RDFLimitModifier(tops));
            query.AddModifier(new RDFOrderByModifier(batteryCapacity, RDFQueryEnums.RDFOrderByFlavors.DESC));
        }

        [When(@"executing the created query on the graph")]
        public void WhenExecutingTheCreatedQueryOnTheGraphToGetThePhones()
        {
            result = query.ApplyToGraph(graph);
        }

        [Then(@"the result, query and graph objects are not null and result contains (.*) objects")]
        public void ThenTheResultQueryAndGraphObjectsAreNotNullAndResultContainsObjects(int numOfObjects)
        {
            Assert.IsNotNull(graph);
            Assert.IsNotNull(query);
            Assert.IsNotNull(result);
            Assert.AreEqual(numOfObjects, result.SelectResultsCount);
        }

        [Then(@"receiving the actual top (.*) phones with the longest battery life")]
        public void ThenReceivingTheActualPhonesWithTheLongestBatteryLife(int tops)
        {
            Assert.IsNotNull(graph);
            Assert.IsNotNull(query);
            Assert.IsNotNull(result);
            Assert.AreEqual(tops, result.SelectResultsCount);

            int max = 4000 + (tops - 1) * 500;

            for (int i = 0; i < tops; i++)
            {
                Assert.AreEqual(max - (i * 500), int.Parse(result.SelectResults.Rows[i].ItemArray[1].ToString().Split("^")[0]));
            }
        }

        [Given(@"a graph with (.*) days data and (.*) temperature value for each day")]
        public void GivenAGraphWithDaysDataAndTemperatureValueForEachDay(int numOfDays, int numOfTempValues)
        {
            graph = new RDFGraph();

            for (int i = 0; i < numOfDays; i++)
            {
                RDFResource day = new RDFResource(RDF.BASE_URI + "day" + i);

                for (int j = 0; j < numOfTempValues; j++)
                {
                    string temp = (20 + i * 2 + j * 2).ToString();
                    RDFTypedLiteral tempLiteral = new RDFTypedLiteral(temp, RDFModelEnums.RDFDatatypes.XSD_INTEGER);
                    graph.AddTriple(new RDFTriple(day, RDF.VALUE, tempLiteral));
                }
            }
        }

        [Given(@"a query thet selects the days with their temperature values")]
        public void GivenAQueryThetSelectsTheDaysWithTheirTemperatureValues()
        {
            query = new RDFSelectQuery();
            RDFVariable day = new RDFVariable("day");
            RDFVariable temperature = new RDFVariable("temperature");

            query.AddPatternGroup(new RDFPatternGroup("PatternGroup").AddPattern(new RDFPattern(day, RDF.VALUE, temperature)));
            query.AddProjectionVariable(day);
            query.AddProjectionVariable(temperature);

        }

        [Given(@"a GroupBy modifier to calculate the average value for each day")]
        public void GivenAGroupByModifierToCalculateTheAverageValueForEachDay()
        {
            RDFVariable day = new RDFVariable("day");
            RDFVariable temp = new RDFVariable("temperature");
            RDFGroupByModifier groupByModifier = new RDFGroupByModifier(new List<RDFVariable>() { day });

            groupByModifier.AddAggregator(new RDFAvgAggregator(temp, new RDFVariable("avarage")));
            query.AddModifier(groupByModifier);
        }

        [Then(@"the average of (.*) temperatures should be calculated correctly for (.*) day")]
        public void ThenTheAverageOfTemperaturesShouldBeCalculatedCorrectlyForEachDay(int numOfTempValues, int numOfDays)
        {
            int avg = (20 * numOfTempValues + (numOfTempValues - 1) * numOfTempValues) / numOfTempValues;

            for (int i = 0; i < numOfDays; i++)
            {
                Assert.AreEqual(avg + i * 2, int.Parse(result.SelectResults.Rows[i].ItemArray[1].ToString().Split("^")[0]));
            }
        }

        [Given(@"a GroupBy modifier to calculate the max value for each day")]
        public void GivenAGroupByModifierToCalculateTheMaxValueForEachDay()
        {
            RDFVariable day = new RDFVariable("day");
            RDFVariable temp = new RDFVariable("temperature");
            RDFGroupByModifier groupByModifier = new RDFGroupByModifier(new List<RDFVariable>() { day });

            groupByModifier.AddAggregator(new RDFMaxAggregator(temp, new RDFVariable("max"), RDFQueryEnums.RDFMinMaxAggregatorFlavors.Numeric));
            query.AddModifier(groupByModifier);
        }

        [Then(@"the max of (.*) temperature values should be determined correctly for (.*) day")]
        public void ThenTheMaxOfTemperatureValuesShouldBeDeterminedCorrectlyForDay(int numOfTempValues, int numOfDays)
        {
            int max = 20 + (numOfTempValues - 1) * 2;

            for (int i = 0; i < numOfDays; i++)
            {
                Assert.AreEqual(max + i * 2, int.Parse(result.SelectResults.Rows[i].ItemArray[1].ToString().Split("^")[0]));
            }
        }

    }
}
