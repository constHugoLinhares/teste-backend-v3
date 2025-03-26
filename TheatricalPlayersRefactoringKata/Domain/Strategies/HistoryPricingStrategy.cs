using System;

namespace TheatricalPlayersRefactoringKata;

public class HistoryPricingStrategy : IPlayPricingStrategy, ICreditsStrategy
{
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
        return performance.Audience > 30 ? performance.Audience - 30 : 0;
    }
}
