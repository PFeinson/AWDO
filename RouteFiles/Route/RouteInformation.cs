using System;
using System.Collections.Generic;

namespace RouteFiles
{
    public class Header
    {
        public String headerName;
        public LinkedList<Parameter> parameterList;

        public Header(String headerName, LinkedList<Parameter> parameterList) {
            this.headerName = headerName;
            this.parameterList = parameterList;
        }

        public String toString() {
            String paramsListString = "";
            // append each parameter to header
            foreach (Parameter focus in parameterList) {
                paramsListString += (focus.toString() + ", ");
            }
            return String.Format("\t\t\tpublic IActionResult {0}({1}){2}", headerName, paramsListString.Substring(0, paramsListString.Length-2), "{");
        }
    }

    public class Url
    {
        public LinkedList<String> urlVars;
        public String name;
        public String action;
        public Url(String name, LinkedList<String> urlVars, String action)
        {
            this.urlVars = urlVars;
            this.name = name;
            this.action = action;
        }

        public String toString()
        {
            String pulledData = "";
            foreach (String currentVar in urlVars)
            {
                pulledData += String.Format("/{0}", "{" + currentVar + "\n");
            }
            return String.Format("\t\t\t{2}\n\t\t\t[Route(\"{0}{1}\")]\n", name, pulledData, String.Format("[Http{0}]", action));
        }
    }

    public class Parameter
    {
        String type, identifier;
        public Parameter(String type, String identifier)
        {
            this.type = type;
            this.identifier = identifier;
        }

        public String toString()
        {
            return String.Format("{0} {1}", type, identifier);
        }
    }
}

