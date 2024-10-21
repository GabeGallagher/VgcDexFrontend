import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Tournament } from '../interfaces/tournament.model';

@Injectable({
  providedIn: 'root',
})
export class TournamentService {
  private tournamentUrl = 'https://localhost:7229/api/Tournament';
  private tournamentDetailUrl = 'https://labmaus-website-b7a5f5f01a05.herokuapp.com/api/tournaments';
  private language = '?language=en';

  constructor(private http: HttpClient) {}

  getTournaments(): Observable<Tournament[]> {
    return this.http.get<Tournament[]>(`${this.tournamentUrl}`);
  }

  getTournamentDetails(tournamentId: number): Observable<Tournament> {
    return this.http.get<Tournament>(`${this.tournamentDetailUrl}/${tournamentId}${this.language}`);
  }
}
