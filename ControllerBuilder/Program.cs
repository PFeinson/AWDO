using System;
using System.Collections.Generic;
namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<String> inputs = new LinkedList<String>();
            inputs.AddFirst("System");
            inputs.AddLast("System.Collections.Generic");
            ControllerBuilder Home = new ControllerBuilder(inputs, "Home");
            Console.WriteLine(Home.toString());
        }
    }
}
