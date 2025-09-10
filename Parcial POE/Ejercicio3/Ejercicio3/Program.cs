using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Conversor de Números a Palabras ===");
            int numero;

            do
            {
                Console.Write("Ingrese un número (1-999, 0 para salir): ");

                if (!int.TryParse(Console.ReadLine(), out numero))
                {
                    Console.WriteLine("⚠️ Entrada inválida.");
                    continue;
                }

                if (numero == 0) break;

                if (numero < 1 || numero > 999)
                {
                    Console.WriteLine("⚠️ El número debe estar entre 1 y 999.");
                    continue;
                }

                Console.WriteLine($"{numero} = {ConvertirNumeroAPalabras(numero)}");

            } while (numero != 0);

            Console.WriteLine("Programa finalizado.");
        }

        static string ConvertirNumeroAPalabras(int numero)
        {
            string[] unidades = { "", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve" };
            string[] decenas = { "", "diez", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa" };
            string[] especiales = { "diez", "once", "doce", "trece", "catorce", "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve" };
            string[] centenas = { "", "ciento", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos", "setecientos", "ochocientos", "novecientos" };

            // Separar centenas, decenas y unidades
            int centena = numero / 100;
            int resto = numero % 100;
            int decena = resto / 10;
            int unidad = resto % 10;

            string resultado = "";

            // Casos especiales 100 y múltiplos exactos
            if (numero == 100) return "cien";

            // Centenas
            if (centena > 0)
            {
                resultado += centenas[centena] + " ";
            }

            // Casos 10-19
            if (resto >= 10 && resto <= 19)
            {
                resultado += especiales[resto - 10];
            }
            // Casos 20-29
            else if (resto >= 20 && resto <= 29)
            {
                if (resto == 20)
                    resultado += "veinte";
                else
                    resultado += "veinti" + unidades[unidad];
            }
            // Casos 30-99
            else
            {
                if (decena > 0)
                {
                    resultado += decenas[decena];
                    if (unidad > 0) resultado += " y ";
                }
                if (unidad > 0)
                {
                    resultado += unidades[unidad];
                }
            }

            return resultado.Trim();
        }
    }
}
