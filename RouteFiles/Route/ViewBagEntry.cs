using System;

namespace RouteFiles {
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