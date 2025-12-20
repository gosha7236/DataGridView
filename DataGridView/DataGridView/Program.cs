using Entities;
using Services;
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

            // Composition Root
            StorageManager.Initialize(new Storage());

            // Синхронная загрузка при старте
            StorageManager.LoadAsync().GetAwaiter().GetResult();

            Application.Run(new MainForm());
        }
    }
}