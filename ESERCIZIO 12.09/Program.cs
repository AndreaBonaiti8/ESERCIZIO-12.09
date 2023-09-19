using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESERCIZIO_12._09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int c, n, p, m, g, ng;                    //dichiarazione delle variabili c, n, p; rispettivamente la variabile della posizione dell'ultimo valore, la variabile che degli gli input e la variabile della posizione ricevuta in input
            Random rnd = new Random();
            Console.WriteLine("Quanti numeri vuoi generare?");
            int[] arr1 = new int[Convert.ToInt16(Console.ReadLine())];
            Console.WriteLine("Inserire il valore più piccolo dei numeri da generare");
            m = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserire il valore più grande dei numeri da generare");
            g = int.Parse(Console.ReadLine());
            c = arr1.Length;
            for (int i = 0; i < arr1.Length; i++)
            {
                ng = rnd.Next(m, g);
            }                        //dichiarazione dell'array array
            bool r = false;       
            Console.Clear();    //reset della console
            do                  //ciclo do while che verifica se ripetere il programma o chiuderlo
            {
               Console.WriteLine("Inserire la lettera associata alla funzione per selezionarla: \r\na - Aggiungere un elemento in coda all'array\r\nv - Visualizzare l'array che restituisca la stringa in HTML\r\nr - Ricerca un numero all'interno dell'array\r\nc - Cancellazione di un elemento nell'array\r\ni - Inserimento di un valore in una posizione dell'array\r\ns - Stampa dell'array aggiornato\r\nt - Troncamento dell'array nella posizione desiderata\r\nz - Inserimento di numeri ordinati nell'array\r\nu - Uscita dal programma"); //output delle indicazioni
                switch (Console.ReadLine())         //switch che verifica l'input ricevuto
                {
                    case "a":
                        Console.WriteLine("Inserire un elemento in coda: ");
                        n = int.Parse(Console.ReadLine());
                        if (Coda(arr1, n, ref c) == true)
                        {
                            Console.WriteLine("Elemento inserito correttamente");
                        }
                        else
                        {
                            Console.WriteLine("Array pieno");
                        }
                        break;
                    case "v":
                        Console.WriteLine(Html(arr1, ref c));
                        break;
                    case "r":
                        Console.WriteLine("Inserire numero da ricercare: ");
                        n = int.Parse(Console.ReadLine());
                        p = Pos(arr1, n, ref c);
                        Console.WriteLine($"Il numero {n} si trova in posizione {p}");
                        break;
                    case "c":
                        Console.WriteLine("Inserire elemento da cencellare: ");
                        n = int.Parse(Console.ReadLine());
                        if ((Canc(arr1, n, ref c)))
                        {
                            Console.WriteLine("Elemento cancellato correttamente");
                        }
                        else
                        {
                            Console.WriteLine("Array vuoto");
                        }
                        break;
                    case "i":
                        Console.WriteLine("Inserire elemento: ");
                        n = int.Parse(Console.ReadLine());
                        Console.WriteLine("Inserire posizione dove aggiungere l'elemento: ");
                        p = int.Parse(Console.ReadLine());
                        if (Ins(arr1, n, p, ref c) == true)
                        {
                            Console.WriteLine("Elemento inserito correttamente");
                        }
                        else
                        {
                            Console.WriteLine("Array pieno");
                        }
                        break;
                    case "s":
                        for (int i = 0; i < c; i++)
                        {
                            Console.Write(arr1[i] + " ");
                        }
                        Console.WriteLine();
                        break;
                    case "t":
                        for (int i = 0; i < c; i++)
                        {
                            Console.Write(arr1[i] + " ");
                        }
                        Console.WriteLine();
                        break;
                    case "z":
                        int[] arr = new int[100];
                        int[] arr2 = new int[arr.Length+arr1.Length];
                        do                              //ciclo do while che verifica che l'input ricevuto sia compreso tra 0 e 25(per questione di comodità)
                        {
                            Console.WriteLine("Inserire numero di elementi iniziale: (0 < N < 25)");    //output del messaggio "Inserire numero di elementi iniziale: (0 < N < 25)"
                            c = int.Parse(Console.ReadLine());                                          //assegnazione a c del valore ricevuto in input dall'utente
                        } while (c < 0 || c > 25);                                                      //codizione che verifica che c sia <0 o >25 per ripetere il ciclo
                        for (byte i = 0; i < c; i++)                                                    //ciclo for per chiedere all'utente l'input c volte
                        {
                            Console.WriteLine($"Inserire elemento iniziale in posizione {i}: ");        //output del messaggio "Inserire elemento iniziale in posizione {i}: " con {i} sostituito dal valore di i
                            arr[i] = int.Parse(Console.ReadLine());                                  //salvataggio in array1[i] del valore ricevuto in input
                        }
                        Console.WriteLine(Insor(arr1, arr, ref arr2));
                        Console.WriteLine();
                        break;                       
                    case "u":
                        r = true;
                        break;
                    default:
                        Console.WriteLine("Opzione non valida");
                        break;
                }
                Console.WriteLine("Premere un tasto per continuare");
                Console.ReadKey();
                Console.Clear();
            } while (r == false);
        }

        static bool Coda(int[] array, int numero, ref int indice)
        {
            bool inserito = true;
            if (indice < array.Length)
            {
                array[indice] = numero;
                indice++;
            }
            else
            {
                inserito = false;
            }
            return inserito;
        }

        static string Html(int[] array, ref int indice)
        {
            string s;
            s = "<!DOCTYPE html>\r\n<html lang=\"it\">\r\n    <head>\r\n    <title>Visualizzazione dell'array</title>\r\n  </head>\r\n  <body>\r\n    <table>\r\n    <tr>";
            for (int i = 0; i < indice; i++)
            {
                s += $"<td> {array[i]} </td>";
            }
            s += $"</tr>\r\n    </table>\r\n    </body>\r\n</html>";
            return s;
        }

        static int Pos(int[] array, int numero, ref int indice)
        {
            int posizione = -1;
            for (int i = 0; i < indice; i++)
            {
                if (array[i] == numero)
                {
                    posizione = i;
                }
            }
            return posizione;
        }

        static bool Canc(int[] array, int numero, ref int indice)
        {
            bool inserito = true;
            if (indice > 0)
            {
                for (int i = 0; i < indice; i++)
                {
                    if (array[i] == numero)
                    {
                        for (; i < indice - 1; i++)
                        {
                            array[i] = array[i + 1];
                        }
                        indice--;
                        break;
                    }
                }
            }
            else
            {
                inserito = false;
            }
            return inserito;
        }

        static bool Ins(int[] array, int numero, int posizione, ref int indice)
        {
            bool inserito = true;
            if (indice < array.Length)
            {
                indice++;
                for (int i = indice; i > posizione; i--)
                {
                    array[i] = array[i - 1];
                }
                array[posizione] = numero;
            }
            else
            {
                inserito = false;
            }
            return inserito;
        }
        static int[] Insor(int[] array1,int[] array2,ref int[] array3)
        {
            int i = 0, j = 0, k = 0;
            for (; i < array1.Length && j < array2.Length; k++)
            {
                if (array1[i] < array2[j])
                {
                    array3[k] = array1[i];
                    i++;
                }
                else
                {
                    array3[k] = array2[j];
                    j++;
                }
            }
            if (i == array1.Length)
            {
                for (; j < array2.Length; j++)
                {
                    array3[k] = array2[j];
                    k++;
                }
            }
            else
            {
                for (; i < array1.Length; i++)
                {
                    array3[k] = array1[i];
                    k++;
                }
            }
            return array3;
        }
    }
}



















