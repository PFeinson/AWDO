using System;
using System.Collections.Generic;

namespace ConsoleApplication {
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
            // Builds Class
            information += String.Format("namespace {0}.Controllers\n{{\n", controllerName);
            // Insert Route information here
            information += "}";
            return information;
        }

    }
}