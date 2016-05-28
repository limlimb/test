using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClickMessenger.Sender;
using ClickMessenger.Helper;

namespace ClickMessenger
{
    public partial class MainForm : Form
    {
        MessageClient client;
        Config config;
        
        public MainForm()
        {
            XmlHelper.Load(out config);
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 設定内容の反映
            // TODO: NofityPropertyChangedの実装をめんどくさがらずにやる
            clickIntervalNumericUpDown.Value = config.ClickInterval;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            client?.Dispose();

            // 設定内容の保存
            SetConfig();
            XmlHelper.Update(config);

            // 解放
            Sender.ImageRecognition.IplImages.Dispose();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            configGroupBox.Enabled = false;

            var flashHandle = FlashHandle.Get();
            SetConfig();
            client = new MessageClient(flashHandle, config);

            stopButton.Enabled = true;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            stopButton.Enabled = false;

            client.Dispose();
            client = null;

            startButton.Enabled = true;
            configGroupBox.Enabled = true;
        }

        void SetConfig()
        {
            config.ClickInterval = (int)clickIntervalNumericUpDown.Value;
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
