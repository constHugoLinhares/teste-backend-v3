using System;
using System.Collections.Generic;

namespace TheatricalPlayersRefactoringKata.Adapters.Infra.Database.Persistence.Entities;
public class InvoiceEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Customer { get; set; } = string.Empty;
    public List<PerformanceEntity> Performances { get; set; } = new();
    public string XmlPath { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
