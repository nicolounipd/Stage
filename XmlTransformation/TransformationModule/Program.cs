using System;
using System.Windows.Forms;
using TransformationModule.Contract;

namespace TransformationModule
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TrasformtaionForm());
        }
    }
}
