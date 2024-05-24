# IP-Info

IP-Info is a C# console application that provides information about IP addresses. It allows users to look up information for a specific IP address or check their own public IP address.

## Download and install Microsoft packages and .NET SDK.

1. Install the Microsoft packages:

   A)
   ```sh
   wget https://packages.microsoft.com/config/debian/12/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
   ```
   B)
   ```sh
   sudo dpkg -i packages-microsoft-prod.deb
   ```
   C)
   ```sh
   rm packages-microsoft-prod.deb
   ```

3. Installing the .NET SDK:
   ```sh
   sudo apt-get install -y dotnet-sdk-8.0
   ```

## How to Use

### Cloning the Repository:

1. Clone the repository:

   A)
   ```sh
   git clone https://github.com/jetblack90/IP-Info.git
   ```

   B)
   ```sh
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
