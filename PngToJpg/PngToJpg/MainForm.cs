using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PngToJpg
{
    public partial class MainForm : Form
    {
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
    }
}
