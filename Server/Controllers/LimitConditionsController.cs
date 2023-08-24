using Microsoft.AspNetCore.Mvc;
using BlazorWebAssemblySignalRApp.Shared;
using Npgsql;

namespace BlazorWebAssemblySignalRApp.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class LimitConditionsController : ControllerBase
{
	public List<LimitCondition> CheckDatabase()
	{
		try
		{
			string conn_param = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=20056865;Database=sdku;";
			NpgsqlConnection conn = new NpgsqlConnection(conn_param);
			conn.Open();
			string sql = "SELECT * FROM public.\"LimitCondition\"";
			NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
			var reader = comm.ExecuteReader();
			var conditions = new List<LimitCondition>();
			while (reader.Read())
			{
				conditions.Add(new LimitCondition()
				{
					IdSignal = reader.GetInt32(0),
					Id = reader.GetInt32(1),
					Limit = reader.GetString(2),
					Message = reader.GetString(3),
					Sound = reader.GetInt32(4),
					Importance = reader.GetInt32(5),
					Allow = reader.GetString(6)
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
	public IEnumerable<LimitCondition> Get()
	{
		return CheckDatabase().OrderBy(o => o.Id);
	}
}
