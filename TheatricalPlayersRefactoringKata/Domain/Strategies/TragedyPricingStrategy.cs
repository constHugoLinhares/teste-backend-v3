namespace TheatricalPlayersRefactoringKata;

public class TragedyPricingStrategy : IPlayPricingStrategy, ICreditsStrategy
{
    public double CalculatePrice(Play play, Performance performance)
    {
        double basePrice = play.GetBasePrice();

        if (performance.Audience > 30)
        {
            basePrice += (performance.Audience - 30) * 10.0;
        }

        return basePrice;
    }

    public int CalculateCredits(Performance performance)
    {
        return performance.Audience > 30 ? performance.Audience - 30 : 0;
    }
}
