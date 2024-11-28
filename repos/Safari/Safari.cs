using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Safari.Seres;

namespace Safari
{
    public class Safari
    {
        //Atributos
        private Ser[,] seres;
        private int filas;
        private int columnas;
        private int maxLeones;  
        private int leones;    
        private int maxGacelas;
        private int gacelas;    
        private int maxPlantas;
        private int plantas;
        private int maxNulos;
        private int nulos;
        private int pasos;
        private bool pausado;

        //Constructor vacío
        public Safari()
        {
            this.filas = 10;
            this.columnas = 10;
            this.leones = 0;
            this.gacelas = 0;
            this.plantas = 0;
            this.nulos = 0;
            this.maxLeones = (filas * columnas) * 2 / 9;
            this.maxGacelas = (filas * columnas) * 4 / 9;
            this.maxPlantas = (filas * columnas) / 3;
            this.maxNulos = (filas * columnas) - (maxGacelas + maxLeones + maxPlantas);
            this.pasos = 0;
            this.seres = new Ser[10,10];
            this.pausado = false;



        }
        //Constructor parametrizado por si quiero poder elegir cuántas filas y columnas pongo
        public Safari(int filas, int columnas)
        {
            this.seres = new Ser[filas,columnas];
            this.filas = filas;
            this.columnas = columnas;
            this.leones = 0;
            this.gacelas = 0;
            this.plantas = 0;
            this.nulos = 0;
            this.maxNulos = (filas * columnas) - (maxGacelas + maxLeones + maxPlantas);
            this.maxLeones = (filas * columnas) * 2 / 9;
            this.maxGacelas = (filas * columnas) * 4 / 9;
            this.maxPlantas = (filas * columnas) / 3;
            this.pasos = 0;
            this.pausado = false;



        }

        //Avanzar un paso, o STEP
        public void avanzar() 
        {
            //Si está pausado, lo despauso
            pausado = false;
            //Aumento el número de pasos
            pasos++;
            //Recorro una vez el array poniendo el movido como false para que todos los animales se puedan mover
            for (int i = 0; i < this.filas; i++)
            {
                for (int j = 0; j < this.columnas; j++)
                {
                   if  ( this.seres[i,j] is Animal)
                    {
                        ((Animal) this.seres[i,j]).setMovido(false);
                    }
                }
            }
            //Recorro el array por segunda vez haciendo ya todo el trabajo
            for (int i = 0; i < this.filas; i++)
            {
                for (int j = 0; j < this.columnas; j++)
                {
                    //Si el Ser en esa posición es un León y no se ha movido entra en el if
                    if (this.seres[i, j] is Leon&& !((Leon)this.seres[i,j]).getMovido())
                    {
                        //Buscamos Si hay una gacela cerca. Si la hay nos la comemos y nos movemos a su posición
                        // ALEJANDRO //Leon leon = seres[i,j] as Leon;
                        Ser provisional = buscarGacela(i, j/* //ALEJANDRO ,Leon.comida*/);
                        if (provisional != null)
                        Console.WriteLine(provisional.GetType().Name);

                        if (provisional is Gacela)
                        {
                            Console.WriteLine("Leon en: " + i + ", " + j+"\n Se come a "+provisional.GetType().Name+" en: " + provisional.getPosicioni() + ", " + provisional.getPosicionj());
                            //Transformamos la Gacela en el León
                            seres[provisional.getPosicioni(), provisional.getPosicionj()] = seres[i,j];
                            Console.WriteLine(seres[provisional.getPosicioni(), provisional.getPosicionj()].GetType().Name + "\n");
                            //Ponemos su movido a true para que no se pueda volver a mover en este paso
                            ((Animal)this.seres[provisional.getPosicioni(), provisional.getPosicionj()]).setMovido(true);
                           //Dejamos el antiguo lugar del León como Vacío
                            seres[i, j] = new Vacio(i,j);
                            gacelas--;
                        }
                        
                    }
                    //Copia de lo de León pero con Gacela
                    if (this.seres[i, j] is Gacela && !((Gacela)this.seres[i, j]).getMovido())
                    {
                        Ser provisional = buscarPlanta(i, j);

                        if (provisional is Planta)
                        {

                            seres[provisional.getPosicioni(), provisional.getPosicionj()] = seres[i, j];
                            Debug.WriteLine(provisional.getPosicioni() + " " + provisional.getPosicionj());
                            ((Animal)this.seres[provisional.getPosicioni(), provisional.getPosicionj()]).setMovido(true);
                            seres[i, j] = new Vacio(i, j);
                            plantas--;
                        }

                    }

                }
            }
            
        }
        //Ponemos el pausado a true para que no pueda avanzar
        public void pausar() { pausado = true;}
        //Creamos el safari de nuevo
        public void resetear() { iniciarSafari(); }
        //EL autoplay aún no debería funcionar. No está hecho con lo de los hilos, en proceso.
        public void autoplay() 
        {

            while (!pausado)
            {
                avanzar();
                
               
            }
        }

       
        //Iniciamos el Safari
        public void iniciarSafari()
        {
            //Inicializamos todos los parámetros del safari
            pasos = 0;
            pausado = true;
            bool Creado = false;
            this.maxLeones = (filas * columnas)/9;
            this.maxGacelas = (filas * columnas) * 2 / 9;
            this.maxPlantas = (filas * columnas) / 3;
            this.maxNulos = (filas * columnas)-(maxGacelas+maxLeones+maxPlantas);
            this.nulos = 0;
            this.leones = 0;
            this.gacelas = 0;
            this.plantas = 0;
            this.seres = new Ser[filas , columnas];

            

            //Creamos un Ser en cada posición del array
            for (int i = 0; i < filas; i++)
                {
                    for (int j = 0; j < columnas; j++)
                    {
                        //Para cada posición, nada más empezar indicamos que no está creado. Solo cuando haya un nuevo
                        //Ser en esta posición pasará a la siguiente
                        Creado = false;

                    while (!Creado)
                    {
                        //Elegimos qué Ser se creará de manera randomizada y aumentamos su número
                        int rnd = new Random().Next(0, 4);
                        switch (rnd)
                        {
                            case 0:
                                if (plantas < maxPlantas)
                                {
                                    plantas++;
                                    this.seres[i, j] = new Planta(i, j);
                                    Creado = true;
                                }
                                break;
                            case 1:
                                if (gacelas < maxGacelas)
                                {
                                    gacelas++;
                                this.seres[i, j] = new Gacela(i, j);
                                    Creado = true;
                                }
                                break;
                            case 2:
                                if (leones < maxLeones)
                                {
                                    leones++;
                                this.seres[i, j] = new Leon(i, j);
                                    Creado = true;
                                }
                                break;
                            case 3:
                                if (nulos <= maxNulos)
                                {
                                    nulos++;
                                this.seres[i, j] = new Vacio(j,i);
                                    Creado = true;
                                }
                                break;
                        }



                    }
                }
            }
        }

