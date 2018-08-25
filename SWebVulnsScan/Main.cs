using Amib.Threading;
using shack2.tools;
using shack2.tools.file;
using shack2.tools.model;
using shack2.tools.http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SWebVulnsScan
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        public static Config config = null;

        private int scanTime = 0;
   
        public static Dictionary<String,List<String>> dirs = new Dictionary<String,List<String>>();
        public long sumDomains = 0;
        public HashSet<String> initdirs = new HashSet<String>();
        public static String scanURL = "";
        public long scanDirCount = 0;//扫描目录总数
        public static long allscanCount = 0;
        public bool keeAlive = true;
        private void loadLastConfig() {
            try
            {
                config = XML.readConfig(AppDomain.CurrentDomain.BaseDirectory+"lastConfig.xml");
            }
            catch (Exception e) {
               
                MessageBox.Show("加载上次配置失败，使用默认配置！");
            }
            if (config == null) {
                config = new Config();
            }
            this.cbox_threadSize.Text = config.threadSize.ToString();
            this.cbox_timeOut.Text = config.timeOut.ToString();
            switch (config.scanMode) { 
                case 1:
                    this.chk_fastMode.Checked=true;;   
                    break;
                case 2:
                    this.chk_404Mode.Checked = true; ;
                    break;
            }  
            this.chk_getBanner.Checked = config.getBanner;
            this.txt_showCodes.Text = config.showCodes;
            this.cbox_show.SelectedIndex = config.show;
            this.cbox_isExists.SelectedIndex = config.isExists;
            this.txt_404_keys.Text = config.key;
            this.cbox_length.SelectedIndex = config.contentSelect;
            this.txt_contentType.Text = config.contentType;
            this.txt_contentLength.Text = config.contentLength+"";
            this.cbox_dicType.SelectedIndex = config.dicType;

            if (config.sleepTime == 0)
            {
                this.cbox_sleepTime.Text = "休眠";
            }
            else {
                this.cbox_sleepTime.Text = config.sleepTime.ToString();
            }
            
            this.cbox_method.Text = config.method;

            if (String.IsNullOrEmpty(config.ext))
            {
                this.cbox_ext.Text = "自定后缀";
            }
            else
            {
                this.cbox_ext.Text = config.ext;
            }
          
        }

        private void loadDirPath()
        {
            String dicpath = "/dic/max/";
            if (config.dicType != 0) {
                dicpath = "/dic/min/";
            }
            List<String> dirlist = FileTool.readAllDic(dicpath);

            this.chkList_dir.Items.Clear();
            dirs.Clear();
            foreach (String dir in dirlist){
                List<String> clist = FileTool.readFileToListByEncoding(dicpath + dir,"UTF-8");
                dirs[dir] = clist;
                this.chkList_dir.Items.Add(dir + "|" + clist.Count+ "条");
            }
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            this.Text += " " + version;
            loadLastConfig();
            Thread th = new Thread(checkUpdate);
            th.Start();
            loadDirPath();
        }
        delegate void DelegateAddItemToListView(ServerInfo svinfo);
        public void AddItemToListView(ServerInfo svinfo)
        {
            //过滤类型不符合的
            if (!svinfo.contentType.StartsWith(config.contentType,StringComparison.OrdinalIgnoreCase)) {
                return;
            }
            //过滤长度不符合的
            bool filter = false;
            if (config.contentLength>-2)
            {
               
                    switch (config.contentSelect) {
                    case 0:
                        if (svinfo.length < config.contentLength) {
                            filter = true;
                        }
                        
                        break;
                    case 1:
                        if (svinfo.length == config.contentLength)
                        {
                            filter = true;
                        }
                       
                        break;
                    case 2:
                        if (svinfo.length > config.contentLength)
                        {
                            filter = true;
                        }
                        break;
                }

            }
            if (filter) {
                return;
            }
            ListViewItem lvi = new ListViewItem(svinfo.id + "");
            lvi.Tag = svinfo.type;
            lvi.SubItems.Add(svinfo.url);
            lvi.SubItems.Add(svinfo.code + "");
            lvi.SubItems.Add(svinfo.contentType+ "");
            lvi.SubItems.Add(svinfo.length + "");
            lvi.SubItems.Add(svinfo.server + "");
            lvi.SubItems.Add(svinfo.powerBy + "");
            lvi.SubItems.Add(svinfo.runTime + "");
            lvi.SubItems.Add(svinfo.ip + "");
            String result = svinfo.url +"----"+ svinfo.code;
            lvi.Tag = svinfo.type;
            if (svinfo.code.ToString().StartsWith("2"))
            {
                lvi.ForeColor = Color.Green;
            }
            else if (svinfo.code.ToString().StartsWith("3"))
            {
                lvi.ForeColor = Color.Blue;
            }
            else if (svinfo.code.ToString().StartsWith("4"))
            {
                lvi.ForeColor = Color.Gray;
            }
            else if (svinfo.code.ToString().StartsWith("5"))
            {
                lvi.ForeColor = Color.Red;
            }
            FileTool.AppendLogToFile("logs/scan_"+DateTime.Now.ToString("yyyy-MM-dd") + ".log", result);
            this.lvw_info.Items.Add(lvi);
        }
        private void scanExistsDirs(Object obj)
        {
            ServerInfo svinfo = (ServerInfo)obj;
            ServerInfo result = new ServerInfo();
            
            if (config.scanMode == 2)
            {
                result = HTTPRequest.SendRequestGetBody(config.method, svinfo.url, config.timeOut, keeAlive);
            }
            else
            {
                result = HTTPRequest.SendRequestGetHeader(config.method, svinfo.url, config.timeOut, keeAlive);
            }

            svinfo.code = result.code;

            if (svinfo.code != 0)
            {
                String location = result.location;
                svinfo.contentType = result.contentType;
                svinfo.length = result.length;
                svinfo.server = result.server;
                svinfo.powerBy = result.powerBy;
                svinfo.runTime = result.runTime;
                //关键字扫描
                if (config.scanMode >= 1)
                {
                    if (svinfo.code == 302 && location.IndexOf(svinfo.path) != -1)
                    {
                        svinfo.code = 301;
                    }

                    else if (config.scanMode == 2 && result.body != null)
                    {
                        String[] keys404 = config.key.Split(',');
                        if (keys404.Count() > 0)
                        {
                            foreach (String key in keys404)
                            {

                                if (result.body.IndexOf(key) != -1 && config.isExists == 1)
                                {
                                    svinfo.code = 404;
                                    break;
                                }
                                if (result.body.IndexOf(key) == -1 && config.isExists == 0 && svinfo.code == 200)
                                {
                                    svinfo.code = 404;
                                    break;
                                }

                                if (result.body.IndexOf(key) != -1 && config.isExists == 0)
                                {
                                    svinfo.code = 200;
                                    break;
                                }

                            }
                        }
                    }
                }
              
                if (config.show == 0)
                {
                    if (config.showCodes.IndexOf(svinfo.code.ToString()) != -1)
                    {
                        this.Invoke(new DelegateAddItemToListView(AddItemToListView), svinfo);
                    }
                }
                else
                {
                    if (config.showCodes.IndexOf(svinfo.code.ToString()) == -1)
                    {
                        this.Invoke(new DelegateAddItemToListView(AddItemToListView), svinfo);
                    }
                }
            }
            Thread.Sleep(config.sleepTime);
        }

        private void zwScan(Object obj)
        {
            ServerInfo svinfo = (ServerInfo)obj;

            ServerInfo result = HTTPRequest.SendRequestGetHeader(config.method, svinfo.url, config.timeOut, keeAlive);
            svinfo.code = result.code;
            svinfo.ip = Tools.getIP(svinfo.host);
            svinfo.contentType = result.contentType;
            svinfo.length = result.length;
            svinfo.server = result.server;
            svinfo.powerBy = result.powerBy;
            svinfo.runTime = result.runTime;
            this.Invoke(new DelegateAddItemToListView(AddItemToListView), svinfo);
            Thread.Sleep(config.sleepTime);
        }

        private String getDir(String path)
        {
            try {
                int start = path.IndexOf("/");
                int end =path.IndexOf("/", start+1);
                if (start > end) {
                    return path;
                }
                if (end > start) {
                    String startDir = path.Substring(start, end - start);
                    return startDir;
                }
            } catch (Exception e) {

            }
            return "";
        }
        private void scanThread()
        {
           this.scanDirCount = 0;
           
            if (config.getBanner) {
                allscanCount = initdirs.Count;
                if (!"".Equals(scanURL))
                {
                    //获取指纹、IP
                    ServerInfo svinfo = new ServerInfo();
                    this.scanDirCount++;
                    //扫描状态码
                    svinfo.host = Tools.updateTheDomain(scanURL, false);

                    svinfo.id = this.scanDirCount;
                    svinfo.type = "指纹";
                    svinfo.url = svinfo.host;
                    stp.WaitFor(1000, 10000);
                    stp.QueueWorkItem<ServerInfo>(zwScan, svinfo);
                    stp.WaitForIdle();
                }
                else {
                    FileStream fs_dir = null;
                    StreamReader reader = null;
                    try
                    {
                        fs_dir = new FileStream(this.txt_web.Text, FileMode.Open, FileAccess.Read);

                        reader = new StreamReader(fs_dir, Encoding.GetEncoding("UTF-8"));

                        String domain;

                        while ((domain = reader.ReadLine()) != null)
                        {
                            //获取指纹、IP
                            ServerInfo svinfo = new ServerInfo();
                            this.scanDirCount++;
                            //扫描状态码
                            svinfo.host = Tools.updateTheDomain(domain, false);

                            svinfo.id = this.scanDirCount;
                            svinfo.type = "指纹";
                            svinfo.url = svinfo.host;
                            stp.WaitFor(1000, 10000);
                            stp.QueueWorkItem<ServerInfo>(zwScan, svinfo);

                        }
                        stp.WaitForIdle();
                    }
                    catch (Exception e)
                    {
                        Tools.SysLog(e.Message);
                    }
                    finally
                    {
                        if (reader != null)
                        {
                            reader.Close();
                        }
                        if (fs_dir != null)
                        {
                            fs_dir.Close();
                        }
                    }
                }
              
            }
            //合并目录
            foreach (String dir in this.chkList_dir.CheckedItems)
            {

                String cdir = dir.Split('|')[0];
                List<String> clist = null;
                Boolean isget = dirs.TryGetValue(cdir, out clist);
                foreach (String scanDir in clist)
                {
                    if (!initdirs.Contains(scanDir))
                    {
                        initdirs.Add(scanDir);
                    }
                }

            }
            allscanCount = initdirs.Count;
            if ("".Equals(scanURL))
            {
                allscanCount = this.sumDomains * initdirs.Count;
            }
                
            //优化keepalive
            if (this.sumDomains > config.threadSize*2) {
                keeAlive = false;
            }
            this.lbl_dirs_sum.Text = allscanCount.ToString();

            foreach (String scanDir in initdirs)
            {
                if (!"".Equals(scanURL))
                {
                
                    ServerInfo svinfo = new ServerInfo();
                    svinfo.target = scanURL;
                    svinfo.host = Tools.updateTheDomain(scanURL, true);
                    this.scanDirCount++;
                    svinfo.id = this.scanDirCount;
                    svinfo.type = "目录";
                    String cdomain = Tools.getHost(svinfo.host);
                    String domaincenter = Tools.getHostCenter(svinfo.host);
                    svinfo.path = scanDir.Replace("%domain%", cdomain).Replace("%domainCenter%", domaincenter);
                    svinfo.url = svinfo.host + scanDir.Replace("%domain%", Tools.getHost(svinfo.host)).Replace("%domainCenter%", Tools.getHostCenter(svinfo.host));
                    stp.WaitFor(1000, 10000);
                    stp.QueueWorkItem<ServerInfo>(scanExistsDirs, svinfo);
                }
                else
                { 
                    //更新总数
                    allscanCount = this.sumDomains * initdirs.Count;

                    FileStream fs_dir = null;
                    StreamReader reader = null;
                    try
                    {
                        fs_dir = new FileStream(this.txt_web.Text, FileMode.Open, FileAccess.Read);

                        reader = new StreamReader(fs_dir, Encoding.GetEncoding("UTF-8"));

                        String domain;

                        while ((domain = reader.ReadLine()) != null)
                        {

                            ServerInfo svinfo = new ServerInfo();
                            svinfo.target = domain;
                            svinfo.host = Tools.updateTheDomain(domain, true);
                            this.scanDirCount++;
                            svinfo.id = this.scanDirCount;
                            svinfo.type = "目录";
                            String cdomain = Tools.getHost(svinfo.host);
                            String domaincenter = Tools.getHostCenter(svinfo.host);
                            svinfo.path = scanDir.Replace("%domain%", cdomain).Replace("%domainCenter%", domaincenter);
                            svinfo.url = svinfo.host + scanDir.Replace("%domain%", Tools.getHost(svinfo.host)).Replace("%domainCenter%", Tools.getHostCenter(svinfo.host));
                            stp.WaitFor(1000, 10000);
                            stp.QueueWorkItem<ServerInfo>(scanExistsDirs, svinfo);

                        }
                    }
                    catch (Exception e)
                    {
                        Tools.SysLog(e.Message);
                    }
                    finally
                    {
                        if (reader != null)
                        {
                            reader.Close();
                        }
                        if (fs_dir != null)
                        {
                            fs_dir.Close();
                        }
                    }
                }   
           }
           stp.WaitForIdle();
           dostopScan();

        }
        private SmartThreadPool stp = new SmartThreadPool();
        private Thread sThread = null;
        private void btn_start_Click(object sender, EventArgs e)
        {
            if (loaddomains != 0) {
                MessageBox.Show("等待导入域名完成！");
                return;
            }
            if (stp.InUseThreads<=0)
            {
                if ("".Equals(this.txt_web.Text))
                {
                    MessageBox.Show("请输入域名或者选择导入扫描域名！");
                    return;
                }
                if (this.txt_web.Text.StartsWith("http") || this.txt_web.Text.StartsWith("www."))
                {
                    //单个网站扫描
                    scanURL = Tools.updateTheDomain(this.txt_web.Text.Trim(),false);
                    
                }
                if (this.chkList_dir.SelectedItems.Count<=0&& !config.getBanner)
                {
                    MessageBox.Show("请选择扫描字典！");
                    return;
                }
                stp = new SmartThreadPool();
            
                stp.MaxThreads=config.threadSize;
                //
                this.lastcount = 0;
                this.scanDirCount = 0;
                this.scanTime = 0;
                this.initdirs.Clear();
                this.btn_start.Enabled = false;
                this.timer_scandir.Start();
                //开始扫描
                sThread = new Thread(new ThreadStart(scanThread));
                sThread.Start();
            }

            else
            {
                MessageBox.Show("上次任务还没停止，请停止上次任务！");
            }


        }

        private void cbox_timeOut_SelectedValueChanged(object sender, EventArgs e)
        {
            config.timeOut = Tools.convertToInt(this.cbox_timeOut.Text);
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            XML.saveConfig(AppDomain.CurrentDomain.BaseDirectory + "/" + "lastConfig.xml", config);
            System.Environment.Exit(0);
        }

        private void cbox_method_SelectedValueChanged(object sender, EventArgs e)
        {
            config.method = this.cbox_method.Text;
        }

     

        private void chk_fastMode_CheckedChanged(object sender, EventArgs e)
        {
            config.scanMode = 1;
            this.chk_404Mode.Checked = false;
            if (this.chk_getBanner.Checked) {
                this.chk_getBanner.Checked = false;
            }
        }

        private void chk_preciseMode_CheckedChanged(object sender, EventArgs e)
        {
            config.scanMode = 2;
            this.chk_fastMode.Checked = false;
            this.chk_404Mode.Checked = false;
        }

        private void chk_getBanner_CheckedChanged(object sender, EventArgs e)
        {
            config.getBanner = this.chk_getBanner.Checked;
            if (this.chk_fastMode.Checked) {
                this.chk_fastMode.Checked = false;
            }
        }

        private void txt_showCode_TextChanged(object sender, EventArgs e)
        {
            config.showCodes = this.txt_showCodes.Text;
        }

        private void cbox_ext_SelectedValueChanged(object sender, EventArgs e)
        {
            config.ext = this.cbox_ext.Text;
        }

        private void cbox_sleepTime_SelectedValueChanged(object sender, EventArgs e)
        {
            config.sleepTime = Tools.convertToInt(this.cbox_sleepTime.Text);
        }

        
        delegate void DelegateUpdateScanStatus();

        public long lastcount = 0;
        private void updateScanStatus()
        {
            long ccount = stp.WorkItemsItemsProcessed();
            long speed = ccount - lastcount;
            lastcount = ccount;
            this.lbl_usedtime.Text = this.scanTime.ToString();
            this.lbl_waitCount.Text = (allscanCount - ccount).ToString();
            this.lbl_scanedCount.Text = ccount.ToString();
            this.lbl_speed.Text = speed.ToString();
        }

        private int loaddomains = 0;

        public void loadDomains(Object FileDir) {
            this.sumDomains = FileTool.getReadFileLine(FileDir.ToString());
            this.lbl_sumDomains.Text = this.sumDomains + "";
            loaddomains = 0;
            this.btn_import.Enabled = true;
        }
        private void btn_import_Click(object sender, EventArgs e)
        {
            if (loaddomains == 1) {
                return;
            }
            OpenFileDialog ofd = new OpenFileDialog { Filter = "文本文件(*.txt)|*.txt" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                loaddomains = 1;
                this.btn_import.Enabled = false;
                this.lbl_c_url.Text = "正在导入域名列表...";
                this.txt_web.Text = ofd.FileName;
                Thread t = new Thread(loadDomains);
                t.Start(ofd.FileName);
            }
        }
        delegate void voiddelegate();
        public void dostopScan()
        {
            this.timer_scandir.Stop();
            this.Invoke(new DelegateUpdateScanStatus(updateScanStatus));
            this.btn_start.Enabled = true;
        }

        //停止扫描
        public void stopScan()
        {
            stp.Cancel();
            if (sThread != null) {
                sThread.Abort();
            }
            while (stp.InUseThreads > 0) {
                Thread.Sleep(10);
            }
            this.Invoke(new voiddelegate(dostopScan));
  
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
           
            Thread t = new Thread(stopScan);
            t.Start();
            
        }

        public static int version = 20180821;
        public static String versionURL = "http://www.shack2.org/soft/SWebVulnsScan/version.txt";
        //检查更新
        public void checkUpdate()
        {
            try
            {
                String[] result = HTTPRequest.getHTML(versionURL, 30).Split('-');
                String versionText = result[0];
                int cversion = int.Parse(result[1]);
                String versionUpdateURL = result[2];
                if (cversion > version)
                {
                    DialogResult dr = MessageBox.Show("发现新版本：" + versionText + "，更新日期：" + cversion + "，立即转到目标网站更新吗？", "提示", MessageBoxButtons.OKCancel);

                    if (DialogResult.OK.Equals(dr))
                    {
                        try
                        {

                            System.Diagnostics.Process.Start("IEXPLORE.EXE", versionUpdateURL);

                        }

                        catch (Exception other)
                        {
                            MessageBox.Show("无法打开浏览器!" + other.GetBaseException());
                        }
                    }
                }
                else
                {

                    MessageBox.Show("自动检查更新，没有发现新版本！");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("未发现新版本！");
            }
        }

        private void tsmi_delete_item_Click(object sender, EventArgs e)
        {
            if (this.lvw_info.SelectedItems.Count == 0)
            {
                return;
            }
            try
            {
                foreach (ListViewItem lvi in this.lvw_info.SelectedItems)
                {
                    this.lvw_info.Items.Remove(lvi);
                }
            }
            catch (Exception es)
            {
                MessageBox.Show("删除异常，异常原因----" + es.GetBaseException());
            }
        }

        private void tsmi_copyURL_Click(object sender, EventArgs e)
        {
            if (this.lvw_info.SelectedItems.Count == 0)
            {
                return;
            }
            Clipboard.SetText(this.lvw_info.SelectedItems[0].SubItems[1].Text);
            MessageBox.Show("复制成功！");
        }

        private void timer_scandir_Tick(object sender, EventArgs e)
        {
            this.scanTime += 1;
            this.Invoke(new DelegateUpdateScanStatus(updateScanStatus)); 
        }

        private void lvw_info_DoubleClick(object sender, EventArgs e)
        {
            if (this.lvw_info.SelectedItems.Count == 0)
            {
                return;
            }
            string target = this.lvw_info.SelectedItems[0].SubItems[1].Text;

            try
            {
                System.Diagnostics.Process.Start("target");
                

            }
            catch (Exception o)
            {
                try
                {
                    System.Diagnostics.Process.Start("IEXPLORE.EXE", target);

                }
                catch (Exception o1)
                {
                    MessageBox.Show("无法调用浏览器打开URL！"+ o1.Message);
                }
            }
        }
        private ListViewColumnSorter lvw_info_lvwColumnSorter;
        private bool sort = false;
        private void lvw_info_ColumnClick(object sender, ColumnClickEventArgs e)
        {
             // 创建一个ListView排序类的对象，并设置listView1的排序器
           lvw_info_lvwColumnSorter = new ListViewColumnSorter();
            if (sort == false)
            {
                sort = true;
                lvw_info_lvwColumnSorter.Order = SortOrder.Descending;
            }
            else
            {
                sort = false;
                lvw_info_lvwColumnSorter.Order = SortOrder.Ascending;
            }
            lvw_info_lvwColumnSorter.SortColumn = e.Column;
            this.lvw_info.ListViewItemSorter = lvw_info_lvwColumnSorter;
        }

        private void tsmi_clearResult_Click(object sender, EventArgs e)
        {
            this.lvw_info.Items.Clear();
        }

        private void tsmi_exportZWInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lvw_info.Items.Count<= 0)
                {
                    MessageBox.Show("没有数据!");
                    return;
                }
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "文本文件|*.txt";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //保存文件
                    FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    foreach (ListViewItem sv in this.lvw_info.Items)
                    {
                        if (sv.Tag.Equals("指纹"))
                        {
                            sw.WriteLine(sv.SubItems[1].Text + "----" + sv.SubItems[5].Text + "----" + sv.SubItems[6].Text + "----" + sv.SubItems[7].Text);
                        }
                        else
                        {
                            break;
                        }
                    }
                    sw.Close();
                    fs.Close();
                    MessageBox.Show("导出成功！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出数据发生异常！"+ex.Message);
            }
        }

        private void tsmi_exportDirInfo_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "文本文件|*.txt";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //保存文件
                    FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    int sindex = 0;
                    foreach (ListViewItem lvi in this.lvw_info.Items)
                    {
                        if (lvi.Tag.Equals("目录"))
                        {
                            sw.WriteLine(lvi.SubItems[1].Text + "----" + lvi.SubItems[2].Text);
                            sindex++;
                        }   
                    }

                    sw.Close();
                    fs.Close();
                    MessageBox.Show("导出成功！" + sindex + "条！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出数据发生异常！" + ex.Message);
            }
        }

        

        private void tsmi_about_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SWebScan V5.0 " + version+"\r\nBy shack2,www.shack2.org");
        }

        private void chk_404Mode_CheckedChanged(object sender, EventArgs e)
        {
            config.scanMode = 2;
            this.chk_fastMode.Checked = false;
            if (this.chk_404Mode.Checked) { 
            this.cbox_method.SelectedIndex = 1;
            }
        }

        private void txt_404_keys_TextChanged(object sender, EventArgs e)
        {
            config.key = this.txt_404_keys.Text;
        }

        private void cbox_show_SelectedIndexChanged(object sender, EventArgs e)
        {
            config.show = this.cbox_show.SelectedIndex;
        }

        private void cbox_isExists_SelectedIndexChanged(object sender, EventArgs e)
        {
            config.isExists = this.cbox_isExists.SelectedIndex;
        }
        public void changeThreadSize()
        {
            config.threadSize = Tools.convertToInt(this.cbox_threadSize.Text);
            stp.MaxThreads = config.threadSize;
            this.cbox_threadSize.Enabled = true;
        }
        private void cbox_threadSize_TextChanged(object sender, EventArgs e)
        {
            this.cbox_threadSize.Enabled = false;
            Thread t = new Thread(changeThreadSize);
            t.Start();
        }

        private void 在线更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(checkUpdate);
            th.Start();
        }

        private void cbox_length_SelectedIndexChanged(object sender, EventArgs e)
        {
            config.contentSelect = this.cbox_length.SelectedIndex;
        }

        private void txt_contentType_TextChanged(object sender, EventArgs e)
        {
            config.contentType = this.txt_contentType.Text;
        }

        private void txt_contentLength_TextChanged(object sender, EventArgs e)
        {
            config.contentLength = Tools.convertToInt(this.txt_contentLength.Text);
        }

        private void cbox_dicType_SelectedValueChanged(object sender, EventArgs e)
        {
            config.dicType = this.cbox_dicType.SelectedIndex;
            loadDirPath();
        }
    }
}
