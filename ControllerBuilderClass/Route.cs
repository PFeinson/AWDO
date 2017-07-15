using System;
using System.Collections.Generic;

namespace RouteFiles {
    // Route class: Builds the contents of each route
    public class Route {
        Header header;
        LinkedList<ViewBagEntry> viewBagOps;
        LinkedList<SessionEntrySet> sessionOpsSet;
        LinkedList<SessionEntryGet> sessionOpsGet;
        Url path;
        // Constructor: Requires 2 parameters for MVP
        public Route(Header header, Url path) {
            this.header = header;
            this.path = path;
        }


        // Constructor: Requires exactly five parameters, includes most different options
         public Route(Header header, LinkedList<ViewBagEntry> viewBagOps, LinkedList<SessionEntrySet> sessionOpsSet, LinkedList<SessionEntryGet> sessionOpsGet, Url path) {
             this.header = header;
             this.viewBagOps = viewBagOps;
             this.sessionOpsSet = sessionOpsSet;
             this.sessionOpsGet = sessionOpsGet;
             this.path = path;
         }

         public String toString() {
             // Creates variable to store view bag and sessions operations to write to route function
             String routeString = (path.toString() + header.toString());
             // Appends each view bag entry to the string
             foreach (ViewBagEntry viewBagLine in viewBagOps) {
                 routeString += viewBagLine.toString();
             }
             // Appends each item in LinkedList containing SessionEntrySet operations
             foreach (SessionEntrySet sessionEntry in sessionOpsSet) {
                 routeString += sessionEntry.toString();
             }
            // Appends each item in LinkedList containing SessionEntryGet operations
            foreach (SessionEntryGet sessionEntry in sessionOpsGet) {
                routeString += sessionEntry.toString();
            }
             routeString += "\t\t\treturn View();\n";
             routeString += "\t\t}\n";
             return routeString;
         }
    }
}