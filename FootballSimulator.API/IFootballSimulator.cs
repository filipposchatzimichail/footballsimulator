using FootballSimulator.Data;
using System.Collections.Generic;

namespace FootballSimulator.API
{
  public interface IFootballSimulator
  {
    /// <summary>
    /// The settings the simulator uses.
    /// </summary>
    public SimulatorSettings Settings { get; set; }

    /// <summary>
    /// Simulates game fixtures.
    /// </summary>
    /// <returns>A collection of fixtures.</returns>
    public IEnumerable<Fixture> SimulateFixtures();

    /// <summary>
    /// Simulates games.
    /// </summary>
    /// <param name="fixtures">A collection of fixtures.</param>
    /// <returns>A collection of completed games.</returns>
    public IEnumerable<Game> SimulateGames(IEnumerable<Fixture> fixtures);

    /// <summary>
    /// Generates summaries.
    /// </summary>
    /// <param name="games">A collection of games.</param>
    /// <returns>A collection of odered results. (Descending points, descending goals for and ascending goals against).</returns>
    public IEnumerable<TeamSummary> GenerateSummaries(IEnumerable<Game> games);

    /// <summary>
    /// Checks if all teams have their own strengths.
    /// </summary>
    /// <returns>True if all teams have their own strengths, false otherwise.</returns>
    public bool AllTeamsHaveStrengths();
  }
}
