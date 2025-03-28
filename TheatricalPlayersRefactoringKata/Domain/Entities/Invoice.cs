using System.Collections.Generic;

namespace TheatricalPlayersRefactoringKata.Domain.Entities;

public class Invoice(string customer, List<Performance> performances)
{
    public string Customer { get; set; } = customer;
    public List<Performance> Performances { get; set; } = performances;
}
