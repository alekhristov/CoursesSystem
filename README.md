# Project name: CoursesSystem

[CoursesSystem Application](http://coursessystem.azurewebsites.net/)

## Project Description

This is a **ASP.NET Core MVC application**  where users can see all available courses and register/unregister for them.

The application have:
* **public part** (accessible without authentication)
* **private part** (available for registered users)

### Public Part

The **public part** of the application is **visible without authentication**. This includes:

- Home page - default ASP.NET Core page
- Login page
- Register page
- About Us page - basic information about the author

### Private Part (Users only)

**Registered users** have private part in the web application accessible after **successful login**. They are able to:

- See all available courses and register/unregister for them
- See all registered and not registered courses
- Edit courses
- Add new courses
- Delete existing courses

## Additional application info:
- The application is based on **ASP.NET Core MVC**, **MS SQL Server** as database back-end.
- Used IDE - **Visual Studio 2017**.
- Used **Entity Framework Core** to access database.
- Used **Repository pattern** and **Service Layer**.
- Used the default dependency container and **Automapper**.
- Used AJAX calls
- Created one extension method
- Written more than **60 Unit Tests** for the logic and controllers
- Applied **error handling** and **data validation** to avoid crashes when invalid data is entered (both client-side and server-side).
- Applied **CI pipeline** in the git server repository for code integrity verification in two stages: build stage and running tests stage.
- Deployed on Azure