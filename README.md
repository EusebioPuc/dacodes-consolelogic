# dacodes-consolelogic

## Instalación

* Descargar los archivos.
* Al abrir el archivo de la solución (ConsoleLogic.sln) se verá en el Solution Explorer que no se encuentra el proyecto,
  porque la ruta es diferente, entonces hacemos clic derecho sobre el proyecto no encontrado y seleccionamos la opción REMOVE,
  ahora hacemos clic derecho sobre la solución y buscamos la opción ADD>EXISTING PROJECT, buscamos y seleccionamos el proyecto "ConsoleLogic"
* Ejecutar 🚀

## Aplicación
* Starting at the top left corner of an N x M grid and facing towards the right, you keep walking one square at a time in the direction you are facing. If you reach the boundary of the grid or if the next square you are about to visit has already been visited, you turn right. You stop when all the squares in the grid have been visited. What direction will you be facing when you stop? For example: Consider the case with N = 3, M = 3. The path followed will be (0,0) -> (0,1) -> (0,2) -> (1,2) -> (2,2) -> (2,1) -> (2,0) -> (1,0) -> (1,1). At this point, all squares have been visited, and you are facing right.
* Input specification The first line contains T the number of test cases. Each of the next T lines contain two integers N and M, denoting the number of rows and columns respectively.
* Output specification Output T lines, one for each test case, containing the required direction you will be facing at the end. Output L for left, R for right, U for up, and D for down. 1 <= T <= 5000, 1 <= N,M <= 10^9.

## Uso
Al ejecutar se abrirá una aplicación en modo consola:
* Nos pedirá el valor de T, el cual será un número entero, pulsamos ENTER
* Nos pedirá el tamaño de la matriz para almacenar en N y M, ambos son números enteros y estarán separados por un espacio en blanco, el primer número sera N y el segundo M, pulsamos ENTER
* Nos pedirá tamaños de matrices de acuerdo al número que introdujimos en T
* Se mostrará el mensaje correspondiente de "El último paso del caso # es:" y se pintará una matriz con numeros enteros, que indican el orden en el cual fue avanzando en la cuadrícula, para que podamos corroborar cuál fue el último movimiento
* Se tienen las validaciones de tamaños y de tipo de dato al introducir

Ejemplo:
<pre>
Por favor ingresa el valor de T (número de casos) : 2
Por favor ingresa N y M (separado por un espacio en blanco) para el caso 1: 1 1
Por favor ingresa N y M (separado por un espacio en blanco) para el caso 2: 3 3


El último paso del caso 1 es: R
---- Caso 1 ----
1
-----------------


El último paso del caso 2 es: R
---- Caso 2 ----
1       2       3
8       9       4
7       6       5
-----------------

</pre

