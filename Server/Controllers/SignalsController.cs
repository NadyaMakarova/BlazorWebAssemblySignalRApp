using Microsoft.AspNetCore.Mvc;
using BlazorWebAssemblySignalRApp.Shared;
using Npgsql;

namespace BlazorWebAssemblySignalRApp.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class SignalsController : ControllerBase
{
	public List<Signal> CheckDatabase()
	{
		try
		{
			string conn_param = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=20056865;Database=sdku;";
			NpgsqlConnection conn = new NpgsqlConnection(conn_param);
			conn.Open();
			string sql = "SELECT * FROM public.\"Signals\"";
			NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
			var reader = comm.ExecuteReader();
			var signals = new List<Signal>();
			while (reader.Read())
			{
				signals.Add(new Signal()
				{
					Id = reader.GetInt32(0),
					Formula = reader.GetString(1),
					Value = reader.GetDouble(2),
					Quality = reader.GetString(3),
					Date = reader.GetDateTime(4),
					Time = reader.GetTimeSpan(5),
					Type = reader.GetString(6),
					Description = reader.GetString(7),
					Procedure = reader.GetString(8),
					Message = reader.GetString(9),
					Sound = reader.GetInt32(10)
				});
			}
			conn.Close();
			return signals;
		}
		catch (Exception ex)
		{
			return null;
		}
	}

	[HttpGet]
	public IEnumerable<Signal> Get()
	{
		return CheckDatabase().OrderBy(o => o.Id);
	}
}
