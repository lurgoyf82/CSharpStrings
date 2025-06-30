# CSharpStrings

CSharpStrings is an ASP.NET Core API that implements the String Calculator kata.
Two alternative solutions are provided:

- **develop_soluzione_A** – a more monolithic approach.
- **develop_soluzione_B** – the preferred implementation that resolves all seven kata steps through a single service configured by options.

The application is continuously deployed to a VM and publicly reachable at
[https://strings.raphp.net](https://strings.raphp.net).  There is no AWS deployment.

## Running the project

1. Install the [.NET SDK 9](https://dotnet.microsoft.com/).
2. Start the API:

   ```bash
   dotnet run --project src/CSharpStrings/CSharpStrings.Api
   ```

   By default the API listens on `https://localhost:5001` and exposes Swagger UI at `/swagger`.

## API usage

Each kata step has its own endpoint under `Strings/` (e.g.
`POST /Strings/GetStepOne`).
Send a JSON body containing the numbers string:

```json
{
  "numbers": "0,1,2"
}
```

The response returns the computed sum and any error message.
See `STRINGS.md` for the detailed requirements of all seven steps.

## Deployment

Deployment is handled by the workflow in `.github/workflows/deploy.yml`.
Every push to the `master` branch publishes the application and deploys it via
SSH to the VM, then restarts the service.  The live instance is available at
<https://strings.raphp.net>.

## Example TDD with xUnit

The repository includes a small xUnit project under `tests/`.
A sample test for the first step looks like this:

```csharp
using CSharpStrings.Domain.Entities;
using CSharpStrings.Infrastructure.Services;
using Xunit;

public class CalculatorServiceTests
{
    [Theory]
    [InlineData("", 0)]
    [InlineData("1", 1)]
    [InlineData("1,2", 3)]
    public void StepOne_SumsBasicNumbers(string input, int expected)
    {
        var options = new CalculatorOptions
        {
            Delimiters = new List<string> { "," },
            AllowMultipleDelimeters = false,
            MaxDelimeterSize = 0,
            MaxNumbers = 3,
            AllowNegatives = true,
            IgnoreAboveOrEqual = 0
        };

        var service = new CalculatorService();
        var result = service.CalculateSum(input, options);

        Assert.Equal(expected, result);
    }
}
```

## License

This project is released under the MIT License. See `LICENSE.txt` for details.
