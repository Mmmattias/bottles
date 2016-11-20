using System;
using System.Collections.Generic;
using System.Linq;

namespace Dijkstra
{
	public static class GraphPathSolver
	{
		public static IEnumerable<BottlesState> FindPath(BottleGraph map, BottlesState start, Func<BottlesState, bool> isDone)
		{
			var foundPath = new List<BottlesState>();

			int nodesChecked = 0;
			bool found = false;

			var toVisit = new Queue<BottlesState> ();
			toVisit.Enqueue (start);

			var cameFrom = new Dictionary<Tuple<int, int>, BottlesState> ();
			cameFrom.Add (Tuple.Create(start.Bottle1, start.Bottle2), null);

			var costs = new Dictionary<Tuple<int, int>, int> ();
			costs.Add(Tuple.Create(start.Bottle1, start.Bottle2), 0);

			var foundGoal = toVisit.First();

			while (toVisit.Count > 0)
			{
				var current = toVisit.Dequeue ();

				if (isDone(current))
				{
					found = true;
					foundGoal = current;
					break;
				}

				var neighbours = map.GetStates (current).ToArray();

				foreach (var next in neighbours)
				{
					int newCost = costs[Tuple.Create(current.Bottle1, current.Bottle2)] + 1;

					if (!costs.ContainsKey (Tuple.Create(next.Bottle1, next.Bottle2)) || newCost < costs [Tuple.Create(next.Bottle1, next.Bottle2)]) {
						costs [Tuple.Create(next.Bottle1, next.Bottle2)] = newCost;
						toVisit.Enqueue (next);
						cameFrom [Tuple.Create(next.Bottle1, next.Bottle2)] = current;
					}
				}
				nodesChecked++;
			}
			if (!found)
			{
				return foundPath;
			}

			var reverseCurrent = foundGoal;
			var path = new Queue<BottlesState> (new[] { reverseCurrent });
			while (reverseCurrent != start)
			{
				reverseCurrent = cameFrom [Tuple.Create(reverseCurrent.Bottle1, reverseCurrent.Bottle2)];
				path.Enqueue (reverseCurrent);
			}

			foundPath = path.Reverse ().ToList();

			return foundPath;
		}
	}
}