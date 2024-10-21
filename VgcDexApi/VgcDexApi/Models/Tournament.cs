namespace VgcDexApi.Models
{
  public enum Division
  {
    Juniors,
    Seniors,
    Masters
  }

  public enum Platform
  {
    Switch,
    Simulator,
  }

  public enum Regulation
  {
    RegulationA,
    RegulationB,
    RegulationC,
    RegulationD,
    RegulationE,
    RegulationF,
    RegulationG,
    RegulationH,
    Custom
  }

  public enum Type
  {
    Official,
    Unofficial
  }

  public class Tournament
  {
    public int Id { get; set; }
    public int TournamentId { get; set; }
    public Division Division { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public Platform Platform { get; set; }
    public int Players { get; set; }
    public Regulation Regulation { get; set; }
    public Type Type { get; set; }
  }
}
