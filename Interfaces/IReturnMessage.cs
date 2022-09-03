namespace CandidateTesting.PatrickHiannKonasugawa.Interfaces
{
	public interface IReturnMessage
	{
		bool Error { get; set; }
		string ErrorMessage { get; set; }

		void ClearStatus();
	}
}
