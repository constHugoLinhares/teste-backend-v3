using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TheatricalPlayersRefactoringKata.Domain.Entities;
using TheatricalPlayersRefactoringKata.Domain.Ports;
using TheatricalPlayersRefactoringKata.Adapters.Infra.Database.Persistence.Entities;

namespace TheatricalPlayersRefactoringKata.Adapters.InQueue
{
    public class InMemoryInvoiceQueue : IInvoiceQueue
    {
        private readonly Channel<InvoiceEntity> _channel = Channel.CreateUnbounded<InvoiceEntity>();
        private readonly IServiceProvider _serviceProvider;

        public InMemoryInvoiceQueue(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            StartConsumer();
        }

        private void StartConsumer()
        {
            Task.Run(async () =>
            {
                await foreach (var invoice in _channel.Reader.ReadAllAsync())
                {
                    using var scope = _serviceProvider.CreateScope();
                    var processor = scope.ServiceProvider.GetRequiredService<IInvoiceProcessor>();
                    await processor.ProcessAsync(invoice);
                }
            });
        }

        public Task EnqueueAsync(Invoice invoice)
        {
            return _channel.Writer.WriteAsync(invoice).AsTask();
        }

    }
}