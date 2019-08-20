using System.Threading.Tasks;

namespace ApplicationCore.Application.Claims
{
  public interface IPhoneClaimsManager
  {
    Task<bool> ManageClaimAsync(PhoneClaimModel phoneClaimModel);
  }
}
