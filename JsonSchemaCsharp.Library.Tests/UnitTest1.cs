using System.Collections.Generic;
using Xunit;
using JsonSchemaCsharp.Core;

public class ValidatorTests
{
    [Fact]
    public void Validate_ShouldReturnValid_WhenInputIsCorrect()
    {
        var schema = new Schema
        {
            Fields = new Dictionary<string, FieldValidationRules>
            {
                { "name", new FieldValidationRules { Length = 50, Mandatory = true } }
            }
        };

        var input = new Dictionary<string, object>
        {
            { "name", "John Doe" }
        };

        var validator = new Validator(schema);
        var result = validator.Validate(input);

        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validate_ShouldReturnInvalid_WhenMandatoryFieldIsMissing()
    {
        var schema = new Schema
        {
            Fields = new Dictionary<string, FieldValidationRules>
            {
                { "name", new FieldValidationRules { Length = 50, Mandatory = true } }
            }
        };

        var input = new Dictionary<string, object>();

        var validator = new Validator(schema);
        var result = validator.Validate(input);

        Assert.False(result.IsValid);
    }
}