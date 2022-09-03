using CandidateTesting.PatrickHiannKonasugawa.Interfaces;

namespace CandidateTesting.PatrickHiannKonasugawa.Backend.Abstracts
{
	public abstract class FacadeAbstract
	{
		protected IInputCommand? _inputCommand;

		protected IReturnMessage _returnMessage;

		protected string? _command;

		public FacadeAbstract( IReturnMessage returnMessage, string? command )
		{
			_returnMessage = returnMessage;
			_command = command;

			this.BuildFile();
		}

		protected abstract void BuildFile();
	}
}
