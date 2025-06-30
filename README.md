# PasswordGeneratorWebApp

A modern ASP.NET Core (.NET 9) web application for generating secure passwords with customizable options.

## Features

- Generate passwords with configurable length and character sets (uppercase, lowercase, numbers, symbols)
- Password strength indicator
- Copy to clipboard functionality
- Responsive Bootstrap UI
- Error handling for invalid options

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- (Optional) [AWS CLI](https://aws.amazon.com/cli/) and [Elastic Beanstalk CLI](https://docs.aws.amazon.com/elasticbeanstalk/latest/dg/eb-cli3-install.html) for deployment

### Running Locally

1. Clone the repository:
   ```sh
   git clone https://github.com/ViRaJiN009/PasswordGeneratorWebApp.git
   cd PasswordGeneratorWebApp
   ```

2. Restore dependencies:
   ```sh
   dotnet restore PasswordGeneratorWebApp/PasswordGeneratorWebApp.csproj
   ```

3. Run the application:
   ```sh
   dotnet run --project PasswordGeneratorWebApp/PasswordGeneratorWebApp.csproj
   ```
   The app will be available at `https://localhost:5001` or `http://localhost:5000`.

### Running Tests

```sh
dotnet test
```

## Deployment to AWS Elastic Beanstalk

This project is ready for deployment to AWS Elastic Beanstalk using GitHub Actions.

### Steps

1. **Configure AWS Elastic Beanstalk:**
   - Create an application and environment in the AWS Elastic Beanstalk console.

2. **Set GitHub Secrets:**
   - `AWS_ACCESS_KEY_ID` and `AWS_SECRET_ACCESS_KEY` in repository settings.

3. **Update Workflow:**
   - The `.github/workflows/cd.yml` file is set up for CI/CD deployment.
   - Update `application_name` and `environment_name` in `cd.yml` to match your AWS setup.

4. **Push to Main:**
   - On every push to the `main` branch, the workflow will build, publish, zip, and deploy your app.

5. **Access Your App:**
   - After deployment, visit the environment URL shown in the AWS Elastic Beanstalk console.

### Notes

- The app automatically binds to the port provided by AWS (`PORT` environment variable).
- Make sure your published output contains all necessary files (including `.runtimeconfig.json`).

## Project Structure

```
PasswordGeneratorWebApp/
  ├── Controllers/
  ├── Models/
  ├── Views/
  ├── wwwroot/
  ├── Program.cs
  ├── Startup.cs
  └── PasswordGeneratorWebApp.csproj
PasswordGeneratorWebApp.Tests/
.github/
  └── workflows/
      └── cd.yml
README.md
```

## License

MIT