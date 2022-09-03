using CandidateTesting.PatrickHiannKonasugawa.Interfaces;

namespace CandidateTesting.PatrickHiannKonasugawa.Backend.Abstracts
{
	public abstract class InputCommandAbstract
	{
		protected string _sourceUrl;
		protected string _targetPath;

		protected IReturnMessage _returnMessage;

		public InputCommandAbstract( IReturnMessage returnMessage, string? command )
		{
			_returnMessage = returnMessage;
			_sourceUrl = "";
			_targetPath = "";

			this.Validate( command );
		}
		protected abstract void Validate( string? command );
	}
}
