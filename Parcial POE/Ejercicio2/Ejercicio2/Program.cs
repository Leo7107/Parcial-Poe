using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    class Producto
    {
        // Propiedades automáticas
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        // Propiedad calculada
        public decimal ValorTotal => Precio * Cantidad;
    }

    class Program
    {
        static void Main()
        {
            List<Producto> inventario = new List<Producto>();
            int opcion;

            do
            {
                Console.WriteLine("\n=== GESTOR DE INVENTARIO ===");
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Buscar producto");
                Console.WriteLine("3. Mostrar todos los productos");
                Console.WriteLine("4. Calcular valor total del inventario");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opción inválida.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        AgregarProducto(inventario);
                        break;
                    case 2:
                        BuscarProducto(inventario);
                        break;
                    case 3:
                        MostrarProductos(inventario);
                        break;
                    case 4:
                        CalcularValorTotal(inventario);
                        break;
                    case 5:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

            } while (opcion != 5);
        }

        static void AgregarProducto(List<Producto> inventario)
        {
            Console.Write("Ingrese nombre del producto: ");
            string nombre = Console.ReadLine();

            decimal precio;
            while (true)
            {
                Console.Write("Ingrese precio del producto (positivo): ");
                if (decimal.TryParse(Console.ReadLine(), out precio) && precio > 0)
                    break;
                Console.WriteLine("Error: El precio debe ser un número positivo.");
            }

            int cantidad;
            while (true)
            {
                Console.Write("Ingrese cantidad (0 o más): ");
                if (int.TryParse(Console.ReadLine(), out cantidad) && cantidad >= 0)
                    break;
                Console.WriteLine("Error: La cantidad debe ser un número entero mayor o igual a 0.");
            }

            inventario.Add(new Producto { Nombre = nombre, Precio = precio, Cantidad = cantidad });
            Console.WriteLine("Producto agregado con éxito.");
        }

        static void BuscarProducto(List<Producto> inventario)
        {
            Console.Write("Ingrese nombre del producto a buscar: ");
            string nombre = Console.ReadLine();

            var resultado = inventario.Where(p => p.Nombre.ToLower().Contains(nombre.ToLower()));

            if (resultado.Any())
            {
                foreach (var prod in resultado)
                {
                    Console.WriteLine($"{prod.Nombre} | Precio: ${prod.Precio:F2} | Cantidad: {prod.Cantidad} | Valor Total: ${prod.ValorTotal:F2}");
                }
            }
            else
            {
                Console.WriteLine(" Producto no encontrado.");
            }
        }

        static void MostrarProductos(List<Producto> inventario)
        {
            if (!inventario.Any())
            {
                Console.WriteLine("No hay productos en el inventario.");
                return;
            }

            Console.WriteLine("\n=== LISTA DE PRODUCTOS ===");
            foreach (var prod in inventario)
            {
                Console.WriteLine($" {prod.Nombre} | Precio: ${prod.Precio:F2} | Cantidad: {prod.Cantidad} | Valor Total: ${prod.ValorTotal:F2}");
            }
        }

        static void CalcularValorTotal(List<Producto> inventario)
        {
            decimal total = inventario.Sum(p => p.ValorTotal);
            Console.WriteLine($"Valor total del inventario: ${total:F2}");
        }
    }
}
