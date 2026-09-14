namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
            
            int targetNumber = getTargetNumber();

            Console.Write("Jag tänker på ett tal. Gissa vilket: ");

            while (true)
            {
                int guess;
                try
                {
                    guess = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Var god skriv ett giltigt tal.");
                    Console.Write("Gissning: ");
                    continue;
                }
                if (guess == targetNumber)
                {
                    Console.WriteLine("Rätt!");
                    break;
                }
                else
                {
                    int distance = checkDistance(guess, targetNumber);
                    string message = distance > 0 ? "För högt!" : "För lågt!";
                    Console.WriteLine(message + " " + "Gissa igen: ");
                }
            }

        }
        public class NumbersGame
        {
            public int getTargetNumber(int low = 0, int high = 10)
            {
                Random random = new Random();
                int targetNumber = random.Next(low, high);
                return targetNumber;
            }

            private int checkDistance(int guess, int targetNumber)
            {
                return guess - targetNumber;
            }
        }
    }
}
