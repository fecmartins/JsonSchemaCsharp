using System;
using System.Collections.Generic;
using Xunit;
using JsonSchemaCsharp.Library;

public class ValidatorTests
{
    [Fact]
    public void Validate_ShouldReturnValid_WhenInputIsCorrect()
    {
        // Arrange
        var schema = new Schema
        {
            Fields = new Dictionary<string, FieldValidationRules>
            {
                { "name", new FieldValidationRules { Length = 50, Mandatory = true } },
                { "email", new FieldValidationRules { Length = 100, Mandatory = true } },
                { "age", new FieldValidationRules { Mandatory = false } }
            }
        };

        var input = new Dictionary<string, object>
        {
            { "name", "John Doe" },
            { "email", "john.doe@example.com" },
            { "age", 30 }
        };

        var validator = new Validator(schema);

        // Act
        var result = validator.Validate(input);

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.ErrorMessages);
    }

    [Fact]
    public void Validate_ShouldReturnInvalid_WhenMandatoryFieldIsMissing()
    {
        // Arrange
        var schema = new Schema
        {
            Fields = new Dictionary<string, FieldValidationRules>
            {
                { "name", new FieldValidationRules { Length = 50, Mandatory = true } }
            }
        };

        var input = new Dictionary<string, object>();

        var validator = new Validator(schema);

        // Act
        var result = validator.Validate(input);

        // Assert
        Assert.False(result.IsValid);
        Assert.Single(result.ErrorMessages);
        Assert.Equal("MandatoryError", result.ErrorMessages[0].ErrorType);
    }

    [Fact]
    public void Validate_ShouldReturnInvalid_WhenFieldExceedsMaxLength()
    {
        // Arrange
        var schema = new Schema
        {
            Fields = new Dictionary<string, FieldValidationRules>
            {
                { "name", new FieldValidationRules { Length = 5, Mandatory = true } }
            }
        };

        var input = new Dictionary<string, object>
        {
            { "name", "John Doe" } // Length is 8, which exceeds the maximum length of 5
        };

        var validator = new Validator(schema);

        // Act
        var result = validator.Validate(input);

        // Assert
        Assert.False(result.IsValid);
        Assert.Single(result.ErrorMessages);
        Assert.Equal("LengthError", result.ErrorMessages[0].ErrorType);
    }

    [Fact]
    public void Validate_ShouldReturnValid_WhenNonMandatoryFieldIsMissing()
    {
        // Arrange
        var schema = new Schema
        {
            Fields = new Dictionary<string, FieldValidationRules>
            {
                { "name", new FieldValidationRules { Length = 50, Mandatory = true } },
                { "email", new FieldValidationRules { Length = 100, Mandatory = false } }
            }
        };

        var input = new Dictionary<string, object>
        {
            { "name", "John Doe" }
        };

        var validator = new Validator(schema);

        // Act
        var result = validator.Validate(input);

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.ErrorMessages);
    }

    [Fact]
    public void Validate_ShouldReturnInvalid_WhenInputIsEmpty()
    {
        // Arrange
        var schema = new Schema
        {
            Fields = new Dictionary<string, FieldValidationRules>
            {
                { "name", new FieldValidationRules { Length = 50, Mandatory = true } }
            }
        };

        var input = new Dictionary<string, object>();

        var validator = new Validator(schema);

        // Act
        var result = validator.Validate(input);

        // Assert
        Assert.False(result.IsValid);
        Assert.Single(result.ErrorMessages);
        Assert.Equal("MandatoryError", result.ErrorMessages[0].ErrorType);
    }
}