namespace GameMissions.Web.Endpoints.MissionEndpoints;

public class CreateMissionResponse
{
  public CreateMissionResponse(int id)
  {
    Id = id;
  }

  public int Id { get; }
}
