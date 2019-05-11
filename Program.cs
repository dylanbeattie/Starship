using System;
using Newtonsoft.Json;
using Starship.Rockstar;

namespace Starship {
    class Program {
        static void Main(string[] args) {
            var source = System.IO.File.ReadAllText("test.rock");
            var parser = new Parser();
            var syntax = parser.Parse(source);
            Console.WriteLine(syntax);
        }
    }
}