using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio5
{
    enum Dificultad
    {
        Facil,
        Medio,
        Dificil
    }

    class Program
    {
        static void Main()
        {
            Random random = new Random();
            List<int> puntuaciones = new List<int>();
            string opcion;

            do
            {
                Console.WriteLine("\n=== JUEGO DE ADIVINANZA ===");
                Console.WriteLine("Seleccione nivel de dificultad:");
                Console.WriteLine("1. Fácil (1-50)");
                Console.WriteLine("2. Medio (1-100)");
                Console.WriteLine("3. Difícil (1-500)");

                int rangoMax = 100;
                Dificultad dificultad = Dificultad.Medio;

                string seleccion = Console.ReadLine();
                switch (seleccion)
                {
                    case "1": rangoMax = 50; dificultad = Dificultad.Facil; break;
                    case "2": rangoMax = 100; dificultad = Dificultad.Medio; break;
                    case "3": rangoMax = 500; dificultad = Dificultad.Dificil; break;
                }

                int numeroSecreto = random.Next(1, rangoMax + 1);
                int intentos = 0;
                int guess = 0;

                Console.WriteLine($"He pensado un número entre 1 y {rangoMax}. ¡Adivínalo!");

                while (guess != numeroSecreto)
                {
                    Console.Write("Tu intento: ");
                    if (!int.TryParse(Console.ReadLine(), out guess))
                    {
                        Console.WriteLine("Ingresa un número válido.");
                        continue;
                    }

                    intentos++;

                    if (guess == numeroSecreto)
                    {
                        Console.WriteLine($"¡Correcto! Lo lograste en {intentos} intentos.");
                        puntuaciones.Add(intentos);
                    }
                    else
                    {
                        int diferencia = Math.Abs(guess - numeroSecreto);
                        if (diferencia <= 3) Console.WriteLine("Muy cerca");
                        else if (diferencia <= 10) Console.WriteLine("Cerca");
                        else if (guess < numeroSecreto) Console.WriteLine("Muy bajo");
                        else Console.WriteLine("Muy alto");
                    }
                }

                Console.Write("¿Quieres jugar otra partida? (s/n): ");
                opcion = Console.ReadLine().ToLower();

            } while (opcion == "s");

            // Estadísticas
            if (puntuaciones.Any())
            {
                Console.WriteLine("\n=== ESTADÍSTICAS ===");
                Console.WriteLine($"Mejor puntuación (menos intentos): {puntuaciones.Min()}");
                Console.WriteLine($"Promedio de intentos: {puntuaciones.Average():F2}");
                Console.WriteLine("Historial de intentos: " + string.Join(", ", puntuaciones));
            }

            Console.WriteLine("Gracias por jugar :)");
        }
    }
}
