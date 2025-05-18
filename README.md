# http://pharaogo.runasp.net/

## Project Overview

Pharaogo is an ASP.NET Core 8.0 MVC project designed to facilitate tourists to book rooms in hotels and purchase tickets to Egyptian museums, ensuring they enjoy a seamless trip to Egypt.

## Features

* User authentication and role management
* Hotel room search, filtering, and booking
* Museum ticket browsing and reservation
* Payment integration with popular gateways
* Responsive UI optimized for desktop and mobile devices
* Administrative dashboard for managing hotels, museums, and bookings

## Prerequisites

* .NET 8.0 SDK
* Microsoft SQL Server (or another supported SQL database)

## Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/MohamedRamadan32325/Pharaogo.git
   ```

2. Restore dependencies and build the project:

   ```bash
   dotnet restore
   dotnet build
   ```

## Configuration

1. Copy and rename the environment file:

   ```bash
   cp appsettings.Development.json.example appsettings.Development.json
   ```

2. Update the connection strings and API keys in `appsettings.Development.json`:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR_SERVER;Database=PharaogoDB;Trusted_Connection=True;"
     },
     "PaymentGateway": {
       "ApiKey": "YOUR_PAYMENT_API_KEY"
     }
   }
   ```

## Usage

1. Run database migrations:

   ```bash
   dotnet ef database update
   ```

2. Start the development server:

   ```bash
   dotnet run
   ```

3. Open your browser and navigate to `https://localhost:5001`.

## Project Structure

```
Pharaogo-master/
├── Controllers/         # MVC controllers
├── Models/              # Entity and ViewModel classes
├── Views/               # Razor views
├── Data/                # EF Core DbContext and migrations
├── wwwroot/             # Static assets (CSS, JS, images)
├── appsettings.json     # Application configuration
└── Program.cs           # App startup and middleware configuration

```

## Architecture

Pharaogo follows a traditional ASP.NET Core MVC architecture with:

* **Controllers** handling HTTP requests and responses
* **Models** representing domain entities and ViewModels
* **Razor Views** for rendering HTML
* **Entity Framework Core** for data access and migrations
* **Dependency Injection** for service management

## Testing

Run unit and integration tests using the .NET CLI:

```bash
dotnet test
```

## Contributing

1. Fork the repository.
2. Create a feature branch (`git checkout -b feature/YourFeature`).
3. Commit your changes with descriptive messages.
4. Push to your fork and open a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

