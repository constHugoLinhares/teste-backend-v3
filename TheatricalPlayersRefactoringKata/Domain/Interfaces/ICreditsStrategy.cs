using TheatricalPlayersRefactoringKata.Domain.Entities;

namespace TheatricalPlayersRefactoringKata.Domain.Interfaces;
public interface ICreditsStrategy
{
	int CalculateCredits(Performance performance);
}
