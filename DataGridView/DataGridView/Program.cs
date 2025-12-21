using Entities;
using Services;
using Services.Contracts;
namespace DataGridView
{
    /// <summary>
    /// программный класс
    /// </summary>
    public class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(new StorageManager(new Storage())));
        }
    }
}