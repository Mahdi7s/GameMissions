namespace GameMissions.Web.Endpoints.GameEndpoints;

public class DeleteGameRequest
{
  public const string Route = "/Games/{GameId:int}";
  public static string BuildRoute(int projectId) => Route.Replace("{GameId:int}", projectId.ToString());

  public int GameId { get; set; }
}
