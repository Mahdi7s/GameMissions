using GameMissions.Core.GameAggregate;

namespace GameMissions.Web.Endpoints.GameEndpoints;

public class CreateGameResponse 
{
  public CreateGameResponse(int id)
  {
    Id = id;
  }
  public int Id { get; set; }
}
