
namespace HomeWork
{
    public struct Interval
    {
        private int Min;
        private int Max;
        private Random random;

        public int Get() 
        {
            return random.Next(Min, Max);
        }

        public Interval(int minValue , int maxValue)
        {
            random = new Random();
            int incrementCounter = 10;

            if (minValue < 0) 
            {
                minValue = 0;
                Console.WriteLine("minValue less than 0!");
            }
            if (maxValue < 0)
            {
                maxValue = 0;
                Console.WriteLine("maxValue less than 0!");
            }
            if (minValue == maxValue)
            {
                maxValue += incrementCounter;
                Console.WriteLine("minValue = maxValue!");
            }
            if (minValue > maxValue)
            {
                (minValue, maxValue) = (maxValue, minValue);
                Console.WriteLine("minValue bigger then maxValue!");
            }
            Min = minValue;
            Max = maxValue;
        }
    }
}
