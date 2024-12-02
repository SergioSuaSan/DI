using Safari.Seres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari
{
    class MetodosBuscar_deprecated
    {
        /*
        public Ser buscarGacela(int fila, int columna //ALEJANDRO, String comida)
        {
            /*
             *ALEJANDRO, método indicado por él que es bastante más eficiente que el mío, pendiente de cambio
             
             * int maxderecha =0
             * int maxizquierda = 0
             * int maxarriba = 0
             * int maxabajo = 0
            //if (mira si esta a la derecha)
                maxderecha =1
              if (mira si esta a la izquierda)
                maxizquiera = 1
                =1
              if (mira abajo)
                =1
              if (mira arriba)  
                

            //Creo una lista donde irán todas las gacelas que encuentre de forma adyacente
            List<Gacela> listaPosibles = new List<Gacela>();


            if ((fila == 0) && (columna == 0))
            {
                for (int i = fila; i <= fila + 1; i++)
                {
                    for (int j = columna; j <= columna + 1; j++)
                    {
                        if (getSer(i, j) is Gacela)
                        {
                            //Guardo el ser en un array
                            listaPosibles.Add((Gacela)getSer(i, j));
                        }
                    }
                }
                //retorno un ser random del array
                Random rndo = new Random();
                int final = rndo.Next(0, listaPosibles.Count);
                if (listaPosibles.Count != 0)
                {
                    return listaPosibles[final];

                }
                else return null;
            }
            else
            if ((fila == getSeres().GetLength(0) - 1) && (columna == getSeres().GetLength(1) - 1))
            {
                for (int i = fila - 1; i <= fila; i++)
                {
                    for (int j = columna - 1; j <= columna; j++)
                    {
                        //getSer(i,j).getType().Name == comida
                        if (getSer(i, j) is Gacela)
                        {
                            //Guardo el ser en un array
                            listaPosibles.Add((Gacela)getSer(i, j));
                        }
                    }
                }
                //retorno un ser random del array
                Random rndo = new Random();
                int final = rndo.Next(0, listaPosibles.Count);
                if (listaPosibles.Count != 0)
                {
                    return listaPosibles[final];

                }
                else return null;
            }
            else
             if ((fila == getSeres().GetLength(0) - 1) && columna == 0)
            {
                for (int i = fila - 1; i <= fila; i++)
                {
                    for (int j = columna; j <= columna + 1; j++)
                    {
                        if (getSer(i, j) is Gacela)
                        {
                            //Guardo el ser en un array
                            listaPosibles.Add((Gacela)getSer(i, j));
                        }
                    }
                }
                //retorno un ser random del array
                Random rndo = new Random();
                int final = rndo.Next(0, listaPosibles.Count);
                if (listaPosibles.Count != 0)
                {
                    return listaPosibles[final];

                }
                else return null;
            }
            else
            if (fila == 0 && (columna == getSeres().GetLength(1) - 1))
            {
                for (int i = fila; i <= fila + 1; i++)
                {
                    for (int j = columna - 1; j <= columna; j++)
                    {
                        if (getSer(i, j) is Gacela)
                        {
                            //Guardo el ser en un array
                            listaPosibles.Add((Gacela)getSer(i, j));
                        }
                    }
                }
                //retorno un ser random del array
                Random rndo = new Random();
                int final = rndo.Next(0, listaPosibles.Count);
                if (listaPosibles.Count != 0)
                {
                    return listaPosibles[final];

                }
                else return null;
            }
            else
            if (fila == 0)
            {
                for (int i = fila; i <= fila + 1; i++)
                {
                    for (int j = columna - 1; j <= columna + 1; j++)
                    {
                        if (getSer(i, j) is Gacela)
                        {
                            //Guardo el ser en un array
                            listaPosibles.Add((Gacela)getSer(i, j));
                        }
                    }
                }
                //retorno un ser random del array
                Random rndo = new Random();
                int final = rndo.Next(0, listaPosibles.Count);
                if (listaPosibles.Count != 0)
                {
                    return listaPosibles[final];

                }
                else return null;

            }
            else
            if (columna == 0)
            {
                for (int i = fila - 1; i <= fila + 1; i++)
                {
                    for (int j = columna; j <= columna + 1; j++)
                    {
                        if (getSer(i, j) is Gacela)
                        {
                            //Guardo el ser en un array
                            listaPosibles.Add((Gacela)getSer(i, j));
                        }
                    }
                }
                //retorno un ser random del array
                Random rndo = new Random();
                int final = rndo.Next(0, listaPosibles.Count);
                if (listaPosibles.Count != 0)
                {
                    return listaPosibles[final];

                }
                else return null;
            }
            else


            if (fila == getSeres().GetLength(0) - 1)
            {
                for (int i = fila - 1; i <= fila; i++)
                {
                    for (int j = columna - 1; j <= columna + 1; j++)
                    {
                        if (getSer(i, j) is Gacela)
                        {
                            //Guardo el ser en un array
                            listaPosibles.Add((Gacela)getSer(i, j));
                        }
                    }
                }
                //retorno un ser random del array
                Random rndo = new Random();
                int final = rndo.Next(0, listaPosibles.Count);
                if (listaPosibles.Count != 0)
                {
                    return listaPosibles[final];

                }
                else return null;
            }
            else
            if (columna == getSeres().GetLength(1) - 1)
            {
                for (int i = fila; i <= fila + 1; i++)
                {
                    for (int j = columna - 1; j <= columna; j++)
                    {
                        if (getSer(i, j) is Gacela)
                        {
                            //Guardo el ser en un array
                            listaPosibles.Add((Gacela)getSer(i, j));
                        }
                    }
                }
                //retorno un ser random del array
                Random rndo = new Random();
                int final = rndo.Next(0, listaPosibles.Count);
                if (listaPosibles.Count != 0)
                {
                    return listaPosibles[final];

                }
                else return null;
            }
            else
            {
                for (int i = fila - 1; i <= fila + 1; i++)
                {
                    for (int j = columna - 1; j <= columna + 1; j++)
                    {
                        if (getSer(i, j) is Gacela)
                        {
                            //Guardo el ser en un array
                            listaPosibles.Add((Gacela)getSer(i, j));
                        }
                    }
                }
                //retorno un ser random del array
                Random rndo = new Random();
                int final = rndo.Next(0, listaPosibles.Count);
                if (listaPosibles.Count != 0)
                {
                    listaPosibles.ForEach(it => { Console.WriteLine(it); });
                    return listaPosibles[final];

                }
                else return null;
            }


        }
        */

        /*
        //Copia del método buscarGacelas adaptado a Plantas
        public Ser buscarPlanta(int fila, int columna)
        {
            List<Planta> listaPosibles = new List<Planta>();
            if ((fila == 0) && (columna == 0))
            {
                for (int i = fila; i <= fila + 1; i++)
                {
                    for (int j = columna; j <= columna + 1; j++)
                    {
                        if (getSer(i, j) is Planta)
                        {
                            //Guardo el ser en un array
                            listaPosibles.Add((Planta)getSer(i, j));
                        }
                    }
                }
                //retorno un ser random del array
                Random rndo = new Random();
                int final = rndo.Next(0, listaPosibles.Count);
                if (listaPosibles.Count != 0)
                {
                    return listaPosibles[final];

                }
                else return null;
            }
            else
            if ((fila == getSeres().GetLength(0) - 1) && (columna == getSeres().GetLength(1) - 1))
            {
                for (int i = fila - 1; i <= fila; i++)
                {
                    for (int j = columna - 1; j <= columna; j++)
                    {
                        if (getSer(i, j) is Planta)
                        {
                            //Guardo el ser en un array
                            listaPosibles.Add((Planta)getSer(i, j));
                        }
                    }
                }
                //retorno un ser random del array
                Random rndo = new Random();
                int final = rndo.Next(0, listaPosibles.Count);
                if (listaPosibles.Count != 0)
                {
                    return listaPosibles[final];

                }
                else return null;
            }
            else
             if ((fila == getSeres().GetLength(0) - 1) && columna == 0)
            {
                for (int i = fila - 1; i <= fila; i++)
                {
                    for (int j = columna; j <= columna + 1; j++)
                    {
                        if (getSer(i, j) is Planta)
                        {
                            //Guardo el ser en un array
                            listaPosibles.Add((Planta)getSer(i, j));
                        }
                    }
                }
                //retorno un ser random del array
                Random rndo = new Random();
                int final = rndo.Next(0, listaPosibles.Count);
                if (listaPosibles.Count != 0)
                {
                    return listaPosibles[final];

                }
                else return null;
            }
            else
            if (fila == 0 && (columna == getSeres().GetLength(1) - 1))
            {
                for (int i = fila; i <= fila + 1; i++)
                {
                    for (int j = columna - 1; j <= columna; j++)
                    {
                        if (getSer(i, j) is Planta)
                        {
                            //Guardo el ser en un array
                            listaPosibles.Add((Planta)getSer(i, j));
                        }
                    }
                }
                //retorno un ser random del array
                Random rndo = new Random();
                int final = rndo.Next(0, listaPosibles.Count);
                if (listaPosibles.Count != 0)
                {
                    return listaPosibles[final];

                }
                else return null;
            }
            else
            if (fila == 0)
            {
                for (int i = fila; i <= fila + 1; i++)
                {
                    for (int j = columna - 1; j <= columna + 1; j++)
                    {
                        if (getSer(i, j) is Planta)
                        {
                            //Guardo el ser en un array
                            listaPosibles.Add((Planta)getSer(i, j));
                        }
                    }
                }
                //retorno un ser random del array
                Random rndo = new Random();
                int final = rndo.Next(0, listaPosibles.Count);
                if (listaPosibles.Count != 0)
                {
                    return listaPosibles[final];

                }
                else return null;

            }
            else
            if (columna == 0)
            {
                for (int i = fila - 1; i <= fila + 1; i++)
                {
                    for (int j = columna; j <= columna + 1; j++)
                    {
                        if (getSer(i, j) is Planta)
                        {
                            //Guardo el ser en un array
                            listaPosibles.Add((Planta)getSer(i, j));
                        }
                    }
                }
                //retorno un ser random del array
                Random rndo = new Random();
                int final = rndo.Next(0, listaPosibles.Count);
                if (listaPosibles.Count != 0)
                {
                    return listaPosibles[final];

                }
                else return null;
            }
            else


            if (fila == getSeres().GetLength(0) - 1)
            {
                for (int i = fila - 1; i <= fila; i++)
                {
                    for (int j = columna - 1; j <= columna + 1; j++)
                    {
                        if (getSer(i, j) is Planta)
                        {
                            //Guardo el ser en un array
                            listaPosibles.Add((Planta)getSer(i, j));
                        }
                    }
                }
                //retorno un ser random del array
                Random rndo = new Random();
                int final = rndo.Next(0, listaPosibles.Count);
                if (listaPosibles.Count != 0)
                {
                    return listaPosibles[final];

                }
                else return null;
            }
            else
            if (columna == getSeres().GetLength(1) - 1)
            {
                for (int i = fila - 1; i <= fila + 1; i++)
                {
                    for (int j = columna - 1; j <= columna; j++)
                    {
                        if (getSer(i, j) is Planta)
                        {
                            //Guardo el ser en un array
                            listaPosibles.Add((Planta)getSer(i, j));
                        }
                    }
                }
                //retorno un ser random del array
                Random rndo = new Random();
                int final = rndo.Next(0, listaPosibles.Count);
                if (listaPosibles.Count != 0)
                {
                    return listaPosibles[final];

                }
                else return null;
            }
            else
            {
                for (int i = fila - 1; i <= fila + 1; i++)
                {
                    for (int j = columna - 1; j <= columna + 1; j++)
                    {
                        if (getSer(i, j) is Planta)
                        {
                            //Guardo el ser en un array
                            listaPosibles.Add((Planta)getSer(i, j));
                        }
                    }
                }
                //retorno un ser random del array
                Random rndo = new Random();
                int final = rndo.Next(0, listaPosibles.Count);
                if (listaPosibles.Count != 0)
                {
                    return listaPosibles[final];

                }
                else return null;
            }


        }

        */
        /*
        //Copia del método buscarGacelas adaptado a Vacío
        public Ser buscarVacio(int fila, int columna)
        {
            List<Vacio> listaPosibles = new List<Vacio>();
            if ((fila == 0) && (columna == 0))
            {
                for (int i = fila; i <= fila + 1; i++)
                {
                    for (int j = columna; j <= columna + 1; j++)
                    {
                        if (getSer(i, j) is Vacio)
                        {
                            //Guardo el ser en un array
                            listaPosibles.Add((Vacio)getSer(i, j));
                        }
                    }
                }
                //retorno un ser random del array
                Random rndo = new Random();
                int final = rndo.Next(0, listaPosibles.Count);
                if (listaPosibles.Count != 0)
                {
                    return listaPosibles[final];

                }
                else return null;
            }

            else
            if ((fila == getSeres().GetLength(0) - 1) && (columna == getSeres().GetLength(1) - 1))
            {
                for (int i = fila - 1; i <= fila; i++)
                {
                    for (int j = columna - 1; j <= columna; j++)
                    {
                        if (getSer(i, j) is Vacio)
                        {
                            //Guardo el ser en un array
                            listaPosibles.Add((Vacio)getSer(i, j));
                        }
                    }
                }
                //retorno un ser random del array
                Random rndo = new Random();
                int final = rndo.Next(0, listaPosibles.Count);
                if (listaPosibles.Count != 0)
                {
                    return listaPosibles[final];

                }
                else return null;
            }

            else
             if ((fila == getSeres().GetLength(0) - 1) && columna == 0)
            {
                for (int i = fila - 1; i <= fila; i++)
                {
                    for (int j = columna; j <= columna + 1; j++)
                    {
                        if (getSer(i, j) is Vacio)
                        {
                            //Guardo el ser en un array
                            listaPosibles.Add((Vacio)getSer(i, j));
                        }
                    }
                }
                //retorno un ser random del array
                Random rndo = new Random();
                int final = rndo.Next(0, listaPosibles.Count);
                if (listaPosibles.Count != 0)
                {
                    return listaPosibles[final];

                }
                else return null;
            }

            else
            if (fila == 0 && (columna == getSeres().GetLength(1) - 1))
            {
                for (int i = fila; i <= fila + 1; i++)
                {
                    for (int j = columna - 1; j <= columna; j++)
                    {
                        if (getSer(i, j) is Vacio)
                        {
                            //Guardo el ser en un array
                            listaPosibles.Add((Vacio)getSer(i, j));
                        }
                    }
                }
                //retorno un ser random del array
                Random rndo = new Random();
                int final = rndo.Next(0, listaPosibles.Count);
                if (listaPosibles.Count != 0)
                {
                    return listaPosibles[final];

                }
                else return null;
            }

            else
            if (fila == 0)
            {
                for (int i = fila; i <= fila + 1; i++)
                {
                    for (int j = columna - 1; j <= columna + 1; j++)
                    {
                        if (getSer(i, j) is Vacio)
                        {
                            //Guardo el ser en un array
                            listaPosibles.Add((Vacio)getSer(i, j));
                        }
                    }
                }
                //retorno un ser random del array
                Random rndo = new Random();
                int final = rndo.Next(0, listaPosibles.Count);
                if (listaPosibles.Count != 0)
                {
                    return listaPosibles[final];

                }
                else return null;

            }
            else
            if (columna == 0)
            {
                for (int i = fila - 1; i <= fila + 1; i++)
                {
                    for (int j = columna; j <= columna + 1; j++)
                    {
                        if (getSer(i, j) is Vacio)
                        {
                            //Guardo el ser en un array
                            listaPosibles.Add((Vacio)getSer(i, j));
                        }
                    }
                }
                //retorno un ser random del array
                Random rndo = new Random();
                int final = rndo.Next(0, listaPosibles.Count);
                if (listaPosibles.Count != 0)
                {
                    return listaPosibles[final];

                }
                else return null;
            }
            else


            if (fila == getSeres().GetLength(0) - 1)
            {
                for (int i = fila - 1; i <= fila; i++)
                {
                    for (int j = columna - 1; j <= columna + 1; j++)
                    {
                        if (getSer(i, j) is Vacio)
                        {
                            //Guardo el ser en un array
                            listaPosibles.Add((Vacio)getSer(i, j));
                        }
                    }
                }
                //retorno un ser random del array
                Random rndo = new Random();
                int final = rndo.Next(0, listaPosibles.Count);
                if (listaPosibles.Count != 0)
                {
                    return listaPosibles[final];

                }
                else return null;
            }
            else
            if (columna == getSeres().GetLength(1) - 1)
            {
                for (int i = fila - 1; i <= fila + 1; i++)
                {
                    for (int j = columna - 1; j <= columna; j++)
                    {
                        if (getSer(i, j) is Vacio)
                        {
                            //Guardo el ser en un array
                            listaPosibles.Add((Vacio)getSer(i, j));
                        }
                    }
                }
                //retorno un ser random del array
                Random rndo = new Random();
                int final = rndo.Next(0, listaPosibles.Count);
                if (listaPosibles.Count != 0)
                {
                    return listaPosibles[final];

                }
                else return null;
            }
            else
            {
                for (int i = fila - 1; i <= fila + 1; i++)
                {
                    for (int j = columna - 1; j <= columna + 1; j++)
                    {
                        if (getSer(i, j) is Vacio)
                        {
                            //Guardo el ser en un array
                            listaPosibles.Add((Vacio)getSer(i, j));
                        }
                    }
                }
                //retorno un ser random del array
                Random rndo = new Random();
                int final = rndo.Next(0, listaPosibles.Count);
                if (listaPosibles.Count != 0)
                {
                    return listaPosibles[final];

                }

                else return null;
            }


        }
        */

    }
}
