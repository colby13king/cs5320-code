using LicenseAssetManagerSDK.Controllers;
using LicenseAssetManagerSDK.Models;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LicenseAssetManagerWpfTestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            licenseManager = new LicenseAssetManagerSDK.Controllers.LicenseManager();

            licenseNamesLB.SelectedIndex = 0;

            userName = "jwilli11";

            this.DataContext = this;
        }


        // This is for LicenseManager
        private LicenseAssetManagerSDK.Controllers.LicenseManager licenseManager;

        /// <remarks>
        /// This is for LicenseManager
        /// </remarks>

        public LicenseAssetManagerSDK.Controllers.LicenseManager LicenseManager
        {
            get => licenseManager;
            set { licenseManager = value; }
        }

        static readonly string url = "http://localhost:5228";


        // 
        private string userName;

        public event PropertyChangedEventHandler? PropertyChanged;

        /// <remarks>
        /// 
        /// </remarks>

        public string UserName
        {
            get => userName;
            set { 
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        // This is for Order PassWord
        private string orderPw;

        /// <remarks>
        /// This is for Order PassWord
        /// </remarks>

        public string OrderPw
        {
            get => orderPw;
            set 
            { 
                orderPw = value;
                OnPropertyChanged("OrderPw");
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            requestResult.Content = "Processing License Request...";
            string? licenseName = (licenseNamesLB.Items.GetItemAt(licenseNamesLB.SelectedIndex) as ListBoxItem)?.Content.ToString();
            //MessageBox.Show($"Attempting to get license for {licenseName}");
            int PID = 1;
            string request = url + $"/myorders/Index/?userName={userName}&passWord={orderPw}";
            requestString.Content = request;

            LicenseAssetManagerSDK.Models.License license = await LicenseManager.GetLicense(url, userName, 1, licenseName, orderPw);
            //MessageBox.Show("License object obtained");
            if (license.Approved)
            {
                requestResult.Content = "License Approved!";
            }
            else
            {
                requestResult.Content = "License Denied!";
            }
        }
    }
}