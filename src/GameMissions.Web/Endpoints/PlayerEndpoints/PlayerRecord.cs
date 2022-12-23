namespace GameMissions.Web.Endpoints.PlayerEndpoints;

public record PlayerRecord(int Id, string? DeviceId, int GameId, int Level, DateTime LastAdWatch, bool Rated = false, string? LastConnectedIP = null, string LocaleCode = "en");
