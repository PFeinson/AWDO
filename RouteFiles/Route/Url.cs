using System;
using System.Collections.Generic;

namespace RouteFiles
{
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
}