using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
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