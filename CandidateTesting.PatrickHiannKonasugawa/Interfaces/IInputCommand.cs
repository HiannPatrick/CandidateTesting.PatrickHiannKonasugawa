namespace CandidateTesting.PatrickHiannKonasugawa.Interfaces
{
	public interface IInputCommand
	{
		string SourceUrl { get; }
		string TargetPath { get; }
		public IReturnMessage ReturnMessage { get; }
	}
}
