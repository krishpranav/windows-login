using System;
using System.Windows.Forms;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.IO;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;


namespace windowslogin
{
    static class Program
    {
        ///<summary>
        ///the main entry point for the application
        ///</summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize new screen
            LogonScreen s = new LogonScreen();

            // Set username
            string SIZE = string.Empty;

            try{
                
                UserPrincipal user = UserPrincipal.Current;
                s.Username = user.SamAccountName;
                s.DisplayName = user.DisplayName;
                SID = user.Sid.Value;
                s.Context = user.ContextType;
            }
            catch (Exception)
            {
                s.Username = Environment.UserName;
                s.Context = ContextType.Machine;
            }

            //set background
            string imagePath = GetImagePath(SID) ?? @"C:\Windows\Web\Screen\img100.jpg";
            if (File.Exists(imagePath))
                s.BackgroundImage = Image.FromFile(imagePath);
            else
                s.BackColor = Color.FromArgb(0, 90, 158);

            //show
            Application.Run(s);
        }

        static string GetImagePath(string SID)
        {
            string foundImage = null;

             try
            {
                // Open registry, if path exists
                string regPath = string.Format(@"SOFTWARE\Microsoft\Windows\CurrentVersion\SystemProtectedUserData\{0}\AnyoneRead\LockScreen", SID);
                RegistryKey regLockScreen = Registry.LocalMachine.OpenSubKey(regPath);
                if (regLockScreen == null)
                    return null;

                // Obtain lock screen index
                string imageOrder = (string)regLockScreen.GetValue(null);
                int ord = (int)imageOrder[0];

                
            }
    }
}
