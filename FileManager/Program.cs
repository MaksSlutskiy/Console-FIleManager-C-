using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp9;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Maxoft Far Manager";
            Console.SetWindowSize(73, 42);
            Console.BufferHeight = 42;
            Console.BufferWidth = 73;
            Console.SetWindowSize(73, 42);

            Interface start = new Interface();          
            start.Start();
        }
    }
}
