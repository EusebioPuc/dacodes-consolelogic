using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            int T=0;
            bool tIncorrecto = true;
            do
            {
                try
                {
                    Console.Write("Por favor ingresa el valor de T (número de casos): ");
                    T = Convert.ToInt32(Console.ReadLine());
                    if (T >= 1 && T <= 5000)
                    {
                        tIncorrecto = false;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("*** No has introducido un valor entero ***");
                }
                
            } while (tIncorrecto);

            int[,] arrNM = new int[T, 2];//0 N , 1 M
            for (int z = 0; z < T; z++)
            {
                bool nmIncorrecto = true;
                do
                {
                    try
                    {
                        Console.Write("Por favor ingresa N y M (separado por un espacio en blanco) para el caso {0}: ", (z+1));
                        string sAux = Console.ReadLine();
                        string[] sNM = sAux.Split(' ');
                        int iN = Convert.ToInt32(sNM[0]);
                        int iM = Convert.ToInt32(sNM[1]);
                        if (iN >= 1 && iN <= 1000000000)
                        {
                            if (iM >= 1 && iM <= 1000000000)
                            {
                                arrNM[z, 0] = iN;
                                arrNM[z, 1] = iM;
                                nmIncorrecto = false;
                            }
                            else
                            {
                                Console.WriteLine("El valor de M debe ser 1 <=  M <= 10 ^ 9");
                            }
                        }
                        else
                        {
                            Console.WriteLine("El valor de M debe ser 1 <=  N <= 10 ^ 9");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("*** No has introducido correctamente los valores para N y M, son 2 enteros separados por un espacio en blanco, intenta nuevamente ***");
                    }
                } while (nmIncorrecto);
            }
            Console.WriteLine();
            Console.WriteLine();

            for (int z = 0; z < T; z++)
            {
                string paso = "R"; // R-Right L-Left D-Down U-Up
                int pasos = 1;
                int[,] matCaso = new int[arrNM[z, 0], arrNM[z, 1]];
                matCaso[0, 0] = 1;
                bool continuar = true;
                int i = 0, j = 0;
                do
                {
                    switch (paso)
                    {
                        case "R":                             
                            if ((j+1) < arrNM[z, 1]) //Solo puede aumentar hasta el penúltimo
                            {
                                if (matCaso[i, (j+1)]==0)
                                {
                                    pasos++;
                                    j++;
                                    paso = "R";
                                    matCaso[i, j] = pasos;
                                }else if ((i + 1) < arrNM[z, 0] && matCaso[(i+1), j] == 0)
                                {
                                    pasos++;
                                    i++;
                                    paso = "D";
                                    matCaso[i, j] = pasos;
                                }
                                else
                                {
                                    Console.WriteLine("El último paso del caso {0} es: R", (z + 1));
                                    continuar = false;
                                }
                            }else if ((j + 1) == arrNM[z, 1]) //Es la última columna
                            {
                                if ((i+1)< arrNM[z, 0] && matCaso[(i+1), j] == 0)
                                {
                                    pasos++;
                                    i++;
                                    paso = "D";
                                    matCaso[i, j] = pasos;
                                }                                    
                                else
                                {
                                    Console.WriteLine("El último paso del caso {0} es: R", (z + 1));
                                    continuar = false;
                                }
                            }                                
                                                       
                            break;
                        case "L":                            
                            if ((j - 1) > 0) //Solo puede reducir hasta antes del inicial
                            {
                                if (matCaso[i, (j - 1)] == 0)
                                {
                                    pasos++;
                                    j--;
                                    paso = "L";
                                    matCaso[i, j] = pasos;
                                }
                                else if ((i - 1) >= 0 && matCaso[(i - 1), j] == 0)
                                {
                                    pasos++;
                                    i--;
                                    paso = "U";
                                    matCaso[i, j] = pasos;
                                }
                                else
                                {
                                    Console.WriteLine("El último paso del caso {0} es: L", (z + 1));
                                    continuar = false;
                                }
                            }
                            else if ((j - 1) == 0 || j==0) //Es la última columna
                            {
                                if (j> 0)
                                {
                                    if ( matCaso[i, (j-1)] == 0)
                                    {
                                        pasos++;
                                        j--;
                                        paso = "L";
                                        matCaso[i, j] = pasos;
                                    }
                                    else if ((i - 1) >= 0 && matCaso[(i - 1), j] == 0)
                                    {
                                        pasos++;
                                        i--;
                                        paso = "U";
                                        matCaso[i, j] = pasos;
                                    }
                                    else
                                    {
                                        Console.WriteLine("El último paso del caso {0} es: L", (z + 1));
                                        continuar = false;
                                    }

                                }
                                else
                                {
                                    if ((i - 1) >= 0 && matCaso[(i - 1), j] == 0)
                                    {
                                        pasos++;
                                        i--;
                                        paso = "U";
                                        matCaso[i, j] = pasos;
                                    }
                                    else
                                    {
                                        Console.WriteLine("El último paso del caso {0} es: L", (z + 1));
                                        continuar = false;
                                    }
                                }                                
                            }                            
                            break;

                        case "U":
                            if ((i - 1) > 0) //Solo puede reducir hasta antes del inicial
                            {
                                if (matCaso[(i-1), j] == 0)
                                {
                                    pasos++;
                                    i--;
                                    paso = "U";
                                    matCaso[i, j] = pasos;
                                }
                                else if ((j+1) <= arrNM[z, 1] && matCaso[i, (j+1)] == 0)
                                {
                                    pasos++;
                                    j++;
                                    paso = "R";
                                    matCaso[i, j] = pasos;
                                }
                                else
                                {
                                    Console.WriteLine("El último paso del caso {0} es: U", (z + 1));
                                    continuar = false;
                                }
                            }
                            else if ((i - 1) == 0 || i==0) //Es la primera fila
                            {
                                if ((j + 1) <= arrNM[z, 1] && matCaso[i, (j+1)] == 0)
                                {
                                    pasos++;
                                    j++;
                                    paso = "R";
                                    matCaso[i, j] = pasos;
                                }
                                else
                                {
                                    Console.WriteLine("El último paso del caso {0} es: U", (z + 1));
                                    continuar = false;
                                }
                            }
                            break;
                        case "D":
                            if ((i + 1) < arrNM[z, 0]) //Solo puede reducir hasta antes del final
                            {
                                if (matCaso[(i + 1), j] == 0)
                                {
                                    pasos++;
                                    i++;
                                    paso = "D";
                                    matCaso[i, j] = pasos;
                                }
                                else if ((j - 1) >=0 && matCaso[i, (j - 1)] == 0)
                                {
                                    pasos++;
                                    j--;
                                    paso = "L";
                                    matCaso[i, j] = pasos;
                                }
                                else
                                {                                    
                                    Console.WriteLine("El último paso del caso {0} es: D", (z + 1));
                                    continuar = false;
                                }
                            }
                            else if ((i + 1) == arrNM[z, 0]) //Es la última fila
                            {
                                if ((j - 1) >=0 && matCaso[i, (j - 1)] == 0)
                                {
                                    pasos++;
                                    j--;
                                    paso = "L";
                                    matCaso[i, j] = pasos;
                                }
                                else
                                {
                                    Console.WriteLine("El último paso del caso {0} es: D", (z+1));
                                    continuar = false;
                                }
                            }
                            break;
                    }
                } while (continuar);

                Console.WriteLine("---- Caso {0} ----",(z+1));
                for (int n = 0; n < arrNM[z, 0]; n++)
                {
                    for (int m = 0; m < arrNM[z, 1]; m++)
                    {
                        Console.Write(matCaso[n,m].ToString() + "\t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("-----------------");
                Console.WriteLine();
                Console.WriteLine();
            }



            Console.ReadKey();
        }
    }
}
