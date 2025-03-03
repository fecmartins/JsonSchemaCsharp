using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using JsonSchemaCsharp.Library;

namespace JsonSchemaCsharp.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Get the path to the data folder
                string dataFolder = Path.Combine(Directory.GetCurrentDirectory(), "data");

                // Read input.json
                string inputFilePath = Path.Combine(dataFolder, "input.json");
                string inputJson = File.ReadAllText(inputFilePath);

                // Deserialize JSON array into a list of dictionaries
                var inputs = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(inputJson);

                // Check if inputs is null or empty
                if (inputs == null || inputs.Count == 0)
                {
                    Console.WriteLine("Error: Input JSON is null, invalid, or empty.");
                    return;
                }

                // Read schema.json
                string schemaFilePath = Path.Combine(dataFolder, "schema.json");
                string schemaJson = File.ReadAllText(schemaFilePath);
                var schema = JsonConvert.DeserializeObject<Schema>(schemaJson);

                // Check if schema is null
                if (schema == null)
                {
                    Console.WriteLine("Error: Schema JSON is null or invalid.");
                    return;
                }

                // Validate each input in the list
                var validator = new Validator(schema);
                var validationResults = new List<ValidationResult>();

                for (int i = 0; i < inputs.Count; i++)
                {
                    Console.WriteLine($"Validating input {i + 1}:");
                    var input = inputs[i];

                    var result = validator.Validate(input);
                    validationResults.Add(result);

                    // Output the result
                    Console.WriteLine($"Validation Result: {(result.IsValid ? "Valid" : "Invalid")}");
                    if (!result.IsValid)
                    {
                        foreach (var error in result.ErrorMessages)
                        {
                            Console.WriteLine($"{error.ErrorType}: {error.Message}");
                        }
                    }
                }

                // Serialize the validation results to JSON and write to output.json
                string outputFilePath = Path.Combine(dataFolder, "output.json");
                string jsonOutput = JsonConvert.SerializeObject(validationResults, Formatting.Indented);
                File.WriteAllText(outputFilePath, jsonOutput);

                Console.WriteLine($"Validation results written to {outputFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}