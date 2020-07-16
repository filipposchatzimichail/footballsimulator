namespace FootballSimulator.Data
{
  public class Team
  {
    /// <summary>
    /// The team name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The team strength. (Currently expressed as the maximum number of goals the team usually scores per game) 
    /// </summary>
    public int Strength { get; set; }

    public override string ToString()
    {
      return $"{this.Name} has strength {this.Strength}";
    }
  }
}