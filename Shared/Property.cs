using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebAssemblySignalRApp.Shared
{
	public class Property
	{
		public long Id { get; set; }

		public long IdSignal { get; set; }

		public string? ShortName { get; set; }

		public string? Description { get; set; }

		public int? Number { get; set; }
	}
}
