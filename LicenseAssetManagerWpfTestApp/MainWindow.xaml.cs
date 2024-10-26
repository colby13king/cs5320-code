using LicenseAssetManagerSDK.Controllers;
using LicenseAssetManagerSDK.Models;
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            licenseManager = new LicenseManager();

            licenseNamesLB.SelectedIndex = 0;
        }


        // This is for LicenseManager
        private LicenseManager licenseManager;

        /// <remarks>
        /// This is for LicenseManager
        /// </remarks>

        public LicenseManager LicenseManager
        {
            get => licenseManager;
            set { licenseManager = value; }
        }

        static readonly string url = "http://www.google.com";

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string? licenseName = (licenseNamesLB.Items.GetItemAt(licenseNamesLB.SelectedIndex) as ListBoxItem)?.Content.ToString();
            //MessageBox.Show($"Attempting to get license for {licenseName}");
            int PID = 1;
            requestString.Content = url + ":" + emailTB.Text + ":" + PID + ":" + licenseName;
            License license = LicenseManager.GetLicense(url, emailTB.Text, 1, licenseName);
            //MessageBox.Show("License object obtained");
            if (!license.Approved)
            {
                requestResult.Content = "License Denied!";
            }

            //MessageBox.Show("License approved");
            requestResult.Content = "License Approved!";
        }
    }
}