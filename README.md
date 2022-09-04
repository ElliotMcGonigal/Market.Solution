# Pierre's Market
#### Project by Elliot McGonigal
## Description
This application will allow a registered user to add treats and flavors in a many to many relationship. It will also allow any unregistered user to view them.
## Technologies Used
* C#
* MSTest
* .NET 5.0
* ASP.NET Core MVC
* Html
* MySql Workbench
## Setup
1. Set up your environment. I use GitBash with VSCode for this. You'll also want MySql Workbench installed.
2. Install .NET https://dotnet.microsoft.com/en-us/download/dotnet/5.0 get .NET SDK 5.0.408
3. Clone this repo by entering into GitBash 'git clone https://github.com/ElliotMcGonigal/Market.Solution'
4. In the terminal, navigate to the file you just cloned.
5. Create an 'appsettings.json' file in the Market directory. It should look like the following: 
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=[YOUR DATABASE NAME HERE];uid=[YOUR USER ID HERE];pwd=[YOUR PASSWORD HERE];"
  }
}
6. Have mysql server running and open mysql workbench
7. Enter 'dotnet build' into the terminal
8. Enter 'dotnet run' into the terminal
9. Enter 'dotnet ef database update' into the terminal
10. Now open a browser and go to http://localhost:5000/ and explore!
## Known Bugs
No known bugs
## License
GNU gpl 3.0 view LICENSE for more details