using ApplicationCore.Application.Claims;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PhoneClaimsFunctionsApp
{
  public class BlobTriggeredInboundPhoneClaimFunction
  {
    private readonly IPhoneClaimsManager PhoneClaimsManager;

    public BlobTriggeredInboundPhoneClaimFunction(IPhoneClaimsManager phoneClaimsManager) => PhoneClaimsManager = phoneClaimsManager;

    [FunctionName("BlobTriggeredInboundPhoneClaimFunction")]
    public async Task Run([BlobTrigger("inbound-phone-claims/{name}",
      Connection = "StorageConnectionSettings")]Stream blobBlob,
      string name, ILogger log)
    {
      log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {blobBlob.Length} Bytes");

      try
      {
        var processed = await PhoneClaimsManager.ManageClaimAsync(new PhoneClaimModel(name, blobBlob));

        if (processed)
        {
          log.LogInformation($"Successfully processed {name}");
        }
        else
        {
          log.LogWarning($"failed to process {name}");
        }
      }
      catch (Exception exception)
      {
        log.LogError(exception.Message, exception);
        throw;
      }
    }
  }
}
