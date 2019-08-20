using ApplicationCore.Application.Claims;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationCore.Tests.Application.Claims
{

  public class PhoneClaimsManagerTests
  {
    [Fact]
    public async Task ManageClaimAsync_GivenNoValidationIssues_ThenTrueResultIsReturned()
    {

      // arrange
      var manager = new PhoneClaimsManager();


      // act
      var model = new PhoneClaimModel("filename.txt", new MemoryStream());
      var result = await manager.ManageClaimAsync(model);

      // assert
      Assert.True(result);

    }

    [Fact]
    public async Task ManageClaimAsync_GivenInvalidFileName_ThenInvalidDataExceptionIsThrown()
    {
      // arrange
      var manager = new PhoneClaimsManager();
      var model = new PhoneClaimModel(null, new MemoryStream());

      // assert
      await Assert.ThrowsAsync<InvalidDataException>(async () => await manager.ManageClaimAsync(model));

    }
  }
}
