﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Safari.Seres;

namespace Safari
{
    public class Safari
    {
        private Ser[,] seres {  get; set; }
        private int filas {  get; set; }
        private int columnas { get; set; }
        private int maxLeones { get; set; }
        private int leones {  get; set; }   
        private int maxGacelas { get; set; }
        private int gacelas { get; set; }
        private int maxPlantas { get; set; }
        private int plantas { get; set; }
        private int maxNulos { get; set; }
        private int nulos { get; set; }
        private int pasos { get; set; }
        private bool pausado { get; set; }

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
            this.maxNulos = (filas * columnas) / 3;
            this.pasos = 0;
            this.seres = new Ser[10,10];
            this.pausado = false;



        }
        public Safari(int filas, int columnas)
        {
            this.seres = new Ser[filas,columnas];
            this.filas = filas;
            this.columnas = columnas;
            this.leones = 0;
            this.gacelas = 0;
            this.plantas = 0;
            this.nulos = 0;
            this.maxNulos = (filas * columnas) / 3;
            this.maxLeones = (filas * columnas) * 2 / 9;
            this.maxGacelas = (filas * columnas) * 4 / 9;
            this.maxPlantas = (filas * columnas) / 3;
            this.pasos = 0;
            this.pausado = false;



        }
        public void avanzar() 
        {
            pausado = false;
            pasos++;

            
        }
        public void pausar() {
            pausado = true;
        }
        public void resetear() { }
        public void autoplay() 
        {
            while (!pausado)
            {
                avanzar();
                System.Threading.Thread.Sleep(3000);
            }
        }
        public void terminar() {
            
        }

       
        public void iniciarSafari()
        {

            pasos = 0;
            pausado = true;
            bool Creado = false;
            this.maxLeones = (filas * columnas)/9;
            this.maxGacelas = (filas * columnas) * 2 / 9;
            this.maxPlantas = (filas * columnas) / 3;
            this.maxNulos = (filas * columnas) / 3;
            this.nulos = 0;
            this.leones = 0;
            this.gacelas = 0;
            this.plantas = 0;
            this.seres = new Ser[filas , columnas];

           
                for (int i = 0; i < filas; i++)
                {
                    for (int j = 0; j < columnas; j++)
                    {
                        Creado = false;

                    while (!Creado)
                    {
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
                                this.seres[i, j] = null;
                                    Creado = true;
                                }
                                break;
                        }



                    }
                }
            }
        }

        public int getFilas()
        {
            return this.filas;
        }
        public int getColumnas()
        {
            return this.columnas;
        }

        internal Ser[,] getSeres()
        {
            return this.seres;
        }
        public Ser getSer(int fila, int columna) {return this.seres[fila, columna]; }

        public String getNombre (Ser ser) {
            if (ser == null)
                return "";
            if (ser is Planta)
                return "Planta";
            if (ser is Gacela)
                return "Gacela";
            else 
                return "León";
            
          }

    }

}