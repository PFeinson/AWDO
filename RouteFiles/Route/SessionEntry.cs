using System;

namespace ConsoleApplication {
    public class SessionEntry {
        public String getSet, identifier, type;
        public Object contents;
        public SessionEntry(String getSet, String type, String identifier, Object contents) {
            this.getSet = getSet;
            this.identifier = identifier;
            this.contents = contents;
            this.type = type;
        }   

        public String toString() {
            return String.Format("\n\t\t\t\tHttpContext.Session.{0}{1}(\"{2}\", \"{3}\");", getSet, type, identifier, contents);
        }
    }
}