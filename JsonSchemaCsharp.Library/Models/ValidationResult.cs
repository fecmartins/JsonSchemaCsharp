namespace JsonSchemaCsharp.Library;

// Define Output
public class ValidationResult
{
    public bool IsValid { get; set; }
    public List<ErrorMessage> ErrorMessages { get; set; } = new List<ErrorMessage>();
}

public class ErrorMessage
{
    public string ErrorType { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public string Field { get; set; } = string.Empty;
}