namespace BaseSubjektIntegrator
{
	public class Configuration
	{
		public int Interval { get; private set; }
		public string BaseLinkerToken { get; private set; }
		public string BaseLinkerUrl { get; private set; }
		public string SGTDatabaseName { get; set; }
		public string SGTServer { get; set; }
		public string SGTDBUserName { get; set; }
		public string SGTDBUserPassword { get; set; }
		public string SGTOperator { get; set; }
		public string SGTOperatorPassword { get; set; }

		public Configuration()
		{
			this.Interval = 6000;
			this.BaseLinkerToken = "2001030-2005057-RWGTSCBHK151KEVN08YSBTBSBI5KYHDRU5PJD9ODEHCHC8TMH04D1CYDTTKX6BOQ";
			this.BaseLinkerUrl = "https://api.baselinker.com/connector.php";
			this.SGTDatabaseName = "podmiot_testowy";
			this.SGTServer = "localhost\\InsERTGT";
			this.SGTDBUserName = "sa";
			this.SGTDBUserPassword = "1234";
			this.SGTOperator = "nazwisko_szefa imie_szefa"; // ?
			this.SGTOperatorPassword = "1234";
		}
	}
}
