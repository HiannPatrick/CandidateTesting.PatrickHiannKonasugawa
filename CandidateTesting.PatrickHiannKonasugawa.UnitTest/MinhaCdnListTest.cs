using CandidateTesting.PatrickHiannKonasugawa.Backend.BDD;
using CandidateTesting.PatrickHiannKonasugawa.Frontend;
using CandidateTesting.PatrickHiannKonasugawa.Interfaces;

namespace CandidateTesting.PatrickHiannKonasugawa.UnitTest
{
	[TestClass]
	public class MinhaCdnListTest
	{
		[TestMethod]
		public void Execute()
		{
			string command = MocksSources.Command;

			IReturnMessage returnMessage = new ReturnMessage();

			IInputCommand inputCommand = new InputCommand(returnMessage, command);

			IProvidersList minhaCdnList = new MinhaCdnList(returnMessage, inputCommand);

			Assert.IsFalse( returnMessage.Error, returnMessage.ErrorMessage );

			Assert.IsNotNull( minhaCdnList, "IProviderList is null" );

			Assert.IsNotNull( minhaCdnList.InputCommand, "InputCommand is null!" );

			Assert.IsNotNull( minhaCdnList.ListOfMinhaCdn, "Invalid list!" );
		}
	}
}
