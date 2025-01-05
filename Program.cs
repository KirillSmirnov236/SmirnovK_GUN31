namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Задание 1 Фибоначи первые 8 чисел
            int[] fib = new[] { 0, 1, 1, 2, 3, 5, 8, 13 };

            //Задание 2 string массив месяцев.
            string[] months = new[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            //Задание 3 Матрица 3х3
            int[,] matrix = new int[3, 3] {
                    {2, 3, 4},
                    {4, 9, 16},
                    {8, 27, 56}
            };

            //Задание 4 Зубчатый массив
            double[][] jaggedArray = new double[3][];

            jaggedArray[0] = new double[] { 1, 2, 3, 4, 5 };

            jaggedArray[1] = new double[] { Math.E, Math.PI };

            jaggedArray[2] = new double[] {
            Math.Log10(1),
            Math.Log10(10),
            Math.Log10(100),
            Math.Log10(1000)
        };

            //Задание 5
            int[] array = { 1, 2, 3, 4, 5 };
            int[] array2 = { 7, 8, 9, 10, 11, 12, 13 };

            Array.Copy(array, array2, 3);

            // Вывод
            Console.WriteLine("Array2 with first 3 elements from array");
            for (int i = 0; i < array2.Length; i++) { 
                Console.Write(array2[i] + " ");
            }
            

            //Задание 6
            Array.Resize(ref array, array.Length*2);

            //Вывод\
            Console.WriteLine();
            Console.WriteLine("Array with size x2");
            for (int i = 0; i < array.Length; i++) {
                Console.Write(array[i]+ " ");
            }
        }
    }
}