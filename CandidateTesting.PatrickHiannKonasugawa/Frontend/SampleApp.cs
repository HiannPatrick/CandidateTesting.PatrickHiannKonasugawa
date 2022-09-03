using CandidateTesting.PatrickHiannKonasugawa.Frontend.Abstracts;

namespace CandidateTesting.PatrickHiannKonasugawa.Frontend
{
	public class SampleApp :AppAbstract
	{
		const string sourceUrl = @"https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt";
		const string targetPath = @"./minhaCdn1.txt";

		protected override void Init()
		{
			Console.WriteLine( "Starting Sample..." );
			
			Thread.Sleep( 1500 );

			Console.WriteLine( "URL: " + sourceUrl );

			Thread.Sleep( 1500 );

			Console.WriteLine( "Target Path: " + targetPath );

			Thread.Sleep( 1500 );

			string command = "convert " + sourceUrl + " " + targetPath;

			this.Execute( command );
		}
	}
}
