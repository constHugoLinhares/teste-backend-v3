using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using Xunit;
using TheatricalPlayersRefactoringKata.Domain.Entities;
using TheatricalPlayersRefactoringKata.Application.Services;
using TheatricalPlayersRefactoringKata.Application.Formatters;

namespace TheatricalPlayersRefactoringKata.Tests
{
    [UseReporter(typeof(DiffReporter))]
    public class StatementPrinterTests
    {
        public readonly TextStatementFormatter textStatementFormatter = new();
        public readonly XmlStatementFormatter xmlStatementFormatter = new();

        [Fact]
        public void TestStatementExampleLegacy()
        {

            var plays = new Dictionary<string, Play>
            {
                { "hamlet", new Play("Hamlet", 4024, "tragedy") },
                { "as-like", new Play("As You Like It", 2670, "comedy") },
                { "othello", new Play("Othello", 3560, "tragedy") }
            };

            Invoice invoice = new(
                "BigCo",
                new List<Performance>
                {
                    new(plays["hamlet"], 55),
                    new(plays["as-like"], 35),
                    new(plays["othello"], 40)
                }
            );

            var printer = new StatementPrinter(textStatementFormatter);
            var result = printer.Print(invoice);

            Approvals.Verify(result);
        }

        [Fact]
        public void TestTextStatementExample()
        {
            var plays = new Dictionary<string, Play>
            {
                { "hamlet", new Play("Hamlet", 4024, "tragedy") },
                { "as-like", new Play("As You Like It", 2670, "comedy") },
                { "othello", new Play("Othello", 3560, "tragedy") },
                { "henry-v", new Play("Henry V", 3227, "history") },
                { "john", new Play("King John", 2648, "history") },
                { "richard-iii", new Play("Richard III", 3718, "history") }
            };

            Invoice invoice = new Invoice(
                "BigCo",
                new List<Performance>
                {
                    new Performance(plays["hamlet"], 55),
                    new Performance(plays["as-like"], 35),
                    new Performance(plays["othello"], 40),
                    new Performance(plays["henry-v"], 20),
                    new Performance(plays["john"], 39),
                    new Performance(plays["henry-v"], 20)
                }
            );

            var printer = new StatementPrinter(textStatementFormatter);
            var result = printer.Print(invoice);

            Approvals.Verify(result);
        }


        [Fact]
        public void TestXmlStatementExample()
        {
            var plays = new Dictionary<string, Play>
            {
                { "hamlet", new Play("Hamlet", 4024, "tragedy") },
                { "as-like", new Play("As You Like It", 2670, "comedy") },
                { "othello", new Play("Othello", 3560, "tragedy") },
                { "henry-v", new Play("Henry V", 3227, "history") },
                { "john", new Play("King John", 2648, "history") },
                { "richard-iii", new Play("Richard III", 3718, "history") }
            };

            Invoice invoice = new Invoice(
                "BigCo",
                new List<Performance>
                {
                    new Performance(plays["hamlet"], 55),
                    new Performance(plays["as-like"], 35),
                    new Performance(plays["othello"], 40),
                    new Performance(plays["henry-v"], 20),
                    new Performance(plays["john"], 39),
                    new Performance(plays["henry-v"], 20)
                }
            );

            var printer = new StatementPrinter(xmlStatementFormatter);
            var xml = printer.Print(invoice);

            Approvals.Verify(xml);
        }
    }
}