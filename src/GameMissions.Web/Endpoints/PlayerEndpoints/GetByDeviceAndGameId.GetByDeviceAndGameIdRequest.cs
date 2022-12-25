namespace GameMissions.Web.Endpoints.PlayerEndpoints;

public class GetByDeviceAndGameIdRequest
{
  public const string Route = "/Players/{DeviceId:string}/{GameId:int}";
  public static string BuildRoute(string deviceId, int gameId) => Route.Replace("{DeviceId:string}", deviceId).Replace("{GameId:int}", gameId.ToString());

  public string DeviceId { get; set; }
  public int GameId { get; set; }
}
