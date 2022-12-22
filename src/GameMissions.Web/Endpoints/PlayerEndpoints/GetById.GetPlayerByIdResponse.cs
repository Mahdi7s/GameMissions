namespace GameMissions.Web.Endpoints.PlayerEndpoints;

public class GetPlayerByIdResponse
{
  public GetPlayerByIdResponse(PlayerRecord playerRecord)
  {
    PlayerRecord = playerRecord;
  }

  public PlayerRecord PlayerRecord { get; set; }
}
