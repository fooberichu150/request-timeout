# ASP.NET Core Request Timeouts w/IIS in-process mode

Code in this repository was created for my blog post [ASP.NET Core Request Timeout IIS In-Process Mode](https://www.seeleycoder.com/blog/asp-net-core-request-timeout-iis-in-process-mode).

## Getting started

Run the .NET Core application. Available methods:

- `requesttimeout/hasttimeout` - uses the configurable middleware to force a timeout
- `requesttimeout/notimeout` - no timeout configured, waits 10s before returning
- `requesttimeout/ridiculous` - no timeout configured, waits 60s before returning

## Notes
