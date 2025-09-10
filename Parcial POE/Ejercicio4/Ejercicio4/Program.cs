using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ejercicio4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ANALIZADOR DE TEXTO ===");
            Console.Write("Ingrese un texto: ");
            string texto = Console.ReadLine();

            // Total de caracteres
            int totalConEspacios = texto.Length;
            int totalSinEspacios = texto.Replace(" ", "").Length;

            // Palabras
            string[] palabras = Regex.Split(texto, @"\W+").Where(p => p != "").ToArray();
            int totalPalabras = palabras.Length;

            // Oraciones (separadas por . ! ?)
            int totalOraciones = Regex.Split(texto, @"[.!?]").Where(o => o.Trim() != "").Count();

            // Palabra más larga y más corta
            string palabraLarga = palabras.OrderByDescending(p => p.Length).FirstOrDefault();
            string palabraCorta = palabras.OrderBy(p => p.Length).FirstOrDefault();

            // Frecuencia de vocales
            string vocales = "aeiou";
            var frecuenciaVocales = vocales.Select(v => new
            {
                Vocal = v,
                Conteo = texto.ToLower().Count(c => c == v)
            });

            // Conteo de palabras que comienzan con cada letra
            var conteoIniciales = palabras
                .GroupBy(p => p[0].ToString().ToUpper())
                .Select(g => new { Letra = g.Key, Conteo = g.Count() });

            // Resultados
            Console.WriteLine($"\nTotal de caracteres (con espacios): {totalConEspacios}");
            Console.WriteLine($"Total de caracteres (sin espacios): {totalSinEspacios}");
            Console.WriteLine($"Número de palabras: {totalPalabras}");
            Console.WriteLine($"Número de oraciones: {totalOraciones}");
            Console.WriteLine($"Palabra más larga: {palabraLarga}");
            Console.WriteLine($"Palabra más corta: {palabraCorta}");

            Console.WriteLine("\nFrecuencia de vocales:");
            foreach (var v in frecuenciaVocales)
                Console.WriteLine($"  {v.Vocal}: {v.Conteo}");

            Console.WriteLine("\nPalabras que comienzan con cada letra:");
            foreach (var g in conteoIniciales.OrderBy(g => g.Letra))
                Console.WriteLine($"  {g.Letra}: {g.Conteo}");
        }
    }
}
