# IP-Info

IP-Info is a C# console application that provides information about IP addresses. It allows users to look up information for a specific IP address or check their own public IP address.

## How to Use

### Cloning the Repository:

1. Clone the repository:
   ```sh
   A)
   git clone https://github.com/jetblack90/IP-Info.git

   B)
   cd IP-Info
   ```

### Building and Running the Application:

2. Build the project:
   ```sh
   dotnet build
   ```

3. Run the application:
   - To check your own public IP address:
     ```sh
     dotnet run -myip
     ```

   - To look up information for a specific IP address:
     ```sh
     dotnet run [IP_ADDRESS]
     ```

4. Get help commands:
   - To check the help commands:
     ```sh
     dotnet run -h or --help
     ```

### Additional Notes:

- Ensure that the .NET Core SDK is installed on your system.
- Make sure any external dependencies are properly installed.
- The application should be cross-platform compatible.
