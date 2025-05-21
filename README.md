# Password Generator Web Application

This is a simple web application that generates secure passwords based on user-defined criteria. The application allows users to specify the length of the password and whether to include uppercase letters, numbers, and special characters.

## Features

- Generate passwords with customizable settings
- User-friendly interface
- Secure password generation

## Project Structure

```
PasswordGeneratorWebApp
├── PasswordGeneratorWebApp
│   ├── Controllers
│   │   └── PasswordController.cs
│   ├── Models
│   │   └── PasswordModel.cs
│   ├── Views
│   │   └── Home
│   │       └── Index.cshtml
│   ├── wwwroot
│   └── Startup.cs
├── PasswordGeneratorWebApp.Tests
│   └── PasswordControllerTests.cs
├── .github
│   └── workflows
│       ├── ci.yml
│       └── cd.yml
├── PasswordGeneratorWebApp.sln
└── README.md
```

## Getting Started

### Prerequisites

- .NET Framework installed on your machine
- A code editor (e.g., Visual Studio Code)
- Access to DigitalOcean for deployment

### Installation

1. Clone the repository:
   ```
   git clone <repository-url>
   ```
2. Navigate to the project directory:
   ```
   cd PasswordGeneratorWebApp
   ```
3. Restore the dependencies:
   ```
   dotnet restore
   ```

### Running the Application

To run the application locally, use the following command:
```
dotnet run --project PasswordGeneratorWebApp
```
Open your web browser and navigate to `http://localhost:5000` to access the application.

### Running Tests

To run the unit tests, navigate to the test project directory and execute:
```
dotnet test
```

## Deployment

### Continuous Integration

The CI pipeline is defined in `.github/workflows/ci.yml`. It automatically builds and tests the application whenever changes are pushed to the repository.

### Continuous Deployment

The CD pipeline is defined in `.github/workflows/cd.yml`. It deploys the application to DigitalOcean after successful builds in the CI pipeline.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.