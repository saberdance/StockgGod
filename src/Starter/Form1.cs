using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Starter
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll")] //声明API函数
        public static extern int VirtualAllocEx(IntPtr hwnd, int lpaddress, int size, int type, int tect);
        [DllImport("kernel32.dll")]
        public static extern int WriteProcessMemory(IntPtr hwnd, int baseaddress, string buffer, int nsize, int filewriten);
        [DllImport("kernel32.dll")]
        public static extern int GetProcAddress(int hwnd, string lpname);
        [DllImport("kernel32.dll")]
        public static extern int GetModuleHandleA(string name);
        [DllImport("kernel32.dll")]
        public static extern int CreateRemoteThread(IntPtr hwnd, int attrib, int size, int address, int par, int flags, int threadid);
        public Form1()
        {
            InitializeComponent();
        }

        private bool InjectDll(string dllPath, string processName)
        {
            int ok1;
            //int ok2;
            //int hwnd;
            int baseaddress;
            int temp = 0;
            int hack;
            int yan;
            int dlllength;
            dlllength = dllPath.Length + 1;
            Process[] pname = Process.GetProcesses(); //取得所有进程
            foreach (Process name in pname) //遍历进程
            {
                //MessageBox.Show(name.ProcessName.ToLower());
                if (name.ProcessName.ToLower().IndexOf(processName) != -1) //找到进程开始注入
                {
                    MessageBox.Show(name.ProcessName.ToLower());
                    baseaddress = VirtualAllocEx(name.Handle, 0, dlllength, 4096, 4); //申请内存空间
                    if (baseaddress == 0) //返回0则操作失败，下面都是
                    {
                        MessageBox.Show("申请内存空间失败！！");
                        return false;
                    }
                    ok1 = WriteProcessMemory(name.Handle, baseaddress, dllPath, dlllength, temp); //写内存
                    if (ok1 == 0)
                    {

                        MessageBox.Show("写内存失败！！");
                        return false;
                    }
                    hack = GetProcAddress(GetModuleHandleA("Kernel32"), "LoadLibraryA"); //取得loadlibarary在kernek32.dll地址
                    if (hack == 0)
                    {
                        MessageBox.Show("无法取得函数LoadLibraryA的入口点！！");
                        return false;
                    }
                    yan = CreateRemoteThread(name.Handle, 0, 0, hack, baseaddress, 0, temp); //创建远程线程。
                    if (yan == 0)
                    {
                        MessageBox.Show("创建远程线程失败！！");
                        return false;
                    }
                    else
                    {
                        MessageBox.Show("已成功注入dll!!");
                    }
                }
            }
            return false;
        }

        private void Inject_Click(object sender, EventArgs e)
        {
            string dllname;
            dllname = "CppCore.dll";
            string dllPath = AppDomain.CurrentDomain.BaseDirectory + "\\" + dllname;
            int dlllength;
            //暂时先写死
            string processName = ProcessName.Text;
            InjectDll(dllPath, processName);
        }
    }
}
