using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.Threading;

public class CmdTest : MonoBehaviour
{
    public static string cmd = "cd f";
    public string result;
    void Start()
    {
        Thread t = new Thread(new ThreadStart(NewThread));
        t.Start();
        string cmd = "ifconfig";
        result = RunCMD(cmd);
    }

    void Update()
    {
        
    }

    static void NewThread()
    {
        string str = RunCMD(cmd);
        print(str);
    }

    public static string RunCMD(string command)
    {
        Process p = new Process();
        p.StartInfo.FileName = "Terminal.exe";  //确定程序名
        p.StartInfo.Arguments = @"/Users/mirageele/Desktop/Tracker>" + command;  //指定程式命令行
        p.StartInfo.UseShellExecute = false;   //是否使用Shell
        p.StartInfo.RedirectStandardInput = true;   //重定向输入
        p.StartInfo.RedirectStandardOutput = true;   //重定向输出
        p.StartInfo.RedirectStandardError = true;    //重定向输出错误
        p.StartInfo.CreateNoWindow = false;        //设置不显示窗口
        p.Start();
        return p.StandardOutput.ReadToEnd();     //输出流取得命令行结果
    }
}
