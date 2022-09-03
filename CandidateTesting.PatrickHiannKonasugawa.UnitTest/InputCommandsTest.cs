using CandidateTesting.PatrickHiannKonasugawa.Backend.BDD;
using CandidateTesting.PatrickHiannKonasugawa.Frontend;
using CandidateTesting.PatrickHiannKonasugawa.Interfaces;

namespace CandidateTesting.PatrickHiannKonasugawa.UnitTest
{
	[TestClass]
	public class InputCommandsTest
	{
		[TestMethod]
		public void Execute()
		{
			string command = MocksSources.Command;

			IReturnMessage returnMessage = new ReturnMessage();

			IInputCommand inputCommand = new InputCommand(returnMessage, command);

			Assert.IsFalse( returnMessage.Error, returnMessage.ErrorMessage );

			Assert.IsNotNull( inputCommand, "Input is null!" );

			Assert.IsNotNull( inputCommand.SourceUrl, "Source URL is null!" );

			Assert.IsNotNull( inputCommand.TargetPath, "Target path is null!" );
		}
	}
}
