using System.ComponentModel.DataAnnotations;

namespace SnakesAndLadders.Web.Dto;

public class PostGuestLogin
{
    [Required]
    [StringLength(20)]
    public string Guestname { get; set; } = default!;
}

public record GetUser(Guid Id, string Username);