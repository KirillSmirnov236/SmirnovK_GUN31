

using System.Text;

namespace HomeWork
{
    internal class Program
    {

        public static string ConcatenateStrings(string s1 , string s2) 
        {
            return s1 + s2;
        }

        public static string GreetUser(string name, int age) 
        {
            return $"Hello, {name}! You are {age} years old.";
        }

        public static string StringInfo(string s)
        {
            return $"Number of characters: {s.Length} \n " +
                   $"Uppercase string: {s.ToUpper()} \n" +
                   $"Lowercase string: {s.ToLower()}";
        }

        public static string TakeFirstFiveChars(string s)
        {
            return s.Substring(0, 5);
        }

        public static string StringArrayToSentence(string[] array)
        {
            var sentence = new StringBuilder();
            foreach (var item in array) 
            {
                sentence.Append(item);
                sentence.Append(' ');
            }
            return sentence.ToString();
        }

        public static string ReplaceWordInSentence(string sentence, string replaceWord, string pasteWord)
        {
            return sentence.Replace(replaceWord, pasteWord);
        }


        static void Main(string[] args)
        {
            Console.WriteLine(ConcatenateStrings("Hello Wo", "rd!"));
            Console.WriteLine(GreetUser("Kirill", 21));
            Console.WriteLine(StringInfo("Today im going to play Elden ring."));
            Console.WriteLine(TakeFirstFiveChars("Day#8 snow with rain, -1C"));
            Console.WriteLine(StringArrayToSentence(new string[]{"Sword" , "Bow" , "Spell" }));
            Console.WriteLine(ReplaceWordInSentence("Your name is *? , fine * now you can go.","*","Biba"));
        }

    }
}