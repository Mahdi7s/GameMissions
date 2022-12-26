namespace GameMissions.Web.Endpoints.PlayerEndpoints;

public class DeletePlayerRequest
{
  public const string Route = "/Players/{PlayerId:int}";

  public static string BuildRoute(int playerId) => Route.Replace("{PlayerId:int}", playerId.ToString());

  public int PlayerId { get; set; }
}
