import Player from "./Player";


export default interface Device {
  id: string;
  players?: Player[];
}
