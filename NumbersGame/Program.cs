namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {

            NumbersGame numbersGame = new();

            int difficulty;
            while (true)
            {
                Console.WriteLine("--- Välj svårighetsgrad ---");
                Console.WriteLine("1: 0-10");
                Console.WriteLine("2: 0-100");
                Console.WriteLine("3: 0-1000");
                
                string answer = Console.ReadLine();
                //Checks that user input is correctly formatted.
                if (int.TryParse(answer, out difficulty) && 
                    difficulty >= 1 && difficulty <= 3)
                {
                    break;                       
                }
                Console.WriteLine("Ange ett giltigt nummer mellan 1 och 3");
            }

            int targetNumber = numbersGame.getTargetNumber(difficulty);

            Console.Write("Jag tänker på ett tal. Gissa vilket: ");

            while (true)
            {
                int guess;
                try
                {
                    guess = int.Parse(Console.ReadLine());
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
                    //Checks distance between guess and target and gives hints.
                    int distance = numbersGame.checkDistance(guess, targetNumber);

                    int burningGrade = numbersGame.getBurningGrade(distance, targetNumber);
                    string burningGradeMessage;
                    switch (burningGrade)
                    {
                        case 1:
                            burningGradeMessage = "Väldigt nära!";
                            break;
                        case 2:
                            burningGradeMessage = "Det bränns!";
                            break;
                        case 3:
                            burningGradeMessage = "Det känns kallt.";
                            break;
                        case 4:
                            burningGradeMessage = "Iskallt. Brr.";
                            break;
                        default:
                            burningGradeMessage = "Fortsätt gissa...";
                            break;

                    }
                    
                    string message = distance > 0 ? "För högt!" : "För lågt!";
                    message += " " + burningGradeMessage;


                    Console.Write("\n" + message + "\n" + "Gissning: ");
                }
            }

        }
        public class NumbersGame
        {
            public int getTargetNumber(int difficulty)
            {
                int low = 0;
                int high = 1;
                for (int i = 0; i < difficulty; i++)
                {
                    high *= 10;
                }
                Random random = new Random();
                int targetNumber = random.Next(low, high);
                return targetNumber;
            }

            public int checkDistance(int guess, int targetNumber)
            {
                return guess - targetNumber;
            }

            public int getBurningGrade(int distance, int targetNumber)
            {
                //Makes distance positive either way and assigns a grade based on how close it is.
                int positiveDistanceNumber = distance < 0 ? -distance : distance;

                switch (positiveDistanceNumber)
                {
                    case 1:
                        return 1;
                        
                    case >= 2 and <= 4:
                        return 2;
                        
                    case >= 5 and <= 10:
                        return 3;
                        
                    default:
                        return 4;
                        
                }
            }
        }
    }
}
