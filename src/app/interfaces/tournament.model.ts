export enum Division {
  Juniors = "Juniors",
  Seniors = "Seniors",
  Masters = "Masters"
}

export enum Platform {
  Switch = "Switch",
  Simulator = "Showdown"
}

export enum Regulation {
  A = 0,
  B = 1,
  C = 2,
  D = 3,
  E = 4,
  F = 5,
  G = 6,
  H = 7,
  Custom = 8
}

export enum Type {
  Official = "Official",
  Unofficial = "Unofficial"
}

export interface Tournament {
  id: number;
  tournamentId: number,
  name: string;
  date: Date;
  division: Division;
  platform: Platform;
  players: number;
  regulation: Regulation;
  type: Type;
}
  