using CandidateTesting.PatrickHiannKonasugawa.Backend.Abstracts;
using CandidateTesting.PatrickHiannKonasugawa.DTO;
using CandidateTesting.PatrickHiannKonasugawa.Interfaces;

using System.Reflection;

namespace CandidateTesting.PatrickHiannKonasugawa.Backend.BDD
{
	public class BuildAgoraFile :BuildProviderFileAbstract, IProviderFile
	{
		public BuildAgoraFile( IReturnMessage returnMessage, IProvidersList providersList )
			: base( returnMessage, providersList )
		{

		}

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
