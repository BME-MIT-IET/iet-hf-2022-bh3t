using RDFSharp.Model;
using System;
using System.Collections.Generic;

namespace ManualTests
{
    class Program
    {
        static void Main(string[] args)
        {
            bool menuActive = true;
            while (menuActive)
            {
                Console.WriteLine("Choose a test!");
                Console.WriteLine("1. create resources (1)");
                Console.WriteLine("2. create literals (2)");
                Console.WriteLine("3. create triples (3)");
                Console.WriteLine("4. create graph (4)");
                Console.WriteLine("5. manipulate graph (5)");
                Console.WriteLine("Exit (e)");
                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        {
                            CreateResourcesMenu();
                            break;
                        }

                    case "2":
                        {
                            CreateLiteralsMenu();
                            break;
                        }

                    case "3":
                        {
                            CreateTriplesMenu();
                            break;
                        }

                    case "4":
                        {
                            CreateGraphMenu();
                            break;
                        }

                    case "5":
                        {
                            break;
                        }

                    case "e":
                        {
                            menuActive = false;
                            break;
                        }
                        
                    default:
                        {
                            Console.WriteLine("Choose a number from above!");
                            break;
                        }
                }
            }
        }

        private static void CreateResourcesMenu()
        {
            bool crMenuActive = true;
            while (crMenuActive)
            {
                Console.WriteLine("Choose a sub-test!");
                Console.WriteLine("1. create resource with uri-string");
                Console.WriteLine("2. create resource with blank string");
                Console.WriteLine("3. create resource with not uri string");
                Console.WriteLine("4. create resource without string");
                Console.WriteLine("Exit create resources (e)");
                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        {
                            CreateResource(1);
                            break;
                        }

                    case "2":
                        {
                            CreateResource(2);
                            break;
                        }

                    case "3":
                        {
                            CreateResource(3);
                            break;
                        }

                    case "4":
                        {
                            CreateResource(4);
                            break;
                        }

                    case "e":
                        {
                            crMenuActive = false;
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Choose a number from above!");
                            break;
                        }
                }
            }
            
        }

        private static void CreateResource(int mode)
        {
            switch (mode)
            {
                case 1:
                    {
                        try
                        {
                            Console.WriteLine("Expectation: Success");
                            var donaldduck = new RDFResource("http://www.waltdisney.com/donald_duck");
                            Console.WriteLine(donaldduck);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    }

                case 2:
                    {
                        try
                        {
                            Console.WriteLine("Expectation: Empty resource");
                            var disney = new RDFResource("");
                            Console.WriteLine(disney);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    }

                case 3:
                    {
                        try
                        {
                            Console.WriteLine("Expectation: Exception");
                            var mickey = new RDFResource("MickeyMouse");
                            Console.WriteLine(mickey);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    }

                case 4:
                    {
                        try
                        {
                            Console.WriteLine("Expectation: Empty resource");
                            var disney_group = new RDFResource();
                            Console.WriteLine(disney_group);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
        }

        private static void CreateLiteralsMenu()
        {
            bool literalMenu = true;
            while (literalMenu)
            {
                Console.WriteLine("1. create plainliteral with string");
                Console.WriteLine("2. create plainliteral with blank string");
                Console.WriteLine("3. create plainliteral with sting and language tag");
                Console.WriteLine("4. create plainliteral with string and blank language tag");
                Console.WriteLine("5. create plainliteral with blank string and language tag");
                Console.WriteLine("6. create plainliteral with blank string and blank language tag");
                Console.WriteLine("7. create typedliteral with correct value");
                Console.WriteLine("8. create typedliteral with blank value");
                Console.WriteLine("9. create typedliteral with not matching values");
                Console.WriteLine("Exit (e)");
                string mode = Console.ReadLine();
                switch (mode)
                {
                    case "1":
                        {
                            CreateLiteral(1);
                            break;
                        }

                    case "2":
                        {
                            CreateLiteral(2);
                            break;
                        }

                    case "3":
                        {
                            CreateLiteral(3);
                            break;
                        }

                    case "4":
                        {
                            CreateLiteral(4);
                            break;
                        }

                    case "5":
                        {
                            CreateLiteral(5);
                            break;
                        }

                    case "6":
                        {
                            CreateLiteral(6);
                            break;
                        }

                    case "7":
                        {
                            CreateLiteral(7);
                            break;
                        }

                    case "8":
                        {
                            CreateLiteral(8);
                            break;
                        }

                    case "9":
                        {
                            CreateLiteral(9);
                            break;
                        }

                    case "e":
                        {
                            literalMenu = false;
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Choose a number from above!");
                            break;
                        }
                }
            }
        }

        private static void CreateLiteral(int mode)
        {
            switch (mode)
            {
                case 1:
                    {
                        try
                        {
                            Console.WriteLine("Expectation: Success");
                            var donaldduck_name = new RDFPlainLiteral("Donald Duck");
                            Console.WriteLine(donaldduck_name);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    }

                case 2:
                    {
                        try
                        {
                            Console.WriteLine("Expectation: Success (with empty string)");
                            var donaldduck_withoutname = new RDFPlainLiteral("");
                            Console.WriteLine(donaldduck_withoutname);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    }

                case 3:
                    {
                        try
                        {
                            Console.WriteLine("Expectation: Success");
                            var donaldduck_name_enus = new RDFPlainLiteral("Donald Duck", "en-US");
                            Console.WriteLine(donaldduck_name_enus);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    }

                case 4:
                    {
                        try
                        {
                            Console.WriteLine("Expectation: Success (empty language tag)");
                            var donaldduck_name_withoutenus = new RDFPlainLiteral("Donald Duck", "");
                            Console.WriteLine(donaldduck_name_withoutenus);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    }

                case 5:
                    {
                        try
                        {
                            Console.WriteLine("Expectation: Exception");
                            var notdonaldduck_name_enus = new RDFPlainLiteral("", "en-US");
                            Console.WriteLine(notdonaldduck_name_enus);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    }

                case 6:
                    {
                        try
                        {
                            Console.WriteLine("Expectation: Exception");
                            var notdonaldduck_name_notenus = new RDFPlainLiteral("", "");
                            Console.WriteLine(notdonaldduck_name_notenus);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    }

                case 7:
                    {
                        try
                        {
                            Console.WriteLine("Expectation: Success");
                            var mickeymouse_age = new RDFTypedLiteral("85", RDFModelEnums.RDFDatatypes.XSD_INTEGER);
                            Console.WriteLine(mickeymouse_age);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    }

                case 8:
                    {
                        try
                        {
                            Console.WriteLine("Expectation: Exception");
                            var mickeymouse_noage = new RDFTypedLiteral("", RDFModelEnums.RDFDatatypes.XSD_INTEGER);
                            Console.WriteLine(mickeymouse_noage);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    }

                case 9:
                    {
                        try
                        {
                            Console.WriteLine("Expectation: Exception");
                            var mickeymouse_strage = new RDFTypedLiteral("eighty", RDFModelEnums.RDFDatatypes.XSD_INTEGER);
                            Console.WriteLine(mickeymouse_strage);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    }
                default: break;
            }
        }
    
        private static void CreateTriplesMenu()
        {
            bool ctMenu = true;
            while (ctMenu)
            {
                Console.WriteLine("Choose a sub-test!");
                Console.WriteLine("1. create triple with correct values");
                Console.WriteLine("2. create triple with blank values");

                Console.WriteLine("Exit create resources (e)");
                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        {
                            CreateTriples(1);
                            break;
                        }

                    case "2":
                        {
                            CreateTriples(2);
                            break;
                        }

                    case "e":
                        {
                            ctMenu = false;
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Choose a number from above!");
                            break;
                        }
                }
            }
        }

        private static void CreateTriples(int mode)
        {
            switch (mode)
            {
                case 1:
                    {
                        try
                        {
                            Console.WriteLine("Expectation: Success");
                            RDFTriple mickeymouse_is85yr = new RDFTriple(
                             new RDFResource("http://www.waltdisney.com/mickey_mouse"),
                             new RDFResource("http://xmlns.com/foaf/0.1/age"),
                             new RDFTypedLiteral("85", RDFModelEnums.RDFDatatypes.XSD_INTEGER));
                            Console.WriteLine(mickeymouse_is85yr);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    }
                case 2:
                    {
                        try
                        {
                            Console.WriteLine("Expectation: Exception");
                            RDFTriple mickeymouse_ = new RDFTriple(
                             new RDFResource(""),
                             new RDFResource(""),
                             new RDFTypedLiteral("85", RDFModelEnums.RDFDatatypes.XSD_INTEGER));
                            Console.WriteLine(mickeymouse_);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        
                        break;
                    }
                default: break;
            }
        }

        private static void CreateGraphMenu()
        {
            bool cgMenu = true;
            while (cgMenu)
            {
                Console.WriteLine("Choose a sub-test!");
                Console.WriteLine("1. create empty graph");
                Console.WriteLine("2. create graph with triples");
                Console.WriteLine("3. create graph with uri string");
                Console.WriteLine("4. create graph from datatable");
                Console.WriteLine("Exit create resources (e)");
                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        {
                            CreateGraph(1);
                            break;
                        }

                    case "2":
                        {
                            CreateGraph(2);
                            break;
                        }

                    case "3":
                        {
                            CreateGraph(3);
                            break;
                        }

                    case "4":
                        {
                            CreateGraph(4);
                            break;
                        }

                    case "e":
                        {
                            cgMenu = false;
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Choose a number from above!");
                            break;
                        }
                }
            }
        }

        private static void CreateGraph(int mode)
        {
            switch (mode)
            {
                case 1:
                    {
                        try
                        {
                            Console.WriteLine("Expectation: Success");
                            var waltdisney = new RDFGraph();
                            Console.WriteLine(waltdisney);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    }
                case 2:
                    {
                        try
                        {
                            Console.WriteLine("Expectation: Success");
                            RDFTriple mickeymouse_is85yr = new RDFTriple(
                             new RDFResource("http://www.waltdisney.com/mickey_mouse"),
                             new RDFResource("http://xmlns.com/foaf/0.1/age"),
                             new RDFTypedLiteral("85", RDFModelEnums.RDFDatatypes.XSD_INTEGER));
                            RDFTriple donaldduck_name_enus = new RDFTriple(
                             new RDFResource("http://www.waltdisney.com/donald_duck"),
                             new RDFResource("http://xmlns.com/foaf/0.1/name"),
                             new RDFPlainLiteral("Donald Duck", "en-US"));

                            var waltdisney_filled = new RDFGraph(new List<RDFTriple>() { mickeymouse_is85yr, donaldduck_name_enus });

                            foreach (RDFTriple Triple in waltdisney_filled)
                                Console.WriteLine(Triple);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    }

                case 3:
                    {
                        try
                        {
                            Console.WriteLine("Expectation: Success");
                            var waltdisney = new RDFGraph();
                            waltdisney.SetContext(new Uri("http://waltdisney.com/"));
                            foreach (RDFTriple Triple in waltdisney)
                                Console.WriteLine(Triple);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    }

                case 4:
                    {
                        try
                        {
                            Console.WriteLine("Expectation: Success");
                            RDFTriple donaldduck_name_enus_triple = new RDFTriple(
                                new RDFResource("http://www.waltdisney.com/donald_duck"),
                                new RDFResource("http://xmlns.com/foaf/0.1/name"),
                                new RDFPlainLiteral("Donald Duck", "en-US"));

                            RDFTriple mickeymouse_is85yr = new RDFTriple(
                                new RDFResource("http://www.waltdisney.com/mickey_mouse"),
                                new RDFResource("http://xmlns.com/foaf/0.1/age"),
                                new RDFTypedLiteral("85", RDFModelEnums.RDFDatatypes.XSD_INTEGER));

                            var waltdisney_list = new RDFGraph(new List<RDFTriple>() { mickeymouse_is85yr, donaldduck_name_enus_triple });

                            var waltdisney_table = waltdisney_list.ToDataTable();
                            var waltdisney_newgraph = RDFGraph.FromDataTable(waltdisney_table);
                            foreach (RDFTriple t in waltdisney_newgraph)
                            {
                                Console.WriteLine("Subject: " + t.Subject);
                                Console.WriteLine("Predicate: " + t.Predicate);
                                Console.WriteLine("Object: " + t.Object);
                            }


                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    }

                default: break;
            }
        }

        private static void ManipulateGraphMenu()
        {
            bool mgMenu = true;
            while (mgMenu)
            {
                Console.WriteLine("Choose a sub-test!");
                Console.WriteLine("1. add triple to graph");
                Console.WriteLine("2. delete triples from graph");
                Console.WriteLine("3. delete triples by subject from graph");
                Console.WriteLine("4. delete triples by non existing predicate from graph");
                Console.WriteLine("5. delete triples by object from graph");
                Console.WriteLine("6. delete triples by non existing literal from graph");
                Console.WriteLine("7. clear triples from graph");
                Console.WriteLine("8. check if given triple exists");
                Console.WriteLine("Exit create resources (e)");
                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        {
                            
                            break;
                        }

                    case "2":
                        {
                            
                            break;
                        }

                    case "3":
                        {
                            
                            break;
                        }

                    case "4":
                        {
                            
                            break;
                        }

                    case "e":
                        {
                            mgMenu = false;
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Choose a number from above!");
                            break;
                        }
                }
            }
        }
    }
}
