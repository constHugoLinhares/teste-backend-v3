using System.Globalization;
using System.Text;
using System.Xml.Linq;
using System.Collections.Generic;
using System;
using TheatricalPlayersRefactoringKata.Domain.Entities;
using TheatricalPlayersRefactoringKata.Domain.Factories;
using TheatricalPlayersRefactoringKata.Domain.Interfaces;

namespace TheatricalPlayersRefactoringKata.Application.Services;
public class StatementPrinter
{
    public string Print(Invoice invoice)
    {
        double totalAmount = 0;
        int volumeCredits = 0;
        var result = new StringBuilder();

        CultureInfo cultureInfo = new CultureInfo("en-US");
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

    public string GenerateXml(Invoice invoice)
    {
        CultureInfo cultureInfo = new("en-US");
        double totalAmount = 0;
        int totalCredits = 0;
        var items = new List<XElement>();

        foreach (var performance in invoice.Performances)
        {
            int credits = 0;
            var play = performance.Play;
            var strategy = PlayPricingStrategyFactory.GetStrategy(play.Genre);
            double amount = strategy.CalculatePrice(play, performance);

            if (strategy is ICreditsStrategy creditsStrategy)
            {
                credits = creditsStrategy.CalculateCredits(performance);
                totalCredits += creditsStrategy.CalculateCredits(performance);
            }

            totalAmount += amount;

            items.Add(
                new XElement("Item",
                    new XElement("AmountOwed", amount.ToString("0.##", CultureInfo.InvariantCulture)),
                    new XElement("EarnedCredits", credits),
                    new XElement("Seats", performance.Audience)
                )
            );
        }

        var doc =
        new XDocument(
            new XDeclaration("1.0", "utf-8", null),
            new XElement("Statement",
                new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
                new XAttribute(XNamespace.Xmlns + "xsd", "http://www.w3.org/2001/XMLSchema"),
                new XElement("Customer", invoice.Customer),
                new XElement("Items", items),
                new XElement("AmountOwed", totalAmount.ToString("0.##", CultureInfo.InvariantCulture)),
                new XElement("EarnedCredits", totalCredits)
            )
        );

        return doc.Declaration + Environment.NewLine + doc.ToString();
    }
}
