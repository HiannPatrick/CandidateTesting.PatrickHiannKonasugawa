using CandidateTesting.PatrickHiannKonasugawa.Backend.Abstracts;
using CandidateTesting.PatrickHiannKonasugawa.Backend.BDD;
using CandidateTesting.PatrickHiannKonasugawa.Interfaces;

namespace CandidateTesting.PatrickHiannKonasugawa.Backend
{
	public class Facade :FacadeAbstract, IFacade
	{
		public IInputCommand? InputCommand { get => _inputCommand; }
		public IReturnMessage ReturnMessage { get => _returnMessage; }

		public Facade( IReturnMessage returnMessage, string? command ) : base( returnMessage, command )
		{

		}

		protected override void BuildFile()
		{
			_inputCommand = new InputCommand( _returnMessage, _command );

			if( _returnMessage.Error )
				return;

			IProvidersList minhaCdnList = new MinhaCdnList( _returnMessage, _inputCommand);

			if( _returnMessage.Error )
				return;

			new BuildAgoraFile( _returnMessage, minhaCdnList );
		}
	}
}
