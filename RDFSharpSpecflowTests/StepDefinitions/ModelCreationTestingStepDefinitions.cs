using RDFSharp.Query;
using System;
using System.Data;
using TechTalk.SpecFlow;

namespace RDFSharpSpecflowTests.StepDefinitions
{
    [Binding]
    public class ModelCreationTestingStepDefinitions
    {
        private readonly ScenarioContext? scenarioContext;

        private readonly List<RDFResource> resources = new List<RDFResource>();
        private RDFPlainLiteral? plainLiteral;
        private RDFTriple? triple;
        private RDFTriple[] triples;
        private RDFGraph[]? graphs;
        private DataTable dataTable;

        private RDFVariable? rdfVar;
        private RDFVariable testVar1, testVar2, testVar3;
        private RDFPattern pattern;

        [Given("a resource (.*)")]
        public void GivenAResource(string resource)
        {
            resources.Add(new RDFResource(resource));
        }

        [Given("a string literal (.*)")]
        public void GivenAStringLiteral(string literalName)
        {
            plainLiteral = new RDFPlainLiteral(literalName);
        }


        [When(@"create a new triple from the resources")]
        public void WhenCreateANewTripleFromTheResources()
        {
            triple = new RDFTriple(resources[0], resources[1], plainLiteral);
        }

        [Then(@"a correct triple object will be created")]
        public void ThenACorrectTripleObjectWillBeCreated()
        {
            Assert.IsNotNull(triple);
            Assert.AreEqual(triple.Subject, resources[0]);
            Assert.AreEqual(triple.Predicate, resources[1]);
            Assert.AreEqual(triple.Object, plainLiteral);
        }

        [Given(@"(.*) triples filled with mock data")]
        public void GivenThereAreTriplesFilledWithTestData(int numOfTriples)
        {
            
            triples = new RDFTriple[numOfTriples];

            for (var i = 0; i < triples.Length; i++)
            {
                int id = i + 1;
                triples[i] = new RDFTriple(
                    new RDFResource(String.Format("http://subject.com/{0}", id)),
                    new RDFResource(String.Format("http://predicate.com/{0}", id)),
                    new RDFResource(String.Format("http://object.com/{0}", id))
                );
            }
        }
        [Given(@"crate (.*) empty graphs")]
        public void GivenCrateEmptyGraphs(int numOfGraphs)
        {
            graphs = new RDFGraph[numOfGraphs];
            for (int i = 0; i < numOfGraphs; i++)
            {
                graphs[i] = new RDFGraph();
            }
        }

        [When(@"creating graph (.*) with tuples from (.*) to (.*)")]
        public void WhenCreatingGraphWithTuplesFromTo(int graphIndex, int from, int to)
        {
            for (int j = 0; j < triples.Length; j++)
            {
                if (j >= from - 1 && j <= to - 1)
                    graphs[graphIndex - 1].AddTriple(triples[j]);
            }
        }

        [Then(@"graph (.*) contains triples from (.*) to (.*)")]
        public void ThenGraphContainsTriplesFromTo(int graphIndex, int from, int to)
        {
            for (int j = 0; j < graphs[graphIndex - 1].TriplesCount; j++)
            {
                if (j >= from - 1 && to - 1 <= j)
                    graphs[graphIndex - 1].ContainsTriple(triples[j]);
            }
        }

        [When(@"graph is converted to a DataTable")]
        public void WhenGraphIsConvertedToADataTable()
        {
            dataTable = graphs[0].ToDataTable();
        }

        [Then(@"the received DataTable object is correct")]
        public void ThenTheReceivedDataTableObjectIsCorrect()
        {
            foreach (DataRow row in dataTable.Rows)
            {
                Assert.IsTrue(row[0].ToString() == "http://subject.com/0");
                Assert.IsTrue(row[1].ToString() == "http://predicate.com/0");
                Assert.IsTrue(row[2].ToString() == "http://object.com/0");
            }
        }

        [Given(@"an RDFVariable with test data")]
        public void GivenAnRDFVariableWithTestData()
        {
            rdfVar = new RDFVariable("testString");
        }

        [Then(@"the RDFVariable has been successfuly created")]
        public void ThenTheRDFVariableHasBeenSuccessfulyCreated()
        {
            Assert.IsNotNull(rdfVar);
            Assert.AreEqual("?TESTSTRING", rdfVar.VariableName);
        }

        [Given(@"a subject, object, predicate resources")]
        public void GivenASubjectObjectPredicateResources()
        {
            testVar1 = new RDFVariable("test1");
            testVar2 = new RDFVariable("test2");
            testVar3 = new RDFVariable("test3");
        }

        [When(@"create a pattern with the variables")]
        public void WhenCreateAPatternWithTheVariables()
        {
            pattern = new RDFPattern(testVar1, testVar2, testVar3);
        }

        [Then(@"the correct pattern should be created successfuly")]
        public void ThenTheCorrectPatternShouldBeCreatedSuccessfuly()
        {
            Assert.IsNotNull(pattern);
            Assert.AreEqual(testVar1, pattern.Subject);
            Assert.AreEqual(testVar2, pattern.Predicate);
            Assert.AreEqual(testVar3, pattern.Object);
        }

    }
}