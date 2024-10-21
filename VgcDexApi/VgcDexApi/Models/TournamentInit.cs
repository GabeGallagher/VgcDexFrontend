using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text.Json.Serialization;

namespace VgcDexApi.Models
{
  public class TournamentInit
  {
    [JsonPropertyName("date")]
    public string Date { get; set; }

    [JsonPropertyName("division")]
    public string Division { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("platform")]
    public string Platform { get; set; }

    [JsonPropertyName("players")]
    public int Players { get; set; }

    [JsonPropertyName("regulation")]
    public string Regulation { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
  }
}
