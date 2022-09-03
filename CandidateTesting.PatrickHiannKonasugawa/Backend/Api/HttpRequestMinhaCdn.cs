using CandidateTesting.PatrickHiannKonasugawa.Backend.Abstracts;
using CandidateTesting.PatrickHiannKonasugawa.Interfaces;

namespace CandidateTesting.PatrickHiannKonasugawa.Backend.Api
{
	public class HttpRequestMinhaCdn :HttpRequestMinhaCdnAbstract, IHttpRequestMinhaCdn
	{
		public IReturnMessage ReturnMessage { get => _returnMessage; }

		public IInputCommand InputCommand { get => _inputCommand; }

		public Stream ContentAsStream { get => _contentAsStream; }

		/// <summary>
		/// Create an instance of this class, getting a list of "MinhaCdn", using only commands typed by the user;
		/// </summary>
		/// <param name="returnMessage">Will be used to return a error message</param>
		/// <param name="inputCommand">Contains the command typed by user</param>
		public HttpRequestMinhaCdn( IReturnMessage returnMessage, IInputCommand inputCommand )
			: base( returnMessage, inputCommand )
		{

		}

		/// <summary>
		/// Method used to get the "MinhaCDN" list, converting it to a STREAM object.
		/// </summary>
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
