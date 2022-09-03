namespace CandidateTesting.PatrickHiannKonasugawa.Interfaces
{
	public interface IProvidersList
	{
		List<IProvider> ListOfMinhaCdn { get; }

		IInputCommand InputCommand { get; }

		IReturnMessage ReturnMessage { get; }
	}
}
