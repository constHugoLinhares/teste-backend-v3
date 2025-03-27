using System.Collections.Generic;

namespace TheatricalPlayersRefactoringKata;

public class Invoice(string customer, List<Performance> performances)
{
    public string Customer { get; set; } = customer;
    public List<Performance> Performances { get; set; } = performances;
}
