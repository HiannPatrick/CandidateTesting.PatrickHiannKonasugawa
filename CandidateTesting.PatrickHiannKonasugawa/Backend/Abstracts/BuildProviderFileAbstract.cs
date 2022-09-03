using CandidateTesting.PatrickHiannKonasugawa.Interfaces;

namespace CandidateTesting.PatrickHiannKonasugawa.Backend.Abstracts
{
	public abstract class BuildProviderFileAbstract
	{

		protected IReturnMessage _returnMessage;

		protected IProvidersList _providersList;

		public IReturnMessage ReturnMessage { get => _returnMessage; }

		public BuildProviderFileAbstract( IReturnMessage returnMessage, IProvidersList providersList )
		{
			_returnMessage = returnMessage;

			_providersList = providersList;

			this.Write();
		}

		public abstract void Write();
	}
}
