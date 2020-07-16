namespace FootballSimulator.Data
{
  /// <summary>
  /// The game result 
  /// </summary>
  public class Game
  {
    /// <summary>
    /// The game fixture.
    /// </summary>
    public Fixture Fixture { get; set; }

    /// <summary>
    /// The game result.
    /// </summary>
    public ScoreResult Result { get; set; }
  }
}