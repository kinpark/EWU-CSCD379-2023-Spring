using Microsoft.AspNetCore.Identity;

namespace Wordle.Api.Data;

public class AppUser : IdentityUser
{
    public required string Name { get; set; }
    public int GameCount { get; set; }
    public double WinLossAverage { get; set; }
    public double AverageMoves { get; set; }
    public int AverageSecondsPerGame { get; set; }

    public DateTime? BirthDate { get; set; }
}