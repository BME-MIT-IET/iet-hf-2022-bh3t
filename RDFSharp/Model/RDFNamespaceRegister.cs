/*
   Copyright 2012-2022 Marco De Salvo

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

     http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using static RDFSharp.Query.RDFQueryUtilities;

namespace RDFSharp.Model
{
    /// <summary>
    /// RDFNamespaceRegister is a singleton in-memory container for registered RDF namespaces.
    /// </summary>
    public sealed class RDFNamespaceRegister : IEnumerable<RDFNamespace>
    {
        #region Properties
        /// <summary>
        /// Default namespace of the library (rdfsharp)
        /// </summary>
        private static RDFNamespace RDFSharpNS = new RDFNamespace(RDFVocabulary.RdfSharp.PREFIX, RDFVocabulary.RdfSharp.BASE_URI).SetDereferenceUri(new Uri(RDFVocabulary.RdfSharp.DEREFERENCE_URI));

        /// <summary>
        /// Default namespace of the library
        /// </summary>
        public static RDFNamespace DefaultNamespace { get; internal set; }

        /// <summary>
        /// Singleton instance of the RDFNamespaceRegister class
        /// </summary>
        public static RDFNamespaceRegister Instance { get; internal set; }

        /// <summary>
        /// List of registered namespaces
        /// </summary>
        internal List<RDFNamespace> Register { get; set; }

        /// <summary>
        /// Count of the register's namespaces
        /// </summary>
        public static int NamespacesCount
            => Instance.Register.Count;

        /// <summary>
        /// Gets the enumerator on the register's namespaces for iteration
        /// </summary>
        public static IEnumerator<RDFNamespace> NamespacesEnumerator
            => Instance.Register.GetEnumerator();
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to initialize the singleton instance of the register
        /// </summary>
        static RDFNamespaceRegister()
        {
            Instance = new RDFNamespaceRegister()
            {
                Register = new List<RDFNamespace>()
                {
                    RDFSharpNS,

                    //Basic
                    new RDFNamespace(RDFVocabulary.RDF.PREFIX, RDFVocabulary.RDF.BASE_URI).SetDereferenceUri(new Uri(RDFVocabulary.RDF.DEREFERENCE_URI)),
                    new RDFNamespace(RDFVocabulary.RDFS.PREFIX, RDFVocabulary.RDFS.BASE_URI).SetDereferenceUri(new Uri(RDFVocabulary.RDFS.DEREFERENCE_URI)),
                    new RDFNamespace(RDFVocabulary.OWL.PREFIX, RDFVocabulary.OWL.BASE_URI).SetDereferenceUri(new Uri(RDFVocabulary.OWL.DEREFERENCE_URI)),
                    new RDFNamespace(RDFVocabulary.Shacl.PREFIX, RDFVocabulary.Shacl.BASE_URI).SetDereferenceUri(new Uri(RDFVocabulary.Shacl.DEREFERENCE_URI)),
                    new RDFNamespace(RDFVocabulary.Swrl.PREFIX, RDFVocabulary.Swrl.BASE_URI).SetDereferenceUri(new Uri(RDFVocabulary.Swrl.DEREFERENCE_URI)),
                    new RDFNamespace(RDFVocabulary.Swrl.SemanticWebRuleLangBuiltIns.PREFIX, RDFVocabulary.Swrl.SemanticWebRuleLangBuiltIns.BASE_URI).SetDereferenceUri(new Uri(RDFVocabulary.Swrl.SemanticWebRuleLangBuiltIns.DEREFERENCE_URI)),
                    new RDFNamespace(RDFVocabulary.XSD.PREFIX, RDFVocabulary.XSD.BASE_URI).SetDereferenceUri(new Uri(RDFVocabulary.XSD.DEREFERENCE_URI)),
                    new RDFNamespace(RDFVocabulary.XML.PREFIX, RDFVocabulary.XML.BASE_URI).SetDereferenceUri(new Uri(RDFVocabulary.XML.DEREFERENCE_URI)),

                    //Extended
                    new RDFNamespace(RDFVocabulary.DC.PREFIX, RDFVocabulary.DC.BASE_URI).SetDereferenceUri(new Uri(RDFVocabulary.DC.DEREFERENCE_URI)),
                    new RDFNamespace(RDFVocabulary.DC.Dcam.PREFIX, RDFVocabulary.DC.Dcam.BASE_URI).SetDereferenceUri(new Uri(RDFVocabulary.DC.Dcam.DEREFERENCE_URI)),
                    new RDFNamespace(RDFVocabulary.DC.Dcterms.PREFIX, RDFVocabulary.DC.Dcterms.BASE_URI).SetDereferenceUri(new Uri(RDFVocabulary.DC.Dcterms.DEREFERENCE_URI)),
                    new RDFNamespace(RDFVocabulary.DC.Dctype.PREFIX, RDFVocabulary.DC.Dctype.BASE_URI).SetDereferenceUri(new Uri(RDFVocabulary.DC.Dctype.DEREFERENCE_URI)),
                    new RDFNamespace(RDFVocabulary.Foaf.PREFIX, RDFVocabulary.Foaf.BASE_URI).SetDereferenceUri(new Uri(RDFVocabulary.Foaf.DEREFERENCE_URI)),
                    new RDFNamespace(RDFVocabulary.Geo.PREFIX, RDFVocabulary.Geo.BASE_URI).SetDereferenceUri(new Uri(RDFVocabulary.Geo.DEREFERENCE_URI)),
                    new RDFNamespace(RDFVocabulary.Sioc.PREFIX, RDFVocabulary.Sioc.BASE_URI).SetDereferenceUri(new Uri(RDFVocabulary.Sioc.DEREFERENCE_URI)),
                    new RDFNamespace(RDFVocabulary.Skos.PREFIX, RDFVocabulary.Skos.BASE_URI).SetDereferenceUri(new Uri(RDFVocabulary.Skos.DEREFERENCE_URI)),
                    new RDFNamespace(RDFVocabulary.Skos.SkosXl.PREFIX, RDFVocabulary.Skos.SkosXl.BASE_URI).SetDereferenceUri(new Uri(RDFVocabulary.Skos.SkosXl.DEREFERENCE_URI)),
                    new RDFNamespace(RDFVocabulary.Earl.PREFIX, RDFVocabulary.Earl.BASE_URI).SetDereferenceUri(new Uri(RDFVocabulary.Earl.DEREFERENCE_URI)),
                    new RDFNamespace(RDFVocabulary.Crm.PREFIX, RDFVocabulary.Crm.BASE_URI).SetDereferenceUri(new Uri(RDFVocabulary.Crm.DEREFERENCE_URI)),
                    new RDFNamespace(RDFVocabulary.DescriptionOfAProject.PREFIX, RDFVocabulary.DescriptionOfAProject.BASE_URI).SetDereferenceUri(new Uri(RDFVocabulary.DescriptionOfAProject.DEREFERENCE_URI)),
                    new RDFNamespace(RDFVocabulary.VS.PREFIX, RDFVocabulary.VS.BASE_URI).SetDereferenceUri(new Uri(RDFVocabulary.VS.DEREFERENCE_URI))
                }
            };

            DefaultNamespace = RDFSharpNS;
        }
        #endregion

        #region Interfaces
        /// <summary>
        /// Exposes a typed enumerator on the register's namespaces
        /// </summary>
        IEnumerator<RDFNamespace> IEnumerable<RDFNamespace>.GetEnumerator()
            => NamespacesEnumerator;

        /// <summary>
        /// Exposes an untyped enumerator on the register's namespaces
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
            => NamespacesEnumerator;
        #endregion

        #region Methods
        /// <summary>
        /// Sets the given namespace as default namespace of the library.
        /// </summary>
        public static void SetDefaultNamespace(RDFNamespace nSpace)
        {
            if (nSpace != null)
            {
                DefaultNamespace = nSpace;

                //Also add it to the register
                AddNamespace(nSpace);
            }
        }

        /// <summary>
        /// Resets the default namespace of the library.
        /// </summary>
        public static void ResetDefaultNamespace()
            => DefaultNamespace = RDFSharpNS;

        /// <summary>
        /// Adds the given namespace to the register, if it has unique prefix and uri.
        /// </summary>
        public static void AddNamespace(RDFNamespace nSpace)
        {
            if (nSpace != null)
            {
                if (GetByPrefix(nSpace.NamespacePrefix) == null && GetByUri(nSpace.NamespaceUri.ToString()) == null)
                    Instance.Register.Add(nSpace);
            }
        }

        /// <summary>
        /// Removes the namespace having the given Uri.
        /// </summary>
        public static void RemoveByUri(string uri)
        {
            if (uri != null)
                Instance.Register.RemoveAll(ns => ns.NamespaceUri.ToString().Equals(uri.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Removes the namespace having the given prefix.
        /// </summary>
        public static void RemoveByPrefix(string prefix)
        {
            if (prefix != null)
                Instance.Register.RemoveAll(ns => ns.NamespacePrefix.Equals(prefix.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Retrieves a namespace by seeking presence of its Uri.
        /// </summary>
        public static RDFNamespace GetByUri(string uri, bool enablePrefixCCService = false)
        {
            if (uri != null)
            {
                RDFNamespace result = Instance.Register.Find(ns => ns.NamespaceUri.ToString().Equals(uri.Trim(), StringComparison.OrdinalIgnoreCase));
                if (result == null && enablePrefixCCService)
                    result = LookupPrefixCC(uri.Trim().TrimEnd(new char[] { '#' }), 2);
                return result;
            }
            return null;
        }

        /// <summary>
        /// Retrieves a namespace by seeking presence of its prefix.
        /// </summary>
        public static RDFNamespace GetByPrefix(string prefix, bool enablePrefixCCService = false)
        {
            if (prefix != null)
            {
                RDFNamespace result = Instance.Register.Find(ns => ns.NamespacePrefix.Equals(prefix.Trim(), StringComparison.OrdinalIgnoreCase));
                if (result == null && enablePrefixCCService)
                    result = LookupPrefixCC(prefix.Trim(), 1);
                return result;
            }
            return null;
        }

        /// <summary>
        /// Looksup the given prefix or namespace into the prefix.cc service
        /// </summary>
        internal static RDFNamespace LookupPrefixCC(string data, int lookupMode)
        {
            string lookupString = lookupMode == 1 ? string.Concat("http://prefix.cc/", data, ".file.txt")
                                                  : string.Concat("http://prefix.cc/reverse?uri=", data, "&format=txt");

            using (RDFWebClient webclient = new RDFWebClient(1000))
            {
                try
                {
                    string response = webclient.DownloadString(lookupString);
                    string prefix = response.Split('\t')[0];
                    string nspace = response.Split('\t')[1].TrimEnd(new char[] { '\n' });
                    RDFNamespace result = new RDFNamespace(prefix, nspace);

                    //Also add the namespace to the register, to avoid future lookups
                    AddNamespace(result);

                    //Return the found result
                    return result;
                }
                catch { return null; }
            }
        }

        /// <summary>
        /// Removes namespaces marked as temporary
        /// </summary>
        internal static void RemoveTemporaryNamespaces()
            => Instance.Register.RemoveAll(x => x.IsTemporary);
        #endregion
    }
}