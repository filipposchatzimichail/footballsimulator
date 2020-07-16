using FootballSimulator.Data;
using FootballSimulator.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace FootballSimulator.Tests
{
  [TestFixture]
  public class FootballSimulatorTests
  {
    private SimulatorSettings _settings;
    
    private Team _team1;
    private Team _team2;
    private Team _team3;
    private Team _team4;

    [SetUp]
    public void Setup()
    {
      _team1 = new Team { Name = "Italy", Strength = 1 };
      _team2 = new Team { Name = "Spain", Strength = 1 };
      _team3 = new Team { Name = "Portugal", Strength = 2 };
      _team4 = new Team { Name = "Netherlands", Strength = 3 };

      _settings = new SimulatorSettings()
      {
        Teams = new List<Data.Team>()
        {
          _team1, _team2, _team3, _team4
        }, 
        PsychologicalAdvantage = 1
      };
    }

    [Test]
    public void Simulator_Should_Generate_Three_Rounds_For_FourTeams()
    {
      //Arrange
      var expected = 3;

      //Act
      var simulator = new FootballSimulator.Services.FootballSimulatorService() { Settings = _settings };
      var actual = simulator.SimulateFixtures().GroupBy(p => p.Round).Count();

      //Assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Simulator_Should_Generate_Six_Games_For_FourTeams()
    {
      //Arrange
      var expected = 6;

      //Act
      var simulator = new FootballSimulatorService() { Settings = _settings };
      var actual = simulator.SimulateFixtures().Count();

      //Assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Simulator_Should_Check_That_All_Teams_Have_Strengths()
    {
      //Arrange
      var expected = true;

      //Act
      var simulator = new FootballSimulatorService() { Settings = _settings };
      var actual = simulator.AllTeamsHaveStrengths();

      //Assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Simulator_Should_Simulate_Games()
    {
      //Arrange
      var simulator = new FootballSimulatorService() { Settings = _settings };
      var fixtures = simulator.SimulateFixtures();
      var expected = fixtures.Count();

      //Act
      var actual = simulator.SimulateGames(fixtures).Count();

      //Assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Simulator_Should_Generate_Summaries()
    {
      //Arrange
      var expected = _settings.Teams.Count();
      var simulator = new FootballSimulatorService() { Settings = _settings };
      var fixtures = simulator.SimulateFixtures();
      var games = simulator.SimulateGames(fixtures);

      //Act
      var actual = simulator.GenerateSummaries(games).Count();

      //Assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Simulator_Should_Generate_Summaries_By_Descending_Total_Points()
    {
      //Arrange     
      var simulator = new FootballSimulatorService() { Settings = _settings };
      var fixtures = simulator.SimulateFixtures();
      var games = simulator.SimulateGames(fixtures);
      var actual = simulator.GenerateSummaries(games);

      //Act
      var expected = actual.OrderByDescending(p => p.TotalPoints).ThenByDescending(p => p.GoalsFor).ThenBy(p => p.GoalsAgainst);

      //Assert
      Assert.IsTrue(expected.SequenceEqual(actual));
    }
    [Test]
    public void Simulator_Should_Generate_Summaries_By_Descending_Total_Points_And_Descending_Goals_For()
    {
      //Arrange     
      var simulator = new FootballSimulatorService() { Settings = _settings };
      var fixtures = simulator.SimulateFixtures();
      var games = simulator.SimulateGames(fixtures);
      var actual = simulator.GenerateSummaries(games);

      //Act
      var expected = actual.OrderByDescending(p => p.TotalPoints).ThenByDescending(p => p.GoalsFor).ThenBy(p => p.GoalsAgainst);

      //Assert
      Assert.IsTrue(expected.SequenceEqual(actual));     
    }
    [Test]
    public void Simulator_Should_Generate_Summaries_By_Descending_Total_Points_And_Descending_Goals_For_And_Ascending_Goals_Against()
    {
      //Arrange     
      var simulator = new FootballSimulatorService() { Settings = _settings };
      var fixtures = simulator.SimulateFixtures();
      var games = simulator.SimulateGames(fixtures);
      var actual = simulator.GenerateSummaries(games);

      //Act
      var expected = actual.OrderByDescending(p => p.TotalPoints).ThenByDescending(p => p.GoalsFor).ThenBy(p => p.GoalsAgainst);

      //Assert
      Assert.IsTrue(expected.SequenceEqual(actual));
    }
  }
}