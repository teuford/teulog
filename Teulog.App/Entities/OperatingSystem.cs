namespace Teulog.App.Entities;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

[Index(nameof(Title), IsUnique = true)]
public sealed class OperatingSystem
{
    public required string Title { get; set; }

    [Key]
    public ushort Id { get; init; }
}
