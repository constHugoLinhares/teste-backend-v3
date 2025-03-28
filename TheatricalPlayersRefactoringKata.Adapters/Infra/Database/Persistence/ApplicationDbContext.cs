using Microsoft.EntityFrameworkCore;
using TheatricalPlayersRefactoringKata.Adapters.Infra.Database.Persistence.Entities;

namespace TheatricalPlayersRefactoringKata.Infra.Database.Persistence;
public class ApplicationDbContext : DbContext
{
    public DbSet<InvoiceEntity> Invoices => Set<InvoiceEntity>();
    public DbSet<PlayEntity> Plays => Set<PlayEntity>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
}
