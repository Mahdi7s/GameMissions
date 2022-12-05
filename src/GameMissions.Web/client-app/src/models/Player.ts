import Device from "./Device";
import Game from "./Game";
import Mission from "./Mission";

export default interface Player
{
  id: number;
  device?: Device;
  deviceId: string;
  lastConnectedIP: string;
  localeCode: string;
  gameId: number;
  game?: Game;
  level: number;
  lastAdWatch: Date;
  claimedMissions?: Mission[];
}
