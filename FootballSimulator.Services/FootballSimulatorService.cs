using FootballSimulator.API;
using FootballSimulator.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FootballSimulator.Services
{
  public class FootballSimulatorService : IFootballSimulator
  {
    private SimulatorSettings _settings;
    private RoundRobinGenerator _rRGenerator;

    public SimulatorSettings Settings
    {
      get
      {
        if (_settings == null)
        {
          _settings = JsonConvert.DeserializeObject<SimulatorSettings>(File.ReadAllText("settings.json"));
          Random rnd = new Random();

          _settings.Teams = _settings.Teams.OrderBy(x => rnd.Next()).ToList();
        }

        return _settings;
      }
      set
      {
        _settings = value;
      }
    }   

    public IEnumerable<Fixture> SimulateFixtures()
    {
      if (_rRGenerator == null)
        _rRGenerator = new RoundRobinGenerator();

      _settings = null;

      var result = new List<Fixture>();

      var fixtures = _rRGenerator.GenerateRoundRobin(this.Settings.Teams.Count);

      for (var round = 0; round <= fixtures.GetUpperBound(1); round++)
      {
        for (var team = 0; team <= fixtures.GetUpperBound(0); team++)
        {
          if (team < fixtures[team, round])
          {
            result.Add(new Fixture { 
              Round = round + 1,
              HomeTeam = this.Settings.Teams[team].Name,
              AwayTeam = this.Settings.Teams[fixtures[team, round]].Name 
            });
          }
        }
      }

      return result;
    }

    public IEnumerable<Game> SimulateGames(IEnumerable<Fixture> fixtures)
    {
      var result = fixtures.Select(f => new Game()
      {
        Fixture = f
      }).ToArray();

      foreach (var r in result)
      {
        var homeTeam = this.Settings.Teams.Single(p => p.Name == r.Fixture.HomeTeam);
        var awayTeam = this.Settings.Teams.Single(p => p.Name == r.Fixture.AwayTeam);

        r.Result = new ScoreResult {
          HomeTeamScore = GetRandomScore(homeTeam.Strength + this.Settings.PsychologicalAdvantage),
          AwayTeamScore = GetRandomScore(awayTeam.Strength)
        };
      }

      return result;
    }

    public IEnumerable<TeamSummary> GenerateSummaries(IEnumerable<Game> games)
    {
      var result = this.Settings.Teams.Select(p => new TeamSummary() { Team = p.Name }).ToList();

      foreach (var game in games)
      {
        var homeTeamResult = result.Single(p => p.Team == game.Fixture.HomeTeam);
        var awayTeamResult = result.Single(p => p.Team == game.Fixture.AwayTeam);

        if (game.Result.HomeTeamScore > game.Result.AwayTeamScore)
        {
          homeTeamResult.Wins++;
          awayTeamResult.Losses++;
        }
        else if (game.Result.HomeTeamScore < game.Result.AwayTeamScore)
        {
          homeTeamResult.Losses++;
          awayTeamResult.Wins++;
        }
        else
        {
          homeTeamResult.Draws++;
          awayTeamResult.Draws++;
        }

        AssignGoals(homeTeamResult, game.Result.HomeTeamScore, game.Result.AwayTeamScore);
        AssignGoals(awayTeamResult, game.Result.AwayTeamScore, game.Result.HomeTeamScore);
      }

      var orderedSummaries = result.OrderByDescending(p => p.TotalPoints).ThenByDescending(p => p.GoalsFor).ThenBy(p => p.GoalsAgainst);

      return orderedSummaries;
    }
    public bool AllTeamsHaveStrengths()
    {
      foreach (var team in this.Settings.Teams)
      {
        if (team.Strength < 1)
          return false;
      }

      return true;
    }

    private void AssignGoals(TeamSummary teamSummary, int goalsFor, int goalsAgainst)
    {
      teamSummary.GoalsFor += goalsFor;
      teamSummary.GoalsAgainst += goalsAgainst;
    }

    private int GetRandomScore(int teamStrength)
    {
      Random r = new Random(Guid.NewGuid().GetHashCode());

      return r.Next(0, teamStrength);
    }    
  }
}