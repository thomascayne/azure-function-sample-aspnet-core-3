using ApplicationCore.Application.Claims;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PhoneClaimsFunctionsApp;

/**
* courtesy of: https://medium.com/capax-brainpower/azure-functions-v2-dependency-injection-using-net-core-fccd93b80c0
*/
[assembly: WebJobsStartup(typeof(Startup))]
namespace PhoneClaimsFunctionsApp
{
  public class Startup : IWebJobsStartup
  {
    public void Configure(IWebJobsBuilder builder)
    {
      builder.Services.AddScoped<IPhoneClaimsManager, PhoneClaimsManager>();
    }
  }
}
