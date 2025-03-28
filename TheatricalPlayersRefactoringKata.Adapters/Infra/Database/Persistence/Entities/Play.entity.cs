using System;
using System.Collections.Generic;

namespace TheatricalPlayersRefactoringKata.Adapters.Infra.Database.Persistence.Entities;
public class PlayEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public int LineCount { get; set; }
}