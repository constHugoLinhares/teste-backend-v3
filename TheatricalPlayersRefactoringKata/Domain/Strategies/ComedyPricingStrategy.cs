using System;

namespace TheatricalPlayersRefactoringKata;

public class ComedyPricingStrategy : IPlayPricingStrategy, ICreditsStrategy
{
    public double CalculatePrice(Play play, Performance performance)
    {
        double basePrice = play.GetBasePrice() + (performance.Audience * 3.0);

        if (performance.Audience > 20)
        {
            basePrice += 100.0 + ((performance.Audience - 20) * 5.0);
        }

        return basePrice;
    }

    public int CalculateCredits(Performance performance)
    {
        int baseCredits = performance.Audience > 30 ? performance.Audience - 30 : 0;
        int bonusCredits = (int)Math.Floor(performance.Audience / 5.0);
        return baseCredits + bonusCredits;
    }
}
