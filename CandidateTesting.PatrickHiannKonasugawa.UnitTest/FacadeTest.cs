using CandidateTesting.PatrickHiannKonasugawa.Backend;
using CandidateTesting.PatrickHiannKonasugawa.Frontend;
using CandidateTesting.PatrickHiannKonasugawa.Interfaces;

namespace CandidateTesting.PatrickHiannKonasugawa.UnitTest
{
	[TestClass]
	public class FacadeTest
	{
		[TestMethod]
		public void Execute()
		{
			string command = MocksSources.Command;

			IReturnMessage returnMessage = new ReturnMessage();

			IFacade facade = new Facade(returnMessage, command);

			Assert.IsFalse( returnMessage.Error, returnMessage.ErrorMessage );

			Assert.IsNotNull( facade.InputCommand, "Input command failed!" );
		}
	}
}