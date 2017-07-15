using System.Collections.Generic;
using System;
namespace HTMLSerialTree
{
    public class HTMLTree
    {
        Node root;
        public HTMLTree()
        {
            // Construct the static elements of a web page
            root = new Node("0", "", "html", "");
            add("00", "", "head", "");
            add("01", "", "body", "");
            // Test data for copy and paste from terminal into text editor html integrity test
            // Website body 
            add("010", "", "div", "class=\"navBar\" width=\"300px\" height=\"150px\"");
            add("0100", "", "p", "");
            add("01000", "Hello World!", "h1", "");
            add("011", "", "div", "");
            // head tag elements
            add("000", "", "link");
            add("001", "", "source", "");
            // body of site extended
            add("0110", "This really works???", "h4", "");
        }

        public void add(String serial, String contents, String tag) {
            add(serial, contents, tag, "");
        }
        public void add(String serial, String contents, String tag, String attributes)
        {
            // DEBUGGING
            // Display information about the node currently being assessed
            //Console.WriteLine(String.Format("Current node to place: {0}, {1}, {2}", serial, contents, tag));
            // Variable for each digit of the serial number
            int currentSerial;
            // Variable for the number of nodes explored in the LinkedList<Node>
            int nodesNavigated = 0; ;
            // Kill switch incase returns fail
            Boolean created = false;
            // Start navigation with root
            Node focus = root;
            // Instantiate the LinkedListNode
            LinkedListNode<Node> scanChildren = null;

            // If its body or head
            if (serial.Length == 2 && !created)
            {
                if (attributes.Length <= 0)
                {
                    focus.children.AddLast(new Node(serial, contents, tag));
                }
                else
                {
                    focus.children.AddLast(new Node(serial, contents, tag, attributes));
                }
                created = true;
                return;
            }
            // If its any other tag
            else
            {
                // Iterate through each value in the HTML's serial number
                for (int i = 1; i < serial.Length - 1; ++i)
                {
                    // Grab current digit of serial number
                    currentSerial = Convert.ToInt32(serial[i].ToString());
                    // If the current serial number is 0
                    if (currentSerial == 0 && !created)
                    {
                        // If this node has no children, the attempted addition must be the intended first child
                        if (focus.children.First == null)
                        {
                            // Add new node and break out of method
                            created = true;
                            if (attributes.Length <= 0)
                            {
                                focus.children.AddLast(new Node(serial, contents, tag));
                            }
                            else
                            {
                                focus.children.AddLast(new Node(serial, contents, tag, attributes));
                            }
                            return;
                        }
                        // Otherwise if the first child exists, shift focus to that
                        else
                        {
                            focus = focus.children.First.Value;
                            //Console.WriteLine(String.Format("Currently examining: {0}, {1}, {2}", focus.serial, focus.contents, focus.tag));
                        }
                    }
                    else
                    {
                        // Set LinkedListNode to navigate children to the first child of whichever node is currently the focus
                        scanChildren = focus.children.First;
                        // DEBUGGING
                        // Status of sentinal values in while loop
                        // Console.WriteLine(String.Format("Current stats: currentSerial: {0}, nodesNavigated: {1}, scanChildren: {2}, scanChildren.Next: {3}",
                        //    currentSerial, nodesNavigated, scanChildren, scanChildren.Next));
                        while (scanChildren.Next != null && nodesNavigated < currentSerial && !created)
                        {
                            // DEBUGGING
                            //Console.WriteLine("Entered Children Traversal While Loop");
                            // Move the pointer responsible for traversing the "children" LinkedList<Node>
                            scanChildren = scanChildren.Next;
                            nodesNavigated++;
                            // DEBUGGING
                            // Post update on what node is currently focus
                            // Console.WriteLine(String.Format("Currently examining: {0}, {1}, {2}", focus.serial, focus.contents, focus.tag));
                        }
                        // Assign focus to the Value attached to the scanChildren LinkedListNode<Node>
                        focus = scanChildren.Value;
                        // If the current focus has no existing children
                        if (focus.children.First == null && !created)
                        {
                            // Add the new node and exit the method
                            if (attributes.Length <= 0)
                            {
                                focus.children.AddLast(new Node(serial, contents, tag));
                            }
                            else
                            {
                                focus.children.AddLast(new Node(serial, contents, tag, attributes));
                            }
                            created = true;
                            return;
                        }
                    }
                    // In all cases that this method has not exited yet, add the new node to wherever focus is 
                    nodesNavigated = 0;
                }
                if (!created)
                {
                    if (attributes.Length <= 0)
                    {
                        focus.children.AddLast(new Node(serial, contents, tag));
                    }
                    else
                    {
                        focus.children.AddLast(new Node(serial, contents, tag, attributes));
                    }
                }
            }
            //Console.WriteLine(plotTree(root));
        }



        public String toString()
        {
            return plotTree(root);
        }

        public String plotTree(Node focus)
        {
            // Instantiate the LinkedListNode to navigate children
            LinkedListNode<Node> childrenNavigator = null;
            String page = "";
            String tabs = "";
            // Set up white space for formatting
            for (int i = 0; i < focus.serial.Length - 1; ++i)
            {
                tabs += "\t";
            }
            // Build opening tag
            // If attributes exist....
            if (focus.attributes != null)
            {
                page = String.Format("{0}<{1} serial=\"{2}\" {3}>\n", tabs, focus.tag, focus.serial, focus.attributes);
            }
            else
            {
                page = String.Format("{0}<{1} serial=\"{2}\">\n", tabs, focus.tag, focus.serial);
            }
            // if the first child exists
            if (focus.children.First != null)
            {
                childrenNavigator = focus.children.First;
            }
            // while childrenNavigator has a value
            while (childrenNavigator != null)
            {
                page += plotTree(childrenNavigator.Value);
                childrenNavigator = childrenNavigator.Next;
            }
            // If this tag has content inside of its open and close (example: Text) add it here
            if (focus.contents.Length > 0)
            {
                page += String.Format("{0}{1}\n", tabs, focus.contents);
            }
            // Build closing tag
            page += String.Format("{0}</{1}>\n", tabs, focus.tag);

            return page;
        }
    }

    public class Node
    {
        // Store children in LinkedList for serial traversal
        public LinkedList<Node> children = new LinkedList<Node>();
        // Instantiate components of a Node
        public String serial, contents, tag, attributes;


        // Constructor
        public Node(String serial, String contents, String tag)
        {
            this.serial = serial;
            this.contents = contents;
            this.tag = tag;
        }

        public Node(String serial, String contents, String tag, String attributes)
        {
            this.serial = serial;
            this.contents = contents;
            this.tag = tag;
            this.attributes = attributes;
        }

        public void addAttributes(String attributes)
        {
            this.attributes += (" " + attributes);
        }
    }
}