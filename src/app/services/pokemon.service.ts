import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PokemonService {
  private pokemonImgUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/";
  private imgType = "png"

  constructor(private http: HttpClient) { }

  getPokemonImg(id: number): Observable<Blob> {
    return this.http.get<Blob>(`${this.pokemonImgUrl}${id}.${this.imgType}`);
  }
}
