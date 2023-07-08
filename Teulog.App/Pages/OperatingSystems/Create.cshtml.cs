namespace Teulog.App.Pages.OperatingSystems;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Teulog.App.Entities;

public sealed class CreateModel : PageModel
{
    private readonly TeulogDbContext context;

    [BindProperty]
    public OperatingSystem OperatingSystem { get; set; } = default!;

    public CreateModel(TeulogDbContext context) => this.context = context;

    public IActionResult OnGet() => Page();

    // To protect from over posting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid || context.OperatingSystems is null || OperatingSystem is null)
        {
            return Page();
        }

        context.OperatingSystems.Add(OperatingSystem);
        _ = await context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
