namespace FootballSimulator.Data
{
  /// <summary>
  /// The fixture between two teams.
  /// </summary>
  public class Fixture
  {
    /// <summary>
    /// The home team name.
    /// </summary>
    public string HomeTeam { get; set; }

    /// <summary>
    /// The away team name.
    /// </summary>
    public string AwayTeam { get; set; }

    /// <summary>
    /// The fixture round.
    /// </summary>
    public int Round { get; set; }

    public override string ToString()
    {
      return $"{this.HomeTeam} vs {this.AwayTeam}";
    }
  }
}