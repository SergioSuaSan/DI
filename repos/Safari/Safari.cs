using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
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

        /*
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
            this.seres = new Ser[10, 10];
            this.pausado = false;



        }
        */
        //Constructor parametrizado por si quiero poder elegir cuántas filas y columnas pongo
        public Safari(int filas, int columnas)
        {
            this.seres = new Ser[filas, columnas];
            this.filas = filas;
            this.columnas = columnas;
            this.leones = 0;
            this.gacelas = 0;
            this.plantas = 0;
            this.nulos = 0;
            this.maxNulos = (filas * columnas) - (maxGacelas + maxLeones + maxPlantas);
            this.maxLeones =  (filas * columnas) * 2 / 9;
            this.maxGacelas = (filas * columnas) * 4 / 9;
            this.maxPlantas =  (filas * columnas) / 3;
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
                    if (this.seres[i, j] is Animal)
                    {
                        ((Animal)this.seres[i, j]).setMovido(false);
                    }
                }
            }
            //Recorro el array por segunda vez haciendo ya todo el trabajo
            for (int i = 0; i < this.filas; i++)
            {

                for (int j = 0; j < this.columnas; j++)
                {
                    #region TurnoAnimales ;

                    //Si el Ser en esa posición es un León y no se ha movido entra en el if
                    if (this.seres[i, j] is Leon && !((Leon)this.seres[i, j]).getMovido())
                        {
                            
                            morirseDeHambre(seres[i, j]);
                            //Buscamos Si hay una gacela cerca. Si la hay nos la comemos y nos movemos a su posición
                            Ser provisional = buscarGacela(i, j/* //ALEJANDRO ,Leon.comida*/);

                            if (provisional != null)
                                Console.WriteLine(provisional.GetType().Name);
                         if (seres[i, j].getTiempoParaReproducirse() >= 6)
                        {

                            reproducirse(seres[i, j]);

                        }
                        else if (provisional is Gacela)
                            {
                                // Console.WriteLine("Leon en: " + i + ", " + j+"\n Se come a "+provisional.GetType().Name+" en: " + provisional.getPosicioni() + ", " + provisional.getPosicionj());
                                //Transformamos la Gacela en el León
                                seres[provisional.getPosicioni(), provisional.getPosicionj()] = seres[i, j];
                                Console.WriteLine(seres[provisional.getPosicioni(), provisional.getPosicionj()].GetType().Name + "\n");
                                //Ponemos su movido a true para que no se pueda volver a mover en este paso
                                ((Animal)this.seres[provisional.getPosicioni(), provisional.getPosicionj()]).setMovido(true);
                                ((Animal)this.seres[provisional.getPosicioni(), provisional.getPosicionj()]).setTiempoSinComer(0);
                                ((Animal)this.seres[provisional.getPosicioni(), provisional.getPosicionj()]).setTiempoParaReproducirse(((Animal)this.seres[provisional.getPosicioni(), provisional.getPosicionj()]).getTiempoParaReproducirse() + 1);
                                // ACTUALIZAMOS LA NUEVA POSICIÓN DEL LEÓN
                                seres[provisional.getPosicioni(), provisional.getPosicionj()].setPosicioni(provisional.getPosicioni());
                                seres[provisional.getPosicioni(), provisional.getPosicionj()].setPosicionj(provisional.getPosicionj());
                                //Dejamos el antiguo lugar del León como Vacío
                                seres[i, j] = new Vacio(i, j);
                                gacelas--;
                            }
                           
                            else
                            {
                                moverse(seres[i, j]);
                            }

                        Console.WriteLine("Fin del Leon \n");

                        }

                    //Copia de lo de León pero con Gacela
                    if (this.seres[i, j] is Gacela && !((Gacela)this.seres[i, j]).getMovido())
                    {
                        morirseDeHambre(seres[i, j]);
                        Ser provisional = buscarPlanta(i, j);

                        Console.WriteLine($"La Gacela en la posición  ({seres[i, j].getPosicioni()}, {seres[i, j].getPosicionj()})  lleva {seres[i, j].getTiempoParaReproducirse()} días para reproducirse");
                        if (seres[i, j].getTiempoParaReproducirse() >= 4)
                        {
                            Console.WriteLine($"La Gacela en la posición  ({seres[i, j].getPosicioni()}, {seres[i, j].getPosicionj()})  ha empezado la reproducción");
                            reproducirse(seres[i, j]);


                        }
                         else if (provisional is Planta)
                        {

                            seres[provisional.getPosicioni(), provisional.getPosicionj()] = seres[i, j];
                            Debug.WriteLine(provisional.getPosicioni() + " " + provisional.getPosicionj());
                            ((Animal)this.seres[provisional.getPosicioni(), provisional.getPosicionj()]).setMovido(true);
                            ((Animal)this.seres[provisional.getPosicioni(), provisional.getPosicionj()]).setTiempoSinComer(0);
                            ((Animal)this.seres[provisional.getPosicioni(), provisional.getPosicionj()]).setTiempoParaReproducirse(((Animal)this.seres[provisional.getPosicioni(), provisional.getPosicionj()]).getTiempoParaReproducirse() + 1);
                            seres[provisional.getPosicioni(), provisional.getPosicionj()].setPosicioni(provisional.getPosicioni());
                            seres[provisional.getPosicioni(), provisional.getPosicionj()].setPosicionj(provisional.getPosicionj());
                            seres[i, j] = new Vacio(i, j);
                            plantas--;
                        }
                       
                        else
                        {

                            moverse(seres[i, j]);

                        }
                        Console.WriteLine("Fin de la gacela \n");
                    }

                    #endregion
                    //Copia de lo de León pero con Gacela

                    if (this.seres[i, j] is Planta)
                    {
                        this.seres[i, j].setTiempoParaReproducirse(this.seres[i, j].getTiempoParaReproducirse() + 1);
                        if (seres[i, j].getTiempoParaReproducirse() >= 2)
                        {
                            this.seres[i, j].setTiempoParaReproducirse(0);
                            reproducirse(seres[i, j]);
                           
                        }
                        Console.WriteLine("Fin de la planta \n");


                    }

                    
                }






            }
        }

        //Ponemos el pausado a true para que no pueda avanzar
        public void pausar() { pausado = true; }
        //Creamos el safari de nuevo
        public void resetear() {
            //Inicializamos todos los parámetros del safari

            pasos = 0;
            pausado = true;
           

            this.maxLeones = (filas * columnas) / 9;
            this.maxGacelas = (filas * columnas) * 2 / 9;
            this.maxPlantas = (filas * columnas) / 3;
            this.maxNulos = (filas * columnas) - (maxGacelas + maxLeones + maxPlantas);
            this.nulos = 0;
            this.leones = 0;
            this.gacelas = 0;
            this.plantas = 0;
            this.seres = new Ser[filas, columnas];
            iniciarSafari(); }
        //EL autoplay.
        public void autoplay(VentanaP ventanaP)
        {
            // Ejecutar en un subproceso separado para no bloquear la UI
            Task.Run(() =>
            {
                while (!pausado) // Condición de pausa
                {
                    avanzar();      // Lógica para avanzar (implementa este método según tu lógica)

                    ventanaP.Invoke((MethodInvoker)delegate
                    {
                        ventanaP.Refresh();
                    });

                    Thread.Sleep(500); // Delay de 500ms (ajusta según lo que necesites)
                }
            });
        }







        //Metodo moverse parametrizado. Me dan un ser y si es animal, lo muevo a un vacio
        private void moverse(Ser ser)
        {
            if (ser is Animal)
            {
                //Sacamos la posición del animal
                int viejai = ser.getPosicioni();
                int viejaj = ser.getPosicionj();
                //Buscamos si hay un vacío cerca
                //Ser provisional = buscarVacio(viejai, viejaj);
                Ser provisional = buscarVacio_cgpt(viejai, viejaj);
                if (provisional is Vacio)
                {
                    //Le damos 2/3 de posibilidades de moverse. Es posible que el animal no se mueva.
                    Random rnd = new Random();
                    int num = rnd.Next(0, 6);
                    if (num < 5)
                    {
                       
                        //Sacamos la posición del vacio
                        int nuevai = provisional.getPosicioni();
                        int nuevaj = provisional.getPosicionj();
                        Console.WriteLine(ser.GetType().Name + " en: " + viejai + ", " + viejaj + "\n Se mueve a " + provisional.GetType().Name + " en: " + nuevai + ", " + nuevaj);
                        //Convertimos el vacio en un león
                        seres[nuevai,nuevaj] = seres[viejai, viejaj];
                        //Actualizamos la posición del animal que se ha movido
                        seres[nuevai, nuevaj].setPosicioni(nuevai);
                        seres[nuevai, nuevaj].setPosicionj(nuevaj);
                        //Decimos que el animal que se haya movido cambie su estado a "movido"
                        ((Animal)this.seres[nuevai, nuevaj]).setMovido(true);
                        //Decimos que el animal que se haya movido aumente en 1 su tiempo de vida
                        ((Animal)this.seres[nuevai, nuevaj]).setTiempoDeVida(((Animal)this.seres[nuevai, nuevaj]).getTiempoVida() + 1);
                        ((Animal)this.seres[nuevai, nuevaj]).setTiempoSinComer(((Animal)this.seres[nuevai, nuevaj]).getTiempoSinComer() + 1);

                        seres[viejai, viejaj] = new Vacio(viejai, viejaj);

                        Console.WriteLine("El nuevo animal es: " + this.seres[nuevai, nuevaj].ToString());


                    }
                }
            }

        }
        private void reproducirse(Ser ser)
        {
            if (!(ser is Vacio))
            {
                //Sacamos la posición del ser
                int viejai = ser.getPosicioni();
                int viejaj = ser.getPosicionj();
                //Buscamos si hay un vacío cerca
               // Ser provisional = buscarVacio(viejai, viejaj);
                Ser provisional = buscarVacio_cgpt(viejai, viejaj);
                if (provisional is Vacio)
                {
                        //Sacamos la posición del vacio
                        int nuevai = provisional.getPosicioni();
                        int nuevaj = provisional.getPosicionj();
                        Console.WriteLine($"El ser {ser.GetType().Name} Se va a reproducir en {provisional.GetType().Name}  en:  {nuevai} ,  {nuevaj}");
                        //Creamos en el nuevo ser el vacío
                       
                    if (seres[viejai, viejaj] is Leon)
                    {
                       this.seres[nuevai,nuevaj]= new Leon(nuevai,nuevaj);
                        leones++;
                    }
                    else if (seres[viejai, viejaj] is Gacela)
                    {
                        this.seres[nuevai, nuevaj] = new Gacela(nuevai,nuevaj);
                        gacelas++;
                    }
                    else if (seres[viejai, viejaj] is Planta)
                    {
                        this.seres[nuevai, nuevaj] = new Planta(nuevai,nuevaj);
                        plantas++;
                    }
                        
                        //Decimos que el animal que se haya movido cambie su estado a "movido"
                        if (this.seres[nuevai,nuevaj] is Animal)
                        ((Animal)this.seres[nuevai, nuevaj]).setMovido(true);

                        seres[viejai, viejaj].setTiempoParaReproducirse(0);
                        seres[viejai, viejaj].setTiempoSinComer(seres[viejai,viejaj].getTiempoSinComer()+1);
                        Console.WriteLine("El nuevo animal es: " + this.seres[nuevai, nuevaj].ToString());


                    
                }
            }

        }

        private void morirseDeHambre(Ser ser)
        {
            Console.WriteLine($"El ser {ser.GetType().Name} \n en la posición ({ser.getPosicioni()}, {ser.getPosicionj()}) \n lleva {ser.getTiempoSinComer()} dias sin comer");
            if (ser.getTiempoSinComer() >= 3)
            {
            seres[ser.getPosicioni(), ser.getPosicionj()] = new Vacio(ser.getPosicioni(), ser.getPosicionj());
                if (ser is Leon)
                {
                    leones--;
                }
                if (ser is Gacela)
                {
                    gacelas--;
                }
                Console.WriteLine($"El ser {ser.GetType().Name} \n en la posición ({ser.getPosicioni()}, {ser.getPosicionj()})ha muerto por hambre");

            }

        }


       
           
            

        


        //Iniciamos el Safari
        public void iniciarSafari()
        {

           
            bool Creado = false;

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
                                this.seres[i, j] = new Vacio(i,j);
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


        /*
        //Devolvemos un nombre según el Ser que demos
        //Se puede cambiar en  el toString();
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
        */


        //Método que busca una gacela en las 8 casillas adyacentes a la posición del Ser que se indique

        //Optimización realizada por chatgpt. Es increible lo fácil que era optimizarlo y que no era capaz de verlo
        public Ser buscarGacela(int fila, int columna)
        {
            // Lista para guardar los vacíos encontrados
            List<Gacela> listaPosibles = new List<Gacela>();

            // Dimensiones del array
            int filas = getSeres().GetLength(0);
            int columnas = getSeres().GetLength(1);

            // Iterar por las celdas vecinas (incluye la actual)
            for (int i = fila - 1; i <= fila + 1; i++)
            {
                for (int j = columna - 1; j <= columna + 1; j++)
                {
                    // Validar si la posición está dentro de los límites del array
                    if (i >= 0 && i < filas && j >= 0 && j < columnas)
                    {
                        // Comprobar si el ser es "Vacio"
                        if (getSer(i, j) is Gacela)
                        {
                            listaPosibles.Add((Gacela)getSer(i, j));
                        }
                    }
                }
            }

            // Si hay vacíos disponibles, seleccionar uno al azar
            if (listaPosibles.Count > 0)
            {
                int final = random.Next(0, listaPosibles.Count);
                return listaPosibles[final];
            }

            // Si no hay vacíos, retornar null
            return null;
        }

        //Optimización realizada por chatgpt. Es increible lo fácil que era optimizarlo y que no era capaz de verlo
        public Ser buscarPlanta(int fila, int columna)
        {
            // Lista para guardar los vacíos encontrados
            List<Planta> listaPosibles = new List<Planta>();

            // Dimensiones del array
            int filas = getSeres().GetLength(0);
            int columnas = getSeres().GetLength(1);

            // Iterar por las celdas vecinas (incluye la actual)
            for (int i = fila - 1; i <= fila + 1; i++)
            {
                for (int j = columna - 1; j <= columna + 1; j++)
                {
                    // Validar si la posición está dentro de los límites del array
                    if (i >= 0 && i < filas && j >= 0 && j < columnas)
                    {
                        // Comprobar si el ser es "Vacio"
                        if (getSer(i, j) is Planta)
                        {
                            listaPosibles.Add((Planta)getSer(i, j));
                        }
                    }
                }
            }

            // Si hay vacíos disponibles, seleccionar uno al azar
            if (listaPosibles.Count > 0)
            {
                int final = random.Next(0, listaPosibles.Count);
                return listaPosibles[final];
            }

            // Si no hay vacíos, retornar null
            return null;
        }

        //Optimización realizada por chatgpt. Es increible lo fácil que era optimizarlo y que no era capaz de verlo
        public Ser buscarVacio_cgpt(int fila, int columna)
        {
            // Lista para guardar los vacíos encontrados
            List<Vacio> listaPosibles = new List<Vacio>();

            // Iterar por las celdas vecinas (incluye la actual)
            for (int i = fila - 1; i <= fila + 1; i++)
            {
                for (int j = columna - 1; j <= columna + 1; j++)
                {
                    // Validar si la posición está dentro de los límites del array
                    if (i >= 0 && i < this.filas && j >= 0 && j < this.columnas)
                    {
                        // Comprobar si el ser es "Vacio"
                        if (getSer(i, j) is Vacio)
                        {
                            listaPosibles.Add((Vacio)getSer(i, j));
                        }
                    }
                }
            }

            // Si hay vacíos disponibles, seleccionar uno al azar
            if (listaPosibles.Count > 0)
            {
                int final = random.Next(0, listaPosibles.Count);
                return listaPosibles[final];
            }

            // Si no hay vacíos, retornar null
            return null;
        }

        // Instancia de Random estática para evitar reinicio de la semilla
        private static Random random = new Random();

        internal String getPasos()    {return this.pasos.ToString();        }

        internal string getPlantas() { return this.plantas.ToString(); }

        internal string getGacelas()   {  return this.gacelas.ToString();   }
        internal string getLeones() { return this.leones.ToString(); }

        internal void despausar()
        {
            pausado = false;
        }
    }

}