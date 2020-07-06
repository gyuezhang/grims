using FluentFTP;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FTPClient
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private static FtpClient CreateFtpClient()
        {
            return new FtpClient("192.168.207.129", new System.Net.NetworkCredential { UserName = "ftpuser", Password = "Aa1111" });
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFile = new Microsoft.Win32.OpenFileDialog();

            if (openFile.ShowDialog() != true)
                return;

            string filePath = openFile.FileName;

            using (FtpClient ftp = CreateFtpClient())
            {
                await ftp.UploadFileAsync(filePath, System.IO.Path.GetFileName(filePath));
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (FtpClient ftp = CreateFtpClient())
            {
                foreach (FtpListItem item in ftp.GetListing("/list"))
                {

                    // if this is a file
                    if (item.Type == FtpFileSystemObjectType.File)
                    {

                        // get the file size
                        long size = ftp.GetFileSize(item.FullName);

                        // calculate a hash for the file on the server side (default algorithm)
                        FtpHash hash = ftp.GetChecksum(item.FullName);
                    }

                    // get modified date/time of the file or folder
                    DateTime time = ftp.GetModifiedTime(item.FullName);

                }
            }
            
        }

        private  void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using (FtpClient ftp = CreateFtpClient())
            {
                FolderBrowserDialog openFolder = new FolderBrowserDialog();

                openFolder.ShowDialog();
                

                string filePath = openFolder.SelectedPath;

                 ftp.DownloadFile(@"C:\Users\Gyue\Desktop\Wiki\3.txt", "/list/3.txt");
            }
        }
    }
}
