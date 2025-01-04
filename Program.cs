using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static void Main() {

        Console.WriteLine("number1:");

        if (!int.TryParse(Console.ReadLine(), out int a))
        {
            Console.WriteLine("not a number!");
            return;
        }
       
        
        Console.WriteLine("number2:");

        if (!int.TryParse(Console.ReadLine(), out int b))
        {
            Console.WriteLine("not a number!");
            return;
        }
      

        Console.WriteLine("operation(|, ^ , &):");
        var operation = Console.ReadLine();

        switch (operation[0]) 
        {
            case '|':
                Console.WriteLine("a | b:");
                Console.WriteLine("bin:");
                Console.WriteLine(Convert.ToString(a | b, 2));
                Console.WriteLine("dec:");
                Console.WriteLine(Convert.ToString(a | b, 10));
                Console.WriteLine("hex:");
                Console.WriteLine(Convert.ToString(a | b, 16));
                break;
            case '^':
                Console.WriteLine("a ^ b:");
                Console.WriteLine("bin:");
                Console.WriteLine(Convert.ToString(a ^ b, 2));
                Console.WriteLine("dec:");
                Console.WriteLine(Convert.ToString(a ^ b, 10));
                Console.WriteLine("hex:");
                Console.WriteLine(Convert.ToString(a ^ b, 16));
                break;
            case '&':
                Console.WriteLine("a & b:");
                Console.WriteLine("bin:");
                Console.WriteLine(Convert.ToString(a & b, 2));
                Console.WriteLine("dec:");
                Console.WriteLine(Convert.ToString(a & b, 10));
                Console.WriteLine("hex:");
                Console.WriteLine(Convert.ToString(a & b, 16));
                break;
            default:
                Console.WriteLine("wrong operand!");
                break;
        }

    }
}