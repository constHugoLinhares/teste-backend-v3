using System;

namespace TheatricalPlayersRefactoringKata.Domain.Entities;

public class Performance(Play play, int audience)
{
    public Play Play { get; set; } = play ?? throw new ArgumentNullException(nameof(play));
    public int Audience { get; set; } = audience;
}
