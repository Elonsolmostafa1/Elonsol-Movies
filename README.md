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

![Actors](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/6721aa5c-9b06-436c-a5be-2ec5f8e223af)

![Actor Delete](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/f8048e7c-9e7e-4b98-b842-1054f87eb2cf)

![Actor Update](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/5b4d51fb-9865-4a17-9835-d3a5565a715e)

![Actor Details](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/c94e658c-4025-40aa-aacf-d8a4d17d1a6c)



- **Movie Management**

![Movies](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/103e7d1e-8ac3-471a-ac8b-1fdf354e0334)

![Movies Details](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/f7dda0da-4265-4538-ad15-76dabd39fbd4)

![Movie Update](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/a2d3db17-e267-4f88-a34b-66cb77f2dc2a)

![Movie Delete](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/de2c1a10-0451-4ca2-927b-f792912b83af)

![Movie Actors](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/82998efd-314f-47af-88d2-2f235833b2d5)

![Movie Actor Add](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/cb8ac43f-e3fb-4d24-a046-cd8a13baaa09)




- **Role Management**

![Roles](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/8d3c517b-72f8-4d3b-98a3-c8e286ef96c9)

![Role Update](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/ab840e43-0bf2-4330-9c5a-9e6aee6c55f3)


### User App

- **Login and Register**
  
![Sign Up](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/8db4cad9-23f9-48f9-9543-d708116f6188)

![Login](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/18e33ee1-139c-4daf-9ae2-7a2c5ba5a2f1)

- **Movie Home**
  
![Home 1](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/652f07c6-8fc2-4859-95aa-f2db577b5ebc)

![Home 2](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/973a01b6-5fb9-414a-a8ca-535ba9a6db5f)



- **Movie Details**
  
![Details 1](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/71412c60-f8c7-49f1-9dfe-57dd92279c54)

![Details 2](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/cd0353f2-5b32-4677-bae7-56c30352478f)

![Details 3](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/898911d7-edf5-4c24-9906-d7b213058604)



- **Actor Directory**
  
![Actors](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/9c90d245-ec2b-4997-b893-3a73f326d687)


- **Actor Details**
  
![ActorDetail1](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/2783ebf4-c846-4ff8-a54a-9f28c0a6bcbd)

![ActorDetail2](https://github.com/Elonsolmostafa1/Elonsol-Movies/assets/62807830/089721c8-4b5e-40d5-8e30-2b929606e565)


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
