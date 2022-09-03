using CandidateTesting.PatrickHiannKonasugawa.Backend;
using CandidateTesting.PatrickHiannKonasugawa.Interfaces;

namespace CandidateTesting.PatrickHiannKonasugawa.Frontend.Abstracts
{
	public abstract class AppAbstract
	{
		public AppAbstract()
		{
			Console.Clear();

			this.Init();
		}

		protected abstract void Init();
		protected void Execute( string? command )
		{
			IReturnMessage returnMessage = new ReturnMessage();

			IFacade facade = new Facade(returnMessage, command );

			if( returnMessage.Error )
			{
				ShowErrorMessage( returnMessage.ErrorMessage );
				return;
			}

			if( facade.InputCommand == null )
			{
				returnMessage.Error = true;
				returnMessage.ErrorMessage = "Input command was not found!";

				ShowErrorMessage( returnMessage.ErrorMessage );

				return;
			}

			Static.TextFiles.Exists( returnMessage, facade.InputCommand.TargetPath );

			if( returnMessage.Error )
				return;

			Static.TextFiles.OpenInNotepad( returnMessage, facade.InputCommand.TargetPath );
		}
		protected void ShowErrorMessage( string errorMessage )
		{
			Console.Clear();
			Console.WriteLine( "Error: " );
			Console.WriteLine( errorMessage );
			Console.Write( "Press any key to continue!" );

			Console.ReadKey();
		}
	}
}
