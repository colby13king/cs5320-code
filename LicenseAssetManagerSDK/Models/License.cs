using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseAssetManagerSDK.Models
{
    public class License
    {
		public License(string _name, string _url, int _pid, string _userName) 
		{
			approved = false;
			name = _name;
			url = _url;
			pid = _pid;
			userName = _userName;
		}

		// This is for Name
		private string name;

		/// <remarks>
		/// This is for Name
		/// </remarks>

		public string Name
		{
			get => name;
			set { name = value; }
		}

		// This is for approved
		private bool approved;

		/// <remarks>
		/// This is for approved
		/// </remarks>

		public bool Approved
		{
			get => approved;
			set { approved = value; }
		}


		// This is for URL
		private string url;

		/// <remarks>
		/// This is for URL
		/// </remarks>

		public string URL
		{
			get => url;
			set { url = value; }
		}

		// This is for PID
		private int pid;

		/// <remarks>
		/// This is for PID
		/// </remarks>

		public int PID
		{
			get => pid;
			set { pid = value; }
		}

		// This is for userName
		private string userName;

		/// <remarks>
		/// This is for userName
		/// </remarks>

		public string UserName
		{
			get => userName;
			set { userName = value; }
		}





	}
}