        public int getFilas(){return this.filas;}
        public int getColumnas() {return this.columnas;}

        //Obtiene TODOS los seres
        internal Ser[,] getSeres(){return this.seres;}
        //Obtiene UN ser de  una determinada posición
        public Ser getSer(int fila, int columna) {return this.seres[fila, columna]; }

        //Devolvemos un nombre según el Ser que demos
        public String getNombre (Ser ser) {
            if (ser is Vacio)
                return "Vacío";
            if (ser is Planta)
                return "Planta";
            if (ser is Gacela)
                return "Gacela";
            else 
                return "León";
            
          }


        //Método que busca una gacela en las 8 casillas adyacentes a la posición del Ser que se indique
        public Ser buscarGacela(int fila, int columna /*//ALEJANDRO, String comida*/)
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
                */

            //Creo una lista donde irán todas las gacelas que encuentre de forma adyacente
            List<Gacela> listaPosibles = new List<Gacela> ();

            /*
             *Tengo que hacer bucles independientes dependiendo de la posición en la que estoy. Si estoy en una esquina 
             *solo puedo mirar 3 espacios determinados, en vez de los 8. Lo mismo pasa si estoy en el borde de una fila o
             *columna, solo puedo mirar 5 espacios. Así que me veo obligado a hacer bucles para cada posible posición
             *distinta, por si está en una de las cuatro esquinas, uno de los cuatro bordes o por el medio.
             */
            if ((fila == 0) && (columna == 0))
            {
                for (int i = fila; i <= fila + 1; i++)
                {
                    for (int j = columna; j <= columna + 1; j++)
                    {
                        if (getSer(i, j) is Gacela)
                        {
                            //Guardo el ser en un array
                            listaPosibles.Add( (Gacela) getSer(i, j));
                        }
                    }
                }
                //retorno un ser random del array
                Random rndo = new Random();
                 int final = rndo.Next(0,listaPosibles.Count);
                if (listaPosibles.Count != 0)
                {
                    return listaPosibles[final];

                }
                else return null;
            }
            else
            if ((fila == getSeres().GetLength(0) - 1) && (columna == getSeres().GetLength(1) - 1))
            {
                for (int i = fila-1; i <= fila; i++)
                {
                    for (int j = columna-1; j <= columna; j++)
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
             if ((fila == getSeres().GetLength(0)-1) && columna == 0)
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
            if (fila == 0 && (columna == getSeres().GetLength(1)-1))
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


            if (fila == getSeres().GetLength(0)-1)
            {
                for (int i = fila - 1; i <= fila; i++)
                {
                    for (int j = columna-1; j <= columna + 1; j++)
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
            if (columna == getSeres().GetLength(1)-1)
            {
                for (int i = fila; i <= fila + 1; i++)
                {
                    for (int j = columna -1; j <= columna; j++)
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
                    return listaPosibles[final];

                }
                else return null;
            }

           
        }


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
                for (int i = fila-1; i <= fila; i++)
                {
                    for (int j = columna-1; j <= columna; j++)
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
                for (int i = fila-1; i <= fila; i++)
                {
                    for (int j = columna-1; j <= columna + 1; j++)
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
                for (int i = fila-1; i <= fila + 1; i++)
                {
                    for (int j = columna-1; j <= columna; j++)
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
                for (int i = fila-1; i <= fila; i++)
                {
                    for (int j = columna-1; j <= columna; j++)
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
                    for (int j = columna-1; j <= columna + 1; j++)
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
                for (int i = fila-1; i <= fila + 1; i++)
                {
                    for (int j = columna-1; j <= columna; j++)
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

        internal String getPasos()    {return this.pasos.ToString();        }

        internal string getPlantas() { return this.plantas.ToString(); }

        internal string getGacelas()   {  return this.gacelas.ToString();   }
        internal string getLeones() { return this.leones.ToString(); }

    }

}