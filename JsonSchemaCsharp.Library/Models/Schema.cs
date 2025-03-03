namespace JsonSchemaCsharp.Library;
// Create classes to represent the schema and input data.
public class Schema
{
    public Dictionary<string, FieldValidationRules> Fields { get; set; } = new Dictionary<string, FieldValidationRules>();
}

public class FieldValidationRules
{
    public int Length { get; set; }
    public bool Mandatory { get; set; }
}