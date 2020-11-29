using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PngToJpg
{
    public partial class MainForm : Form
    {
        protected class WorkerParam
        {
            public string FolderPath { get; set; } = "";
            public int Quality { get; set; } = 100;

            public override string ToString()
            {
                return $"{FolderPath},{Quality}";
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            Log.Info("アプリケーション起動");
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log.Info("アプリケーション終了");
        }

        private void folderPathRefButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                folderPathTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (bgWorker.IsBusy)
            {
                return;
            }

            var folderPath = folderPathTextBox.Text;
            if (string.IsNullOrEmpty(folderPath))
            {
                MessageBox.Show("フォルダパスが指定されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show("フォルダパスが存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            startButton.Enabled = false;
            bgWorker.RunWorkerAsync(new WorkerParam()
            {
                FolderPath = folderPath,
                Quality = (int)qualityNumeric.Value,
            });
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (sender is not BackgroundWorker worker)
            {
                Log.Error("sender is not BackgroundWorker");
                e.Result = "処理パラメーターエラー";
                return;
            }
            if (e.Argument is not WorkerParam param)
            {
                Log.Error("e.Argument is not WorkerParam");
                e.Result = "処理パラメーターエラー";
                return;
            }

            Log.Info($"処理開始 param={param}");
            var fileList = Directory.GetFiles(param.FolderPath, "*.png", SearchOption.AllDirectories);
            if (fileList.Length == 0)
            {
                Log.Warn("フォルダ内にPNGファイルが見つからない");
                e.Result = "指定されたフォルダ内にPNGファイルが見つかりません";
                return;
            }

            worker.ReportProgress(fileList.Length);
            var pos = 0;
            var successCount = 0;
            var errorCount = 0;
            foreach (var file in fileList)
            {
                pos++;
                worker.ReportProgress(pos, Path.GetFileName(file));
                if (worker.CancellationPending)
                {
                    Log.Info("処理キャンセル検知");
                    e.Cancel = true;
                    return;
                }

                Log.Info($"処理ファイル={file}");
                if (pngToJpg(file, param.Quality))
                {
                    successCount++;
                }
                else
                {
                    errorCount++;
                }
            }

            Log.Info("処理完了");
            e.Result = $"処理結果 成功={successCount} 失敗={errorCount}";
        }

        private static bool pngToJpg(string pngFile, int quality)
        {
            var dirPath = Path.GetDirectoryName(pngFile);
            if (dirPath == null)
            {
                Log.Warn($"ファイルパスはフルパスで指定してください file={pngFile}");
                return false;
            }
            var outputPath = Path.Combine(dirPath, Path.GetFileNameWithoutExtension(pngFile)+".jpg");
            if (File.Exists(outputPath))
            {
                Log.Warn($"ファイルが既に存在しています file={outputPath}");
                return false;
            }

            try
            {
                var image = Image.FromFile(pngFile);
                JpegFile.SaveImageQuality(outputPath, image, quality);
            }
            catch (Exception e)
            {
                Log.Error(e, "変換処理例外");
                return false;
            }

            return true;
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var message = "";
            if (e.UserState != null)
            {
                message = e.UserState.ToString();
            }

            if (message == "")
            {
                progressBar.Maximum = e.ProgressPercentage;
                progressBar.Value = 0;
                progressStatusLabel.Text = "";
            }
            else
            {
                progressBar.Value = e.ProgressPercentage;
                progressStatusLabel.Text = message;
            }
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            startButton.Enabled = true;
            if (e.Cancelled)
            {
                MessageBox.Show("キャンセルされました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                progressStatusLabel.Text = "キャンセルされました";
            }
            else if (e.Result == null)
            {
                MessageBox.Show("想定外のエラーが発生しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressStatusLabel.Text = "想定外のエラーが発生しました";
            }
            else
            {
                MessageBox.Show(e.Result.ToString(), "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                progressStatusLabel.Text = e.Result.ToString();
            }
        }
    }
}
