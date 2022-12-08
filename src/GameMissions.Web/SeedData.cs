
using GameMissions.Core.ContributorAggregate;
using GameMissions.Core.GameAggregate;
using GameMissions.Core.PlayerAggregate;
using GameMissions.Core.ProjectAggregate;
using GameMissions.Core.Services;
using GameMissions.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GameMissions.Web;

public static class SeedData
{
  public static async Task Initialize(IServiceProvider serviceProvider)
  {
    using (var dbContext = new AppDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
    {
      // Look for any Game records.
      if (dbContext.Games.Any())
      {
        return;   // DB has been seeded
      }

      await PopulateTestGameData(dbContext);
    }
  }

  public static async Task PopulateTestGameData(AppDbContext dbContext)
  {
    List<Game> games = new();
    for(int i = 0; i < 10; i++)
    {
      var game = new Game($"Game#{i}", $"Game_#{i}.Package.Name");

      dbContext.Add(game);
      await dbContext.SaveChangesAsync();

      for (int j = 0; j < 10; j++)
      {
        var referralReward = 50 + (i + 1) * 25;
        var referralMission = new Mission(game.Id, (int)MissionType.Referral, 1, $"Invite a friend", 5, referralReward,
          $"Invite a friend to game {game.Title} and get {referralReward} coins as the reward.");

        game.AddMission(referralMission);
      }

      games.Add(game);
    }

    for (var i = 0; i < 10; i++)
    {
      var device = new Device($"Device#{i}");
      var game = games[Random.Shared.Next(0, games.Count)];
      var player = new Player(device.Id, game.Id, Random.Shared.Next(1, 500), DateTime.Now);
      device.AddPlayer(player);


    }
  }
}
