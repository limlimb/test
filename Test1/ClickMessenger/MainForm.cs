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
        ComboClient comboClient;
        Config config;

        const int WM_HOTKEY = 0x0312;
        const int HOTKEY_ID = 0x0001;

        public MainForm()
        {
            // 設定の読み込み
            XmlHelper.Load(out config);
            // ホットキーの登録
            Native.NativeMethods.RegisterHotKey(this.Handle, HOTKEY_ID, 0, (int)Keys.F2);

            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 設定内容の反映
            // TODO: NofityPropertyChangedの実装をめんどくさがらずにやる
            clickIntervalNumericUpDown.Value = config.ClickInterval;
            clickCheckBox.Checked = config.DontClick;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // ホットキーの解除
            Native.NativeMethods.UnregisterHotKey(this.Handle, HOTKEY_ID);

            // 設定内容の保存
            SetConfig();
            XmlHelper.Update(config);

            // 解放
            client?.Dispose();
            comboClient?.Dispose();
            Sender.ImageRecognition.IplImages.Dispose();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            configGroupBox.Enabled = false;
            clickGroupBox.Enabled = true;

            IntPtr flashHandle;
            try
            {
                flashHandle = FlashHandle.Get();
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("FlashPlayerのハンドルが見つかりません。\r\n"
                    +"IEでClickerHeroesを開いてください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                startButton.Enabled = true;
                configGroupBox.Enabled = true;
                clickGroupBox.Enabled = false;
                return;
            }
            
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
            clickGroupBox.Enabled = false;
        }

        void SetConfig()
        {
            config.ClickInterval = (int)clickIntervalNumericUpDown.Value;
            config.DontClick = clickCheckBox.Checked;
        }

        private void comboStartButton_Click(object sender, EventArgs e)
        {
            comboStartButton.Enabled = false;

            IntPtr flashHandle;
            try
            {
                flashHandle = FlashHandle.Get();
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("FlashPlayerのハンドルが見つかりません。\r\n"
                    + "IEでClickerHeroesを開いてください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboStartButton.Enabled = true;
                return;
            }

            comboClient = new ComboClient(flashHandle);
            comboStopButton.Enabled = true;
        }

        private void comboStopButton_Click(object sender, EventArgs e)
        {
            comboStopButton.Enabled = false;

            comboClient.Dispose();
            comboClient = null;

            comboStartButton.Enabled = true;
        }

        private void progressionButton_Click(object sender, EventArgs e)
        {
            client?.ProgressiveClick();
        }

        private void previousMapButton_Click(object sender, EventArgs e)
        {
            client?.PreviousMapClick();
        }

        private void nextMapButton_Click(object sender, EventArgs e)
        {
            client?.NextMapClick();
        }

        private void clickCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (clickCheckBox.Checked)
            {
                config.DontClick = true;
                clickIntervalNumericUpDown.Enabled = false;
            }
            else
            {
                config.DontClick = false;
                clickIntervalNumericUpDown.Enabled = true;
            }
        }

        #region Form

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_HOTKEY)
            {
                if ((int)m.WParam == HOTKEY_ID)
                {
                    // 実行中かどうかのフラグを明確に立てるべき
                    if (client == null) startButton.PerformClick();
                    else stopButton.PerformClick();
                }
            }
        }

        #endregion
    }
}
