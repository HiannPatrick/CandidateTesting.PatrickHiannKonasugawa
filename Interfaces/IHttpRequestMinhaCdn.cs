namespace CandidateTesting.PatrickHiannKonasugawa.Interfaces
{
	public interface IHttpRequestMinhaCdn
	{
		IReturnMessage ReturnMessage { get; }

		IInputCommand InputCommand { get; }

		Stream? ContentAsStream { get; }
	}
}
