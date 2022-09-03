using CandidateTesting.PatrickHiannKonasugawa.Backend.Abstracts;
using CandidateTesting.PatrickHiannKonasugawa.DTO;
using CandidateTesting.PatrickHiannKonasugawa.Interfaces;

using System.Reflection;

namespace CandidateTesting.PatrickHiannKonasugawa.Backend.BDD
{
	public class BuildAgoraFile :BuildProviderFileAbstract, IProviderFile
	{
		/// <summary>
		/// Create an instance of this class and write a file in "Agora" layout, using a list of IProvider.
		/// </summary>
		/// <param name="returnMessage">Will be used to return a error message</param>
		/// <param name="providersList">Contains the data that will be written in the layout of the "Agora" file</param>
		public BuildAgoraFile( IReturnMessage returnMessage, IProvidersList providersList )
			: base( returnMessage, providersList )
		{

		}

		/// <summary>
		/// Method to write an IProvider in  layout of the Agora File.
		/// </summary>
		public override void Write()
		{
			try
			{
				using( var sw = new StreamWriter( _providersList.InputCommand.TargetPath, false ) )
				{
					PropertyInfo[] properties = typeof( ProviderDto ).GetProperties();

					string strProperties = properties.Aggregate( "", (aggregate, current) => aggregate += current.Name + " ", o => o.Replace("_", "-").ToLower() );

					sw.WriteLine( "#Version: 1.0" );
					sw.WriteLine( "#Date: "
								  + DateTime.Now.ToShortDateString()
								  + " "
								  + DateTime.Now.ToShortTimeString() );

					sw.WriteLine( "#Fields: " + strProperties );

					foreach( ProviderDto provider in _providersList.ListOfMinhaCdn )
					{
						sw.WriteLine( '"' + provider.Provider + '"'
									  + " " + provider.Http_Method
									  + " " + provider.Status_Code
									  + " " + provider.Uri_Path
									  + " " + provider.Time_Taken
									  + " " + provider.Response_Size
									  + " " + provider.Cache_Status );
					}
				}
			}
			catch( Exception ex )
			{
				_returnMessage.Error = true;
				_returnMessage.ErrorMessage = ex.Message;
			}
		}
	}
}
