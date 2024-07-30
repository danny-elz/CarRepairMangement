### CarRepairManagement System

Welcome to the **CarRepairManagement System** repository! This application is a console-based management system designed to handle vehicle, inventory, and repair data for a car repair shop. It allows users to perform CRUD (Create, Read, Update, Delete) operations on vehicles, inventory, and repairs while ensuring data integrity and proper exception handling.

#### Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Setup and Installation](#setup-and-installation)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [Contribution Guidelines](#contribution-guidelines)
- [License](#license)
- [Contact](#contact)

### Features

- **Vehicle Management**: Add, list, update, and delete vehicle records.
- **Inventory Management**: Add, list, update, and delete inventory records.
- **Repair Management**: Add, list, update, and delete repair records.
- **Exception Handling**: Comprehensive error handling to manage invalid data inputs and database constraints.
- **Input Validation**: Ensures all user inputs are valid and formatted correctly.

### Technologies Used

- **.NET Core**: For building the console application.
- **C#**: The primary programming language.
- **ADO.NET**: For database operations.
- **SQL Server LocalDB**: For data storage.
- **Microsoft.Extensions.Configuration**: For configuration management.

### Setup and Installation

#### Prerequisites

- .NET Core SDK
- SQL Server LocalDB

#### Steps

1. **Clone the repository**:
   ```sh
   git clone https://github.com/yourusername/CarRepairManagement.git
   cd CarRepairManagement
   ```

2. **Set up the database**:
   - Ensure the `Database1.mdf` file is placed in the appropriate directory.
   - Update the connection string in `config.json` if necessary.

3. **Build the project**:
   ```sh
   dotnet build
   ```

4. **Run the application**:
   ```sh
   dotnet run
   ```

### Usage

Upon running the application, you will be presented with a menu to manage vehicles, inventory, and repairs. Follow the prompts to perform the desired operations.

#### Example Operations

- **Add a Vehicle**: Follow the prompts to enter vehicle details such as make, model, year, and whether it is new or used.
- **List All Vehicles**: Displays all vehicle records in the database.
- **Update a Vehicle**: Enter the vehicle ID and new details to update an existing vehicle.
- **Delete a Vehicle**: Enter the vehicle ID to delete a vehicle record.

### Project Structure

```
CarRepairManagement/
├── CarRepairManagement/
│   ├── DataAccess/
│   │   └── DatabaseHelper.cs
│   ├── Models/
│   │   ├── Vehicle.cs
│   │   ├── Inventory.cs
│   │   └── Repair.cs
│   ├── Services/
│   │   ├── VehicleService.cs
│   │   ├── InventoryService.cs
│   │   └── RepairService.cs
│   ├── Program.cs
│   ├── config.json
│   └── CarRepairManagement.csproj
├── .gitignore
├── README.md
└── LICENSE
```

### Contribution Guidelines

We welcome contributions to improve this project! Please follow these steps:

1. **Fork the repository**.
2. **Create a new branch** for your feature or bugfix.
3. **Make your changes** and commit them with descriptive messages.
4. **Push to your branch**.
5. **Create a Pull Request**.

### License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

### Contact

For any questions or suggestions, feel free to open an issue or contact the repository owner at your.email@example.com.

---

Thank you for using the CarRepairManagement System! We hope this tool helps you manage your car repair shop efficiently.
