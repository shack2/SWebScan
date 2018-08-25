namespace SWebVulnsScan
{
    partial class FrmMain
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.使用手册ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_about = new System.Windows.Forms.ToolStripMenuItem();
            this.在线更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbox_timeOut = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.cbox_threadSize = new System.Windows.Forms.ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lvw_info = new System.Windows.Forms.ListView();
            this.column_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_url = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_response = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_contentType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_length = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_server = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_X_Powered_By = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_runTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_ip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctx_dirscan = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_exportZWInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_exportDirInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_delete_item = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_copyURL = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_clearResult = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.lbl_speed = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_waitCount = new System.Windows.Forms.Label();
            this.lbl_scanedCount = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lbl_usedtime = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lbl_c_url = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.lbl_dirs_sum = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_sumDomains = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.cbox_isExists = new System.Windows.Forms.ComboBox();
            this.cbox_show = new System.Windows.Forms.ComboBox();
            this.cbox_length = new System.Windows.Forms.ComboBox();
            this.cbox_sleepTime = new System.Windows.Forms.ComboBox();
            this.chk_404Mode = new System.Windows.Forms.CheckBox();
            this.chkList_dir = new System.Windows.Forms.CheckedListBox();
            this.cbox_ext = new System.Windows.Forms.ComboBox();
            this.chk_getBanner = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_404_keys = new System.Windows.Forms.TextBox();
            this.txt_contentLength = new System.Windows.Forms.TextBox();
            this.txt_contentType = new System.Windows.Forms.TextBox();
            this.txt_showCodes = new System.Windows.Forms.TextBox();
            this.chk_fastMode = new System.Windows.Forms.CheckBox();
            this.btn_import = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.cbox_method = new System.Windows.Forms.ComboBox();
            this.btn_stop = new System.Windows.Forms.Button();
            this.txt_web = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.timer_scandir = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.ctx_dirscan.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.菜单ToolStripMenuItem,
            this.系统设置ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(997, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 菜单ToolStripMenuItem
            // 
            this.菜单ToolStripMenuItem.Name = "菜单ToolStripMenuItem";
            this.菜单ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.菜单ToolStripMenuItem.Text = "菜单";
            // 
            // 系统设置ToolStripMenuItem
            // 
            this.系统设置ToolStripMenuItem.Name = "系统设置ToolStripMenuItem";
            this.系统设置ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.系统设置ToolStripMenuItem.Text = "系统设置";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.使用手册ToolStripMenuItem,
            this.tsmi_about,
            this.在线更新ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 使用手册ToolStripMenuItem
            // 
            this.使用手册ToolStripMenuItem.Name = "使用手册ToolStripMenuItem";
            this.使用手册ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.使用手册ToolStripMenuItem.Text = "使用手册";
            // 
            // tsmi_about
            // 
            this.tsmi_about.Name = "tsmi_about";
            this.tsmi_about.Size = new System.Drawing.Size(124, 22);
            this.tsmi_about.Text = "关 于";
            this.tsmi_about.Click += new System.EventHandler(this.tsmi_about_Click);
            // 
            // 在线更新ToolStripMenuItem
            // 
            this.在线更新ToolStripMenuItem.Name = "在线更新ToolStripMenuItem";
            this.在线更新ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.在线更新ToolStripMenuItem.Text = "在线更新";
            this.在线更新ToolStripMenuItem.Click += new System.EventHandler(this.在线更新ToolStripMenuItem_Click);
            // 
            // cbox_timeOut
            // 
            this.cbox_timeOut.FormattingEnabled = true;
            this.cbox_timeOut.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "40",
            "50",
            "60",
            "100"});
            this.cbox_timeOut.Location = new System.Drawing.Point(417, 56);
            this.cbox_timeOut.Name = "cbox_timeOut";
            this.cbox_timeOut.Size = new System.Drawing.Size(59, 20);
            this.cbox_timeOut.TabIndex = 18;
            this.cbox_timeOut.SelectedValueChanged += new System.EventHandler(this.cbox_timeOut_SelectedValueChanged);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(364, 60);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(47, 12);
            this.label33.TabIndex = 17;
            this.label33.Text = "超 时：";
            // 
            // cbox_threadSize
            // 
            this.cbox_threadSize.FormattingEnabled = true;
            this.cbox_threadSize.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "15",
            "20",
            "30",
            "40",
            "50",
            "70",
            "100",
            "200",
            "300",
            "400",
            "500",
            "600",
            "700",
            "800",
            "900",
            "1000"});
            this.cbox_threadSize.Location = new System.Drawing.Point(417, 20);
            this.cbox_threadSize.Name = "cbox_threadSize";
            this.cbox_threadSize.Size = new System.Drawing.Size(59, 20);
            this.cbox_threadSize.TabIndex = 3;
            this.cbox_threadSize.TextChanged += new System.EventHandler(this.cbox_threadSize_TextChanged);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(364, 24);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(47, 12);
            this.label36.TabIndex = 0;
            this.label36.Text = "线 程：";
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox8.Controls.Add(this.lvw_info);
            this.groupBox8.Location = new System.Drawing.Point(12, 198);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(973, 525);
            this.groupBox8.TabIndex = 14;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "扫描结果";
            // 
            // lvw_info
            // 
            this.lvw_info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvw_info.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_id,
            this.column_url,
            this.column_response,
            this.col_contentType,
            this.col_length,
            this.col_server,
            this.column_X_Powered_By,
            this.col_runTime,
            this.column_ip});
            this.lvw_info.ContextMenuStrip = this.ctx_dirscan;
            this.lvw_info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvw_info.ForeColor = System.Drawing.Color.Green;
            this.lvw_info.FullRowSelect = true;
            this.lvw_info.GridLines = true;
            this.lvw_info.Location = new System.Drawing.Point(3, 17);
            this.lvw_info.Name = "lvw_info";
            this.lvw_info.Size = new System.Drawing.Size(967, 505);
            this.lvw_info.TabIndex = 1;
            this.lvw_info.UseCompatibleStateImageBehavior = false;
            this.lvw_info.View = System.Windows.Forms.View.Details;
            this.lvw_info.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvw_info_ColumnClick);
            this.lvw_info.DoubleClick += new System.EventHandler(this.lvw_info_DoubleClick);
            // 
            // column_id
            // 
            this.column_id.Text = "序 号";
            // 
            // column_url
            // 
            this.column_url.Text = "Web路径";
            this.column_url.Width = 300;
            // 
            // column_response
            // 
            this.column_response.Text = "HTTP响应";
            this.column_response.Width = 66;
            // 
            // col_contentType
            // 
            this.col_contentType.Text = "文档类型";
            this.col_contentType.Width = 76;
            // 
            // col_length
            // 
            this.col_length.Text = "长度";
            this.col_length.Width = 55;
            // 
            // col_server
            // 
            this.col_server.Text = "Web服务器";
            this.col_server.Width = 111;
            // 
            // column_X_Powered_By
            // 
            this.column_X_Powered_By.Text = "X-Powered-By";
            this.column_X_Powered_By.Width = 91;
            // 
            // col_runTime
            // 
            this.col_runTime.Text = "用时[毫秒]";
            this.col_runTime.Width = 78;
            // 
            // column_ip
            // 
            this.column_ip.Text = "IP地址";
            this.column_ip.Width = 105;
            // 
            // ctx_dirscan
            // 
            this.ctx_dirscan.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_exportZWInfo,
            this.tsmi_exportDirInfo,
            this.tsmi_delete_item,
            this.tsmi_copyURL,
            this.tsmi_clearResult});
            this.ctx_dirscan.Name = "contextMenuStrip1";
            this.ctx_dirscan.Size = new System.Drawing.Size(173, 114);
            // 
            // tsmi_exportZWInfo
            // 
            this.tsmi_exportZWInfo.Name = "tsmi_exportZWInfo";
            this.tsmi_exportZWInfo.Size = new System.Drawing.Size(172, 22);
            this.tsmi_exportZWInfo.Text = "导出扫描指纹信息";
            this.tsmi_exportZWInfo.Click += new System.EventHandler(this.tsmi_exportZWInfo_Click);
            // 
            // tsmi_exportDirInfo
            // 
            this.tsmi_exportDirInfo.Name = "tsmi_exportDirInfo";
            this.tsmi_exportDirInfo.Size = new System.Drawing.Size(172, 22);
            this.tsmi_exportDirInfo.Text = "导出目录扫描信息";
            this.tsmi_exportDirInfo.Click += new System.EventHandler(this.tsmi_exportDirInfo_Click);
            // 
            // tsmi_delete_item
            // 
            this.tsmi_delete_item.Name = "tsmi_delete_item";
            this.tsmi_delete_item.Size = new System.Drawing.Size(172, 22);
            this.tsmi_delete_item.Text = "删除此记录";
            this.tsmi_delete_item.Click += new System.EventHandler(this.tsmi_delete_item_Click);
            // 
            // tsmi_copyURL
            // 
            this.tsmi_copyURL.Name = "tsmi_copyURL";
            this.tsmi_copyURL.Size = new System.Drawing.Size(172, 22);
            this.tsmi_copyURL.Text = "复制此URL";
            this.tsmi_copyURL.Click += new System.EventHandler(this.tsmi_copyURL_Click);
            // 
            // tsmi_clearResult
            // 
            this.tsmi_clearResult.Name = "tsmi_clearResult";
            this.tsmi_clearResult.Size = new System.Drawing.Size(172, 22);
            this.tsmi_clearResult.Text = "清空结果";
            this.tsmi_clearResult.Click += new System.EventHandler(this.tsmi_clearResult_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox9.Controls.Add(this.lbl_speed);
            this.groupBox9.Controls.Add(this.label1);
            this.groupBox9.Controls.Add(this.label6);
            this.groupBox9.Controls.Add(this.lbl_waitCount);
            this.groupBox9.Controls.Add(this.lbl_scanedCount);
            this.groupBox9.Controls.Add(this.label15);
            this.groupBox9.Controls.Add(this.label22);
            this.groupBox9.Controls.Add(this.lbl_usedtime);
            this.groupBox9.Controls.Add(this.label21);
            this.groupBox9.Controls.Add(this.lbl_c_url);
            this.groupBox9.Controls.Add(this.label27);
            this.groupBox9.Controls.Add(this.lbl_dirs_sum);
            this.groupBox9.Controls.Add(this.label4);
            this.groupBox9.Controls.Add(this.lbl_sumDomains);
            this.groupBox9.Location = new System.Drawing.Point(12, 152);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(973, 40);
            this.groupBox9.TabIndex = 13;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "状态";
            // 
            // lbl_speed
            // 
            this.lbl_speed.AutoSize = true;
            this.lbl_speed.Location = new System.Drawing.Point(800, 19);
            this.lbl_speed.Name = "lbl_speed";
            this.lbl_speed.Size = new System.Drawing.Size(11, 12);
            this.lbl_speed.TabIndex = 14;
            this.lbl_speed.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(613, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "已扫描：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(747, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "速 度：";
            // 
            // lbl_waitCount
            // 
            this.lbl_waitCount.AutoSize = true;
            this.lbl_waitCount.Location = new System.Drawing.Point(527, 19);
            this.lbl_waitCount.Name = "lbl_waitCount";
            this.lbl_waitCount.Size = new System.Drawing.Size(11, 12);
            this.lbl_waitCount.TabIndex = 11;
            this.lbl_waitCount.Text = "0";
            // 
            // lbl_scanedCount
            // 
            this.lbl_scanedCount.AutoSize = true;
            this.lbl_scanedCount.Location = new System.Drawing.Point(672, 18);
            this.lbl_scanedCount.Name = "lbl_scanedCount";
            this.lbl_scanedCount.Size = new System.Drawing.Size(11, 12);
            this.lbl_scanedCount.TabIndex = 0;
            this.lbl_scanedCount.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(485, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 9;
            this.label15.Text = "等待：";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(349, 19);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(0, 12);
            this.label22.TabIndex = 3;
            // 
            // lbl_usedtime
            // 
            this.lbl_usedtime.AutoSize = true;
            this.lbl_usedtime.Location = new System.Drawing.Point(934, 18);
            this.lbl_usedtime.Name = "lbl_usedtime";
            this.lbl_usedtime.Size = new System.Drawing.Size(11, 12);
            this.lbl_usedtime.TabIndex = 0;
            this.lbl_usedtime.Text = "0";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(881, 18);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(47, 12);
            this.label21.TabIndex = 0;
            this.label21.Text = "用 时：";
            // 
            // lbl_c_url
            // 
            this.lbl_c_url.Location = new System.Drawing.Point(14, 18);
            this.lbl_c_url.Name = "lbl_c_url";
            this.lbl_c_url.Size = new System.Drawing.Size(194, 12);
            this.lbl_c_url.TabIndex = 2;
            this.lbl_c_url.Text = "正在等待开始....";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(364, 18);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(53, 12);
            this.label27.TabIndex = 10;
            this.label27.Text = "字  典：";
            // 
            // lbl_dirs_sum
            // 
            this.lbl_dirs_sum.AutoSize = true;
            this.lbl_dirs_sum.Location = new System.Drawing.Point(423, 18);
            this.lbl_dirs_sum.Name = "lbl_dirs_sum";
            this.lbl_dirs_sum.Size = new System.Drawing.Size(11, 12);
            this.lbl_dirs_sum.TabIndex = 0;
            this.lbl_dirs_sum.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(214, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "总域名：";
            // 
            // lbl_sumDomains
            // 
            this.lbl_sumDomains.AutoSize = true;
            this.lbl_sumDomains.Location = new System.Drawing.Point(273, 18);
            this.lbl_sumDomains.Name = "lbl_sumDomains";
            this.lbl_sumDomains.Size = new System.Drawing.Size(11, 12);
            this.lbl_sumDomains.TabIndex = 0;
            this.lbl_sumDomains.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(678, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "文档类型：";
            // 
            // groupBox10
            // 
            this.groupBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox10.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox10.Controls.Add(this.cbox_timeOut);
            this.groupBox10.Controls.Add(this.label5);
            this.groupBox10.Controls.Add(this.cbox_isExists);
            this.groupBox10.Controls.Add(this.cbox_show);
            this.groupBox10.Controls.Add(this.cbox_length);
            this.groupBox10.Controls.Add(this.cbox_sleepTime);
            this.groupBox10.Controls.Add(this.label33);
            this.groupBox10.Controls.Add(this.chk_404Mode);
            this.groupBox10.Controls.Add(this.cbox_threadSize);
            this.groupBox10.Controls.Add(this.chkList_dir);
            this.groupBox10.Controls.Add(this.label36);
            this.groupBox10.Controls.Add(this.cbox_ext);
            this.groupBox10.Controls.Add(this.chk_getBanner);
            this.groupBox10.Controls.Add(this.label7);
            this.groupBox10.Controls.Add(this.txt_404_keys);
            this.groupBox10.Controls.Add(this.txt_contentLength);
            this.groupBox10.Controls.Add(this.txt_contentType);
            this.groupBox10.Controls.Add(this.txt_showCodes);
            this.groupBox10.Controls.Add(this.chk_fastMode);
            this.groupBox10.Controls.Add(this.btn_import);
            this.groupBox10.Controls.Add(this.btn_start);
            this.groupBox10.Controls.Add(this.cbox_method);
            this.groupBox10.Controls.Add(this.btn_stop);
            this.groupBox10.Controls.Add(this.txt_web);
            this.groupBox10.Controls.Add(this.label29);
            this.groupBox10.Location = new System.Drawing.Point(12, 17);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(973, 129);
            this.groupBox10.TabIndex = 12;
            this.groupBox10.TabStop = false;
            // 
            // cbox_isExists
            // 
            this.cbox_isExists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_isExists.FormattingEnabled = true;
            this.cbox_isExists.Items.AddRange(new object[] {
            "200页面",
            "404页面"});
            this.cbox_isExists.Location = new System.Drawing.Point(197, 94);
            this.cbox_isExists.Name = "cbox_isExists";
            this.cbox_isExists.Size = new System.Drawing.Size(70, 20);
            this.cbox_isExists.TabIndex = 36;
            this.cbox_isExists.SelectedIndexChanged += new System.EventHandler(this.cbox_isExists_SelectedIndexChanged);
            // 
            // cbox_show
            // 
            this.cbox_show.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_show.FormattingEnabled = true;
            this.cbox_show.Items.AddRange(new object[] {
            "提示",
            "不提示"});
            this.cbox_show.Location = new System.Drawing.Point(680, 94);
            this.cbox_show.Name = "cbox_show";
            this.cbox_show.Size = new System.Drawing.Size(63, 20);
            this.cbox_show.TabIndex = 35;
            this.cbox_show.SelectedIndexChanged += new System.EventHandler(this.cbox_show_SelectedIndexChanged);
            // 
            // cbox_length
            // 
            this.cbox_length.FormattingEnabled = true;
            this.cbox_length.Items.AddRange(new object[] {
            "排除响应长度小于",
            "排除响应长度等于",
            "排除响应长度大于"});
            this.cbox_length.Location = new System.Drawing.Point(680, 19);
            this.cbox_length.Name = "cbox_length";
            this.cbox_length.Size = new System.Drawing.Size(185, 20);
            this.cbox_length.TabIndex = 34;
            this.cbox_length.SelectedIndexChanged += new System.EventHandler(this.cbox_length_SelectedIndexChanged);
            // 
            // cbox_sleepTime
            // 
            this.cbox_sleepTime.FormattingEnabled = true;
            this.cbox_sleepTime.Items.AddRange(new object[] {
            "休眠",
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "40",
            "50",
            "60",
            "100",
            "500",
            "1000",
            "5000"});
            this.cbox_sleepTime.Location = new System.Drawing.Point(277, 94);
            this.cbox_sleepTime.Name = "cbox_sleepTime";
            this.cbox_sleepTime.Size = new System.Drawing.Size(72, 20);
            this.cbox_sleepTime.TabIndex = 34;
            this.cbox_sleepTime.SelectedValueChanged += new System.EventHandler(this.cbox_sleepTime_SelectedValueChanged);
            // 
            // chk_404Mode
            // 
            this.chk_404Mode.AutoSize = true;
            this.chk_404Mode.Location = new System.Drawing.Point(183, 59);
            this.chk_404Mode.Name = "chk_404Mode";
            this.chk_404Mode.Size = new System.Drawing.Size(84, 16);
            this.chk_404Mode.TabIndex = 33;
            this.chk_404Mode.Text = "关键字扫描";
            this.chk_404Mode.UseVisualStyleBackColor = true;
            this.chk_404Mode.CheckedChanged += new System.EventHandler(this.chk_404Mode_CheckedChanged);
            // 
            // chkList_dir
            // 
            this.chkList_dir.FormattingEnabled = true;
            this.chkList_dir.Location = new System.Drawing.Point(487, 18);
            this.chkList_dir.Name = "chkList_dir";
            this.chkList_dir.Size = new System.Drawing.Size(179, 100);
            this.chkList_dir.TabIndex = 31;
            // 
            // cbox_ext
            // 
            this.cbox_ext.FormattingEnabled = true;
            this.cbox_ext.Items.AddRange(new object[] {
            "自定后缀",
            ".rar",
            ".zip",
            ".tar",
            ".tar.gz",
            ".bz2",
            ".tar.bz2",
            ".7z",
            ".tar.7z",
            ".bak",
            ".txt",
            ".asa",
            ".asp.bak",
            ".php3",
            ".php.bak",
            ".cfm",
            ".aspx",
            ".aspx.bak",
            ".do",
            ".action",
            ".jsp.bak",
            ".xml",
            ".py"});
            this.cbox_ext.Location = new System.Drawing.Point(366, 94);
            this.cbox_ext.Name = "cbox_ext";
            this.cbox_ext.Size = new System.Drawing.Size(110, 20);
            this.cbox_ext.TabIndex = 20;
            this.cbox_ext.SelectedValueChanged += new System.EventHandler(this.cbox_ext_SelectedValueChanged);
            // 
            // chk_getBanner
            // 
            this.chk_getBanner.AutoSize = true;
            this.chk_getBanner.Location = new System.Drawing.Point(16, 59);
            this.chk_getBanner.Name = "chk_getBanner";
            this.chk_getBanner.Size = new System.Drawing.Size(72, 16);
            this.chk_getBanner.TabIndex = 28;
            this.chk_getBanner.Text = "指纹识别";
            this.chk_getBanner.UseVisualStyleBackColor = true;
            this.chk_getBanner.CheckedChanged += new System.EventHandler(this.chk_getBanner_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 27;
            this.label7.Text = "关键字：";
            // 
            // txt_404_keys
            // 
            this.txt_404_keys.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_404_keys.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_404_keys.Location = new System.Drawing.Point(73, 93);
            this.txt_404_keys.Name = "txt_404_keys";
            this.txt_404_keys.Size = new System.Drawing.Size(118, 21);
            this.txt_404_keys.TabIndex = 25;
            this.txt_404_keys.Text = "404";
            this.txt_404_keys.TextChanged += new System.EventHandler(this.txt_404_keys_TextChanged);
            // 
            // txt_contentLength
            // 
            this.txt_contentLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_contentLength.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_contentLength.Location = new System.Drawing.Point(883, 20);
            this.txt_contentLength.Name = "txt_contentLength";
            this.txt_contentLength.Size = new System.Drawing.Size(75, 21);
            this.txt_contentLength.TabIndex = 25;
            this.txt_contentLength.TextChanged += new System.EventHandler(this.txt_contentLength_TextChanged);
            // 
            // txt_contentType
            // 
            this.txt_contentType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_contentType.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_contentType.Location = new System.Drawing.Point(749, 55);
            this.txt_contentType.Name = "txt_contentType";
            this.txt_contentType.Size = new System.Drawing.Size(116, 21);
            this.txt_contentType.TabIndex = 25;
            this.txt_contentType.TextChanged += new System.EventHandler(this.txt_contentType_TextChanged);
            // 
            // txt_showCodes
            // 
            this.txt_showCodes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_showCodes.Font = new System.Drawing.Font("宋体", 9F);
            this.txt_showCodes.Location = new System.Drawing.Point(749, 94);
            this.txt_showCodes.Name = "txt_showCodes";
            this.txt_showCodes.Size = new System.Drawing.Size(116, 21);
            this.txt_showCodes.TabIndex = 25;
            this.txt_showCodes.Text = "404";
            this.txt_showCodes.TextChanged += new System.EventHandler(this.txt_showCode_TextChanged);
            // 
            // chk_fastMode
            // 
            this.chk_fastMode.AutoSize = true;
            this.chk_fastMode.Location = new System.Drawing.Point(96, 59);
            this.chk_fastMode.Name = "chk_fastMode";
            this.chk_fastMode.Size = new System.Drawing.Size(72, 16);
            this.chk_fastMode.TabIndex = 24;
            this.chk_fastMode.Text = "快速扫描";
            this.chk_fastMode.UseVisualStyleBackColor = true;
            this.chk_fastMode.CheckedChanged += new System.EventHandler(this.chk_fastMode_CheckedChanged);
            // 
            // btn_import
            // 
            this.btn_import.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_import.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_import.Location = new System.Drawing.Point(277, 19);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(72, 23);
            this.btn_import.TabIndex = 23;
            this.btn_import.Text = "导 入";
            this.btn_import.UseVisualStyleBackColor = true;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // btn_start
            // 
            this.btn_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_start.Location = new System.Drawing.Point(883, 94);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 11;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // cbox_method
            // 
            this.cbox_method.BackColor = System.Drawing.Color.White;
            this.cbox_method.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_method.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbox_method.FormattingEnabled = true;
            this.cbox_method.Items.AddRange(new object[] {
            "HEAD",
            "GET"});
            this.cbox_method.Location = new System.Drawing.Point(277, 56);
            this.cbox_method.Name = "cbox_method";
            this.cbox_method.Size = new System.Drawing.Size(72, 20);
            this.cbox_method.TabIndex = 4;
            this.cbox_method.SelectedValueChanged += new System.EventHandler(this.cbox_method_SelectedValueChanged);
            // 
            // btn_stop
            // 
            this.btn_stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_stop.Location = new System.Drawing.Point(883, 55);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(75, 23);
            this.btn_stop.TabIndex = 2;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // txt_web
            // 
            this.txt_web.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_web.Location = new System.Drawing.Point(67, 20);
            this.txt_web.Name = "txt_web";
            this.txt_web.Size = new System.Drawing.Size(200, 21);
            this.txt_web.TabIndex = 1;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(14, 24);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(47, 12);
            this.label29.TabIndex = 0;
            this.label29.Text = "域 名：";
            // 
            // timer_scandir
            // 
            this.timer_scandir.Interval = 1000;
            this.timer_scandir.Tick += new System.EventHandler(this.timer_scandir_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox10);
            this.groupBox1.Controls.Add(this.groupBox8);
            this.groupBox1.Controls.Add(this.groupBox9);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(997, 729);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 754);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SWebScan V5.0 by shack2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.ctx_dirscan.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 菜单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 使用手册ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_about;
        private System.Windows.Forms.ToolStripMenuItem 在线更新ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ListView lvw_info;
        private System.Windows.Forms.ColumnHeader column_id;
        private System.Windows.Forms.ColumnHeader column_url;
        private System.Windows.Forms.ColumnHeader column_response;
        private System.Windows.Forms.ColumnHeader col_server;
        private System.Windows.Forms.ColumnHeader column_X_Powered_By;
        private System.Windows.Forms.ColumnHeader column_ip;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label lbl_speed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_waitCount;
        private System.Windows.Forms.Label lbl_scanedCount;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbl_usedtime;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lbl_c_url;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.CheckedListBox chkList_dir;
        private System.Windows.Forms.CheckBox chk_getBanner;
        private System.Windows.Forms.TextBox txt_showCodes;
        private System.Windows.Forms.CheckBox chk_fastMode;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.ComboBox cbox_ext;
        private System.Windows.Forms.Label lbl_dirs_sum;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBox cbox_method;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.TextBox txt_web;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox cbox_timeOut;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.ComboBox cbox_threadSize;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_sumDomains;
        private System.Windows.Forms.ComboBox cbox_sleepTime;
        private System.Windows.Forms.ContextMenuStrip ctx_dirscan;
        private System.Windows.Forms.ToolStripMenuItem tsmi_exportZWInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmi_exportDirInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmi_delete_item;
        private System.Windows.Forms.ToolStripMenuItem tsmi_copyURL;
        private System.Windows.Forms.Timer timer_scandir;
        private System.Windows.Forms.ToolStripMenuItem tsmi_clearResult;
        private System.Windows.Forms.ColumnHeader col_contentType;
        private System.Windows.Forms.ColumnHeader col_length;
        private System.Windows.Forms.CheckBox chk_404Mode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_404_keys;
        private System.Windows.Forms.ComboBox cbox_show;
        private System.Windows.Forms.ComboBox cbox_isExists;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader col_runTime;
        private System.Windows.Forms.TextBox txt_contentType;
        private System.Windows.Forms.ComboBox cbox_length;
        private System.Windows.Forms.TextBox txt_contentLength;
        private System.Windows.Forms.Label label1;
    }
}

