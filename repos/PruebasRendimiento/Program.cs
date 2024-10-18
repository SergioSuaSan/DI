using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Rendimiento
{
    public class OperacionesMatematicas
    {

        public double Suma(double a, double b)
        {
            return a + b;
        }
        public double Multiplicacion(double a, double b)
        {
            return a * b;
        }
        public double Potencia(double @base, double exponente)
        {
            return Math.Pow(@base, exponente);
        }
        public double Potencia2(double @base, double exponente)
        {
            if (exponente == 0)
                return 1;
            var resultado = @base;
            for (int i = 1; i < exponente; i++)
            {
                resultado = resultado * @base;
            }
            return resultado;
        }
    }

 
    public class OperacionesMatematicasBenchmark
    {
        [Params(2, 3)]
        public int A { get; set; }
        [Params(2, 200)]
        public int B { get; set; }
        [Benchmark]
        public void Suma()
        {

            var operaciones = new OperacionesMatematicas();
            operaciones.Suma(A, B);
        }
        [Benchmark]
        public void Multiplicacion()
        {
            var operaciones = new OperacionesMatematicas();
            operaciones.Multiplicacion(A, B);
        }
        [Benchmark]
        public void Potencia()
        {
            var operaciones = new OperacionesMatematicas();
            operaciones.Potencia(A, B);
        }
        [Benchmark]
        public void Potencia2()
        {
            var operaciones = new OperacionesMatematicas();
            operaciones.Potencia2(A, B);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var summary =
            BenchmarkRunner.Run<OperacionesMatematicasBenchmark>();
            Console.Read();
        }
    }
}