using System;

namespace BaseSubjektIntegrator.UI
{
	public class ConsoleUI
	{

		public bool ShowAlternative(string message)
		{
			char key;
			do
			{
				Console.Write(message);

				key = Console.ReadKey().KeyChar;
				Console.WriteLine();
			} while (key != 'y' && key != 'n' && key != 'Y' && key != 'N');
			return key == 'y' ? true : false;
		}

		public int ShowOptions(string message)
		{
			string input;
			int output;
			do
			{
				Console.Write(message);

				input = Console.ReadLine();
			} while (!int.TryParse(input, out output));
			return output;
		}
	}
}
