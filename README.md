# UserRegistrationAPI

### Functionality:
User Registration: Users can register by providing their first name, last name, username, and password. The password is hashed before being stored in the database.
User Login: Registered users can log in by providing their username and password. The system validates the credentials and provides access if they match.
User Update: Users can update their profile, including their name and password, with proper validation of the old password.
Password Hashing: The password is securely hashed using a hashing utility before storage to protect sensitive user data.

### Technologies Used:
ASP.NET Core Web API: A modern, cross-platform framework used to build the Web API.
Entity Framework Core: ORM used for database interactions and entity management.
SQL Server: Database used to store user data securely.
Swagger: Used for API documentation and testing the API endpoints in an interactive manner.
Postman: API testing and endpoint validation.
ASP.NET Core Middleware: For handling exceptions such as AppException and NotFoundException with appropriate status codes (400 and 404).

### Key Features:
Secure password hashing (bcrypt or similar hashing algorithms).
Exception handling with custom exception middleware.
Asynchronous programming using async and await to improve API responsiveness.
