using TheatricalPlayersRefactoringKata.Domain.Entities;
namespace TheatricalPlayersRefactoringKata.Domain.Interfaces;

public interface IPlayPricingStrategy
{
    double CalculatePrice(Play play, Performance performance);
}
