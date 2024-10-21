using System.Text.Json;
using VgcDexApi.Models;

namespace VgcDexApi.Services
{
  public class TournamentService
  {
    private readonly string _tournamentListUrl;
    private readonly HttpClient _httpClient;

    public TournamentService(IConfiguration configuration, HttpClient httpClient)
    {
      _httpClient = httpClient;
      _tournamentListUrl = configuration["TournamentsListUrl"];
    }

    public async Task<List<Tournament>> GetTournamentsAsync()
    {
      HttpResponseMessage response = await _httpClient.GetAsync(_tournamentListUrl);
      response.EnsureSuccessStatusCode();
      string jsonResponse = await response.Content.ReadAsStringAsync();

      List<Tournament> tournamentList = new List<Tournament>();

      List<TournamentInit> tournamentInitList = JsonSerializer.Deserialize<List<TournamentInit>>(jsonResponse);

      if (tournamentInitList != null || tournamentInitList.Count > 0)
      {
        foreach (TournamentInit tournamentInit in tournamentInitList)
        {
          Tournament tournament = new Tournament {
            TournamentId = tournamentInit.Id,
            Division = ParseDivision(tournamentInit.Division),
            Name = tournamentInit.Name,
            Date = DateTime.Parse(tournamentInit.Date),
            Platform = ParsePlatform(tournamentInit.Platform),
            Players = tournamentInit.Players,
            Regulation = ParseRegulation(tournamentInit.Regulation),
            Type = ParseType(tournamentInit.Type)
          };
          tournamentList.Add(tournament);
        } 
      }
      else
      {
        throw new Exception("Tournament list was not found");
      }

      return tournamentList ?? new List<Tournament>();
    }
    private Division ParseDivision(string division)
    {
      return division switch
      {
        "Juniors" => Division.Juniors,
        "juniors" => Division.Juniors,
        "Junior" => Division.Juniors,
        "junior" => Division.Juniors,
        "Seniors" => Division.Seniors,
        "seniors" => Division.Seniors,
        "Senior" => Division.Seniors,
        "senior" => Division.Seniors,
        "Masters" => Division.Masters,
        "Master" => Division.Masters,
        "masters" => Division.Masters,
        "master" => Division.Masters,
        _ => throw new ArgumentException($"Invalid division: {division}")
      };
    }

    private Platform ParsePlatform(string platform)
    {
      return platform switch
      {
        "Simulator" => Platform.Simulator,
        "Nintendo Switch" => Platform.Switch,
        _ => throw new ArgumentException($"Invalid platform: {platform}")
      };
    }

    private Regulation ParseRegulation(string regulation)
    {
      return regulation switch
      {
        "Scarlet & Violet - Regulation A" => Regulation.RegulationA,
        "Scarlet & Violet - Regulation B" => Regulation.RegulationB,
        "Scarlet & Violet - Regulation C" => Regulation.RegulationC,
        "Scarlet & Violet - Regulation D" => Regulation.RegulationD,
        "Scarlet & Violet - Regulation E" => Regulation.RegulationE,
        "Scarlet & Violet - Regulation F" => Regulation.RegulationF,
        "Scarlet & Violet - Regulation G" => Regulation.RegulationG,
        "Scarlet & Violet - Regulation H" => Regulation.RegulationH,
        "Custom" => Regulation.Custom,
        "Custom format" => Regulation.Custom,
        "custom" => Regulation.Custom,
        _ => throw new ArgumentException($"Invalid regulation: {regulation}")
      };
    }

    private VgcDexApi.Models.Type ParseType(string type)
    {
      return type switch
      {
        "Official" => VgcDexApi.Models.Type.Official,
        "official" => VgcDexApi.Models.Type.Official,
        "Unofficial" => VgcDexApi.Models.Type.Unofficial,
        "unofficial" => VgcDexApi.Models.Type.Unofficial,
        _ => throw new ArgumentException($"Invalid type: {type}")
      };
    }
  }
}
