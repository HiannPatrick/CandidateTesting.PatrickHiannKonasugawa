using CandidateTesting.PatrickHiannKonasugawa.Frontend.Abstracts;

namespace CandidateTesting.PatrickHiannKonasugawa.Frontend
{
	public class MainApp :AppAbstract
	{
		protected override void Init()
		{
			Console.Write( "Type the command (<command> <source url> <target path>): " );

			string? command = Console.ReadLine();

			this.Execute( command );
		}
	}
}
