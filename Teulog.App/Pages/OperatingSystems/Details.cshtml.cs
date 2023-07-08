namespace Teulog.App.Pages.OperatingSystems;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Teulog.App.Entities;

public sealed class DetailsModel : PageModel
{
    private readonly TeulogDbContext context;

    public OperatingSystem OperatingSystem { get; set; } = default!;

    public DetailsModel(TeulogDbContext context) => this.context = context;

    public async Task<IActionResult> OnGetAsync(ushort? id)
    {
        if (id is null or ushort.MinValue || context.OperatingSystems is null)
        {
            return NotFound();
        }

        OperatingSystem? operatingSystem = await context.OperatingSystems.FirstOrDefaultAsync(system => system.Id == id);
        if (operatingSystem is null)
        {
            return NotFound();
        }
        else
        {
            OperatingSystem = operatingSystem;
        }

        return Page();
    }
}
