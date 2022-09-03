namespace CandidateTesting.PatrickHiannKonasugawa.UnitTest
{
	public static class MocksSources
	{
		public const string SourceUrl = @"https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt";
		public const string TargetPath = @"./minhaCdn1.txt";
		public const string Command = MocksSources.SourceUrl + " " + MocksSources.TargetPath;
	}
}
