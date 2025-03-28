using System;
using System.Collections.Generic;

namespace TheatricalPlayersRefactoringKata.Adapters.Infra.Database.Persistence.Entities;
public class PerformanceEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int Audience { get; set; }
    public Guid PlayId { get; set; }
    public PlayEntity Play { get; set; } = null!;
}