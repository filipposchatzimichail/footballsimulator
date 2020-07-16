using System.Collections.Generic;

namespace FootballSimulator.Data
{
  /// <summary>
  /// The settings the simulator uses.
  /// </summary>
  public class SimulatorSettings
  {
    /// <summary>
    /// A list of teams that participate in the simulator. 
    /// </summary>
    public List<Team> Teams { get; set; }

    /// <summary>
    /// The physchological advantage when teams play home. (Currently expressed as additional goals).
    /// </summary>
    public int PsychologicalAdvantage { get; set; }
  }
}