using System;
using System.Collections.Generic;

namespace ConsoleApplication {
    public class Route {
        Header header;
        LinkedList<ViewBagEntry> viewBagOps;
        LinkedList<SessionEntry> sessionOps;
        Url path;
         public Route(Header header, LinkedList<ViewBagEntry> viewBagOps, LinkedList<SessionEntry> sessionOps, Url path) {
             this.header = header;
             this.viewBagOps = viewBagOps;
             this.sessionOps = sessionOps;
             this.path = path;
         }

         public String toString() {
             String routeString = (path.toString() + header.toString());
             foreach (ViewBagEntry viewBagLine in viewBagOps) {
                 routeString += viewBagLine.toString();
             }
             foreach (SessionEntry sessionEntry in sessionOps) {
                 routeString += sessionEntry.toString();
             }
             routeString += "\n\t\t\t}";
             return routeString;
         }
    }
}