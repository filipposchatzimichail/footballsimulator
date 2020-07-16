namespace FootballSimulator.Data
{
  /// <summary>
  /// The score result.
  /// </summary>
  public class ScoreResult
  {
    /// <summary>
    /// The home team score.
    /// </summary>
    public int HomeTeamScore { get; set; }

    /// <summary>
    /// The away team score.
    /// </summary>
    public int AwayTeamScore { get; set; }

    public override string ToString()
    {
      return $"{this.HomeTeamScore}-{this.AwayTeamScore}";
    }
  }
}
