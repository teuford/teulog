namespace Teulog.App.Pages.OperatingSystems;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Teulog.App.Entities;

public sealed class EditModel : PageModel
{
    private readonly TeulogDbContext context;

    [BindProperty]
    public OperatingSystem OperatingSystem { get; set; } = default!;

    public EditModel(TeulogDbContext context) => this.context = context;

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

        OperatingSystem = operatingSystem;

        return Page();
    }

    // To protect from over posting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        context.Attach(OperatingSystem).State = EntityState.Modified;

        try
        {
            _ = await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!OperatingSystemExists(OperatingSystem.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool OperatingSystemExists(ushort id) => (context.OperatingSystems?.Any(system => system.Id == id)).GetValueOrDefault();
}
