# Movie App

**Movie App** is an ASP.NET MVC project that follows a 3-tier architecture, designed for managing movies, actors, and user accounts. This application features two presentation layers: the **Admin Dashboard** and the **User App**, each serving different roles and functions.

## Table of Contents

- [Features](#features)
- [Screenshots](#screenshots)
- [Videos](#videos)
- [Project Structure](#project-structure)
- [Database](#database)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Contact](#contact)

## Features

### Admin Dashboard

- **User Management**:
  - Create, update, delete, and view user accounts.
  - Manage user roles (Admin/User).

- **Actor Management**:
  - Add, update, delete, and view actors.
  - Assign actors to movies and remove them from movies.

- **Movie Management**:
  - Create, update, delete, and view movie details.
  - View movie actors and their details.
  - Assign actors to movies and remove them from movies.

- **Role Management**:
  - Create, update, delete, and view roles.
  - Assign roles to users.

### User App

- **User Account**:
  - Users can view and update their profiles.
  - Profile includes name, email, password, phone number, and profile picture.

- **Movie Catalog**:
  - View a catalog of available movies.
  - Click on a movie to view its details, including name, publish year, genre, director, writer, trailer link, actors, and overview.

- **Actor Directory**:
  - Explore a list of actors in the app.
  - Click on an actor to view their details and associated movies.

## Screenshots

### Admin Dashboard

- **User Management**

![Login](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/eaee247b-9ee6-4290-bb88-0542f21accc3)

![Users GetAll](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/df4e22cd-493e-4506-8926-3b35607397fb)

![User Details](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/510475ce-fe74-43fc-8757-0b1ed28caf1b)

![User Delete](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/e62f974e-d602-461b-aebb-36b34fce60bb)

![User Update](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/379a96b7-82a1-4cb8-a30f-54137aebc77e)


- **Actor Management**

![Actors](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/64579dc5-f40c-4d2e-b164-ffe147c3238c)

![Actor Details](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/88e9d268-ad6b-4350-91d8-9163cfe07b28)

![Actor Update](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/8075d37b-99c0-4e75-88ea-d3f4dc86f161)

![Actor Delete](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/96b98288-9498-4e8b-bf31-bde85a951691)

![Movie Actors](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/94912d63-38e2-4a9d-8b91-3bf17cde0127)

![Movie Actor Add](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/b2e1bea1-6db0-43b1-b2c8-c6bf97329c07)



- **Movie Management**

![Movies](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/2b7b82a7-c3c3-426f-93a9-fbc4d5db58cd)

![Movies Details](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/c086ab09-f1d8-4e14-9b71-73b0f22ac009)

![Movie Update](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/2f566ed4-fc87-4999-a2cf-d4830ed34116)

![Movie Delete](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/c1b2c93e-a681-4b71-93be-a49fc165cf60)





- **Role Management**

![Roles](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/a9bafac7-a949-4e90-bcb0-2629948cce10)

![Role Update](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/c0e85306-9a2c-4e0e-9020-4e97a36709b1)

### User App

- **Login and Register**
  
![Sign Up](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/f4868e3b-2829-4028-87e9-072c4eebd3a9)

![Login](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/ac2e5efa-24ec-4b01-a026-af449a4f269a)

- **Movie Home**
  
![Home 1](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/fd726775-8ab5-45a0-958a-b53b40c280ab)

![Home 2](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/ff24c9f1-08d5-480e-8d04-352c7cb50e15)



- **Movie Details**
  
![Details 1](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/bf6f7149-adc6-4be7-8994-8534a80ffff5)

![Details 2](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/29d68ca4-d2a8-41dd-9408-7b88b97a7845)

![Details 3](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/9e8d5faf-96f4-4355-ab1e-c6fdafb68b2e)




- **Actor Directory**
  
![Actors](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/0cab0dd3-69f8-48f0-8a3a-d91ee4af1ad9)


- **Actor Details**
  
![ActorDetail1](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/fea39bf9-43e0-40a7-bb8e-89f90b785879)

![ActorDetail2](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/064108cd-1d53-4382-b47a-6bbbf87b1f6b)



## Videos

- **Admin Dashboard Demo**: [Watch Video](https://youtube.com/your-video-link)
- **User App Demo**: [Watch Video](https://youtube.com/your-video-link)

## Project Structure

The project adheres to a 3-tier architecture:

- **Data Access Layer (DAL)**:
  - Manages data access, including database context, models, and migrations.
  - Key models include `ApplicationUser`, `Movie`, and `Actor`.

- **Business Logic Layer (BLL)**:
  - Implements the Generic Repository design pattern and Unit of Work for efficient data manipulation.
  - Houses business logic, interfaces, and repositories.

- **Presentation Layers**:
  - **Admin Dashboard**: Accessible via `http://your-app/admin`.
  - **User App**: Accessible by standard users and administrators.

## Database

- **Database**: Microsoft SQL Server
- **Models**: `ApplicationUser`, `Movie`, `Actor`
- **Migrations**: Manage database schema changes efficiently.

## Technologies Used

- **ASP.NET MVC**: The core framework for building the web application.
- **Entity Framework Core**: Handles data access and database operations.
- **Bootstrap**: Ensures a responsive and visually appealing user interface.
- **jQuery**: Enhances user interaction.
- **Identity**: Manages authentication and authorization.
- **Dependency Injection**: Enhances code maintainability and scalability.

## Getting Started

To run the application locally, follow these steps:

1. Clone this repository to your local machine:

   ```shell
   git clone https://github.com/your-username/movie-app.git](https://github.com/Elonsolmostafa1/Elonsol-Movies.git)
   ```

2. Open the solution in Visual Studio or your preferred IDE.

3. Configure the database connection string in the `appsettings.json` file:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "your-connection-string"
   }
   ```

4. Run the application. Default admin login credentials are provided within the application.

## Usage

- **Admin Dashboard**:
  - Access the admin dashboard at `http://localhost:port

localhost:port/admin`.
  - Log in with admin credentials.
  - Utilize the dashboard to manage users, actors, movies, and roles.

- **User App**:
  - Users can log in to the User App using their credentials.
  - Explore movies, view movie details, and update their profiles.


## Contact

For any questions or feedback, please contact [Mostafa Ahmed](mailto:mostafaahmed21121997@gmail.com).
