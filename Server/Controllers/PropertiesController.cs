using Microsoft.AspNetCore.Mvc;
using BlazorWebAssemblySignalRApp.Shared;
using Npgsql;

namespace BlazorWebAssemblySignalRApp.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class PropertiesController : ControllerBase
{
	public List<Property> CheckDatabase()
	{
		try
		{
			string conn_param = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=20056865;Database=sdku;";
			NpgsqlConnection conn = new NpgsqlConnection(conn_param);
			conn.Open();
			string sql = "SELECT * FROM public.\"Properties\"";
			NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
			var reader = comm.ExecuteReader();
			var properties = new List<Property>();
			while (reader.Read())
			{
				properties.Add(new Property()
				{
					IdSignal = reader.GetInt32(0),
					Id = reader.GetInt32(1),
					ShortName = reader.GetString(2),
					Description = reader.GetString(3),
					Number = reader.GetInt32(4)
				});
			}
			conn.Close();
			return properties;
		}
		catch
		{
			return null;
		}
	}

	[HttpGet]
	public IEnumerable<Property> Get()
	{
		return CheckDatabase().OrderBy(o => o.Id);
	}
}
