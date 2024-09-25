using System;

//interface Ejemplo
//{
//    void hola();
//}



//class Ejem_Consola : Ejemplo
//{
//    public struct Persona
//    {
//        int edad;
//        String nombre;
//        String apellido;
//        float altura;
//        public Persona()
//        {
//            edad = 0;
//            nombre = "";
//            apellido = "";
//            altura = 0;
//        }

//        public Persona(int edad_p, String nombre_p, String apellido_p, float altura_p)
//        {
//            this.edad = edad_p;
//            this.nombre = nombre_p;
//            this.apellido = apellido_p;
//            this.altura = altura_p;
//        }

//        public int getEdad() {return edad;}
//        public String getNombre() {return nombre;}
//        public String getApellido() {return apellido;}
//        public float getAltura() {return altura;}




//    }

//    private static void Main(string[] args)
//    {
//        Persona juan = new Persona();
//        Persona nacho = new Persona(44, "Nacho", "Gómez", 1.72f);
//        Ejem_Consola class_ejem = new Ejem_Consola();
//        class_ejem.hola();
//        Console.WriteLine(juan.getNombre() + " tiene " + juan.getEdad() + " años, y " + nacho.getNombre() + " tiene " + nacho.getEdad() + " años");

//    }

//  void Ejemplo.hola()
//    {
//        Console.WriteLine("hola a todos");
//    }
//}

//----------------------------------------------------------

namespace DynamicExamples
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    ExampleClass ec = new ExampleClass();
        //    dynamic retorno = ec.ExampleMethod(1);
        //    Console.WriteLine(retorno);

        //    retorno = ec.ExampleMethod("Cadena");
        //    Console.WriteLine(retorno);

        //    Console.WriteLine("Dime la variable que quieres saber; ");
        //    dynamic var_dinamica = Console.Read();
        //    retorno = ec.ExampleMethod(var_dinamica);
        //    Console.WriteLine(retorno);
        //}
    }
    class ExampleClass
    {
        static dynamic field;
        dynamic Prop
        {
            get; set;
        }
        public dynamic ExampleMethod(dynamic d)
        {
            if (d is int)
            {
                return "La variable es de tipo entero";
            }
            else
            {
                return "La variable NO es de tipo entero";
            }
        }
    }
}

