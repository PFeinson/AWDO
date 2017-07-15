using System;
using System.Collections.Generic;

namespace RouteFiles
{

    // Header builds the opening method statement
    public class Header
    {
        public String headerName;
        public LinkedList<Parameter> parameterList;

        // Constructor: Requires exactly 2 parameters
        public Header(String headerName, LinkedList<Parameter> parameterList) {
            this.headerName = headerName;
            this.parameterList = parameterList;
        }

        // Builder method: Turns data into usable String
        public String toString() {
            String paramsListString = "";
            // append each parameter to header
            foreach (Parameter focus in parameterList) {
                paramsListString += (focus.toString() + ", ");
            }
            // Construct final opening method statuement.
            return String.Format("\t\t\tpublic IActionResult {0}({1}){2}", headerName, paramsListString.Substring(0, paramsListString.Length-2), "{");
        }
    }

    // Url attaches 2 Attributes to a given route: [Route("")] and [HttpGet]
    public class Url
    {
        public LinkedList<String> urlVars;
        public String name;
        public String action;
        // Constructor: Requires exactly 3 inputs, otherwise would not generate usable code
        public Url(String name, LinkedList<String> urlVars, String action)
        {
            this.urlVars = urlVars;
            this.name = name;
            this.action = action;
        }

        // Builder method that combines data into usable String
        public String toString()
        {
            String urlData = "";
            // Attach Variables passed through Url
            foreach (String currentVar in urlVars)
            {
                urlData += String.Format("/{0}", "{" + currentVar + "\n");
            }
            // Combine all of the data into a usable form
            return String.Format("\t\t\t{2}\n\t\t\t[Route(\"{0}{1}\")]\n", name, urlData, String.Format("[Http{0}]", action));
        }
    }

    // Parameter class, support for header. Adds variables
    public class Parameter
    {
        String type, identifier;

        // Constructor: Requires exactly 2 inputs or would not be a valid parameter
        public Parameter(String type, String identifier)
        {
            this.type = type;
            this.identifier = identifier;
        }

        // Combine the two terms into one statement
        public String toString()
        {
            return String.Format("{0} {1}", type, identifier);
        }
    }
}

