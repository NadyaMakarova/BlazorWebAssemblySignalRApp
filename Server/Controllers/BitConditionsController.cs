using Microsoft.AspNetCore.Mvc;
using BlazorWebAssemblySignalRApp.Shared;
using Npgsql;

namespace BlazorWebAssemblySignalRApp.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class BitConditionsController : ControllerBase
{
	public List<BitCondition> CheckDatabase()
	{
		try
		{
			string conn_param = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=20056865;Database=sdku;";
			NpgsqlConnection conn = new NpgsqlConnection(conn_param);
			conn.Open();
			string sql = "SELECT * FROM public.\"BitConditions\"";
			NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
			var reader = comm.ExecuteReader();
			var conditions = new List<BitCondition>();
			while (reader.Read())
			{
				conditions.Add(new BitCondition()
				{
					IdSignal = reader.GetInt32(0),
					Id = reader.GetInt32(1),
					Allow = reader.GetString(2),
					Message = reader.GetString(3),
					Sound = reader.GetInt32(4),
					Importance = reader.GetInt32(5),
				});
			}
			conn.Close();
			return conditions;
		}
		catch
		{
			return null;
		}
	}

	[HttpGet]
	public IEnumerable<BitCondition> Get()
	{
		return CheckDatabase().OrderBy(o => o.Id);
	}
}
