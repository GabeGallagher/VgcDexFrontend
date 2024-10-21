import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TournamentService } from '../../services/tournament.service';
import { Tournament } from '../../interfaces/tournament.model';
import { PokemonService } from '../../services/pokemon.service';

@Component({
  selector: 'app-tournament',
  templateUrl: './tournament.component.html',
  styleUrl: './tournament.component.css',
})
export class TournamentComponent {
  tournament: any | undefined;
  teamsDisplay: any[] = [];
  displayCount: number = 16;
  displayMax: number = 16;

  constructor(
    private route: ActivatedRoute,
    private tournamentService: TournamentService,
    private pokemonService: PokemonService
  ) {}

  ngOnInit(): void {
    this.loadTournament(
      Number(this.route.snapshot.paramMap.get('tournamentId'))
    );
  }

  loadTournament(id: number): void {
    this.tournamentService.getTournamentDetails(id).subscribe((data) => {
      this.tournament = data;
      this.showTeams(this.displayCount, this.tournament.teams);
    });
  }

  showTeams(displayCount: number, teams: any): void {
    if (teams.length > 16) {
      this.teamsDisplay = teams.slice(0, displayCount);
    }
    this.teamsDisplay = teams;
  }

  getPokemonImg(id: number): string {
    let pokemonImgUrl = id.toString();
    this.pokemonService.getPokemonImg(id).subscribe((img: Blob) => {
      const objectUrl = URL.createObjectURL(img);
      pokemonImgUrl = objectUrl;
    });
    return pokemonImgUrl;
  }
}
