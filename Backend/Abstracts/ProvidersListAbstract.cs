using CandidateTesting.PatrickHiannKonasugawa.Interfaces;

namespace CandidateTesting.PatrickHiannKonasugawa.Backend.Abstracts
{
	public abstract class ProvidersListAbstract
	{
		protected IReturnMessage _returnMessage;

		protected IInputCommand _inputCommand;

		protected List<IProvider> _listOfMinhaCdn;

		public ProvidersListAbstract( IReturnMessage returnMessage, IInputCommand inputCommand )
		{
			_returnMessage = returnMessage;
			_inputCommand = inputCommand;
			_listOfMinhaCdn = new List<IProvider>();

			this.FillList();
		}

		protected abstract void FillList();
	}
}
