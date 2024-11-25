using LicenseAssetManagerSDK.Controllers;
using LicenseAssetManagerSDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLicenseAssetManager
{
    public class UniTestLicenseManager
    {
        [Fact]

        public async void TestGetLicense()
        {
            LicenseManager licenseManager = new LicenseManager();

            Assert.NotNull(licenseManager);

            string url = "http://www.google.com";
            string email = "jwilli11@uccs.edu";
            int PID = 1;
            string licenseName = "Best_CAD";
            License license = await licenseManager.GetLicense(url, email, PID, licenseName);
            Assert.NotNull(license);
            Assert.True(license.Approved);

        }
    }
}
