# CSharpStrings

CSharpStrings is an ASP.NET Core API that implements the String Calculator.
Two alternative solutions are provided:

- **develop_soluzione_A** – a more monolithic approach.
- **develop_soluzione_B** – the preferred implementation that resolves all seven steps through a single service configured by options.

The application is continuously deployed to a VM and publicly reachable at
[https://strings.raphp.net](https://strings.raphp.net).

## Running the project

1. Install the [.NET SDK 9](https://dotnet.microsoft.com/).
2. Start the API with IIS Express option on Visual Studio

   By default the API listens on `https://localhost:44310` and exposes Swagger UI at `https://localhost:44310/swagger`.

## API usage

Each step has its own endpoint.
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

https://strings.raphp.net will automatically redirect on swagger if open in the browser

While for postman's testing use these endpoints:

https://strings.raphp.net/GetStepOne
https://strings.raphp.net/GetStepTwo
https://strings.raphp.net/GetStepThree
https://strings.raphp.net/GetStepFour
https://strings.raphp.net/GetStepFive
https://strings.raphp.net/GetStepSix
https://strings.raphp.net/GetStepSeven



## License

This project is released under the MIT License. See `LICENSE.txt` for details.
