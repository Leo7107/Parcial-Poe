using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----Calculadora de Promedio de Calificaciones----");

            int cantidadNotas = 0;

            while (true)
            {
                Console.WriteLine("Ingrese la cantidad de calificaciones: ");
                if (int.TryParse(Console.ReadLine(), out cantidadNotas) && cantidadNotas > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error: Debe seleccionar un numero mayor a 0. ");
                }
            }
            double[] notas = new double[cantidadNotas];
            double suma = 0;

            for (int i = 0; i < cantidadNotas; i++)
            {
                double nota = 0;
                while (true)
                {
                    Console.WriteLine($"Ingrese la calificacion #{i + 1} (entre 0 y 10): ");

                    if (double.TryParse(Console.ReadLine(), out nota) && nota >= 0 && nota <= 10)
                    {
                        notas[i] = nota;
                        suma += nota;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Error: La calificacion debe estar entre 0 y 10.");
                    }
                }
            }
            double promedio = suma / cantidadNotas;
            double max = notas.Max();
            double min = notas.Min();
            foreach (double nota in notas)
            {
                if (nota > max)
                {
                    max = nota;
                }

                if (nota < min)
                {
                    min = nota;
                }
            }

            Console.WriteLine($"\nPromedio: {promedio:F2}");
            Console.WriteLine(promedio >= 7 ? "Estudiante Aprobado" : "Estudiante Reprobado");
            Console.WriteLine($"Calificación más alta: {max}");
            Console.WriteLine($"Calificación más baja: {min}");
        }
    }
}
