# CinemaPlus - Diploma Project

## Table of Contents
- [Project Overview](#project-overview)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Installation and Setup](#installation-and-setup)
- [How to Run the Project](#how-to-run-the-project)
- [Contributing](#contributing)
- [License](#license)

## Project Overview
CinemaPlus is a diploma project developed as part of the Step IT Academy curriculum. This project simulates a complete cinema ticket booking system, allowing users to browse movies, select seats, and make payments.

## Features
- Browse available movies and showtimes.
- Select seats and book tickets.
- Manage user accounts and bookings.
- Admin panel for managing movies and schedules.
  
## Technologies Used
- **Backend**: C# (.NET)
- **Frontend**: HTML, CSS, JavaScript
- **Database**: SQL Server
- **Others**: Entity Framework, LINQ

## Installation and Setup

### Prerequisites:
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
- .NET SDK
- SQL Server

### Steps:
1. Clone the repository:
    ```bash
    git clone https://github.com/aykhan019/CinemaPlus-Project.git
    ```
2. Open the `CinemaPlus.sln` file in Visual Studio 2022.
3. Restore NuGet packages:
   - Go to `Tools` -> `NuGet Package Manager` -> `Manage NuGet Packages for Solution`.
   - Click on **Restore** to install the dependencies.

4. Setup the database:
   - Update the connection string in `appsettings.json` file located in the `Cinema.UI` project folder.
   - Run the migrations to create the database.
   ```bash
   Update-Database

### How to Run the Project
1. Once the solution is open in Visual Studio, set Cinema.UI as the startup project.
2. Build the solution by pressing Ctrl + Shift + B.
3. Run the project using the IIS Express or by pressing F5.
4. The project should launch in your default browser with the homepage for CinemaPlus.


Here is the content for the README.md file in markdown format:

md
Copy code
# CinemaPlus - Diploma Project

![CinemaPlus Logo](logo-url)

## Table of Contents
- [Project Overview](#project-overview)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Installation and Setup](#installation-and-setup)
- [How to Run the Project](#how-to-run-the-project)
- [Contributing](#contributing)
- [License](#license)

## Project Overview
CinemaPlus is a diploma project developed as part of the Step IT Academy curriculum. This project simulates a complete cinema ticket booking system, allowing users to browse movies, select seats, and make payments.

## Features
- Browse available movies and showtimes.
- Select seats and book tickets.
- Manage user accounts and bookings.
- Admin panel for managing movies and schedules.
  
## Technologies Used
- **Backend**: C# (.NET)
- **Frontend**: HTML, CSS, JavaScript
- **Database**: SQL Server
- **Others**: Entity Framework, LINQ

## Installation and Setup

### Prerequisites:
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
- .NET SDK
- SQL Server

### Steps:
1. Clone the repository:
    ```bash
    git clone https://github.com/aykhan019/CinemaPlus-Project.git
    ```
2. Open the `CinemaPlus.sln` file in Visual Studio 2022.
3. Restore NuGet packages:
   - Go to `Tools` -> `NuGet Package Manager` -> `Manage NuGet Packages for Solution`.
   - Click on **Restore** to install the dependencies.

4. Setup the database:
   - Update the connection string in `appsettings.json` file located in the `Cinema.UI` project folder.
   - Run the migrations to create the database.
   ```bash
   Update-Database
How to Run the Project
Once the solution is open in Visual Studio, set Cinema.UI as the startup project.
Build the solution by pressing Ctrl + Shift + B.
Run the project using the IIS Express or by pressing F5.
The project should launch in your default browser with the homepage for CinemaPlus.

### Contributing
Contributions are welcome! If you have any suggestions or improvements, feel free to submit a pull request.

## License
This project is licensed under the MIT License. See the LICENSE file for more details.
