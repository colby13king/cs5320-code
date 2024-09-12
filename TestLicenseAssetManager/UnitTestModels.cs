using LicenseAssetManager.Models;

namespace TestLicenseAssetManager
{
    public class UnitTestModels
    {
        [Fact]
        public void TestErrorViewModel()
        {
            ErrorViewModel errorViewModel = new ErrorViewModel();
            Assert.NotNull(errorViewModel);

        }
    }
}