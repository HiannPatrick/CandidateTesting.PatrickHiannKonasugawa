using CandidateTesting.PatrickHiannKonasugawa.Backend.BDD;
using CandidateTesting.PatrickHiannKonasugawa.Frontend;
using CandidateTesting.PatrickHiannKonasugawa.Interfaces;

namespace CandidateTesting.PatrickHiannKonasugawa.UnitTest
{
	[TestClass]
	public class BuildAgoraFileTest
	{
		[TestMethod]
		public void Execute()
		{
			string command = MocksSources.Command;

			IReturnMessage returnMessage = new ReturnMessage();

			IInputCommand inputCommand = new InputCommand(returnMessage, command);

			IProvidersList minhaCdnList = new MinhaCdnList(returnMessage, inputCommand);

			IProviderFile buildAgoraFile = new BuildAgoraFile(returnMessage, minhaCdnList);

			Assert.IsFalse( returnMessage.Error, returnMessage.ErrorMessage );

			Assert.IsNotNull( buildAgoraFile, "IProviderFile is null" );
		}
	}
}
