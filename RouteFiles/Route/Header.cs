using System;
using System.Collections.Generic;

namespace ConsoleApplication
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
            foreach (Parameter focus in parameterList) {
                Console.WriteLine(focus.toString());
                paramsListString += (focus.toString() + ", ");
            }
            Console.WriteLine(paramsListString);
            return String.Format("\t\t\tpublic IActionResult {0}({1}){2}", name, paramsListString.Substring(0, paramsListString.Length-2), "{");
        }
    }
}

