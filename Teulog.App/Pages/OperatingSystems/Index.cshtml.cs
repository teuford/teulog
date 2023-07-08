namespace Teulog.App.Pages.OperatingSystems;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Teulog.App.Entities;

public sealed class IndexModel : PageModel
{
    private readonly TeulogDbContext context;

    public IList<OperatingSystem> OperatingSystems { get; set; } = default!;

    public IndexModel(TeulogDbContext context) => this.context = context;

    public async Task OnGetAsync()
    {
        if (context.OperatingSystems is not null)
        {
            OperatingSystems = await context.OperatingSystems.ToListAsync();
        }
    }
}
