﻿using System;
using System.Linq;
using System.Xml;

/* В задаче не использовать циклы for, while. Все действия по обработке данных выполнять с использованием LINQ
 * 
 * На вход подается строка, состоящая из целых чисел типа int, разделенных одним или несколькими пробелами.
 * Необходимо оставить только те элементы коллекции, которые предшествуют нулю, или все, если нуля нет.
 * Дважды вывести среднее арифметическое квадратов элементов новой последовательности.
 * Вывести элементы коллекции через пробел.
 * Остальные указания см. непосредственно в коде.
 * 
 * Пример входных данных:
 * 1 2 0 4 5
 * 
 * Пример выходных:
 * 2,500
 * 2,500
 * 1 2
 * 
 * Обрабатывайте возможные исключения путем вывода на экран типа этого исключения 
 * (не использовать GetType(), пишите тип руками).
 * Например, 
 *          catch (SomeException)
            {
                Console.WriteLine("SomeException");
            }
 * В случае возникновения иных нештатных ситуаций (например, в случае попытки итерирования по пустой коллекции) 
 * выбрасывайте InvalidOperationException!
 */
namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ru-RU");
            RunTesk02();
        }

        public static void RunTesk02()
        {
            int[] arr;
            try
            {
                // Попробуйте осуществить считывание целочисленного массива, записав это ОДНИМ ВЫРАЖЕНИЕМ.
                arr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var filteredCollection = arr.TakeWhile(x => x != 0);
                // использовать статическую форму вызова метода подсчета среднего
                checked
                {
                    System.Collections.Generic.IEnumerable<int> collection = filteredCollection.Select(x => x * x);
                    double averageUsingStaticForm = Enumerable.Average(filteredCollection.Select(x => x * x));
                    // использовать объектную форму вызова метода подсчета среднего
                    double averageUsingInstanceForm = filteredCollection.Select(x => x * x).Average();
                    Console.WriteLine($"{averageUsingStaticForm:f3}");
                    Console.WriteLine($"{averageUsingInstanceForm:f3}");
                }

                // вывести элементы коллекции в одну строку
                Console.WriteLine(string.Join(" ", filteredCollection));
            }
            catch (FormatException)
            {
                Console.WriteLine("FormatException");
            }
            catch (OverflowException)
            {
                Console.WriteLine("OverflowException");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("InvalidOperationException");
            }
          
        }
        
    }
}
