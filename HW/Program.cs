using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());


            Func<object, int[]> func1 = new Func<object, int[]>(GetArray);
            Task<int[]> task1 = new Task<int[]>(func1, n);

            Action<Task<int[]>> action1 = new Action<Task<int[]>>(Print);
            Task task2 = task1.ContinueWith(action1);


            task1.Start();
            Console.ReadKey();
        }
        static int[] GetArray(object a)
        {
            int n = (int)a;
            int[] array = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 100);
            }
            return array;
        }

        static void Print(Task<int[]> task)
        {
            int summ = 0;
            int[] array = task.Result;
            for (int i = 0; i < array.Count(); i++)
            {
                summ +=array[i];
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine(summ);
        }

    }
}
