using System.Collections.Generic;

namespace Dijkstra
{
	public class BottleGraph
	{
		private int _bottle1Max;
		private int _bottle2Max;

		public BottleGraph(int bottle1Max, int bottle2Max)
		{
			_bottle1Max = bottle1Max;
			_bottle2Max = bottle2Max;
		}

		public IEnumerable<BottlesState> GetStates(BottlesState currentState)
		{
			var options = new List<BottlesState>();

			// Bottle 1 --> Bottle 2
			if (currentState.Bottle1 > 0 && currentState.Bottle2 < _bottle2Max)
			{
				int bottle2 = currentState.Bottle2 + currentState.Bottle1;
				var overflow = bottle2 - _bottle2Max;

				// Om vi inte får plats, låt det överflödiga ligga kvar
				int bottle1 = overflow > 0 ? overflow : 0;

				// Om vi inte får plats, fyll flaskan.
				bottle2 = bottle2 > _bottle2Max ? _bottle2Max : bottle2;
				options.Add(new BottlesState(bottle1, bottle2));
			}

			// Bottle 2 --> Bottle 1
			if (currentState.Bottle2 > 0 && currentState.Bottle1 < _bottle1Max)
			{
				int bottle1 = currentState.Bottle1 + currentState.Bottle2;
				var overflow = bottle1 - _bottle1Max;

				// Om vi inte får plats, låt det överflödiga ligga kvar
				int bottle2 = overflow > 0 ? System.Math.Abs(overflow) : 0;

				// Om vi inte får plats, fyll flaskan.
				bottle1 = bottle1 > _bottle1Max ? _bottle1Max : bottle1;
				options.Add(new BottlesState(bottle1, bottle2));
			}

			// Bottle 1 --> Empty
			if (currentState.Bottle1 > 0)
			{
				options.Add(new BottlesState(0, currentState.Bottle2));
			}

			// Bottle 2 --> Empty
			if (currentState.Bottle2 > 0)
			{
				options.Add(new BottlesState(currentState.Bottle1, 0));
			}

			// Bottle 1 --> Fill
			if (currentState.Bottle1 < _bottle1Max)
			{
				options.Add(new BottlesState(_bottle1Max, currentState.Bottle2));
			}

			// Bottle 2 --> Fill
			if (currentState.Bottle2 < _bottle2Max)
			{
				options.Add(new BottlesState(currentState.Bottle2, _bottle2Max));
			}

			return options;
		}
	}
}