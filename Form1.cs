using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;




namespace 关闭Windows_defender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RegistryKey key1 = Registry.LocalMachine;
            RegistryKey software1 = key1.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\SecurityHealthService"); 
            string GetValue1 = software1.GetValue("Start").ToString();
            if(GetValue1 == "2")
            {
                label1.Text = "状态： 已开启！";
            }
            else if (GetValue1 == "3")
            {
                label1.Text = "状态： 已被第三方软件接管！";
            }
            else if (GetValue1 == "4")
            {
                label1.Text = "状态： 已关闭！";
            }
            RegistryKey key2 = Registry.LocalMachine;
            RegistryKey software2 = key2.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\wscsvc"); 
            string GetValue2 = software2.GetValue("Start").ToString();
            if (GetValue2 == "2")
            {
                label2.Text = "状态： 已开启！";
            }
            else if (GetValue2 == "4")
            {
                label2.Text = "状态： 已关闭！";
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //开启安全健康服务
            RegistryKey key1 = Registry.LocalMachine;
            RegistryKey software1 = key1.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\SecurityHealthService", true);
            software1.SetValue("Start",2);
            string GetValue1 = software1.GetValue("Start").ToString();
            if (GetValue1 == "2")
            {
                MessageBox.Show("开启成功！重启生效");
                label1.Text = "状态： 已开启！";
            }
            else
            {
                MessageBox.Show("错误！请以管理员权限运行若仍未解决我也没办法！");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //关闭安全健康服务
            RegistryKey key1 = Registry.LocalMachine;
            RegistryKey software1 = key1.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\SecurityHealthService", true);
            software1.SetValue("Start", 4);
            string GetValue1 = software1.GetValue("Start").ToString();
            if (GetValue1 == "4") {
                MessageBox.Show("关闭成功！重启生效");
                label1.Text = "状态： 已关闭！";
            }
            else { MessageBox.Show("错误！请以管理员权限运行若仍未解决我也没办法！"); }
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            //安全健康服务状态
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            //安全中心服务状态
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            //关闭window Defender安全中心服务
            RegistryKey key2 = Registry.LocalMachine;
            RegistryKey software2 = key2.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\wscsvc", true);
            software2.SetValue("Start", 4);
            string GetValue2 = software2.GetValue("Start").ToString();
            if (GetValue2 == "4") {
                MessageBox.Show("关闭成功！重启生效");
                label2.Text = "状态： 已关闭！";
            }
            else
            {
                MessageBox.Show("错误！请以管理员权限运行若仍未解决我也没办法！");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //开启window Defender安全中心服务
            RegistryKey key2 = Registry.LocalMachine;
            RegistryKey software2 = key2.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\wscsvc", true);
            software2.SetValue("Start", 2);
            string GetValue2 = software2.GetValue("Start").ToString();
            if (GetValue2 == "2")
            {
                MessageBox.Show("开启成功！重启生效");
                label2.Text = "状态： 已开启！";
            }
            else
            {
                MessageBox.Show("错误！请以管理员权限运行若仍未解决我也没办法！");
            }
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
