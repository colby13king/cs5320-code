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
        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        static readonly HttpClient client = new HttpClient();

        /// <remarks>
        /// Author:      John L Williams Jr
        /// Date:        10/26/2024
        /// Method Name: GetLicense
        /// Description: Checks for a license and returns a license object
        /// Arguments:   string url, string email, int PID, string licenseName
        /// </remarks>
        /// 

        public License GetLicense(string _url, string _userName, int _PID, string _licenseName)
		{
			License license = new License(_licenseName, _url, _PID, _userName);
			license.Approved = true;

			return license;
		}

        async Task<string> RequestLicense(string uri)
        {
            string result = "No license";

            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                //using HttpResponseMessage response = await client.GetAsync("http://www.google.com/");
                //response.EnsureSuccessStatusCode();
                //result = await response.Content.ReadAsStringAsync();

                // Above three lines can be replaced with new helper method below
                result = await client.GetStringAsync(uri);



            }
            catch (HttpRequestException e)
            {
                //Console.WriteLine("\nException Caught!");
                //Console.WriteLine("Message :{0} ", e.Message);
                result = e.Message;
            }

            //MessageBox.Show(result);
            return result;
        }

    }
}
