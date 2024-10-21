using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VgcDexApi.Models;
using VgcDexApi.Services;

namespace VgcDexApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TournamentController : ControllerBase
  {
    private readonly TournamentDbContext _context;
    private readonly TournamentService _tournamentService;

    public TournamentController(TournamentDbContext context, TournamentService tournamentService)
    {
      _context = context;
      _tournamentService = tournamentService;
    }

    [HttpPost]
    public async Task<IActionResult> AddTournaments([FromBody] List<Tournament> tournamentList)
    {
      if (tournamentList == null || tournamentList.Count == 0)
      {
        return BadRequest("No tournament data found...");
      }
      _context.Tournaments.AddRange(tournamentList);

      await _context.SaveChangesAsync();

      return Ok();
    }

    [HttpGet("fetch-and-insert")]
    public async Task<IActionResult> FetchAndSaveTournaments()
    {
      List<Tournament> tournamentList = await _tournamentService.GetTournamentsAsync();

      if (tournamentList == null || tournamentList.Count == 0)
      {
        return BadRequest("No tournament data found...");
      }
      _context.Tournaments.AddRange(tournamentList);
      await _context.SaveChangesAsync();

      return Ok(new { message = "Tournaments fetched successfully", count = tournamentList.Count });
    }

    [HttpPatch("update-tournaments")]
    public async Task<IActionResult> UpdateTournaments()
    {
      List<Tournament> tournamentList = await _tournamentService.GetTournamentsAsync();

      if (tournamentList == null || tournamentList.Count == 0)
      {
        return BadRequest("No tournament data found...");
      }

      foreach (var tournament in tournamentList)
      {
        var existingTournament = await _context.Tournaments.FirstOrDefaultAsync(t => t.Id == tournament.Id);

        if (existingTournament != null)
        {
          existingTournament.Name = tournament.Name;
        }
      }
      await _context.SaveChangesAsync();

      return Ok(new { message = "Tournaments fetched successfully", count = tournamentList.Count });
    }

    [HttpGet]
    public async Task<IActionResult> GetTournamentList()
    {
      List<Tournament> tournaments = await _context.Tournaments.ToListAsync();
      return Ok(tournaments);
    }
  }
}
