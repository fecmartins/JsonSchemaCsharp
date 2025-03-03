namespace JsonSchemaCsharp.Library;

public class Validator

    //Create a validator class that takes the schema and input, and performs the validation.

{
    private readonly Schema _schema;
    
    public Validator(Schema schema)
    {
        _schema = schema;
    }

    public ValidationResult Validate(Dictionary<string, object> input)
    {
        var result = new ValidationResult { IsValid = true, ErrorMessages = new List<ErrorMessage>() };

        foreach (var field in _schema.Fields)
        {
            if (field.Value.Mandatory && (!input.ContainsKey(field.Key) || input[field.Key] == null)
            {
                result.IsValid = false;
                result.ErrorMessages.Add(new ErrorMessage
                {
                    ErrorType = "MandatoryError",
                    ErrorMessage = $"Field {field.Key} is mandatory.",
                    Field = field.Key
                });
            }

            if (input.ContainsKey(field.Key) && input[field.Key] is string value && value.Length > field.Value.Length)
            {
                result.IsValid = false;
                result.ErrorMessages.Add(new ErrorMessage
                {
                    ErrorType = "LengthError",
                    ErrorMessage = $"Field {field.Key} exceeds maximum length of {field.Value.Length}.",
                    Field = field.Key
                });
            }
        }

        return result;
    }
}
