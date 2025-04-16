Sistema de Validación de Subsidios para Afiliados
📌 Descripción del Proyecto
Sistema desarrollado para la gestión y validación de subsidios para afiliados a una caja de compensación familiar. Permite:

Registrar afiliados con sus datos personales y socioeconómicos

Calcular automáticamente el valor del subsidio según criterios establecidos

Almacenar la información en tres estructuras de datos diferentes (Pila, Cola, Lista)

Generar reportes específicos para cada estructura

Sistema de autenticación con contraseña numérica

🛠 Requisitos del Sistema
Hardware:
Procesador: 1 GHz o superior

RAM: 2 GB mínimo

Espacio en disco: 50 MB disponibles

Software:
Sistema operativo: Windows 7/10/11

.NET Framework 4.7.2 o superior

Visual Studio 2019 o superior (para desarrollo)

📥 Instalación
Descargar el proyecto:

bash
Copy
git clone https://github.com/tu-usuario/Fase3_AndersonMolina.git
O descargar el ZIP desde el repositorio

Abrir la solución en Visual Studio:

Navegar a la carpeta del proyecto

Abrir el archivo Fase3_AndersonMolina.sln

Compilar el proyecto:

Menú principal → Compilar → Compilar solución

Ejecutar la aplicación:

Presionar F5 o hacer clic en "Iniciar"

🚀 Ejecución del Programa
Pantalla de Login (Form1)
Contraseña predeterminada: 1234

Ingresar la contraseña usando los botones numéricos

Botones disponibles:

Limpiar: Borra la contraseña ingresada

Ingresar: Valida la contraseña y accede al sistema

Acerca de: Muestra información del desarrollador

Salir: Cierra la aplicación

Formulario Principal (Datos)
1. Registro de Afiliados
Campos obligatorios:

Tipo de identificación (CC, CE, NUIP, PAS)

Número de identificación (solo números)

Nombre completo (solo letras)

Salario (valor numérico)

Estrato (1-6)

Afiliación al SISBEN (Sí/No)

Fecha de afiliación

Estructuras de datos disponibles:

Pila (LIFO - Último en entrar, primero en salir)

Cola (FIFO - Primero en entrar, primero en salir)

Lista (Inserción al final)

2. Funcionalidades principales
Botón Registrar: Agrega el afiliado a la estructura seleccionada

Botón Limpiar: Vacía todos los campos del formulario

Botón Salir: Cierra la aplicación

Reportes:

Pila: Muestra la suma total de subsidios

Cola: Muestra el número de registros

Lista: Muestra el promedio de salarios

3. Eliminación de registros
Pila: Elimina el último registro añadido

Cola: Elimina el primer registro añadido

Lista: Elimina un registro específico por número de identificación

🖥️ Estructura del Código
Clases principales
Form1.cs:

Pantalla de login con autenticación por contraseña

Navegación al formulario principal

Datos.cs:

Formulario principal con todas las funcionalidades

Implementación de las tres estructuras de datos

Lógica de cálculo de subsidios

AcercaDe.cs:

Muestra información del desarrollador

Diseño elegante con efectos visuales

EstructuraDatosAfiliado (clase interna):

csharp
Copy
public class EstructuraDatosAfiliado
{
    public string TipoIdentificacion { get; set; }
    public string NumeroIdentificacion { get; set; }
    public string NombreCompleto { get; set; }
    public decimal Salario { get; set; }
    public int Estrato { get; set; }
    public bool AfiliadoSISBEN { get; set; }
    public decimal ValorSubsidio { get; set; }
    public DateTime FechaAfiliacion { get; set; }
}
🔍 Criterios de Subsidios
Para afiliados al SISBEN:
Estrato	Subsidio Base	Adicional (si salario < $500,000)
1	$450,000	+$50,000
2	$350,000	+$50,000
3	$250,000	+$50,000
4	$150,000	+$50,000
5-6	$0	-
Para no afiliados al SISBEN:
Estrato	Subsidio Base	Adicional (si salario < $1,000,000)
1	$300,000	+$150,000
2	$200,000	+$150,000
3	$100,000	+$150,000
4	$50,000	+$150,000
5-6	$0	-
📝 Notas Adicionales
Validaciones: Todos los campos tienen validaciones para asegurar datos correctos

Persistencia: Los datos se mantienen en memoria durante la ejecución

Diseño: Interfaz intuitiva con colores profesionales y distribución lógica

✒️ Autor
Anderson Molina
Estudiante de Ingeniería de Sistemas
Universidad Nacional Abierta y a Distancia (UNAD)
Materia: Estructura de Datos - 2025

📜 Licencia
Este proyecto está bajo la Licencia MIT
