namespace CandidateTesting.PatrickHiannKonasugawa.Interfaces
{
	public interface IFacade
	{
		IInputCommand? InputCommand { get; }
		IReturnMessage ReturnMessage { get; }
	}
}
