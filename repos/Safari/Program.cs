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
            //Creo un Safari
            Safari miSafari = new Safari(10,10);
            //Creo un controlador que tenga dentro mi instancia de Safari
            Controlador controlador = new Controlador(miSafari);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Creo una ventana que tenga mi instancia del controlador
            VentanaP ventanaP = new VentanaP(controlador);

            //Hago funcionar la ventana
            Application.Run( ventanaP);
        }
    }
}