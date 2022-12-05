import mock from './mock';
import Game from '../models/Game';
import {
  randomCreatedDate,
  randomUpdatedDate,
  randomId,
  randomInt,
  randomUserName,
  randomName, randomTraderName
} from '@mui/x-data-grid-generator';

let games: Game[] = [];

for (let i = 0; i < 20; i++) {
  games.push({
    id: i + 1,
    title: `Game_${randomTraderName()}`,
    packageName: `Package.${randomUserName()}`,
    rewardedVideoReward: randomInt(25, 100),
    nextRewardedVideoTimeout: randomInt(60, 120),
    intrestitialPerLevel: randomInt(1, 5)
  });
}

mock.onGet('/api/games').reply(config => {
  return [200, games];
});
