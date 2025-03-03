using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using JsonSchemaValidator.Core;
// Reads JSON files
// Use Newtonsoft.Json to read schema.json and input.json.
class Program
{
    static void Main(string[] args)
    {
        var schemaJson = File.ReadAllText("schema.json");
        var inputJson = File.ReadAllText("input.json");

        var schema = JsonConvert.DeserializeObject<Schema>(schemaJson);
        var inputs = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(inputJson);

        var validator = new Validator(schema);
        var results = new List<ValidationResult>();

        foreach (var input in inputs)
        {
            results.Add(validator.Validate(input));
        }

        var outputJson = JsonConvert.SerializeObject(results, Formatting.Indented);
        File.WriteAllText("output.json", outputJson);
    }
}