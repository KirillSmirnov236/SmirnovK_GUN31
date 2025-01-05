namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Задание 1 Фибоначи
            int a = 0;
            int b = 1;
            int c = 0;

            Console.WriteLine("Fibonachi:");
            Console.Write(a + " " + b);

            for (int i = 0;i < 10; i++)
            {
                c = a + b;
                a = b;
                b = c;
                Console.Write(" " + b);
            }

            //Задание 2 чётные от 2 до 20
            Console.WriteLine();
            Console.WriteLine("Even numbers:");

            for (int i = 2; i <= 20; i += 2)
            {
                Console.Write(i + " ");
            }

            //Задание 3 таблица умножения от 1 до 5
            Console.WriteLine();
            Console.WriteLine("Multiplication table:");

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine();
                for (int j = 1; j <= 10; j++)
                {
                    Console.Write(i * j + " ");
                }
            }

            //Задание 4  ввод пароля
            string password = "qwerty";
            string input = "";

            Console.WriteLine();

            do
            {
                Console.WriteLine("enter password:");
                input = Console.ReadLine();
            }
            while (input != password);

            Console.WriteLine("Correct");
            

        }
    }
}