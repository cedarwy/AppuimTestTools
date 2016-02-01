namespace AppuimTestTools
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查找手机ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置结果保存路径ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.获取最新的APKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置SDK的路径ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.比较测试结果ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.相同界面时间比较ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.手机操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.连续4次截图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.解apk包ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_sdkpath = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lb_respath = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.操作ToolStripMenuItem,
            this.手机操作ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1094, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查找手机ToolStripMenuItem,
            this.设置结果保存路径ToolStripMenuItem,
            this.获取最新的APKToolStripMenuItem,
            this.设置SDK的路径ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 查找手机ToolStripMenuItem
            // 
            this.查找手机ToolStripMenuItem.Name = "查找手机ToolStripMenuItem";
            this.查找手机ToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.查找手机ToolStripMenuItem.Text = "查找手机";
            // 
            // 设置结果保存路径ToolStripMenuItem
            // 
            this.设置结果保存路径ToolStripMenuItem.Name = "设置结果保存路径ToolStripMenuItem";
            this.设置结果保存路径ToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.设置结果保存路径ToolStripMenuItem.Text = "设置结果保存路径";
            this.设置结果保存路径ToolStripMenuItem.Click += new System.EventHandler(this.设置结果保存路径ToolStripMenuItem_Click);
            // 
            // 获取最新的APKToolStripMenuItem
            // 
            this.获取最新的APKToolStripMenuItem.Name = "获取最新的APKToolStripMenuItem";
            this.获取最新的APKToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.获取最新的APKToolStripMenuItem.Text = "获取最新的APK";
            this.获取最新的APKToolStripMenuItem.Click += new System.EventHandler(this.获取最新的APKToolStripMenuItem_Click);
            // 
            // 设置SDK的路径ToolStripMenuItem
            // 
            this.设置SDK的路径ToolStripMenuItem.Name = "设置SDK的路径ToolStripMenuItem";
            this.设置SDK的路径ToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.设置SDK的路径ToolStripMenuItem.Text = "设置SDK的路径";
            this.设置SDK的路径ToolStripMenuItem.Click += new System.EventHandler(this.设置SDK的路径ToolStripMenuItem_Click);
            // 
            // 操作ToolStripMenuItem
            // 
            this.操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.比较测试结果ToolStripMenuItem,
            this.相同界面时间比较ToolStripMenuItem});
            this.操作ToolStripMenuItem.Name = "操作ToolStripMenuItem";
            this.操作ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.操作ToolStripMenuItem.Text = "测试行为";
            // 
            // 比较测试结果ToolStripMenuItem
            // 
            this.比较测试结果ToolStripMenuItem.Name = "比较测试结果ToolStripMenuItem";
            this.比较测试结果ToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.比较测试结果ToolStripMenuItem.Text = "比较测试结果";
            this.比较测试结果ToolStripMenuItem.Click += new System.EventHandler(this.比较测试结果ToolStripMenuItem_Click);
            // 
            // 相同界面时间比较ToolStripMenuItem
            // 
            this.相同界面时间比较ToolStripMenuItem.Name = "相同界面时间比较ToolStripMenuItem";
            this.相同界面时间比较ToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.相同界面时间比较ToolStripMenuItem.Text = "相同界面时间比较";
            this.相同界面时间比较ToolStripMenuItem.Click += new System.EventHandler(this.相同界面时间比较ToolStripMenuItem_Click);
            // 
            // 手机操作ToolStripMenuItem
            // 
            this.手机操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.连续4次截图ToolStripMenuItem,
            this.解apk包ToolStripMenuItem});
            this.手机操作ToolStripMenuItem.Name = "手机操作ToolStripMenuItem";
            this.手机操作ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.手机操作ToolStripMenuItem.Text = "手机操作";
            // 
            // 连续4次截图ToolStripMenuItem
            // 
            this.连续4次截图ToolStripMenuItem.Name = "连续4次截图ToolStripMenuItem";
            this.连续4次截图ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.连续4次截图ToolStripMenuItem.Text = "连续4次截图";
            this.连续4次截图ToolStripMenuItem.Click += new System.EventHandler(this.连续4次截图ToolStripMenuItem_Click);
            // 
            // 解apk包ToolStripMenuItem
            // 
            this.解apk包ToolStripMenuItem.Name = "解apk包ToolStripMenuItem";
            this.解apk包ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.解apk包ToolStripMenuItem.Text = "解apk包";
            this.解apk包ToolStripMenuItem.Click += new System.EventHandler(this.解apk包ToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_sdkpath);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.lb_respath);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(27, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 200);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置相关";
            // 
            // lb_sdkpath
            // 
            this.lb_sdkpath.AutoSize = true;
            this.lb_sdkpath.Location = new System.Drawing.Point(148, 76);
            this.lb_sdkpath.Name = "lb_sdkpath";
            this.lb_sdkpath.Size = new System.Drawing.Size(0, 15);
            this.lb_sdkpath.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "androidSDK路径：";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(23, 155);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 39);
            this.button2.TabIndex = 4;
            this.button2.Text = "刷新";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(124, 118);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(181, 23);
            this.comboBox1.TabIndex = 3;
            // 
            // lb_respath
            // 
            this.lb_respath.AutoSize = true;
            this.lb_respath.Location = new System.Drawing.Point(129, 40);
            this.lb_respath.Name = "lb_respath";
            this.lb_respath.Size = new System.Drawing.Size(0, 15);
            this.lb_respath.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "结果保存路径：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前手机ID：";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(27, 268);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(342, 304);
            this.listBox1.TabIndex = 2;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(438, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(522, 159);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "测试说明";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "运行测试";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "测试描述：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "测试名称：";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(438, 232);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(644, 339);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(981, 171);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 33);
            this.button3.TabIndex = 5;
            this.button3.Text = "特别功能";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 583);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查找手机ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置结果保存路径ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 比较测试结果ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lb_respath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem 获取最新的APKToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem 设置SDK的路径ToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lb_sdkpath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem 相同界面时间比较ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 手机操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 连续4次截图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 解apk包ToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button3;
    }
}

