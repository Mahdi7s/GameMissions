import Game from "./Game";

export default interface Mission
{
  GameId: number;
  Game: Game;
  MissionType: number;
  CompletionLevel: number;
  Title: string;
  Order: number;
  Reward: number;
  Description: string;
}
