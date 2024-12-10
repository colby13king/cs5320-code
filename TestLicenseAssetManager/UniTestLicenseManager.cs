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

            string url = "http://localhost:5228";
            string email = "jwilli11";
            string passWord = "123";
            int PID = 1;
            string licenseName = "BestCAD";
            License license = await licenseManager.GetLicense(url, email, PID, licenseName, passWord);
            Assert.NotNull(license);
            Assert.False(license.Approved);

        }
    }
}
