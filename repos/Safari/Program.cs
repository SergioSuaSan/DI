namespace Safari
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Safari miSafari = new Safari(10,10);
            Controlador controlador = new Controlador(miSafari);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            VentanaP ventanaP = new VentanaP(controlador);

            Application.Run( ventanaP);
        }
    }
}