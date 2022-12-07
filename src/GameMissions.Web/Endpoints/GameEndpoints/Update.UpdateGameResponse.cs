namespace GameMissions.Web.Endpoints.GameEndpoints;

public class UpdateGameResponse
{
  public UpdateGameResponse(GameRecord gameRecord)
  {
    GameRecord = gameRecord;
  }

  public GameRecord GameRecord { get; set; }
}
