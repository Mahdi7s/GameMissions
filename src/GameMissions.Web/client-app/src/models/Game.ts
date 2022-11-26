import Mission from './Mission';

export default interface Game {
  Title: string;
  PackageName: string;
  NextRewardedVideoTimeout: number; // seconds
  RewardedVideoReward: number; // seconds
  IntrestitialPerLevel: number;
  Description: string;

  Missions: Mission[];
}
