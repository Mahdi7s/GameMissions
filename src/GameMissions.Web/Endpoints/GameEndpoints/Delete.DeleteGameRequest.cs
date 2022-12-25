namespace GameMissions.Web.Endpoints.GameEndpoints;

public class DeleteGameRequest
{
  public const string Route = "/Games/{GameId:int}";
  public static string BuildRoute(int gameId) => Route.Replace("{GameId:int}", gameId.ToString());

  public int GameId { get; set; }
}
