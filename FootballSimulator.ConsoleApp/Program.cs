using FootballSimulator.API;
using FootballSimulator.Data;
using FootballSimulator.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballSimulator.ConsoleApp
{
  class Program
  {
    private static IFootballSimulator _simulator;

    static void Main(string[] args)
    {
      while (true)
      {
        DisplayText("======= Simulation started. =======");
        DisplayText("======= Simulating fixtures. =======");

        _simulator = new FootballSimulatorService();
        var fixtures = _simulator.SimulateFixtures();

        DisplayFixtures(fixtures);

        Console.WriteLine("Press Enter to simulate all games: ");
        Console.ReadLine();
        Console.Clear();

        DisplayText("======= Simulating games. =======");

        var games = _simulator.SimulateGames(fixtures).ToList();

        DisplayGames(games);

        DisplayText("======= Displaying Summaries. =======");

        var summaries = _simulator.GenerateSummaries(games);

        DisplaySummaries(summaries);
        Console.WriteLine("");

        DisplayText("======= Simulation finished. Press Esc to exit or any other key to simulate again. =======");

        var input = Console.ReadKey();
        if (input.Key == ConsoleKey.Escape)
        {
          break;
        }
        Console.Clear();
      }
    }

    static void DisplayText(string text)
    {
      Console.WriteLine(text);
      Console.WriteLine("");
    }

    static void DisplayFixtures(IEnumerable<Fixture> fixtures)
    {
      IEnumerable<IGrouping<int, Fixture>> query = fixtures.GroupBy(p => p.Round);
      foreach (var group in query)
      {
        Console.WriteLine($"Round {group.Key}:");

        foreach (var fixture in group)
        {
          Console.WriteLine(fixture);
        }

        Console.WriteLine();
      }
    }

    static void DisplayGames(IEnumerable<Game> games)
    {
      IEnumerable<IGrouping<int, Game>> query = games.GroupBy(p => p.Fixture.Round);
      foreach (var group in query)
      {
        Console.WriteLine($"Round {group.Key}:");

        foreach (var match in group)
        {
          Console.WriteLine($"{match.Fixture} ({match.Result})");
        }

        Console.WriteLine();
      }
    }

    static void DisplaySummaries(IEnumerable<TeamSummary> summaries)
    {      
      foreach (var teamSummary in summaries)
      {
        Console.WriteLine(teamSummary);
      }
    }
  }
}
