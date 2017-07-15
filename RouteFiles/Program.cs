using System;
using System.Collections.Generic;
namespace RouteFiles
{
    public class Program
    {
        public static void Main(string[] args)
        {   
            // Declares LinkedList of Parameters to pass to Header method
            LinkedList<Parameter> localParams = new LinkedList<Parameter>();
            
            // Add to the LinkedList of Parameters
            localParams.AddLast(new Parameter("String", "testStr"));
            localParams.AddLast(new Parameter("int", "count"));
            
            // Declare new header, initalize with name Index and parameters from LinkedList
            Header test = new Header("Index", localParams);
            
            // Establishes Route attributes: Route and Post/Get
            Url testUrl = new Url("Index", new LinkedList<String>(), "Post");
            
            // Creates a sample viewbags entries with dummy data
            ViewBagEntry demoBag = new ViewBagEntry("userName", "garbage");
            ViewBagEntry demoBag2 = new ViewBagEntry("password", "trash");

            // Creates a sample Sessions operation
            SessionEntrySet demoSession = new SessionEntrySet("Int32", "userName", "test");

            // Creates a LinkedList of ViewBagEntry objects to pass to the actual Route Builder
            LinkedList<ViewBagEntry> demoBagFull = new LinkedList<ViewBagEntry>();
            demoBagFull.AddLast(demoBag);
            demoBagFull.AddLast(demoBag2);

            // Creates a LinkedList of SessionEntryGet objecfts to pass to the acutal Route Builder, forming the body
            LinkedList<SessionEntryGet> sessionOpsGet = new LinkedList<SessionEntryGet>();

            // Creates a LinkedList of SessionEntrySet objects to pass to the actual Route Builder, forming the body
            LinkedList<SessionEntrySet> sessionOps = new LinkedList<SessionEntrySet>();
            sessionOps.AddLast(demoSession);
            sessionOps.AddLast(new SessionEntrySet("Int32", "userName", "test"));
            
            // Pass all of this information to the "Route" class
            Route sampleController = new Route(test, demoBagFull, sessionOps, sessionOpsGet, testUrl);
            
            // Print the result of the Route Class
            System.Console.WriteLine((sampleController.toString()));
        }
    }
}
