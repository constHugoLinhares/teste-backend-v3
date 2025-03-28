using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TheatricalPlayersRefactoringKata.Domain.Entities;
using TheatricalPlayersRefactoringKata.Domain.Ports;
using TheatricalPlayersRefactoringKata.Adapters.Infra.Database.Persistence.Entities;

namespace TheatricalPlayersRefactoringKata.Adapters.Infra.Http.Controllers
{
    [ApiController]
    [Route("api/invoices")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceQueue _queue;

        public InvoiceController(IInvoiceQueue queue)
        {
            _queue = queue;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitInvoice([FromBody] Invoice invoice)
        {
            await _queue.EnqueueAsync(invoice);
            return Accepted();
        }
    }
}