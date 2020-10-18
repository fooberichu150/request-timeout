using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RequestTimeout.Demo.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RequestTimeoutController : ControllerBase
	{
		private const int DELAY_10 = 10000;
		private const int DELAY_60 = 60000;
		private readonly ILogger<RequestTimeoutController> _logger;

		public RequestTimeoutController(ILogger<RequestTimeoutController> logger)
		{
			_logger = logger;
		}

		[HttpGet("hastimeout")]
		public async Task<IActionResult> GetTimeout(CancellationToken cancellationToken)
		{
			var profiler = new System.Diagnostics.Stopwatch();
			profiler.Start();

			try
			{
				await Task.Delay(DELAY_10, cancellationToken);
			}
			catch (OperationCanceledException opEx)
			{
				profiler.Stop();
				_logger.LogError(opEx, $"Operation canceled and returned after {profiler.ElapsedMilliseconds}ms");

				return StatusCode((int)HttpStatusCode.RequestTimeout);
			}
			finally
			{
				if (profiler.IsRunning)
					profiler.Stop();
			}

			return Ok("Waited 10s");
		}

		[HttpGet("notimeout")]
		public async Task<IActionResult> NoTimeout(CancellationToken cancellationToken)
		{
			await Task.Delay(DELAY_10, cancellationToken);

			return Ok("Waited 10s");
		}

		[HttpGet("ridiculous")]
		public async Task<IActionResult> RidiculousWait(CancellationToken cancellationToken)
		{
			await Task.Delay(60000, cancellationToken);

			return Ok("Waited 10s");
		}
	}
}
