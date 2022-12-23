namespace GameMissions.Web.Endpoints.MissionEndpoints;

public record MissionRecord(int Id, int GameId, int MissionType, int Order, string? Title, int CompletionLevel, int Reward, string? Description);
