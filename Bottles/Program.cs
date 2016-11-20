using System;
using Dijkstra;

namespace Bottles
{
	public class MainClass
	{
		public static void Main(string[] args)
		{
			bool hasCorrectInput = false;
			int bottle1 = 0;
			int bottle2 = 0;
			int goal = 0;

			while (!hasCorrectInput)
			{
				Console.WriteLine("Specify bottles and goal amount as follows: <Bottle 1> <Bottle 2> <Goal amount>");

				var input = Console.ReadLine();

				var parameters = input.Split(new[] { ' ' });

				hasCorrectInput =
					parameters.Length == 3 &&
		          	int.TryParse(parameters[0], out bottle1) &&
		          	int.TryParse(parameters[1], out bottle2) &&
		          	int.TryParse(parameters[2], out goal);
				
				if (!hasCorrectInput)
				{
					Console.WriteLine("Invalid arguments.");
				}
			}

			var map = new BottleGraph(bottle1, bottle2);
			var path = GraphPathSolver.FindPath(map, new BottlesState(bottle1, bottle2), x => x.Bottle1 == goal || x.Bottle2 == goal);

			foreach (var step in path)
			{
				Console.WriteLine(step);
			}
		}
	}
}
