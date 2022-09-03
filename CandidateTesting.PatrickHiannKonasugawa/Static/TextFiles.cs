using CandidateTesting.PatrickHiannKonasugawa.Interfaces;

using System.Diagnostics;

namespace CandidateTesting.PatrickHiannKonasugawa.Static
{
	public static class TextFiles
	{
		public static void Exists( IReturnMessage returnMessage, string targetPath )
		{
			try
			{
				returnMessage.ClearStatus();

				if( !File.Exists( targetPath ) )
				{
					returnMessage.Error = true;
					returnMessage.ErrorMessage = "The file was not found!";
				}
			}
			catch( Exception ex )
			{
				returnMessage.Error = true;
				returnMessage.ErrorMessage = ex.Message;
			}
		}

		public static void OpenInNotepad( IReturnMessage returnMessage, string targetPath )
		{
			try
			{
				ProcessStartInfo startInfo = new ProcessStartInfo{ FileName = targetPath };

				Process.Start( "notepad.exe", startInfo.FileName );
			}
			catch( Exception ex )
			{
				returnMessage.Error = true;

				returnMessage.ErrorMessage = ex.Message;
			}
		}
	}
}
