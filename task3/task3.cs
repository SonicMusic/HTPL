using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace task3
{
    class task3
    {
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Usage: program.exe values.json tests.json report.json");
                return;
            }

            string valuesPath = args[0];
            string testsPath = args[1];
            string reportPath = args[2];

            Dictionary<string, int> testValues = LoadTestValues(valuesPath);
            if (testValues == null)
            {
                Console.WriteLine("Error loading test values");
                return;
            }

            TestStructure tests = LoadTests(testsPath);
            if (tests == null)
            {
                Console.WriteLine("Error loading test structure");
                return;
            }

            UpdateTestValues(tests, testValues);

            SaveReport(tests, reportPath);

            Console.WriteLine("Report generated successfully");
        }

        static Dictionary<string, int> LoadTestValues(string path)
        {
            try
            {
                string json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<Dictionary<string, int>>(json);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error loading test values: {e.Message}");
                return null;
            }
        }

        static TestStructure LoadTests(string path)
        {
            try
            {
                string json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<TestStructure>(json);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error loading test structure: {e.Message}");
                return null;
            }
        }

        static void UpdateTestValues(TestStructure tests, Dictionary<string, int> testValues)
        {
            foreach (TestItem test in tests.tests)
            {
                if (testValues.ContainsKey(test.id))
                {
                    test.value = testValues[test.id];
                }
            }
        }

        static void SaveReport(TestStructure tests, string path)
        {
            try
            {
                string json = JsonConvert.SerializeObject(tests, Formatting.Indented);
                File.WriteAllText(path, json);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error saving report: {e.Message}");
            }
        }
    }

    class TestStructure
    {
        public List<TestItem> tests { get; set; }
    }

    class TestItem
    {
        public string id { get; set; }
        public int value { get; set; }
        public List<TestItem> children { get; set; }
    }
}