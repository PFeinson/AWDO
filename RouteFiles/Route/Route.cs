using System;
using System.Collections.Generic;

namespace RouteFiles {
    public class Route {
        Header header;
        LinkedList<ViewBagEntry> viewBagOps;
        LinkedList<SessionEntrySet> sessionOpsSet;
        Url path;
         public Route(Header header, LinkedList<ViewBagEntry> viewBagOps, LinkedList<SessionEntrySet> sessionOpsSet, Url path) {
             this.header = header;
             this.viewBagOps = viewBagOps;
             this.sessionOpsSet = sessionOpsSet;
             this.path = path;
         }

         public String toString() {
             String routeString = (path.toString() + header.toString());
             foreach (ViewBagEntry viewBagLine in viewBagOps) {
                 routeString += viewBagLine.toString();
             }
             foreach (SessionEntrySet sessionEntry in sessionOpsSet) {
                 routeString += sessionEntry.toString();
             }
             routeString += "\n\t\t\t}";
             return routeString;
         }
    }
}