using CandidateTesting.PatrickHiannKonasugawa.Backend.Abstracts;
using CandidateTesting.PatrickHiannKonasugawa.Interfaces;

namespace CandidateTesting.PatrickHiannKonasugawa.Backend.BDD
{
	public class InputCommand :InputCommandAbstract, IInputCommand
	{
		public string SourceUrl { get => _sourceUrl; }
		public string TargetPath { get => _targetPath; }

		public IReturnMessage ReturnMessage { get => _returnMessage; }

		public InputCommand( IReturnMessage returnMessage, string? command ) : base( returnMessage, command )
		{
		}

		protected override void Validate( string? command )
		{
			if( string.IsNullOrEmpty( command ) )
			{
				_returnMessage.Error = true;
				_returnMessage.ErrorMessage = "Type a command!";
				return;
			}

			string[] splitString = command.Split(' ');

			if( splitString.Length < 2 )
			{
				_returnMessage.Error = true;
				_returnMessage.ErrorMessage = "Type a valid command!";
				return;
			}

			string? sourceUrl = splitString.FirstOrDefault( o => o.IndexOf("http") >= 0 );

			if( string.IsNullOrEmpty( sourceUrl ) )
			{
				_returnMessage.Error = true;
				_returnMessage.ErrorMessage = "Invalid source url!";
				return;
			}

			string? targetPath = splitString.LastOrDefault();

			if( string.IsNullOrEmpty( targetPath ) )
			{
				_returnMessage.Error = true;
				_returnMessage.ErrorMessage = "Invalid target path!";
				return;
			}

			_sourceUrl = sourceUrl;
			_targetPath = targetPath;
		}
	}
}
