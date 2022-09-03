using CandidateTesting.PatrickHiannKonasugawa.Backend.Abstracts;
using CandidateTesting.PatrickHiannKonasugawa.Interfaces;

namespace CandidateTesting.PatrickHiannKonasugawa.Backend.BDD
{
	public class InputCommand :InputCommandAbstract, IInputCommand
	{
		/// <summary>
		/// Get the address to provider file.
		/// </summary>
		public string SourceUrl { get => _sourceUrl; }

		/// <summary>
		/// Get the concatenation of the folder and name of the file to be created.
		/// </summary>
		public string TargetPath { get => _targetPath; }

		/// <summary>
		/// Return a error message.
		/// </summary>
		public IReturnMessage ReturnMessage { get => _returnMessage; }

		/// <summary>
		/// Create an instance of this class, validating and keeping the command typed by the user
		/// </summary>
		/// <param name="returnMessage">Will be used to return a error message</param>
		/// <param name="command">The command typed by user</param>
		public InputCommand( IReturnMessage returnMessage, string? command ) : base( returnMessage, command )
		{
		}

		/// <summary>
		/// Method that validates commands entered by the user
		/// </summary>
		/// <param name="command">Commando typed by user in frontend</param>
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
