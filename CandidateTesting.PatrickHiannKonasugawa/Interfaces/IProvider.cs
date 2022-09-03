namespace CandidateTesting.PatrickHiannKonasugawa.Interfaces
{
	public interface IProvider
	{
		public string? Provider { get; set; }
		public string? Http_Method { get; set; }
		public string? Status_Code { get; set; }
		public string? Uri_Path { get; set; }
		public int Time_Taken { get; set; }
		public string? Response_Size { get; set; }
		public string? Cache_Status { get; set; }
	}
}
