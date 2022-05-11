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

using RDFSharp.Model;
using RDFSharp.Semantics.OWL;
using System.Collections.Generic;

namespace RDFSharp.Semantics.SKOS
{

    /// <summary>
    /// RDFSKOSOntology represents an OWL-DL ontology implementation of W3C SKOS vocabulary
    /// </summary>
    public static class RDFSKOSOntology
    {

        #region Properties
        /// <summary>
        /// Singleton instance of the SKOS ontology
        /// </summary>
        public static RDFOntology Instance { get; internal set; }
        #endregion

        #region Ctors
        /// <summary>
        /// Default-ctor to initialize the SKOS ontology
        /// </summary>
        static RDFSKOSOntology()
        {

            #region Declarations

            #region Ontology
            Instance = new RDFOntology(new RDFResource(RDFVocabulary.Skos.BASE_URI));
            #endregion

            #region Classes
            Instance.Model.ClassModel.AddClass(RDFVocabulary.Skos.COLLECTION.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.Skos.CONCEPT.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.Skos.CONCEPT_SCHEME.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(RDFVocabulary.Skos.ORDERED_COLLECTION.ToRDFOntologyClass());
            Instance.Model.ClassModel.AddClass(new RDFOntologyUnionClass(new RDFResource("bnode:ConceptCollection")));

            //SKOS.SKOSXL
            Instance.Model.ClassModel.AddClass(RDFVocabulary.Skos.SkosXl.LABEL.ToRDFOntologyClass());
            #endregion

            #region Properties
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.Skos.ALT_LABEL.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.Skos.BROAD_MATCH.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.Skos.BROADER.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.Skos.BROADER_TRANSITIVE.ToRDFOntologyObjectProperty().SetTransitive(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.Skos.CHANGE_NOTE.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.Skos.CLOSE_MATCH.ToRDFOntologyObjectProperty().SetSymmetric(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.Skos.DEFINITION.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.Skos.EDITORIAL_NOTE.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.Skos.EXACT_MATCH.ToRDFOntologyObjectProperty().SetSymmetric(true).SetTransitive(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.Skos.EXAMPLE.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.Skos.HAS_TOP_CONCEPT.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.Skos.HIDDEN_LABEL.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.Skos.HISTORY_NOTE.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.Skos.NARROW_MATCH.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.Skos.NARROWER.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.Skos.NARROWER_TRANSITIVE.ToRDFOntologyObjectProperty().SetTransitive(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.Skos.IN_SCHEME.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.Skos.MAPPING_RELATION.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.Skos.MEMBER.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.Skos.MEMBER_LIST.ToRDFOntologyObjectProperty().SetFunctional(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.Skos.NOTATION.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.Skos.NOTE.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.Skos.PREF_LABEL.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.Skos.RELATED_MATCH.ToRDFOntologyObjectProperty().SetSymmetric(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.Skos.RELATED.ToRDFOntologyObjectProperty().SetSymmetric(true));
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.Skos.SCOPE_NOTE.ToRDFOntologyAnnotationProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.Skos.SEMANTIC_RELATION.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.Skos.TOP_CONCEPT_OF.ToRDFOntologyObjectProperty());

            //SKOS.SKOSXL
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.Skos.SkosXl.LITERAL_FORM.ToRDFOntologyDatatypeProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.Skos.SkosXl.PREF_LABEL.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.Skos.SkosXl.ALT_LABEL.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.Skos.SkosXl.HIDDEN_LABEL.ToRDFOntologyObjectProperty());
            Instance.Model.PropertyModel.AddProperty(RDFVocabulary.Skos.SkosXl.LABEL_RELATION.ToRDFOntologyObjectProperty().SetSymmetric(true));
            #endregion

            #endregion

            #region Taxonomies

            #region ClassModel

            //Restrictions
            Instance.Model.ClassModel.AddClass(new RDFOntologyCardinalityRestriction(new RDFResource("bnode:ExactlyOneLiteralForm"), Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.SkosXl.LITERAL_FORM.ToString()), 1, 1));

            //SubClassOf
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.Skos.ORDERED_COLLECTION.ToString()), Instance.Model.ClassModel.SelectClass(RDFVocabulary.Skos.COLLECTION.ToString()));
            Instance.Model.ClassModel.AddSubClassOfRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.Skos.SkosXl.LABEL.ToString()), Instance.Model.ClassModel.SelectClass("bnode:ExactlyOneLiteralForm"));

