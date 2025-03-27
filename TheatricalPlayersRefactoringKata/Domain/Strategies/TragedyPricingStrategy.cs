namespace TheatricalPlayersRefactoringKata;

public class TragedyPricingStrategy : IPlayPricingStrategy, ICreditsStrategy
{
    private static readonly int ExtraCreditsThreshold = 30;
    private static readonly int BonusAudienceThreshold = 30;
    private static readonly double BonusPerPerson = 10.0;

    public double CalculatePrice(Play play, Performance performance)
    {
        double basePrice = play.GetBasePrice();

        if (performance.Audience > BonusAudienceThreshold)
        {
            basePrice += (performance.Audience - BonusAudienceThreshold) * BonusPerPerson;
        }

        return basePrice;
    }

    public int CalculateCredits(Performance performance)
    {
        return performance.Audience > ExtraCreditsThreshold ? performance.Audience - ExtraCreditsThreshold : 0;
    }
}
