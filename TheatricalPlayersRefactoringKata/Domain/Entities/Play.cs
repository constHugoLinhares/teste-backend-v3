using System;

namespace TheatricalPlayersRefactoringKata;

public class Play
{
    public string Title { get; }
    public string Genre { get; }
    public int LineCount { get; }

    public Play(string title, int lineCount, string genre)
    {
        Title = title;
        LineCount = Math.Clamp(lineCount, 1000, 4000);
        Genre = genre;
    }

    public double GetBasePrice()
    {
        return LineCount / 10.0;
    }
}
