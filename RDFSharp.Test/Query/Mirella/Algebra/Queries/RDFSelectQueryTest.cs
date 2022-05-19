﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RDFSharp.Model;
using RDFSharp.Query;
using WireMock.Server;

namespace RDFSharp.Test.Query.Mirella.Algebra.Queries
{
    [TestClass]
    public class RDFSelectQueryTest
    {
        private WireMockServer server;

        [TestInitialize]
        public void Initialize() { server = WireMockServer.Start(); }

        [TestCleanup]
        public void Cleanup() { server.Stop(); server.Dispose(); }

        [TestMethod]
        public void ShouldCreateSelectQuery()
        {
            RDFSelectQuery query = new RDFSelectQuery();

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
        public void ShouldCreateSelectQueryWithQueryMembers()
        {
            // Create variables
            RDFVariable x = new RDFVariable("x");
            RDFVariable y = new RDFVariable("y");
            // CREATE PATTERNS
            var dogOf = new RDFResource(RDFVocabulary.DC.BASE_URI + "dogOf");
            // Compose query
            RDFSelectQuery query = new RDFSelectQuery()
                .AddPrefix(RDFNamespaceRegister.GetByPrefix("dc"))
                .AddPatternGroup(new RDFPatternGroup("PG1")
                    .AddPattern(new RDFPattern(y, dogOf, x)))
                .AddModifier(new RDFOrderByModifier(y,
                    RDFQueryEnums.RDFOrderByFlavors.DESC))
                .AddModifier(new RDFLimitModifier(5))
                .AddProjectionVariable(y)
                .AddProjectionVariable(x);

            string mystring = query.ToString();

            Assert.IsTrue(query.ToString().Equals(
@"PREFIX dc: <http://purl.org/dc/elements/1.1/>" + Environment.NewLine +
Environment.NewLine +
"SELECT ?Y ?X" + Environment.NewLine +
"WHERE {" + Environment.NewLine +
"  {" + Environment.NewLine +
"    ?Y dc:dogOf ?X ." + Environment.NewLine +
"  }" + Environment.NewLine +
"}" + Environment.NewLine +
"ORDER BY DESC(?Y)" + Environment.NewLine +
"LIMIT 5"
            ));
        }
    }
}
