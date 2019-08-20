using System;
using System.IO;
using System.Threading.Tasks;

namespace ApplicationCore.Application.Claims
{
  public class PhoneClaimsManager : IPhoneClaimsManager
  {
    public async Task<bool> ManageClaimAsync(PhoneClaimModel phoneClaimModel)
    {
      if (string.IsNullOrEmpty(phoneClaimModel.FileName))
      {
        throw new InvalidDataException("Filename cannot be null or empty");
      }

      return await Task.Run(() =>
      {
        Task.Delay(TimeSpan.FromSeconds(1));
        return true;
      });
    }
  }
}
