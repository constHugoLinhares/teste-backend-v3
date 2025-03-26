using System;
using System.Collections.Generic;
using System.Globalization;

namespace TheatricalPlayersRefactoringKata;

public class StatementPrinter
{
    public string Print(Invoice invoice)
    {
        double totalAmount = 0;
        int volumeCredits = 0;
        var result = $"Statement for {invoice.Customer}\n";
        CultureInfo cultureInfo = new CultureInfo("en-US");

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

            result += String.Format(cultureInfo, $"  {play.Title}: {playPrice:C} ({performance.Audience} seats)\n");
        }

        result += String.Format($"Amount owed is {totalAmount:C}\n");
        result += String.Format($"You earned {volumeCredits} credits\n");

        return result;
    }
}
