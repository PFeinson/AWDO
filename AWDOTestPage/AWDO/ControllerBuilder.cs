using System;
using System.Collections.Generic;
using Route;

namespace AWDO {
    public class ControllerBuilder {

        LinkedList<String> imports;
        String controllerName;

        // Requires exactly two parameters. No overloads; Will not work with less information
        public ControllerBuilder(LinkedList<String>  imports, String controllerName) {
            this.imports = imports;
            this.controllerName = controllerName;
        }

        //public void addRoute(Route

        public String toString() {
            String information = "";
            // Builds using ....; part of a Controller
            foreach (String useStat in imports) {
                information += String.Format("using {0};\n", useStat);
            }
            // Builds namespace
            information += String.Format("namespace {0}.Controllers\n{{\n", controllerName);
            // Builds class
            information += String.Format("\tpublic class {0}Controller : Controller {{\n", controllerName);
            Header sampleHeader = new Header(controllerName);
            Url sampleUrl = new Url(controllerName, "Get");
            Route.Route sampleController = new Route.Route(sampleHeader, sampleUrl);
            information += sampleController.toString();
            information += "\t}\n}";
            return information;
        }

    }
}