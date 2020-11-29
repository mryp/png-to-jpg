
namespace PngToJpg
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.folderPathTextBox = new System.Windows.Forms.TextBox();
            this.folderPathRefButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.qualityNumeric = new System.Windows.Forms.NumericUpDown();
            this.startButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progressStatusLabel = new System.Windows.Forms.Label();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.qualityNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "フォルダパス：";
            // 
            // folderPathTextBox
            // 
            this.folderPathTextBox.Location = new System.Drawing.Point(109, 12);
            this.folderPathTextBox.Name = "folderPathTextBox";
            this.folderPathTextBox.Size = new System.Drawing.Size(550, 27);
            this.folderPathTextBox.TabIndex = 1;
            // 
            // folderPathRefButton
            // 
            this.folderPathRefButton.Location = new System.Drawing.Point(665, 11);
            this.folderPathRefButton.Name = "folderPathRefButton";
            this.folderPathRefButton.Size = new System.Drawing.Size(94, 29);
            this.folderPathRefButton.TabIndex = 2;
            this.folderPathRefButton.Text = "参照";
            this.folderPathRefButton.UseVisualStyleBackColor = true;
            this.folderPathRefButton.Click += new System.EventHandler(this.folderPathRefButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "品質：";
            // 
            // qualityNumeric
            // 
            this.qualityNumeric.Location = new System.Drawing.Point(109, 45);
            this.qualityNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.qualityNumeric.Name = "qualityNumeric";
            this.qualityNumeric.Size = new System.Drawing.Size(116, 27);
            this.qualityNumeric.TabIndex = 4;
            this.qualityNumeric.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 90);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(747, 53);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "処理開始";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 149);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(747, 29);
            this.progressBar.TabIndex = 6;
            // 
            // progressStatusLabel
            // 
            this.progressStatusLabel.AutoSize = true;
            this.progressStatusLabel.Location = new System.Drawing.Point(12, 181);
            this.progressStatusLabel.Name = "progressStatusLabel";
            this.progressStatusLabel.Size = new System.Drawing.Size(54, 20);
            this.progressStatusLabel.TabIndex = 7;
            this.progressStatusLabel.Text = "未処理";
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 213);
            this.Controls.Add(this.progressStatusLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.qualityNumeric);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.folderPathRefButton);
            this.Controls.Add(this.folderPathTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Png to Jpg";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qualityNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button folderPathRefButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown qualityNumeric;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox folderPathTextBox;
        private System.Windows.Forms.Label progressStatusLabel;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}

