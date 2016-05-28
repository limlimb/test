namespace ClickMessenger
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.clickIntervalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.configGroupBox = new System.Windows.Forms.GroupBox();
            this.testButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.clickIntervalNumericUpDown)).BeginInit();
            this.configGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(146, 230);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(60, 20);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "開始";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(212, 230);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(60, 20);
            this.stopButton.TabIndex = 1;
            this.stopButton.Text = "停止";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "クリック間隔:";
            // 
            // clickIntervalNumericUpDown
            // 
            this.clickIntervalNumericUpDown.Location = new System.Drawing.Point(73, 20);
            this.clickIntervalNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.clickIntervalNumericUpDown.Name = "clickIntervalNumericUpDown";
            this.clickIntervalNumericUpDown.Size = new System.Drawing.Size(49, 19);
            this.clickIntervalNumericUpDown.TabIndex = 3;
            this.clickIntervalNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "回/秒";
            // 
            // configGroupBox
            // 
            this.configGroupBox.Controls.Add(this.label1);
            this.configGroupBox.Controls.Add(this.label2);
            this.configGroupBox.Controls.Add(this.clickIntervalNumericUpDown);
            this.configGroupBox.Location = new System.Drawing.Point(12, 12);
            this.configGroupBox.Name = "configGroupBox";
            this.configGroupBox.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.configGroupBox.Size = new System.Drawing.Size(259, 212);
            this.configGroupBox.TabIndex = 5;
            this.configGroupBox.TabStop = false;
            this.configGroupBox.Text = "設定";
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(12, 230);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(60, 20);
            this.testButton.TabIndex = 6;
            this.testButton.Text = "テスト";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.configGroupBox);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Name = "MainForm";
            this.Text = "ClickMessenger";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clickIntervalNumericUpDown)).EndInit();
            this.configGroupBox.ResumeLayout(false);
            this.configGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown clickIntervalNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox configGroupBox;
        private System.Windows.Forms.Button testButton;
    }
}

