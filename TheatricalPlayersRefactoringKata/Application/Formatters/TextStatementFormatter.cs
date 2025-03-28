using System.Globalization;
using System.Text;
using TheatricalPlayersRefactoringKata.Domain.Entities;
using TheatricalPlayersRefactoringKata.Domain.Factories;
using TheatricalPlayersRefactoringKata.Domain.Interfaces;

namespace TheatricalPlayersRefactoringKata.Application.Formatters;

public class TextStatementFormatter : IStatementFormatter
{
    public string Format(Invoice invoice)
    {
        double totalAmount = 0;
        int volumeCredits = 0;
        var result = new StringBuilder();

        CultureInfo cultureInfo = new("en-US");
        result.AppendLine($"Statement for {invoice.Customer}");

        foreach (var performance in invoice.Performances)
        {
            var play = performance.Play;
            var strategy = PlayPricingStrategyFactory.GetStrategy(play.Genre);

            double playPrice = strategy.CalculatePrice(play, performance);
            totalAmount += playPrice;

            if (strategy is ICreditsStrategy creditsStrategy)
            {
                volumeCredits += creditsStrategy.CalculateCredits(performance);
            }

            result.AppendLine(cultureInfo, $"  {play.Title}: {playPrice:C} ({performance.Audience} seats)");
        }

        result.AppendLine($"Amount owed is {totalAmount:C}");
        result.AppendLine($"You earned {volumeCredits} credits");

        return result.ToString();
    }
}
