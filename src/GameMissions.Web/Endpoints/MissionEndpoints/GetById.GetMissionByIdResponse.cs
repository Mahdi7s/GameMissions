namespace GameMissions.Web.Endpoints.MissionEndpoints;

public class GetMissionByIdResponse
{
  public GetMissionByIdResponse(MissionRecord missionRecord)
  {
    MissionRecord = missionRecord;
  }

  public MissionRecord MissionRecord { get; }
}
