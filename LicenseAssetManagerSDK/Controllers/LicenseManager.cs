using LicenseAssetManagerSDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LicenseAssetManagerSDK.Controllers
{
    public class LicenseManager
    {
        public LicenseManager() 
        {
            int timeout = 5;
            client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(timeout);
        }

        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        HttpClient client;

        public License license;

        /// <remarks>
        /// Author:      John L Williams Jr
        /// Date:        10/26/2024
        /// Method Name: GetLicense
        /// Description: Checks for a license and returns a license object
        /// Arguments:   string url, string email, int PID, string licenseName
        /// </remarks>
        /// 

        public async Task<License> GetLicense(string _url, string _userName, int _PID, string _licenseName)
		{
			license = new License(_licenseName, _url, _PID, _userName);
            var requestLicense = await RequestLicense(_url);

            if(requestLicense == true)
            {
                license.Approved = true;
            }

            return license;
		}

        async Task<bool> RequestLicense(string uri)
        {
            bool result = false;
            
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                var clientResult = await client.GetStringAsync(uri);
                result = true;
            }
            catch (HttpRequestException e)
            {
                //Console.WriteLine("\nException Caught!");
                //Console.WriteLine("Message :{0} ", e.Message);
                //result = e.Message;
            }

            //MessageBox.Show(result);
            return result;
        }

    }
}
