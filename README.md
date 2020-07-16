# Football Simulator

## A C# .NET Core solution that simulates a football tournament.

#### The solution consists of two self executing applications (a Console app and a Blazor app). It features separation of concerns and unit testing while following the SOLID and KISS principles. 

The solution currrently uses 4 teams (Italy, Spain, Portugal and Netherlands) but is highly configurable (see settings.json) and well tested by tournaments consisting of 100 teams.

The projects in this solution include:

* FootballSimulator.API
* FootballSimulator.Blazor
* FootballSimulator.ConsoleApp
* FootballSimulator.Data
* FootballSimulator.Services
* FootballSimulator.Tests

#### Other features
* Simulating the tournament fixtures.
* Simulating the tournament games (results).
* Simulating team strengths (over time the strongest teams appear on top of the rankings).    
* Simulating additional team strengths (i.e. phychological advantages when a team plays home).
* Presenting the final results by order of 

  * Final points
  * Total wins
  * Total draws
  * Total losses
  * Goals for
  * Goals against




