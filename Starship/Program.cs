using System;
using Newtonsoft.Json;
using Starship.Rockstar;

namespace Starship {
    class Program {
        static void Main(string[] args) {
            var source = System.IO.File.ReadAllText("test.rock");
            Console.WriteLine("======== SOURCE ========");
            Console.WriteLine(source);
            var parser = new Parser();
            var syntax = parser.Parse(source);
            Console.WriteLine("======== SYNTAX ========");
            Console.WriteLine(syntax);
            Console.WriteLine("======== OUTPUT ========");
            var e = new Rockstar.Interpreter.RSEnvironment();
            var result = e.Evaluate(syntax);
            if (result.Returnable) {
                Console.WriteLine("======== RESULT ========");
                Console.WriteLine(result.Value);
            }
        }
    }
}