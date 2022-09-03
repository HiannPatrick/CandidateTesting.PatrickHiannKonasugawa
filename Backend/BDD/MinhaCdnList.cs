using CandidateTesting.PatrickHiannKonasugawa.Backend.Abstracts;
using CandidateTesting.PatrickHiannKonasugawa.Backend.Api;
using CandidateTesting.PatrickHiannKonasugawa.DTO;
using CandidateTesting.PatrickHiannKonasugawa.Interfaces;

namespace CandidateTesting.PatrickHiannKonasugawa.Backend.BDD
{
	public class MinhaCdnList :ProvidersListAbstract, IProvidersList
	{
		/// <summary>
		/// Return a error message.
		/// </summary>
		public IReturnMessage ReturnMessage { get => _returnMessage; }

		/// <summary>
		/// Command typed by the user, after validated and formatted.
		/// </summary>
		public IInputCommand InputCommand { get => _inputCommand; }

		/// <summary>
		/// List of provider
		/// </summary>
		public List<IProvider> ListOfMinhaCdn { get => _listOfMinhaCdn; }

		/// <summary>
		/// Creates an instance of this class, which will populate a "MyCdn" list. 
		/// </summary>
		/// <param name="returnMessage">Will be used to return a error message</param>
		/// <param name="command">Command typed by the user, after validated and formatted</param>
		public MinhaCdnList( IReturnMessage returnMessage, IInputCommand command )
			: base( returnMessage, command )
		{
		}

		/// <summary>
		/// Method that fill list of "MinhaCDN", using a STREAM object.
		/// </summary>
		protected override void FillList()
		{
			try
			{
				_listOfMinhaCdn.Clear();

				IHttpRequestMinhaCdn httpRequest = new HttpRequestMinhaCdn( _returnMessage, _inputCommand );

				if( _returnMessage.Error )
					return;

				if( httpRequest.ContentAsStream == null || httpRequest.ContentAsStream == Stream.Null )
				{
					_returnMessage.Error = true;
					_returnMessage.ErrorMessage = "Error generating the stream";
					return;
				}

				using( var srmMinhaCdn = new StreamReader( httpRequest.ContentAsStream ) )
				{
					string? lineMinhaCdn;

					while( ( lineMinhaCdn = srmMinhaCdn.ReadLine() ) != null )
					{
						IProvider minhaCdnDto = new ProviderDto{ Provider = "MINHA CDN" };

						string[] vetString = lineMinhaCdn.Split('|');

						int currentIndex = 0;

						foreach( string field in vetString )
						{
							switch( currentIndex )
							{
								case 0:
									minhaCdnDto.Response_Size = field;
									break;
								case 1:
									minhaCdnDto.Status_Code = field;
									break;
								case 2:
									minhaCdnDto.Cache_Status = field.ToUpper() == "INVALIDATE" ? "REFRESH_HIT" : field;
									break;
								case 3:
									SetSubField( ref minhaCdnDto, field );
									break;
								case 4:
									Double formatField = Convert.ToDouble(field.Replace('.', ','));
									minhaCdnDto.Time_Taken = Convert.ToInt32( formatField );
									break;
								default:
									continue;
							}

							currentIndex++;
						}

						_listOfMinhaCdn.Add( minhaCdnDto );
					}
				}
			}
			catch( Exception ex )
			{
				_returnMessage.Error = true;
				_returnMessage.ErrorMessage = ex.Message;
			}
		}

		private bool SetSubField( ref IProvider minhaCdnDto, string field )
		{
			string[] subVetString = field.Split(' ');

			int subIndex = 0;

			foreach( string subField in subVetString )
			{
				switch( subIndex )
				{
					case 0:
						minhaCdnDto.Http_Method = subField.Replace( '"', ' ' ).Trim();
						break;
					case 1:
						minhaCdnDto.Uri_Path = subField.Replace( '"', ' ' ).Trim();
						break;
					default:
						continue;
				}

				subIndex++;
			}

			return true;
		}
	}
}
