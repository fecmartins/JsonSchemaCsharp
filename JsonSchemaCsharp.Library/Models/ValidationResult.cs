namespace JsonSchemaCsharp;

// Define the Output
public class ValidationResult
{
    public bool IsValid { get; set; }
    public List<ErrorMessage> ErrorMessages { get; set; }
}

public class ErrorMessage
{
    public string ErrorType { get; set; }
    public string ErrorMessage { get; set; }
    public string Field { get; set; }
}