            //DisjointWith
            Instance.Model.ClassModel.AddDisjointWithRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.Skos.COLLECTION.ToString()), Instance.Model.ClassModel.SelectClass(RDFVocabulary.Skos.CONCEPT.ToString()));
            Instance.Model.ClassModel.AddDisjointWithRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.Skos.COLLECTION.ToString()), Instance.Model.ClassModel.SelectClass(RDFVocabulary.Skos.CONCEPT_SCHEME.ToString()));
            Instance.Model.ClassModel.AddDisjointWithRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.Skos.COLLECTION.ToString()), Instance.Model.ClassModel.SelectClass(RDFVocabulary.Skos.SkosXl.LABEL.ToString()));
            Instance.Model.ClassModel.AddDisjointWithRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.Skos.CONCEPT.ToString()), Instance.Model.ClassModel.SelectClass(RDFVocabulary.Skos.CONCEPT_SCHEME.ToString()));
            Instance.Model.ClassModel.AddDisjointWithRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.Skos.CONCEPT.ToString()), Instance.Model.ClassModel.SelectClass(RDFVocabulary.Skos.SkosXl.LABEL.ToString()));
            Instance.Model.ClassModel.AddDisjointWithRelation(Instance.Model.ClassModel.SelectClass(RDFVocabulary.Skos.CONCEPT_SCHEME.ToString()), Instance.Model.ClassModel.SelectClass(RDFVocabulary.Skos.SkosXl.LABEL.ToString()));

            //UnionOf
            Instance.Model.ClassModel.AddUnionOfRelation(
                (RDFOntologyUnionClass)Instance.Model.ClassModel.SelectClass("bnode:ConceptCollection"),
                new List<RDFOntologyClass>() {
                    Instance.Model.ClassModel.SelectClass(RDFVocabulary.Skos.CONCEPT.ToString()),
                    Instance.Model.ClassModel.SelectClass(RDFVocabulary.Skos.COLLECTION.ToString())
                }
            );

            #endregion

            #region PropertyModel

            //SubPropertyOf
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.BROAD_MATCH.ToString()), (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.BROADER.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.BROAD_MATCH.ToString()), (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.MAPPING_RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.BROADER.ToString()), (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.BROADER_TRANSITIVE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.BROADER_TRANSITIVE.ToString()), (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.SEMANTIC_RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.CLOSE_MATCH.ToString()), (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.MAPPING_RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.EXACT_MATCH.ToString()), (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.CLOSE_MATCH.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.MAPPING_RELATION.ToString()), (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.SEMANTIC_RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.NARROW_MATCH.ToString()), (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.NARROWER.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.NARROW_MATCH.ToString()), (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.MAPPING_RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.NARROWER.ToString()), (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.NARROWER_TRANSITIVE.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.NARROWER_TRANSITIVE.ToString()), (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.SEMANTIC_RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.TOP_CONCEPT_OF.ToString()), (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.IN_SCHEME.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.RELATED_MATCH.ToString()), (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.RELATED.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.RELATED_MATCH.ToString()), (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.MAPPING_RELATION.ToString()));
            Instance.Model.PropertyModel.AddSubPropertyOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.RELATED.ToString()), (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.SEMANTIC_RELATION.ToString()));

            //InverseOf
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.BROAD_MATCH.ToString()), (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.NARROW_MATCH.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.BROADER.ToString()), (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.NARROWER.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.BROADER_TRANSITIVE.ToString()), (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.NARROWER_TRANSITIVE.ToString()));
            Instance.Model.PropertyModel.AddInverseOfRelation((RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.HAS_TOP_CONCEPT.ToString()), (RDFOntologyObjectProperty)Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.TOP_CONCEPT_OF.ToString()));

            //Domain/Range
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.HAS_TOP_CONCEPT.ToString()).SetDomain(Instance.Model.ClassModel.SelectClass(RDFVocabulary.Skos.CONCEPT_SCHEME.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.HAS_TOP_CONCEPT.ToString()).SetRange(Instance.Model.ClassModel.SelectClass(RDFVocabulary.Skos.CONCEPT.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.IN_SCHEME.ToString()).SetRange(Instance.Model.ClassModel.SelectClass(RDFVocabulary.Skos.CONCEPT_SCHEME.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.MEMBER.ToString()).SetDomain(Instance.Model.ClassModel.SelectClass(RDFVocabulary.Skos.COLLECTION.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.MEMBER.ToString()).SetRange(Instance.Model.ClassModel.SelectClass("bnode:ConceptCollection"));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.MEMBER_LIST.ToString()).SetDomain(Instance.Model.ClassModel.SelectClass(RDFVocabulary.Skos.ORDERED_COLLECTION.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.SEMANTIC_RELATION.ToString()).SetDomain(Instance.Model.ClassModel.SelectClass(RDFVocabulary.Skos.CONCEPT.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.SEMANTIC_RELATION.ToString()).SetRange(Instance.Model.ClassModel.SelectClass(RDFVocabulary.Skos.CONCEPT.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.TOP_CONCEPT_OF.ToString()).SetDomain(Instance.Model.ClassModel.SelectClass(RDFVocabulary.Skos.CONCEPT.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.TOP_CONCEPT_OF.ToString()).SetRange(Instance.Model.ClassModel.SelectClass(RDFVocabulary.Skos.CONCEPT_SCHEME.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.SkosXl.LITERAL_FORM.ToString()).SetDomain(Instance.Model.ClassModel.SelectClass(RDFVocabulary.Skos.SkosXl.LABEL.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.SkosXl.PREF_LABEL.ToString()).SetRange(Instance.Model.ClassModel.SelectClass(RDFVocabulary.Skos.SkosXl.LABEL.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.SkosXl.ALT_LABEL.ToString()).SetRange(Instance.Model.ClassModel.SelectClass(RDFVocabulary.Skos.SkosXl.LABEL.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.SkosXl.HIDDEN_LABEL.ToString()).SetRange(Instance.Model.ClassModel.SelectClass(RDFVocabulary.Skos.SkosXl.LABEL.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.SkosXl.LABEL_RELATION.ToString()).SetDomain(Instance.Model.ClassModel.SelectClass(RDFVocabulary.Skos.SkosXl.LABEL.ToString()));
            Instance.Model.PropertyModel.SelectProperty(RDFVocabulary.Skos.SkosXl.LABEL_RELATION.ToString()).SetRange(Instance.Model.ClassModel.SelectClass(RDFVocabulary.Skos.SkosXl.LABEL.ToString()));

            #endregion

            #endregion

        }
        #endregion

    }

}