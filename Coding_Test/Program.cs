namespace Coding_Test
{
    internal static class Program
    {
       
        [STAThread]
        static void Main()
        {
            
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Sale());
        }
    }
}