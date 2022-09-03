using CandidateTesting.PatrickHiannKonasugawa.Backend.Abstracts;
using CandidateTesting.PatrickHiannKonasugawa.Interfaces;

namespace CandidateTesting.PatrickHiannKonasugawa.Backend.Api
{
	public class HttpRequestMinhaCdn :HttpRequestMinhaCdnAbstract, IHttpRequestMinhaCdn
	{
		public IReturnMessage ReturnMessage { get => _returnMessage; }

		public IInputCommand InputCommand { get => _inputCommand; }

		public Stream ContentAsStream { get => _contentAsStream; }

		public HttpRequestMinhaCdn( IReturnMessage returnMessage, IInputCommand inputCommand )
			: base( returnMessage, inputCommand )
		{

		}

		protected override void SetStream()
		{
			using( var client = new HttpClient() )
			{
				HttpResponseMessage message = client.GetAsync(_inputCommand.SourceUrl).Result;

				if( message.StatusCode != System.Net.HttpStatusCode.OK )
				{
					_returnMessage.Error = true;
					_returnMessage.ErrorMessage = "Could not reach requested url.";
					_returnMessage.ErrorMessage += " | Http Status Code: " + message.StatusCode;
					_returnMessage.ErrorMessage += " | URL: " + _inputCommand.SourceUrl;
					return;
				}

				_contentAsStream = message.Content.ReadAsStream();

				if( _contentAsStream == null )
				{
					_returnMessage.Error = true;
					_returnMessage.ErrorMessage = "Error generating the stream";
					return;
				}
			}
		}
	}
}
