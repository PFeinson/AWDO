using System;

namespace RouteFiles {
    // Class to handle getting information from Sessions
    public class SessionEntryGet {
        public String identifier, type;
        public Object contents;
        // Constructor: Requires exactly 3 parameters or isn't valid
        public SessionEntryGet(String type, String identifier, Object contents) {
            this.identifier = identifier;
            this.contents = contents;
            this.type = type;
        }   
        // Combines information into a usable line of code returns as String
        public String toString() {
            return String.Format("\t\t\tHttpContext.Session.Get{0}(\"{1}\", \"{2}\");\n", type, identifier, contents);
        }
    }

    // Class to handle storing information in sessions    
    public class SessionEntrySet {
        public String identifier, type;
        public Object contents;
        // Constructor: Requires exactly three parameters or isn't valid
        public SessionEntrySet(String type, String identifier, Object contents) {
            this.type = type;
            this.identifier = identifier;
            this.contents = contents;
        }

        // Combines information into a usable line of code returns as String
        public String toString() {
            return String.Format("\t\t\tHttpContext.Session.Set{0}(\"{1}\", \"{2}\");\n", type, identifier, contents);
        }
    }

    // Class to handle adding information to ViewBag
    public class ViewBagEntry {
        String id, contents;

        // Constructor: Requires exactly two parameters or isn't valid
        public ViewBagEntry(String id, String contents) {
            this.id = id;
            this.contents = contents;
        }
        // Combines information into a usable line of code, returns as String
        public String toString() {
            return String.Format("\t\t\tViewBag.{0} = \"{1}\";\n", id, contents);
        }
    }
}