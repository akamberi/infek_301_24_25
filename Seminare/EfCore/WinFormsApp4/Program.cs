using WinFormsApp4.Core.Data;
using WinFormsApp4.Forms;

namespace WinFormsApp4
{
    internal static class Program
    {
        public static string ConnectionString = "Data Source=LAB101\\SQLEXPRESS01;Initial Catalog=UsersDb;Integrated Security=True;Trust Server Certificate=True";        
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmUsers());
        }
    }
}