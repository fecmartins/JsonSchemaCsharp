namespace JsonSchemaCsharp;
// Create classes to represent the schema and input data.
public class Schema
{
    public Dictionary<string, FieldValidationRules> Fields { get; set; }
}

public class FieldValidationRules
{
    public int Length { get; set; }
    public bool Mandatory { get; set; }
}