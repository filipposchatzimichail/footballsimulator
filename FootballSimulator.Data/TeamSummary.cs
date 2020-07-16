namespace FootballSimulator.Data
{
  public class TeamSummary
  {
    /// <summary>
    /// The team name.
    /// </summary>
    public string Team { get; set; }

    /// <summary>
    /// Total games won.
    /// </summary>
    public int Wins { get; set; }

    /// <summary>
    /// Total draws.
    /// </summary>
    public int Draws { get; set; }

    /// <summary>
    /// Total games lost.
    /// </summary>
    public int Losses { get; set; }

    /// <summary>
    /// Total goals for.
    /// </summary>
    public int GoalsFor { get; set; }

    /// <summary>
    /// Total goals against.
    /// </summary>
    public int GoalsAgainst { get; set; }   

    /// <summary>
    /// Total tournament points.
    /// </summary>
    public int TotalPoints { get { return this.Wins * 3 + this.Draws; } }

    public override string ToString()
    {
      return $"{this.Team}: {this.Wins} wins, {this.Draws} draws, {this.Losses} losses, {this.GoalsFor} goalsFor, {this.GoalsAgainst} goalsAgainst, {this.TotalPoints} totalpoints";
    }
  }
}
