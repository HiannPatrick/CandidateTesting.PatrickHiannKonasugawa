using CandidateTesting.PatrickHiannKonasugawa.Frontend.Abstracts;

namespace CandidateTesting.PatrickHiannKonasugawa.Frontend
{
	public class MockApp :AppAbstract
	{
		const string sourceUrl = @"https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt";
		const string targetPath = @"./minhaCdn1.txt";

		protected override void Init()
		{
			Console.WriteLine( "Starting mock test..." );
			Console.WriteLine( "URL: " + sourceUrl );
			Console.WriteLine( "Target Path: " + targetPath );

			string command = "convert " + sourceUrl + " " + targetPath;

			this.Execute( command );
		}
	}
}
