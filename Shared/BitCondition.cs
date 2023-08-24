using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebAssemblySignalRApp.Shared
{
	public class BitCondition
	{
		public long Id { get; set; }

		public long IdSignal { get; set; }

		public string? Allow { get; set; }

		public string? Message { get; set; }

		public int? Sound { get; set; }

		public int? Importance { get; set; }
	}
}
