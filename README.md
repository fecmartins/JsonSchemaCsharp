# JsonSchemaCsharp

JsonSchemaCsharp is a C# library and demo application for validating JSON data against a predefined schema. The project includes a library for schema validation and a demo application that demonstrates how to use the library.

## Project Structure

```
JsonSchemaCsharp/
├── .gitignore
├── .idea/
├── .vscode/
├── JsonSchemaCsharp.Demo
│   ├── Data/
│   │   ├── input.json
│   │   ├── schema.json
│   ├── JsonSchemaCsharp.Demo.csproj
│   ├── Program.cs
├── JsonSchemaCsharp.Library
│   ├── Models/
│   │   ├── Schema.cs
│   │   ├── ValidationResult.cs
│   ├── JsonSchemaCsharp.Library.csproj
│   ├── Validator.cs
├── JsonSchemaCsharp.Library.Tests
│   ├── JsonSchemaCsharp.Library.Tests.csproj
│   ├── ValidatorTests.cs
├── JsonSchemaCsharp.sln
├── README.md
```

## Getting Started

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio Code](https://code.visualstudio.com/) or any other C# compatible IDE

### Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/fecmartins/JsonSchemaCsharp.git
    cd JsonSchemaCsharp
    ```

2. Restore the dependencies:
    ```sh
    dotnet restore
    ```

### Building the Project

To build the project, run the following command:
```sh
dotnet build
```

### Running the Demo

To run the demo application, use the following command:
```sh
dotnet run --project JsonSchemaCsharp.Demo/JsonSchemaCsharp.Demo.csproj
```

### Running the Tests

To run the unit tests, use the following command:
```sh
dotnet test
```

## Usage

The demo application reads JSON data from input.json and validates it against the schema defined in schema.json. The validation results are printed to the console.

### Example

Sample schema.json:
```json
{
    "name": {
      "length": 50,
      "mandatory": true
    },
    "age": {
      "length": 3,
      "mandatory": false
    },
    "email": {
      "length": 100,
      "mandatory": true
    }
}
```

Sample input.json:
```json
[
  {
    "name": "John Doe",
    "email": "john.doe@example.com",
    "age": 30
  },
  {
    "name": "Ze Test",
    "email": "ze.test@example.com",
    "age": 50000
  }
]
```

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any improvements or bug fixes.

## License

This project is licensed under the MIT License. See the LICENSE file for details.
```