

namespace HomeWork
{
    internal class Program
    {
        private class ListTask
        {
            private readonly List<string> _listOfStrings; // Тип данных любой

            public ListTask()
            {
                _listOfStrings = new List<string> { };
                _listOfStrings.Add("Moscow");
                _listOfStrings.Add("Tver");
                _listOfStrings.Add("Vladimir");
            }
            public void TaskLoop()
            {

                // проверка ввода и вывод результата
                Console.WriteLine("type -exit to leave.");
                Console.WriteLine("type line to add:");
                var line = Console.ReadLine();
                if (line == "-exit")
                {
                    return;
                }
                _listOfStrings.Add(line);
                PrintList();
                //
                Console.WriteLine("type line to add in middle:");
                line = Console.ReadLine();
                if (line == "-exit")
                {
                    return;
                }
                int inputIndex = (_listOfStrings.Count) / 2;
                _listOfStrings.Insert(inputIndex, line);
                PrintList();
                //
                line = Console.ReadLine();
                if (line == "-exit")
                {
                    return;
                }
            }
            private void PrintList()
            {
                Console.WriteLine();
                for(int i = 0; i < _listOfStrings.Count; i++)
                {
                    Console.Write(_listOfStrings[i] + " ");
                }
                Console.WriteLine();
            }
        }

        private class DictionaryTask
        {
            private readonly Dictionary<string, double> studentGrades = new Dictionary<string, double>();

            public void TaskLoop()
            {
                Console.WriteLine("type -exit to leave.");
                Console.WriteLine("type student name:");
                var line = Console.ReadLine();
                if (line == "-exit")
                {
                    return;
                }
                Console.WriteLine("type student mark:");
                var mark = Double.Parse(Console.ReadLine());

                studentGrades.Add(line, mark);

                Console.WriteLine("type student name to print:");
                line = Console.ReadLine();

                if (studentGrades.ContainsKey(line))
                {
                    Console.WriteLine("student:" + line + ", mark:" + studentGrades[line]);
                }
                else
                {
                    Console.WriteLine("student " + line + " not exist.");
                }


            }
        }
        private class LinkedListTask
        {
            private Node node1 = new Node();
            private Node node2 = new Node();
            private Node node3 = new Node();
            private Node node4 = new Node();

            private class Node 
            {
                public int Value;

                public Node Next;
                public Node Previous;
            } 

            public LinkedListTask()
            {
                
                node1.Next = node2;
                //node1.Previous = node4;

                node2.Next = node3;
                node2.Previous = node1;

                node3.Next = node4;
                node3.Previous = node2;

                //node4.Next = node1;
                node4.Previous = node3;

            }

            public void TaskLoop()
            {
                Console.WriteLine("type -exit to leave.");
                Console.WriteLine("type list of four int:");

                string input = Console.ReadLine();
                if (input == "-exit")
                {
                    return;
                }
                List<int> numbers = input.Split(' ')
                                     .Select(int.Parse)
                                     .ToList();

                node1.Value = numbers[0];
                node2.Value = numbers[1];
                node3.Value = numbers[2];
                node4.Value = numbers[3];

                Console.WriteLine("list forward:");
                
                var next = node1;

                while(next!= null)
                {
                    Console.WriteLine(next.Value);
                    next = next.Next;
                }

                Console.WriteLine("list reverse:");
                var previous = node4;

                while (previous != null)
                {
                    Console.WriteLine(previous.Value);
                    previous = previous.Previous;
                }
            }
        }

        static void Main(string[] args)
        {

            while (true) 
            {
                Console.WriteLine("Enter 1,2 or 3 to check task 1,2 or 3");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int task))
                {
                    switch (task)
                    {
                        case 1:
                            CheckTaskFirst();
                            break;
                        case 2:
                            CheckTaskSecond(); 
                            break;
                        case 3:
                            CheckTaskThird(); 
                            break;
                        default:
                            Console.WriteLine("Invalid input. Please enter 1, 2, or 3.");
                            break; 
                    }
                    break; 
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            }
        }



        

        private static void CheckTaskFirst()
        {
            var listTask = new ListTask();
            listTask.TaskLoop();
        }
        private static void CheckTaskSecond()
        {
            var dictionaryTask = new DictionaryTask();
            dictionaryTask.TaskLoop();
        }
        private static void CheckTaskThird()
        {
            var linkedListTask = new LinkedListTask();
            linkedListTask.TaskLoop();
        }

    }
}