using System.Threading.Tasks;
using TheatricalPlayersRefactoringKata.Domain.Entities;

namespace TheatricalPlayersRefactoringKata.Domain.Ports;
public interface IInvoiceQueue
{
    Task EnqueueAsync(Invoice invoice);
}

public interface IInvoiceProcessor
{
    Task ProcessAsync(Invoice invoice);
}
