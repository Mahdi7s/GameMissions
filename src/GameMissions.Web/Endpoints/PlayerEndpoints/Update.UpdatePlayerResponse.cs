namespace GameMissions.Web.Endpoints.PlayerEndpoints;

public class UpdatePlayerResponse
{
  public UpdatePlayerResponse(PlayerRecord playerRecord)
  {
    PlayerRecord = playerRecord;
  }

  public PlayerRecord PlayerRecord { get; }
}
