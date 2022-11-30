import Game from "./Game";

export default interface Mission
{
  id: number;
  gameId: number;
  game?: Game;
  missionType: number;
  completionLevel: number;
  title: string;
  order: number;
  reward: number;
  description?: string;
}
