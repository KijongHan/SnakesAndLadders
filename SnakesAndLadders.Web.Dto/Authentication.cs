namespace SnakesAndLadders.Web.Dto;

public record PostGuestLogin(string Guestname);

public record GetUser(Guid Id, string Username);