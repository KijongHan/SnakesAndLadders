namespace SnakesAndLadders.Web.Api.Dtos;

public record PostGuestLogin(string Guestname);

public record GetUser(Guid Id, string Username);