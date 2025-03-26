using System;

namespace TheatricalPlayersRefactoringKata;

public class PlayPricingStrategyFactory
{
	public static IPlayPricingStrategy GetStrategy(string genre)
	{
		return genre.ToLower() switch
		{
			"comedy" => new ComedyPricingStrategy(),
			"history" => new HistoryPricingStrategy(),
			"tragedy" => new TragedyPricingStrategy(),
			_ => throw new ArgumentException("Unknown genre.")
		};
	}
}