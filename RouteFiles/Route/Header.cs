using System;
using System.Collections.Generic;

namespace RouteFiles
{
    public class Header
    {
        public String name;
        public LinkedList<Parameter> parameterList;

        public Header(String name, LinkedList<Parameter> parameterList) {
            this.name = name;
            this.parameterList = parameterList;
        }

        public String toString() {
            String paramsListString = "";
            // append each parameter to header
            foreach (Parameter focus in parameterList) {
                paramsListString += (focus.toString() + ", ");
            }
            return String.Format("\t\t\tpublic IActionResult {0}({1}){2}", name, paramsListString.Substring(0, paramsListString.Length-2), "{");
        }
    }
}

