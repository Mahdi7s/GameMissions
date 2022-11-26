import Device from "./Device";
import Game from "./Game";
import Mission from "./Mission";

export default interface Player
{
  Device: Device;
  DeviceId: string;
  LastConnectedIP: string;
  LocaleCode: string;
  GameId: number;
  Game: Game;
  Level: number;
  LastAdWatch: Date;
  ClaimedMissions: Mission[];
}
