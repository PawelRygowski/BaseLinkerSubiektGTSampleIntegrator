using System.Collections.Generic;

namespace BaseSubjektIntegrator.BaseLinker
{
	public class BaseLinkerOrderResponseModel
	{
		public string Status { get; set; }
		public List<BaseLinkerOrderModel> Orders { get; set; }
	}
}
