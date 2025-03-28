using TheatricalPlayersRefactoringKata;
using TheatricalPlayersRefactoringKata.Domain.Entities;
using TheatricalPlayersRefactoringKata.Adapters.Infra.Database.Persistence.Entities;

namespace TheatricalPlayersRefactoringKata.Adapters.Infra.Database.Mappers;
public static class InvoiceMapper
{
    public static Invoice ToDomain(this InvoiceEntity entity)
    {
        return new Invoice(
            entity.Customer,
            entity.Performances.Select(p => new Performance(
                new Play(p.Play.Title, p.Play.LineCount, p.Play.Genre),
                p.Audience
            )).ToList()
        );
    }

    public static InvoiceEntity ToEntity(this Invoice invoice)
    {
        return new InvoiceEntity
        {
            Customer = invoice.Customer,
            Performances = invoice.Performances.Select(p => new PerformanceEntity
            {
                Audience = p.Audience,
                Play = new PlayEntity
                {
                    Title = p.Play.Title,
                    Genre = p.Play.Genre,
                    LineCount = p.Play.LineCount
                }
            }).ToList()
        };
    }
}
