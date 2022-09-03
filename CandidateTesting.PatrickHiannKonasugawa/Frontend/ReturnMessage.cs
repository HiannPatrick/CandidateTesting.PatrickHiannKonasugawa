using CandidateTesting.PatrickHiannKonasugawa.Interfaces;

namespace CandidateTesting.PatrickHiannKonasugawa.Frontend
{
	public class ReturnMessage :IReturnMessage
	{
		private bool _error = false;
		private string _errorMessage = "";

		public bool Error { get => _error; set => _error = value; }
		public string ErrorMessage { get => _errorMessage; set => _errorMessage = value; }

		public void ClearStatus()
		{
			_error = false;
			_errorMessage = "";
		}
	}
}
