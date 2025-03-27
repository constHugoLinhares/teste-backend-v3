using System;

namespace TheatricalPlayersRefactoringKata;

public class Play(string title, int lineCount, string genre)
{
    static int minPlayLines = 1000;
    static int maxPlayLines = 4000;

    public string Title { get; set; } = title;
    public int LineCount { get; set; } = Math.Clamp(lineCount, minPlayLines, maxPlayLines);
    public string Genre { get; set; } = genre;

    public double GetBasePrice() => LineCount / 10.0;
}
