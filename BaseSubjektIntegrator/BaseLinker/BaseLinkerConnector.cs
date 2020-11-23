using RestSharp;
using RestSharp.Serialization.Json;

namespace BaseSubjektIntegrator.BaseLinker
{
	public class BaseLinkerConnector
	{
		private RestClient client;
		private RestRequest request;
		public BaseLinkerConnector(Configuration configuration)
		{
			Configure(configuration);
		}

		public void Configure(Configuration configuration)
		{
			client = new RestClient(configuration.BaseLinkerUrl);
			request = new RestRequest(Method.POST);
			request.AlwaysMultipartFormData = true;
			request.AddParameter("token", configuration.BaseLinkerToken);
			request.AddParameter("method", "getOrders");
		}

		public BaseLinkerOrderModel GetOrderById(int id)
		{
			BaseLinkerOrderModel output = null;
			request.AddParameter("parameters", "{\"order_id\": \"" + id +"\",  \"get_unconfirmed_orders\": \"true\"}");
			IRestResponse response = client.Execute(request);
			if (response.StatusCode == System.Net.HttpStatusCode.OK)
			{
				JsonSerializer jsonSerializer = new JsonSerializer();
				BaseLinkerOrderResponseModel responseObject = jsonSerializer.Deserialize<BaseLinkerOrderResponseModel>(response);

				output = responseObject.Orders.Count > 0 ? responseObject.Orders[0] : null;
			}
			return output;
		}
	}
}
