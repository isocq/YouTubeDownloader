using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
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
using VideoLibrary;

namespace YouTubeDownloader
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void SelectDir_Click(object sender, EventArgs e)
        {
            var DirDlg = new CommonOpenFileDialog("フォルダを選択")
            {
                IsFolderPicker = true
            };
            var ret = DirDlg.ShowDialog();
            if (ret == CommonFileDialogResult.Ok)
            {
                this.SaveDirBox.Text = DirDlg.FileName;
            }
        }

        public void Download_Click(object sender, EventArgs e)
        {
            var youTube = YouTube.Default;
            string link = URLBox.Text;
            var video = youTube.GetVideo(link);
            string DownloadDir = @SaveDirBox.Text;
            string path = System.IO.Path.Combine(DownloadDir, video.FullName);
            File.WriteAllBytes(path, video.GetBytes());
            Log.Text = "完了しました。";
        }
    }
}
