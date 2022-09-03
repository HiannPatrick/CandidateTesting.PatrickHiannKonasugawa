using CandidateTesting.PatrickHiannKonasugawa.Interfaces;

namespace CandidateTesting.PatrickHiannKonasugawa.Backend.Abstracts
{
	public abstract class HttpRequestMinhaCdnAbstract
	{
		protected IReturnMessage _returnMessage;

		protected IInputCommand _inputCommand;

		protected Stream _contentAsStream;

		public HttpRequestMinhaCdnAbstract( IReturnMessage returnMessage, IInputCommand inputCommand )
		{
			_returnMessage = returnMessage;
			_inputCommand = inputCommand;
			_contentAsStream = Stream.Null;

			this.SetStream();
		}

		protected abstract void SetStream();
	}
}
