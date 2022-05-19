using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RDFSharp.Model;
using RDFSharp.Query;
using WireMock.Server;

namespace RDFSharp.Test.Query
{
    [TestClass]
    public class RDFConstructQueryTest
    {
        private WireMockServer server;

        [TestInitialize]
        public void Initialize() { server = WireMockServer.Start(); }

        [TestCleanup]
        public void Cleanup()  { server.Stop(); server.Dispose(); }

        [TestMethod]
        public void ShouldCreateConstructQuery()
        {
            RDFConstructQuery query = new RDFConstructQuery();
            
            Assert.IsNotNull(query);
            Assert.IsNotNull(query.QueryMembers);
            Assert.IsTrue(query.QueryMembers.Count == 0);
            Assert.IsNotNull(query.Prefixes);
            Assert.IsTrue(query.Prefixes.Count == 0);
            Assert.IsTrue(query.IsEvaluable);
            Assert.IsFalse(query.IsOptional);
            Assert.IsFalse(query.JoinAsUnion);
            Assert.IsFalse(query.IsSubQuery);
            Assert.IsTrue(query.QueryMemberID.Equals(RDFModelUtilities.CreateHash(query.QueryMemberStringID)));
            Assert.IsTrue(query.GetEvaluableQueryMembers().Count() == 0);
            Assert.IsTrue(query.GetPatternGroups().Count() == 0);
            Assert.IsTrue(query.GetSubQueries().Count() == 0);
            Assert.IsTrue(query.GetValues().Count() == 0);
            Assert.IsTrue(query.GetModifiers().Count() == 0);
            Assert.IsTrue(query.GetPrefixes().Count() == 0);
        }

        [TestMethod]
        public void ShouldCreateConstructQueryWithQueryMembers()
        {
            // Create variables
            RDFVariable x = new RDFVariable("x");
            RDFVariable y = new RDFVariable("y");
            RDFVariable n = new RDFVariable("n");
            RDFVariable h = new RDFVariable("h");
            // CREATE PATTERNS
            var dogOf = new RDFResource(RDFVocabulary.DC.BASE_URI + "dogOf");
            var age = new RDFResource(RDFVocabulary.FOAF.BASE_URI + "age");
            // Compose query
            RDFConstructQuery query = new RDFConstructQuery()
                .AddPrefix(RDFNamespaceRegister.GetByPrefix("rdf"))
                .AddPrefix(RDFNamespaceRegister.GetByPrefix("dc"))
                .AddPrefix(RDFNamespaceRegister.GetByPrefix("foaf"))
                .AddPatternGroup(new RDFPatternGroup("PG1")
                    .AddPattern(new RDFPattern(y, dogOf, x))
                    .AddPattern(new RDFPattern(x, age, n).Optional())
                    .AddFilter(new RDFComparisonFilter(
                        RDFQueryEnums.RDFComparisonFlavors.GreaterOrEqualThan, n, new RDFPlainLiteral("45.0"))))
                .AddTemplate(new RDFPattern(y, RDFVocabulary.RDF.TYPE, RDFVocabulary.FOAF.PERSON))
                .AddModifier(new RDFLimitModifier(10));

            Assert.IsTrue(query.ToString().Trim().Equals(
@"PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>"+Environment.NewLine+
"PREFIX dc: <http://purl.org/dc/elements/1.1/>"+Environment.NewLine+
"PREFIX foaf: <http://xmlns.com/foaf/0.1/>"+Environment.NewLine+
Environment.NewLine+
"CONSTRUCT"+Environment.NewLine+
"{"+Environment.NewLine+
"  ?Y rdf:type foaf:Person ."+Environment.NewLine+
"}"+Environment.NewLine+
"WHERE {"+Environment.NewLine+
"  {"+Environment.NewLine+
"    ?Y dc:dogOf ?X ."+Environment.NewLine+
"    OPTIONAL { ?X foaf:age ?N } ."+Environment.NewLine+
"    FILTER ( ?N >= \"45.0\" ) "+Environment.NewLine+
"  }"+Environment.NewLine+
"}"+Environment.NewLine+
"LIMIT 10"
            ));
        }

    }
}
