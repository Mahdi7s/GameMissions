namespace GameMissions.Web.Endpoints.PlayerEndpoints;

public class GetByDeviceAndGameIdResponse
{
  public GetByDeviceAndGameIdResponse(PlayerRecord playerRecord)
  {
    PlayerRecord = playerRecord;
  }

  public PlayerRecord PlayerRecord { get; set; }
}
