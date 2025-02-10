

namespace Safari.Seres
{
    internal class Leon : Carnivoro
    {
        //Constructor parametrizado por posición
        public Leon(int i, int j) : base(i, j) { }


        //Metodo necesario
        public override string ToString()
        {
            return "León";
        }
    }
}
