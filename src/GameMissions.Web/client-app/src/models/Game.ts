import Mission from './Mission';

export default interface Game {
  id: number;
  title: string;
  packageName: string;
  nextRewardedVideoTimeout: number; // seconds
  rewardedVideoReward: number; // seconds
  intrestitialPerLevel: number;
  description?: string;

  missions?: Mission[];
}
