# ShowMyTime

ShowMyTime is a web application built using ASP.NET Core 5.0. It uses external API http://worldtimeapi.org/ to show current time for predefined time zone.
Time zone can be changed in ShowMyTimeConfigurationFile.json in UserTimeZone parameter.

When WorldTimeApi returns 503 error ShowMyTime displays information 'API service is currently unavailable'.
When UserTimeZone parameter is badly configured, ShowMyTime sends request for all available time zones in WorldTimeApi and displays it. Path for this request is also configurable.


To run this project you need to install .NET 5.0 and Angular Client. 

Configuration:
  + Go to /ShowMyTime.API directory and execute 'dotnet restore' command,
  + then go to /ShowMyTime.SPA directory and execute 'npm install' command,
  + define your time zone in ShowMyTimeConfigurationFile.json.

Run:
  + Go to /ShowMyTime.API directory and execute 'dotnet run' command,
  + then go to /ShowMyTime.SPA directory and execute 'ng serve' command.
.NET project would run on http://localhost:5000 and Angular project on http://localhost:4200/.

