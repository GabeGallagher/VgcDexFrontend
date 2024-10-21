import { Component, OnInit } from '@angular/core';
import { TournamentService } from '../../services/tournament.service';
import { Regulation, Tournament } from '../../interfaces/tournament.model';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent implements OnInit {
  tournamentList: Tournament[] = [];
  tournamentDisplay: Tournament[] = [];
  displayCount: number = 25;
  displayIncrease: number = 25;
  selectedRegulation: Regulation | null = null;
  filterForm: FormGroup;

  regulations = [
    { key: 0, label: Regulation.A },
    { key: 1, label: Regulation.B },
    { key: 2, label: Regulation.C },
    { key: 3, label: Regulation.D },
    { key: 4, label: Regulation.E },
    { key: 5, label: Regulation.F },
    { key: 6, label: Regulation.G },
    { key: 7, label: Regulation.H },
    { key: 8, label: Regulation.Custom },
  ];

  constructor(
    private tournamentService: TournamentService,
    private fb: FormBuilder,
    private router: Router
  ) {
    this.filterForm = this.fb.group({
      regulation: [null],
      minPlayers: [''],
      maxPlayers: [''],
    });
  }

  ngOnInit(): void {
    this.getTournaments();
  }

  getTournaments(): void {
    this.tournamentService.getTournaments().subscribe((data: Tournament[]) => {
      this.tournamentList = data;
      this.showTournaments(this.displayCount, this.tournamentList);
    });
  }

  showTournaments(displayCount: number, tournamentList: Tournament[]) {
    this.tournamentDisplay = tournamentList.slice(0, displayCount);
  }

  showMore(): void {
    this.displayCount += this.displayIncrease;
    let filteredTournament = this.applyFilters(false);
    filteredTournament = filteredTournament.slice(0, this.displayCount);
    this.showTournaments(this.displayCount, filteredTournament);
  }

  showLess(): void {
    this.displayCount -= this.displayIncrease * 2;
    this.showMore();
  }

  getRegulation(regulation: number): string {
    if (regulation === Regulation.Custom) return 'Custom';
    return `Scarlet & Violet Regulation ${Regulation[regulation]}`;
  }

  applyFilters(loadOnReturn: boolean = true): Tournament[] {
    let { regulation, minPlayers, maxPlayers } = this.filterForm.value;
    if (minPlayers == '') minPlayers = 0;
    if (maxPlayers == '') maxPlayers = 0;

    let filteredTournament = this.tournamentList.filter((tournament) => {
      const matchesReg = !regulation || tournament.regulation === regulation;
      if (minPlayers > maxPlayers && maxPlayers != 0) minPlayers = maxPlayers;
      const matchesMinPlayers = !minPlayers || tournament.players >= minPlayers;
      const matchesMaxPlayers = !maxPlayers || tournament.players <= maxPlayers;

      return matchesReg && matchesMinPlayers && matchesMaxPlayers;
    });
    if (loadOnReturn === true)
      this.showTournaments(this.displayCount, filteredTournament);
    return filteredTournament;
  }

  clearFilters(): void {
    this.filterForm.reset();
    this.showTournaments(this.displayCount, this.tournamentList);
  }

  viewTournament(tournamentId: number): void {
    this.router.navigate(['/tournament', tournamentId]);
  }
}
