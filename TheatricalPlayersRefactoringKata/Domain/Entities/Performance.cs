using System;

namespace TheatricalPlayersRefactoringKata;

public class Performance
{
    public Play Play { get; }
    public int Audience { get; }

    public Performance(Play play, int audience)
    {
        Play = play ?? throw new ArgumentNullException(nameof(play));
        Audience = audience;
    }
}