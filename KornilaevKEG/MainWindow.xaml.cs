using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KornilaevKEG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new VM.ViewModel();
        }

        private byte[] Message = Encoding.UTF8.GetBytes("Here is some data to encrypt!");
        private byte[] Key = Encoding.UTF8.GetBytes("G-KaPdSgUkXp2s5v8y/B?E(H+MbQeThW");
        private byte[] PublicKey = Encoding.UTF8.GetBytes("MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCbeppZ4rljjH7fKm5zPkgWAgTxK0eWTgUeKg/wAt8qTedp3bhoQj7D2s3tKBdwKJ9HesnKPpal/f1Xf7GcSla4v3JgCLNyEpYpoIKekeW4FNsZxrakCOhg5XSysca/tylOnNvvP5kgROJ04iiJukklV+AaY4PU1LvDApFIqrmeOwIDAQAB");
        private byte[] PrivateKey = Encoding.UTF8.GetBytes("MIICdgIBADANBgkqhkiG9w0BAQEFAASCAmAwggJcAgEAAoGBAJt6mlniuWOMft8qbnM+SBYCBPErR5ZOBR4qD/AC3ypN52nduGhCPsPaze0oF3Aon0d6yco+lqX9/Vd/sZxKVri/cmAIs3ISlimggp6R5bgU2xnGtqQI6GDldLKxxr+3KU6c2+8/mSBE4nTiKIm6SSVX4Bpjg9TUu8MCkUiquZ47AgMBAAECgYAJ6z9vnpQ/MpZhfF6BgaatqMFR9XXis+WFsB9GK5i7JS8vRNLf6+H/MrVSfO1J3X2T3NSEz4ti2ZpQ+7eEBgYUN6j/Og8OhUhrWzflKRLKcpoUmLkWcHSNPisAQ+NIBboscZGNizqbu7V7MPGoGD+RMjT3fgFpQ/ec5qS47hiCgQJBANsstcsD/admqtNqich62Kp1We6kQercfIZh2e+0mswEIP1ITH/hpxcSz7VpqZueqhahyr22Qazs5p4ZHuq48UECQQC1misgGB8a+o3TFEMEUrdoppRCwLF/pYj5HJ3saHuuFmlWeBNc8cQascV6VSFGDqAg9y5XML/zxUGHFkiPPLR7AkA8G13byENnBlPw2PXiYjZLQRWhybA+LauE2w7+mwQc0UEO1SYNqB+/xyvpb4nRIMk6nbJRJsuKFgoE75S4AHJBAkEAoVzovu7QDM/fX1RcrCW3lMSXbqz7yxlSmU+FP8AjTa/aT5wIUIj+oF2fxDCKjU6HmGMqiQznMvruW9NADA57qwJAcHCN81giSY5FAwxQS5Js9KhXSAaiF6Y/0kb02HbQvusCrfepMb9AWSFj52YGabNeospAXfj57AuFabmEWF9gkw==");
        private string Path;

        private void OpenFile_Btn(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Message = File.ReadAllBytes(openFileDialog.FileName);
                Path = openFileDialog.FileName;
                Console.Text += "\nOpen file " + Path + "\n\r\t" + Encoding.UTF8.GetString(Message);
            }
        }

        private void Encrypt_Btn(object sender, RoutedEventArgs e)
        {
            if (Algorithms.SelectedItem is null) throw new ArgumentNullException("Не выбран алгоритм шифрования!");
            using(var fs = new FileStream(Path + "Enc.bin", FileMode.OpenOrCreate))
            {
                var tm = new Stopwatch();
                tm.Start();
                Message = (Algorithms.SelectedItem as Core.Algorithms.IAlgirithm).Encrypt(Message, Key);
                tm.Stop();
                Console.Text += "\nEncrypt "
                    + (Algorithms.SelectedItem as Core.Algorithms.IAlgirithm).Name
                    + " text " + tm.Elapsed.TotalMilliseconds
                    + " milliseconds" + "\n\t\r"
                    + Encoding.UTF8.GetString(Message)
                    + "\n";
                fs.Write(Message);
            }
        }

        private void Decrypt_Btn(object sender, RoutedEventArgs e)
        {
            if (Algorithms.SelectedItem is null) throw new ArgumentNullException("Не выбран алгоритм шифрования!");
            using (var fs = new FileStream(Path + "Dec.bin", FileMode.OpenOrCreate))
            {
                var tm = new Stopwatch();
                tm.Start();
                Message = (Algorithms.SelectedItem as Core.Algorithms.IAlgirithm).Decrypt(Message, Key);
                tm.Stop();
                Console.Text += "\nDecrypt "
                    + (Algorithms.SelectedItem as Core.Algorithms.IAlgirithm).Name
                    + " text " + tm.Elapsed.TotalMilliseconds
                    + " milliseconds"
                    + "\n\t\r" + Encoding.UTF8.GetString(Message)
                    + "\n";
                fs.Write(Message);
            }
        }
    }
}
