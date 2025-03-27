using System;

namespace TheatricalPlayersRefactoringKata;

public class ComedyPricingStrategy : IPlayPricingStrategy, ICreditsStrategy
{
    private static readonly double PerAudiencePrice = 3.0;
    private static readonly int BonusAudienceThreshold = 20;
    private static readonly double BonusBase = 100.0;
    private static readonly double BonusPerAudience = 5.0;
    private static readonly int ExtraCreditsThreshold = 30;
    private static readonly double BonusCreditsFactor = 5.0;

    public double CalculatePrice(Play play, Performance performance)
    {
        double basePrice = play.GetBasePrice() + (performance.Audience * PerAudiencePrice);

        if (performance.Audience > BonusAudienceThreshold)
        {
            basePrice += BonusBase + ((performance.Audience - BonusAudienceThreshold) * BonusPerAudience);
        }

        return basePrice;
    }

    public int CalculateCredits(Performance performance)
    {
        int baseCredits = performance.Audience > ExtraCreditsThreshold
            ? performance.Audience - ExtraCreditsThreshold
            : 0;

        int bonusCredits = (int)Math.Floor(performance.Audience / BonusCreditsFactor);
        return baseCredits + bonusCredits;
    }
}
