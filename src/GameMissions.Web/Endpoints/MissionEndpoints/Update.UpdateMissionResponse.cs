namespace GameMissions.Web.Endpoints.MissionEndpoints;

public class UpdateMissionResponse
{
  public UpdateMissionResponse(MissionRecord missionRecord)
  {
    MissionRecord = missionRecord;
  }

  public MissionRecord MissionRecord { get; }
}
