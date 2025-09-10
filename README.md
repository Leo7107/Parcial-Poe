# Parcial de Programación Orientada a Eventos 

Este documento contiene las respuestas a las preguntas teóricas de los ejercicios del parcial de Programación Orientada a Eventos (POE), junto con ejemplos de código donde aplica.

---

## Ejercicio 1: Calculadora de Promedio de Calificaciones

**Pregunta completa:**  
Explique la diferencia entre `int.Parse()`, `int.TryParse()` y `TryParse()`.  
¿Cuál es más recomendable usar para validar entrada del usuario y por qué?  
Proporcione un ejemplo de cada uno y explique qué sucede cuando se ingresa un valor inválido.

**Respuesta:**  

- **`int.Parse(string s)`**: Convierte un string a entero.  
  - Ejemplo:
    ```csharp
    int numero = int.Parse("10"); // devuelve 10
    ```
  - Si el valor es inválido (ej. `"abc"`), lanza una **excepción `FormatException`**.

- **`int.TryParse(string s, out int resultado)`**: Intenta convertir un string a entero.  
  - Ejemplo:
    ```csharp
    int numero;
    bool exito = int.TryParse("10", out numero); // exito = true, numero = 10
    ```
  - Si el valor es inválido (ej. `"abc"`), devuelve `false` y `numero = 0`. No lanza excepción.

- **`TryParse()`**: es simplemente otra forma de referirse a `int.TryParse()`. No existe una sobrecarga independiente solo llamada `TryParse()`.

- **Recomendación:**  
  Usar `int.TryParse()` para validar la entrada del usuario porque **evita que el programa se detenga por excepción** al ingresar valores no numéricos.

---

## Ejercicio 2: Gestor de Inventario Simple

**Pregunta completa:**  
En este ejercicio del inventario, se utiliza una clase `Producto` con propiedades y un método calculado. Explique:  

1. **¿Qué son las propiedades automáticas en C#?**  
   - Propiedades que permiten declarar `get` y `set` sin un campo privado explícito.  
   - Ejemplo:
     ```csharp
     public string Nombre { get; set; }
     ```

2. **¿Cuál es la diferencia entre un campo y una propiedad?**  
   - Campo: variable dentro de la clase, ej. `private string nombre;`  
   - Propiedad: controla el acceso a un campo, ej.:
     ```csharp
     public string Nombre
     {
         get { return nombre; }
         set { nombre = value; }
     }
     ```

3. **¿Qué ventajas tiene usar `get` y `set` en las propiedades?**  
   - Permite validar datos antes de asignarlos.  
   - Encapsula la lógica de acceso.  
   - Facilita propiedades de solo lectura o solo escritura.

4. **Explique cómo funciona la propiedad calculada `ValorTotal => Precio * Cantidad`**  
   - No almacena un valor, sino que calcula dinámicamente el resultado al acceder a ella.  
   - Ejemplo:
     ```csharp
     Producto p = new Producto { Precio = 10, Cantidad = 5 };
     Console.WriteLine(p.ValorTotal); // 50
     ```

---

## Ejercicio 3: Conversor de Números a Palabras

**Pregunta completa:**  
Explique:  

1. **¿Cómo funciona el operador módulo en C#?**  
   - Devuelve el residuo de una división: `a % b`.  
   - Ejemplo: `157 % 100 = 57`

2. **¿Por qué es útil para separar unidades, decenas y centenas?**  
   - Permite extraer cada posición decimal de un número usando división y módulo.  
   - Ejemplo:
     ```csharp
     int numero = 157;
     int centena = numero / 100; // 1
     int resto = numero % 100;   // 57
     int decena = resto / 10;    // 5
     int unidad = resto % 10;    // 7
     ```

3. **Describa el algoritmo usado para convertir 157 a "ciento cincuenta y siete"**  
   - `centena = 157 / 100 = 1 → "ciento"`  
   - `resto = 157 % 100 = 57`  
   - `decena = 57 / 10 = 5 → "cincuenta"`  
   - `unidad = 57 % 10 = 7 → "siete"`  
   - Concatenar: `"ciento" + "cincuenta y siete"`

4. **¿Qué otros problemas se pueden resolver usando aritmética modular?**  
   - Determinar si un número es par o impar (`n % 2`)  
   - Verificar múltiplos (`n % 5 == 0`)  
   - Ciclos de reloj, días de la semana  
   - Cálculos de dígitos de control

---

## Ejercicio 4: Analizador de Texto

**Pregunta completa:**  
Explique:  

1. **¿Cuál es la diferencia entre tipos por valor y tipos por referencia?**  
   - Valor: almacenan directamente el contenido (ej. `int`, `double`).  
   - Referencia: almacenan la dirección en memoria del objeto (ej. `string`, `class`).  

2. **¿Por qué usar decimal para precios en lugar de double?**  
   - `decimal` evita errores de redondeo en cálculos financieros.  
   - `double` es más adecuado para cálculos científicos.  

3. **¿Qué sucede en memoria cuando se crea un array de 1000 elementos?**  
   - Se reserva un bloque contiguo de memoria para almacenar los elementos del array.  

4. **¿Cuándo se libera la memoria ocupada por las variables locales?**  
   - Al salir del método donde se declararon, y el Garbage Collector limpia la memoria de objetos sin referencias.

---

## Ejercicio 5: Juego de Adivinanza Mejorado

**Pregunta completa:**  
1. **¿Qué son las enumeraciones en C# y cuándo usarlas?**  
   - Tipo que define un conjunto de constantes con nombre.  
   - Se usan para mejorar legibilidad en lugar de números mágicos.  
   - Ejemplo:
     ```csharp
     enum Dificultad { Facil, Medio, Dificil }
     ```

2. **¿Cuál es la diferencia entre switch statement tradicional y switch expression?**  
   - Switch tradicional: más largo, usa `case` y `break`.  
   - Switch expression: más compacto, retorna un valor directamente.  
   - Ejemplo:
     ```csharp
     string nivel = opcion switch
     {
         1 => "Fácil",
         2 => "Medio",
         _ => "Otro"
     };
     ```

---

## Preguntas Finales

1. **¿Cuál es la diferencia entre tipos por valor y tipos por referencia?**  
   - Valor: copia directa del contenido; Referencia: copia de la dirección en memoria.  

2. **¿Por qué usar decimal para precios en lugar de double?**  
   - Mayor precisión y evita errores de redondeo en cálculos financieros.  

3. **¿Qué sucede en memoria cuando se crea un array de 1000 elementos?**  
   - Se reserva un bloque contiguo de memoria para almacenar 1000 elementos.  

4. **¿Cuándo se libera la memoria ocupada por las variables locales?**  
   - Al salir del método donde fueron declaradas, y el Garbage Collector limpia la memoria de objetos sin referencias.

5. **¿Qué significa que un método sea estático?**  
   - Puede llamarse sin crear una instancia de la clase.  

6. **¿Cuándo es apropiado usar métodos estáticos vs. métodos de instancia?**  
   - Estáticos: cuando no dependen de datos de un objeto.  
   - Instancia: cuando necesitan acceder a propiedades o campos del objeto.  

7. **¿Por qué Main() debe ser estático?**  
   - Porque es el punto de entrada del programa y se ejecuta sin crear un objeto de la clase.  

8. **¿Qué limitaciones tienen los métodos estáticos?**  
   - No pueden acceder a variables de instancia ni a `this`.  
   - Solo pueden llamar a otros métodos estáticos o acceder a campos estáticos.
