using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestTimeout.Demo.Configuration
{
	public class MaximumRequestTimeoutSettings
	{
		public int Timeout { get; set; } = 2000;
	}
}
