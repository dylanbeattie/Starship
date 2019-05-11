using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Starship.Rockstar.Interpreter;
using Xunit;
using Xunit.Sdk;

namespace Starship.Tests {
    public class Fixtures {
        const string fixtures = "../../../../../Rockstar/tests/fixtures/";
        public static IEnumerable<object[]> TestFiles =>
            System.IO.Directory.EnumerateFiles(fixtures, "*.rock", SearchOption.AllDirectories)
            .Select(path => new[] { path.Replace(fixtures, "") });


        [Theory]
        [MemberData(nameof(TestFiles))]
        public void RunTest(string filePath) {
            string source, target = String.Empty, actual;
            var stdout = new StringBuilder();
            var env = new RSEnvironment();
            env.Output = s => stdout.AppendLine((s ?? "(null)").ToString());
            source = File.ReadAllText(fixtures + filePath);
            if (File.Exists(fixtures + filePath + ".out")) target = File.ReadAllText(fixtures + filePath + ".out");
            actual = "";
            try {
                var parser = new Parser();
                var syntax = parser.Parse(source);
                var result = env.Evaluate(syntax);
                actual = stdout.ToString();
            } catch (Exception ex) {
                actual = ex.Message;
            }
            Assert.Equal(target, actual);
        }
    }
}

