namespace GameMissions.Web.Endpoints.PlayerEndpoints;

public class CreatePlayerResponse
{
  public int Id { get; set; }

  public CreatePlayerResponse(int id)
  {
    Id = id;
  }
}
