using System;
using System.Collections.Generic;
namespace RouteFiles
{
    class Program
    {
        static void Main(string[] args)
        {
    
            LinkedList<String> inputs = new LinkedList<String>();
            inputs.AddFirst("System");
            inputs.AddLast("System.Collections.Generic");
            inputs.AddLast("System.Threading.Tasks");
            inputs.AddLast("Microsoft.AspNetCore.Mvc");
            inputs.AddLast("Microsoft.AspNetCore.http:");
            inputs.AddLast("NewtonSoft.Json");
            ControllerBuilder Home = new ControllerBuilder(inputs, "Home");
            Console.WriteLine(Home.toString());
        }
    }
}