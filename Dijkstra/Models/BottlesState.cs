namespace Dijkstra
{
	public class BottlesState
	{
		public int Bottle1 { get; set; }
		public int Bottle2 { get; set; }

		public BottlesState(int bottle1, int bottle2)
		{
			Bottle1 = bottle1;
			Bottle2 = bottle2;
		}

		public override string ToString ()
		{
			return string.Format ("({0},{1})", Bottle1, Bottle2);
		}
	}
}