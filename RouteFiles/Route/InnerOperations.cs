using System;

namespace RouteFiles {
    public class SessionEntryGet {
        public String identifier, type;
        public Object contents;
        public SessionEntryGet(String type, String identifier, Object contents) {
            this.identifier = identifier;
            this.contents = contents;
            this.type = type;
        }   

        public String toString() {
            return String.Format("\n\t\t\t\tHttpContext.Session.Get{0}(\"{1}\", \"{2}\");", type, identifier, contents);
        }
    }
    
    public class SessionEntrySet {
        public String identifier, type;
        public Object contents;
        public SessionEntrySet(String type, String identifier, Object contents) {
            this.type = type;
            this.identifier = identifier;
            this.contents = contents;
        }

        public String toString() {
            return String.Format("\n\t\t\t\tHttpContext.Session.Set{0}(\"{1}\", \"{2}\";", type, identifier, contents);
        }
    }

    public class ViewBagEntry {
        String id, contents;
        public ViewBagEntry(String id, String contents) {
            this.id = id;
            this.contents = contents;
        }

        public String toString() {
            return String.Format("\n\t\t\t\tViewBag.{0} = \"{1}\";", id, contents);
        }
    }
}