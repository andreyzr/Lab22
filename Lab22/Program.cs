 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab22
{
    internal class Program
    {
        static void Method1()
        {
            Console.WriteLine("Method1 начал работу");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Method1 выводит счётчик = {i}");
                Thread.Sleep(100);
            }
            Console.WriteLine("Method1 окончил работу");
        }
        static void Method2(Task task, object a)
        {
            int n = (int)a;
            Console.WriteLine("Method2 начал работу");
            for (int i = n; i < n + 10; i++)
            {
                Console.WriteLine($"Method2 выводит счётчик = {i}");
                Thread.Sleep(800);
            }
            Console.WriteLine("Method2 окончил работу");
        }
        static int Method3()
        {
            Console.WriteLine("Method3 начал работу");
            int S = 0;
            for (int i = 0; i < 10; i++)
            {
                S += i;
                Thread.Sleep(500);
            }
            Console.WriteLine("Method3 окончил работу");
            return (S);
        }
        static int Method4(int a)
        {
            Console.WriteLine("Method4 начал работу");
            int S = 0;
            for (int i = 0; i < 10; i++)
            {
                S += a;
                Thread.Sleep(500);
            }
            Console.WriteLine("Method4 окончил работу");
            return (S);
        }
        static void Main(string[] args)
        {
            //Action action = new Action(Method1);
            //Task task = new Task(action); длинная запись 

            //Task task = new Task(Method1); короткая запись 

            //Task task = new Task(delegate() { Console.WriteLine("Hello"); }); используется анаонимный метод

            //Task task = new Task(() => Console.WriteLine("Hello")); с использованием лямнда выражения
            //task.Start();

            //Task task = Task.Factory.StartNew(action); горячяя задача 

            //Task task = Task.Run(action); горячяя задача

            //Task task = new Task(()=>Method2(100));
            //task.Start();

            //Func<int> func = new Func<int>(Method3);
            //Task<int> task = new Task<int>(func);
            //task.Start();
            Action action = new Action(Method1);
            Task task1 = new Task(action);

            Action<Task, object> actionTask = new Action<Task, object>(Method2);
            Task task2 = task1.ContinueWith(actionTask, 100);
            task1.Start();
            //Console.WriteLine(task.Result); 
            Console.WriteLine("Main окончил работу");
            Console.ReadKey();
        }
    }
}
