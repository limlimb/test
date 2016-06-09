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
            this.comboStartButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboStopButton = new System.Windows.Forms.Button();
            this.progressionButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nextMapButton = new System.Windows.Forms.Button();
            this.previousMapButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.clickIntervalNumericUpDown)).BeginInit();
            this.configGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(146, 124);
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
            this.stopButton.Location = new System.Drawing.Point(212, 124);
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
            this.configGroupBox.Size = new System.Drawing.Size(259, 50);
            this.configGroupBox.TabIndex = 5;
            this.configGroupBox.TabStop = false;
            this.configGroupBox.Text = "設定";
            // 
            // comboStartButton
            // 
            this.comboStartButton.Location = new System.Drawing.Point(127, 78);
            this.comboStartButton.Name = "comboStartButton";
            this.comboStartButton.Size = new System.Drawing.Size(60, 20);
            this.comboStartButton.TabIndex = 6;
            this.comboStartButton.Text = "開始";
            this.comboStartButton.UseVisualStyleBackColor = true;
            this.comboStartButton.Click += new System.EventHandler(this.comboStartButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboStopButton);
            this.groupBox1.Controls.Add(this.comboStartButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 162);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox1.Size = new System.Drawing.Size(259, 105);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DRコンボ";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("メイリオ", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 53);
            this.label3.TabIndex = 8;
            this.label3.Text = "123457869→15分待機→89123457→2分半待機→12→2分半待機→12→2分半待機→1234→2分半待機→12→2分半待機→(12)→2分半待機→最" +
    "初に戻る";
            // 
            // comboStopButton
            // 
            this.comboStopButton.Enabled = false;
            this.comboStopButton.Location = new System.Drawing.Point(193, 78);
            this.comboStopButton.Name = "comboStopButton";
            this.comboStopButton.Size = new System.Drawing.Size(60, 20);
            this.comboStopButton.TabIndex = 7;
            this.comboStopButton.Text = "停止";
            this.comboStopButton.UseVisualStyleBackColor = true;
            this.comboStopButton.Click += new System.EventHandler(this.comboStopButton_Click);
            // 
            // progressionButton
            // 
            this.progressionButton.Location = new System.Drawing.Point(6, 18);
            this.progressionButton.Name = "progressionButton";
            this.progressionButton.Size = new System.Drawing.Size(23, 20);
            this.progressionButton.TabIndex = 5;
            this.progressionButton.Text = "靴";
            this.progressionButton.UseVisualStyleBackColor = true;
            this.progressionButton.Click += new System.EventHandler(this.progressionButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nextMapButton);
            this.groupBox2.Controls.Add(this.previousMapButton);
            this.groupBox2.Controls.Add(this.progressionButton);
            this.groupBox2.Location = new System.Drawing.Point(12, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox2.Size = new System.Drawing.Size(259, 50);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "特定箇所のクリック";
            // 
            // nextMapButton
            // 
            this.nextMapButton.Location = new System.Drawing.Point(64, 18);
            this.nextMapButton.Name = "nextMapButton";
            this.nextMapButton.Size = new System.Drawing.Size(23, 20);
            this.nextMapButton.TabIndex = 7;
            this.nextMapButton.Text = "→";
            this.nextMapButton.UseVisualStyleBackColor = true;
            this.nextMapButton.Click += new System.EventHandler(this.nextMapButton_Click);
            // 
            // previousMapButton
            // 
            this.previousMapButton.Location = new System.Drawing.Point(35, 18);
            this.previousMapButton.Name = "previousMapButton";
            this.previousMapButton.Size = new System.Drawing.Size(23, 20);
            this.previousMapButton.TabIndex = 6;
            this.previousMapButton.Text = "←";
            this.previousMapButton.UseVisualStyleBackColor = true;
            this.previousMapButton.Click += new System.EventHandler(this.previousMapButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 274);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.configGroupBox);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "ClickMessenger";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clickIntervalNumericUpDown)).EndInit();
            this.configGroupBox.ResumeLayout(false);
            this.configGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown clickIntervalNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox configGroupBox;
        private System.Windows.Forms.Button comboStartButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button comboStopButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button progressionButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button nextMapButton;
        private System.Windows.Forms.Button previousMapButton;
    }
}

