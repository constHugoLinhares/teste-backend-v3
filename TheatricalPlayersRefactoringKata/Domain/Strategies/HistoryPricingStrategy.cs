using TheatricalPlayersRefactoringKata.Domain.Entities;
using TheatricalPlayersRefactoringKata.Domain.Interfaces;
namespace TheatricalPlayersRefactoringKata;

public class HistoryPricingStrategy : IPlayPricingStrategy, ICreditsStrategy
{
    private static readonly int ExtraCreditsThreshold = 30;
    private readonly TragedyPricingStrategy _tragedy = new();
    private readonly ComedyPricingStrategy _comedy = new();

    public double CalculatePrice(Play play, Performance performance)
    {
        double tragedyPrice = _tragedy.CalculatePrice(play, performance);
        double comedyPrice = _comedy.CalculatePrice(play, performance);
        return tragedyPrice + comedyPrice;
    }

    public int CalculateCredits(Performance performance)
    {
        return performance.Audience > ExtraCreditsThreshold ? performance.Audience - ExtraCreditsThreshold : 0;
    }
}
