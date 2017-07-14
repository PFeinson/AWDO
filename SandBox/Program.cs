using System;
using System.Collections.Generic;
namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {   
            LinkedList<Parameter> localParams = new LinkedList<Parameter>();
            localParams.AddLast(new Parameter("String", "testStr"));
            localParams.AddLast(new Parameter("int", "count"));
            Header test = new Header("Index", localParams);
            Url testUrl = new Url("Index", new LinkedList<String>(), "Post");
            ViewBagEntry demoBag = new ViewBagEntry("userName", "garbage");
            ViewBagEntry demoBag2 = new ViewBagEntry("password", "trash");
            SessionEntry demoSession = new SessionEntry("Set", "Int32", "userName", "test");
            LinkedList<ViewBagEntry> demoBagFull = new LinkedList<ViewBagEntry>();
            demoBagFull.AddLast(demoBag);
            demoBagFull.AddLast(demoBag2);
            LinkedList<SessionEntry> sessionOps = new LinkedList<SessionEntry>();
            sessionOps.AddLast(demoSession);
            sessionOps.AddLast(new SessionEntry("Get", "Int32", "userName", "test"));
            Route sampleController = new Route(test, demoBagFull, sessionOps, testUrl);
            System.Console.WriteLine((sampleController.toString()));
        }
    }
}
