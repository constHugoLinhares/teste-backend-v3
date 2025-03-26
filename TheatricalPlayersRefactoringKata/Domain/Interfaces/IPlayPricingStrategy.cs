namespace TheatricalPlayersRefactoringKata;

public interface IPlayPricingStrategy
{
    double CalculatePrice(Play play, Performance performance);
}
