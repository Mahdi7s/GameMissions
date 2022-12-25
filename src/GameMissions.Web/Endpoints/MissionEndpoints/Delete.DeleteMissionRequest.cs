﻿namespace GameMissions.Web.Endpoints.MissionEndpoints;

public class DeleteMissionRequest
{
  public const string Route = "/Missions/{MissionId:int}";

  public static string BuildRoute(int missionId) => Route.Replace("{MissionId:int}", missionId.ToString());

  public int MissionId { get; }
}
