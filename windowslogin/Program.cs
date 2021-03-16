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
        }
    }
}
